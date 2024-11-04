namespace aoc_csharp.puzzles;

public sealed class Day06 : PuzzleBaseLines
{
    private const string TurnOn = "turn on";
    private const string TurnOff = "turn off";
    private const string Toggle = "toggle";

    private static (Point From, Point To) ParseLine(string line)
        => line.Split(' ').Where(token => token.Contains(','))
        .PairWithNext().First()
        .MapPairWith(str =>
                {
                    var (x, y) = str.SplitAndMapToPair(int.Parse);
                    return new Point(x, y);
                });


    public override string? FirstPuzzle()
    {
        var grid = new bool[1000, 1000];
        Dictionary<string, Func<bool, bool>> AvailableOperations = new()
        {
            {TurnOn, (_) => true },
            {TurnOff, (_) => false },
            {Toggle, (before) => !before }
        };

        foreach (var line in Data)
        {
            var operation = line switch
            {
                var l when l.StartsWith(TurnOn) => AvailableOperations[TurnOn],
                var l when l.StartsWith(TurnOff) => AvailableOperations[TurnOff],
                var l when l.StartsWith(Toggle) => AvailableOperations[Toggle],
                _ => (_) => false
            };

            var (from, to) = ParseLine(line);
            grid.SetArea(from, to, operation);
        }

        // Printer.DebugMsg(grid.AsJaggedArray().AsPrintable((l) => l == true ? "O" : "-"));
        var numLit = grid.AsJaggedArray().SelectMany(l => l).Count(l => l);
        Printer.DebugMsg($"There are {numLit} lights on");
        return numLit.ToString();
    }

    public override string? SecondPuzzle()
    {
        var grid = new int[1000, 1000];
        Dictionary<string, Func<int, int>> AvailableOperations = new()
        {
            {TurnOn, (before) => before + 1 },
            {TurnOff, (before) => before == 0 ? 0 : before - 1 },
            {Toggle, (before) => before + 2 }
        };

        foreach (var line in Data)
        {
            var operation = line switch
            {
                var l when l.StartsWith(TurnOn) => AvailableOperations[TurnOn],
                var l when l.StartsWith(TurnOff) => AvailableOperations[TurnOff],
                var l when l.StartsWith(Toggle) => AvailableOperations[Toggle],
                _ => (_) => 0
            };

            var (from, to) = ParseLine(line);
            grid.SetArea(from, to, operation);
        }

        var numLit = grid.AsJaggedArray().SelectMany(l => l).Sum(l => l);
        Printer.DebugMsg($"There is a total brightness of {numLit}");
        return numLit.ToString();
    }

}