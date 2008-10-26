using System;

using BooGame;
using BooGame.Sdl;

using MfGames.Input;
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
			game.Modes.DefaultMode = new GemsMode();
			game.Fps = 25;

			// Set up the input commands.
			game.Input.AutoCollapseTokens = true;
			game.Input.Register(new Chain("ESCAPE"), OnQuit);
			game.Input.Register(new Chain("QUIT"), OnQuit);
			game.Input.Register(new Chain(new ChainLink("CONTROL", "x"), new ChainLink("CONTROL", "c")), OnQuit);

			// Execute the game.
			game.Run();
		}

		#region Input Processing
		/// <summary>
		/// Called when the QUIT input is used.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="args">The <see cref="MfGames.Input.ChainInputEventArgs"/> instance containing the event data.</param>
		private static void OnQuit(object sender, ChainInputEventArgs args)
		{
			Game.Instance.IsRunning = false;
		}
		#endregion
	}
}
