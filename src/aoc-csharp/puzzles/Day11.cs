using System.Text;
using aoc_csharp.helper.algorithms;

namespace aoc_csharp.puzzles;

public sealed class Day11 : PuzzleBaseText
{
    public override string? FirstPuzzle()
    {
        const int AmountOfRepetitions = 40;
        var permutatedText = LookAndSay.LookAndSayNTimes(Data, AmountOfRepetitions);
        return permutatedText.Length.ToString();
    }

    public override string? SecondPuzzle()
    {
        const int AmountOfRepetitions = 50;
        var permutatedText = LookAndSay.LookAndSayNTimes(Data, AmountOfRepetitions);
        return permutatedText.Length.ToString();
    }
}