using System.IO;

using BooGame;

using MfGames.Numerics;
using MfGames.Scene2;
using MfGames.Scene2.Collections;
using MfGames.Scene2.Tao.OpenGL;

namespace BooGameExample
{
	public class GemsMode
		: SceneNodeMode
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="RectangleMode"/> class.
		/// </summary>
		public GemsMode()
		{
			// Create a list of gem images.
			SceneNodeLinkedList<float> nodes = new SceneNodeLinkedList<float>();
			RootSceneNode = nodes;

			// Create the blue gem.
			IImageKey imageKey = DevILImageLoader.Load(new FileInfo("Images/Gem Blue.png"));
			ImageNode<float> image = new ImageNode<float>(imageKey);
			image.Point = new Point2<float>(10, 10);
			nodes.Add(image);

			// Create the green gem.
			imageKey = DevILImageLoader.Load(new FileInfo("Images/Gem Green.png"));
			image = new ImageNode<float>(imageKey);
			image.Point = new Point2<float>(60, 90);
			nodes.Add(image);
		}
		#endregion Constructors
	}
}
