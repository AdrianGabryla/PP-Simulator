namespace Simulator;

public abstract class Creature
{
    private string name = "Unknown";
    public string Name
    {
        get => name;
        init => name = Validator.Shortener(value, 3, 25);
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


    public string Go(Direction direction) => $"{name} goes {direction.ToString().ToLower()}.";

    public string[] Go(Direction[] directions)
    {
        string[] result = new string[directions.Length];

        for (int i = 0; i < directions.Length; i++)
        {
            result[i] = Go(directions[i]);
        }

        return result;
    }

    public string[] Go(string directions) => Go(DirectionParser.Parse(directions));

}
