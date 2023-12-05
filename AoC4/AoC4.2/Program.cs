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
            string[] id_and_numbers = line.Split(':');
            string[] numbers = id_and_numbers[1].Split('|');
            cards.Add(new(
                id_and_numbers[0],
                numbers[0].Trim().Replace("  ", " ").Split(" "),
                numbers[1].Trim().Replace("  ", " ").Split(" ")
            ));
        }

        // Loop through the list and add the relevant cards to that same list when needed
        // It stops once no other cards can be copied
        int original_count = cards.Count;
        for (int i = 0; i < cards.Count; ++i)
            if (cards[i].GetScore() != 0)
                // I am deeply sorry for that awful algorithm but I lost my patience editing the Scratchcard class
                for (int j = cards[i].ID; j < cards[i].ID + Math.Log(cards[i].GetScore(), 2) + 1 && j < original_count; ++j)
                    cards.Add(cards[j]);

        Console.WriteLine(cards.Count);
    }
}