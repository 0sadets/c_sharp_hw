namespace HW11_Collections
{
    internal class Program
    {
//        Завдання 1:
//        Реалізувати клас PhoneBook на базі дженерік колекції
//        Dictionary<TKey, TValue>,
//        передбачити додавання, зміну, пошук та видалення записів.
        class Person
        {
            public string Firstname { get; set; }
            public string Lastname { get; set; }
            public DateTime Birthday { get; set; }
            public Person(string f, string l, DateTime d)
            {
                Firstname = f;
                Lastname = l; 
                Birthday = d;
            }
            public void Print()
            {
                Console.Write($"{Firstname} {Lastname} {Birthday.Day}.{Birthday.Month}.{Birthday.Year} ");
            }
        }
        class PhoneBook
        {
            Dictionary<string, Person> dict;
            public PhoneBook()
            {
                dict = new Dictionary<string, Person>();
            }
            public void AddContact(string number,  Person person)
            {
                if(dict.ContainsKey(number))
                {
                    Console.WriteLine("This contact is already exist in PhoneBook. Do you want to rename it?");
                    string answer = Console.ReadLine();
                    if(answer.ToLower() == "yes")
                    {
                        Console.Write("Enter new Firstname: ");
                        string firstname = Console.ReadLine();
                        Console.Write("Enter new Lastname: ");
                        string lastname = Console.ReadLine();
                        ChangeName(number, firstname, lastname);
                    } 
                }
                else
                {
                    dict[number] = person;
                    Console.WriteLine("Contact added successfully.");
                }
                
            }
            public void ChangeName(string number, string newName, string newLastName)
            {
                if (dict.ContainsKey(number))
                {
                    dict[number].Firstname = newName;
                    dict[number].Lastname = newLastName;
                }
                else
                {
                    Console.WriteLine("There is no contact with the entered number.");
                }
            }
            public void ChangeNumber(string number, string newNumber)
            {
                if (dict.ContainsKey(number))
                {
                    Person person1 = dict[number];
                    dict.Remove(number);
                    dict.Add(number, person1);
                }
                else
                {
                    Console.WriteLine("There is no contact with the entered number.");
                }
            }
            public void SearchContact(string number)
            {
                if (dict.ContainsKey(number))
                {
                    PrintContactInfo(number, dict[number]);
                }
                else
                {
                    Console.WriteLine("There is no contact with the entered number.");
                }
            }
            public void SearchContact(Person person)
            {
                if (dict.ContainsValue(person))
                {
                    foreach(var item in dict)
                    {
                        if(item.Value == person)
                        {
                            PrintContactInfo(item.Key, person);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("There is no contact with the entered name.");
                }
            }
            public void PrintContactInfo(string number, Person person)
            {
                person.Print();
                Console.WriteLine($": +38{number}");
            }
            public void PrintPhoneBook()
            {
                Console.WriteLine("----- PhoneBook-----");
                foreach (var item in dict)
                {
                    PrintContactInfo(item.Key, item.Value);
                }
                Console.WriteLine();
            }
            public void DeleteContact(string number) 
            {
                if (dict.ContainsKey(number))
                {
                    dict.Remove(number);
                }
                else
                {
                    Console.WriteLine("There is no contact with the entered number.");
                }
            }

        }
        static void Main(string[] args)
        {
            PhoneBook phoneBook = new PhoneBook();
            Person person1 = new Person ("Sasha","Osadets", new DateTime(2004, 8, 14) );
            Person person2 = new Person ("Madiha", "Connor", new DateTime(2002, 9, 1));
            Person person3 = new Person ("Felix", "Gutierrez", new DateTime(1998, 2, 2));
            Person person4 = new Person ("Leighton", "Gray", new DateTime(1990, 6, 7));
            Person person5 = new Person ("Greta", "Riggs", new DateTime(1989, 7, 17));
            Person person6 = new Person ("Colin", "Hampton", new DateTime(1996, 12, 1));
            Person person7 = new Person ("Colin", "Hampton", new DateTime(1996, 8, 14));

            phoneBook.AddContact("0968315057", person1);
            phoneBook.AddContact("0964586277", person2);
            phoneBook.AddContact("0976542596", person3);
            phoneBook.AddContact("0964434444", person4);
            phoneBook.AddContact("0964444444", person5);
            phoneBook.AddContact("0685663202", person6);
            phoneBook.AddContact("0689525242", person7);
            int answ = 1;
            while (answ != 0)
            {
                Console.WriteLine("1. Show PhoneBook list");
                Console.WriteLine("2. Add contact");
                Console.WriteLine("3. Change contact");
                Console.WriteLine("4. Search contact");
                Console.WriteLine("0. Exit");
                Console.WriteLine("Enter option: ");
                answ = Convert.ToInt32(Console.ReadLine());
                if(answ == 1)
                {
                    phoneBook.PrintPhoneBook();
                }
                else if(answ == 2)
                {
                    Console.WriteLine("Enter number: ");
                    string number = Console.ReadLine();
                    Console.WriteLine("Enter name: ");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter surname: ");
                    string surname = Console.ReadLine(); 
                    Console.WriteLine("Enter birthdate: ");
                    DateTime dateTime;
                    while (!DateTime.TryParse(Console.ReadLine(), out dateTime))
                    {
                        Console.WriteLine("Invalid date format. Please enter birthdate (MM/dd/yyyy): ");
                    }
                    phoneBook.AddContact(number, new Person(name, surname, dateTime));
                }
                else if(answ == 3)
                {
                    Console.WriteLine("1. Change name");
                    Console.WriteLine("2. Change number");
                    int choise = Convert.ToInt32(Console.ReadLine());
                    if(choise == 1)
                    {
                        Console.WriteLine("Enter number: ");
                        string number = Console.ReadLine();
                        Console.WriteLine("Enter new name: ");
                        string name = Console.ReadLine();
                        Console.WriteLine("Enter new surname: ");
                        string surname = Console.ReadLine();
                        phoneBook.ChangeName(number, name, surname);
                    }
                    else if(choise == 2)
                    {
                        Console.WriteLine("Enter number to change: ");
                        string number = Console.ReadLine();
                        Console.WriteLine("Enter new number: ");
                        string newNumber = Console.ReadLine();
                        phoneBook.ChangeNumber(number, newNumber);
                    }
                    else
                    {
                        Console.WriteLine("Invalid choise");
                    }
                }
                else if(answ == 4)
                {
                    Console.WriteLine("1. Search by number");
                    Console.WriteLine("1. Search by name");
                    int choise = Convert.ToInt32(Console.ReadLine());
                    if(choise == 1)
                    {
                        Console.WriteLine("Enter number: ");
                        string number = Console.ReadLine();
                        phoneBook.SearchContact(number);
                    }
                    else if(choise==2)
                    {
                        Console.WriteLine("Enter number: ");
                        string number = Console.ReadLine();
                        Console.WriteLine("Enter name: ");
                        string name = Console.ReadLine();
                        Console.WriteLine("Enter surname: ");
                        string surname = Console.ReadLine();
                        Console.WriteLine("Enter birthdate: ");
                        DateTime dateTime;
                        while (!DateTime.TryParse(Console.ReadLine(), out dateTime))
                        {
                            Console.WriteLine("Invalid date format. Please enter birthdate (MM/dd/yyyy): ");
                        }
                        phoneBook.SearchContact(new Person(name, surname, dateTime));
                    }
                    else
                    {
                        Console.WriteLine("Invalid choise");
                    }
                }
            }


        }
    }
}