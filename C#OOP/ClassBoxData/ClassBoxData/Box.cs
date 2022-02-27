using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBoxData
{

    public class Box
    {
        private double length;
        private double width;
        private double height;
        public double Length
        {
            get
            {
                return this.length;
            }
            private set
            {
                try
                {
                    if (value <= 0)
                    {
                        throw new ArgumentException();
                    }
                }
                catch (ArgumentException)
                {
                    Console.WriteLine($"Length cannot be zero or negative.");
                    Environment.Exit(0);
                }
                this.length = value;
            }
        }


        public double Width
        {
            get
            {
                return this.width;
            }
            private set
            {
                try
                {
                    if (value <= 0)
                    {
                        throw new ArgumentException();
                    }
                }
                catch (ArgumentException)
                {
                    Console.WriteLine($"Width cannot be zero or negative.");
                    Environment.Exit(0);
                }
                this.width = value;
            }
        }



        public double Height
        {
            get
            {
                return this.height;
            }
            private set
            {
                try
                {
                    if (value <= 0)
                    {
                        throw new ArgumentException();
                    }
                }
                catch (ArgumentException)
                {
                    Console.WriteLine($"Height cannot be zero or negative.");
                    Environment.Exit(0);
                }
                this.height = value;
            }
        }

        public Box(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }

        public double SurfaceArea()
        {
            return 2 * Width * Length + 2 * Length * Height + 2 * Width * Height;
        }

        public double LetaralSurfaceArea()
        {
            return 2 * Height * Length + 2 * Width * Height;
        }

        public double Volume()
        {
            return Width * Length * Height;
        }
    }
}
