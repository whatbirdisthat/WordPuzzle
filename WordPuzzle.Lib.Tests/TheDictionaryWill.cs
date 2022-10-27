using System.Text.RegularExpressions;

namespace WordPuzzle.Lib.Tests;

public class TheDictionaryWill
{
    [Fact]
    public void MatchInvalidCharacters()
    {
        Regex invalidChars = new Regex("[^a-z]");
        const string validString = "thisisok";
        const string invalidString = "this is not ok";

        invalidChars.IsMatch(validString).Should().BeFalse();
        invalidChars.IsMatch(invalidString).Should().BeTrue();
    }
    
    [Fact]
    public void LoadTheWords()
    {
        var englishWords = new EnglishWords();
        englishWords.Should().NotBeNull();
        englishWords.Count.Should().NotBeInRange(
            int.MinValue,
            0,
            "Words cannot be empty."
        );
        // _englishWords.Count.Should().Be(106179);
        englishWords.Count.Should().Be(106179);

        var expectedList = new List<string>()
        {
            "monoamino", "oinomania", "monomania", "oniomania"
        }.AsEnumerable();
        var actualList = "moonamain".Anagrams(englishWords);
        actualList.Should().BeEquivalentTo(expectedList);
    }
    [Fact]
    public void LoadTheWordsParallel()
    {
        var englishWordsParallel = new EnglishWordsParallel();
        englishWordsParallel.Should().NotBeNull();
        englishWordsParallel.Count.Should().NotBeInRange(
            int.MinValue,
            0,
            "Words cannot be empty."
        );
        
        // _englishWordsParallel.Count.Should().Be(106179);
        englishWordsParallel.Count.Should().Be(99482);
        var expectedList = new List<string>()
        {
            "monoamino", "oinomania", "monomania", "oniomania"
        }.AsEnumerable();

        var actualList = "moonamain".Anagrams(englishWordsParallel);
        actualList.Should().BeEquivalentTo(expectedList);
    }

}