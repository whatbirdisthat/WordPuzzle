using System.Collections;

namespace WordPuzzle.Lib.Loading;

public abstract class WordLoader<T>
    where T : ICollection
{
    protected WordLoader()
    {
        Words = loadWords();
    }

    public T Words { get; }

    public int Count
    {
        get { return Words.Count; }
    }

    protected abstract T loadWords();
    
}