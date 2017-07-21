using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DVMN.Models
{
    public class ProposalsFilm : Base
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Reason { get; set; }
        public int? ImageID { get; set; }
        public Images Image { get; set; }
        public int Vote { get; set; }
    }
}
