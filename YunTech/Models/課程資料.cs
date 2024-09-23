using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YunTech.Models
{
    public class 課程資料
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string SUBJ_NO { get; set; }
        public string SUBJ_NAME { get; set; }
        public string SUBJ_NAME_ENG { get; set; }
    }
}
