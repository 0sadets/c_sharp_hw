using System.Reflection.Metadata;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace HW3_String
{
    internal class Program
    {
        //        Task 1:
        //Вставити в задану позицію рядка інший рядок.
        //Task 2:
        //Визначити, чи є рядок паліндромом.Паліндром – це число, слово або фраза, яка однаково читається в обох напрямках.
        //Task 3:
        //Дано текст. Визначте відсоткове відношення малих і великих літер до загальної кількості символів в ньому.
        //Task 4:
        //Дано масив слів.Замінити останні три символи слів, що мають обрану довжину, на символ "$".
        //Task 5:
        //Знайти слово, що стоїть в тексті під певним номером, і вивести його першу букву.
        //Task 6:
        //Дано рядок слів, розділених пробілами.Між словами може бути кілька пробілів, на початку і вкінці рядка також можуть бути пробіли.Ви повинні змінити рядок так, щоб на початку і вкінці пробілів не було, а слова були розділені поодиноким символом "*" (зірочка).
        //Task 7:
        //Користувач вводить слова, поки не буде введено слово з символом крапки вкінці.Сформувати з введених слів рядок, розділивши їх комою з пробілом.Застосувати StringBuilder.

        static void Task1()
        {
            int pos;
            Console.Write("Enter position: ");
            pos = Convert.ToInt32(Console.ReadLine());
            string text = "Lorem Ipsum is simply dummy text of the printing and typesetting industry";
            string insertText = " LOREM IPSUM ";
            text = text.Insert(pos, insertText);
            Console.WriteLine(text);
        }
        static void Task2()
        {
            string word = "радар";
            char[] array = word.ToCharArray();
            Array.Reverse(array);
            string reversed="";
            for(int i =0; i<word.Length; i++)
            {
                reversed += string.Join("", array[i]);
            }
            if(word == reversed)
            {
                Console.WriteLine($"{word} is palindrom");
            }

        }
        static void Task3()
        {
            string text = "Contrary to popular belief, Lorem Ipsum is not simply random text." +
                " It has roots in a piece of classical Latin literature from BC, making it " +
                "over  years old. Richard McClintock, a Latin professor at Hampden-Sydney " +
                "College in Virginia, looked up one of the more obscure Latin words, consectetur," +
                " from a Lorem Ipsum passage, and going through the cites of the word in classical " +
                "literature, discovered the undoubtable source.";
            //Console.WriteLine(text);
            //string[] splitArr = text.Split(new char[] { ',' ,' ', '.',  });
            int low = 0, up = 0;
            foreach (char item in text)
            {
                if (char.IsLower(item))
                {
                    low++;
                }
                else if (char.IsUpper(item))
                {
                    up++;
                }
            }
            float lowerP = low/ (float)text.Length * 100;
            float upperP = up/ (float)text.Length * 100;
            Console.WriteLine($"Відсоткове співвідношення малих літер: {lowerP}");
            Console.WriteLine($"Відсоткове співвідношення великих літер: {upperP}");
        }
        static void Task4()
        {
            string[] words = { "water", "silent", "awesome", "table", "elephant", "soda", "taro" };
            Console.Write("Enter word`s length: ");
            int len = Convert.ToInt32(Console.ReadLine());
            for(int i = 0; i<words.Length; i++)
            {
                if (words[i].Length == len)
                {
                    words[i] = words[i].Substring(0, len - 3) + "$";
                }
            }


            foreach (string word in words)
            {
                Console.Write($"{word} ");
            }
        }
        static void Task5()
        {
            string text = "Lorem Ipsum is simply dummy text of the printing and typesetting industry";
            string[] splitArr = text.Split(new char[] { ',', ' ', '.', });
            Console.Write("Enter position: ");
            int pos = Convert.ToInt32(Console.ReadLine());
            string res = splitArr[pos - 1].Substring(0, splitArr[pos-1].Length - (splitArr[pos - 1].Length -1));
            Console.WriteLine(res);


        }
        static void Task6()
        {
            string text = "    Contrary to   popular belief,    Lorem Ipsum    is not simply     random text. ";
            string[] splitArr = text.Split(new char[] { ',', ' ', '.', }, StringSplitOptions.RemoveEmptyEntries);
            string newStr = string.Join("*", splitArr);
            Console.WriteLine(newStr);
        }
        static void Task7()
        {
            StringBuilder strBuilder = new StringBuilder();
            while (true)
            {
                Console.Write("Enter word: ");
                string str = Console.ReadLine();
                strBuilder.Append($", {str}");
                if (str.Contains("."))
                {
                    break;
                }
            }

            strBuilder.Remove(0, 2);
            Console.WriteLine(strBuilder);
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            //Task1(); // Вставити в задану позицію рядка інший рядок.
            //Task2(); // Визначити, чи є рядок паліндромом.
            //Task3(); // Дано текст. Визначте відсоткове відношення малих і великих літер до загальної кількості символів в ньому.
            //Task4(); // Дано масив слів.Замінити останні три символи слів, що мають обрану довжину, на символ "$".
            //Task5(); // Знайти слово, що стоїть в тексті під певним номером, і вивести його першу букву.
            //Task6(); // Дано рядок слів, розділених пробілами.Між словами може бути кілька пробілів, на початку і вкінці рядка також
                       // можуть бути пробіли.Ви повинні змінити рядок так, щоб на початку і вкінці пробілів не було, а слова були розділені поодиноким символом "*" (зірочка).
            Task7(); // Користувач вводить слова, поки не буде введено слово з символом крапки вкінці.Сформувати з введених слів рядок, розділивши їх комою з пробілом.Застосувати StringBuilder.


        }
    }
}