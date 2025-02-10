using System.Text.RegularExpressions;

namespace aoc_csharp.puzzles;

public partial class Day11 : PuzzleBaseText
{
    public override string? FirstPuzzle()
    {
        Span<char> nextPassword = Data.ToCharArray();
        var validNextPassword = false;
        int counter = 0;
        CheatEarlyReplacements(ref nextPassword);
        while (!validNextPassword)
        {
            NextPassword(ref nextPassword);
            validNextPassword = AllPolicies(nextPassword);
            counter++;
            if (counter % 100_000 == 0)
            {
                Printer.DebugMsg($"From {Data} after {counter} Iterations you get {nextPassword}");
            }
        }
        Printer.DebugMsg($"Next valid password after starting at {Data} is {nextPassword} after {counter} iterations.");
        return nextPassword.ToString();
    }

    public override string? SecondPuzzle()
    {
        Span<char> nextPassword = Data.ToCharArray();
        var validNextPassword = false;
        var validSecondPassword = false;
        int counter = 0;
        CheatEarlyReplacements(ref nextPassword);
        while (!validNextPassword || !validSecondPassword)
        {
            validSecondPassword |= validNextPassword;
            NextPassword(ref nextPassword);
            validNextPassword = AllPolicies(nextPassword);
            counter++;
            if (counter % 100_000 == 0)
            {
                Printer.DebugMsg($"From {Data} after {counter} Iterations you get {nextPassword}");
            }
        }
        Printer.DebugMsg($"Second-next valid password after starting at {Data} is {nextPassword} after {counter} iterations.");
        return nextPassword.ToString();
    }

    public static void CheatEarlyReplacements(ref Span<char> pw)
    {
        // If there are i's or j's in the input, early increase it 
        var indexOfFirstInvalid = pw.IndexOfAny(['i', 'o', 'l']);
        if (indexOfFirstInvalid != -1)
        {
            pw.Replace('i', 'j');
            pw.Replace('o', 'p');
            pw.Replace('l', 'm');
            for (int i = indexOfFirstInvalid + 1; i < pw.Length; i++)
            {
                pw[i] = 'a';
            }
        }
    }
    public static void NextPassword(ref Span<char> pw)
    {
        bool overflow;
        for (int i = pw.Length - 1; i >= 0; i--)
        {
            overflow = pw[i] == 'z';
            pw[i] = overflow ? 'a' : (char)(pw[i] + 1);
            if (!overflow) break;
        }
    }
    public static bool PolicyEightLowercaseLetters(ReadOnlySpan<char> pw) => pw.Length == 8 && !pw.ContainsAnyExceptInRange('a', 'z');
    public static bool PolicyEightLowercaseLettersRegex(ReadOnlySpan<char> pw) => EightLowerRegex().IsMatch(pw);
    public static bool PolicyNoBadLetters(ReadOnlySpan<char> pw) => !pw.ContainsAny(['i', 'l', 'o']);
    public static bool PolicyIncrStraightCheck(ReadOnlySpan<char> pw)
    {
        for (int i = 0; i < pw.Length - 2; i++)
        {
            if ((pw[i + 2] - pw[i + 1] == 1) && (pw[i + 1] - pw[i + 0] == 1))
            {
                return true;
            }
        }
        return false;
    }// => pw.Window(3).Any(str => (str[2] - str[1] == 1) && (str[1] - str[0] == 1));
    public static bool PolicyNeedsTwoPairs(ReadOnlySpan<char> pw)
    {
        int? firstIndex = null;
        for (int i = 0; i < pw.Length - 1; i++)
        {
            if (pw[i] == pw[i + 1])
            {
                if (firstIndex != -1 && i - firstIndex > 1)
                {
                    return true;
                }
                firstIndex ??= i;
            }
        }
        return false;
    }
    public static bool AllPolicies(ReadOnlySpan<char> pw) => PolicyEightLowercaseLetters(pw)
                                            && PolicyNoBadLetters(pw)
                                            && PolicyIncrStraightCheck(pw)
                                            && PolicyNeedsTwoPairs(pw);

    [GeneratedRegex("^[a-z]{8}$")]
    public static partial Regex EightLowerRegex();
}