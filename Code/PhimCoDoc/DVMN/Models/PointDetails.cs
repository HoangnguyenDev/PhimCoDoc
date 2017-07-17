using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DVMN.Models
{
    public class PointDetails : Base
    {
        public int ID { get; set; }
        public int PointTypeID { get; set; }
        public string Level { get; set; }

        public string Point { get; set; }
        public PointType PointType;
    }
}
