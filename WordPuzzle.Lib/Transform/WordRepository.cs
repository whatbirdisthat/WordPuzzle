using System.Text.RegularExpressions;

namespace WordPuzzle.Lib.Transform;

public class WordRepository
{
    private static readonly Regex AlphaCharsOnly = new Regex("[^a-z]");

    public TransformDestination FromFile(string sourceFilename)
    {
        var transformedToLowercase =
                File.ReadLines(sourceFilename)
                    .AsParallel()
                    .Select(l => l.ToLowerInvariant())
                    .Where(l => !AlphaCharsOnly.IsMatch(l))
            ;

        var transformedLines = transformedToLowercase
                .AsParallel()
                .Where(l => l != null)
                .Where(l => l != string.Empty)
            ;
        var dedupWords =
            new SortedSet<string>(
                transformedLines
            );
        
        var wordKeyDictionary =
                dedupWords
                    .GroupBy(l => l.WordKey())
                    .ToDictionary(
                        k => k.Key,
                        l => l.ToList()
                    )
            ;

        var outputlist = new List<string>();
        foreach (var wordKeyList in wordKeyDictionary)
        {
            var outputLine = $"{wordKeyList.Key} {string.Join(" ", wordKeyList.Value)}";
            outputlist.Add(outputLine);
        }

        var transformDestination = new TransformDestination(
            outputlist.AsParallel(),
            wordKeyDictionary.ToDictionary(
                e => e.Key,
                e => e.Value as IEnumerable<string>)
        );

        return transformDestination;
    }
}