using System.Collections.Immutable;
using System.Text.RegularExpressions;

namespace WordPuzzle.Lib.Loading;

public class LinqMethod : WordLoader<ImmutableDictionary<uint, List<WordModel>>>
{
    private static readonly Regex InvalidChars = new("[^a-z]");

    protected override ImmutableDictionary<uint, List<WordModel>> loadWords() =>             File.ReadLines("./english-words/en")
        .AsParallel()
        .Where(w => !InvalidChars.IsMatch(w))
        .Select(word => new WordModel(word))
        .GroupBy(word => word.WordKey)
        .ToImmutableDictionary(g => g.Key, g => g.ToList())
    ;
    
}