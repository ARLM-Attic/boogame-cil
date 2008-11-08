using System;

using BooGame.Interfaces;

using MfGames.Scene2.Tao.OpenGL;

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
		private Resolution resolution = Interfaces.Resolution.Standard640x480;
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
		/// Gets or sets the resolution of this <see cref="IPlatformWindow"/>.
		/// Setting this value will change it dynamically; to set more than one setting at once, use
		/// the Set function.
		/// </summary>
		/// <value>The resolution.</value>
		public Resolution Resolution
		{
			get
			{
				return resolution;
			}
			set
			{
				// We don't handle null values well.
				if (value == null)
					throw new Exception("Cannot assign a null resolution");

				// Don't do anything if we haven't changed.
				if (resolution == value)
					return;

				// Change the resolution.
				resolution = value;
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

			// Add the full screen flag if we have it.
			if (fullscreen)
				flags = flags | Tao.Sdl.Sdl.SDL_FULLSCREEN;

			// Create/update the video mode.
			Tao.Sdl.Sdl.SDL_SetVideoMode(resolution.Width, resolution.Height, depth, flags);
			Tao.Sdl.Sdl.SDL_WM_SetCaption(title, null);

			// Setup our screen
			Gl.glViewport(0, 0, resolution.Width, resolution.Height);
			Gl.glMatrixMode(Gl.GL_PROJECTION);
			Gl.glLoadIdentity();

			//Glu.gluOrtho2D(0, m_ScreenWidth, m_ScreenHeight, 0);
			Gl.glOrtho(0, resolution.Width, resolution.Height, 0, -100, 100);
			Gl.glMatrixMode(Gl.GL_MODELVIEW);

			// Set up some OpenGL expectations.
			Gl.glBlendFunc(Gl.GL_SRC_ALPHA, Gl.GL_ONE_MINUS_SRC_ALPHA);
			Gl.glEnable(Gl.GL_BLEND);

			// Dispose all the OpenGL textures since they are no longer valid.
			Texture.DisposeTextures();

			// Fire the event if appropriate.
			if (ResolutionChanged != null)
				ResolutionChanged(this, EventArgs.Empty);
		}

		/// <summary>
		/// Configures the window with the given values, then creates the window (or updates it if it
		/// already exists).
		/// </summary>
		/// <param name="newResolution">The new resolution.</param>
		/// <param name="newFullscreen">if set to <c>true</c> [new fullscreen].</param>
		/// <param name="newTitle">The new title.</param>
		public void Configure(Resolution newResolution, bool newFullscreen, string newTitle)
		{
			// Set all the internal values for the window.
			resolution = newResolution;
			fullscreen = newFullscreen;
			title = newTitle;

			// Configure the window.
			Configure();
		}
		#endregion

		#region Events
		/// <summary>
		/// Occurs when the resolution has been explicitly changed.
		/// </summary>
		public event EventHandler ResolutionChanged;
		#endregion Events
	}
}
