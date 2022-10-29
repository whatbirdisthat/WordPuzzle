using System.Text.Json;

namespace WordPuzzle.Lib.Transform;

public class TransformDestination
{
    public TransformDestination(
        ParallelQuery<string> transformedLines,
        Dictionary<uint, IEnumerable<string>> wordsDictionary)

    {
        TransformedLines = transformedLines;
        WordsDictionary = wordsDictionary;
    }

    private ParallelQuery<string> TransformedLines { get; }
    public Dictionary<uint, IEnumerable<string>> WordsDictionary { get; set; }

    public void ToFile(string destinationFilename)
    {
        var bigText = string.Join(
            Environment.NewLine,
            TransformedLines
        );
        File.WriteAllText(
            destinationFilename,
            bigText
        );

        File.WriteAllText(
            $"{destinationFilename}-dictionary",
            JsonSerializer.Serialize(WordsDictionary)
        );
    }
}