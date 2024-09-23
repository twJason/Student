using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using YunTech.Models;

namespace YunTech.Service
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetStudentsAsync(string searchTxt);

        Task<Student> GetStudentDetailAsync(string studNo);

        Task<bool> CheckStudentAsync(string studNo);

        Task<int> AddStudentAsync(學生學籍資料 addStudent);

        Task<int> UpdateStudentAsync(string studNo, 學生學籍資料 nStudent);

        Task<int> DelStudentAsync(string studNo);
    }

}