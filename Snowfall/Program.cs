namespace Snowfall;

using NetCoreAudio;

public static class Program
{
    private const string PathToAudio = "Resources/Snowfall.mp3";
    private const int DelayInMilliseconds = 140;
    private static readonly Player Player = new ();
    private static readonly SnowflakesController SnowflakesController = new();
    private static readonly Snowdrift Snowdrift = new(5);

    public static void Main(string[] args)
    {
        Console.Clear();
        Player.PlaybackFinished += delegate { Player.Play(PathToAudio); };
        Player.Play(PathToAudio);

        while (!Console.KeyAvailable)
        {
            SnowflakesController.DrawSnowflakes();
            Snowdrift.Draw();
            Thread.Sleep(DelayInMilliseconds);
        }
        
        Player.Stop();
        Console.Clear();
    }
}