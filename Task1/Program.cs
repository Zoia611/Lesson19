using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static void Main(string[] args, List<Comp> com1, List<Comp> com3)
        {
            List<Comp> computers = new List<Comp>()
            {
                new Comp(){Articul = "0001", Name = "Asus", TypeCPU = "Intel Core i7", FrequencyCPU = 2.2, RAM =16, SSD = 512, VideoRAM = 8192, Price=100, Availability = 20},
                new Comp(){Articul = "0002", Name = "Redmibook", TypeCPU = "Intel Core i5", FrequencyCPU = 2.2, RAM =16, SSD = 512, VideoRAM = 4096, Price=150, Availability = 50},
                new Comp(){Articul = "0003", Name = "Apple", TypeCPU = "Intel Core i3", FrequencyCPU = 2.4, RAM =32, SSD = 512, VideoRAM = 8192, Price=200, Availability = 30},
                new Comp(){Articul = "0004", Name = "HP", TypeCPU = "Intel Core i3", FrequencyCPU = 2.3, RAM =16, SSD = 512, VideoRAM = 4096, Price=180, Availability = 20},
                new Comp(){Articul = "0005", Name = "Hasee", TypeCPU = "Intel Core i7", FrequencyCPU = 2.4, RAM =16, SSD = 512, VideoRAM = 4096, Price=100, Availability = 20},
                new Comp(){Articul = "0006", Name = "Lenovo", TypeCPU = "Intel Core i5", FrequencyCPU = 2.2, RAM =8, SSD = 512, VideoRAM = 8192, Price=120, Availability = 40},
                new Comp(){Articul = "0007", Name = "Redmibook", TypeCPU = "Intel Core i7", FrequencyCPU = 2.3, RAM =16, SSD = 512, VideoRAM = 8192, Price=100, Availability = 60},
                new Comp(){Articul = "0008", Name = "MSI", TypeCPU = "Intel Core i5", FrequencyCPU = 2.3, RAM =32, SSD = 512, VideoRAM = 4096, Price=200, Availability = 10},
                new Comp(){Articul = "0009", Name = "Asus x415", TypeCPU = "Intel Core i3", FrequencyCPU = 2.3, RAM =8, SSD = 512, VideoRAM = 4096, Price=160, Availability = 20},
                new Comp(){Articul = "0010", Name = "Lenovo thingpad", TypeCPU = "Intel Core i5", FrequencyCPU = 2.4, RAM =8, SSD = 512, VideoRAM = 4096, Price=150, Availability = 40}
            };
            Console.WriteLine("Введите марку процессора");
            string cpu = Console.ReadLine().ToLower();
            List<Comp> comp1 = computers.Where(x => x.TypeCPU.ToLower().Contains(cpu)).ToList();
            Console.WriteLine("Список компьютеров с процессором марки {0}:", cpu);
            Print(com1);

            Console.WriteLine("Введите объем оперативной памяти, Gb");
            int ram = Convert.ToInt32(Console.ReadLine());
            List<Comp> com2 = computers.Where(x => x.RAM >= ram).ToList();
            Console.WriteLine($"Список компьютеров с объемом памяти от {ram}Gb:");
            Print(com2);
            Console.WriteLine();

            Console.WriteLine("Cписок компьютеров, по увеличению стоимости и по наличию:");
            List<Comp> comp3 = computers.OrderBy(x => x.Price).ThenBy(x => x.Availability).ToList();
            Print(com3);

            Console.WriteLine("Список компьютеров по типу процессора:");
            IEnumerable<IGrouping<string, Comp>> comp4 = computers.GroupBy(x => x.TypeCPU);
            foreach (IGrouping<string, Comp> gr in comp4)
            {
                Console.WriteLine(gr.Key);
                foreach (Comp c in gr)
                {
                    Console.WriteLine($"{c.Articul} {c.Name} {c.TypeCPU} {c.Price} {c.Availability}");
                }
            }

            Console.WriteLine();

            int maxPrice = computers[0].Price;
            int minPrice = computers[0].Price;
            var compMaxPrice = computers[0];
            var compMinPrice = computers[0];
            int count = 0;
            foreach (var c in computers)
            {
                if (maxPrice < c.Price)
                    compMaxPrice = c;
                if (minPrice > c.Price)
                    compMinPrice = c;
                if (c.Availability < 30)
                    count++;
            }
            Console.WriteLine("Самый дорогой компьютер:");
            Console.WriteLine($"{compMaxPrice.Articul} {compMaxPrice.Name} {compMaxPrice.Price}тыс.руб");
            Console.WriteLine("Самый дешевый компьютер:");
            Console.WriteLine($"{compMinPrice.Articul} {compMinPrice.Name} {compMinPrice.Price}тыс.руб");
            Console.WriteLine(count > 0 ? "Есть компьютеры в количестве менее 30 шт." : "Нет компьютеров в количестве менее 30 шт.");

            Console.ReadKey();
        }
        static void Print(List<Comp> computers)
        {
            foreach (Comp c in computers)
            {
                Console.WriteLine($"{c.Articul} {c.Name} {c.Price} тыс.руб. В наличии {c.Availability} шт.");
            }
            Console.WriteLine();
        }
    }
}
