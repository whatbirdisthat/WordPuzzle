namespace WordPuzzle.Lib.Query;

public class ProperSubset
{
    public IEnumerable<string> Of(string word, IDictionary<uint, IEnumerable<string>> fromWords)
    {
        var theWordKey = word.WordKey();
        var theWordLength = word.Length;

        var matchingWordKeys = fromWords
            .Where(eachWordKey => eachWordKey.Key == theWordKey)
            .Select(wordKey => wordKey.Value)
            .Select(listOfWordModelLists =>
                listOfWordModelLists.Where(word => word.Length == theWordLength));

        foreach (var modelsWithSameKeyAndLength in matchingWordKeys)
        foreach (var q in modelsWithSameKeyAndLength)
            yield return q;
    }
}