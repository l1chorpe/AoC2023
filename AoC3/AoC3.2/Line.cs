namespace AoC3;

public class Line
{
    public readonly List<Number> Numbers = new();
    public readonly List<Symbol> Symbols = new();

    public Line(string line)
    {
        string buffer = "";
        for (int i = 0; i < line.Length; ++i)
        {
            // Add every digit to the buffer
            if (char.IsDigit(line[i]))
            {
                buffer += line[i];
            }
            else
            {
                // If the current char is not a digit, add the number in the buffer (if necessary) and reset the buffer,
                // and add a new symbol to the list if the char is not '.'
                if (buffer != "")
                {
                    Numbers.Add(new(i - buffer.Length, i - 1, int.Parse(buffer)));
                    buffer = "";
                }
                if (line[i] != '.')
                    Symbols.Add(new(i, line[i]));
            }
        }
        if(buffer != "")
            Numbers.Add(new(line.Length - buffer.Length, line.Length - 1, int.Parse(buffer)));
    }
}

public class Number
{
    public readonly int StartPos, EndPos, Value;

    public Number(int startPos, int endPos, int value) { StartPos = startPos; EndPos = endPos; Value = value; }
}

public class Symbol
{
    public readonly int Pos;
    public readonly char Character;

    public Symbol(int pos, char character) { Pos = pos; Character = character; }
}