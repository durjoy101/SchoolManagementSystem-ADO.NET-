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
    public class DummyStudentDAL
    {
        public int Insert_Update_DeleteDummyStudent(Entity.EDummyStudent objEDS)
        {
            int ret = 0;

            Database db;
            DbCommand dbCmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbCmd = db.GetStoredProcCommand("conSp_InsertUpdateDeleteDummyStudent");
            db.AddInParameter(dbCmd, "action", DbType.Int32, objEDS.action);
            db.AddInParameter(dbCmd, "StudentId", DbType.Int32, objEDS.StudentId);
            db.AddInParameter(dbCmd, "FirstName", DbType.String, objEDS.FirstName);
            db.AddInParameter(dbCmd, "LastName", DbType.String, objEDS.LastName);
            db.AddInParameter(dbCmd, "FathersName", DbType.String, objEDS.FathersName);
            db.AddInParameter(dbCmd, "FathersOccupation", DbType.String, objEDS.FathersOccupation);
            db.AddInParameter(dbCmd, "FathersContact", DbType.String, objEDS.FathersContact);
            db.AddInParameter(dbCmd, "MothersName", DbType.String, objEDS.MothersName);
            db.AddInParameter(dbCmd, "MothersOccupation", DbType.String, objEDS.MothersOccupation);
            db.AddInParameter(dbCmd, "MothersContact", DbType.String, objEDS.MothersContact);
            db.AddInParameter(dbCmd, "PresentAddress", DbType.String, objEDS.PresentAddress);
            db.AddInParameter(dbCmd, "PermanentAddress", DbType.String, objEDS.PermanentAddress);
            db.AddInParameter(dbCmd, "ContactNo", DbType.String, objEDS.ContactNo);
            db.AddInParameter(dbCmd, "Email", DbType.String, objEDS.Email);
            db.AddInParameter(dbCmd, "Nationality", DbType.String, objEDS.Nationality);
            db.AddInParameter(dbCmd, "Gender", DbType.String, objEDS.Gender);
            db.AddInParameter(dbCmd, "ReligionId", DbType.Int32, objEDS.ReligionId);
            db.AddInParameter(dbCmd, "DateOfBirth", DbType.String, objEDS.DateOfBirth);
            db.AddInParameter(dbCmd, "BloodGroup", DbType.String, objEDS.BloodGroup);
            db.AddInParameter(dbCmd, "GuardianName", DbType.String, objEDS.GuardianName);
            db.AddInParameter(dbCmd, "GuardianContact", DbType.String, objEDS.GuardianContact);
            db.AddInParameter(dbCmd, "IsActive", DbType.Boolean, objEDS.IsActive);
            db.AddInParameter(dbCmd, "EntryBy", DbType.Int32, objEDS.EntryBy);
            
          

            ret = db.ExecuteNonQuery(dbCmd);

            return ret;
        }

        public DataTable GetDummyStudent(int StudentId = 0)
        {
            DataTable dt = new DataTable();
            Database db;
            DbCommand dbCmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbCmd = db.GetStoredProcCommand("SetupSp_GetDummyStudent");
            db.AddInParameter(dbCmd, "StudentId", DbType.Int32, StudentId);

            dt = db.ExecuteDataSet(dbCmd).Tables[0];
            return dt;
        }

        public DataTable StudentSearch(string StuName, int Religion, string Gender, int RollNo)
        {
            DataTable dt = new DataTable();
            Database db;
            DbCommand dbCmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbCmd = db.GetStoredProcCommand("SetupSp_GetByParam");
            db.AddInParameter(dbCmd, "StuName", DbType.String, StuName);
            db.AddInParameter(dbCmd, "Religion", DbType.Int32, Religion);
            db.AddInParameter(dbCmd, "Gender", DbType.String, Gender);
            db.AddInParameter(dbCmd, "RollNo", DbType.Int32, RollNo);

            dt = db.ExecuteDataSet(dbCmd).Tables[0];
            return dt;
        }
    }
}
