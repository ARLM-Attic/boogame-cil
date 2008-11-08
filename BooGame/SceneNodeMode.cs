using BooGame.Interfaces;

using MfGames.Scene2;
using MfGames.Scene2.Tao.OpenGL;

namespace BooGame
{
	/// <summary>
	/// Defines a mode that uses the MfGames.Scene2 to render its contents.
	/// </summary>
	public class SceneNodeMode
		: Mode
	{
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
		public override void Render()
		{
			// If we don't have a root node, don't bother.
			if (rootSceneNode == null)
				return;

			// Create the OpenGL context for the scene graph.
			Renderer<float> renderer = new Renderer<float>();
			rootSceneNode.PreRender(renderer);
			rootSceneNode.Render(renderer);
		}
		#endregion
	}
}