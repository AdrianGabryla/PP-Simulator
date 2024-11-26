namespace Simulator.Maps;

public class SmallSquareMap : SmallMap
{

    public SmallSquareMap(int sizeX, int sizeY) : base(sizeX, sizeY) { }

    public override Point Next(Point p, Direction d)
    {
        Point nextPoint = p.Next(d);
        return Exist(nextPoint) ? nextPoint : p;

    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        Point nextPoint = p.NextDiagonal(d);
        return Exist(nextPoint) ? nextPoint : p;
    }
}
