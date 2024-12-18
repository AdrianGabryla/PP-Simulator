namespace Simulator.Maps;

public static class MoveLogic
{
    public static Point WallNext(Map m, Point p, Direction d)
    {
        Point nextPoint = p.Next(d);
        return m.Exist(nextPoint) ? nextPoint : p;

    }
    public static Point WallNextDiagonal(Map m, Point p, Direction d)
    {
        Point nextPoint = p.NextDiagonal(d);
        return m.Exist(nextPoint) ? nextPoint : p;
    }
}
