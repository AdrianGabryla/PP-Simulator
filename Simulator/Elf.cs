namespace Simulator;

public class Elf : Creature
{
    private int _agility = 1;
    private int _singcount = 0;

    public Elf(string name = "Unknown Elf", int level = 1, int agility = 1) : base(name, level)
    {
        Agility = agility;
    }

    public int Agility
    {
        get => _agility;
        private set => _agility = Validator.Limiter(value, 0, 10);
    }

    public override int Power => 8 * Level + 2 * Agility;

    public void Sing()
    {
        _singcount++;
        if (_singcount % 3 == 0)
        {
            if (_agility < 10)
            {
                _agility++;
            }
        }
    }
    public override string Info => $"{Name} [{Level}][{Agility}]";

    public override string Greeting() => $"Hi, I'm {Name}, my level is {Level}, my agility is {Agility}.";
}
