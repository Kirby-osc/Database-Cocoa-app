using System;

using Foundation;
using AppKit;

namespace Koursach
{
    public partial class ProfileSheetController : NSViewController
    {
        #region Private Variables
        private String _profile="";
        #endregion

        #region Computed Properties
        public String Profile
        {
            get
            {
                return _profile;
            }
            set
            {
                _profile = value;
            }
        }
        #endregion

        #region Constructors
        public ProfileSheetController(bool isNew)
        {
            // Load the .xib file for the sheet
            NSBundle.LoadNib("ProfileSheet", this);

            CancelButton.Hidden = !isNew;
        }
        #endregion

        #region Public Methods
        public void ShowSheet(NSWindow inWindow)
        {
            NSApplication.SharedApplication.BeginSheet(window, inWindow);
        }

        public void CloseSheet()
        {
            NSApplication.SharedApplication.EndSheet(window);
            window.Close();
        }
        #endregion
        #region Override Methods
        public override void AwakeFromNib()
        {
            base.AwakeFromNib();

            // Set initial values
            ProfileField.StringValue = Profile;

            // Wireup events
            ProfileField.Changed += (sender, e) => {
                Profile = ProfileField.StringValue;
            };
        }
        #endregion

        #region Actions
        partial void CancelAction(NSObject sender)
        {
            RaiseSheetCanceled();
            CloseSheet();
        }
        partial void OkAction(NSObject sender)
        {

            RaiseSheetAccepted();
            CloseSheet();
        }
        #endregion
        #region Events
        public EventHandler SheetAccepted;

        internal void RaiseSheetAccepted()
        {
            if (this.SheetAccepted != null)
                this.SheetAccepted(this, EventArgs.Empty);
        }
        public EventHandler SheetCanceled;

        internal void RaiseSheetCanceled()
        {
            if (this.SheetCanceled != null)
                this.SheetCanceled(this, EventArgs.Empty);
        }
        #endregion
    }
}
