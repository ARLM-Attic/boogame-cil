using BooGame.Interfaces;

namespace BooGame.Sdl
{
	/// <summary>
	/// The SDL platform to interface between the operating system and
	/// the rest of BooGame.
	/// </summary>
	public class SdlPlatform
		: IPlatform
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="SdlPlatform"/> class.
		/// </summary>
		public SdlPlatform()
			: this(true)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="SdlPlatform"/> class.
		/// </summary>
		/// <param name="initializeAudio">if set to <c>true</c> [initialize audio].</param>
		public SdlPlatform(bool initializeAudio)
		{
			// Initalize the entire system.
			uint flags = Tao.Sdl.Sdl.SDL_INIT_VIDEO;

			if (initializeAudio)
				flags |= Tao.Sdl.Sdl.SDL_INIT_AUDIO;

			Tao.Sdl.Sdl.SDL_Init(flags);

			// Set up the internal SDL elements.
			Tao.Sdl.Sdl.SDL_GL_SetAttribute(Tao.Sdl.Sdl.SDL_GL_DOUBLEBUFFER, 1);
			Tao.Sdl.Sdl.SDL_GL_SetAttribute(Tao.Sdl.Sdl.SDL_GL_RED_SIZE, 8);
			Tao.Sdl.Sdl.SDL_GL_SetAttribute(Tao.Sdl.Sdl.SDL_GL_GREEN_SIZE, 8);
			Tao.Sdl.Sdl.SDL_GL_SetAttribute(Tao.Sdl.Sdl.SDL_GL_BLUE_SIZE, 8);
			Tao.Sdl.Sdl.SDL_GL_SetAttribute(Tao.Sdl.Sdl.SDL_GL_ALPHA_SIZE, 8);
		}
		#endregion Constructors

		#region IPlatform Members
		private readonly SdlWindow window = new SdlWindow();

		/// <summary>
		/// Gets the singleton window for the application.
		/// </summary>
		/// <value>The window.</value>
		public IPlatformWindow Window
		{
			get { return window; }
		}

		/// <summary>
		/// Processes any SDL events that have accumulated.
		/// </summary>
		public void ProcessEvents()
		{
			// Loop through all the accumulated events.
			Tao.Sdl.Sdl.SDL_Event ev;

			while (Tao.Sdl.Sdl.SDL_PollEvent(out ev) != 0)
			{
				// Figure out what to do based on the event type
				switch (ev.type)
				{
					case Tao.Sdl.Sdl.SDL_QUIT:
						// Inject the QUIT input into the system to allow it to handle
						// the input in a standard manner.
						Game.Instance.Input.TriggerInput("QUIT");
						break;

					case Tao.Sdl.Sdl.SDL_KEYDOWN:
						string downToken = SdlInputs.MapInput(ev.key.keysym);

						if (downToken != null)
							Game.Instance.Input.ActivateInput(downToken);

						break;

					case Tao.Sdl.Sdl.SDL_KEYUP:
						string upToken = SdlInputs.MapInput(ev.key.keysym);

						if (upToken != null)
							Game.Instance.Input.DeactivateInput(upToken);

						break;
				}
			}
		}

		/// <summary>
		/// Swaps the OpenGL buffers to display the results to the user.
		/// </summary>
		public void SwapBuffers()
		{
			Tao.Sdl.Sdl.SDL_GL_SwapBuffers();
		}
		#endregion
	}
}
