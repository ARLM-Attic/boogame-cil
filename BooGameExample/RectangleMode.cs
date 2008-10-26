using BooGame;

using MfGames.Numerics;
using MfGames.Scene2.Primitives;

namespace BooGameExample
{
	/// <summary>
	/// A simple overlapping rectangle mode.
	/// </summary>
	public class RectangleMode
		: SceneNodeMode
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="RectangleMode"/> class.
		/// </summary>
		public RectangleMode()
		{
			RootSceneNode = new RectangleShapeNode<float>()
			{
				Point = new Point2<float>(10, 10),
				Size = new Size2<float>(20, 20)
			};
		}
		#endregion Constructors
	}
}