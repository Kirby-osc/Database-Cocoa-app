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
    public class SportBuildingsORMDataSource:NSTableViewDataSource
    {
        #region Computed Properties
        public List<SportBuildings> Infrastructures { get; set; } = new List<SportBuildings>();
        public SQLiteConnection Conn { get; set; }
        #endregion

        #region Constructors
        public SportBuildingsORMDataSource(SQLiteConnection conn)
        {
            // Initialize
            this.Conn = conn;
            LoadInfrastructures();
        }
        public SportBuildingsORMDataSource()
        {
        }
        #endregion

        #region Public Methods
        public void LoadInfrastructures()
        {

            // Get occupations from database
            var query = Conn.Query<SportBuildings>("SELECT SportBuildings.sbuild_id, SportBuildings.contact," +
                "TypeOfBuilding.type_title,TypeOfBuilding.type_enterprise,TypeOfBuilding.count_of_seats,TypeOfBuilding.type_of_cover," +
                "TypeOfBuilding.length,TypeOfBuilding.count_of_equipment " +
                "from SportBuildings " +
                "inner join TypeOFBuilding on SportBuildings.type_id = TypeOfBuilding.type_id " +
                "order by sbuild_id; ");
            // Copy into table collection
            Infrastructures.Clear();
            foreach (SportBuildings infrastructure in query)
            {
                Infrastructures.Add(infrastructure);
            }

        }
        #endregion

        #region Override Methods
        public override nint GetRowCount(NSTableView tableView)
        {
            return Infrastructures.Count;
        }
        #endregion
        
    }
}
