using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using System;
using YunTech.Models;
using YunTech.Service;
using YunTech.Services;

namespace YunTech.Controllers
{
    public class StudentController : Controller
    {
        private IStudentRepository _studentRepositories;
        private IDeptRepository _deptRepositories;
        public StudentController(IStudentRepository studentRepositories, IDeptRepository deptRepositories)
        {
            _studentRepositories = studentRepositories;
            _deptRepositories = deptRepositories;
        }

        /// <summary>
        /// 獲取系所列表
        /// </summary>
        /// <returns></returns>
        public async Task<ResponseModel> GetDeptAsync()
        {
            try
            {
                var deps = await _deptRepositories.GetDeptsAsync();

                return ResponseConver.Suc(deps);
            }
            catch (Exception ex)
            {
                return ResponseConver.Err(ex.ToString());
            }

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

                var studentView = from student in students
                                  select new
                                  {
                                      學號 = student.STUD_NO,
                                      姓名 = student.STUD_NAME,
                                      系所 = student.DEPT_NAME,
                                  };

                return ResponseConver.Suc(studentView);

            }
            catch (Exception ex)
            {
                return ResponseConver.Err(ex.ToString());
            }

        }

        /// <summary>
        /// 查詢詳細學籍資訊
        /// </summary>
        /// <returns></returns>
        private async Task<ResponseModel> GetStudentDetailAsync(string studNo)
        {

            try
            {
                var student = await _studentRepositories.GetStudentDetailAsync(studNo);

                return ResponseConver.Suc(student);
            }
            catch (Exception ex)
            {
                return ResponseConver.Err(ex.ToString());
            }


        }

        /// <summary>
        /// 非同步新增學籍
        /// </summary>
        /// <returns></returns>
        private async Task<ResponseModel> AddStudentAsync(學生學籍資料 addStudent)
        {
            var studNo = addStudent.STUD_NO;

            var check = await _studentRepositories.CheckStudentAsync(studNo);

            if (check)
                return ResponseConver.Err("重複學號");
            else
            {
                try
                {
                    var count = await _studentRepositories.AddStudentAsync(addStudent);

                    if (count > 0)
                    {
                        return ResponseConver.Suc("新增成功");
                    }
                    else
                        return ResponseConver.Err("新增失敗");
                }
                catch
                (Exception ex)
                {
                    return ResponseConver.Err(ex.ToString());
                }
            }



        }

        /// <summary>
        /// 非同步修改學籍
        /// </summary>
        /// <returns></returns>
        private async Task<ResponseModel> UpdateStudentAsync(學生學籍資料 nStudent)
        {
            var studNo = nStudent.STUD_NO;

            try
            {
                var count = await _studentRepositories.UpdateStudentAsync(studNo, nStudent);

                if (count > 0)
                {
                    return ResponseConver.Suc("修改完畢");
                }
                else
                    return ResponseConver.Err("新增失敗");

            }
            catch (Exception ex)
            {
                return ResponseConver.Err(ex.ToString());
            }

        }

        /// <summary>
        /// 非同步刪除學籍
        /// </summary>
        /// <returns></returns>
        private async Task<ResponseModel> DelStudentAsync(string studNo)
        {
            try
            {
                var count = await _studentRepositories.DelStudentAsync(studNo);
                if (count > 0)
                {
                    return ResponseConver.Suc("刪除完畢");
                }
                else
                    return ResponseConver.Err("新增失敗");

            }
            catch (Exception ex)
            {
                return ResponseConver.Err(ex.ToString());
            }

        }

        /// <summary>
        /// 學籍資訊顯示畫面
        /// </summary>
        /// <param name="student"></param>
        //private void MappingStudentToView(Student student)
        //{
        //    TxNo.Text = student.STUD_NO;
        //    TxName.Text = student.STUD_NAME;
        //    TxTel.Text = student.TEL;
        //    TxAdd.Text = student.ADDRESS;

        //    DlDept.SelectedValue = student.DEPT_CODE;

        //    RbSex.SelectedValue = student.SEX;
        //}

        /// <summary>
        /// 畫面轉換學籍資訊
        /// </summary>
        /// <returns></returns>
        //private 學生學籍資料 SetViewToStudentModel()
        //{
        //    var student = new 學生學籍資料();
        //    student.STUD_NO = TxNo.Text;
        //    student.STUD_NAME = TxName.Text;
        //    student.TEL = TxTel.Text;
        //    student.ADDRESS = TxAdd.Text;
        //    student.SEX = RbSex.Text;
        //    student.DEPT_CODE = DlDept.SelectedValue.Trim();
        //    student.DEPT_CODE = LbDept.Text.Trim();

        //    return student;
        //}

        /// <summary>
        /// 系所資訊顯示下拉
        /// </summary>
        /// <param name="deps"></param>
        //private void MappingDeptToDropList(List<Dept> deps)
        //{
        //    foreach (var dep in deps)
        //    {
        //        DlDept.Items.Add(new ListItem(dep.DEPT_NAME, dep.DEPT_CODE));
        //    }
        //}


      
    }
}
