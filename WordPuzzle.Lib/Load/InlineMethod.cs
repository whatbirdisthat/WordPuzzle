namespace WordPuzzle.Lib.Load;

public class InlineMethod : WordLoader
{
    // private const int NumLines = 106181; //106178
    // private static readonly int ConcurrencyLevel = Environment.ProcessorCount * 2;

    public override IDictionary<uint, IEnumerable<string>> LoadWords()
    {
        return
            new Dictionary<uint, IEnumerable<string>>(
                File.ReadLines(WordsFilename)
                    .AsParallel()
                    .Select(line => line.Split(' '))
                    .Select(lineSplit => new KeyValuePair<uint, IEnumerable<string>>(
                        uint.Parse(lineSplit[0]),
                        lineSplit.Skip(1)
                    ))
            );
    }
}