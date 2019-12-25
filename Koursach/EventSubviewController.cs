using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;
using SQLite;
using System.IO;

namespace Koursach
{
    public partial class EventSubviewController : AppKit.NSViewController
    {
        public SQLiteConnection Conn { get; set; }
        #region Constructors

        // Called when created from unmanaged code
        public EventSubviewController(IntPtr handle) : base(handle)
        {
            Initialize();
        }

        // Called when created directly from a XIB file
        [Export("initWithCoder:")]
        public EventSubviewController(NSCoder coder) : base(coder)
        {
            Initialize();
        }

        // Call to load from the XIB/NIB file
        public EventSubviewController() : base("EventSubview", NSBundle.MainBundle)
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
            var DataSource = new EventORMDataSource(Conn);

            // Populate the Product Table
            EventTable.DataSource = DataSource;
            EventTable.Delegate = new EventORMDelegate(DataSource);

        }
        //strongly typed view accessor
        public new EventSubview View
        {
            get
            {
                return (EventSubview)base.View;
            }
        }
    }
}
