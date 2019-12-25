using System;
using AppKit;
using System.Collections.Generic;
using SQLite;
namespace Koursach
{
    public class MultiSportsmanORMDataSource : NSTableViewDataSource
    {

        #region Computed Properties
        public List<MultiSportsman> MultiSportsmen { get; set; } = new List<MultiSportsman>();
        public SQLiteConnection Conn { get; set; }
        #endregion

        #region Constructors
        public MultiSportsmanORMDataSource(SQLiteConnection conn)
        {
            // Initialize
            this.Conn = conn;
            LoadMultiSportsman();
        }
        public MultiSportsmanORMDataSource()
        {

        }
        #endregion

        #region Public Methods
        public void LoadMultiSportsman()
        {

            // Get occupations from database
            var query = Conn.Query<MultiSportsman>("SELECT Sportsman.sportsman_id, Sportsman.second_name,Sportsman.name,Sportsman.surrname,Sportsman.sx,Sportsman.s_rank, Award.profile,Count(Award.award_id) as count_award FROM Award" +
                " INNER JOIN Sportsman on Award.winner_id = Sportsman.sportsman_id " +
                "GROUP by Sportsman.sportsman_id " +
                "HAVING Count(Award.award_id) >= 2; ");
            // Copy into table collection
            MultiSportsmen.Clear();
            foreach (MultiSportsman multiSportsman in query)
            {
                MultiSportsmen.Add(multiSportsman);
            }

        }
        #endregion

        #region Override Methods
        public override nint GetRowCount(NSTableView tableView)
        {
            return MultiSportsmen.Count;
        }
        #endregion

    }
}
