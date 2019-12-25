using System;
using SQLite;
namespace Koursach
{
    public class SportBuildings
    {

        #region Computed Properties
        [PrimaryKey]
        public int sbuild_id { get; set; }

        public String contact { get; set; }

        public String type_title { get; set; }

        public String type_enterprise { get; set; }

        public int count_of_seats { get; set; }

        public String type_of_cover { get; set; }

        public float length { get; set; }

        public int count_of_equipment { get; set; }
        #endregion

        #region Constructors
        public SportBuildings()
        {
        }

        public SportBuildings(int sbuild_id, String contact, String typeTitle,
            String typeEnterprise, int countOfSeats, String typeOfCover,
            float length, int countOfEquipment)
        {

            // Initialize
            this.sbuild_id = sbuild_id;
            this.contact = contact;
            this.type_title = typeTitle;
            this.type_enterprise = typeEnterprise;
            this.count_of_seats = countOfSeats;
            this.type_of_cover = typeOfCover;
            this.length = length;
            this.count_of_equipment = countOfEquipment;

        }
        #endregion
    }
}
