namespace WordPuzzle.Lib;

public class FrequencyModel
{
    public Dictionary<char, uint> CharFrequencies { get; } = new();
    public FrequencyModel(string word)
    {
        foreach (var eachChar in word)
        {
            if (!CharFrequencies.TryAdd(eachChar, 1))
            {
                CharFrequencies[eachChar]++;
            }
        }
    }
}