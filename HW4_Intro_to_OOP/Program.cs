using System.Drawing;

namespace HW4_Intro_to_OOP
{
    partial class Freezer
    {
        private int maxTemp;
        private int minTemp;

        private int width;
        private int height;
        
        static string model;
        static string color;
        public int MaxTemp
        {
            get
            {
                return maxTemp;
            }
            set
            {
                if (value < 20)
                {
                    maxTemp = value;
                }
                else
                {
                    maxTemp = 0;
                }
            }
        }
        public int MinTemp
        {
            get
            {
                return minTemp;
            }
            set
            {
                if (value > -50)
                {
                    minTemp = value;
                }
                else
                {
                    minTemp = 0;
                }
            }
        }

        public int Width
        {
            get
            {
                return width;
            }
            set
            {
                if (value > 0)
                {
                    width = value;
                }
                else
                {
                    width = 50;
                }
            }
        }
        public int Height
        {
            get
            {
                return height;
            }
            set
            {
                if (value > 0)
                {
                    height = value;
                }
                else
                {
                    height = 100;
                }
            }
        }

        


    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Freezer[] freezer = new Freezer[5];
            freezer[0] = new Freezer();
            freezer[1] = new Freezer(70, -10);
            freezer[2] = new Freezer(60, 140, 14, -25);
            freezer[3] = new Freezer(25, -40);
            freezer[3].Width = 50;
            freezer[3].Height = 260;
            freezer[4] = new Freezer();
            freezer[4].MaxTemp = 40;
            freezer[4].MinTemp = -30;
            freezer[4].Width = 70;
            freezer[4].Height = 260;
            for(int i = 0; i< 5; i++)
            {
                Console.WriteLine(freezer[i].ToString());
                //freezer[i].Print();
                Console.WriteLine();
            }
        }
    }
}