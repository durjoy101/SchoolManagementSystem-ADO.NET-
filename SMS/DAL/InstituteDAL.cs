using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace DAL
{
    public class InstituteDAL
    {


        //public DataTable GetUserReg(int ReligionId, int Gender, int userId)
        //{
        //    DataTable dt = new DataTable();
        //    Database db;
        //    DbCommand dbCmd;
        //    db = DatabaseFactory.CreateDatabase("cnn");
        //    dbCmd = db.GetStoredProcCommand("AuthSp_GetUserReg");
        //    db.AddInParameter(dbCmd, "ReligionId", DbType.Int32, ReligionId);
        //    db.AddInParameter(dbCmd, "Gender", DbType.Int32, Gender);
        //    db.AddInParameter(dbCmd, "UserId", DbType.Int32, userId);
        //    dt = db.ExecuteDataSet(dbCmd).Tables[0];
        //    return dt;
        //}

        //public DataTable LoadStudentReg()
        //{
        //    DataTable dt = new DataTable();
        //    Database db;
        //    DbCommand dbCmd;
        //    db = DatabaseFactory.CreateDatabase("cnn");
        //    dbCmd = db.GetStoredProcCommand("SetupSp_GetStudentRegistration");
        //    dt = db.ExecuteDataSet(dbCmd).Tables[0];
        //    return dt;
        //}

        //public DataTable ddlLoad(string query)
        //{
        //    DataTable dt = new DataTable();
        //    Database db;
        //    DbCommand dbCmd;
        //    db = DatabaseFactory.CreateDatabase("cnn");
        //    dbCmd = db.GetSqlStringCommand(query);
        //    dt = db.ExecuteDataSet(dbCmd).Tables[0];
        //    return dt;
        //}

        public int Insert_Update_DeleteInstitute(Entity.EInstitute objEIns)
        {
            int ret = 0;

            Database db;
            DbCommand dbCmd; 
            db = DatabaseFactory.CreateDatabase("cnn");
            dbCmd = db.GetStoredProcCommand("conSp_InsertUpdateDeleteInstitute");
            db.AddInParameter(dbCmd, "action", DbType.Int32, objEIns.action);
            db.AddInParameter(dbCmd, "InstituteId", DbType.Int32, objEIns.InstituteId);
            db.AddInParameter(dbCmd, "EIIN_RegistrationNo", DbType.String, objEIns.EIIN_RegistrationNo);
            db.AddInParameter(dbCmd, "InstituteName", DbType.String, objEIns.InstituteName);
            db.AddInParameter(dbCmd, "Email", DbType.String, objEIns.Email);
            db.AddInParameter(dbCmd, "Phone", DbType.String, objEIns.Phone);
            db.AddInParameter(dbCmd, "Fax", DbType.String, objEIns.Fax);
            db.AddInParameter(dbCmd, "DistrictId", DbType.Int32, objEIns.DistrictId);
            db.AddInParameter(dbCmd, "UpazilaId", DbType.Int32, objEIns.UpazilaId);
            db.AddInParameter(dbCmd, "Address", DbType.String, objEIns.Address);
            db.AddInParameter(dbCmd, "InstituteTypeId", DbType.Int32, objEIns.InstituteTypeId);
            db.AddInParameter(dbCmd, "EntryBy", DbType.Int32, objEIns.EntryBy);
            db.AddInParameter(dbCmd, "IsActive", DbType.Boolean, objEIns.IsActive);

            ret = db.ExecuteNonQuery(dbCmd);

            return ret;
        }

        public int InsertUpdateDelete_StudentReg(Entity.EStudentReg objESR)
        {
            int ret = 0;

            Database db;
            DbCommand dbCmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbCmd = db.GetStoredProcCommand("conSp_StudentRegistration");
            db.AddInParameter(dbCmd, "action", DbType.String, objESR.Action);
            db.AddInParameter(dbCmd, "StudentId", DbType.String, objESR.StudentId);
            db.AddInParameter(dbCmd, "FirstName", DbType.String, objESR.FirstName);
            db.AddInParameter(dbCmd, "LastName", DbType.String, objESR.LastName);
            db.AddInParameter(dbCmd, "FathersName", DbType.String, objESR.FathersName);
            db.AddInParameter(dbCmd, "FathersOccupation", DbType.String, objESR.FathersOccupation);
            db.AddInParameter(dbCmd, "FathersContact", DbType.String, objESR.FathersContact);
            db.AddInParameter(dbCmd, "MothersName", DbType.String, objESR.MothersName);
            db.AddInParameter(dbCmd, "MothersOccupation", DbType.String, objESR.MothersOccupation);
            db.AddInParameter(dbCmd, "MothersContact", DbType.String, objESR.MothersContact);
            db.AddInParameter(dbCmd, "PresentAddress", DbType.String, objESR.PresentAddress);
            db.AddInParameter(dbCmd, "PermanentAddress", DbType.String, objESR.PermanentAddress);
            db.AddInParameter(dbCmd, "ContactNo", DbType.String, objESR.ContactNo);
            db.AddInParameter(dbCmd, "Email", DbType.String, objESR.Email);
            db.AddInParameter(dbCmd, "Nationality", DbType.String, objESR.Nationality);
            db.AddInParameter(dbCmd, "Gender", DbType.String, objESR.Gender);
            db.AddInParameter(dbCmd, "ReligionId", DbType.Int32, objESR.ReligionId);
            db.AddInParameter(dbCmd, "DateOfBirth", DbType.String, objESR.DateOfBirth);
            db.AddInParameter(dbCmd, "BloodGroup", DbType.String, objESR.BloodGroup);
            db.AddInParameter(dbCmd, "GuardianName", DbType.String, objESR.GuardianName);
            db.AddInParameter(dbCmd, "GuardianContact", DbType.String, objESR.GuardianContact);
            
            db.AddInParameter(dbCmd, "EntryBy", DbType.Int32, objESR.EntryBy);
            
            ret = db.ExecuteNonQuery(dbCmd);

            return ret;
        }

        public DataTable GetInstitute(int InstituteId = 0)
        {
            DataTable dt = new DataTable();
            Database db;
            DbCommand dbCmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbCmd = db.GetStoredProcCommand("SetupSp_GetInstitute");
            db.AddInParameter(dbCmd, "InstituteId", DbType.Int32, InstituteId);
            
            dt = db.ExecuteDataSet(dbCmd).Tables[0];
            return dt;
        }

        //public int Approved_UserReg(int UserId,string AppStatus,string Password)
        //{
        //    int ret = 0;

        //    Database db;
        //    DbCommand dbCmd;
        //    db = DatabaseFactory.CreateDatabase("cnn");
        //    dbCmd = db.GetStoredProcCommand("AuthSp_ApprovesUser");
        //    db.AddInParameter(dbCmd, "UserId", DbType.Int32, UserId);
        //    db.AddInParameter(dbCmd, "AppStatus", DbType.String, AppStatus);
        //    db.AddInParameter(dbCmd, "Password", DbType.String, Password);

        //    ret = db.ExecuteNonQuery(dbCmd);

        //    return ret;
        //}

    }
}
