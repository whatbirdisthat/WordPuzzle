using System.Collections.Immutable;
using System.Text.RegularExpressions;

namespace WordPuzzle.Lib.Load;

public class LinqMethod : WordLoader
{
    // private static readonly Regex InvalidChars = new("[^a-z]");

    public override IDictionary<uint, List<WordModel>> LoadWords() =>
        File.ReadLines(WordsFilename)
            .AsParallel()
            // .Where(w => !InvalidChars.IsMatch(w))
            .Select(word => new WordModel(word))
            .GroupBy(word => word.WordKey)
            .ToImmutableDictionary(
                g => g.Key,
                g => g.ToList()
            );
}