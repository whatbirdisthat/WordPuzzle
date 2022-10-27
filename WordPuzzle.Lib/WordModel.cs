namespace WordPuzzle.Lib;

public class WordModel : IComparable<WordModel>
{
    public WordModel(string word)
    {
        Word = word;
        WordKey = word.WordKey();
        FrequencyModel = word.FrequencyModel();
    }

    public uint WordKey { get; set; }

    public string Word { get; set; }

    public FrequencyModel FrequencyModel { get; set; }

    public int CompareTo(WordModel? other)
    {
        return other == null || other.Word.GetHashCode() < Word.GetHashCode() ? -1 : 1;
    }
}