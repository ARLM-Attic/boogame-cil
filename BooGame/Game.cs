using System;
using System.Threading;
using BooGame.Interfaces;
using MfGames.Input;
using MfGames.Scene2;
using MfGames.Scene2.Tao.OpenGL;
using MfGames.Time;

using Tao.OpenGl;

namespace BooGame
{
	/// <summary>
	/// Primary game management application. This handles the various game modes,
	/// platform interaction, and basically performs the event processing of the game.
	/// </summary>
	public class Game
	{
		#region Singleton
		private static Game instance;

		/// <summary>
		/// Gets or sets the singleton game instance.
		/// </summary>
		/// <value>The instance.</value>
		public static Game Instance
		{
			get { return instance; }
			set { instance = value; }
		}
		#endregion Singleton

		#region Game Properties
		private bool isRunning = true;
		private int sleepMilliseconds = 0;

		/// <summary>
		/// Gets or sets the frames per second (FPS).
		/// </summary>
		/// <value>The FPS.</value>
		public double Fps
		{
			get { return 1000.0 / sleepMilliseconds; }
			set
			{
				// Don't allow negative values.
				if (value < 0)
					throw new Exception("Cannot set a negative frames per second");

				// If we are zero, just set it to zero, otherwise calculate it.
				if (value == 0)
					sleepMilliseconds = 0;
				else
					sleepMilliseconds = (int) (1000.0 / value);
			}
		}

		/// <summary>
		/// Gets or sets a value indicating whether this instance is running.
		/// </summary>
		/// <value>
		/// 	<c>true</c> if this instance is running; otherwise, <c>false</c>.
		/// </value>
		public bool IsRunning
		{
			get { return isRunning; }
			set { isRunning = value; }
		}

		/// <summary>
		/// Gets or sets the number of milliseconds the game will attempt to perform a single
		/// round of update and render. It will sleep for an appropriate time in an attempt to
		/// maintain this rate.
		/// </summary>
		/// <value>The sleep milliseconds.</value>
		public int SleepMilliseconds
		{
			get { return sleepMilliseconds; }
			set { sleepMilliseconds = value; }
		}
		#endregion Game Properties

		#region Execution
		/// <summary>
		/// Runs this instance of the game. This assumes the platform is properly
		/// configured before execution.
		/// </summary>
		public virtual void Run()
		{
			// Check the platform.
			if (Platform.Instance == null)
				throw new Exception("Platform.Instance has not been properly configured.");

			IPlatform platform = Platform.Instance;

			// Put ourself in the singleton.
			if (Instance != null && Instance != this)
				throw new Exception("Cannot start game with Game.Instance set to another value.");

			Instance = this;

			// Set up some OpenGL expectations.
			Gl.glBlendFunc(Gl.GL_SRC_ALPHA, Gl.GL_ONE_MINUS_SRC_ALPHA);
			Gl.glEnable(Gl.GL_BLEND);

			// Loop through the system forever, sleeping as appropriate, until the IsRunning flag
			// is changed.
			while (isRunning)
			{
				// Give the dispose and cache manager an attempt to clean up memory.
				DisposeManager.Instance.DisposedManaged();

				// Poll the events from the platform.
				platform.ProcessEvents();

				// Update the game's state.
				Update();

				// Render out the game data to the OpenGL context.
				Render();

				// Draw the buffer to the screen.
				platform.SwapBuffers();

				// See if we need to sleep (for frame-limiting).
				if (sleepMilliseconds > 0)
				{
					// Sleep for an appropriate amount to try maintaining the framerate.
					// TODO Need a better sleep processing.
					Thread.Sleep(sleepMilliseconds);
				}
			}

			// TODO Call the shutdown event.

			// Clean up memory and run a final dispose.
			Texture.DisposeTextures();
			DisposeManager.Instance.DisposedManaged();
		}
		#endregion Execution

		#region Input
		private readonly ChainInputManager inputManager = new ChainInputManager();

		/// <summary>
		/// Gets or sets the input manager used for keyboard and mouse inputs.
		/// </summary>
		/// <value>The input.</value>
		public ChainInputManager Input
		{
			get { return inputManager; }
		}
		#endregion

		#region Rendering
		/// <summary>
		/// Renders this game's instance.
		/// </summary>
		protected virtual void Render()
		{
			// Clear the screen.
			Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);

			// Render the game mode if required
			IMode currentMode = Modes.CurrentMode;

			if (currentMode != null)
				currentMode.Render();
		}
		#endregion Rendering

		#region Updating
		private long lastTick = DateTime.Now.Ticks;

		/// <summary>
		/// Fired when the game is updating the code.
		/// </summary>
		public EventHandler<UpdateEventArgs> Updating;

		/// <summary>
		/// Updates the game state for rendering.
		/// </summary>
		protected virtual void Update()
		{
			// Figure out how many ticks since the last update.
			long currentTicks = DateTime.Now.Ticks;
			long difference = currentTicks - lastTick;
			lastTick = currentTicks;

			// Create the event arguments for the update.
			UpdateEventArgs args = new UpdateEventArgs();
			args.ElapsedTicks = difference;

			// Fire the event to anyone listening directly to the game.
			if (Updating != null)
				Updating(this, args);

			// Fire to the current mode.
			Modes.CurrentMode.Update(args);
		}
		#endregion Updatings

		#region Modes
		private readonly ModeList modeList = new ModeList();

		/// <summary>
		/// Gets the sorted list of game modes.
		/// </summary>
		/// <value>The modes.</value>
		public ModeList Modes
		{
			get { return modeList; }
		}
		#endregion
	}
}
