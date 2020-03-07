using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_05_.DAL.Models
{
    class Model
    {
        public int ModelId { get; set; }

        public string Name { get; set; }

        public int ManufacturerId { get; set; }

        public int SMCSFamilyId { get; set; }

        public string Image { get; set; }
    }
}
