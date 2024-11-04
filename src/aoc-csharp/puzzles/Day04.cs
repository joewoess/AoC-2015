using System.Text;

namespace aoc_csharp.puzzles;

public sealed class Day04 : PuzzleBaseText
{

    public override string? FirstPuzzle()
    {
        var secret = Data;
        const string RequiredStartingHex = "00000"; // 5 zeroes
        var validNum = 0;
        var resultHex = "";

        while (!resultHex.StartsWith(RequiredStartingHex))
        {
            validNum++;
            resultHex = GetMd5Hex($"{secret}{validNum}");
        }

        Printer.DebugMsg($"For Key {Data} smallest number for adventCoin is {validNum} with an md5 hash of {resultHex}");
        return validNum.ToString();
    }

    public override string? SecondPuzzle()
    {
        var secret = Data;
        const string RequiredStartingHex = "000000"; // 6 zeroes
        var validNum = 0;
        var resultHex = "";

        while (!resultHex.StartsWith(RequiredStartingHex))
        {
            validNum++;
            resultHex = GetMd5Hex($"{secret}{validNum}");
        }

        Printer.DebugMsg($"For Key {Data} smallest number for adventCoin is {validNum} with an md5 hash of {resultHex}");
        return validNum.ToString();
    }

    private static string GetMd5Hex(string secret)
    {
        byte[] inputBytes = Encoding.ASCII.GetBytes(secret);
        byte[] hashBytes = System.Security.Cryptography.MD5.HashData(inputBytes);
        return Convert.ToHexString(hashBytes);
    }
}