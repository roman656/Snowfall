namespace Snowfall;

public class Snowdrift
{
    private const char Symbol = ' ';
    private const ConsoleColor Color = ConsoleColor.White;
    private const double PIInDegrees = 180.0;
    private const double dA = Math.PI * 2.0 / 79.0;
    private readonly int _xMaxCoordinate = Console.BufferWidth;
    private readonly int _yMaxCoordinate = Console.BufferHeight;
    private readonly int _height;
    private readonly double _startAngle;

    public Snowdrift(int height, double startAngle = 0.0)
    {
        _height = height;
        _startAngle = ConvertDegreesToRadians(startAngle);
    }

    private static double ConvertDegreesToRadians(double degrees)
    {
        return degrees * Math.PI / PIInDegrees;
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

        Console.ResetColor();
    }
}