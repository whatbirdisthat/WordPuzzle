using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using WordPuzzle.Lib;

namespace WordPuzzle.Benchmarks;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
public class AnagramBenchmarksFind
{
    private readonly EnglishWords _theEnglishWords = new();
    private readonly EnglishWordsParallel _theEnglishWordsParallel = new();

    [Benchmark(Baseline = true, Description = "Baseline: 'moonamain'")]
    public void GetAnagrams9Letters_Baseline()
    {
        const string word = "moonamain";
        var anagrams = word.Anagrams(_theEnglishWords);
        Console.WriteLine($"::: Word: {word} :::");
        Console.WriteLine(string.Join(", ", anagrams));
    }

    [Benchmark(Description = "Baseline: 'amino'")]
    public void GetAnagrams5Letters_Baseline()
    {
        const string word = "amino";

        var anagrams = word.Anagrams(_theEnglishWords);
        Console.WriteLine($"::: Word: {word} :::");
        Console.WriteLine(string.Join(", ", anagrams));
    }

    [Benchmark(Description = "Baseline: 'cyberpunk'")]
    public void GetAnagramsCyberpunk_Baseline()
    {
        const string word = "cyberpunk";

        var anagrams = word.Anagrams(_theEnglishWords);
        Console.WriteLine($"::: Word: {word} :::");
        Console.WriteLine(string.Join(", ", anagrams));
    }


    [Benchmark(Description = "Parallel: 'moonamain'")]
    public void GetAnagrams9Letters_Parallel()
    {
        const string word = "moonamain";
        var anagrams = word.Anagrams(_theEnglishWordsParallel);
        Console.WriteLine($"::: Word: {word} :::");
        Console.WriteLine(string.Join(", ", anagrams));
    }

    [Benchmark(Description = "Parallel: 'amino'")]
    public void GetAnagrams5Letters_Parallel()
    {
        const string word = "amino";

        var anagrams = word.Anagrams(_theEnglishWordsParallel);
        Console.WriteLine($"::: Word: {word} :::");
        Console.WriteLine(string.Join(", ", anagrams));
    }

    [Benchmark(Description = "Parallel: 'cyberpunk'")]
    public void GetAnagramsCyberpunk_Parallel()
    {
        const string word = "cyberpunk";

        var anagrams = word.Anagrams(_theEnglishWordsParallel);
        Console.WriteLine($"::: Word: {word} :::");
        Console.WriteLine(string.Join(", ", anagrams));
    }
}