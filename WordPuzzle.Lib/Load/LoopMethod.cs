namespace WordPuzzle.Lib.Load;

public class LoopMethod : WordLoader
{
    public override IDictionary<uint, IEnumerable<string>> LoadWords()
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
        return temporaryStringsInMemory
                .AsParallel()
                .Select(word => 
                {
                    var wordSplit = word.Split(" ");
                    return (
                        wordKey: uint.Parse(wordSplit[0]),
                        wordList: new ArraySegment<string>(wordSplit, 1, wordSplit.Length-1) as IEnumerable<string>
                    );
                }
                )
                .ToDictionary(
                    k => k.wordKey,
                    l => l.wordList
                )
            ;
    }
}