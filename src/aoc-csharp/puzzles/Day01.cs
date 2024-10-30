namespace aoc_csharp.puzzles;

public sealed class Day01 : PuzzleBaseText
{
    public override string? FirstPuzzle()
    {
        var openingBrackets = Data.Count(ch => ch == '(');
        var closingBrackets = Data.Count(ch => ch == ')');

        var finalFloor = openingBrackets - closingBrackets;

        Printer.DebugMsg($"Final floor: {finalFloor}");
        return finalFloor.ToString();
    }

    public override string? SecondPuzzle()
    {
        var currentFloor = 0;
        var basementInstructions = 0;
        foreach (var (ch, idx) in Data.WithIndex())
        {
            currentFloor = ch switch
            {
                '(' => currentFloor + 1,
                ')' => currentFloor - 1,
                _ => currentFloor
            };
            if (currentFloor == -1)
            {
                basementInstructions = idx + 1;
                break;
            }
        }

        Printer.DebugMsg($"Instruction to enter basement at: {basementInstructions}");
        return basementInstructions.ToString();
    }
}