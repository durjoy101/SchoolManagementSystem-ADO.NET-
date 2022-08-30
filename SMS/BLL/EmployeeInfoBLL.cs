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
    public class EmployeeInfoBLL
    {
        EmployeeInfoDAL objEDAL = new EmployeeInfoDAL();
        
        public int Insert_Update_DeleteEmployeeInfo(EEmployeeInfo objEE)
        {

            int ret = 0;
            ret = objEDAL.Insert_Update_DeleteEmployee(objEE);
            return ret;
        }

        public DataTable GetEmployeeInfo(int EmployeeId = 0)
        {
            DataTable dt = new DataTable();
            dt = objEDAL.GetEmployee(EmployeeId);
            return dt;
        }

        
    }
}
