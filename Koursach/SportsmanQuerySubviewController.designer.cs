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
	[Register ("SportsmanQuerySubviewController")]
	partial class SportsmanQuerySubviewController
	{
		[Outlet]
		AppKit.NSTableView SportsmanQueryTable { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (SportsmanQueryTable != null) {
				SportsmanQueryTable.Dispose ();
				SportsmanQueryTable = null;
			}
		}
	}
}
