using BooGame.Interfaces;

using Tao.OpenGl;

namespace BooGame.Sdl
{
	/// <summary>
	/// Encapsulates the functionality of a SDL window.
	/// </summary>
	public class SdlWindow
		: IPlatformWindow
	{
		#region IPlatformWindow Members
		private bool fullscreen = false;
		private int width = 640;
		private int height = 480;
		private string title = "BooGame";

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="IPlatformWindow"/> is fullscreen.
		/// Setting this value will change it dynamically; to set more than one setting at once, use
		/// the Set function.
		/// </summary>
		/// <value><c>true</c> if fullscreen; otherwise, <c>false</c>.</value>
		public bool Fullscreen
		{
			get
			{
				return fullscreen;
			}
			set
			{
				fullscreen = value;
				Configure();
			}
		}

		/// <summary>
		/// Gets or sets the height this <see cref="IPlatformWindow"/>.
		/// Setting this value will change it dynamically; to set more than one setting at once, use
		/// the Set function.
		/// </summary>
		/// <value>The height.</value>
		public int Height
		{
			get
			{
				return height;
			}
			set
			{
				height = value;
				Configure();
			}
		}

		/// <summary>
		/// Gets or sets the title this <see cref="IPlatformWindow"/>.
		/// Setting this value will change it dynamically; to set more than one setting at once, use
		/// the Set function.
		/// </summary>
		/// <value>The title.</value>
		public string Title
		{
			get
			{
				return title;
			}
			set
			{
				title = value;
				Configure();
			}
		}

		/// <summary>
		/// Gets or sets the width this <see cref="IPlatformWindow"/>.
		/// Setting this value will change it dynamically; to set more than one setting at once, use
		/// the Set function.
		/// </summary>
		/// <value>The width.</value>
		public int Width
		{
			get
			{
				return width;
			}
			set
			{
				width = value;
				Configure();
			}
		}

		/// <summary>
		/// Configures (creates or updates) the singleton window.
		/// </summary>
		private void Configure()
		{
			// Set up the window elements.
			int flags =
				Tao.Sdl.Sdl.SDL_OPENGL |
				Tao.Sdl.Sdl.SDL_HWSURFACE |
				Tao.Sdl.Sdl.SDL_ANYFORMAT;
			int depth = 24;

			// Create/update the video mode.
			Tao.Sdl.Sdl.SDL_SetVideoMode(width, height, depth, flags);
			Tao.Sdl.Sdl.SDL_WM_SetCaption(title, null);

			// Setup our screen
			Gl.glViewport(0, 0, width, height);
			Gl.glMatrixMode(Gl.GL_PROJECTION);
			Gl.glLoadIdentity();

			//Glu.gluOrtho2D(0, m_ScreenWidth, m_ScreenHeight, 0);
			Gl.glOrtho(0, width, height, 0, -100, 100);
			Gl.glMatrixMode(Gl.GL_MODELVIEW);
		}

		/// <summary>
		/// Configures the window with the given values, then creates the window (or updates it if it
		/// already exists).
		/// </summary>
		/// <param name="newWidth">The new width.</param>
		/// <param name="newHeight">The new height.</param>
		/// <param name="newFullscreen">if set to <c>true</c> [new fullscreen].</param>
		/// <param name="newTitle">The new title.</param>
		public void Configure(int newWidth, int newHeight, bool newFullscreen, string newTitle)
		{
			// Set all the internal values for the window.
			width = newWidth;
			height = newHeight;
			fullscreen = newFullscreen;
			title = newTitle;

			// Configure the window.
			Configure();
		}
		#endregion
	}
}
