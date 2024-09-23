using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YunTech.Models
{
    public class 學生選課資料
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string STUD_NO { get; set; }
        public string ACAD_YEAR { get; set; }
        public string SEME_TYPE { get; set; }
        public string COURSE_NO { get; set; }
    }
}
