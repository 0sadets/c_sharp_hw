namespace HW10_Events
{
    public delegate void ActionDelegate(int course);
    class Traders
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        private int balance;
        public int Balance
        {
            get { return balance; }
            set { balance = value >= 0 ? value : 0; }
        }
        public void SomeAction(int course)
        {
            if(course >= 40)
            {
                Console.WriteLine($"{Name} {LastName} sales money");
                balance = balance + 1;
                Console.WriteLine($"Left {balance} money");

            }
            else if (course <= 40)
            {
                Console.WriteLine($"{Name} {LastName} buys money");
                balance = balance - 1;
                Console.WriteLine($"Left {balance} money");
            }
            else
            {
                Console.WriteLine($"{Name} {LastName} does nothing");
                Console.WriteLine($"Left {balance} money");

            }
            // P.S. не шарю в темі фінансових бірж, зробила +- як зрозуміла
        }


    }
    class Birzha
    {
        private ActionDelegate actionDelegate;
        public event ActionDelegate ActionDelegate 
        {
            add
            {
                actionDelegate += value;
            }
            remove
            {
                actionDelegate -= value;
            }
        }
        public int GenerateCourse()
        {
            Random random = new Random();
            int course = random.Next(35, 45);
            Console.WriteLine("Course: " + course);
            return course;
        }
        public void SomeAction(int course)
        {
            actionDelegate?.Invoke(course);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Traders> traders = new List<Traders>
            {
                new Traders
                {
                    Name = "Igor",
                    LastName = "Pavluk",
                    Balance = 150

                },
                new Traders
                {
                    Name = "Karen",
                    LastName = "Luise",
                    Balance = 140

                },
                new Traders
                {
                    Name = "Igor",
                    LastName = "Pavluk",
                    Balance = 130

                }
            };
            Birzha birzha = new Birzha();
            foreach (var item in traders)
            {
                birzha.ActionDelegate += new ActionDelegate(item.SomeAction);
            }
            int course = birzha.GenerateCourse();
            birzha.SomeAction(course);
        }
    }
}