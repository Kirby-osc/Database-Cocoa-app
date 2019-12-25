// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace Koursach
{
	[Register ("ProfileSheetController")]
	partial class ProfileSheetController
	{
		[Outlet]
		AppKit.NSButton CancelButton { get; set; }

		[Outlet]
		AppKit.NSTextField ProfileField { get; set; }

		[Outlet]
		Koursach.ProfileSheet window { get; set; }

		[Action ("CancelAction:")]
		partial void CancelAction (Foundation.NSObject sender);

		[Action ("OkAction:")]
		partial void OkAction (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (ProfileField != null) {
				ProfileField.Dispose ();
				ProfileField = null;
			}

			if (CancelButton != null) {
				CancelButton.Dispose ();
				CancelButton = null;
			}

			if (window != null) {
				window.Dispose ();
				window = null;
			}
		}
	}
}
