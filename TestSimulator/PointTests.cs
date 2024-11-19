using Simulator;

namespace TestSimulator;

public class PointTests
{
    [Fact]

    public void Constructor_ValidPoints_ShouldSetPoints()
    {
        int x = 5; 
        int y = 5;
        var p = new Point(x, y);
        Assert.Equal(x, p.X);
        Assert.Equal(y, p.Y);
    }
    [Theory]
    [InlineData(5, 5, Direction.Up, 5, 6)]
    [InlineData(4, 12, Direction.Down, 4, 11)]
    [InlineData(7, 8, Direction.Left, 6, 8)]
    [InlineData(18, 10, Direction.Right, 19, 10)]
    public void Next_ShouldReturnCorrectNextPoint(int x, int y, Direction direction, int expectedX, int expectedY)
    {
        var p = new Point(x, y);
        var next = p.Next(direction);
        var nextpoint = new Point(expectedX, expectedY);
        Assert.Equal(nextpoint, next);
    }
    [Theory]
    [InlineData(5, 10, Direction.Up, 6, 11)]
    [InlineData(4, 12, Direction.Down, 3, 11)]
    [InlineData(7, 8, Direction.Left, 6, 9)]
    [InlineData(18, 10, Direction.Right, 19, 9)]
    public void NextDiagonal_ShouldReturnCorrectNextDiagonalPoint(int x, int y, Direction direction, int expectedX, int expectedY)
    {
        var p = new Point(x, y);
        var next = p.NextDiagonal(direction);
        var nextpoint = new Point(expectedX, expectedY);
        Assert.Equal(nextpoint, next);
    }
}
