using System;

using Foundation;
using AppKit;

namespace Koursach
{
    public partial class EventSheetController : NSViewController
    {
        #region Private Variables
        private String _organizator = "";
        #endregion

        #region Computed Properties
        public String Organizator { get
            {
                return _organizator;
            }
            set
            {
                _organizator = value;
            }
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
            OrganizationField.StringValue = Organizator;

            // Wireup events
            OrganizationField.Changed += (sender, e) => {
                Organizator = OrganizationField.StringValue;
            };
        }
        #endregion
        #region Constructors
        public EventSheetController(bool isNew)
        {
            // Load the .xib file for the sheet
            NSBundle.LoadNib("EventSheet", this);

            CancelButton.Hidden = !isNew;
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
