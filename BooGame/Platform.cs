using BooGame.Interfaces;

namespace BooGame
{
	/// <summary>
	/// Singleton accessor for the currently installed platform.
	/// </summary>
	public static class Platform
	{
		#region Singleton
		private static IPlatform instance;

		/// <summary>
		/// Gets or sets the singleton instance for the entire platform.
		/// </summary>
		/// <value>The instance.</value>
		public static IPlatform Instance
		{
			get { return instance; }
			set { instance = value; }
		}
		#endregion Singleton
	}
}
