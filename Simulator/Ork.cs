namespace Simulator;

public class Orc : Creature
{
    private int _rage = 0;
    private int _huntcount = 0;

    public int Rage
    {
        get => _rage;
        init => _rage = Validator.Limiter(value, 0, 10); 
    }

    public Orc(string name = "Unknown Orc", int level = 1, int rage = 1) : base(name, level)
    {
        _rage = Validator.Limiter(rage, 0, 10);
    }

    public override int Power => 7 * Level + 3 * Rage;

    public void Hunt()
    {
        _huntcount++;
        if (_huntcount % 3 == 0)
        {
            if (_rage < 10)
            {
                _rage++;
            }
        }
    }
    public override string Info => $"{Name} [{Level}][{Rage}]";

    public override void SayHi() => Console.WriteLine($"Hi, I'm {Name}, my level is {Level}, my rage is {Rage}.");
}