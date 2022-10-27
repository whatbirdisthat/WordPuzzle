using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using WordPuzzle.Lib.Load;
using WordPuzzle.Lib.Query;
using WordPuzzle.Lib.Repository;

namespace WordPuzzle.Benchmarks;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
[SimpleJob(launchCount: 1, warmupCount: 1, targetCount: 1, invocationCount:1)]
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
