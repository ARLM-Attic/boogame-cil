using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;

using BooGame;

using MfGames.Drawing;
using MfGames.Numerics;
using MfGames.Scene2;
using MfGames.Scene2.Animation;
using MfGames.Scene2.Collections;
using MfGames.Scene2.Images;
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
			BitmapLoader systemLoader = new BitmapLoader(new FileInfo("Images/Gem Blue.png"));
			TextureLoader textureLoader = new TextureLoader(systemLoader);
			ImageNode<float> image = new ImageNode<float>(textureLoader);
			image.Point = new Point2<float>(10, 10);
			image.DrawableRenderAnimators.Add(
				new DisappearingFlickerDrawableAnimation<float>());
			image.DrawableRenderAnimators.Add(
				new UnsteadyFlickerDrawableAnimation<float>()
				{
					OpacityScale = 0.2,
					TimeScale = 1,
				});
			Updating += image.OnUpdate;
			nodes.Add(image);

			// Create the green gem.
			systemLoader = new BitmapLoader(new FileInfo("Images/Gem Green.png"));
			textureLoader = new TextureLoader(systemLoader);
			image = new ImageNode<float>(textureLoader);
			image.Point = new Point2<float>(60, 90);
			nodes.Add(image);

			// Create the translucent orange.
			systemLoader = new BitmapLoader(new FileInfo("Images/Gem Orange.png"));
			textureLoader = new TextureLoader(systemLoader);
			image = new ImageNode<float>(textureLoader);
			image.Tint = new Color<float>(0.5f, 1f, 1f, 1f);
			image.Point = new Point2<float>(110, 10);
			nodes.Add(image);

			// Create an animated image.
			AnimatedImageNodeController<float> animatedController = new AnimatedImageNodeController<float>();
			animatedController.NeedImageKey += OnLoadImageKey;
			animatedController.Load(new FileInfo("Images/Gem Animation.xml"));
			AnimatedImageNode<float> animatedImage = new AnimatedImageNode<float>(animatedController);
			animatedImage.Point = new Point2<float>(10, 200);
			Updating += animatedImage.OnUpdate;
			nodes.Add(animatedImage);
		}
		#endregion Constructors

		#region Events
		/// <summary>
		/// Called when the load image key event is called.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="args">The <see cref="MfGames.Scene2.Images.LoadImageKeyEventArgs"/> instance containing the event data.</param>
		private void OnLoadImageKey(object sender, LoadImageKeyEventArgs args)
		{
			BitmapLoader systemLoader = new BitmapLoader(new FileInfo("Images/" + args.Path + ".png"));
			TextureLoader textureLoader = new TextureLoader(systemLoader);

			args.ImageKeyLoader = textureLoader;
		}
		#endregion Events
	}
}
