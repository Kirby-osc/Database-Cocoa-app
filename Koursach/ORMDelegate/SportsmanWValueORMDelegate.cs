using System;
using AppKit;
namespace Koursach
{
    public class SportsmanWValueORMDelegate : NSTableViewDelegate
    {
        #region Constants 
        private const string CellIdentifier = "OccCell";
        #endregion

        #region Private Variables
        private SportsmanWithValueORMDataSource DataSource;
        #endregion
        #region Constructors
        public SportsmanWValueORMDelegate()
        {
        }
        public SportsmanWValueORMDelegate(SportsmanWithValueORMDataSource dataSource)
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
                    view.IntValue = DataSource.SportsmenWValue[(int)row].sportsman_id;
                    break;
                case "second_name":
                    view.StringValue = new String(DataSource.SportsmenWValue[(int)row].second_name);
                    break;
                case "name":
                    view.StringValue = new String(DataSource.SportsmenWValue[(int)row].name);
                    break;
                case "surrname":
                    view.StringValue = new String(DataSource.SportsmenWValue[(int)row].surrname);
                    break;
                case "sx":
                    view.StringValue = new String(DataSource.SportsmenWValue[(int)row].sx);
                    break;
                case "s_rank":
                    view.StringValue = new String(DataSource.SportsmenWValue[(int)row].s_rank);
                    break;
                case "aw_type":
                    view.StringValue = new String(DataSource.SportsmenWValue[(int)row].aw_type);
                    break;
                case "profile":
                    view.StringValue = new String(DataSource.SportsmenWValue[(int)row].profile);
                    break;
            }

            return view;
        }
        #endregion
    }
}
