namespace Simulator.Maps;

public class SmallTorusMap : SmallMap
{
    public SmallTorusMap(int sizeX, int sizeY) : base(sizeX, sizeY) { }

    public override Point Next(Point p, Direction d)
    {
        Point nextPoint = p.Next(d);
        int X1 = (nextPoint.X + Size) % Size;
        int Y1 = (nextPoint.Y + Size) % Size;

        return new Point(X1, Y1);
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        Point nextPoint = p.NextDiagonal(d);
        int X2 = (nextPoint.X + Size) % Size;
        int Y2 = (nextPoint.Y + Size) % Size;

        return new Point(X2, Y2);
    }
}
