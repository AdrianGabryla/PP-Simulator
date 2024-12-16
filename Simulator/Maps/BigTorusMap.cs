
namespace Simulator.Maps;

public class BigTorusMap : BigMap
{
    private readonly int sizeX;
    private readonly int sizeY;
    public BigTorusMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        this.sizeX = sizeX;
        this.sizeY = sizeY;
    }


    public override Point Next(Point p, Direction d)
    {
        Point nextPoint = p.Next(d);
        int X1 = (nextPoint.X + sizeX) % sizeX;
        int Y1 = (nextPoint.Y + sizeY) % sizeY;

        return new Point(X1, Y1);
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        Point nextPoint = p.NextDiagonal(d);
        int X2 = (nextPoint.X + sizeX) % sizeX;
        int Y2 = (nextPoint.Y + sizeY) % sizeY;

        return new Point(X2, Y2);
    }
}
