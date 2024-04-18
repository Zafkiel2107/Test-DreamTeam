using System.IO;
using System.Xml.Linq;
using Tester;
using static Tester.Data;

namespace VacancyTest
{
    public class Engine
    {
        public static void Calc(Data data)
        {
            Console.WriteLine("1. Список товаров и дат ролзива");
            var query1 = from pr in data.Products
                        join pa in data.Parts on pr.ID equals pa.IDProduct
                        select new { Title = pr.Title, DateFilling = pa.DateFilling };

            Console.WriteLine("2. Список товаров с суммарным количеством и количеством партий");
            var query2 = from p in data.Products
                         join pa in data.Parts on p.ID equals pa.IDProduct into productParts
                         from pp in productParts.DefaultIfEmpty()
                         join r in data.Records on pp.ID equals r.IDPart into recordParts
                         from rp in recordParts.DefaultIfEmpty()
                         group new { p, pp } by new { p.ID, p.Title } into g
                         select new
                         {
                             Title = g.Key.Title,
                             TotalAmount = g.Sum(x => x.pp.Amount),
                             NumberOfParts = g.Select(x => x.pp.ID).Distinct().Count()
                         };

            Console.WriteLine("3. Список всех ячеек с возможным содержимым");
            var query3 = from cell in data.Cells
                        join record in data.Records on cell.ID equals record.IDCell into cellRecords
                        from cr in cellRecords.DefaultIfEmpty()
                        join part in data.Parts on cr?.IDPart equals part.ID into recordParts
                        from rp in recordParts.DefaultIfEmpty()
                        group new { cell, rp } by new { cell.ID, ProductTitle = rp != null ? data.Products.First(p => p.ID == rp.IDProduct).Title : "Empty" } into g
                        select new
                        {
                            CellID = g.Key.ID,
                            ProductTitle = g.Key.ProductTitle,
                            NumberOfParts = g.Count(x => x.rp != null),
                            TotalAmount = g.Sum(x => x.rp != null ? x.rp.Amount : 0)
                        };
        }    
    }
}
