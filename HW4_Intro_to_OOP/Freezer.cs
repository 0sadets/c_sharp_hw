using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW4_Intro_to_OOP
{
    partial class Freezer
    {
        static Freezer()
        {
            color = "white";
            model = "model";
        }
        public Freezer()
        {
            maxTemp = 0;
            minTemp = 0;
            width = 0;
            height = 0;
        }
        public Freezer(int maxT, int minT)
        {
            if (maxT < 30) maxTemp = maxT;
            else maxTemp = 0;

            if (minT > -50) MinTemp = minT;
            else MinTemp = 0;
        }
        public Freezer(int width, int height, int maxT, int minT) : this(maxT, minT)
        {
            setHeight(height); setWidth(width);
        }

        public void setWidth(int w)
        {
            if (w > 0)
            {
                width = w;
            }
            else { width = 50; }
        }
        public void setHeight(int height)
        {
            if (height > 0)
            {
                this.height = height;
            }
            else { this.height = 100; }
        }
        public override string ToString()
        {
            return $"Max temperature: {maxTemp}, Min temperature: {minTemp}.\nWidth: {width}, Height: {height}.\nModel: {model}, Color: {color}";
        }
        public void Print()
        {
            Console.WriteLine($"Max temperature: {maxTemp}, Min temperature: {minTemp}.\nWidth: {width}, Height: {height}.\nModel: {model}, Color: {color}"); ;
        }
    }
}
