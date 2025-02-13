using System.Text.Json;
using aoc_csharp.helper.algorithms;

namespace aoc_csharp.puzzles;

public sealed class Day13 : PuzzleBaseLines
{
    private record HappinessData(string Name, string Neighbor, int Happiness);
    public override string? FirstPuzzle()
    {
        var edges = Data.Select(line => line.Split(" "))
                            .Select(words => new TSP.Edge(words[0], words[^1].TrimEnd('.'), (words[2] == "gain" ? 1 : -1) * int.Parse(words[3])))
                            .ToList();


        Printer.DebugMsg($"Edges: {edges.ToListString()}");

        var result = TSP.SolveSeatingArrangement(edges);
        Printer.DebugMsg($"RLib.Tsp solved to this: {result}");

        return result.Success ? result.Distance.ToString() : null;
    }

    public override string? SecondPuzzle()
    {
        var edges = Data.Select(line => line.Split(" "))
                            .Select(words => new TSP.Edge(words[0], words[^1].TrimEnd('.'), (words[2] == "gain" ? 1 : -1) * int.Parse(words[3])))
                            .ToList();


        Printer.DebugMsg($"Edges: {edges.ToListString()}");

        var result = TSP.SolveSeatingArrangement(edges);
        Printer.DebugMsg($"RLib.Tsp solved to this: {result}");
        var yourself = "yourself";

        if (result.Success)
        {
            var minPair = int.MaxValue;
            var minIndex = 0;
            for (int i = 0; i < result.Path.Length; i++)
            {
                var from = result.Path[i];
                var to = result.Path[(i + 1) % result.Path.Length];
                var costFrom = edges.First(e => e.Start == from && e.End == to);
                var costTo = edges.First(e => e.Start == to && e.End == from);
                if ((costFrom.Cost + costTo.Cost) < minPair)
                {
                    minPair = costFrom.Cost + costTo.Cost;
                    minIndex = i;
                }
            }
            var newPath = result.Path.ToList();
            newPath.Insert(minIndex, yourself);
            result = result with { Path = newPath.ToArray(), Distance = result.Distance - minPair };
            Printer.DebugMsg($"Seating yourself into the optimal seating: {result}");

            return result.Distance.ToString();
        }
        return null;
    }
}