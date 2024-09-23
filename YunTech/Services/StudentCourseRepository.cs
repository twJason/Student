using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using YunTech.Models;

namespace YunTech.Service
{
    public class StudentCourseRepository :IStudentCourseRepository
    {
        private static YunTchContext db;
        public StudentCourseRepository()
        {
            db = new YunTchContext();

        }

        public async Task<List<StudentCourse>> GetStudentCoursesAsync()
        {
            try
            {
                var stdCourses = new List<StudentCourse>();
                using (db = new YunTchContext())
                {
                    stdCourses =  await (from stdCourse in db.StudentCourses
                                  select new StudentCourse
                                  {
                                        ACAD_YEAR = stdCourse.ACAD_YEAR,
                                        SEME_TYPE = stdCourse.SEME_TYPE,    
                                        COURSE_NO = stdCourse.COURSE_NO,    
                                        STUD_NO = stdCourse.STUD_NO,    
                                  }

                                    ).ToListAsync();

                };

                return stdCourses;
            }
            catch
            {
                return new List<StudentCourse>();

            }

        }

        public async Task<List<StudentCourseView>> GetStudentCoursesViewAsync(string studNo)
        {
            try
            {
                var studCourseView = new List<StudentCourseView>();
                using (db = new YunTchContext())
                {
                    studCourseView =  await (from course in db.Courses
                                                join studCoures in db.StudentCourses on course.COURSE_NO equals studCoures.COURSE_NO
                                                join subject in db.Subjects on course.SUBJ_NO equals subject.SUBJ_NO
                                                join dept in db.Depts on course.DEPT_CODE equals dept.DEPT_CODE
                                                where studCoures.STUD_NO.Equals(studNo)
                                                select new StudentCourseView()
                                                {
                                                    AcadYear = course.ACAD_YEAR,
                                                    CourseNo = course.COURSE_NO,
                                                    SubjName = subject.SUBJ_NAME,
                                                    DeptName = dept.DEPT_NAME,
                                                }
                                   ).ToListAsync();

                };

                return studCourseView;
            }
            catch
            {
                return new List<StudentCourseView>();

            }

        }
    }
}