using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DVMN.Models
{
    public class Film : Base
    {
        private IList<string> _genres = new List<string>();
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ID { get; set; }
        [DisplayName("Tiêu đề")]
        public string Title { get; set; }
        public string OrtherTitle { get; set; }
        [DisplayName("Nội dung ngắn")]
        public string DescriptionShort { get; set; }
        public string Description { get; set; }

        [DisplayName("Ngày xuất bản")]
        public DateTime? DateofRease { get; set; }
        public string Actor { get; set; }
        
        public string Director { get; set; }

        public int Vote { get; set; }

        public bool IsProposed { get; set; }
        public string Info { get; set; }
        public string Length { get; set; }
        public int Watch { get; set; }
        public float StarRating { get; set; }
        public string Video { get; set; }
        public string VideoBackUp1 { get; set; }
        public string VideoBackUp2 { get; set; }
        public string VideoTrailer { get; set; }
        public string Slug { get; set; }
        public int? ImageID { get; set; }
        public Images Image { get; set; }
        public int? SerieID { get; set; }
        public Serie Serie { get; set; }

        public string Genres
        {
            get;set;
        }
    }
}
