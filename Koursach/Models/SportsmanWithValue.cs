using System;
using SQLite;
namespace Koursach
{
    public class SportsmanWithValue
    {
        #region Computed Properties
        [PrimaryKey]
        public int sportsman_id { get; set; }

        public String second_name { get; set; }
        public String name { get; set; }
        public String surrname { get; set; }
        public String sx { get; set; }
        public String s_rank { get; set; }
        public String org_name { get; set; }
        public String aw_type { get; set; }
        public String profile { get; set; }

        #endregion
        #region Constructors
        public SportsmanWithValue()
        {
        }

        public SportsmanWithValue(int sm_id, String sn, String name, String surname, String sx, String srank, String orgname, String awtype, String profile)
        {
            this.sportsman_id = sm_id;
            this.second_name = sn;
            this.name = name;
            this.surrname = surname;
            this.sx = sx;
            this.s_rank = srank;
            this.org_name = orgname;
            this.aw_type = awtype;
            this.profile = profile;
        }
        #endregion
    }
}
