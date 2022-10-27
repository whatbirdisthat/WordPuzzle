using WordPuzzle.Lib.Load;
using WordPuzzle.Lib.Query;

namespace WordPuzzle.Lib.Repository;

public class WordModelRepository<TLoader, TQuery>
    : IWordModelRepository
    where TLoader : IWordLoader<IDictionary<uint, List<WordModel>>>, new()
    where TQuery : ProperSubset, new()

{
    private readonly TLoader _loader;
    private readonly TQuery _query;

    public WordModelRepository()
    {
        _loader = new TLoader();
        _query = new TQuery();
    }

    public int Count => _loader.Words!.Count;
    public IEnumerable<string> ProperSubset(string word) => _query.Of(word, _loader.Words);
}