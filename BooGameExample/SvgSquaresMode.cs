using System;
using System.Drawing;
using System.IO;

using BooGame;

using MfGames.Drawing;
using MfGames.Numerics;
using MfGames.Scene2.Collections;
using MfGames.Scene2.Images;
using MfGames.Scene2.Svg;
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
			svgLoader = new SvgLoader(new FileInfo("Images/1cm.svg"));
			float screenScale = Platform.Instance.Window.Resolution.Height / 16f;
			svgLoader.Scale = screenScale * SvgImageLoader.Meter100px;
			TextureLoader textureLoader = new TextureLoader(svgLoader);

			// Create squares across the board.
			rows = (int) (440 / screenScale);
			columns = (int) (600 / (2 * screenScale));

			for (int i = 0; i < columns; i++)
			{
				for (int j = 0; j < rows; j++)
				{
					ImageNode<float> image = new ImageNode<float>(textureLoader);
					image.Point = new Point2<float>((j % 2) * screenScale + i * 2 * screenScale, j * screenScale);

					if (i % 4 == 0)
						image.Tint = new Color<float>(1, 1, 0, 0);

					if (j % 4 == 0)
						image.Tint = new Color<float>(1, 0, 1, 0);

					nodes.Add(image);
				}
			}
		}
		#endregion Constructors

		#region Nodes
		private readonly SvgLoader svgLoader;
		private int rows, columns;
		#endregion Nodes

		#region Events
		/// <summary>
		/// Called when the resolution is changed.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="args">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		protected override void OnResolutionChanged(object sender, EventArgs args)
		{
			// Call the parent's resolution change.
			base.OnResolutionChanged(sender, args);

			// Adjust the SVG loader.
			float screenScale = Platform.Instance.Window.Resolution.Height / 16f;
			svgLoader.Scale = screenScale * SvgImageLoader.Meter100px;

			// Create squares across the board.
			SceneNodeLinkedList<float> nodes = (SceneNodeLinkedList<float>) RootSceneNode;
			int k = 0;

			for (int i = 0; i < columns; i++)
			{
				for (int j = 0; j < rows; j++)
				{
					ImageNode<float> node = (ImageNode<float>) nodes[k];
					node.Point = new Point2<float>((j % 2) * screenScale + i * 2 * screenScale, j * screenScale);
					k++;
				}
			}
		}
		#endregion Events
	}
}
