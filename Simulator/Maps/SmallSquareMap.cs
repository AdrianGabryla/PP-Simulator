namespace Simulator.Maps;

public class SmallSquareMap : Map
{
    public int Size { get; }
    private Rectangle _bounds;
    public SmallSquareMap(int size)
    {
        if (size <5 || size > 20)
        {
            throw new ArgumentOutOfRangeException("Size of the map should be in range of 5 to 20.");
        }
        Size = size;
        _bounds = new Rectangle(0, 0, Size - 1, Size - 1);
    }
    public override bool Exist(Point p)
    {
        return _bounds.Contains(p);
    }

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
