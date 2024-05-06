using System.Drawing;
namespace Worker
{
    internal class Program
    {
        class Worker
        {
            string name;
            string lastName;
            int age;
            int salary;
            DateTime employmentDate;

            public string Name
            {
                get { return name; }
                set
                {
                    if (value == null)
                    {
                        throw new ArgumentException("Worker name cannot be epty");
                    }
                    name = value;
                }
            }
            public string LastName
            {
                get { return lastName; }
                set
                {
                    if (value == null)
                    {
                        throw new ArgumentException("Worker lastname cannot be empty");
                    }
                    lastName = value;
                }
            }

            public int Age
            {
                get { return age; }
                set
                {
                    if (value < 18)
                    {
                        throw new ArgumentException("Worker must be at least 18 years old.");
                    }
                    age = value;
                }
            }
            public int Salary
            {
                get { return salary; }
                set
                {
                    if (value < 0)
                    {
                        throw new ArgumentException("Salary cannot be less then zero.");
                    }
                    salary = value;
                }
            }
            public DateTime EmploymentDate
            {
                get { return employmentDate; }
                set
                {
                    if (value.Date > DateTime.Today)
                    {
                        throw new ArgumentException("Invalid Date");
                    }
                    employmentDate = value;
                }
            }
            public Worker(string n, string l, int age, int salary, DateTime eDate)
            {
                Name = n;
                LastName = l;
                Age = age;
                Salary = salary;
                EmploymentDate = eDate;
            }
            public void PrintInfo()
            {
                Console.WriteLine($"Worker: {name} {lastName}.");
                Console.WriteLine($"Age: {age}");
                Console.WriteLine($"Salary: {salary}");
                Console.WriteLine($"HireDate: {employmentDate}");
            }

        }
        static void Main(string[] args)
        {
            //Написати програму, що виконує наступні дії:
            //1.введення з клавіатури даних в масив, що складається з п'яти
            //елементів типу Worker (записи повинні бути впорядковані за алфавітом);
            //2.якщо значення якогось параметру введено не в відповідному форматі
            //-згенерувати відповідний exception.

            int size = 5;
            Worker[] worker = new Worker[size];
            //for (int i = 0; i < 5; i++)
            //{
            //    try
            //    {

            //        Console.WriteLine($"{i+1} Worker");
            //        Console.Write("Enter name: ");
            //        string name = Console.ReadLine();
            //        Console.Write("Enter lastname: ");
            //        string lastname = Console.ReadLine();
            //        Console.Write("Enter age: ");
            //        int age = Convert.ToInt32(Console.ReadLine());
            //        Console.Write("Enter salary: ");
            //        int salary = Convert.ToInt32(Console.ReadLine());
            //        Console.Write("Enter hire date: ");
            //        DateTime date = Convert.ToDateTime(Console.ReadLine());
            //        worker[i] = new Worker(name, lastname, age, salary, date);
            //        Console.WriteLine();
            //    }
            //    catch (ArgumentException e)
            //    {
            //        Console.WriteLine(e.Message);
            //        Console.WriteLine("Skipping this worker...");
            //        Console.WriteLine();
            //    }
            //}

            // 3.вивід на екран прізвища працівника, стаж роботи якого
            // перевищує введене з клавіатури значення.
            try
            {
                worker[0] = new Worker("Tom", "Jonson", 25, 500, new DateTime(2023, 8, 25));
                worker[1] = new Worker("Tim", "Jinson", 26, 15600, new DateTime(2022, 9, 26));
                worker[2] = new Worker("Tum", "Junson", 27, 5400, new DateTime(2018, 10, 27));
                worker[3] = new Worker("Tem", "Jenson", 19, 5100, new DateTime(2019, 11, 28));
                worker[4] = new Worker("Tam", "Janson", 17, 5000, new DateTime(2022, 12, 29));

            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.Write("Enter num: ");
            int num = Convert.ToInt32(Console.ReadLine());
            foreach (Worker w in worker)
            {
                TimeSpan timeSpan = DateTime.Now - w.EmploymentDate;
                double years = timeSpan.TotalDays / 365;
                if (years > num)
                {
                    Console.WriteLine(w.LastName);
                }
            }
        }
    }
}