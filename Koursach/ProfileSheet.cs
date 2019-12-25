using System;

using Foundation;
using AppKit;

namespace Koursach
{
    public partial class ProfileSheet : NSPanel
    {
        public ProfileSheet(IntPtr handle) : base(handle)
        {
        }

        [Export("initWithCoder:")]
        public ProfileSheet(NSCoder coder) : base(coder)
        {
        }

        public override void AwakeFromNib()
        {
            base.AwakeFromNib();
        }
    }
}
