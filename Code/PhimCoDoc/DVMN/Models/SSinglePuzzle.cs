using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DVMN.Models
{
    public class SSinglePuzzle : Base
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public string Slug { get; set; }
        public int ImageID { get; set; }
        public Image Image { get; set; }
        public bool IsYesNo { get; set; }
        public string AnswerA { get; set; }
        public string AnswerB { get; set; }
        public string AnswerC { get; set; }
        public string AnswerD { get; set; }
        public int Correct { get; set; }
        public string Reason { get; set; }
        public List<Comment> Comment { get; set; }
        public int Like { get; set; }
        public float Level { get; set; }
    }
}
