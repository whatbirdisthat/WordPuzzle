namespace WordPuzzle.Lib;

public interface IEnglishWords //<T1> where T1 : ICollection<WordModel>
{
    int Count { get; }
    IEnumerable<string> ProperSubset(string word);
}