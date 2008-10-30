using System.IO;

using BooGame;

using MfGames.Numerics;
using MfGames.Scene2.Collections;
using MfGames.Scene2.Fonts;
using MfGames.Scene2.Tao.OpenGL;

namespace BooGameExample
{
	/// <summary>
	/// Implements a font mode with various font effects.
	/// </summary>
	public class FontsMode
		: SceneNodeMode
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="FontsMode"/> class.
		/// </summary>
		public FontsMode()
		{
			// Create a list of gem images.
			SceneNodeLinkedList<float> nodes = new SceneNodeLinkedList<float>();
			RootSceneNode = nodes;

			// Create the basic font.
			IFontKey font = FtglFontLoader.Load(new FileInfo("Fonts/lilac.ttf"));
			TextNode<float> textNode = new TextNode<float>(font);
			textNode.Point = new Point2<float>(10, 10);
			textNode.Text = "Hello, World.";
			textNode.FontSize = 30;
			nodes.Add(textNode);

			// Create a larger version.
			font = FtglFontLoader.Load(new FileInfo("Fonts/carbon.ttf"));
			textNode = new TextNode<float>(font);
			textNode.Point = new Point2<float>(10, 50);
			textNode.Text = "13";
			textNode.FontSize = 110;
			nodes.Add(textNode);

			font = FtglFontLoader.Load(new FileInfo("Fonts/carbon.ttf"));
			textNode = new TextNode<float>(font);
			textNode.Point = new Point2<float>(90, 60);
			textNode.Text = "/";
			textNode.FontSize = 180;
			nodes.Add(textNode);

			font = FtglFontLoader.Load(new FileInfo("Fonts/carbon.ttf"));
			textNode = new TextNode<float>(font);
			textNode.Point = new Point2<float>(130, 160);
			textNode.Text = "23";
			textNode.FontSize = 110;
			nodes.Add(textNode);
		}
		#endregion Constructors
	}
}
