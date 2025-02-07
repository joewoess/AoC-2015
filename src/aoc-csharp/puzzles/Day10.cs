using System.Text;

namespace aoc_csharp.puzzles;

public sealed class Day10 : PuzzleBaseText
{

    public override string? FirstPuzzle()
    {
        const int AmountOfRepetitions = 40;
        var permutatedText = Data;
        AmountOfRepetitions.DoTimes(() => permutatedText = LookAndSay(permutatedText));

        Printer.DebugMsg($"From {Data} after {AmountOfRepetitions} Iterations we get length {permutatedText.Length}");
        Printer.DebugPrintExcerpt(permutatedText, maxCount: 100, separator: "");
        return permutatedText.Length.ToString();
    }

    public override string? SecondPuzzle()
    {
        const int AmountOfRepetitions = 50;
        var permutatedText = Data;
        AmountOfRepetitions.DoTimes(() => permutatedText = LookAndSay(permutatedText));

        Printer.DebugMsg($"From {Data} after {AmountOfRepetitions} Iterations we get length {permutatedText.Length}");
        Printer.DebugPrintExcerpt(permutatedText, maxCount: 100, separator: "");
        return permutatedText.Length.ToString();
    }

    private static string LookAndSay(ReadOnlySpan<char> text)
    {
        var numChar = 1;
        var lastChar = text[0];
        var result = new StringBuilder();
        for (int i = 1; i < text.Length; i++)
        {
            if (text[i] != lastChar)
            {
                result.Append(numChar);
                result.Append(lastChar);
                numChar = 0;
                lastChar = text[i];
            }
            numChar++;
        }
        result.Append(numChar);
        result.Append(lastChar);
        return result.ToString();
    }
}