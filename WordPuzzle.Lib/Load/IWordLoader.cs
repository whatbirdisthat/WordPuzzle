namespace WordPuzzle.Lib.Load;

public interface IWordLoader
{
    IDictionary<uint, IEnumerable<string>> Words { get; set; }
    IDictionary<uint, IEnumerable<string>> LoadWords();
}