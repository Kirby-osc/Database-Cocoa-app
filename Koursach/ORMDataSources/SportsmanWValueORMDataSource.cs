using System;
using System.Collections.Generic;
using SQLite;
using AppKit;
namespace Koursach
{
    public class SportsmanWithValueORMDataSource : NSTableViewDataSource
    {
        #region Computed Properties
        public List<SportsmanWithValue> SportsmenWValue { get; set; } = new List<SportsmanWithValue>();
        public SQLiteConnection Conn { get; set; }
        public String Profile { get; set; }
        #endregion

        #region Constructors
        public SportsmanWithValueORMDataSource()
        {
        }
        public SportsmanWithValueORMDataSource(SQLiteConnection conn,String pValue)
        {
            this.Conn = conn;
            this.Profile = pValue;
            LoadSportsmanWTValue();
        }
        #endregion
        #region Public Methods
        public void LoadSportsmanWTValue()
        {

            // Get occupations from database
            var query = Conn.Query<SportsmanWithValue>("SELECT Sportsman.sportsman_id, Sportsman.second_name,Sportsman.name,Sportsman.surrname,Sportsman.sx,Sportsman.s_rank, Award.aw_type, Award.profile FROM Award " +
                "INNER JOIN Sportsman on Award.winner_id = Sportsman.sportsman_id WHERE Award.profile like ? ; ",Profile);
            // Copy into table collection
            SportsmenWValue.Clear();
            foreach (SportsmanWithValue sportsmans in query)
            {
                SportsmenWValue.Add(sportsmans);
            }

        }
        #endregion
        #region Override Methods
        public override nint GetRowCount(NSTableView tableView)
        {
            return SportsmenWValue.Count;
        }
        #endregion
    }
}
