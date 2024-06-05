using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    internal class Program
    {
        abstract class Animal
        {
            private int age;
            private double weight;
            public string Name { get; set; }
            public string Gender { get; set; }
            public string Habitat { get; set; }
            public int Age
            {
                get { return age; }
                set { age = value > 0 ? value : 1; }
            }
            public double Weight
            {
                get { return weight; }
                set { weight = value > 0 ? value : 1; }
            }
            public Animal()
            {
                Name = "no name";
                Gender = "no gender";
                Habitat = "none";
                Age = 0;
                Weight = 0;
            }
            public Animal(string n, string g, string h, int a, double w)
            {
                Name = n;
                Gender = g;
                Habitat = h;
                Weight = w;
                Age = a;
            }
            public virtual void Print()
            {
                Console.WriteLine($"Name: {Name}");
                Console.WriteLine($"Gender: {Gender}");
                Console.WriteLine($"Habitat: {Habitat}");
                Console.WriteLine($"Age: {Age}");
                Console.WriteLine($"Weight: {Weight}");
            }
            public abstract void Move();
            public abstract void Sound();
        }
        abstract class Reptile : Animal
        {
            public bool IsColdBlooded { get; set; }
            public string SkinType { get; set; }
            public Reptile() :base()
            {
                IsColdBlooded = true;
                SkinType = "none";
            }
            public Reptile(string n, string g, string h, int a, double w, bool isC, string s):base(n, g, h, a, w)
            {
                IsColdBlooded=isC;
                SkinType = s;
            }
            public override void Print()
            {
                Console.WriteLine("Reptile:");
                base.Print();
                Console.WriteLine($"IsColdBlooded: {IsColdBlooded}");
                Console.WriteLine($"SkinType: {SkinType}");
            }
            public override void Move() { }
            public override void Sound() { }
        }
        class Mammal : Animal
        {
            public Mammal() : base() { }
            public Mammal(string n, string g, string h, int a, double w) : base(n, g, h, a, w) { }
            public override void Move() { }
            public override void Sound() { }
            public override void Print()
            {
                Console.WriteLine("Mammal: ");
                base.Print();
            }
        }
        abstract class Bird : Animal
        {
            private double wingspan;
            public double Wingspan
            {
                get { return wingspan; }
                set
                {
                    wingspan = value > 10 ? value: 10;
                }
            }
            public bool IsFly;
            public Bird() :base()
            {
                Wingspan = 0;
                IsFly = false;
            }
            public Bird(double wingspan, bool isFly, string n, string g, string h, int a, double w) : base(n,g,h,a,w)
            {
                Wingspan = wingspan;
                IsFly = isFly;
            }
            public override void Print()
            {
                Console.WriteLine("Bird: ");
                base.Print();
                Console.WriteLine($"Wingspan: {Wingspan}");
                Console.WriteLine($"IsFly: {IsFly}");
            }
            public override void Move() { }
            public override void Sound() { }
        }
        abstract class Fish : Animal
        {
            public bool IsBig { get; set;}
            public Fish():base()
            {
                IsBig = false;
            }
            public Fish(string n, string g, string h, int a, double w, bool isB):base(n, g, h, a, w)
            {
                IsBig = isB;
            }
            public override void Print()
            {
                Console.WriteLine("Fish:");
                base.Print();
                Console.WriteLine($"IsBig: {IsBig}");
            }
            public override void Move() { }
            public override void Sound() { }
        }
        class Bear: Mammal
        {
            public string FurColor { get; set; }
            public Bear() : base() { FurColor = "none"; }
            public Bear(string n, string g, string h, int a, double w, string furColor) : base(n, g, h, a, w) { FurColor = furColor; }
            public override void Print() 
            {
                base.Print();
                Console.WriteLine($"FurColor: {FurColor}");
            }
            public override void Move()
            {
                Console.WriteLine("Walking");
            }
            public override void Sound()
            {
                Console.WriteLine("Roar");
            }
            public void Hunt()
            {
                Console.WriteLine("Bear is hunting"); 
            }
            public void WinterSleep(bool isS)
            {
                if (isS == true) Console.WriteLine("Bear is sleeping");
                else  Console.WriteLine("Bear is not sleeping");
            }

        }
        class Frog: Reptile
        {
            public string SkinColor { get; set; }
            public bool IsJumping { get; set; }
            public Frog() : base() { SkinColor = "none"; IsJumping = true;  }
            public Frog(string n, string g, string h, int a, double w, bool isC, string s, string skinC, bool isJ):base(n, g, h,a, w, isC, s)
            {
                SkinColor = skinC;
                IsJumping = isJ;
            }
            public override void Sound()
            {
                Console.WriteLine("Kwa-kwa");
            }
            public override void Move()
            {
                Console.WriteLine("Hopping");
            }
            public void Swim()
            {
                Console.WriteLine("Frog is swimming");
            }
            public override void Print()
            {
                base.Print();
                Console.WriteLine($"SkinColor: {SkinColor}");
                Console.WriteLine($"IsJumping: {IsJumping}");
            }
        }
        class Dolphin : Mammal // я була не впевнена в тому, ким є дельфін - рибою чи ссавцем(чи тим і тим), але гугл довів, що він ссавець: https://www.ar25.org/article/35-cikavyh-faktiv-pro-delfiniv.html
        {
            public bool IsFriendly { get; set; }
            public Dolphin():base()
            {
                IsFriendly = true;
            }
            public Dolphin(bool isF, string n, string g, string h, int a, double w) : base(n, g, h, a, w)
            {
                IsFriendly = isF;
            }
            public override void Sound()
            {
                Console.WriteLine("Whistle");
            }
            public override void Move()
            {
                Console.WriteLine("Swimming");
            }
            public void Communicating()
            {
                Console.WriteLine("Dolphin is communicating");
            }
        }
        class Carp : Fish
        {
            public Carp() : base() { }
            public Carp(string n, string g, string h, int a, double w, bool isB) : base(n, g, h, a, w, isB) { }
            public override void Sound() { Console.WriteLine("Bulk"); }
            public override void Move() { Console.WriteLine("Swimming"); }
        }
        class Eagle : Bird
        {
            public string Vision { get; set; }
            public string Beak { get; set; }
            public Eagle():base()
            {
                Vision = "none";
                Beak = "none";
            }
            public Eagle(string vision, string beak, double wingspan, bool isFly, string n, string g, string h, int a, double w):base(wingspan, isFly, n, g, h, a, w)
            {
                Vision = vision;
                Beak = beak;
            }
            public override void Move()
            {
                Console.WriteLine("Flying");
            }
            public override void Sound()
            {
                Console.WriteLine("Screech");
            }
            public override void Print()
            {
                base.Print();
                Console.WriteLine($"Vision: {Vision}");
                Console.WriteLine($"Beak: {Beak}");
            }

        }

        class Zoo
        {
            Animal[] animals;
            public Zoo()
            {
                animals = new Animal[0];
            }
            public Zoo(params Animal[] animals)
            {
                this.animals = animals;
            }
            public void ShowInfo()
            {
                foreach (var item in animals)
                {
                    item.Print();
                    item.Move();
                    item.Sound();
                    Console.WriteLine("\n------------------------------------\n");
                }
            }
        }

        static void Main(string[] args)
        {

            Bear bear = new Bear("Brown Bear", "Male", "Forest", 5, 300, "Brown");
            Frog frog = new Frog("Green Frog", "Female", "Pound", 1, 0.5, true, "Regular", "Green", true);
            Dolphin dolphin = new Dolphin(true, "Dolphin", "Male", "Ocean", 8, 200);
            Carp carp = new Carp("Carp", "Male", "Freshwater", 2, 1.2, false);
            Eagle eagle = new Eagle("good vision", "big beak", 2.34, true, "Berkyt", "Male", "Mountains", 3, 7);



            Zoo zoo = new Zoo(bear, frog, dolphin, carp, eagle);
            zoo.ShowInfo();
            bear.Hunt();
            bear.WinterSleep(false);
            frog.Swim();
            dolphin.Communicating();
        }
    }
}
