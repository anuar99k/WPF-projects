using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_05_.DAL.Models
{
    class Equipment
    {
        public int intEquipmentID { get; set; }

        public int GarageRoom { get; set; }

        public int ManufacturerId { get; set; }

        public int ModelId { get; set; }

        public int ManufactureYear { get; set; }

        public string SerialNo { get; set; }

        public DateTime CreateDate { get; set; }

        public int Metered { get; set; }

        public DateTime LastDate { get; set; }
    }
}
