using System;
using AppKit;
namespace Koursach
{
    public class EventORMDelegate : NSTableViewDelegate
    {
        #region Constants 
        private const string CellIdentifier = "OccCell";
        #endregion

        #region Private Variables
        private EventORMDataSource DataSource;
        #endregion

        #region Constructors
        public EventORMDelegate(EventORMDataSource dataSource)
        {
            // Initialize
            this.DataSource = dataSource;
        }
        #endregion

        #region Override Methods
        public override NSView GetViewForItem(NSTableView tableView, NSTableColumn tableColumn, nint row)
        {
            // This pattern allows you reuse existing views when they are no-longer in use.
            // If the returned view is null, you instance up a new view
            // If a non-null view is returned, you modify it enough to reflect the new data
            NSTextField view = (NSTextField)tableView.MakeView(CellIdentifier, this);
            if (view == null)
            {
                view = new NSTextField();
                view.Identifier = CellIdentifier;
                view.BackgroundColor = NSColor.Clear;
                view.Bordered = false;
                view.Selectable = false;
                view.Editable = false;
            }

            // Setup view based on the column selected
            switch (tableColumn.Title)
            {
                case "org_name":
                    view.StringValue = new String(DataSource.Events[(int)row].org_name);
                    break;
                case "event_name":
                    view.StringValue = new String(DataSource.Events[(int)row].event_name);
                    break;
                case "event_date":
                    view.StringValue = new String(DataSource.Events[(int)row].event_date);
                    break;
                case "type":
                    view.StringValue = new String(DataSource.Events[(int)row].type);
                    break;
              
            }

            return view;
        }
        #endregion
    }
}
