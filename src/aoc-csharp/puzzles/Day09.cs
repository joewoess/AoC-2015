using aoc_csharp.helper.algorithms;

namespace aoc_csharp.puzzles;

public sealed class Day09 : PuzzleBaseLines
{
    public override string? FirstPuzzle()
    {
        var edges = Data.Select(line => line.Split(" "))
                            .Select(arr => new TSP.Edge(arr[0], arr[2], int.Parse(arr[4])))
                            .ToList();


        Printer.DebugMsg($"Edges: {edges.ToListString()}");

        var result = TSP.SolveSymmetricalTSP(edges);
        Printer.DebugMsg($"RLib.Tsp solved to this: {result}");
        return result.Success ? result.Distance.ToString() : null;
    }

    public override string? SecondPuzzle()
    {
        var edges = Data.Select(line => line.Split(" "))
                            .Select(arr => new TSP.Edge(arr[0], arr[2], int.Parse(arr[4])))
                            .ToList();


        Printer.DebugMsg($"Edges: {edges.ToListString()}");

        var result = TSP.SolveSymmetricalTSP(edges, true);
        Printer.DebugMsg($"RLib.Tsp solved to this: {result}");
        return result.Success ? result.Distance.ToString() : null;
    }

}