namespace WordPuzzle.Lib.Load;

public abstract class WordLoader : IWordLoader<IDictionary<uint, List<WordModel>>>
{
    protected const string WordsFilename =
        "./english-words/wordrepository-en";
    
    public WordLoader()
    {
        Words = LoadWords();
    }

    public IDictionary<uint, List<WordModel>> Words { get; set; }

    public abstract IDictionary<uint, List<WordModel>> LoadWords();
}
