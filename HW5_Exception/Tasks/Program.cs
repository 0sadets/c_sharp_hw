namespace Tasks
{

    internal class Program
    {
        class CreditCard
        {
            private string cardNumber;
            private string pib;
            private string cvc;
            private DateTime endDate;

            public string CardNumber
            {
                get { return cardNumber; }
                set 
                {
                    if (value.Length < 13 || value.Length > 19)
                    {
                        throw new ArgumentException("Invalid card number length.");
                    }
                    foreach (char item in value)
                    {
                        if(char.IsDigit(item) == false)
                        {
                            throw new ArgumentException("Card Number consists of digits only.");
                        }
                    }
                    cardNumber = value;
                }
            }
            public string Pib { get; set; }
            public string Cvc 
            { 
                get { return cvc; }
                set
                {
                    if (value.Length != 3)
                    {
                        throw new ArgumentException("Invalid CVC length.");
                    }
                    foreach (char c in value)
                    {
                        if (!char.IsDigit(c))
                        {
                            throw new ArgumentException("CVC must contain digits only.");
                        }
                    }
                    cvc = value;
                }
            }
            public DateTime EndDate
            {
                get { return endDate; }
                set
                {
                    if(value.Date <  DateTime.Today)
                    {
                        throw new ArgumentException("Invalid Date. End date must be in the future.");
                    }
                    endDate = value;
                }
            }
            public CreditCard()
            {
                CardNumber = "0000000000000000";
                Pib = "";
                Cvc = "000";
                EndDate = DateTime.Today;
            }
            public CreditCard(string cardNumber, string pib, string cvc, DateTime endDate)
            {
                CardNumber = cardNumber;
                Pib = pib;
                Cvc = cvc;
                EndDate = endDate;
            }
            public void Print()
            {
                Console.WriteLine("Credit Card:");
                Console.WriteLine($"Number: {CardNumber}");
                Console.WriteLine($"PIB: {Pib}");
                Console.WriteLine($"CVC: {Cvc}");
                Console.WriteLine($"End Date: {EndDate}");
            }
        }
        static void Main(string[] args)
        {
            // Task1
            Console.Write("Enter nums: ");
            string nums = Console.ReadLine();

            try
            {
                int number = Convert.ToInt32(nums);
                Console.WriteLine($"Converted number: {number}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid format.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Input string is too large to be converted to an integer.");
            }
            //----------------------------------------------------------------------------------
            // Task2
            Console.Write("Enter 0 and 1: ");
            string input = Console.ReadLine();

            int res = 0;
            for (int i = 0, j = input.Length - 1; i < input.Length; i++)
            {
                try
                {
                    if (input[i] != '1' && input[i] != '0')
                    {
                        Console.WriteLine($"Error: {input[i]}");
                        throw new Exception("Invalid num. Try only 1 or 0");
                    }
                    else
                    {
                        int num = Convert.ToInt32(input[i].ToString());
                        Console.WriteLine($"num: {num}, j: {j}");
                        res += num * (int)Math.Pow(2, j);
                    }
                    j--;
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Result is out of range of int type.");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }

            }
            Console.WriteLine($"Result: {res}");

            //----------------------------------------------------------------------------------
            // Task3
            try
            {
                CreditCard creditCard = new CreditCard("1234567891234567", "Osadets Olexandra Romanivna", "123", new DateTime(2024, 11, 3));
                creditCard.Print();
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            //----------------------------------------------------------------------------------
            // Task4
            try
            {
                Console.Write("Enter: ");
                string input1 = Console.ReadLine();
                string[] arr = input1.Split('*');
                int res1 = 1;
                foreach(string a in arr)
                {
                    int num = Convert.ToInt32(a);
                    res1 *= num; 
                }
                Console.WriteLine($"{input1} = {res1}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Enter only integers and '*' operator.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Input value is too large to be converted to an integer.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
//Завдання 1
//Користувач вводить до рядка з клавіатури набір символів від 0-9. Необхідно перетворити рядок на число цілого типу. Передбачити випадок виходу за межі діапазону,
//який визначається типом int. Використовуйте механізм
//виключень.
//Завдання 2
//Користувач вводить до рядка з клавіатури 0 і 1. Необхідно перетворити рядок на число цілого типу в десятковому
//поданні. Передбачити випадок виходу за межі діапазону,
//який визначається типом int, неправильне введення. Використовуйте механізм виключень.
//Завдання 3
//Створіть клас «Кредитна картка». Вам необхідно зберігати інформацію про номер картки, ПІБ власника, CVC, дату
//завершення роботи картки і т.д. Передбачити механізми
//ініціалізації полів класу. Якщо значення для ініціалізації
//неправильне, генеруйте виняток. 
//Завдання 4
//Користувач вводить до рядка з клавіатури математичний вираз. Наприклад, 3*2*1*4. Програма має підрахувати
//результат введеного виразу. У рядку можуть бути лише
//цілі числа і оператор*. Для обробки помилок введення
//використовуйте механізм виключень.