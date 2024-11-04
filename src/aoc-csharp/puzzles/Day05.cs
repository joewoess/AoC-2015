using System.Text;

namespace aoc_csharp.puzzles;

public sealed class Day05 : PuzzleBaseLines
{

    public override string? FirstPuzzle()
    {
        string[] badStr = ["ab", "cd", "pq", "xy"];
        bool rule1(string str) => str.Count(c => "aeiou".Contains(c)) >= 3;
        bool rule2(string str) => str.PairWithNext().Any(pair => pair.From == pair.To);
        bool rule3(string str) => !badStr.Any(bad => str.Contains(bad));
        bool isNice(string str) => rule1(str) && rule2(str) && rule3(str);

        foreach (var line in Data)
        {
            var result = isNice(line);
            Printer.DebugMsg($"'{line}' is nice: {result} [{rule1(line)}, {rule2(line)}, {rule3(line)}]");
        }
        var numNice = Data.Count(isNice);
        Printer.DebugMsg($"There are {numNice} nice strings");
        return numNice.ToString();
    }

    public override string? SecondPuzzle()
    {
        bool rule1(string str) => str.PairWithNext()
                                        .Select(pair => $"{pair.From}{pair.To}")
                                        .Any(dual => str.LastIndexOf(dual) - str.IndexOf(dual) > 1);
        bool rule2(string str) => str.PairWithNext().PairWithNext().Any(followingPairs => followingPairs.From.From == followingPairs.To.To);
        bool isNice(string str) => rule1(str) && rule2(str);

        foreach (var line in Data)
        {
            var result = isNice(line);
            Printer.DebugMsg($"'{line}' is nice: {result} [{rule1(line)}, {rule2(line)}]");
        }
        var numNice = Data.Count(isNice);
        Printer.DebugMsg($"There are {numNice} nice strings");
        return numNice.ToString();
    }
}