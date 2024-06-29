using System.Text;

namespace Statistic
{
    internal class Program
    {
//        Програма «Статистика»
//Підрахувати, скільки разів кожне слово зустрічається у заданому
//текстi.Результат записати до колекції Dictionary<
//TKey, TValue>. Текс використовувати із додатка 1.
//Вивести статистику за текстом у вигляді таблиці (рис. 1).
//Додаток 1.
//Ось будинок, який збудував Джек.А це пшениця, яка
//у темній коморі зберігається у будинку, який збудував
//Джек.А це веселий птах-синиця, який часто краде
//пшеницю, яка в темній коморі зберігається у будинку,
//який збудував Джек.

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            string text = "Ось будинок, який збудував Джек. А це пшениця, " +
                "яка у темній коморі зберігається у будинку, який " +
                "збудував Джек. А це веселий птах-синиця, який часто" +
                " краде пшеницю, яка в темній коморі зберігається" +
                " у будинку, який збудував Джек.";
            string[] words = text.Split(new char[] { ' ', '.', ',', '-' }, StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, int> dict = new Dictionary<string, int>();
            foreach (string word in words)
            {
                if (dict.ContainsKey(word))
                {
                    dict[word] = dict[word] + 1;
                }
                else
                {
                    dict.Add(word, 1);
                }
            }
            
            int i = 1; int unic = 0;
            Console.WriteLine("{0, -10} {1, -15} {2, -15}", "Номер", "Слово:", "К-ть");
            foreach (var word in dict) 
            {
                Console.WriteLine("{0, -10} {1, -15} {2, -15}", i, word.Key, word.Value);
                i++;

                if (word.Value == 1)
                {
                    unic++;
                }
            }
            
            Console.WriteLine("{0, -15} {1, -15}", $"Всього слiв: {words.Length}", $"Iз них унiкальних: {unic}");
        }
    }
}