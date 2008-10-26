
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
		/// Gets or sets the height this <see cref="IPlatformWindow"/>.
		/// Setting this value will change it dynamically; to set more than one setting at once, use
		/// the Set function.
		/// </summary>
		/// <value>The height.</value>
		int Height { get; set; }

		/// <summary>
		/// Gets or sets the title this <see cref="IPlatformWindow"/>.
		/// Setting this value will change it dynamically; to set more than one setting at once, use
		/// the Set function.
		/// </summary>
		/// <value>The title.</value>
		string Title { get; set; }

		/// <summary>
		/// Gets or sets the width this <see cref="IPlatformWindow"/>.
		/// Setting this value will change it dynamically; to set more than one setting at once, use
		/// the Set function.
		/// </summary>
		/// <value>The width.</value>
		int Width { get; set; }

		/// <summary>
		/// Sets the specified width, height, and fullscreen of the window at once. If the window
		/// has not been created, it will be with this function.
		/// </summary>
		/// <param name="width">The width.</param>
		/// <param name="height">The height.</param>
		/// <param name="fullscreen">if set to <c>true</c> then the window will be fullscreen.</param>
		/// <param name="title">The title.</param>
		void Configure(int width, int height, bool fullscreen, string title);
	}
}
