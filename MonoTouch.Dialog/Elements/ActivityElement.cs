using System;
using CoreGraphics;

#if XAMCORE_2_0
using UIKit;
using CoreGraphics;
using Foundation;
#else
using UIKit;
using CoreGraphics;
using Foundation;
#endif

#if !XAMCORE_2_0
using nint = global::System.Int32;
using nuint = global::System.UInt32;
using nfloat = global::System.Single;

using CGSize = global::CGSize;
using CGPoint = global::CGPoint;
using CGRect = global::CGRect;
#endif


namespace MonoTouch.Dialog
{
	public class ActivityElement : Element {
		public ActivityElement () : base ("")
		{
		}

		UIActivityIndicatorView indicator;

		public bool Animating {
			get {
				return indicator.IsAnimating;
			}
			set {
				if (value)
					indicator.StartAnimating ();
				else
					indicator.StopAnimating ();
			}
		}

		static NSString ikey = new NSString ("ActivityElement");

		protected override NSString CellKey {
			get {
				return ikey;
			}
		}

		public override UITableViewCell GetCell (UITableView tv)
		{
			var cell = tv.DequeueReusableCell (CellKey);
			if (cell == null){
				cell = new UITableViewCell (UITableViewCellStyle.Default, CellKey);
			}

			indicator = new UIActivityIndicatorView (UIActivityIndicatorViewStyle.Gray);
			var sbounds = tv.Frame;
			var vbounds = indicator.Bounds;

			indicator.Frame = new CGRect((sbounds.Width-vbounds.Width)/2, 12, vbounds.Width, vbounds.Height);
			indicator.StartAnimating ();

			cell.Add (indicator);

			return cell;
		}

		protected override void Dispose (bool disposing)
		{
			if (disposing){
				if (indicator != null){
					indicator.Dispose ();
					indicator = null;
				}
			}
			base.Dispose (disposing);
		}
	}
}

