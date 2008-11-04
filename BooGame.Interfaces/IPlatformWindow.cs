
using System;

namespace BooGame.Interfaces
{
	/// <summary>
	/// Control and retrieval about information from the single window provided by
	/// the platform.
	/// </summary>
	public interface IPlatformWindow
	{
		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="IPlatformWindow"/> is fullscreen.
		/// Setting this value will change it dynamically; to set more than one setting at once, use
		/// the Set function.
		/// </summary>
		/// <value><c>true</c> if fullscreen; otherwise, <c>false</c>.</value>
		bool Fullscreen { get; set; }

		/// <summary>
		/// Gets or sets the title this <see cref="IPlatformWindow"/>.
		/// Setting this value will change it dynamically; to set more than one setting at once, use
		/// the Set function.
		/// </summary>
		/// <value>The title.</value>
		string Title { get; set; }

		/// <summary>
		/// Gets or sets the resolution of the screen.
		/// </summary>
		/// <value>The resolution.</value>
		Resolution Resolution { get; set; }

		/// <summary>
		/// Gets or sets the resolution scale for the actual image.
		/// </summary>
		/// <value>The scale.</value>
		float Scale { get; set; }

		/// <summary>
		/// Sets the specified width, height, and fullscreen of the window at once. If the window
		/// has not been created, it will be with this function.
		/// </summary>
		/// <param name="resolution">The resolution.</param>
		/// <param name="scale">The scale.</param>
		/// <param name="fullscreen">if set to <c>true</c> then the window will be fullscreen.</param>
		/// <param name="title">The title.</param>
		void Configure(Resolution resolution, float scale, bool fullscreen, string title);

		#region Events
		/// <summary>
		/// Occurs when the resolution has been explicitly changed.
		/// </summary>
		event EventHandler ResolutionChanged;
		#endregion Events
	}
}
