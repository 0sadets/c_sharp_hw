using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures
{
    internal class Program
    {
        const double pi = 3.14;

        abstract class Geometric_Figure
        {
            private int side;
            public int Side
            {
                get { return side; }
                set
                {
                    side = value > 0 ? value : 10;
                }
            }
            public Geometric_Figure(int side)
            {
                Side = side;
            }
            public Geometric_Figure()
            {
                this.side = 10;
            }
            public abstract void GetArea();
            public abstract void GetPerimeter();
            public virtual void Print()
            {
                Console.WriteLine("I am figure!");
            }
        }
        class Triangle: Geometric_Figure 
        {
            private int height;
            private int sideA;
            private int sideB;
            // Side з Geometric_Figure - це сторона, до якої проведена висота(вона бере участь в обчисленні площи)
            public int Height
            {
                get { return height; }
                set
                {
                    height = value > 0 ? value : 10;
                }
            }
            public int SideA
            {
                get { return sideA; }
                set
                {
                    sideA = value > 0 ? value : 10;
                }
            }
            public int SideB
            {
                get { return sideB; }
                set
                {
                    sideB = value > 0 ? value : 10;
                }
            }
            public Triangle() : base() 
            {
                this.sideA = 10;
                this.sideB = 10;
                this.height = 10;
            }
            public Triangle(int s, int h):base(s) // рівносторонній трикутник
            {
                Height = h;
                SideA = s;
                SideB = s;
            }
            public Triangle(int a, int b, int c, int h):base(c) // int c - сторона, до якої проведена висота
            {
                Height = h;
                SideA = a;
                SideB = b;
            }
            public override void GetArea()
            {
                float area = (float)(0.5 * Side * Height);
                Console.WriteLine($"Area: {area}");
            }
            public override void GetPerimeter()
            {
                int perimeter = SideA + SideB + Side;
                Console.WriteLine($"Perimeter: {perimeter}");
            }
            public override void Print()
            {
                Console.WriteLine($"Triangle with sides: {SideA}, {SideB}, {Side} and height {Height}");
            }
            public override string ToString()
            {
                return $"Triangle with sides: {SideA}, {SideB}, {Side} and height {Height}";
            }

        }
        class Square : Geometric_Figure
        {

            public Square() : base() { }
            public Square(int s) : base(s) { }
            public override void GetArea()
            {
                Console.WriteLine($"Area: {Side * Side}");
            }
            public override void GetPerimeter()
            {
                Console.WriteLine($"Perimeter: {Side * 4}");
            }
            public override void Print()
            {
                Console.WriteLine($"Square with side {Side}");
            }
            public override string ToString()
            {
                return $"Square with side {Side}";
            }
        }
        class Rhomb : Geometric_Figure
        {
            private int diag1;
            private int diag2;
            public int Diag1
            {
                get { return diag1; }
                set
                {
                    diag1 = value > 0 ? value : 10;
                }
            }
            public int Diag2
            {
                get { return diag2; }
                set
                {
                    diag2 = value > 0 ? value : 10;
                }
            }
            public Rhomb() : base()
            {
                Diag1 = 0;
                Diag2 = 0;
            }
            public Rhomb(int d1, int d2, int s) : base(s)
            {
                Diag1 = d1;
                Diag2 = d2;
            }
            public Rhomb(int d, int s) : base(s)
            {
                Diag1 = d;
                Diag2 = d;
            }
            public override void GetArea()
            {
                Console.WriteLine($"Area: {(float)(0.5 * Diag1 * Diag2)}");
            }
            public override void GetPerimeter()
            {
                Console.WriteLine($"Perimeter: {Side * 4}");
            }
            public override void Print()
            {
                Console.WriteLine($"Rhomb with side: {Side} and diagonals: {Diag1} and {Diag2}");
            }
            public override string ToString()
            {
                return $"Rhomb with side: {Side} and diagonals: {Diag1} and {Diag2}";
            }
        }
        class Rectangle : Geometric_Figure
        {
            private int sideB;
            public int SideB
            {
                get { return sideB; }
                set
                {
                    sideB = value > 0 ? value : 10;
                }
            }
            public Rectangle():base()
            {
                sideB=10;
            }
            public Rectangle(int a, int b) : base(a)
            {
                SideB = b;
            }
            public Rectangle(int a):base(a)
            {
                SideB = a;
            }
            public override void GetArea()
            {
                Console.WriteLine($"Area: {Side*SideB}");
            }
            public override void GetPerimeter()
            {
                Console.WriteLine($"Perimeter: {(Side + SideB)*2}");
            }
            public override void Print()
            {
                Console.WriteLine($"Rectangle with sides {Side} and {SideB}");
            }
            public override string ToString()
            {
                return $"Rectangle with sides {Side} and {SideB}";
            }
        }
        class Parallelogram: Geometric_Figure
        {
            private int sideA;
            private int sideB;
            public int SideA
            {
                get { return sideA; }
                set
                {
                    sideA = value>0? value : 10;
                }
            }
            public int SideB
            {
                get { return sideB; }
                set
                {
                    sideB = value > 0 ? value : 10;
                }
            }
            public Parallelogram() : base()
            {
                sideA = 10;
                sideB = 10;
            }
            public Parallelogram(int a, int b, int h):base(h)
            {
                SideA = a;
                SideB = b;
            }
            public override void GetArea()
            {
                Console.WriteLine($"Area: {SideA*Side}");// Side(base) - в ролі висоти
            }
            public override void GetPerimeter()
            {
                Console.WriteLine($"Perimeter: {(SideA+SideB) * 2}");
            }
            public override void Print()
            {
                Console.WriteLine($"Parallelogram with sides {SideA}, {SideB} and height {Side}");
            }
            public override string ToString()
            {
                return $"Parallelogram with sides {SideA}, {SideB} and height {Side}";
            }
        }
        class Trapezium : Geometric_Figure
        {
            private int sideA; 
            private int sideB;
            private int sideC;
            private int sideD;
            public int SideA
            {
                get { return sideA; }
                set { sideA = value > 0 ? value : 10; }
            }
            public int SideB
            {
                get { return sideB; }
                set { sideB = value > 0 ? value : 10; }
            }
            public int SideC
            {
                get { return sideC; }
                set { sideC = value > 0 ? value : 10; }
            }
            public int SideD
            {
                get { return sideD; }
                set { sideD = value > 0 ? value : 10; }
            }
            public Trapezium():base()
            {
                SideA = 10;
                SideB = 10;
                SideC = 10;
                SideD = 10;

            }
            public Trapezium(int a, int b, int c, int d, int h):base(h)
            {
                SideA = a;
                SideB = b;
                SideC = c;
                SideD = d;
            }
            public override void GetArea()
            {
                float area = (float)((SideA + SideB) * Side / 2);
                Console.WriteLine($"Area: {area}");
            }
            public override void GetPerimeter()
            {
                Console.WriteLine($"Perimeter: {SideA + SideB + SideC + SideD}");
            }
            public override void Print()
            {
                Console.WriteLine($"Trapezium with sides: {SideA}, {SideB}, {SideC}, {SideD} and Height {Side}");
            }
            public override string ToString()
            {
                return $"Trapezium with sides: {SideA}, {SideB}, {SideC}, {SideD} and Height {Side}";
            }
        }
        class Circle : Geometric_Figure
        {
            public Circle() : base() { }
            public Circle(int radius) : base(radius) { }
            public override void GetArea()
            {
                Console.WriteLine($"Area: {pi * Side * Side}");
            }
            public override void GetPerimeter()
            {
                Console.WriteLine($"Circuit: {2 * pi * Side}");
            }
            public override void Print()
            {
                Console.WriteLine($"Circle with radius {Side}");
            }
            public override string ToString()
            {
                return $"Circle with radius {Side}";
            }
        }
        class Ellipse : Geometric_Figure
        {
            private int smallerRadius;
            public int SmallerRadius
            {
                get { return smallerRadius; }
                set { smallerRadius = value > 0 ? value : 10; }
            }
            public Ellipse():base()
            {
                SmallerRadius = 10;
            }
            public Ellipse(int bigRad, int smallRad):base(bigRad)
            {
                SmallerRadius = smallRad;
            }
            public override void GetArea()
            {
                Console.WriteLine($"Area: {pi * SmallerRadius * Side}");
            }
            public override void GetPerimeter()
            {
                Console.WriteLine($"Perimeter: {2 * Side * SmallerRadius}");
            }
            public override void Print()
            {
                Console.WriteLine($"Ellipse with half axis: {Side} and {SmallerRadius} ");
            }
            public override string ToString()
            {
                return $"Ellipse with half axis: {Side} and {SmallerRadius} ";
            }

        }
        class CompleteFigures
        {
            Geometric_Figure[] figures;
            public CompleteFigures()
            {
                figures = null;
            }
            public CompleteFigures(params Geometric_Figure[] f)
            {
                figures = f;
            }
            public void GetInfo()
            {
                foreach(var f in figures)
                {
                    Console.WriteLine(f.ToString());
                    f.GetArea();
                    f.GetPerimeter();
                    Console.WriteLine("-----------------------------");
                }
            }
        }


        static void Main(string[] args)
        {
            Triangle tr = new Triangle(10, 8, 7, 6);
            Square sq = new Square(5);
            Rhomb rh = new Rhomb(14, 10, 6);
            Rectangle rec = new Rectangle(4, 5);
            Parallelogram pr = new Parallelogram(10, 8, 6);
            Trapezium trap = new Trapezium(6, 10, 8, 8, 7);
            Circle cr = new Circle(6);
            Ellipse el = new Ellipse(14, 10);
            CompleteFigures figures = new CompleteFigures(tr, sq, rh, rec, pr, trap, cr, el);
            figures.GetInfo();

        }
    }
}
