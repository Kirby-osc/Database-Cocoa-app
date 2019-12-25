using System;
using SQLite;
namespace Koursach
{
    public class SportOrganizations
    {
        #region Computed Properties
        [PrimaryKey]
        public int organization_id { get; set; }

        public String org_name { get; set; }

        public String address { get; set; }

        public String cont_number { get; set; }

        #endregion

        #region Constructors
        public SportOrganizations()
        {
        }
        public SportOrganizations(int orgid, String name, String address, String contnumber)
        {
            this.organization_id = orgid;
            this.org_name = name;
            this.address = address;
            this.cont_number = contnumber;
        }

        #endregion
    }
}
