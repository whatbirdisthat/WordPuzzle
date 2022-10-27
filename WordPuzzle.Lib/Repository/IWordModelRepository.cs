namespace WordPuzzle.Lib.Repository;

public interface IWordModelRepository

{
    int Count { get; }
    IEnumerable<string> ProperSubset(string word);
}