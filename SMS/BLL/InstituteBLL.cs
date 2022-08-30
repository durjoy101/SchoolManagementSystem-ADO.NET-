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
    public class InstituteBLL
    {
        InstituteDAL objInsDAL = new InstituteDAL();
        
        public int Insert_Update_DeleteInstituteInfo(EInstitute objEIns)
        {

            int ret = 0;
            ret = objInsDAL.Insert_Update_DeleteInstitute(objEIns);
            return ret;
        }

        public DataTable ShowGetInstituteInfo(int InstituteId=0)
        {
            DataTable dt = new DataTable();
            dt = objInsDAL.GetInstitute(InstituteId);
            return dt;
        }

        //public int InsertUpdateDelete_StudentRegInfo(EStudentReg objESR)
        //{
        //    int ret = 0;
        //    ret = objAuthDAL.InsertUpdateDelete_StudentReg(objESR);
        //    return ret;
        //}
        //public DataTable GetUserRegList(int ReligionId, int Gender,int UserId=0)
        //{
        //    DataTable dt = new DataTable();
        //    dt = objAuthDAL.GetUserReg(ReligionId, Gender, UserId);
        //    return dt;
        //}

        //public DataTable LoadGridStudentRegInfo()
        //{
        //    DataTable ret = new DataTable();
        //    ret = objAuthDAL.LoadStudentReg();
        //    return ret;
        //}
        //public int Approved_UserRegInfo(int UserId, string AppStatus, string Password)
        //{
        //    int ret = 0;
        //    ret = objAuthDAL.Approved_UserReg( UserId,  AppStatus,  Password);
        //    return ret;
        //}
    }
}
