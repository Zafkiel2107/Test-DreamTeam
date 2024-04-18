using Tester;
using VacancyTest;


var data = new Data
{
    Products =
    [
        new Data.Product { ID = 1, Title = "Водка Особая" },
        new Data.Product { ID = 2, Title = "Коньяк 5*" },
        new Data.Product { ID = 3, Title = "Вино Столовое" }
    ],
    Cells = [
        new Data.Cell { ID = 1, Title = "A-1"},
        new Data.Cell { ID = 2, Title = "A-2" },
        new Data.Cell { ID = 3, Title = "A-3" }
    ],
    Parts =
    [
        new Data.Part { ID = 1, IDProduct = 1, Amount = 100, DateFilling = new DateTime(2023, 12, 25) },
        new Data.Part { ID = 2, IDProduct = 1, Amount = 200, DateFilling = new DateTime(2023, 5, 10) },
        new Data.Part { ID = 3, IDProduct = 2, Amount = 30, DateFilling = new DateTime(2022, 1, 6) },
        new Data.Part { ID = 4, IDProduct = 3, Amount = 50, DateFilling = new DateTime(2021, 4, 30) }
    ],
    Records =
    [
        new Data.Record { IDCell = 1, IDPart = 1 },
        new Data.Record { IDCell = 1, IDPart = 2 },
        new Data.Record { IDCell = 2, IDPart = 4 },
    ]
};


Engine.Calc(data);
Console.ReadKey();

namespace Tester
{
    public class Data
    {
        public Product[] Products { get; set; } = null!;
        public Cell[] Cells { get; set; } = null!;
        public Part[] Parts { get; set; } = null!;
        public Record[] Records { get; set; } = null!;

        public class Product
        {
            public int ID { get; set; }
            public string Title { get; set; } = null!;
        }
        public class Cell
        {
            public int ID { get; set; }
            public string Title { get; set; } = null!;
        }
        public class Part
        {
            public int ID { get; set; }
            public int IDProduct { get; set; }
            public int Amount { get; set; }
            public DateTime DateFilling { get; set; }
        }

        public class Record
        {
            public int IDCell { get; set; }
            public int IDPart { get; set; }
        }



    }
}

