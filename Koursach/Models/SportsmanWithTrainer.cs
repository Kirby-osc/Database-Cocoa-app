using System;
using SQLite;
namespace Koursach
{
    public class SportsmanWithTrainer
    {
        #region Computed Properties
        [PrimaryKey]
        public int sportsman_id { get; set; }

        public String second_name { get; set; }
        public String name { get; set; }
        public String surrname { get; set; }
        public String sx { get; set; }
        public String s_rank { get; set; }
        public String trainer_name { get; set; }
        #endregion
        #region Constructors
        public SportsmanWithTrainer()
        {
        }
        public SportsmanWithTrainer(int sm_id, String sn, String name, String surname, String sx, String srank, String trname)
        {
            this.sportsman_id = sm_id;
            this.second_name = sn;
            this.name = name;
            this.surrname = surname;
            this.sx = sx;
            this.s_rank = srank;
            this.trainer_name = trname;
        }
        #endregion
    }
}
