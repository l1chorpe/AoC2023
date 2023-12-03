namespace AoC2;

public class MainClass
{
    public static void Main()
    {
        List<Game> list = new();
        foreach(string line in File.ReadAllLines("data.txt"))
            list.Add(new Game(line.Trim()));

        int sum = 0;
        foreach (Game game in list)
            if (game.IsLegal())
                sum += game.ID;

        Console.WriteLine(sum);
    }
}