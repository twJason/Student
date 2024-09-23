using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using System;
using YunTech.Models;
using YunTech.Service;
using YunTech.Services;

namespace YunTech.Controllers
{
    public class StudentCoursesController : Controller
    {
        private IStudentRepository _studentRepositories;
        private IStudentCourseRepository _studentCourseRepositories;
        public StudentCoursesController(IStudentRepository studentRepositories,
           IStudentCourseRepository studentCourseRepositories)
        {
            _studentRepositories = studentRepositories;
            _studentCourseRepositories = studentCourseRepositories;
        }
        /// <summary>
        /// 模糊查詢學生資訊
        /// </summary>
        /// <returns></returns>
        private async Task<ResponseModel> GetStudentsAsync(string txSearch)
        {
            string searchTxt = txSearch.ToString().Trim();

            try
            {
                var students = await _studentRepositories.GetStudentsAsync(searchTxt);

                var studView = from st in students
                               select new
                               {
                                   學號 = st.STUD_NO,
                                   姓名 = st.STUD_NAME,
                               };

                return ResponseConver.Suc(studView);


            }
            catch (Exception ex)
            {
                return ResponseConver.Err(ex.ToString());
            }

        }

        /// <summary>
        /// 非同步查詢學生選課列表
        /// </summary>
        /// <returns></returns>
        private async Task<ResponseModel> GetStudentCourseAsync(string studNo)
        {

            try
            {
                var studentCourses = await _studentCourseRepositories.GetStudentCoursesViewAsync(studNo);

                var studentCourseView = from studentCourse in studentCourses
                                        select new
                                        {
                                            課程年度 = studentCourse.AcadYear,
                                            課程編碼 = studentCourse.CourseNo,
                                            課程 = studentCourse.SubjName,
                                            系所 = studentCourse.DeptName
                                        };

                return ResponseConver.Suc(studentCourseView);

            }
            catch (Exception ex)
            {
                return ResponseConver.Err(ex.ToString());
            }


        }
    }
}
