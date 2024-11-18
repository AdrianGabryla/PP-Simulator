namespace Simulator.Maps;

public class SmallTorusMap : Map
{
    public int Size { get; }
    private Rectangle _bounds;
    public SmallTorusMap(int size)
    {
        if (size < 5 || size > 20)
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
