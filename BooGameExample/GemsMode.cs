using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;

using BooGame;

using MfGames.Numerics;
using MfGames.Scene2;
using MfGames.Scene2.Collections;
using MfGames.Scene2.Tao.OpenGL;

using Svg;

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

			// Load the baby squid image
			SvgDocument svg = SvgDocument.Open("Images/Baby Squid.svg");
			Bitmap bitmap = new Bitmap(400, 400);
			SvgRenderer renderer = SvgRenderer.FromImage(bitmap);
			renderer.ScaleTransform(10, 10);
			renderer.TextRenderingHint = TextRenderingHint.AntiAlias;
			renderer.TextContrast = 1;
			renderer.PixelOffsetMode = PixelOffsetMode.Half;
			svg.Draw(renderer);
			renderer.Save();

			imageKey = SystemImageLoader.Load(bitmap);
			image = new ImageNode<float>(imageKey);
			image.Point = new Point2<float>(200, 10);
			nodes.Add(image);
		}
		#endregion Constructors
	}
}
