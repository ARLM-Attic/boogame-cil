using BooGame.Interfaces;

using MfGames.Scene2;
using MfGames.Scene2.Tao.OpenGL;

namespace BooGame
{
	/// <summary>
	/// Defines a mode that uses the MfGames.Scene2 to render its contents.
	/// </summary>
	public class SceneNodeMode
		: IMode
	{
		#region IMode Members
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
		#endregion IMode Members

		#region Scene Graph
		private ISceneNode<float> rootSceneNode;

		/// <summary>
		/// Gets or sets the root scene node.
		/// </summary>
		/// <value>The root scene node.</value>
		public ISceneNode<float> RootSceneNode
		{
			get { return rootSceneNode; }
			set { rootSceneNode = value; }
		}
		#endregion Scene Graph

		#region Rendering
		/// <summary>
		/// Renders this mode to the given context.
		/// </summary>
		public void Render()
		{
			// If we don't have a root node, don't bother.
			if (rootSceneNode == null)
				return;

			// Create the OpenGL context for the scene graph.
			Renderer<float> renderer = new Renderer<float>();
			rootSceneNode.Render(renderer);
		}
		#endregion

		#region Updating
		#endregion
	}
}