namespace aoc_csharp.puzzles;

public sealed class Day03 : PuzzleBaseText
{
    public override string? FirstPuzzle()
    {
        var startingPoint = new Point(0, 0);
        var instructions = Data.Select(c => c.ToString().ParseDirection()).ToList();
        List<Point> visitedHouses = [startingPoint];

        var lastPoint = instructions.Aggregate<Direction, Point>(startingPoint, (lastPoint, dirNext) =>
        {
            var nextHouse = lastPoint.StepInDirection(dirNext);
            visitedHouses.Add(nextHouse);
            return nextHouse;
        });

        var countHousesVisited = visitedHouses.Distinct().Count();
        Printer.DebugMsg($"Houses visited {countHousesVisited}");
        Printer.DebugMsg($"{visitedHouses.ToListString()}");
        return countHousesVisited.ToString();
    }

    public override string? SecondPuzzle()
    {
        var startingPoint = new Point(0, 0);
        var instructions = Data.Select(c => c.ToString().ParseDirection()).ToList();
        List<Point> visitedBySanta = [startingPoint], visitedByRobotSanta = [startingPoint];

        var santaInstructions = instructions.Where((_, idx) => idx % 2 == 0).ToList();
        var robotInstructions = instructions.Where((_, idx) => idx % 2 == 1).ToList();

        var lastSantaPoint = santaInstructions.Aggregate(startingPoint, (lastPoint, dirNext) =>
        {
            var nextHouse = lastPoint.StepInDirection(dirNext);
            visitedBySanta.Add(nextHouse);
            return nextHouse;
        });

        var lastRobotPoint = robotInstructions.Aggregate(startingPoint, (lastPoint, dirNext) =>
        {
            var nextHouse = lastPoint.StepInDirection(dirNext);
            visitedByRobotSanta.Add(nextHouse);
            return nextHouse;
        });

        var countHousesVisited = visitedByRobotSanta.Union(visitedBySanta).Distinct().Count();
        Printer.DebugMsg($"Houses visited {countHousesVisited}");
        Printer.DebugMsg($"By Santa {visitedBySanta.ToListString()}");
        Printer.DebugMsg($"By Robot {visitedByRobotSanta.ToListString()}");
        return countHousesVisited.ToString();
    }
}