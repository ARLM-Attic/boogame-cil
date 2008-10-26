using System;
using BooGame.Interfaces;
using C5;

namespace BooGame
{
	/// <summary>
	/// Implements a list of modes that automatically updates the frame
	/// view as appropriate.
	/// </summary>
	public class ModeList
	{
		#region Mode Management
		private LinkedList<IMode> modes = new LinkedList<IMode>();
		private IMode defaultMode;

		/// <summary>
		/// Retrieves the currently selected mode.
		/// </summary>
		public IMode CurrentMode
		{
			get
			{
				// If we don't have a mode, automatically add the top one.
				if (modes.Count == 0)
					return defaultMode;

				// Return the top mode
				return modes[0];
			}
		}

		/// <summary>
		/// Gets or sets the default mode which is used if there are no other modes
		/// in the list.
		/// </summary>
		/// <value>The default mode.</value>
		public IMode DefaultMode
		{
			get { return defaultMode; }
			set { defaultMode = value; }
		}

		/// <summary>
		/// Pops off the first mode, deactivates it, and activates the next
		/// one.
		/// </summary>
		public void Pop()
		{
			// We don't bother if we have none
			if (modes.Count == 0)
				return;

			// Get the first one
			IMode mode = modes[0];
			mode.Deactivate(true);
			modes.RemoveFirst();

			// See if we have another. If we don't, then the next call
			// to CurrentMode will add one.
			if (modes.Count > 0)
				modes[0].Activate(false);
		}

		/// <summary>
		/// Pushes and activated a mode.
		/// </summary>
		/// <param name="mode"></param>
		public void Push(IMode mode)
		{
			// We can't handle nulls
			if (mode == null)
				throw new ArgumentNullException("mode");

			// See if we have a current mode
			if (modes.Count != 0)
				// Deactivate the mode
				CurrentMode.Deactivate(false);

			// Add it
			modes.Insert(0, mode);
			mode.Activate(true);
		}

		/// <summary>
		/// This pops off every element from the mode and sets a new one.
		/// </summary>
		/// <param name="mode"></param>
		public void Set(IMode mode)
		{
			// Remove everything
			while (modes.Count > 0)
				Pop();

			// Add this one
			Push(mode);
		}
		#endregion
	}
}
