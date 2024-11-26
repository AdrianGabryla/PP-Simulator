using Simulator;
using Simulator.Maps;

namespace TestSimulator;

public class SmallSquareMapTests
{
    [Fact]
    public void Constructor_ValidSize_ShouldSetSize()
    {
        int sizeX = 10;
        int sizeY = 10;
        var map = new SmallSquareMap(sizeX, sizeY);
        Assert.Equal(sizeX, map.SizeX);
        Assert.Equal(sizeY, map.SizeY);
    }

    [Theory]
    [InlineData(4, 4)]
    [InlineData(21, 21)]
    public void Constructor_InvalidSize_ShouldThrowArgumentOutOfRangeException(int sizeX, int sizeY)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new SmallSquareMap(sizeX, sizeY));
    }

    [Theory]
    [InlineData(3, 4, 5, 5, true)]
    [InlineData(6, 1, 5, 5, false)]
    [InlineData(19, 19, 20, 20, true)]
    [InlineData(20, 20, 20, 20, false)]
    public void Exist_ShouldReturnCorrectValue(int x, int y, int sizeX, int sizeY, bool expected)
    {
        var map = new SmallSquareMap(sizeX, sizeY);
        var point = new Point(x, y);
        var result = map.Exist(point);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(5, 10, Direction.Up, 5, 11)]
    [InlineData(4, 12, Direction.Down, 4, 11)]
    [InlineData(7, 8, Direction.Left, 6, 8)]
    [InlineData(18, 10, Direction.Right, 19, 10)]
    public void Next_ShouldReturnCorrectNextPoint(int x, int y, Direction direction, int expectedX, int expectedY)
    {
        var map = new SmallSquareMap(20, 20);
        var point = new Point(x, y);
        var nextPoint = map.Next(point, direction);
        Assert.Equal(new Point(expectedX, expectedY), nextPoint);
    }

    [Theory]
    [InlineData(5, 10, Direction.Up, 6, 11)]
    [InlineData(4, 12, Direction.Down, 3, 11)]
    [InlineData(7, 8, Direction.Left, 6, 9)]
    [InlineData(18, 10, Direction.Right, 19, 9)]
    public void NextDiagonal_ShouldReturnCorrectNextPoint(int x, int y, Direction direction, int expectedX, int expectedY)
    {
        var map = new SmallSquareMap(20, 20);
        var point = new Point(x, y);
        var nextPoint = map.NextDiagonal(point, direction);
        Assert.Equal(new Point(expectedX, expectedY), nextPoint);
    }
}
