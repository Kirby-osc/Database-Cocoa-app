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
	[Register ("SportBuildingsSubviewController")]
	partial class SportBuildingsSubviewController
	{
		[Outlet]
		AppKit.NSTableView InfrastructureTable { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (InfrastructureTable != null) {
				InfrastructureTable.Dispose ();
				InfrastructureTable = null;
			}
		}
	}
}
