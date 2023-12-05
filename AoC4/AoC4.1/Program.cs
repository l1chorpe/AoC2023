namespace AoC4;

public class MainClass
{
    public static void Main()
    {
        // Read the data and write it into a list
        string[] data = File.ReadAllLines("data.txt");
        List<Scratchcard> cards = new();
        foreach (string line in data)
        {
            string[] numbers = line.Split(':')[1].Split('|');
            cards.Add(new(
                numbers[0].Trim().Replace("  ", " ").Split(" "),
                numbers[1].Trim().Replace("  ", " ").Split(" ")
            ));
        }

        // Calculate the score and display it
        int total_score = 0;
        foreach (Scratchcard card in cards)
            total_score += card.GetScore();

        Console.WriteLine(total_score);
    }
}