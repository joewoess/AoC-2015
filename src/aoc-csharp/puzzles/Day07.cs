using System.Diagnostics;

namespace aoc_csharp.puzzles;

public sealed class Day07 : PuzzleBaseLines
{
    private static (string op, string a, string b, string res) ParseLine(string line)
    {
        var (calc, res) = line.SplitAndMapToPair(str => str, " -> ");
        return calc.Split() switch
        {
            var parts when parts.Length == 3 => (parts[1], parts[0], parts[2], res),
            var parts when parts.Length == 2 => (parts[0], parts[1], "", res),
            var parts when parts.Length == 1 => ("", parts[0], "", res),
            _ => ("", "", "", res),
        };
    }

    private static readonly Dictionary<string, Func<ushort, ushort, ushort>> AvailableOperations = new()
    {
        {"AND", (a, b) => (ushort)(a & b) },
        {"OR", (a, b) => (ushort)(a | b) },
        {"LSHIFT", (a, b) => (ushort)(a << b) },
        {"RSHIFT", (a, b) => (ushort)(a >> b) },
        {"NOT", (a, _) => (ushort)~a },
        {"", (a,_) => a }
    };

    public override string? FirstPuzzle()
    {
        var wires = new Dictionary<string, ushort>();
        var todo = Data.ToDictionary(l => Guid.NewGuid(), l => l);
        var maxRetries = 100000; // just here to not get endless loops

        for (int numRetry = 0; numRetry < maxRetries; numRetry++)
        {
            var thisPass = todo.ToList(); // extra var to avoid editing a list we iterate over
            Printer.DebugMsg($"Pass number #{numRetry + 1}");
            foreach (var (id, line) in thisPass)
            {
                var (op, a, b, res) = ParseLine(line);
                var isNumericA = ushort.TryParse(a, out var numA);
                var isActiveWireA = wires.TryGetValue(a, out var wireA);
                var isNumericB = ushort.TryParse(b, out var numB);
                var isActiveWireB = wires.TryGetValue(b, out var wireB);
                var isEssentialB = op != "" && op != "NOT";
                if ((isNumericA || isActiveWireA) && (!isEssentialB || isNumericB || isActiveWireB))
                {
                    var operation = AvailableOperations[op];
                    wires[res] = operation(isNumericA ? numA : wireA, isNumericB ? numB : wireB);
                    todo.Remove(id);
                }
                else
                {
                    // Printer.DebugMsg($"Wire '{((isNumericA || isActiveWireA) ? a : b)}' was not initialized for {line}");
                    // Printer.DebugMsg($"[{isNumericA}][{isActiveWireA}][{isEssentialB}][{isNumericB}][{isNumericB}][{op}]");
                    continue;
                }
            }
            if (todo.Count == 0)
            {
                break;
            }
        }

        //Printer.DebugMsg(wires.ToListString());
        Printer.DebugMsg($"There are {todo.Count} wires remaining without signal");
        var wireInSearch = Config.IsDemo ? "y" : "a"; // for demodata we didnt have an 'a' wire
        var result = wires[wireInSearch];
        Printer.DebugMsg($"Wire {wireInSearch} has the following signal {result}");
        return result.ToString();
    }

    public override string? SecondPuzzle()
    {
        // stay dynamic here since puzzle 2 wants the answer of puzzle one
        // but we dont need all the debug messages here again
        var tempConfig = Config.IsDebug;
        Config.IsDebug = false;
        var firstPassResult = FirstPuzzle();
        Config.IsDebug = tempConfig;

        var initWireB = ushort.TryParse(firstPassResult, out var startB);
        if (!initWireB)
        {
            Printer.DebugMsg($"There was no valid solution to the first puzzle");
            return null;
        }
        Printer.DebugMsg($"Initialized Wire 'b' with {startB}");
        var wires = new Dictionary<string, ushort>()
        {
            {"b", startB}
        };
        var todo = Data.ToDictionary(l => Guid.NewGuid(), l => l);
        var maxRetries = 100000; // just here to not get endless loops

        for (int numRetry = 0; numRetry < maxRetries; numRetry++)
        {
            var thisPass = todo.ToList(); // extra var to avoid editing a list we iterate over
            Printer.DebugMsg($"Pass number #{numRetry + 1}");
            foreach (var (id, line) in thisPass)
            {
                var (op, a, b, res) = ParseLine(line);
                var isNumericA = ushort.TryParse(a, out var numA);
                var isActiveWireA = wires.TryGetValue(a, out var wireA);
                var isNumericB = ushort.TryParse(b, out var numB);
                var isActiveWireB = wires.TryGetValue(b, out var wireB);
                var isEssentialB = op != "" && op != "NOT";

                if (res == "b")
                {
                    Printer.DebugMsg("Skipped due to override");
                    todo.Remove(id);
                    continue;
                }

                if ((isNumericA || isActiveWireA) && (!isEssentialB || isNumericB || isActiveWireB))
                {
                    var operation = AvailableOperations[op];
                    wires[res] = operation(isNumericA ? numA : wireA, isNumericB ? numB : wireB);
                    todo.Remove(id);
                }
                else
                {
                    // Printer.DebugMsg($"Wire '{((isNumericA || isActiveWireA) ? a : b)}' was not initialized for {line}");
                    // Printer.DebugMsg($"[{isNumericA}][{isActiveWireA}][{isEssentialB}][{isNumericB}][{isNumericB}][{op}]");
                    continue;
                }
            }
            if (todo.Count == 0)
            {
                break;
            }
        }

        //Printer.DebugMsg(wires.ToListString());
        Printer.DebugMsg($"There are {todo.Count} wires remaining without signal");
        var wireInSearch = Config.IsDemo ? "y" : "a"; // for demodata we didnt have an 'a' wire
        var result = wires[wireInSearch];
        Printer.DebugMsg($"Wire {wireInSearch} has the following signal {result}");
        return result.ToString();
    }

}