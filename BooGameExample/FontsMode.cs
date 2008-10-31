using System.IO;

using BooGame;

using MfGames.Drawing;
using MfGames.Numerics;
using MfGames.Scene2.Animation;
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
			textNode.Tint = new Color<float>(1.0f, 1.0f, 0.25f, 0.25f);
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

			// Set up the various text nodes
			int y = 10;
			CreateNode(font, nodes, 30, 350, y);

			y += 40;
			textNode = CreateNode(font, nodes, 30, 350, y);
			textNode.DrawableRenderAnimators.Add(
				new UnsteadyFlickerDrawableAnimation<float>()
				{
					OpacityScale = 0.2,
					TimeScale = 1,
				});
			Updating += textNode.OnUpdate;

			y += 40;
			textNode = CreateNode(font, nodes, 30, 350, y);
			textNode.DrawableRenderAnimators.Add(
				new DisappearingFlickerDrawableAnimation<float>());
			Updating += textNode.OnUpdate;

			y += 40;
			textNode = CreateNode(font, nodes, 30, 350, y);
			textNode.DrawableRenderAnimators.Add(
				new DisappearingFlickerDrawableAnimation<float>());
			textNode.DrawableRenderAnimators.Add(
				new UnsteadyFlickerDrawableAnimation<float>()
				{
					OpacityScale = 0.2,
					TimeScale = 1,
				});
			Updating += textNode.OnUpdate;
		}
		#endregion Constructors

		#region Node Creation
		/// <summary>
		/// Creates a text node with the given components.
		/// </summary>
		/// <param name="font">The font.</param>
		/// <param name="nodes">The nodes.</param>
		/// <param name="fontSize">Size of the font.</param>
		/// <param name="x">The x.</param>
		/// <param name="y">The y.</param>
		/// <returns></returns>
		private TextNode<float> CreateNode(
			IFontKey font,
			SceneNodeLinkedList<float> nodes,
			float fontSize,
			float x,
			float y)
		{
			TextNode<float> textNode = new TextNode<float>(font);
			textNode.Point = new Point2<float>(x, y);
			textNode.Text = "Hello, World!";
			textNode.FontSize = fontSize;
			nodes.Add(textNode);
			return textNode;
		}
		#endregion Node Creation
	}
}
