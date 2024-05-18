namespace HW6_OverloadOperators_Indexes
{
    internal class Program
    {
        class Square
        {
            private int a;
            public int A
            {
                get { return a; }
                set
                {
                    if (value <= 0)
                    {
                        throw new ArgumentException();
                    }

                    else
                    {
                        a = value;
                    }
                }
            }
            public Square()
            {
                A = 1;
            }
            public Square(int val)
            {
                A = (int)val;
            }
            public override string ToString()
            {
                return $"A = {A}";
            }
            public static Square operator -(Square a, int val)
            {
                Square res = new Square
                {
                    A = a.A - val
                };
                return res;
            }
            public static Square operator +(Square a, int val)
            {
                Square res = new Square
                {
                    A = a.A + val
                };
                return res;
            }
            public static Square operator *(Square a, int val)
            {
                Square res = new Square
                {
                    A = a.A * val
                };
                return res;
            }
            public static Square operator /(Square a, int val)
            {
                if (val == 0)
                {
                    throw new ArgumentNullException();
                }
                else
                {
                    Square res = new Square
                    {
                        A = a.A / val
                    };
                    return res;
                }

            }
            public static Square operator ++(Square s)
            {
                s.A++;
                return s;
            }
            public static Square operator --(Square s)
            {
                s.A--;
                return s;
            }

            public static bool operator ==(Square s1, Square s2)
            {
                return s1.A == s2.A;
            }
            public static bool operator !=(Square s1, Square s2)
            {
                return !(s1.A == s2.A);
            }
            public static bool operator >(Square s1, Square s2)
            {
                return s1.A > s2.A;
            }
            public static bool operator <(Square s1, Square s2)
            {
                return s1.A < s2.A;
            }
            public static bool operator >=(Square s1, Square s2)
            {
                return s1.A >= s2.A;
            }
            public static bool operator <=(Square s1, Square s2)
            {
                return s1.A <= s2.A;
            }
            public static bool operator true(Square s)
            {
                return s.A != 0;
            }
            public static bool operator false(Square s)
            {
                return s.A == 0;
            }
            public static implicit operator int(Square s)
            {
                return s.A;
            }
            public static implicit operator Rectangle(Square s)
            {
                return new Rectangle(s.A);
            }
        }
        class Rectangle
        {
            private int a;
            private int b;
            public int A
            {
                get { return a; }
                set
                {
                    if (value <= 0)
                    {
                        throw new ArgumentException();
                    }

                    else
                    {
                        a = value;
                    }
                }
            }
            public int B
            {
                get { return b; }
                set
                {
                    if (value <= 0)
                    {
                        throw new ArgumentException();
                    }

                    else
                    {
                        b = value;
                    }
                }
            }
            public Rectangle()
            {
                A = 1;
                B = 1;
            }
            public Rectangle(int valA, int valB)
            {
                A = valA;
                B = valB;
            }
            public Rectangle(int val)
            {
                A = val;
                B = val;
            }
            public override string ToString()
            {
                return $"A = {A}, B = {B}";

            }
            public static Rectangle operator -(Rectangle a, int val)
            {
                Rectangle res = new Rectangle
                {
                    A = a.A - val,
                    B = a.B - val,
                };
                return res;
            }
            public static Rectangle operator +(Rectangle a, int val)
            {
                Rectangle res = new Rectangle
                {
                    A = a.A + val,
                    B = a.B + val

                };
                return res;
            }
            public static Rectangle operator *(Rectangle a, int val)
            {
                Rectangle res = new Rectangle
                {
                    A = a.A * val,
                    B = a.B * val

                };
                return res;
            }
            public static Rectangle operator /(Rectangle a, int val)
            {
                if (val == 0)
                {
                    throw new ArgumentNullException();
                }
                else
                {
                    Rectangle res = new Rectangle
                    {
                        A = a.A / val,
                        B = a.B / val
                    };
                    return res;
                }

            }
            public static Rectangle operator ++(Rectangle s)
            {
                s.A++;
                s.B++;
                return s;
            }
            public static Rectangle operator --(Rectangle s)
            {
                s.A--;
                s.B--;
                return s;
            }

            public static bool operator ==(Rectangle s1, Rectangle s2)
            {
                return s1.A == s2.A && s1.B == s2.B;
            }
            public static bool operator !=(Rectangle s1, Rectangle s2)
            {
                return !(s1 == s2);
            }
            public static bool operator >(Rectangle s1, Rectangle s2)
            {
                return s1.A + s1.B > s2.A + s2.B;
            }
            public static bool operator <(Rectangle s1, Rectangle s2)
            {
                return s1.A + s1.B < s2.A + s2.B;
            }
            public static bool operator >=(Rectangle s1, Rectangle s2)
            {
                return s1.A + s1.B >= s2.A + s2.B;
            }
            public static bool operator <=(Rectangle s1, Rectangle s2)
            {
                return s1.A + s1.B <= s2.A + s2.B;
            }
            public static bool operator true(Rectangle r)
            {
                return r.A != 0 || r.B != 0;
            }
            public static bool operator false(Rectangle r)
            {
                return r.A == 1 && r.B == 1;
            }
            public static explicit operator int(Rectangle r)
            {
                return r.A + r.B;
            }
            public static explicit operator Square(Rectangle r)
            {
                int side = r.A + r.B;
                return new Square(side);
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}