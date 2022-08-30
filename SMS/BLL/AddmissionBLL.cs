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
    public class AddmissionBLL
    {
        AddmissionDAL objAddmission = new AddmissionDAL();
        
        public int Insert_deleteAddmissionInfo(int action, int AddmissionId, int RegSl, string RegistrationNo, int StudentId,  string Shift, int ClassId, int RollNo, int SessionYear, string AddmissionDate, int CreatedBy, bool IsActive)
        {

            int ret = 0;
            ret = objAddmission.Insert_deleteAddmission(  action,   AddmissionId , RegSl, RegistrationNo, StudentId, Shift,   ClassId,   RollNo,   SessionYear,   AddmissionDate,   CreatedBy,   IsActive); 
            return ret;
        }

      

        
    }
}
