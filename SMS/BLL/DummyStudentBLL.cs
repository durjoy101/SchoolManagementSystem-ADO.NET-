using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Entity;
using System.Data;
namespace BLL
{
    public class DummyStudentBLL
    {
        DummyStudentDAL objDSDAL = new DummyStudentDAL();
        
        public int Insert_Update_DeleteDummyStudentInfo(EDummyStudent objEDS)
        {

            int ret = 0;
            ret = objDSDAL.Insert_Update_DeleteDummyStudent(objEDS);
            return ret;
        }

        public DataTable ShowGetDummyStudentInfo(int StudentId=0)
        {
            DataTable dt = new DataTable();
            dt = objDSDAL.GetDummyStudent(StudentId);
            return dt;
        }
        
        public DataTable StudentSearchInfo(string StuName, int Religion, string Gender, int RollNo)
        {
            DataTable dt = new DataTable();
            dt = objDSDAL.StudentSearch(  StuName,   Religion,   Gender,   RollNo);
            return dt;
        }

        
    }
}
