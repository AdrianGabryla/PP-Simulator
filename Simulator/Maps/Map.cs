﻿using System.Drawing;

namespace Simulator.Maps;

/// <summary>
/// Map of points.
/// </summary>
public abstract class Map
{
    public int SizeX { get; }
    public int SizeY { get; }
    protected abstract List<IMappable>?[,] Fields { get; }
    private Rectangle _bounds;

    public virtual void Add(IMappable mappable, Point point)
    {
        if (!Exist(point))
            throw new ArgumentException($"{point} is out of bounds.");
        Fields[point.X, point.Y] ??= new List<IMappable>();
        Fields[point.X, point.Y]?.Add(mappable);
    }

    public virtual void Remove(IMappable mappable, Point point)
    {
        if (Fields[point.X, point.Y] != null)
        {
            Fields[point.X, point.Y]?.Remove(mappable);
            if (Fields[point.X, point.Y]?.Count == 0)
                Fields[point.X, point.Y] = null;
        }
    }
    public virtual void Move(IMappable mappable, Point from, Point to)
    {
        Remove(mappable, from);
        Add(mappable, to);
    }

    public virtual List<IMappable> At(Point point)
    {
        return Fields[point.X, point.Y] ?? new List<IMappable>();
    }
    public virtual List<IMappable> At(int x, int y)
    {
        return At(new Point(x, y));
    }

    protected Map(int sizeX, int sizeY)
    {
        if (sizeX < 5 || sizeY < 5) throw new ArgumentOutOfRangeException(nameof(sizeX), "Map too small");
        SizeX = sizeX;
        SizeY = sizeY;
        _bounds = new Rectangle(0, 0, SizeX - 1, SizeY - 1);
    }

    /// <summary>
    /// Check if give point belongs to the map.
    /// </summary>
    /// <param name="p">Point to check.</param>
    /// <returns></returns>
    public virtual bool Exist(Point p) => _bounds.Contains(p);

    /// <summary>
    /// Next position to the point in a given direction.
    /// </summary>
    /// <param name="p">Starting point.</param>
    /// <param name="d">Direction.</param>
    /// <returns>Next point.</returns>
    public abstract Point Next(Point p, Direction d);

    /// <summary>
    /// Next diagonal position to the point in a given direction 
    /// rotated 45 degrees clockwise.
    /// </summary>
    /// <param name="p">Starting point.</param>
    /// <param name="d">Direction.</param>
    /// <returns>Next point.</returns>
    public abstract Point NextDiagonal(Point p, Direction d);


}
