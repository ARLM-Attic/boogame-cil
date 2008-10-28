using System;

using BooGame.Interfaces;

using MfGames.Time;

namespace BooGame
{
	/// <summary>
	/// Defines an base class for modes.
	/// </summary>
	public class Mode
		: IMode
	{
		#region Activation and Deactivation
		/// <summary>
		/// Called when the mode is brought to the top of the stack,
		/// either by adding or having the one above it popped.
		/// </summary>
		/// <param name="isAdded"></param>
		public virtual void Activate(bool isAdded)
		{
		}

		/// <summary>
		/// Called when a mode is no longer activated, either by having
		/// a mode pushed on top of it or having it removed from the list.
		/// </summary>
		/// <param name="isRemoved"></param>
		public virtual void Deactivate(bool isRemoved)
		{
		}
		#endregion Activation and Deactivation

		#region Rendering
		/// <summary>
		/// Renders this mode to the given context.
		/// </summary>
		public virtual void Render()
		{
		}
		#endregion

		#region Updating
		/// <summary>
		/// Fired when the game is updating the code.
		/// </summary>
		public event EventHandler<UpdateEventArgs> Updating;

		/// <summary>
		/// Updates the game mode with the given arguments.
		/// </summary>
		/// <param name="args">The <see cref="MfGames.Time.UpdateEventArgs"/> instance containing the event data.</param>
		public virtual void Update(UpdateEventArgs args)
		{
			// Fire an event to anyone listening to the mode.
			if (Updating != null)
				Updating(this, args);
		}
		#endregion
	}
}
