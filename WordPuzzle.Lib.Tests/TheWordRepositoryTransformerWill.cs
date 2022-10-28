using WordPuzzle.Lib.Transform;

namespace WordPuzzle.Lib.Tests;

public class TheWordRepositoryTransformerWill
{
    private const string sourceFileName =
        "./english-words/en";

    const string destinationFileName =
        "/shared/source/repos/WordPuzzle/WordPuzzle.Lib/english-words/wordrepository-en";
        
    [Fact]
    // [Fact(Skip = "Run this when you want to build './english-words/wordrepository-en'")]
    public void WillConstruct98721RowsFromDefaultEnFile()
    {
        var transform = new WordRepository();

        transform
            .FromFile(sourceFileName)
            .ToFile(destinationFileName)
            ;
        
    }
}
