namespace Snowfall;

public class Snowflake
{
    private const char Symbol = '*';
    private const char EmptySpaceSymbol = ' ';
    private FallDirectionEnum _fallDirection;
    private readonly int _xMaxCoordinate;
    private readonly int _yMaxCoordinate;
    private int _x;
    private int _y;

    public Snowflake(int xMaxCoordinate, int yMaxCoordinate)
    {
        _xMaxCoordinate = xMaxCoordinate;
        _yMaxCoordinate = yMaxCoordinate;
        Initialize();
    }

    private void Initialize()
    {
        _fallDirection = new Random().Next(2) == 1 ? FallDirectionEnum.Right : FallDirectionEnum.Left;
        _x = new Random().Next(_xMaxCoordinate) + 1;
        _y = 0;
    }

    private void ErasePreviousMove()
    {
        Console.SetCursorPosition(_x, _y);
        Console.Write(EmptySpaceSymbol);
    }

    public void Move()
    {
        ErasePreviousMove();
        
        if (_y >= _yMaxCoordinate - 1)
        {
            _y = 0;
            _x = new Random().Next(_xMaxCoordinate) + 1;
        }
        else
        {
            _y++;
        }

        if (_fallDirection == FallDirectionEnum.Right)
        {
            _x++;
            _fallDirection = FallDirectionEnum.Left;
        }
        else
        {
            _x--;
            _fallDirection = FallDirectionEnum.Right;
        }
        
        Console.SetCursorPosition(_x, _y);
        Console.Write(Symbol);
    }
}