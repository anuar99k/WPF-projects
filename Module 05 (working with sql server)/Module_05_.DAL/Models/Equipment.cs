using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_05_.DAL.Models
{
    public class Equipment
    {
        public int intEquipmentID { get; set; }

        public string intGarageRoom { get; set; }

        public int intManufacturerID { get; set; }

        public int intModelID { get; set; }

        public string strManufYear { get; set; }

        public string strSerialNo { get; set; }

        public DateTime CreateDate { get; set; }

        public int intMetered { get; set; }

        public DateTime LastDate { get; set; }
    }
}
