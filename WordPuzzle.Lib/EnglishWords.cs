using System.Collections.Immutable;

namespace WordPuzzle.Lib;

public class EnglishWords
{
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
                temporaryStringsInMemory.Add(q.ToLowerInvariant());
            }
        }

        // var parallelQuery = temporaryStringsInMemory.AsParallel().Where(s => s == "monomania").ToArray();
        
        
        var results = temporaryStringsInMemory
            .AsParallel()
            .Select(word =>
            {
                try
                {
                    var x = new WordModel();
                    x.WordKey = word.WordKey();
                    x.FrequencyModel = word.FrequencyModel();
                    x.Word = word;
                    return x;
                }
                catch (ArgumentOutOfRangeException invalidChar)
                {
                    return null;
                }
            })
            .Where(i => i != null)
            .ToImmutableArray();

        foreach (var wordModel in results)
        {
            if (wordModel == null)
            {
                continue;
            }

            // if (wordModel.Word == "monomania" || wordModel.WordKey == 28929)
            // {
            //     Console.WriteLine("monomania");
            // }
            if (_dictionary.ContainsKey(wordModel.WordKey))
            {
                var thisList =_dictionary[wordModel.WordKey]; 
                _dictionary[wordModel.WordKey] = thisList.Add(wordModel);
            }
            else
            {
                _dictionary.Add(wordModel.WordKey, ImmutableSortedSet.Create(
                    new[] { wordModel })
                );
            }
        }
    }

    public Dictionary<uint, ImmutableSortedSet<WordModel>> _dictionary { get; } = new();

    public EnglishWords()
    {
        loadDictionaryWords();
    }

    public int Count
    {
        get => _dictionary.Count;
    }

    public IEnumerable<string> ProperSubset(string word)
    {
        var theWordKey = word.WordKey();
        var theWordLength = word.Length;
        
        var matchingWordKeys = _dictionary
            .Where(eachWordKey => eachWordKey.Key == theWordKey)
            .ToImmutableList()
            ;
        
        var matchingLengthWordModels = matchingWordKeys
            .Select(wordKey => wordKey.Value)
            .Select(listOfWordModelLists =>
                listOfWordModelLists.Where(wordModel => wordModel.Word.Length == theWordLength));

        foreach (var modelsWithSameKeyAndLength in matchingLengthWordModels.AsParallel())
        {
            foreach (var q in modelsWithSameKeyAndLength)
            {
                yield return q.Word;
            }
        }
    }
}