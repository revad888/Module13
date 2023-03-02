using System.Linq;

namespace Task_13._6._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите путь к файлу: ");

            var text = GetText(Console.ReadLine());
            Dictionary<String, Int32> wordsCount = new Dictionary<String, Int32>();

            foreach (var word in text)
            {
                if (wordsCount.ContainsKey(word))
                {
                    wordsCount[word]++;
                }
                else
                {
                    wordsCount.Add(word, 0);
                }
            }

            List<int> counts = wordsCount.Values.ToList();
            counts.Sort();
            counts.Reverse();


            foreach (var i in counts.Take(10))
            {
                foreach (var pair in wordsCount)
                {
                    if (i == pair.Value)
                    {
                        Console.WriteLine($"{pair.Key} встречается в тексте {pair.Value} раз.");
                        break;
                    }
                }

            }

        }

        static string[] GetText(string path)
        {
            string text;

            using (StreamReader sr = new StreamReader(path))
            {
                text = sr.ReadToEnd();
            }

            var noPunctuationText = new string(text.Where(c => !char.IsPunctuation(c)).ToArray());
            var words = noPunctuationText.Split(new char[] { '\r', '\n', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            return words;
        }
    }
}