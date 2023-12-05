namespace AoC4;

public class Scratchcard
{
    private readonly List<int> WinningNums = new(), ScratchedNums = new();

    public Scratchcard(in string[] winningNums, in string[] scratchedNums)
    {
        foreach (string num in winningNums)
            WinningNums.Add(int.Parse(num));
        foreach (string num in scratchedNums)
            ScratchedNums.Add(int.Parse(num));
    }

    public int GetScore()
    {
        // I'm too lazy to write a method to increment this specifically for the init case so I'm initializing at one and
        // bitshifting to the right at the end
        int score = 1;

        // This is the worst performance-wise but modern computers are fast enough
        foreach (int scratch in ScratchedNums)
            foreach (int num in WinningNums)
                if (scratch == num)
                    score <<= 1;

        return score >> 1;
    }
}