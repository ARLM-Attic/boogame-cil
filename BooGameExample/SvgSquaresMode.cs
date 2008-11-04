using System.Drawing;
using System.IO;

using BooGame;

using MfGames.Drawing;
using MfGames.Numerics;
using MfGames.Scene2.Collections;
using MfGames.Scene2.Images;
using MfGames.Scene2.Tao.OpenGL;
using MfGames.Svg;

namespace BooGameExample
{
	public class SvgSquaresMode
		: SceneNodeMode
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="RectangleMode"/> class.
		/// </summary>
		public SvgSquaresMode()
		{
			// Create a list of gem images.
			SceneNodeLinkedList<float> nodes = new SceneNodeLinkedList<float>();
			RootSceneNode = nodes;

			// Load the image into memory.
			int scale = 40;
			SvgImageLoader svgImageLoader = new SvgImageLoader();
			svgImageLoader.Scale = SvgImageLoader.CentimeterScale * scale;
			Bitmap bitmap = svgImageLoader.Load(new FileInfo("Images/1cm.svg"));
			IImageKey imageKey = SystemImageLoader.Load(bitmap);

			// Create squares across the board.
			for (int i = 0; i < 600 / (2 * scale); i++)
			{
				for (int j = 0; j < 440 / scale; j++)
				{
					ImageNode<float> image = new ImageNode<float>(imageKey);
					image.Point = new Point2<float>((j % 2) * scale + i * 2 * scale, j * scale);
					image.ImageKey = imageKey;

					if (i % 4 == 0)
						image.Tint = new Color<float>(1, 1, 0, 0);

					if (j % 4 == 0)
						image.Tint = new Color<float>(1, 0, 1, 0);

					nodes.Add(image);
				}
			}
		}
		#endregion Constructors

		#region Events
		/// <summary>
		/// Called when the resolution is changed.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="args">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		protected override void OnResolutionChanged(object sender, System.EventArgs args)
		{
			// Call the parent event.
			base.OnResolutionChanged(sender, args);

			// Load in the new image key.
			int scale = 40;
			SvgImageLoader svgImageLoader = new SvgImageLoader();
			svgImageLoader.Scale = SvgImageLoader.CentimeterScale * scale;
			Bitmap bitmap = svgImageLoader.Load(new FileInfo("Images/1cm.svg"));
			IImageKey imageKey = SystemImageLoader.Load(bitmap);

			// Set the new image key for all the nodes.
			foreach (ImageNode<float> imageNode in (SceneNodeLinkedList<float>) RootSceneNode)
				imageNode.ImageKey = imageKey;
		}
		#endregion Events
	}
}
