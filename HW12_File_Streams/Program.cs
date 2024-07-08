using System.Text;

namespace HW12_File_Streams
{
    //Завдання 1:
    //Додаток дозволяє користувачеві переглядати вміст файлу.
    //Користувач вводить шлях до файлу. Якщо файл існує, його вміст
    //відображається на екрані.Якщо файл не існує, виведіть
    //повідомлення про помилку.

    //Завдання 2:
    //Користувач вводить значення елементів масиву з клавіатури.
    //Додаток надає можливість зберігати вміст масиву у файл.

    //Завдання 3:
    //Додайте до другого завдання можливість завантажувати масив
    //із файлу.

    //Завдання 4:
    //Додаток генерує випадковим чином 10000 цілих чисел.
    //Збережіть парні числа в один файл, непарні – в інший. За
    //підсумками роботи додатка потрібно відобразити статистику на
    //екрані.

    //Завдання 5:
    //Додаток надає користувачеві можливість пошуку по файлу:
    // Пошук заданого слова.Додаток показує, чи знайдено слово.
    //Крім того, відображається інформація про те, де знайдено
    //збіг.
    // Пошук кількості входження слова у файл. Додаток
    //відображає кількість знайденого слова.
    // Пошук заданого слова у зворотному порядку. Наприклад,
    //користувач шукає слово «moon». Це означає, що додаток
    //шукає слово «moon» у зворотному напрямку: «noom». За
    //результатами пошуку, додаток відображає кількість
    //входжень.

    //Завдання 6:
    //Користувач вводить шлях до файлу.Додаток відображає
    //статистичну інформацію про файл:
    // кількість речень;
    // кількість великих літер;
    // кількість маленьких літер;
    // кількість голосних літер;
    // кількість приголосних літер;
    // кількість цифр.
    internal class Program
    {
        static void Task1(string filepath)
        {
            if(File.Exists(filepath)) 
            {
                try
                {
                    using (StreamReader sr = new StreamReader(filepath))
                    {
                        Console.WriteLine("File contains:");
                        Console.WriteLine(sr.ReadToEnd());
                    }
                    Console.WriteLine();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else
            {
                Console.WriteLine("File is not exist.");
            }
        }
        static void Task2(string filepath, int[]arr)
        {
            try
            {
                using(StreamWriter sr = new StreamWriter(filepath))
                {
                    foreach(int i in arr)
                    {
                        sr.Write(i + " ");
                    }
                }
                Console.WriteLine("The data were successfully written to the file.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        static int[] Task3(string filepath)
        {
            if (File.Exists(filepath)){
                try
                {
                    using(StreamReader sr = new StreamReader(filepath))
                    {
                        string data = sr.ReadToEnd();
                        string[] sArr = data.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        int[] intArr = new int[sArr.Length];
                        int index = 0;
                        foreach(string i in sArr)
                        {
                            intArr[index] = Convert.ToInt32(i);
                            index++;
                        }
                        return intArr;
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    return new int[0];
                }
            }
            else { Console.WriteLine("File does not exist."); return new int[0]; }
        }
        static void Task4(string  fileOdd, string fileEven)
        {
            Random random = new Random();
            int[] arr = new int[10000];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = random.Next(100);
                Console.WriteLine(arr[i]);
            }

            using (StreamWriter even = new StreamWriter(fileEven))
            using (StreamWriter odd = new StreamWriter(fileOdd))
            {
                foreach (int i in arr)
                {
                    if (i % 2 == 0)
                    {
                        even.Write(i + " ");
                    }
                    else
                    {
                        odd.Write(i + " ");
                    }
                }
            }
            
            int[] evenArr = Task3(fileEven);
            int[] oddArr = Task3(fileOdd);
            Console.WriteLine("Statistic:\n" +
                $"Count of even nums: {evenArr.Length}\n" +
                $"Count of odd nums: {oddArr.Length}\n");
        }
        static void Task5(string filepath)
        {
            try
            {
                string data = File.ReadAllText(filepath);
                string[] sArr = data.Split(new[] { ' ', '\n', '\r', '\t', '.', ',', ';', '!', '?', '-', '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
                 
                while (true)
                {
                    Console.Write("Enter word: ");
                    string word = Console.ReadLine();
                    Console.WriteLine("Enter option: " +
                        "\n1. Search word" +
                        "\n2. Search count of entered word" +
                        "\n3. Search word in reverse order" +
                        "\n0. Exit");
                    int op = Convert.ToInt32(Console.ReadLine());
                    if (op == 0)
                    {
                        break;
                    }
                    else if (op == 1)
                    {
                        bool found = false;
                        for (int i = 0; i < sArr.Length; i++)
                        {
                            if (sArr[i] == word)
                            {
                                Console.WriteLine($"The word {word} was found under the number {i+1}");
                                found = true;
                            }
                        }
                        if (!found)
                            Console.WriteLine("No such word exists in this file");
                    }
                    else if (op == 2)
                    {
                        int count = 0;
                        for (int i = 0; i < sArr.Length; i++)
                        {
                            if (sArr[i] == word)
                            {
                                Console.WriteLine($"The word {word} was found under the number {i}");
                                count++;
                            }
                        }
                        Console.WriteLine($"Еhe word {word} was found {count} times");
                    }
                    else if (op == 3)
                    {
                        int count = 0;
                        char[] chars = word.ToCharArray();
                        Array.Reverse(chars);
                        string reverse_data = new string(chars);

                        for (int i = 0; i < sArr.Length; i++)
                        {
                            if (sArr[i] == reverse_data)
                            {
                                Console.WriteLine($"The word {reverse_data} was found under the number {i}");
                                count++;
                            }
                        }
                        Console.WriteLine($"Еhe word {reverse_data} was found {count} times");

                    }
                    else
                        Console.WriteLine("Invalid option.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            

        }
        static void Task6(string filepath)
        {
            try
            {
                string data = File.ReadAllText(filepath);

                int sentence = data.Split(new[] {'.', '!', '?'}, StringSplitOptions.RemoveEmptyEntries).Length;

                char[] chars = data.ToCharArray();
                int uppercase = 0;
                int lowercase = 0;
                int digits = 0;
                int gol = 0; int prugolosni = 0;
                char[] golosni = { 'a', 'e', 'i', 'o', 'u', 'y'};
                foreach(char c in chars)
                {
                    if (char.IsUpper(c)) uppercase++;
                    if (char.IsLower(c)) lowercase++;
                    if(char.IsDigit(c)) digits++;
                    if (golosni.Contains(char.ToLower(c)))
                        gol++;
                    else prugolosni++;
                }

                Console.WriteLine($"Number of sentences: {sentence}");
                Console.WriteLine($"Number of uppercases : {uppercase}");
                Console.WriteLine($"Number of lowercases: {lowercase}");
                Console.WriteLine($"Number of golosni: {gol}");
                Console.WriteLine($"Number of prugolosni: {prugolosni}");
                Console.WriteLine($"Number of digits: {digits}");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        static void Main(string[] args)
        {
            //----------------- TASK 1 -------------------
            //--------------------------------------------
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Enter the path: ");
            string path1 = $@"{Console.ReadLine()}/file1.txt";
            Task1(path1);

            //--------------- TASK 2 & 3 -----------------
            //--------------------------------------------

            Console.WriteLine("Enter the number of elements in the array:");
            int n = Convert.ToInt32(Console.ReadLine());

            int[] array = new int[n];

            Console.WriteLine("Enter the elements of array:");

            for (int i = 0; i < n; i++)
            {
                array[i] = Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine("Enter the path: ");
            string path2 = $@"{Console.ReadLine()}/file2.txt";

            Task2(path2, array);
            int[] arrayFromFile = Task3(path2);

            Console.WriteLine("Array  from file:");
            foreach (int i in arrayFromFile)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();


            //----------------- TASK 4 -------------------
            //--------------------------------------------

            Console.WriteLine("Enter the path(for odd nums): ");
            string odd_file = $@"{Console.ReadLine()}/Odd_file4.txt";

            Console.WriteLine("Enter the path(for even nums): ");
            string even_file = $@"{Console.ReadLine()}/Even_file4.txt";
            Task4(odd_file, even_file);


            //----------------- TASK 5 -------------------
            //--------------------------------------------
            Console.WriteLine("Enter the path: ");
            string file_search = $@"{Console.ReadLine()}/file5.txt";
            Task5(file_search);


            //----------------- TASK 6 -------------------
            //--------------------------------------------
            Console.WriteLine("Enter the path: ");
            string file_statistic = $@"{Console.ReadLine()}/file6.txt";
            Task6(file_statistic);
        }
    }
}