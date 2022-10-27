using System.Collections;

namespace WordPuzzle.Lib.Query;

public class ProperSubset<T> where T:IDictionary<uint, List<WordModel>>
{
    private T Dictionary;

    public ProperSubset(T dictionary)
    {
        Dictionary = dictionary;
    }

    public IEnumerable<string> Of(string word)
    {
        var theWordKey = word.WordKey();
        var theWordLength = word.Length;

        var matchingWordKeys = Dictionary
            .Where(eachWordKey => eachWordKey.Key == theWordKey)
            .Select(wordKey => wordKey.Value)
            .Select(listOfWordModelLists =>
                listOfWordModelLists.Where(wordModel => wordModel.Word.Length == theWordLength));

        foreach (var modelsWithSameKeyAndLength in matchingWordKeys)
        foreach (var q in modelsWithSameKeyAndLength)
            yield return q.Word;

    }
}