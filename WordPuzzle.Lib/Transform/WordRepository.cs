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
        var transformDestination = new TransformDestination(transformedLines);

        return transformDestination;
    }
}