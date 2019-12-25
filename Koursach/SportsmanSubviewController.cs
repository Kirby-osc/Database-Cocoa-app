using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;
using SQLite;
using System.IO;

namespace Koursach
{
    public partial class SportsmanSubviewController : AppKit.NSViewController
    {
        #region Computed Properties
        // Strongly typed view accessor
        public new SportsmanSubview View
        {
            get
            {
                return (SportsmanSubview)base.View;
            }
        }

        public SQLiteConnection Conn { get; set; }
        #endregion
        #region Constructors

        // Called when created from unmanaged code
        public SportsmanSubviewController(IntPtr handle) : base(handle)
        {
            Initialize();
        }

        // Called when created directly from a XIB file
        [Export("initWithCoder:")]
        public SportsmanSubviewController(NSCoder coder) : base(coder)
        {
            Initialize();
        }

        // Call to load from the XIB/NIB file
        public SportsmanSubviewController() : base("SportsmanSubview", NSBundle.MainBundle)
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
            var DataSource = new SportsmanORMDataSource(Conn);

            // Populate the Product Table
            SportsmanTable.DataSource = DataSource;
            SportsmanTable.Delegate = new SportsmanORMDelegate(DataSource);

        }
    }
}
