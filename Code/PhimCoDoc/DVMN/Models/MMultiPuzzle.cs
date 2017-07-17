using DVMN.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DVMN.Models
{
    public class MMultiPuzzle : Base
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Required]
        public int ID { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Slug { get; set; }

        [Required]
        public int NumberQuestion { get; set; }
        public string Image { get; set; }
        public int Like { get; set; }
        public float Level { get; set; }
        public List<Comment> Comment { get; set; }

        public List<MSinglePuzzleDetails> SinglePuzzleDetails { get; set; }
    }
}
