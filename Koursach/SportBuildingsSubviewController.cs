using System;
using System.Collections.Generic;
using System.Linq;
using SQLite;
using Foundation;
using AppKit;
using System.IO;
namespace Koursach
{
    public partial class SportBuildingsSubviewController : AppKit.NSViewController
    {
        #region Computed Properties
        // Strongly typed view accessor
        public new SportBuildingsSubview View
        {
            get
            {
                return (SportBuildingsSubview)base.View;
            }
        }

        public SQLiteConnection Conn { get; set; }
        #endregion
        #region Constructors

        // Called when created from unmanaged code
        public SportBuildingsSubviewController(IntPtr handle) : base(handle)
        {
            Initialize();
        }

        // Called when created directly from a XIB file
        [Export("initWithCoder:")]
        public SportBuildingsSubviewController(NSCoder coder) : base(coder)
        {
            Initialize();
        }

        // Call to load from the XIB/NIB file
        public SportBuildingsSubviewController() : base("SportBuildingsSubview", NSBundle.MainBundle)
        {
            Initialize();
        }

        // Shared initialization code
        void Initialize()
        {
        }

        #endregion

        private SQLiteConnection GetDatabaseConnection()
        {
            var documents = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string db = Path.Combine(documents, "dbtest.db");



            // Create connection to database
            var conn = new SQLiteConnection(db);

            return conn;
        }
        public override void AwakeFromNib()
        {
            base.AwakeFromNib();
            // Get database connection
            Conn = GetDatabaseConnection();

            // Create the Occupation Table Data Source and populate it
            var DataSource = new SportBuildingsORMDataSource(Conn);

            // Populate the Product Table
            InfrastructureTable.DataSource = DataSource;
            InfrastructureTable.Delegate = new SportBuildingsORMDelegate(DataSource);

        }
        //public override NSObject RepresentedObject
        //{
        //    get
        //    {
        //        return base.RepresentedObject;
        //    }
        //    set
        //    {
        //        base.RepresentedObject = value;
        //        // Update the view, if already loaded.
        //    }
        //}
    }
}
