using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
  public  class AssignBLL
    {
        AssignDAL objAssign = new AssignDAL();
        public DataTable Set_getClassAssignInfo(int ClassScheduleId = 0)
        {
            DataTable ret = new DataTable();
            ret = objAssign.Set_getClassAssign( ClassScheduleId);
            return ret;
        }
        public int InsertUpdateDelete_ClassAssignInfo(int action, string Shift, int ClassId, string WeekDay, int SubjectId, string StartTime, string EndTime, int ClassScheduleId = 0)
        {
            int ret = 0;
            ret = objAssign.InsertUpdateDelete_ClassAssign( action,  Shift,  ClassId,  WeekDay,  SubjectId,  StartTime,  EndTime, ClassScheduleId);
            return ret;
        }
    }
}
