namespace WordPuzzle.Lib.Tests;

public class TheDictionaryWill
{
    [Fact]
    public void LoadTheWords()
    {
        EnglishWords _englishWords = new EnglishWords();
        _englishWords.Should().NotBeNull();

        _englishWords.Count.Should().NotBeInRange(
            int.MinValue,
            0,
            "Dictionary cannot be empty."
        );

        var expectedList = new List<string>()
        {
            "monoamino", "oinomania", "monomania", "oniomania"
        }.AsEnumerable();

        var actualList = "moonamain".Anagrams(_englishWords);
        actualList.Should().BeEquivalentTo(expectedList);
    }
}