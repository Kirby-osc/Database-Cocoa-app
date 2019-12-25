using System;
using System.Collections.Generic;
using SQLite;
using AppKit;
namespace Koursach
{
    public class SportsmanWTrainerORMDataSource : NSTableViewDataSource
    {
        #region Computed Properties
        public List<SportsmanWithTrainer> SportsmenWTrainer { get; set; } = new List<SportsmanWithTrainer>();
        public SQLiteConnection Conn { get; set; }
        #endregion

        #region Constructors
        public SportsmanWTrainerORMDataSource()
        {
        }
        public SportsmanWTrainerORMDataSource(SQLiteConnection conn)
        {
            this.Conn = conn;
            LoadSportsmanWTrainer();
        }
        #endregion
        #region Public Methods
        public void LoadSportsmanWTrainer()
        {

            // Get occupations from database
            var query = Conn.Query<SportsmanWithTrainer>("SELECT Sportsman.sportsman_id, Sportsman.second_name,Sportsman.name,Sportsman.surrname,Sportsman.sx,Sportsman.s_rank, Trainer.trainer_name FROM Sportsman " +
                "INNER JOIN Trainer on Sportsman.trainer_id = Trainer.trainer_id " +
                "WHERE Sportsman.trainer_id is NOT NULL; ");
            // Copy into table collection
            SportsmenWTrainer.Clear();
            foreach (SportsmanWithTrainer sportsmans in query)
            {
                SportsmenWTrainer.Add(sportsmans);
            }

        }
        #endregion
        #region Override Methods
        public override nint GetRowCount(NSTableView tableView)
        {
            return SportsmenWTrainer.Count;
        }
        #endregion
    }
}
