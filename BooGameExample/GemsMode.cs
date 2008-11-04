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
			IImageKey imageKey = DevILImageLoader.Load(new FileInfo("Images/Gem Blue.png"));
			ImageNode<float> image = new ImageNode<float>(imageKey);
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
			imageKey = SystemImageLoader.Load(new FileInfo("Images/Gem Green.png"));
			image = new ImageNode<float>(imageKey);
			image.Point = new Point2<float>(60, 90);
			nodes.Add(image);

			// Create the translucent orange.
			imageKey = SystemImageLoader.Load(new FileInfo("Images/Gem Orange.png"));
			image = new ImageNode<float>(imageKey);
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
			args.ImageKey = SystemImageLoader.Load(new FileInfo("Images/" + args.Path + ".png"));
		}

		/// <summary>
		/// Called when the resolution is changed.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="args">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		protected override void OnResolutionChanged(object sender, System.EventArgs args)
		{
			// Call the parent verion's.
			base.OnResolutionChanged(sender, args);

			// Reload all the image keys for this mode.
			SceneNodeLinkedList<float> nodes = (SceneNodeLinkedList<float>) RootSceneNode;
			IImageKey imageKey = DevILImageLoader.Load(new FileInfo("Images/Gem Blue.png"));
			((ImageNode<float>) nodes[0]).ImageKey = imageKey;

			// Create the green gem.
			imageKey = SystemImageLoader.Load(new FileInfo("Images/Gem Green.png"));
			((ImageNode<float>) nodes[1]).ImageKey = imageKey;

			// Create the translucent orange.
			imageKey = SystemImageLoader.Load(new FileInfo("Images/Gem Orange.png"));
			((ImageNode<float>) nodes[2]).ImageKey = imageKey;

			// Create an animated image.
			((AnimatedImageNode<float>) nodes[3]).Controller.ReloadImageKeys();
		}
		#endregion Events
	}
}
