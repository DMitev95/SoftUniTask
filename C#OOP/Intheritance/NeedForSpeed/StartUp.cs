namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            CrossMotorcycle cros = new CrossMotorcycle(100, 100);
            cros.Drive(9);
            System.Console.WriteLine(cros.Fuel);
        }
    }
}
