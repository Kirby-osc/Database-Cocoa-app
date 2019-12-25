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
    public class EventQueryORMDataSource : NSTableViewDataSource
    {
        #region Computed Properties
        public List<SportsEvent> Events { get; set; } = new List<SportsEvent>();
        public SQLiteConnection Conn { get; set; }
      public String Organizator { get; set; }
        #endregion

        #region Constructors
        public EventQueryORMDataSource(SQLiteConnection conn,String org)
        {
            // Initialize
            this.Organizator = org;
            this.Conn = conn;
            LoadEvents();
        }
        public EventQueryORMDataSource()
        {
        }
        #endregion

        #region Public Methods
        public void LoadEvents()
        {

            // Get occupations from database
            var query = Conn.Query<SportsEvent>("SELECT SportOrganizations.org_name," +
                " SportsEvent.event_name, SportsEvent.event_date, SportsEvent.type from SportsEvent" +
                " INNER JOIN SportOrganizations on SportsEvent.organization_id = SportOrganizations.organization_id " +
                " WHERE (SportsEvent.event_date BETWEEN '2017-01-01' AND '2018-01-01') or (SportOrganizations.org_name like ?); ",Organizator);
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
