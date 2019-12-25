using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;
using SQLite;
using System.IO;
namespace Koursach
{
    public partial class EventQuerySubviewController : AppKit.NSViewController
    {
        public SQLiteConnection Conn { get; set; }

        public String Organizator { get; set; }

        #region Constructors

        // Called when created from unmanaged code
        public EventQuerySubviewController(IntPtr handle) : base(handle)
        {
            Initialize();
        }

        // Called when created directly from a XIB file
        [Export("initWithCoder:")]
        public EventQuerySubviewController(NSCoder coder) : base(coder)
        {
            Initialize();
        }

        // Call to load from the XIB/NIB file
        public EventQuerySubviewController(String orgValue) : base("EventQuerySubview", NSBundle.MainBundle)
        {
            this.Organizator = orgValue;
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
            var DataSource = new EventQueryORMDataSource(Conn,Organizator);

            // Populate the Product Table
            EventQueryTable.DataSource = DataSource;
            EventQueryTable.Delegate = new EventQueryORMDelegate(DataSource);

        }

        //strongly typed view accessor
        public new EventQuerySubview View
        {
            get
            {
                return (EventQuerySubview)base.View;
            }
        }
    }
}
