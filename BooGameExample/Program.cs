using BooGame;
using BooGame.Interfaces;
using BooGame.Sdl;

using C5;

using MfGames.Input;

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
			Platform.Instance.Window.Configure(Resolution.Standard640x480, 1, false, "BooGame SDL Example");

			// Set up the game modes.
			modes.Add(new GemsMode());
			modes.Add(new FontsMode());
			modes.Add(new SvgSquaresMode());

			// Run the game loop, this will exit when the game as completed.
			game = new Game();
			modeIndex = modes.Count - 1;
			game.Modes.DefaultMode = modes[modeIndex];
			game.Resolutions.Add(Resolution.Standard640x480);
			game.Resolutions.Add(Resolution.Standard800x600);
			game.AddStandardResolutionBindings();
			game.Fps = 25;

			// Set up the input commands.
			game.Input.AutoCollapseTokens = true;
			game.Input.Register(new Chain("ESCAPE"), OnQuit);
			game.Input.Register(new Chain("QUIT"), OnQuit);
			game.Input.Register(new Chain(new ChainLink("CONTROL", "x"), new ChainLink("CONTROL", "c")), OnQuit);
			game.Input.InputDeactivated += OnInputDeactivated;

			// Execute the game.
			game.Run();
		}

		#region Game Properties
		private static Game game;
		private static int modeIndex = 0;
		private static readonly ArrayList<IMode> modes = new ArrayList<IMode>();
		#endregion Game Properties

		#region Input Processing
		/// <summary>
		/// Called when an input is deactivated (keyboard released).
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="args">The <see cref="MfGames.Input.InputEventArgs"/> instance containing the event data.</param>
		private static void OnInputDeactivated(object sender, InputEventArgs args)
		{
			if (args.Token == InputTokens.Comma)
			{
				modeIndex--;

				if (modeIndex < 0)
					modeIndex = modes.Count - 1;

				modeIndex = modeIndex % modes.Count;
				game.Modes.Set(modes[modeIndex]);
			}
			else if (args.Token == InputTokens.Period)
			{
				modeIndex++;

				if (modeIndex >= modes.Count)
					modeIndex = 0;

				modeIndex = modeIndex % modes.Count;
				game.Modes.Set(modes[modeIndex]);
			}
		}

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
