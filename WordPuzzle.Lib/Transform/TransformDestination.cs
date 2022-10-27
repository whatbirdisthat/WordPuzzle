namespace WordPuzzle.Lib.Transform;

public class TransformDestination
{
    public TransformDestination(ParallelQuery<string> transformedLines)
    {
        TransformedLines = transformedLines;
    }

    private ParallelQuery<string> TransformedLines { get; }

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
    }
}