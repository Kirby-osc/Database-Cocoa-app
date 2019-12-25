using System;
using System.Collections.Generic;
using SQLite;
using AppKit;
namespace Koursach
{
    public class SportsmanORMDataSource:NSTableViewDataSource
    {
        #region Computed Properties
        public List<Sportsman> Sportsmen { get; set; } = new List<Sportsman>();
        public SQLiteConnection Conn { get; set; }
        #endregion

        #region Constructors
        public SportsmanORMDataSource()
        {
        }
        public SportsmanORMDataSource(SQLiteConnection conn)
        {
            this.Conn = conn;
            LoadSportsman();
        }
        #endregion
        #region Public Methods
        public void LoadSportsman()
        {

            // Get occupations from database
            var query = Conn.Query<Sportsman>("SELECT Sportsman.sportsman_id, " +
                "Sportsman.second_name, Sportsman.name, Sportsman.surrname, Sportsman.sx, Sportsman.s_rank, " +
                "SportOrganizations.org_name, Award.aw_type, Award.profile, SportsEvent.event_name from Award " +
                "INNER JOIN SportsEvent on Award.Event_id = SportsEvent.Event_id " +
                "INNER JOIN Sportsman on Award.winner_id = Sportsman.sportsman_id " +
                "INNER JOIN SportOrganizations on SportsEvent.organization_id = SportOrganizations.organization_id " +
                "order by Sportsman.sportsman_id; ");
            // Copy into table collection
            Sportsmen.Clear();
            foreach (Sportsman sportsmans in query)
            {
                Sportsmen.Add(sportsmans);
            }

        }
        #endregion
        #region Override Methods
        public override nint GetRowCount(NSTableView tableView)
        {
            return Sportsmen.Count;
        }
        #endregion
    }
}
