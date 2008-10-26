namespace BooGame.Interfaces
{
	/// <summary>
	/// Defines a game mode in the game. A game mode is used to define a
	/// basic functionality such as a main menu, currently playing, or
	/// even the save/load functionality.
	/// </summary>
	public interface IMode
	{
		#region Activation and Deactivation
		/// <summary>
		/// Called when the mode is brought to the top of the stack,
		/// either by adding or having the one above it popped.
		/// </summary>
		void Activate(bool isAdded);

		/// <summary>
		/// Called when a mode is no longer activated, either by having
		/// a mode pushed on top of it or having it removed from the list.
		/// </summary>
		void Deactivate(bool isRemoved);
		#endregion

		#region Rendering
		/// <summary>
		/// Renders this mode to the given context.
		/// </summary>
		void Render();
		#endregion

		#region Updating
		#endregion
	}
}
