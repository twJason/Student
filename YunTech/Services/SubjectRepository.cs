using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using YunTech.Models;

namespace YunTech.Service
{
    public class SubjectRepository : ISubjectRepository
    {
        private static YunTchContext db; 
        public SubjectRepository() {

            db = new YunTchContext();
        }

        public async Task<List<Subject>> GetSubjectsAsync()
        {
            try
            {
                var subjects = new List<Subject>();
                using (db = new YunTchContext())
                {

                    subjects =  await (from subj in db.Subjects
                                  select new Subject
                                  {
                                   SUBJ_NO = subj.SUBJ_NO,
                                   SUBJ_NAME = subj.SUBJ_NAME,
                                   SUBJ_NAME_ENG = subj.SUBJ_NAME_ENG,  
                                  }

                                    ).ToListAsync();

                };

                return subjects;    
            }
            catch
            {
                return new List<Subject>();

            }

        }
    }
}