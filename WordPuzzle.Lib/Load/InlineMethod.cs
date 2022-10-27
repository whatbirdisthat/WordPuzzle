namespace WordPuzzle.Lib.Load;

public class InlineMethod : WordLoader
{
    public override IDictionary<uint, List<WordModel>> LoadWords()
    {
        var loadedWords = new Dictionary<uint, List<WordModel>>();
        using var allLines = new StreamReader(WordsFilename);
        while (!allLines.EndOfStream)
        {
            var validString = allLines.ReadLine();
            var wordModel = new WordModel(validString!);
            if (loadedWords.ContainsKey(wordModel.WordKey))
            {
                loadedWords[wordModel.WordKey].Add(wordModel);
            }
            else
            {
                var theNewWordList = new List<WordModel>();
                theNewWordList.Add(wordModel);
                loadedWords.Add(
                    wordModel.WordKey,
                    theNewWordList
                );
            }
        }

        return loadedWords;
    }
}