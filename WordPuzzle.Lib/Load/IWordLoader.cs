namespace WordPuzzle.Lib.Load;

public interface IWordLoader<T>
{
    T Words { get; set; }
    T LoadWords();
}