namespace AoC2;

public class Game
{
    private class Subset
    {
        private const int LEGAL_RED = 12, LEGAL_GREEN = 13, LEGAL_BLUE = 14;
        public readonly int Red, Green, Blue;

        public Subset((int, int, int) rgb) { (Red, Green, Blue) = rgb; }
        public bool IsLegal() { return Red <= LEGAL_RED && Green <= LEGAL_GREEN && Blue <= LEGAL_BLUE; }
    }

    public readonly int ID;
    private List<Subset> Subsets { get; }

    public Game(string idAndSubsets)
    {
        idAndSubsets = idAndSubsets.Replace(' ', '\0');
        var split = idAndSubsets.Split(':');
        ID = GetNumber(split[0]);
        Subsets = GetSubsets(split[1]);
    }

    /// <summary>
    /// Retrieves the number from the given string.
    /// </summary>
    /// <returns>The number formatted to int</returns>
    private static int GetNumber(string id)
    {
        string result = "";
        foreach(char c in id)
            if(char.IsDigit(c))
                result += c;
        return int.Parse(result);
    }

    /// <summary>
    /// Converts the given string into a list of subsets.
    /// </summary>
    private static List<Subset> GetSubsets(string subsets)
    {
        // It's just basic string manipulation, nothing too wild
        List<Subset> result = new();
        foreach(string subset in subsets.Split(';'))
        {
            (int, int, int) rgb = (0, 0, 0);
            foreach(string color_cube in subset.Split(','))
            {
                int cube_count = GetNumber(color_cube);
                if(color_cube.Contains("red"))
                    rgb.Item1 = cube_count;
                else if(color_cube.Contains("green"))
                    rgb.Item2 = cube_count;
                else
                    rgb.Item3 = cube_count;
            }
            result.Add(new(rgb));
        }
        return result;
    }

    public bool IsLegal()
    {
        foreach(Subset subset in Subsets)
            if(!subset.IsLegal())
                return false;
        return true;
    }

    public int GetPower()
    {
        int red = 0, green = 0, blue = 0;
        foreach (Subset subset in Subsets)
        {
            if (subset.Red > red)
                red = subset.Red;
            if (subset.Green > green)
                green = subset.Green;
            if (subset.Blue > blue)
                blue = subset.Blue;
        }
        return red * green * blue;
    }
}