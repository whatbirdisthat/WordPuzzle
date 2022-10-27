using System.Collections.Immutable;
using System.Text.RegularExpressions;
using WordPuzzle.Lib.Loading;

namespace WordPuzzle.Lib;

public class EnglishWordsParallel : IEnglishWords
{
    // private ImmutableDictionary<uint, List<WordModel>> Words { get; }
    // private static readonly Regex InvalidChars = new("[^a-z]");
    // public EnglishWordsParallel()
    // {
    //     Words =
    //         File.ReadLines("./english-words/en")
    //             .AsParallel()
    //             .Where(w => !InvalidChars.IsMatch(w))
    //             .Select(word => new WordModel(word))
    //             .GroupBy(word => word.WordKey)
    //             .ToImmutableDictionary(g => g.Key, g => g.ToList())
    //         ;
    // }
    //
    //
    // public int Count => Words.Count;

    private WordLoader<ImmutableDictionary<uint, List<WordModel>>> Dictionary;

    public EnglishWordsParallel()
    {
        Dictionary = new LinqMethod();
        
    }

    public int Count { get => Dictionary.Words.Count; }

    public IEnumerable<string> ProperSubset(string word)
    {
        var theWordKey = word.WordKey();
        var theWordLength = word.Length;

        var matchingWordKeys = Dictionary
            .Words
            // .AsParallel()
            
            .Where(eachWordKey => eachWordKey.Key == theWordKey)
            //     ;
            //
            // var matchingLengthWordModels = matchingWordKeys
            .Select(wordKey => wordKey.Value)
            .Select(listOfWordModelLists =>
                listOfWordModelLists.Where(wordModel => wordModel.Word.Length == theWordLength));

        foreach (var modelsWithSameKeyAndLength in matchingWordKeys)
        foreach (var q in modelsWithSameKeyAndLength)
            yield return q.Word;
    }


    private void loadDictionaryWords()
    {
        // foreach (var wordModel in results)
        // {
        //     if (
        //         Words.TryAdd(wordModel!.WordKey,
        //             new List<WordModel>(new[] { wordModel }))
        //     )
        //     {
        //         continue;
        //     }
        //
        //     Words[wordModel.WordKey].Add(wordModel);
        // }
    }
}