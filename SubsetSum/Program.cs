using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetSum
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите количество элементов" + Environment.NewLine + "> ");
            int amount;
            while (!Int32.TryParse(Console.ReadLine(), out amount))
            {
                Console.Write("Повторите ввод" + Environment.NewLine + "> ");
            }

            List<int> list = Methods.GenerateRandomList(amount, 10, 99);
            Console.WriteLine(String.Join(", ", list));

            Console.Write("Введите искомую сумму" + Environment.NewLine + "> ");
            int sum;
            while (!Int32.TryParse(Console.ReadLine(), out sum))
            {
                Console.Write("Повторите ввод" + Environment.NewLine + "> ");
            }

            DateTime start = DateTime.Now;
            int greedySum;
            Console.WriteLine("Жадный алгоритм запущен... ");
            var res = Methods.GreedySubsetSum(list, sum, out greedySum);
            Console.WriteLine("Жадный алгоритм: ");
            Console.WriteLine(res == null ? "Не найдено" : String.Join(", ", res));
            Console.WriteLine("Сумма: " + greedySum);
            Console.Write("Затрачено времени: ");
            Console.WriteLine(DateTime.Now - start);

            start = DateTime.Now;
            Console.WriteLine("Полный перебор запущен... ");
            try
            {
                res = Methods.BrutSubsetSum(list, sum);
                Console.WriteLine("Полный перебор: ");
                Console.WriteLine(res == null ? "Не найдено" : String.Join(", ", res));
                Console.Write("Затрачено времени: ");
                Console.WriteLine(DateTime.Now - start);
            }
            catch
            {
                Console.WriteLine("Размер множества слишком большой для полного перебора!");
            }

            Console.ReadKey();
        }
    }
}
