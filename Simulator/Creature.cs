using Simulator.Maps;

namespace Simulator;

public abstract class Creature : IMappable
{
    public Map? Map { get; private set; }
    public Point Position { get; private set; }
    
    public void InitMapAndPosition(Map map, Point position) { }


    private string name = "Unknown";
    public string Name
    {
        get => name;
        init => name = Validator.Shortener(value, 3, 25, '#');
    }

    private int level = 1;
    public int Level
    {
        get => level;
        private set => level = Validator.Limiter(value, 1, 10);
    }

    public Creature(string name, int level = 1)
    {
        Name = name;
        Level = level;
    }

    public Creature() { }
    public abstract string Greeting();
    public abstract int Power { get; }

    public void Upgrade()
    {
        Level = Validator.Limiter(level + 1, 1, 10);
    }

    public abstract string Info { get; }
    public override string ToString() => $"{GetType().Name.ToUpper()}: {Info}";

    public void Go(Direction direction)
    {
        if (Map == null) return;
        //Map.Next()
        //Map.Next() == Position - no movement

        //Map.Move()
        Point nextPosition = Map.Next(Position, direction);
        Map.Move((IMappable)this, Position, nextPosition);
        Position = nextPosition;
    }
}
