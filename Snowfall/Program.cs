namespace Snowfall;

using NetCoreAudio;

public static class Program
{
    private const string PathToAudio = "Resources/Snow.mp3";
    private const int DelayInMilliseconds = 140;
    private static readonly Player Player = new ();
    private static readonly SnowflakesController SnowflakesController = new();

    public static void Main(string[] args)
    {
        Console.Clear();
        Player.PlaybackFinished += delegate { Player.Play(PathToAudio); };
        Player.Play(PathToAudio);
        
        while (!Console.KeyAvailable)
        {
            SnowflakesController.MoveSnowflakes();
            SnowflakesController.AddSnowflakes();
            Thread.Sleep(DelayInMilliseconds);
        }
        
        Player.Stop();
        Console.Clear();
    }
}