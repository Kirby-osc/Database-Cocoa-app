using System;
using AppKit;
namespace Koursach
{
    public class MultiSportsmanORMDelegate : NSTableViewDelegate
    {
        #region Constants 
        private const string CellIdentifier = "OccCell";
        #endregion

        #region Private Variables
        private MultiSportsmanORMDataSource DataSource;
        #endregion

        #region Constructors
        public MultiSportsmanORMDelegate(MultiSportsmanORMDataSource dataSource)
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
                case "sportsman_id":
                    view.IntValue = DataSource.MultiSportsmen[(int)row].sportsman_id;
                    break;
                case "second_name":
                    view.StringValue = new String(DataSource.MultiSportsmen[(int)row].second_name);
                    break;
                case "name":
                    view.StringValue = new String(DataSource.MultiSportsmen[(int)row].name);
                    break;
                case "surrname":
                    view.StringValue = new String(DataSource.MultiSportsmen[(int)row].surrname);
                    break;
                case "sx":
                    view.StringValue = new String(DataSource.MultiSportsmen[(int)row].sx);
                    break;
                case "s_rank":
                    view.StringValue = new String(DataSource.MultiSportsmen[(int)row].s_rank);
                    break;
                case "count_award":
                    view.IntValue = DataSource.MultiSportsmen[(int)row].count_award;
                    break;
            }

            return view;
        }
        #endregion
    }
}
