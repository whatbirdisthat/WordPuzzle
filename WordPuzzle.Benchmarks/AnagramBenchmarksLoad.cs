using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using WordPuzzle.Lib.Load;
using WordPuzzle.Lib.Query;
using WordPuzzle.Lib.Repository;

namespace WordPuzzle.Benchmarks;


/**

|                     Method |     Mean |    Error |   StdDev | Ratio | RatioSD | Rank |      Gen0 |      Gen1 |      Gen2 | Allocated | Alloc Ratio |
|--------------------------- |---------:|---------:|---------:|------:|--------:|-----:|----------:|----------:|----------:|----------:|------------:|
| 'ImmutableMethod: loading' | 58.00 ms | 1.128 ms | 1.723 ms |  0.79 |    0.02 |    1 | 6444.4444 | 2888.8889 | 1000.0000 |  40.21 MB |        0.84 |
|      'LinqMethod: loading' | 62.85 ms | 1.257 ms | 2.510 ms |  0.85 |    0.03 |    2 | 6750.0000 | 2875.0000 | 1000.0000 |  46.39 MB |        0.97 |
|    'InlineMethod: loading' | 65.30 ms | 1.236 ms | 1.424 ms |  0.89 |    0.02 |    3 | 6222.2222 | 2333.3333 |  333.3333 |  48.09 MB |        1.00 |
|      'LoopMethod: loading' | 73.26 ms | 0.859 ms | 0.803 ms |  1.00 |    0.00 |    4 | 6428.5714 | 2857.1429 |  857.1429 |  48.02 MB |        1.00 |

 */

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
 // [SimpleJob(launchCount: 1, warmupCount: 1, targetCount: 1, invocationCount:1)]
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
