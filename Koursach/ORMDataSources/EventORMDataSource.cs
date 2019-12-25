using System;
using AppKit;
using CoreGraphics;
using Foundation;
using System.Collections;
using System.Collections.Generic;
using SQLite;
using System.IO;
namespace Koursach
{
    public class EventORMDataSource : NSTableViewDataSource
    {
        #region Computed Properties
        public List<SportsEvent> Events { get; set; } = new List<SportsEvent>();
        public SQLiteConnection Conn { get; set; }
        #endregion

        #region Constructors
        public EventORMDataSource(SQLiteConnection conn)
        {
            // Initialize
            this.Conn = conn;
            LoadEvents();
        }
        public EventORMDataSource()
        {
        }
        #endregion

        #region Public Methods
        public void LoadEvents()
        {

            // Get occupations from database
            var query = Conn.Query<SportsEvent>("SELECT SportOrganizations.org_name, SportsEvent.event_name, event_date, SportsEvent.type from SportsEvent" +
                " INNER JOIN SportOrganizations on SportsEvent.organization_id = SportOrganizations.organization_id" +
                " order by SportOrganizations.org_name");
            // Copy into table collection
            Events.Clear();
            foreach (SportsEvent events in query)
            {
                Events.Add(events);
            }

        }
        #endregion

        #region Override Methods
        public override nint GetRowCount(NSTableView tableView)
        {
            return Events.Count;
        }
        #endregion

    }
}
