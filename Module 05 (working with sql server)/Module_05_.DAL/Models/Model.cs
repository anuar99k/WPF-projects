using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_05_.DAL.Models
{
    public class Model
    {
        public int intModelID { get; set; }

        public string strName { get; set; }

        public int intManufacturerID { get; set; }

        public int intSMCSFamilyID   { get; set; }

        public string strImage { get; set; }
    }
}
