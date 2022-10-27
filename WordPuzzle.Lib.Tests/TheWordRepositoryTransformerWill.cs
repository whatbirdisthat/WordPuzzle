using WordPuzzle.Lib.Transform;

namespace WordPuzzle.Lib.Tests;

public class TheWordRepositoryTransformerWill
{
    [Fact]
    // [Fact(Skip = "Run this when you want to build './english-words/wordrepository-en'")]
    public void WillConstruct98721RowsFromDefaultEnFile()
    {
        var transform = new WordRepository();

        transform
            .FromFile("./english-words/en")
            // .ToFile("./english-words/wordrepository-en")
            .ToFile("/shared/source/repos/WordPuzzle/WordPuzzle.Lib/english-words/wordrepository-en")
            ;
        
    }
}