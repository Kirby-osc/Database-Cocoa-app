using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;

namespace Koursach
{
    public partial class EventSubview : AppKit.NSView
    {
        #region Constructors

        // Called when created from unmanaged code
        public EventSubview(IntPtr handle) : base(handle)
        {
            Initialize();
        }

        // Called when created directly from a XIB file
        [Export("initWithCoder:")]
        public EventSubview(NSCoder coder) : base(coder)
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
