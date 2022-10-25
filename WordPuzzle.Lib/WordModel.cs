namespace WordPuzzle.Lib;

public class WordModel : IComparable<WordModel>
{
    public uint WordKey { get; set; }

    public string Word { get; set; }

    public FrequencyModel FrequencyModel { get; set; }

    public int CompareTo(WordModel? other)
    {
        return other.Word.GetHashCode() > this.Word.GetHashCode() ? 1 : -1;
    }
}