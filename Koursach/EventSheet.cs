using System;

using Foundation;
using AppKit;

namespace Koursach
{
    public partial class EventSheet : NSWindow
    {
        public EventSheet(IntPtr handle) : base(handle)
        {
        }

        [Export("initWithCoder:")]
        public EventSheet(NSCoder coder) : base(coder)
        {
        }

        public override void AwakeFromNib()
        {
            base.AwakeFromNib();
        }
    }
}
