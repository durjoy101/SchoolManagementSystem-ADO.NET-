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
    public class EmployeeInfoDAL
    {
        public int Insert_Update_DeleteEmployee(Entity.EEmployeeInfo objEDE)
        {
            int ret = 0;

            Database db;
            DbCommand dbCmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbCmd = db.GetStoredProcCommand("conSp_InsertUpdateDeleteEmployee");
            db.AddInParameter(dbCmd, "action", DbType.Int32, objEDE.action);
            db.AddInParameter(dbCmd, "EmployeeId", DbType.Int32, objEDE.EmployeeId);
            db.AddInParameter(dbCmd, "FirstName", DbType.String, objEDE.FirstName);
            db.AddInParameter(dbCmd, "LastName", DbType.String, objEDE.LastName);
            db.AddInParameter(dbCmd, "EmployeeType", DbType.String, objEDE.EmployeeType);
            db.AddInParameter(dbCmd, "DesignationId", DbType.Int32, objEDE.DesignationId);
            db.AddInParameter(dbCmd, "StartingSalary", DbType.Double, objEDE.StartingSalary);
            db.AddInParameter(dbCmd, "Nationality", DbType.String, objEDE.Nationality);
            db.AddInParameter(dbCmd, "NID", DbType.String, objEDE.NID);
            db.AddInParameter(dbCmd, "DOB", DbType.String, objEDE.DOB);
            db.AddInParameter(dbCmd, "JoiningDate", DbType.String, objEDE.JoiningDate);
            db.AddInParameter(dbCmd, "ReligionId", DbType.Int32, objEDE.ReligionId);
            db.AddInParameter(dbCmd, "DistrictId", DbType.Int32, objEDE.DistrictId);
            db.AddInParameter(dbCmd, "UpazilaId", DbType.Int32, objEDE.UpazilaId);
            db.AddInParameter(dbCmd, "Address", DbType.String, objEDE.Address);
            db.AddInParameter(dbCmd, "Email", DbType.String, objEDE.Email);
            db.AddInParameter(dbCmd, "ContactNo", DbType.String, objEDE.ContactNo);
            db.AddInParameter(dbCmd, "Gender", DbType.String, objEDE.Gender);
            db.AddInParameter(dbCmd, "BloodGroup", DbType.String, objEDE.BloodGroup);
            db.AddInParameter(dbCmd, "EmpImg", DbType.String, objEDE.EmpImg);
            db.AddInParameter(dbCmd, "EntryBy", DbType.Int32, objEDE.EntryBy);
            db.AddInParameter(dbCmd, "IsActive", DbType.Boolean, objEDE.IsActive);

          

            ret = db.ExecuteNonQuery(dbCmd);

            return ret;
        }

        public DataTable GetEmployee(int EmployeeId = 0)
        {
            DataTable dt = new DataTable();
            Database db;
            DbCommand dbCmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbCmd = db.GetStoredProcCommand("SetupSp_GetEmployee");
            db.AddInParameter(dbCmd, "EmployeeId", DbType.Int32, EmployeeId);

            dt = db.ExecuteDataSet(dbCmd).Tables[0];
            return dt;
        }
    }
}
