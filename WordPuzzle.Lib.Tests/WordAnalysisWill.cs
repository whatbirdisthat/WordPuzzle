namespace WordPuzzle.Lib.Tests;

public class WordAnalysisWill
{
    [Fact]
    public void WhenWordIsEmptyThenReturn0()
    {
        const uint expected = 0;
        const string expectedBinary = "0";
        
        var actual = "".WordKey();

        actual.Should().Be(expected);
        var actualBinary = Convert.ToString(actual, 2);
        actualBinary.Should().Be(expectedBinary);
    }
    
    [Fact]
    public void WhenWordIsAThenReturn1()
    {
        const uint expected = 1;
        const string expectedBinary = "1";
        
        var actual = "a".WordKey();

        actual.Should().Be(expected);
        var actualBinary = Convert.ToString(actual, 2);
        actualBinary.Should().Be(expectedBinary);
    }
    [Fact]
    public void WhenWordIsAaThenReturn1()
    {
        const uint expected = 1;
        const string expectedBinary = "1";
        
        var actual = "aa".WordKey();

        actual.Should().Be(expected);
        var actualBinary = Convert.ToString(actual, 2);
        actualBinary.Should().Be(expectedBinary);
    }
    [Fact]
    public void WhenWordIsBThenReturn2()
    {
        const uint expected = 2;
        const string expectedBinary = "10";
        
        var actual = "b".WordKey();

        actual.Should().Be(expected);
        var actualBinary = Convert.ToString(actual, 2);
        actualBinary.Should().Be(expectedBinary);
    }
    [Fact]
    public void WhenWordIsAbThenReturn3()
    {
        const uint expected = 3;
        const string expectedBinary = "11";

        var actual = "ab".WordKey();

        actual.Should().Be(expected);
        var actualBinary = Convert.ToString(actual, 2);
        actualBinary.Should().Be(expectedBinary);
    }

    [Fact]
    public void WhenWordIsCThenReturn4()
    {
        const uint expected = 4;
        const string expectedBinary = "100";

        var actual = "c".WordKey();

        actual.Should().Be(expected);
        var actualBinary = Convert.ToString(actual, 2);
        actualBinary.Should().Be(expectedBinary);
    }

    [Fact]
    public void WhenWordIsAcThenReturn5()
    {
        const uint expected = 5;
        const string expectedBinary = "101";

        var actual = "ac".WordKey();

        actual.Should().Be(expected);
        var actualBinary = Convert.ToString(actual, 2);
        actualBinary.Should().Be(expectedBinary);
    }

    [Fact]
    public void WhenWordIsAbcThenReturn7()
    {
        const uint expected = 7;
        const string expectedBinary = "111";

        var actual = "abc".WordKey();

        actual.Should().Be(expected);
        var actualBinary = Convert.ToString(actual, 2);
        actualBinary.Should().Be(expectedBinary);
    }

}