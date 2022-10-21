namespace Snowfall;

public class SnowflakesController
{
    private readonly List<Snowflake> _snowflakes = new ();
    private int _wavesAmount = Console.BufferHeight;
    private int _currentWavesAmount = 0;

    public SnowflakesController()
    {
        for (var i = 0; i < 15; i++)
        {
            _snowflakes.Add(new Snowflake(Console.BufferWidth, Console.BufferHeight));
        }
    }

    public void MoveSnowflakes()
    {
        foreach (var snowflake in _snowflakes)
        {
            snowflake.Move();
        }
    }

    public void AddSnowflakes()
    {
        if (_wavesAmount > _currentWavesAmount)
        {
            _currentWavesAmount++;
            
            for (var i = 0; i < 15; i++)
            {
                _snowflakes.Add(new Snowflake(Console.BufferWidth, Console.BufferHeight));
            }
        }
    }
}