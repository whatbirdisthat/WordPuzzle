namespace WordPuzzle.Lib.Tests;

public class TheFrequencyModelWill
{
    [Fact]
    public void BuildA1WhenWordIsA()
    {
        var expected = new FrequencyModel("");
        expected.CharFrequencies.Add('a', 1);

        var actual = "a".FrequencyModel();
        actual.Should().BeEquivalentTo(expected);
    }
}