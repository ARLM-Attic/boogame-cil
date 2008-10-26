using BooGame;
using BooGame.Sdl;

using MfGames.Numerics;

namespace BooGameExample
{
	/// <summary>
	/// Main entry into the example application.
	/// </summary>
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		static void Main()
		{
			// Set up logging.

			// Set up the BooGame platform.
			Platform.Instance = new SdlPlatform(false);
			Platform.Instance.Window.Configure(640, 480, false, "BooGame SDL Example");

			// Run the game loop, this will exit when the game as completed.
			Game game = new Game();
			game.Modes.DefaultMode = new RectangleMode();
			game.Fps = 25;
			game.Run();
		}
	}
}
