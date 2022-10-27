using System.Collections.Immutable;

namespace WordPuzzle.Lib.Load;

public class ImmutableMethod : WordLoader
{
    public override IDictionary<uint, List<WordModel>> LoadWords()
    {

        using var wordsFile = new FileInfo(WordsFilename).OpenRead();
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

        // var parallelQuery = temporaryStringsInMemory.AsParallel().Where(s => s == "monomania").ToArray();

        var results = temporaryStringsInMemory
            .Select(word =>new WordModel(word))
            .ToImmutableArray();

        var loadedWords = new Dictionary<uint, List<WordModel>>();
        
        foreach (var wordModel in results)
        {
            if (loadedWords.ContainsKey(wordModel.WordKey))
            {
                var thisList = loadedWords[wordModel.WordKey];
                thisList.Add(wordModel);
            }
            else
            {
                loadedWords.Add(wordModel.WordKey, new List<WordModel>(
                    new[] { wordModel })
                );
            }
        }
        return loadedWords;
    }
}