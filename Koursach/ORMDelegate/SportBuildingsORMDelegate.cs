using System;
using AppKit;
namespace Koursach
{
    public class SportBuildingsORMDelegate: NSTableViewDelegate
    {
        #region Constants 
        private const string CellIdentifier = "OccCell";
        #endregion

        #region Private Variables
        private SportBuildingsORMDataSource DataSource;
        #endregion

        #region Constructors
        public SportBuildingsORMDelegate(SportBuildingsORMDataSource dataSource)
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
                case "sbuild_id":
                    view.IntValue = DataSource.Infrastructures[(int)row].sbuild_id;
                    break;
                case "contact":
                    view.StringValue = new String(DataSource.Infrastructures[(int)row].contact);
                    break;
                case "type_title":
                    view.StringValue = new String(DataSource.Infrastructures[(int)row].type_title);
                    break;
                case "type_enterprise":
                    view.StringValue = new String(DataSource.Infrastructures[(int)row].type_enterprise);
                    break;
                case "count_of_seats":
                    view.IntValue = DataSource.Infrastructures[(int)row].count_of_seats;
                    break;
                case "type_of_cover":
                    view.StringValue = new String(DataSource.Infrastructures[(int)row].type_of_cover);
                    break;
                case "length":
                    view.FloatValue = DataSource.Infrastructures[(int)row].length;
                    break;
                case "count_of_equipment":
                    view.IntValue = DataSource.Infrastructures[(int)row].count_of_equipment;
                    break;

            }

            return view;
        }
        #endregion
    }
}
