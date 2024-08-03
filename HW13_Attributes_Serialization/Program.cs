using System.ComponentModel.DataAnnotations;
using static HW13_Attributes_Serialization.Program;
using System.Xml.Linq;
using System.Text.Json;
using System;

namespace HW13_Attributes_Serialization
{
    internal class Program
    {
        /*
        *   СПЕЦ. СИМВОЛИ
    \d - Визначає символи цифр. 
    \D - Визначає любий символ, який не є цифрою. 
    \w - Визначає любий символ цифри, букви або нижнє підкреслення. 
    \W - Визначає любий символ, який не є цифрою, буквою або нижнім підкресленням.. 
    \s - Визначає любий недрукований символ, включаючи пробіл. (таб і перехід на новий рядок)
    \S - Визначає любий символ, крім символів табуляции, нового рядка и повернення каретки.
    .  - Визначає любий символ крім символа нового рядка.  
    \. - Визначає символ крапки.

     
      КВАНТИФИКАТОРЫ
    ^ - з початку рядка.
    $ - з кінця рядка.
    * - нуль і більше входжень підшаблону в сторці.
    + - одне і більше входжень підшаблону в сторці.
    ? - нуль чи одне входження підшаблону в сторці.
     */
        static int id = 1000; 
        static string fileName = "User.json";
        [Serializable]
        public class User
        {
            [Required(ErrorMessage = "Id not setted")]
            [Range(1000, 9999, ErrorMessage = "Error id")]
            public int Id { get; set; }

            [Required(ErrorMessage = "Login not setted")]
            [RegularExpression("^[A-Za-z]+$", ErrorMessage ="Invalid Login. ")]
            public string Login { get; set; }

            [Required(ErrorMessage = "Password not setted")]
            [RegularExpression("^[a-zA-Z0-9]{8,}$", ErrorMessage = "Password must be at least 8 characters long and contain only letters and numbers.")]
            public string Password { get; set; }

            [Required(ErrorMessage = "ConfirmPassword not setted")]
            [Compare(nameof(Password), ErrorMessage = "Not confirm password")]
            public string ConfirmPassword { get; set; }

            [Required(ErrorMessage = "Email not setted"), EmailAddress]
            [RegularExpression(@"[a-zA-Z0-9]+@gmail\.com$", ErrorMessage ="Email must be gmail.com")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Phone not setted"), Phone]
            [RegularExpression(@"^\+38-0\d{2}-\d{3}-\d{2}-\d{2}$", ErrorMessage ="Invalid phone number. Must contain 10 digits")]
            public string Phone { get; set; }

            [Required(ErrorMessage = "CreditCard not setted")]
            [RegularExpression(@"^\d{16}$", ErrorMessage = "Credit card number must be 16 digits.")]
            public string CreditCard {  get; set; }
            public User()
            {
                
            }
            public override string ToString()
            {
                return $"Id: {Id}, Login: {Login}, Email: {Email}, Phone: {Phone}, CreditCard: {CreditCard}";
            }

        }
        static int Menu()
        {
            Console.WriteLine("1. Add new User\n" +
                "2. Serialize object\n" +
                "3. Deserialize object\n" +
                "4. Exit");
            int choise = Convert.ToInt32(Console.ReadLine());
            return choise;
        }
        static void AddUser(Dictionary<int, User> dict)
        {
            User user = new User();
            bool isValid  = true;
            do
            {
                Console.Write("Enter Login: ");
                string login = Console.ReadLine()!;

                Console.Write("Enter Password: ");
                string password = Console.ReadLine()!;

                Console.Write("Confirm Password: ");
                string confirmPassword = Console.ReadLine()!;

                Console.Write("Enter Email: ");
                string email = Console.ReadLine()!;

                Console.Write("Enter Phone: ");
                string phone = Console.ReadLine()!;

                Console.Write("Enter Credit Card: ");
                string card = Console.ReadLine()!;

                user.Id = id;
                user.Password = password;
                user.ConfirmPassword = confirmPassword;
                user.Email = email;
                user.Phone = phone;
                user.Login = login;
                user.CreditCard = card;

                var result = new List<ValidationResult>();
                var contex = new ValidationContext(user);

                if (!(isValid = Validator.TryValidateObject(user, contex, result, true)))
                {
                    foreach (ValidationResult error in result)
                    {
                        Console.WriteLine(error.MemberNames.FirstOrDefault() + ": " + error.ErrorMessage);
                    }
                }

            } while (!isValid);
            dict.Add(id, user);
            id++;
        }
        static void SerializeUser(Dictionary<int, User> dict)
        {
            try
            {
               
                string jsonString = JsonSerializer.Serialize(dict);
                File.WriteAllText(fileName, jsonString);
                Console.WriteLine("Done JsonSerializer");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void DeserializeUser(Dictionary<int, User> dict)
        {
            try
            {
                string jsonString = File.ReadAllText(fileName);
                var deserializedDict = JsonSerializer.Deserialize<Dictionary<int, User>>(jsonString)!;

                dict.Clear(); 
                foreach (var i in deserializedDict)
                {
                    dict[i.Key] = i.Value;
                    Console.WriteLine(i.Value);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void Main(string[] args)
        {
            Dictionary<int, User> dict = new Dictionary<int, User>();

            while (true)
            {
                int choise = Menu();
                switch (choise)
                {
                    case 1: AddUser(dict); break;
                    case 2: SerializeUser(dict); break;
                    case 3: DeserializeUser(dict); break;
                    case 4: return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            
        }
    }
}