namespace WordPuzzle.Lib.Load;

public abstract class WordLoader : IWordLoader
{
    protected const string WordsFilename =
        "./english-words/wordrepository-en";

    public WordLoader()
    {
        Words = LoadWords();
    }

    public IDictionary<uint, IEnumerable<string>> Words { get; set; }

    public abstract IDictionary<uint, IEnumerable<string>> LoadWords();
}