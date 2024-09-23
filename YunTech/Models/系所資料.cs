using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YunTech.Models
{
    public class 系所資料
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string DEPT_CODE { get; set; }
        public string DEPT_NAME { get; set; }
        public string DEPT_NAME_ENG { get; set; }
    }
}
