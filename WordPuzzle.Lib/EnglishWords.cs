using System.Text.RegularExpressions;
using WordPuzzle.Lib.Query;

namespace WordPuzzle.Lib;

public class EnglishWords : IEnglishWords
{
    public EnglishWords()
    {
        _properSubset = new ProperSubset<Dictionary<uint, List<WordModel>>>(Dictionary);
        loadDictionaryWords();
    }

    private Dictionary<uint, List<WordModel>> Dictionary { get; } = new();

    public int Count => Dictionary.Count;

    private ProperSubset<Dictionary<uint, List<WordModel>>> _properSubset;

    public IEnumerable<string> ProperSubset(string word)
    {
        return _properSubset.Of(word);
        // var theWordKey = word.WordKey();
        // var theWordLength = word.Length;
        //
        // var matchingWordKeys = Dictionary
        //     .Where(eachWordKey => eachWordKey.Key == theWordKey)
        //     .Select(wordKey => wordKey.Value)
        //     .Select(listOfWordModelLists =>
        //         listOfWordModelLists.Where(wordModel => wordModel.Word.Length == theWordLength));
        //
        // foreach (var modelsWithSameKeyAndLength in matchingWordKeys)
        // foreach (var q in modelsWithSameKeyAndLength)
        //     yield return q.Word;
    }

    private static readonly Regex InvalidChars = new Regex("[^a-z]");

    private void loadDictionaryWords()
    {
        using var wordsFile = new FileInfo("./english-words/en").OpenRead();
        using var fileReader = new StreamReader(wordsFile);
        var temporaryStringsInMemory = new List<string>();
        while (!fileReader.EndOfStream)
        {
            var q = fileReader.ReadLine();
            if (q != null)
            {
                temporaryStringsInMemory.Add(q);
            }
        }

        var results = temporaryStringsInMemory
                .AsParallel()
                .Select(word =>
                {
                    try
                    {
                        return new WordModel(word.ToLowerInvariant());
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        return null;
                    }
                    // return !InvalidChars.IsMatch(word) ? new WordModel(word.ToLowerInvariant()) : null;
                })
                .Where(i => i != null)
            ;
        foreach (var wordModel in results)
        {
            if (wordModel == null) continue;

            if (Dictionary.ContainsKey(wordModel.WordKey))
            {
                var thisList = Dictionary[wordModel.WordKey];
                thisList.Add(wordModel);
            }
            else
            {
                Dictionary.Add(wordModel.WordKey, new List<WordModel>(
                    new[] { wordModel })
                );
            }
        }
    }
}