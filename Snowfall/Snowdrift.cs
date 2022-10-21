namespace Snowfall;

public class Snowdrift
{
    private const char Symbol = ' ';
    private const ConsoleColor Color = ConsoleColor.White;
    private const double PiInDegrees = 15.0;
    private const double dA = Math.PI * 2.0 / 210.0;
    private readonly int _xMaxCoordinate = Console.BufferWidth;
    private readonly int _yMaxCoordinate = Console.BufferHeight;
    private readonly int _height;
    private readonly double _startAngle;

    public Snowdrift(int height)
    {
        _height = height;
        _startAngle = ConvertDegreesToRadians(new Random().Next((int)(PiInDegrees)));
    }

    public void Draw()
    {
        var A = _startAngle;
        
        Console.BackgroundColor = Color;

        for (var x = 0; x < _xMaxCoordinate; x++, A += dA)
        {
            for (var y = (int)(_yMaxCoordinate - _height / 2.0 - Math.Sin(A) * _height / 2.0); y < _yMaxCoordinate; y++)
            {
                Console.SetCursorPosition(x, y);
                Console.Write(Symbol);
            }
        }
        
        for (var x = 0; x < _xMaxCoordinate; x++, A += dA)
        {
            for (var y = (int)(_yMaxCoordinate - _height / 5.0); y < _yMaxCoordinate; y++)
            {
                Console.SetCursorPosition(x, y);
                Console.Write(Symbol);
            }
        }

        Console.ResetColor();
    }
    
    private static double ConvertDegreesToRadians(double degrees) => degrees * Math.PI / PiInDegrees;
}