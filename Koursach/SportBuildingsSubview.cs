using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;

namespace Koursach
{
    public partial class SportBuildingsSubview : AppKit.NSView
    {
        #region Constructors

        // Called when created from unmanaged code
        public SportBuildingsSubview(IntPtr handle) : base(handle)
        {
            Initialize();
        }

        // Called when created directly from a XIB file
        [Export("initWithCoder:")]
        public SportBuildingsSubview(NSCoder coder) : base(coder)
        {
            Initialize();
        }

        // Shared initialization code
        void Initialize()
        {
        }

        #endregion
    }
}
