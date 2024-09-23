using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YunTech.Models
{
    public class 學生學籍資料
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string STUD_NO { get; set; }
        public string STUD_NAME { get; set; }
        public string SEX { get; set; }
        public string DEPT_CODE { get; set; }
        public string TEL { get; set; }
        public string ADDRESS { get; set; }
    }
}
