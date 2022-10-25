namespace WordPuzzle.Lib;

public class FrequencyModel
{
    public Dictionary<char, uint> CharFrequencies { get; } = new();

    public FrequencyModel(string word)
    {
        foreach (var eachChar in word)
        {
            if (CharFrequencies.ContainsKey(eachChar))
            {
                CharFrequencies[eachChar]++;
            }
            else
            {
                CharFrequencies.Add(eachChar, 1);
            }
        }
    }
}