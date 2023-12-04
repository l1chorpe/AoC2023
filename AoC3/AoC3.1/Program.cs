namespace AoC3;

public class MainClass
{
    public static void Main()
    {
        // Parse all the lines
        List<Line> lines = new();
        foreach (string line in File.ReadAllLines("data.txt"))
        {
            lines.Add(new Line(line));
        }

        // Sum all the lines
        int sum = 0;
        for (int i = 0; i < lines.Count; ++i)
            sum += GetLineSum(
                i == 0 ? null : lines[i - 1],
                lines[i],
                i == lines.Count - 1 ? null : lines[i + 1]
            );

        Console.WriteLine(sum);
    }

    /// <summary>
    /// Finds all numbers adjacent to symbols and returns the sum of all of those numbers.
    /// </summary>
    private static int GetLineSum(in Line? previous_line, in Line current_line, in Line? next_line)
    {
        List<int> positions = new();

        // Search for all symbols on each line
        if (previous_line != null)
            foreach (Symbol symbol in previous_line.Symbols)
                positions.Add(symbol.Pos);

        if (next_line != null)
            foreach(Symbol symbol in next_line.Symbols)
                positions.Add(symbol.Pos);

        foreach (Symbol symbol in current_line.Symbols)
            positions.Add(symbol.Pos);

        // Check each number with the positions from the symbols in the three lines and take the sum
        int sum = 0;
        foreach (Number number in current_line.Numbers)
            foreach (int position in positions)
                if (position + 1 >= number.StartPos && position - 1 <= number.EndPos)
                    sum += number.Value;

        return sum;
    }
}