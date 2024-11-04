namespace Simulator;

public class Elf : Creature
{
    public Elf() : base() { }
    private int _agility = 0;
    private int SingCount = 0;
    public Elf(string name = "Unknown Elf", int level = 1, int agility = 1) : base(name, level)
    {
        Agility = agility;
    }

    public int Agility
    {
        get => _agility;
        private set => _agility = Math.Clamp(value, 0, 10);
    }
    public override int Power => 8 * Level + 2 * Agility;
    public void Sing()
    {
        SingCount++;
        if (SingCount % 3 == 0)
        {
            if (_agility < 10)
            {
                _agility++;
            }
        }

    }
    public override void SayHi() => Console.WriteLine($"Hi, I'm {Name}, my level is {Level}, my agility is {Agility}."
);
}