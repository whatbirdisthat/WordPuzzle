namespace WordPuzzle.Lib.Load;

public class LoopMethod : WordLoader
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

        var results = temporaryStringsInMemory
                .AsParallel()
                .Select(word => new WordModel(word))
            ;

        Words = new Dictionary<uint, List<WordModel>>();
        foreach (var wordModel in results)
        {
            // if (wordModel == null) continue;

            if (Words.ContainsKey(wordModel.WordKey))
            {
                var thisList = Words[wordModel.WordKey];
                thisList.Add(wordModel);
            }
            else
            {
                Words.Add(wordModel.WordKey, new List<WordModel>(
                    new[] { wordModel })
                );
            }
        }

        return Words;
    }
}