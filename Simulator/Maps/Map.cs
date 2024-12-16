using System.Drawing;

namespace Simulator.Maps;

/// <summary>
/// Map of points.
/// </summary>
public abstract class Map
{
    public int SizeX { get; }
    public int SizeY { get; }
    private Rectangle _bounds;
    private Dictionary<Point, List<IMappable>> mappablesFields = new Dictionary<Point, List<IMappable>>();
    public void Add(IMappable mappable, Point point)
    {
        if (!Exist(point))
            throw new ArgumentException($"{point} is out of bounds.");
        if (!mappablesFields.ContainsKey(point))
        {
            mappablesFields[point] = new List<IMappable>();
        }
        mappablesFields[point].Add(mappable);
    }

    public void Remove(IMappable mappable, Point point)
    {
        if (mappablesFields.ContainsKey(point))
        {
            mappablesFields[point].Remove(mappable);
            if (mappablesFields[point].Count == 0)
            {
                mappablesFields.Remove(point);
            }
        }
    }
    public virtual void Move(IMappable mappable, Point from, Point to)
    {
        Remove(mappable, from);
        Add(mappable, to);
    }

    public List<IMappable> At(Point point)
    {
        if (mappablesFields.ContainsKey(point))
        {
            return mappablesFields[point];
        }
        return new List<IMappable>();
    }
    public List<IMappable> At(int x, int y)
    {
        return At(new Point(x, y));
    }

    public Map(int sizeX, int sizeY)
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
