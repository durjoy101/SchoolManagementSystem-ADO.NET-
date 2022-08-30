using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
  public  class AssignDAL
    {
        public DataTable Set_getClassAssign(int ClassScheduleId=0)
        {
            DataTable dt = new DataTable();
            Database db;
            DbCommand dbCmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbCmd = db.GetStoredProcCommand("SetupSp_GetClassAssign");
            db.AddInParameter(dbCmd, "ClassScheduleId", DbType.Int32, ClassScheduleId);

            dt = db.ExecuteDataSet(dbCmd).Tables[0];
            return dt;
        }
        public int InsertUpdateDelete_ClassAssign(int action, string Shift, int ClassId, string WeekDay,int SubjectId,string StartTime, string EndTime, int ClassScheduleId = 0)
        {
            int ret = 0;

            Database db;
            DbCommand dbCmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbCmd = db.GetStoredProcCommand("conSp_InsertUpdateDeleteClassSchedule");
            db.AddInParameter(dbCmd, "action", DbType.Int32, action);
            db.AddInParameter(dbCmd, "Shift", DbType.String, Shift );
            db.AddInParameter(dbCmd, "ClassId", DbType.Int32, ClassId);
            db.AddInParameter(dbCmd, "WeekDay", DbType.String, WeekDay );
            db.AddInParameter(dbCmd, "SubjectId", DbType.Int32, SubjectId);
            db.AddInParameter(dbCmd, "StartTime", DbType.String, StartTime);
            db.AddInParameter(dbCmd, "EndTime", DbType.String, EndTime );
            db.AddInParameter(dbCmd, "ClassScheduleId", DbType.Int32, ClassScheduleId);


            ret = db.ExecuteNonQuery(dbCmd);

            return ret;
        }
    }
}
