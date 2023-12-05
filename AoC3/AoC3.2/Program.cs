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

        // Sum all the lines' gear ratios
        int sum = 0;
        for (int i = 0; i < lines.Count; ++i)
            sum += GetGearRatio(
                i == 0 ? null : lines[i - 1],
                lines[i],
                i == lines.Count - 1 ? null : lines[i + 1]
            );

        Console.WriteLine(sum);
    }

    /// <summary>
    /// Finds all the '*' adjacent to exactly two numbers (if there are any).
    /// </summary>
    /// <returns>The sum of all gear ratios</returns>
    private static int GetGearRatio(in Line? previous_line, in Line current_line, in Line? next_line)
    {
        int ratio_sum = 0;
        foreach (Symbol symbol in current_line.Symbols)
        {
            if (symbol.Character == '*')
            {
                List<Number> adjacent_numbers = new();

                // Go through all numbers on the three lines and find those that are close enough to the current '*'
                if (previous_line != null)
                    foreach (Number number in previous_line.Numbers)
                        if (symbol.Pos >= number.StartPos - 1 && symbol.Pos <= number.EndPos + 1)
                            adjacent_numbers.Add(number);

                if (next_line != null)
                    foreach (Number number in next_line.Numbers)
                        if (symbol.Pos >= number.StartPos - 1 && symbol.Pos <= number.EndPos + 1)
                            adjacent_numbers.Add(number);

                foreach (Number number in current_line.Numbers)
                    if (symbol.Pos >= number.StartPos - 1 && symbol.Pos <= number.EndPos + 1)
                        adjacent_numbers.Add(number);

                // Add the gear ratio if all goes well
                if (adjacent_numbers.Count == 2)
                    ratio_sum += adjacent_numbers[0].Value * adjacent_numbers[1].Value;
            }
        }
        return ratio_sum;
    }
}