using Simulator;
using System.Security.Cryptography;

namespace TestSimulator;

public class RectangleTests
{
    [Fact]
    public void Constructor_ValidPoints_ShouldCreateRectangleWithPoints()
    {
        int x1 = 1;
        int y1 = 1;
        int x2 = 2;
        int y2 = 2;
        var rec = new Rectangle(x1, y1, x2, y2);
        Assert.Equal(x1, rec.X1);
        Assert.Equal(y1, rec.Y1);
        Assert.Equal(x2, rec.X2);
        Assert.Equal(y2, rec.Y2);
    }
    [Theory]
    [InlineData(1, 5, 1, 7)]
    [InlineData(10, 5, 15, 5)]
    public void Constructor_InvalidPoints_ShouldThrowException(int x1, int y1, int x2, int y2)
    {
        Assert.Throws<ArgumentException>(() => new Rectangle(x1, y1, x2, y2));
    }
    [Fact]
    public void Constructor_InvalidPoints_ShouldSwapPoints()
    {
        int x1 = 10, y1 = 15, x2 = 5, y2 = 10;
        var rec = new Rectangle(x1, y1, x2, y2);
        Assert.Equal(5, rec.X1);
        Assert.Equal(10, rec.Y1);
        Assert.Equal(10, rec.X2);
        Assert.Equal(15, rec.Y2);
    }
    [Fact]
    public void Constructor_ShouldCreateRectangleUsingPoints()
    {
        var p1 = new Point(0, 0);
        var p2 = new Point(10, 10);
        var rec = new Rectangle(p1, p2);
        Assert.Equal(0, rec.X1);
        Assert.Equal(0, rec.Y1);
        Assert.Equal(10, rec.X2);
        Assert.Equal(10, rec.Y2);
    }
    [Theory]
    [InlineData(0, 5, true)]
    [InlineData(21, 5, false)]
    public void Contains_PointsWithinRectangleRange(int x1, int y1, bool check)
    {
        var rec = new Rectangle(0, 0, 20, 20);
        var p = new Point(x1, y1);
        Assert.Equal(check, rec.Contains(p));
    }
}
