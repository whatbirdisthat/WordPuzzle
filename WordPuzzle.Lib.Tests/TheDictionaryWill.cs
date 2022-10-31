using System.Text.RegularExpressions;
using WordPuzzle.Lib.Load;
using WordPuzzle.Lib.Query;
using WordPuzzle.Lib.Repository;

namespace WordPuzzle.Lib.Tests;

public class TheDictionaryWill
{
    [Fact]
    public void MatchInvalidCharacters()
    {
        var invalidChars = new Regex("[^a-z]");
        const string validString = "thisisok";
        const string invalidString = "this is not ok";

        invalidChars.IsMatch(validString).Should().BeFalse();
        invalidChars.IsMatch(invalidString).Should().BeTrue();
    }
    
    [Fact]
    public void LoadTheWordsJsonSerializerMethod()
    {
        var englishWords = new WordModelRepository<JsonSerializerMethod, ProperSubset>();
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
    public void LoadTheWordsCollectionsMethod()
    {
        var englishWordsParallel = new WordModelRepository<CollectionsMethod, ProperSubset>();

        englishWordsParallel.Should().NotBeNull();
        englishWordsParallel.Count.Should().NotBeInRange(
            int.MinValue,
            0,
            "Words cannot be empty."
        );
        
        englishWordsParallel.Count.Should().Be(106179);
        // englishWordsParallel.Count.Should().Be(99482);
        var expectedList = new List<string>()
        {
            "monoamino", "oinomania", "monomania", "oniomania"
        }.AsEnumerable();

        var actualList = "moonamain".Anagrams(englishWordsParallel);
        actualList.Should().BeEquivalentTo(expectedList);
    }
    
    [Fact]
    public void LoadTheWordsInlineMethod()
    {
        var englishWordsParallel = new WordModelRepository<InlineMethod, ProperSubset>();

        englishWordsParallel.Should().NotBeNull();
        englishWordsParallel.Count.Should().NotBeInRange(
            int.MinValue,
            0,
            "Words cannot be empty."
        );
        
        englishWordsParallel.Count.Should().Be(106179);
        // englishWordsParallel.Count.Should().Be(99482);
        var expectedList = new List<string>()
        {
            "monoamino", "oinomania", "monomania", "oniomania"
        }.AsEnumerable();

        var actualList = "moonamain".Anagrams(englishWordsParallel);
        actualList.Should().BeEquivalentTo(expectedList);
    }
    
    [Fact]
    public void LoadTheWordsImmutableMethod()
    {
        var englishWordsParallel = new WordModelRepository<ImmutableMethod, ProperSubset>();

        englishWordsParallel.Should().NotBeNull();
        englishWordsParallel.Count.Should().NotBeInRange(
            int.MinValue,
            0,
            "Words cannot be empty."
        );
        
        englishWordsParallel.Count.Should().Be(106179);
        // englishWordsParallel.Count.Should().Be(99482);
        var expectedList = new List<string>()
        {
            "monoamino", "oinomania", "monomania", "oniomania"
        }.AsEnumerable();

        var actualList = "moonamain".Anagrams(englishWordsParallel);
        actualList.Should().BeEquivalentTo(expectedList);
    }

}