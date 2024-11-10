﻿namespace Simulator;

public class Rectangle
{
    public readonly int X1;
    public readonly int Y1;
    public readonly int X2;
    public readonly int Y2;

    public Rectangle(int x1, int y1, int x2, int y2)
    {
        if (x1 == x2 || y1 == y2)
        {
            throw new ArgumentException("We dont want too skinny rectangle");

        }

        if (x1 > x2)
        {
            (x1, x2) = (x2, x1);
        }
        if (y1 > y2)
        {
            (y1, y2) = (y2, y1);
        }
        X1 = x1;
        Y1 = y1;
        X2 = x2;
        Y2 = y2;
    }
    public Rectangle(Point p1, Point p2) { this.X1 = p1.X; this.Y1 = p1.Y; this.X2 = p2.X; this.Y2 = p2.Y; }
    public bool Contains(Point point) 
        {
        return point.X >= X1 && point.Y >= Y1 && point.X <= X2 && point.Y <= Y2;
        }
    public override string ToString() => $"({X1}, {Y1}):({X2}, {Y2})";


}