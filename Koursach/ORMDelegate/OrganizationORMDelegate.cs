    using System;
using AppKit;
namespace Koursach
{
    public class OrganizationORMDelegate : NSTableViewDelegate
    {
        #region Constants 
        private const string CellIdentifier = "OccCell";
        #endregion

        #region Private Variables
        private OrganizationORMDataSource DataSource;
        #endregion

        #region Constructors
        public OrganizationORMDelegate(OrganizationORMDataSource dataSource)
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
                case "organization_id":
                    view.IntValue = DataSource.Organizats[(int)row].organization_id;
                    break;
                case "org_name":
                    view.StringValue = new String(DataSource.Organizats[(int)row].org_name);
                    break;
                case "address":
                    view.StringValue = new String(DataSource.Organizats[(int)row].address);
                    break;
                case "cont_number":
                    view.StringValue = new String(DataSource.Organizats[(int)row].cont_number);
                    break;
          

            }

            return view;
        }
        #endregion
    }
}
