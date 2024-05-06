namespace Calc
{
    internal class Program
    {
        class Calculator
        {
            private int a;
            private int b;
            public int A { get; set; }
            public int B { get; set; }
            public int Add()
            {
                return A + B;
            }
            public int Sub()
            {
                return A - B;
            }
            public int Mul()
            {
                return A * B;
            }
            public double Div()
            {
                if(B == 0)
                {
                    throw new ArgumentException("Second operand cannot be zero.");
                }
                return A / B;
            }
            public Calculator()
            {
                A = 0;
                B = 0;
            }
            public Calculator(int a, int b)
            {
                A = a;
                B = b;
            }

        }
        static void Main(string[] args)
        {
            while(true) { 
            Console.Write("Enter a: ");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter b: ");
            int b = Convert.ToInt32(Console.ReadLine());
            Calculator calc = new Calculator(a, b);
            Console.Write("Enter arithmetic operation('+', '-', '*', '/'):  ");
            char op = Convert.ToChar(Console.ReadLine());
            try
            {
                
                if(op == '+')
                {
                    int res = calc.Add();
                    Console.WriteLine($"{a} + {b} = {res}");
                }
                else if (op == '-')
                {
                    int res = calc.Sub();
                    Console.WriteLine($"{a} - {b} = {res}");
                }
                else if (op == '*')
                {
                    int res = calc.Mul();
                    Console.WriteLine($"{a} * {b} = {res}");
                }
                else if (op == '/')
                {
                    double res = calc.Div();
                    Console.WriteLine($"{a} / {b} = {res}");
                }
                else
                {
                    throw new Exception("Invalid operation");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            }
        }
    }
}

//Завдання 2:
//Створіть клас Calculator.
//У класі реалізувати чотири методи для арифметичних дій:
//1.Add – додавання
//2.	Sub – віднімання
//3.	Mul – множення
//4.	Div - ділення.
//Метод ділення повинен робити перевірку ділення на нуль, якщо перевірка не
//проходить, згенерувати виключення.
//Користувач вводить значення, над якими хоче зробити операцію і
//вибирає саму операцію. При виникненні помилок повинні генеруватися виключення.
