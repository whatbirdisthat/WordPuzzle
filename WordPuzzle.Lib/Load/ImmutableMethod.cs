using System.Collections.Immutable;

namespace WordPuzzle.Lib.Load;

public class ImmutableMethod : WordLoader
{
    public override IDictionary<uint, IEnumerable<string>> LoadWords()
    {
        var temporaryStringsInMemory =
                File.ReadLines(WordsFilename)
                    .AsParallel()
                    .Select(l => l.Split(' '))
                    .Select(d => (
                            wordKey: uint.Parse(d[0]),
                            wordList: new ArraySegment<string>(d, 1, d.Length - 1) as IEnumerable<string>
                        )
                    )
                    .ToImmutableArray()
            ;

        var results =
                temporaryStringsInMemory
                    .ToDictionary(
                        k => k.wordKey,
                        l => l.wordList
                    )
            ;

        return results;
    }
}