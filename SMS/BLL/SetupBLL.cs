using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BLL
{
    public class SetupBLL
    {
        SetupDAL objSetup = new SetupDAL();
        public int InsertUpdateDelete_CategoryInfo(int action, string category, int UserId, int catid = 0)
        {
            int ret = 0;
            ret = objSetup.InsertUpdateDelete_Category( action,  category, UserId,  catid );
            return ret;
        }

       

        public int InsertUpdateDelete_SubCategoryInfo(int action, int CategoryId, string Subcategory, int UserId, int Subcatid = 0)
        {
            int ret = 0;
            ret = objSetup.InsertUpdateDelete_SubCategory(action, CategoryId, Subcategory, UserId, Subcatid);
            return ret;
        }

        public int InsertUpdateDelete_SitePostInfo(int action, int CategoryId, int SubcategoryId, string Title, string Description, string ShortDescription, string image, int UserId, int id = 0)
        {
            int ret = 0;
            ret = objSetup.InsertUpdateDelete_SitePost(action, CategoryId,  SubcategoryId,  Title,  Description,  ShortDescription,  image,  UserId,  id);
            return ret;
        }
        public int InsertUpdateDelete_DesignationInfo(int action, string DesignationName, int UserId, int DesignationId = 0)
        {
            int ret = 0;
            ret = objSetup.InsertUpdateDelete_Designation(action, DesignationName, UserId, DesignationId);
            return ret;
        }
        public int InsertUpdateDelete_UpazilaInfo(int action, int DistrictId, string Upazila, int UserId, int UpazilaId = 0)
        {
            int ret = 0;
            ret = objSetup.InsertUpdateDelete_Upazila(action, DistrictId,Upazila, UserId, UpazilaId);
            return ret;
        }
        public int InsertUpdateDelete_DistrictInfo(int action, string DistrictName, int UserId, int DistrictId = 0)
        {
            int ret = 0;
            ret = objSetup.InsertUpdateDelete_District(action, DistrictName, UserId, DistrictId);
            return ret;
        }
        public int InsertUpdateDelete_ClassInfo(int action, string ClassName, int UserId, int ClassId = 0)
        {
            int ret = 0;
            ret = objSetup.InsertUpdateDelete_Class(action, ClassName, UserId, ClassId);
            return ret;
        }
        public int InsertUpdateDelete_SubjectInfo(int action, string SubjectName, int UserId, int SubjectId = 0)
        {
            int ret = 0;
            ret = objSetup.InsertUpdateDelete_Subject(action, SubjectName, UserId, SubjectId);
            return ret;
        }
        public int InsertUpdateDelete_InstitutionTypeInfo(int action, string InstitutionTypeName, int UserId, int InstitutionTypeId = 0)
        {
            int ret = 0;
            ret = objSetup.InsertUpdateDelete_InstitutionType(action, InstitutionTypeName, UserId, InstitutionTypeId);
            return ret;
        }
        public int InsertUpdateDelete_ReligionInfo(int action, string ReligionName, int ReligionId = 0)
        {
            int ret = 0;
            ret = objSetup.InsertUpdateDelete_Religion(action, ReligionName, ReligionId);
            return ret;
        }


        public DataTable Set_getCategoryInfo()
        {
            DataTable ret = new DataTable();
            ret = objSetup.Set_getCategory();
            return ret;
        }
        public DataTable Set_getSubCategoryInfo()
        {
            DataTable ret = new DataTable();
            ret = objSetup.Set_getSubCategory();
            return ret;
        }
        

        public DataTable Set_getSitePostInfo()
        {
            DataTable ret = new DataTable();
            ret = objSetup.Set_getSitePost();
            return ret;
        }
        public DataTable Set_getDesignationInfo()
        {
            DataTable ret = new DataTable();
            ret = objSetup.Set_getDesignation();
            return ret;
        }
        public DataTable Set_getUpazilaInfo()
        {
            DataTable ret = new DataTable();
            ret = objSetup.Set_getUpazila();
            return ret;
        }
        public DataTable Set_getDistrictInfo()
        {
            DataTable ret = new DataTable();
            ret = objSetup.Set_getDistrict();
            return ret;
        }
        public DataTable Set_getClassInfo()
        {
            DataTable ret = new DataTable();
            ret = objSetup.Set_getClass();
            return ret;
        }
        public DataTable Set_getSubjectInfo()
        {
            DataTable ret = new DataTable();
            ret = objSetup.Set_getSubject();
            return ret;
        }
        public DataTable Set_getInstitutionTypeInfo()
        {
            DataTable ret = new DataTable();
            ret = objSetup.Set_getInstitutionType();
            return ret;
        }
        public DataTable Set_getReligionInfo()
        {
            DataTable ret = new DataTable();
            ret = objSetup.Set_getReligion();
            return ret;
        }
    }
}
