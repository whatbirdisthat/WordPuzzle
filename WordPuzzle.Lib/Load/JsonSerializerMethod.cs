using System.Text.Json;

namespace WordPuzzle.Lib.Load;

public class JsonSerializerMethod : WordLoader
{
    public override IDictionary<uint, IEnumerable<string>> LoadWords()
    {
        return
            JsonSerializer
                .Deserialize<IDictionary<uint, IEnumerable<string>>>(
                    File.ReadAllText(
                        $"{WordsFilename}-dictionary"
                    )
                )!;
    }
}