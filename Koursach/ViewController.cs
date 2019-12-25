using System;

using AppKit;
using CoreGraphics;
using Foundation;

namespace Koursach
{
    public partial class ViewController : NSViewController
    {
        public enum SubviewType
        {
            None,
            TableView,
            Query
        }
        #region Private
        private SubviewType ViewType = SubviewType.None;
        private NSViewController SubviewController = null;
        private NSView Subview = null;
        #endregion
        private void DisplaySubview(NSViewController controller, SubviewType type)
        {

            // Is this view already displayed?
           // if (ViewType == type) return;

            // Is there a view already being displayed?
            if (Subview != null)
            {
                // Yes, remove it from the view
                Subview.RemoveFromSuperview();

                // Release memory
                Subview = null;
                SubviewController = null;
            }

            // Save values
            ViewType = type;
            SubviewController = controller;
            Subview = controller.View;

            // Define frame and display
            Subview.Frame = new CGRect(0, 0, ViewContainer.Frame.Width, ViewContainer.Frame.Height);
            Subview.AutoresizingMask= NSViewResizingMask.HeightSizable | NSViewResizingMask.WidthSizable;
            ViewContainer.AddSubview(Subview);
        }

        public NSView Content
        {
            get { return ViewContainer; }
        }
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        //public override void ViewDidLoad()
        //{
        //    base.ViewDidLoad();

        //    // Do any additional setup after loading the view.
        //}
        public override void AwakeFromNib()
        {
            base.AwakeFromNib();

            // Populate source list
            SourceList.Initialize();

            var library = new SourceListItem("TableView");
            library.AddItem("SportBuildings", "calendar.png", () => {
               	 DisplaySubview(new SportBuildingsSubviewController(), SubviewType.TableView);
            });
            library.AddItem("Organizations", "calendar.png", () =>
            {
                DisplaySubview(new OrganizationSubviewController(), SubviewType.TableView);
            });
            library.AddItem("Sportsmen", "calendar.png", () =>
            {
                DisplaySubview(new SportsmanSubviewController(), SubviewType.TableView);
            });
            library.AddItem("Events", "calendar.png", () =>
            {
                DisplaySubview(new EventSubviewController(), SubviewType.TableView);
            });
            SourceList.AddItem(library);

            var querys = new SourceListItem("Query");
            querys.AddItem("Sportsman with more than 2 profiles", "info.png", () => {
                DisplaySubview(new MultiSportsmanSubviewController(), SubviewType.TableView);
            });
            querys.AddItem("Sportsman with Trainer", "info.png", () => {
                DisplaySubview(new SWTrainerSubviewController(), SubviewType.TableView);
            });
            querys.AddItem("Sportsman with specified profile", "info.png", () => {
                var sheet = new ProfileSheetController(true);
                sheet.ShowSheet(this.View.Window);
                sheet.SheetAccepted += (s, e) => {
                 //   Console.WriteLine(sheet.Profile);
                DisplaySubview(new SportsmanQuerySubviewController(sheet.Profile), SubviewType.TableView);
                };
            });
            querys.AddItem("Event with specified parameters", "info.png", () => {
                var sheet = new EventSheetController(true);
                sheet.ShowSheet(this.View.Window);
                sheet.SheetAccepted += (s, e) => {
                    //   Console.WriteLine(sheet.Organizator);
                    DisplaySubview(new EventQuerySubviewController(sheet.Organizator), SubviewType.TableView);
        
                };

                
            });
            SourceList.AddItem(querys);
            // Display side list
            SourceList.ReloadData();
            SourceList.ExpandItem(null, true);
        }
        public override NSObject RepresentedObject
        {
            get
            {
                return base.RepresentedObject;
            }
            set
            {
                base.RepresentedObject = value;
                // Update the view, if already loaded.
            }
        }
    }
}
