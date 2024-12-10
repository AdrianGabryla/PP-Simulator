namespace Simulator.Maps;

public abstract class SmallMap : Map
{

    private readonly List<IMappable>? [,] _fields;
    protected SmallMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        if (sizeX > 20) throw new ArgumentOutOfRangeException(nameof(sizeX), "Map too wide");
        if (sizeY > 20) throw new ArgumentOutOfRangeException(nameof(sizeY), "Map too high");
        _fields = new List<IMappable>?[sizeX, sizeY];
    }
    protected override List<IMappable>?[,] Fields => _fields;

}