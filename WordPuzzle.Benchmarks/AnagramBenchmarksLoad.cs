using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using WordPuzzle.Lib;

namespace WordPuzzle.Benchmarks;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
public class AnagramBenchmarksLoad
{
    [Benchmark(Baseline = true, Description = "Baseline: loading")]
    public void LoadBaseline()
    {
        var _theEnglishWords = new EnglishWords();
    }

    // [Benchmark(Description = "Immutable: loading")]
    // public void LoadBaselineImmutable()
    // {
    //     var _theEnglishWordsImmutable = new EnglishWordsImmutable();
    // }

    /// <summary>
    /// The fastest way of loading (so far) words into the dictionary.
    /// </summary>
    [Benchmark(Description = "Parallel: loading")]
    public void LoadBaselineParallel()
    {
        var _theEnglishWordsParallel = new EnglishWordsParallel();
    }
}