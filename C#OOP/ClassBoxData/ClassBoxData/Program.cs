using System;

namespace ClassBoxData
{
    internal class Program
    {
        static void Main(string[] args)
        {

                double lenght = double.Parse(Console.ReadLine());
                double width = double.Parse(Console.ReadLine());
                double height = double.Parse(Console.ReadLine());
                Box box = new Box(lenght, width, height);
                Console.WriteLine($"Surface Area - {box.SurfaceArea():f2}");
                Console.WriteLine($"Lateral Surface Area - {box.LetaralSurfaceArea():f2}");
                Console.WriteLine($"Volume - {box.Volume():f2}");
            
        }
    }
}
