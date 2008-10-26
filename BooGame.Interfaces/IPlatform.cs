
namespace BooGame.Interfaces
{
	/// <summary>
	/// Represents a platform, the library component that interfaces between
	/// BooGame and the operating system. Both GlfwPlatform and SdlPlatform
	/// are both examples of an IPlatform.
	/// </summary>
	public interface IPlatform
	{
		/// <summary>
		/// Gets the singleton window for the application.
		/// </summary>
		/// <value>The window.</value>
		IPlatformWindow Window { get; }

		/// <summary>
		/// Indicates to the platform to process any events.
		/// </summary>
		void ProcessEvents();

		/// <summary>
		/// Swaps the OpenGL buffers to display the results to the user.
		/// </summary>
		void SwapBuffers();
	}
}
