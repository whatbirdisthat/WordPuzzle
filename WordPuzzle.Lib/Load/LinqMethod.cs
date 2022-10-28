namespace WordPuzzle.Lib.Load;

public class LinqMethod : WordLoader
{
    public override IDictionary<uint, IEnumerable<string>> LoadWords() =>
        File.ReadLines(WordsFilename)
            .AsParallel()
            .Select(word =>
                {
                    var wordSplit = word.Split(" ");
                    return (
                        wordKey: uint.Parse(wordSplit[0]),
                        wordList: wordSplit.Skip(1)
                    );
                }
            )
            .ToDictionary(
                k => k.wordKey,
                l => l.wordList
            );
}