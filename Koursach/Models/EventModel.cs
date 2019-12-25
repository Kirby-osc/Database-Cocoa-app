using System;
namespace Koursach
{
    public class SportsEvent
    {

        #region Computed Properties
        public String org_name { get; set; }
        public String event_name { get; set; }
        public String event_date { get; set; }
        public String type { get; set; }
        #endregion

        #region Constructors
        public SportsEvent()
        {
        }

        public SportsEvent(String orgname, String evname, String date, String type)
        {
            this.org_name = orgname;
            this.event_name = evname;
            this.event_date = date;
            this.type = type;
        }
        #endregion
    }
}
