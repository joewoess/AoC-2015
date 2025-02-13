using System.Text.Json;

namespace aoc_csharp.puzzles;

public sealed class Day12 : PuzzleBaseText
{
    public override string? FirstPuzzle()
    {
        using var json = JsonDocument.Parse(Data);
        var numbers = FindNumbers(json.RootElement);
        Printer.DebugMsg($"Numbers found: {numbers.ToListString()}");

        var result = numbers.Sum();
        return result.ToString();
    }

    public override string? SecondPuzzle()
    {
        using var json = JsonDocument.Parse(Data);
        var ignoreFlag = "red";
        var numbers = FindNumbers(json.RootElement, ignoreFlag);
        Printer.DebugMsg($"Numbers found ignoring '{ignoreFlag}': {numbers.ToListString()}");

        var result = numbers.Sum();
        return result.ToString();
    }


    private static List<int> FindNumbers(JsonElement startNode, string? ignoreObjectFlag = null)
    {
        return startNode.ValueKind switch
        {
            JsonValueKind.Object when ignoreObjectFlag is not null
                && startNode.EnumerateObject()
                            .Any(prop => prop.Value.ValueKind == JsonValueKind.String && prop.Value.GetString() == ignoreObjectFlag) => [],
            JsonValueKind.Object => startNode.EnumerateObject().SelectMany(item => FindNumbers(item.Value, ignoreObjectFlag)).ToList(),
            JsonValueKind.Array => startNode.EnumerateArray().SelectMany(item => FindNumbers(item, ignoreObjectFlag)).ToList(),
            JsonValueKind.Number when startNode.TryGetInt32(out int numberValue) => [numberValue],
            _ => []
        };
    }
}