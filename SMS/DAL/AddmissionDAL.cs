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
    public class AddmissionDAL
    {
        public int Insert_deleteAddmission(int action , int AddmissionId, int RegSl, string RegistrationNo,int StudentId, string Shift,int ClassId,int RollNo,int SessionYear,string AddmissionDate,int CreatedBy, bool IsActive)
        {
            int ret = 0;

            Database db;
            DbCommand dbCmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbCmd = db.GetStoredProcCommand("conSp_InsertDeleteAddmission");
            db.AddInParameter(dbCmd, "action", DbType.Int32, action);
            db.AddInParameter(dbCmd, "AddmissionId", DbType.Int32, AddmissionId);
            db.AddInParameter(dbCmd, "RegSl", DbType.Int32, RegSl);
            db.AddInParameter(dbCmd, "RegistrationNo", DbType.String, RegistrationNo);
            db.AddInParameter(dbCmd, "StudentId", DbType.Int32, StudentId);
            db.AddInParameter(dbCmd, "Shift", DbType.String, Shift);
            db.AddInParameter(dbCmd, "ClassId", DbType.Int32, ClassId);
            db.AddInParameter(dbCmd, "RollNo", DbType.Int32, RollNo);
            db.AddInParameter(dbCmd, "SessionYear", DbType.Int32, SessionYear);
            db.AddInParameter(dbCmd, "AddmissionDate", DbType.String, AddmissionDate);
            db.AddInParameter(dbCmd, "CreatedBy", DbType.Int32, CreatedBy);
            db.AddInParameter(dbCmd, "IsActive", DbType.Boolean, IsActive);

          

            ret = db.ExecuteNonQuery(dbCmd);

            return ret;
        }

        
    }
}
