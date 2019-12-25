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
	[Register ("SWTrainerSubviewController")]
	partial class SWTrainerSubviewController
	{
		[Outlet]
		AppKit.NSTableView SWTrainerTable { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (SWTrainerTable != null) {
				SWTrainerTable.Dispose ();
				SWTrainerTable = null;
			}
		}
	}
}
