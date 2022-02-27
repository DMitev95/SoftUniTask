namespace PlayersAndMonsters
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            BladeKnight bladeKnight = new BladeKnight("Gosho", 5);
            Hero hero = new Hero("Pepi", 10);
            System.Console.WriteLine(bladeKnight.ToString());
            System.Console.WriteLine(hero.ToString());
        }
    }
}