using System.Diagnostics;
using System.Threading;

namespace Task_13._6._1
{
    internal class Program
    {

        static void Main(string[] args)
        {
            List<char> list = new List<char>();
            LinkedList<char> linked = new LinkedList<char>();

            Console.Write("Введите путь к файлу: ");
            var text = GetText(Console.ReadLine());

            var speedList = Stopwatch.StartNew();
            foreach (char c in text)
            {
                list.Add(c);
            }
            Console.WriteLine($"List отработал за {speedList.Elapsed.TotalMilliseconds} мс. Вставленно {text.Count()} символов.");

            var speedLinked = Stopwatch.StartNew();
            foreach (char c in text)
            {
                linked.AddLast(c);
            }

            Console.WriteLine($"LinkedList отработал за {speedList.Elapsed.TotalMilliseconds} мс. Вставленно {text.Count()} символов.");
        }

        static string GetText(string path)
        {
            string text;

            using (StreamReader sr = new StreamReader(path))
            {
                text = sr.ReadToEnd();
            }

            return text;
        }

    }

}