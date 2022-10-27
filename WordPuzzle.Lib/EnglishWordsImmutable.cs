using System.Collections.Immutable;

namespace WordPuzzle.Lib;

public class EnglishWordsImmutable : IEnglishWords
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
            .Select(word =>
            {
                try
                {
                    var x = new WordModel(word);
                    return x;
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.Error.WriteLine($"Word '{word}' contains invalid char. Skipping.");
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
            if (Dictionary.ContainsKey(wordModel.WordKey))
            {
                var thisList = Dictionary[wordModel.WordKey];
                Dictionary[wordModel.WordKey] = thisList.Add(wordModel);
            }
            else
            {
                Dictionary.Add(wordModel.WordKey, ImmutableSortedSet.Create(
                    new[] { wordModel })
                );
            }
        }
    }

    public Dictionary<uint, ImmutableSortedSet<WordModel>> Dictionary { get; } = new();

    public EnglishWordsImmutable()
    {
        loadDictionaryWords();
    }

    public int Count
    {
        get => Dictionary.Count;
    }

    public IEnumerable<string> ProperSubset(string word)
    {
        var theWordKey = word.WordKey();
        var theWordLength = word.Length;

        var matchingWordKeys = Dictionary
                .Where(eachWordKey => eachWordKey.Key == theWordKey)
                .ToImmutableList()
            ;

        var matchingLengthWordModels = matchingWordKeys
            .Select(wordKey => wordKey.Value)
            .Select(listOfWordModelLists =>
                listOfWordModelLists.Where(wordModel => wordModel.Word.Length == theWordLength));

        foreach (var modelsWithSameKeyAndLength in matchingLengthWordModels)
        {
            foreach (var q in modelsWithSameKeyAndLength)
            {
                yield return q.Word;
            }
        }
    }
}