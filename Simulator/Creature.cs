namespace Simulator;

public class Creature
{
    private string name="Unknown";
    private int level;
    public string Name 
    { 
        get { return name; } 
    }
    public int Level
    {
        get { return level; }
        set { level = value > 0 ? value : 1; }
    }
    public void SayHi()
    {
        Console.WriteLine($"Hi, I'm {name}, my level is {level}.");
    }
    public string Info
    {
        get { return $"{name} [{level}]"; }
    }
}
