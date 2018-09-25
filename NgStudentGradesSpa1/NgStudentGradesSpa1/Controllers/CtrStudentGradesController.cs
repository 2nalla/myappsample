using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NgStudentGradesSpa1.Models;
using NgStudentGradesSpa1.DAL;

namespace NgStudentGradesSpa1.Controllers
{
    public class CtrStudentGradesController : ApiController
    {
        public List<SGradesModel> Get()
        {
            GradesDal dal = new GradesDal();
            var allURLValues = ControllerContext.Request.GetQueryNameValuePairs();
            string StudentCode = allURLValues.SingleOrDefault(x => x.Key == "StudentCode").Value;
            string StudentName = allURLValues.SingleOrDefault(x => x.Key == "StudentName").Value;
            List<SGradesModel> gradesList = new List<SGradesModel>();
            if (StudentCode != null)
            {
                gradesList = (from t in dal.dbSGrades
                              where t.StudentCode == StudentCode
                              select t).ToList<SGradesModel>();
            }
            else if (StudentName != null)
            {
                gradesList = (from t in dal.dbSGrades
                              where t.StudentName == StudentName
                              select t).ToList<SGradesModel>();
            }
            else
            {
                gradesList = dal.dbSGrades.ToList<SGradesModel>();
            }
            return gradesList;
        }

        public List<SGradesModel> Post(SGradesModel obj)
        {
            GradesDal dal = new GradesDal();
            dal.dbSGrades.Add(obj);
            dal.SaveChanges();
            List<SGradesModel> gradesList = dal.dbSGrades.ToList<SGradesModel>();

            return gradesList;
        }
        
        public List<SGradesModel> Put(SGradesModel obj)
        {
            GradesDal dal = new GradesDal();
            SGradesModel updateStudent = (from t in dal.dbSGrades
                                          where t.StudentCode == obj.StudentCode
                                          select t).ToList<SGradesModel>()[0];
            updateStudent.StudentName = obj.StudentName;
            updateStudent.Math = obj.Math;
            updateStudent.Science = obj.Science;
            updateStudent.English = obj.English;
            updateStudent.Total = obj.Total;
            updateStudent.Average = obj.Average;
            updateStudent.Grade = obj.Grade;
            dal.SaveChanges();
            List<SGradesModel> studentList = dal.dbSGrades.ToList<SGradesModel>();
            return studentList;
        }
    }
}