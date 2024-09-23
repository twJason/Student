using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using YunTech.Models;

namespace YunTech.Service
{
    public class DeptRepository : IDeptRepository
    {
        private static YunTchContext db;
        public DeptRepository()
        {
            db = new YunTchContext();

        }

        public async Task<List<Dept>> GetDeptsAsync()
        {
            try
            {
                var depts = new List<Dept>();   
                using (db = new YunTchContext())
                {
                    var s = await db.Depts.FirstOrDefaultAsync(); ;

                    depts =  await (from dep in db.Depts
                                      select new Dept
                                      {
                                          DEPT_CODE = dep.DEPT_CODE,
                                          DEPT_NAME = dep.DEPT_NAME
                                      }

                                    ).ToListAsync();

                };

                return depts;
            }
            catch
            {
                return new List<Dept>();

            }

        }
    }
}