using System;
using AppKit;
namespace Koursach
{
    public class SportsmanORMDelegate:NSTableViewDelegate
    {
        #region Constants 
        private const string CellIdentifier = "OccCell";
        #endregion

        #region Private Variables
        private SportsmanORMDataSource DataSource;
        #endregion
        #region Constructors
        public SportsmanORMDelegate()
        {
        }
        public SportsmanORMDelegate(SportsmanORMDataSource dataSource)
        {
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
                case "sportsman_id":
                    view.IntValue = DataSource.Sportsmen[(int)row].sportsman_id;
                    break;
                case "second_name":
                    view.StringValue = new String(DataSource.Sportsmen[(int)row].second_name);
                    break;
                case "name":
                    view.StringValue = new String(DataSource.Sportsmen[(int)row].name);
                    break;
                case "surrname":
                    view.StringValue = new String(DataSource.Sportsmen[(int)row].surrname);
                    break;
                case "sx":
                    view.StringValue = new String(DataSource.Sportsmen[(int)row].sx);
                    break;
                case "s_rank":
                    view.StringValue = new String(DataSource.Sportsmen[(int)row].s_rank);
                    break;
                case "org_name":
                    view.StringValue = new String(DataSource.Sportsmen[(int)row].org_name);
                    break;
                case "aw_type":
                    view.StringValue = new String(DataSource.Sportsmen[(int)row].aw_type);
                    break;
                case "profile":
                    view.StringValue = new String(DataSource.Sportsmen[(int)row].profile);
                    break;
                case "event_name":
                    view.StringValue = new String(DataSource.Sportsmen[(int)row].event_name);
                    break;
            }

            return view;
        }
        #endregion
    }
}
