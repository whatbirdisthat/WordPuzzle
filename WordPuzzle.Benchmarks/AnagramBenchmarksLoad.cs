using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using WordPuzzle.Lib.Load;
using WordPuzzle.Lib.Query;
using WordPuzzle.Lib.Repository;

namespace WordPuzzle.Benchmarks;

/**

|                     Method |     Mean |    Error |   StdDev | Ratio | RatioSD | Rank |      Gen0 |      Gen1 |      Gen2 | Allocated | Alloc Ratio |
|--------------------------- |---------:|---------:|---------:|------:|--------:|-----:|----------:|----------:|----------:|----------:|------------:|
|    'InlineMethod: loading' | 56.29 ms | 1.119 ms | 2.259 ms |  0.77 |    0.05 |    1 | 6600.0000 | 2600.0000 | 1000.0000 |  43.38 MB |        0.90 |
| 'ImmutableMethod: loading' | 57.93 ms | 1.126 ms | 1.579 ms |  0.80 |    0.05 |    2 | 6400.0000 | 2800.0000 | 1000.0000 |  40.22 MB |        0.84 |
|      'LinqMethod: loading' | 63.76 ms | 1.250 ms | 2.286 ms |  0.87 |    0.04 |    3 | 6555.5556 | 2777.7778 | 1000.0000 |  46.51 MB |        0.97 |
|      'LoopMethod: loading' | 72.99 ms | 1.453 ms | 2.583 ms |  1.00 |    0.00 |    4 | 6500.0000 | 2875.0000 |  875.0000 |  48.04 MB |        1.00 |

 */
[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
// [SimpleJob(launchCount: 1, warmupCount: 1, targetCount: 1, invocationCount: 1)]
public class AnagramBenchmarksLoad
{
    [Benchmark(Baseline = true, Description = "LoopMethod: loading")]
    public void LoadLoopMethod()
    {
        var _theRepository = new WordModelRepository<LoopMethod, ProperSubset>();
    }

    [Benchmark(Description = "InlineMethod: loading")]
    public void LoadInlineMethod()
    {
        var _theRepository = new WordModelRepository<InlineMethod, ProperSubset>();
    }

    [Benchmark(Description = "ImmutableMethod: loading")]
    public void LoadImmutableMethod()
    {
        var _theRepository = new WordModelRepository<ImmutableMethod, ProperSubset>();
    }

    [Benchmark(Description = "LinqMethod: loading")]
    public void LoadLinqMethod()
    {
        var _theRepository = new WordModelRepository<LinqMethod, ProperSubset>();
    }
}