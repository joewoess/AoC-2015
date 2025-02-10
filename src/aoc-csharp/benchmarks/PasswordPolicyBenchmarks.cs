using aoc_csharp.puzzles;
using BenchmarkDotNet.Attributes;

namespace aoc_csharp.benchmarks;

[Config(typeof(BenchmarkConfig))]
public class PasswordPolicyBenchmarks
{
    private static readonly List<string> TestData = ["hijklmmn", "abbceffg", "abbcegjk", "abcdefgh", "ghijklmn"];
    private const int AmountOfRepetitions = 1000;

    private static List<string> Iterations = [];

    [GlobalSetup]
    public void GlobalSetup()
    {
        Iterations = [];
        TestData.ForEach((input) =>
        {
            Span<char> aggr = input.ToCharArray();
            for (int i = 0; i < AmountOfRepetitions; i++)
            {
                Day11.NextPassword(ref aggr);
                Iterations.Add(aggr.ToString());
            }
        });
    }

    [Benchmark(Baseline = true)]
    public void NextPasswordTest()
    {
        TestData.ForEach((input) =>
        {
            Span<char> aggr = input.ToCharArray();
            for (int i = 0; i < AmountOfRepetitions; i++)
            {
                Day11.NextPassword(ref aggr);
            }
        });
    }

    [Benchmark]
    public void PolicyEightLowercaseLettersTest()
    {
        TestData.ForEach((input) =>
        {
            AmountOfRepetitions.DoTimes(() => Day11.PolicyEightLowercaseLetters(input));
        });
    }

    [Benchmark]
    public void PolicyNoBadLettersTest()
    {
        TestData.ForEach((input) =>
        {
            AmountOfRepetitions.DoTimes(() => Day11.PolicyNoBadLetters(input));
        });
    }

    [Benchmark]
    public void PolicyIncrStraightCheckTest()
    {
        TestData.ForEach((input) =>
        {
            AmountOfRepetitions.DoTimes(() => Day11.PolicyIncrStraightCheck(input));
        });
    }

    [Benchmark]
    public void PolicyNeedsTwoPairsTest()
    {
        TestData.ForEach((input) =>
        {
            AmountOfRepetitions.DoTimes(() => Day11.PolicyNeedsTwoPairs(input));
        });
    }

    [Benchmark]
    public void PolicyEightLowercaseLettersRegexTest()
    {
        TestData.ForEach((input) =>
        {
            AmountOfRepetitions.DoTimes(() => Day11.PolicyEightLowercaseLettersRegex(input));
        });
    }
}