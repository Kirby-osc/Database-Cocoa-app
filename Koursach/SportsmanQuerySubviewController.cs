using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;
using SQLite;
using System.IO;
namespace Koursach
{
    public partial class SportsmanQuerySubviewController : AppKit.NSViewController
    {
        public SQLiteConnection Conn { get; set; }

        public String Profile { get; set; }

        #region Constructors

        // Called when created from unmanaged code
        public SportsmanQuerySubviewController(IntPtr handle) : base(handle)
        {
            Initialize();
        }

        // Called when created directly from a XIB file
        [Export("initWithCoder:")]
        public SportsmanQuerySubviewController(NSCoder coder) : base(coder)
        {
            Initialize();
        }

        // Call to load from the XIB/NIB file
        public SportsmanQuerySubviewController(String pValue) : base("SportsmanQuerySubview", NSBundle.MainBundle)
        {
            this.Profile = pValue;
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
            var DataSource = new SportsmanWithValueORMDataSource(Conn,Profile);

            // Populate the Product Table
            SportsmanQueryTable.DataSource = DataSource;
            SportsmanQueryTable.Delegate = new SportsmanWValueORMDelegate(DataSource);

        }

        //strongly typed view accessor
        public new SportsmanQuerySubview View
        {
            get
            {
                return (SportsmanQuerySubview)base.View;
            }
        }
    }
}
