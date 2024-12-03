using Simulator.Maps;
using System.Reflection.Emit;
using System.Xml.Linq;
namespace Simulator;
public class Animals : IMappable
{
    public Map? Map { get; private set; }
    public Point Position { get; set; }
    private string description = "Unknown";
    public string Description
    {
        get => description;
        init => description = Validator.Shortener(value, 3, 15, '#');
    }
    public virtual string Info => $"{Description} <{Size}>";
    public override string ToString()
    {
        return $"{GetType().Name.ToUpper()}: {Info}";
    }
    public int Size { get; set; } = 3;
    public virtual char Symbol => 'A';
    public Animals() { }
    public Animals(string description, int size)
    {
        Description = description;
        Size = size;
    }
    public virtual void Go(Direction direction)
    {
        if (Map == null)
            return;
        Point nextPosition = Map.Next(Position, direction);
        Map.Move((IMappable)this, Position, nextPosition);
        Position = nextPosition;
    }
    public void InitMapAndPosition(Map map, Point position)
    {
        Map = map;
        Position = position;
    }
}
