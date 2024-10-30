namespace aoc_csharp.puzzles;

public sealed class Day02 : PuzzleBaseLines
{
    public override string? FirstPuzzle()
    {
        var sumWrappingPaper = 0;
        foreach (var line in Data)
        {
            var boxSizes = line.Split('x')
                            .Select(int.Parse)
                            .ToArray();
            var (l, w, h) = (boxSizes[0], boxSizes[1], boxSizes[2]);
            int[] sides = [l * w, w * h, h * l];
            var smallestSide = sides.Min();
            var boxPaper = sides.Sum(side => 2 * side) + smallestSide;

            Printer.DebugMsg($"Box {line} needs {boxPaper} paper (including extra {smallestSide})");
            sumWrappingPaper += boxPaper;
        }

        Printer.DebugMsg($"Total wrapping paper needed: {sumWrappingPaper}");
        return sumWrappingPaper.ToString();
    }

    public override string? SecondPuzzle()
    {
        var sumRibbon = 0;
        foreach (var line in Data)
        {
            var boxSizes = line.Split('x')
                            .Select(int.Parse)
                            .ToArray();
            var (l, w, h) = (boxSizes[0], boxSizes[1], boxSizes[2]);
            int[] sides = [l * w, w * h, h * l];
            var smallestSide = sides.Min();
            var boxPaper = sides.Sum(side => 2 * side) + smallestSide;

            var smallestSides = boxSizes.Order().Take(2).ToArray();
            var ribbon = 2 * smallestSides[0] + 2 * smallestSides[1];

            var bow = boxSizes.Aggregate((a, b) => a * b);

            Printer.DebugMsg($"Box {line} needs {ribbon + bow} amount of ribbon ({ribbon} and {bow})");
            sumRibbon += ribbon + bow;
        }

        Printer.DebugMsg($"Total wrapping paper needed: {sumRibbon}");
        return sumRibbon.ToString();
    }
}