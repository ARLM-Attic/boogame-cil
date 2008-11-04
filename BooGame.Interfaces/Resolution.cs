using MfGames.Numerics;

namespace BooGame.Interfaces
{
	/// <summary>
	/// Represents a screen resolution for the game. This class also contains some selectors
	/// for common formats.
	/// </summary>
	public class Resolution
		: Size2<int>
	{
		#region Standard Resolutions
		public static readonly Resolution Standard640x480 = new Resolution(640, 480);
		public static readonly Resolution Standard800x600 = new Resolution(800, 600);
		public static readonly Resolution Standard1280x1024 = new Resolution(1280, 1024);

		public static readonly Resolution Standard1680x1050 = new Resolution(1680, 1050);
		#endregion Standard Resolutions

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="Resolution"/> class.
		/// </summary>
		/// <param name="width">The width.</param>
		/// <param name="height">The height.</param>
		public Resolution(int width, int height)
		{
			Width = width;
			Height = height;
		}
		#endregion Constructors
	}
}
