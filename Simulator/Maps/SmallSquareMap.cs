namespace Simulator.Maps;

public class SmallSquareMap : SmallMap
{

    public SmallSquareMap(int sizeX, int sizeY) : base(sizeX, sizeY) 
    {
        FNext = MoveLogic.WallNext;
        FNextDiagonal = MoveLogic.WallNextDiagonal;
    }
}
