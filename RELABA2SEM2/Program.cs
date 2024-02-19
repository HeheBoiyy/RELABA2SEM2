using RELABA2SEM2;

namespace Laba2Sem2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ТЕСТ 1 (РАЗНЫЕ ДЛИНЫ)");
            List<object> initialList = new List<object>
            {
            new Test { Id = 1, Name = "John" },
            
            };

            List<object> controlList = new List<object>
            {
            new Test { Id = 1, Name = "John" },
            new Test { Id = 2,Name = "David"}
            };

            Comparer comparer = new Comparer(initialList);
            comparer.Compare(controlList);
            Console.WriteLine("\n\n");



            Console.WriteLine("ТЕСТ 2 (НЕЧИТАЕМЫЙ ТИП)");

            List<object> initialList1 = new List<object>
            {
            new Test { Id = 1, Name = "John" },
            new Test2NOTCOMPARABLE { Id = 2,Name="David"}
            };

            List<object> controlList1 = new List<object>
            {
            new Test { Id = 1, Name = "John" },
            new Test2NOTCOMPARABLE { Id = 2,Name="David"}
            };

            Comparer comparer1 = new Comparer(initialList1);
            comparer1.Compare(controlList1);
            Console.WriteLine("\n\n");



            Console.WriteLine("ТЕСТ 3 (РАСХОЖДЕНИЕ ТИПОВ)");

            List<object> initialList2 = new List<object>
            {
            new Test { Id = 1, Name = "John" },
            new Test { Id = 2,Name="David"}
            };

            List<object> controlList2 = new List<object>
            {
            new Test { Id = 1, Name = "John" },
            new Test3 { Id = 2,Name="David"}
            };

            Comparer comparer2 = new Comparer(initialList2);
            comparer2.Compare(controlList2);
            Console.WriteLine("\n\n");



            Console.WriteLine("ТЕСТ 4 (РАСХОЖДЕНИЕ ЗНАЧЕНИЙ)");

            List<object> initialList3 = new List<object>
            {
            new Test { Id = 1, Name = "John" },
            new Test { Id = 2,Name="David"}
            };

            List<object> controlList3 = new List<object>
            {
            new Test { Id = 1, Name = "John" },
            new Test { Id = 2,Name="Anton"}
            };

            Comparer comparer3 = new Comparer(initialList3);
            comparer3.Compare(controlList3);
            Console.WriteLine("\n\n");



            Console.WriteLine("ТЕСТ 5 (ПРОПУСК НЕЧИТАЕМЫХ ПОЛЕЙ)");

            List<object> initialList4 = new List<object>
            {
            new Test { Id = 1, Name = "John" },
            new Test4 { Id = 4,Name="David"} // Разные ID
            };

            List<object> controlList4 = new List<object>
            {
            new Test { Id = 1, Name = "John" },
            new Test4 { Id = 2,Name= "David"}
            };

            Comparer comparer4 = new Comparer(initialList4);
            comparer4.Compare(controlList4);
            Console.WriteLine("\n\n");




            Console.WriteLine("ТЕСТ 6 (Равные списки)");

            List<object> initialList5 = new List<object>
            {
            new Test { Id = 1, Name = "John" },
            new Test4 { Id = 4,Name="David"},
            new Test3 { Id = 3,Name = "Anton"}
            };

            List<object> controlList5 = new List<object>
            {
            new Test { Id = 1, Name = "John" },
            new Test4 { Id = 2,Name= "David"},
            new Test3 { Id = 3,Name = "Anton"}
            };

            Comparer comparer5 = new Comparer(initialList5);
            comparer5.Compare(controlList5);
            Console.WriteLine("\n\n");
        }
    }
}
