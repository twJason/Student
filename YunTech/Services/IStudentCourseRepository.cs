using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using YunTech.Models;

namespace YunTech.Service
{
    public interface IStudentCourseRepository
    {
        Task<List<StudentCourse>> GetStudentCoursesAsync();
        Task<List<StudentCourseView>> GetStudentCoursesViewAsync(string studNo);
    }
}