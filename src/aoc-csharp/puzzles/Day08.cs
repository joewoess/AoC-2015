using System.Text.RegularExpressions;

namespace aoc_csharp.puzzles;

public sealed class Day08 : PuzzleBaseLines
{
    public override string? FirstPuzzle()
    {
        var stringRepresentations = Data.Select(line => (line.Trim(), Regex.Unescape(line[1..^1].Trim()))).ToList();
        Printer.DebugMsg(stringRepresentations.ToListString());
        var differences = stringRepresentations.Select(pair => pair.Item1.Length - pair.Item2.Length).ToList();
        Printer.DebugMsg($"Differences: {differences.ToListString()}");

        var sumRepresentation = stringRepresentations.Select(s => s.Item1).Sum(k => k.Length);
        var sumLiterals = stringRepresentations.Select(s => s.Item2).Sum(v => v.Length);
        Printer.DebugMsg($"Repr - Literals ({sumRepresentation} - {sumLiterals})");

        var result = sumRepresentation - sumLiterals;
        Printer.DebugMsg($"Resulting sum is {result}");
        return result.ToString();
    }

    public override string? SecondPuzzle()
    {
        var escape = (string input) => Regex.Escape(input.Trim());
        var escapeQuotes = (string input) => input.Replace("\"", "\\\"");
        var addOuterQuotes = (string input) => $"\"{input}\"";

        var stringRepresentations = Data.Select(line => (addOuterQuotes(escapeQuotes(escape(line))), line.Trim())).ToList();
        Printer.DebugMsg(stringRepresentations.ToListString());
        var differences = stringRepresentations.Select(pair => pair.Item1.Length - pair.Item2.Length).ToList();
        Printer.DebugMsg($"Differences: {differences.ToListString()}");

        var sumRepresentation = stringRepresentations.Select(s => s.Item1).Sum(k => k.Length);
        var sumLiterals = stringRepresentations.Select(s => s.Item2).Sum(v => v.Length);
        Printer.DebugMsg($"Repr - Literals ({sumRepresentation} - {sumLiterals})");

        var result = sumRepresentation - sumLiterals;
        Printer.DebugMsg($"Resulting sum is {result}");
        return result.ToString();
    }

}