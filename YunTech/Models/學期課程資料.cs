using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace YunTech.Models
{
    public class 學期課程資料
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string COURSE_NO { get; set; }
        public string ACAD_YEAR { get; set; }
        public string SEME_TYPE { get; set; }
        public string DEPT_CODE { get; set; }
        public string SUBJ_NO { get; set; }
        public string CREDITS { get; set; }
        public string MAJ_OP { get; set; }
        public string TEACHER { get; set; }
    }
}
