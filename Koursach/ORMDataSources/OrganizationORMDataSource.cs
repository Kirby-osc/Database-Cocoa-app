using System;
using AppKit;
using System.Collections.Generic;
using SQLite;
namespace Koursach
{
    public class OrganizationORMDataSource:NSTableViewDataSource
    {

        #region Computed Properties
        public List<SportOrganizations> Organizats { get; set; } = new List<SportOrganizations>();
        public SQLiteConnection Conn { get; set; }
        #endregion

        #region Constructors
        public OrganizationORMDataSource(SQLiteConnection conn)
        {
            // Initialize
            this.Conn = conn;
            LoadOrganizations();
        }
        public OrganizationORMDataSource()
        {

        }
        #endregion

        #region Public Methods
        public void LoadOrganizations()
        {

            // Get occupations from database
            var query = Conn.Query<SportOrganizations>("SELECT organization_id,org_name,address,cont_number from SportOrganizations order by SportOrganizations.organization_id; ");
            // Copy into table collection
            Organizats.Clear();
            foreach (SportOrganizations organizations in query)
            {
                Organizats.Add(organizations);
            }

        }
        #endregion

        #region Override Methods
        public override nint GetRowCount(NSTableView tableView)
        {
            return Organizats.Count;
        }
        #endregion
        
    }
}
