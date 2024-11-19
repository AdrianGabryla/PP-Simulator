using Simulator;

namespace TestSimulator;

public class ValidatorTests
{
    [Theory]
    [InlineData(50, 0, 50, 50)]
    [InlineData(5, 10, 20, 10)]
    [InlineData(25, 10, 20, 20)]
    [InlineData(15, 10, 20, 15)]

    public void Limiter_ChecksCorrectReturnedValue(int value, int min, int max, int outcome)
    {
        var limiter = Validator.Limiter(value, min, max);
        Assert.Equal(limiter, outcome);
    }
    [Theory]
    [InlineData("123456", 9, 10, '#', "123456###")]
    [InlineData("short", 10, 15, '#', "Short#####")]
    [InlineData("perfect", 5, 10, '#', "Perfect")]
    [InlineData("toolongvalue", 5, 10, '#', "Toolongval")]
    [InlineData("   123", 6, 10, '#', "123###")]
    public void Shortener_ChecksCorrectReturnedValue(string value, int min, int max, char placeholder , string outcome)
    {
        var s = Validator.Shortener(value, min, max, placeholder);
        Assert.Equal(s, outcome);
    }

}
