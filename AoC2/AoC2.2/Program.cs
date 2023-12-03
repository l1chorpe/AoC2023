namespace AoC2;

public class MainClass
{
    public static void Main()
    {
        List<Game> list = new();
        foreach(string line in File.ReadAllLines("data.txt"))
            list.Add(new Game(line.Trim()));

        int power_sum = 0;
        foreach (Game game in list)
            power_sum += game.GetPower();

        Console.WriteLine(power_sum);
    }
}