using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Xml.Linq;
using YunTech.Service;
using System.Threading.Tasks;
using YunTech.Models;
using Microsoft.EntityFrameworkCore;


namespace YunTech
{
    public class StudentRepository :IStudentRepository
    {
        private static YunTchContext db;
        public  StudentRepository() 
        {
            db = new YunTchContext();  
        }


        public async Task<List<Student>> GetStudentsAsync(string searchTxt)
        {
            try
            {
                var students = new List<Student>();
                using (db = new YunTchContext())
                {

                    students = await (from std in db.Students
                                          join dep in db.Depts on std.DEPT_CODE equals dep.DEPT_CODE
                                          where std.STUD_NO.Contains(searchTxt) || std.STUD_NAME.Contains(searchTxt)
                                          select new Student
                                          {
                                              STUD_NO = std.STUD_NO,
                                              STUD_NAME = std.STUD_NAME,
                                              DEPT_NAME = dep.DEPT_NAME
                                          }
                                    ).ToListAsync();
                };
                return students;
            }
            catch
            {
                return new List<Student>();
            }

        }

        public async Task<Student> GetStudentDetailAsync(string studNo)
        {

            try
            {
                var student = new Student();
                using (db = new YunTchContext())
                {

                    student =  await (from std in db.Students
                                         where std.STUD_NO.Equals(studNo)
                                         select new Student()
                                         {
                                             STUD_NO = std.STUD_NO,
                                             STUD_NAME = std.STUD_NAME,
                                             SEX = std.SEX,
                                             DEPT_CODE = std.DEPT_CODE,
                                             TEL = std.TEL,
                                             ADDRESS = std.ADDRESS
                                         }
                                    ).FirstOrDefaultAsync();

                };

                return student;
            }
            catch 
            {
              return null;
            }


        }

        public async Task<bool> CheckStudentAsync(string studNo)
        {
            try
            {
                var check = new bool();
                using (db = new YunTchContext())
                {
                    check =  await (from std in db.Students
                                         where std.STUD_NO.Equals(studNo)
                                         select std.STUD_NO
                                    ).AnyAsync();
                };
                return check;
            }
            catch
            {
                return false;
            }

        }

        public async Task<int> AddStudentAsync(學生學籍資料 addStudent)
        {
            try
            {
                var count = 0;
                using (db = new YunTchContext())
                {

                    db.Students.Add(addStudent);

                    count =  await db.SaveChangesAsync();

                }

                return count;

            }
            catch
            {
                return 0;
            }

        }

        public async Task<int> UpdateStudentAsync(string studNo, 學生學籍資料 nStudent)
        {
            try
            {
                var count = 0;
                using (db = new YunTchContext())
                {
                    var student = await db.Students.Where(o => o.STUD_NO == studNo).FirstOrDefaultAsync();

                    if (student != null)
                    {
                        db.Students.Update(nStudent);

                        count =  await db.SaveChangesAsync();
                    }
                }

                return count;

            }
            catch 
            {
                return 0;
            }

        }

        public async Task<int> DelStudentAsync(string studNo)
        {
            try
            {
                var count = 0;
                using (db = new YunTchContext())
                {
                    var student = await db.Students.Where(o => o.STUD_NO == studNo).FirstOrDefaultAsync();

                    if (student != null)
                    {
                        db.Students.Remove(student);

                        count =  await db.SaveChangesAsync();
                    }
                }

                return count;

            }
            catch 
            {
                return 0;
            }

        }

    }
}