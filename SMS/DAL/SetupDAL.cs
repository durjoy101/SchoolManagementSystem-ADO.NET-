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
    public class SetupDAL
    {
        public int InsertUpdateDelete_Category(int action, string category, int UserId, int catid=0)
        {
            int ret = 0;

            Database db;
            DbCommand dbCmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbCmd = db.GetStoredProcCommand("conSp_InsertUpdateCategory");
            db.AddInParameter(dbCmd, "action", DbType.Int32, action);
            db.AddInParameter(dbCmd, "CategoryId", DbType.Int32, catid);
            db.AddInParameter(dbCmd, "Category", DbType.String, category);
            db.AddInParameter(dbCmd, "EntryBy", DbType.Int32, UserId);
          
            ret = db.ExecuteNonQuery(dbCmd);

            return ret;
        }

        public int InsertUpdateDelete_SubCategory(int action,int CategoryId, string Subcategory, int UserId, int Subcatid = 0)
        {
            int ret = 0;

            Database db;
            DbCommand dbCmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbCmd = db.GetStoredProcCommand("conSp_InsertUpdateSubCategory");
            db.AddInParameter(dbCmd, "action", DbType.Int32, action);
            db.AddInParameter(dbCmd, "CategoryId", DbType.Int32, CategoryId);
            db.AddInParameter(dbCmd, "SubCategory", DbType.String, Subcategory);
            db.AddInParameter(dbCmd, "EntryBy", DbType.Int32, UserId);
            db.AddInParameter(dbCmd, "SubCategoryId", DbType.Int32, Subcatid);

            ret = db.ExecuteNonQuery(dbCmd);

            return ret;
        }

        public int InsertUpdateDelete_SitePost(int action, int CategoryId, int SubcategoryId, string Title, string Description, string ShortDescription, string image,  int UserId, int id=0 )
        {
            int ret = 0;

            Database db;
            DbCommand dbCmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbCmd = db.GetStoredProcCommand("conSp_InsertUpdateSitePost");
            db.AddInParameter(dbCmd, "action", DbType.Int32, action);
            db.AddInParameter(dbCmd, "CategoryId", DbType.Int32, CategoryId);
            db.AddInParameter(dbCmd, "SubCategoryId", DbType.Int32, SubcategoryId);
            db.AddInParameter(dbCmd, "Title", DbType.String, Title);
            db.AddInParameter(dbCmd, "Description", DbType.String, Description);
            db.AddInParameter(dbCmd, "ShortDescription", DbType.String, ShortDescription);
            db.AddInParameter(dbCmd, "ImageName", DbType.String, image);
            db.AddInParameter(dbCmd, "EntryBy", DbType.Int32, UserId);
            db.AddInParameter(dbCmd, "id", DbType.Int32, id);


            ret = db.ExecuteNonQuery(dbCmd);

            return ret;
        }

        public int InsertUpdateDelete_Designation(int action, string DesignationName, int UserId, int DesignationId = 0)
        {
            int ret = 0;

            Database db;
            DbCommand dbCmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbCmd = db.GetStoredProcCommand("conSp_InsertUpdateDesignation");
            db.AddInParameter(dbCmd, "action", DbType.Int32, action);
            db.AddInParameter(dbCmd, "DesignationId", DbType.Int32, DesignationId);
            db.AddInParameter(dbCmd, "DesignationName", DbType.String, DesignationName);
            db.AddInParameter(dbCmd, "EntryBy", DbType.Int32, UserId);

            ret = db.ExecuteNonQuery(dbCmd);

            return ret;
        }

        public int InsertUpdateDelete_Upazila(int action, int DistrictId, string Upazila, int UserId, int UpazilaId = 0)
        {
            int ret = 0;

            Database db;
            DbCommand dbCmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbCmd = db.GetStoredProcCommand("conSp_InsertUpdateUpazila");
            db.AddInParameter(dbCmd, "action", DbType.Int32, action);
            db.AddInParameter(dbCmd, "DistrictId", DbType.Int32, DistrictId);
            db.AddInParameter(dbCmd, "UpazilaName", DbType.String, Upazila);
            db.AddInParameter(dbCmd, "EntryBy", DbType.Int32, UserId);
            db.AddInParameter(dbCmd, "UpazilaId", DbType.Int32, UpazilaId);

            ret = db.ExecuteNonQuery(dbCmd);

            return ret;
        }
        public int InsertUpdateDelete_District(int action, string DistrictName, int UserId, int DistrictId = 0)
        {
            int ret = 0;

            Database db;
            DbCommand dbCmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbCmd = db.GetStoredProcCommand("conSp_InsertUpdateDistrict");
            db.AddInParameter(dbCmd, "action", DbType.Int32, action);
            db.AddInParameter(dbCmd, "DistrictId", DbType.Int32, DistrictId);
            db.AddInParameter(dbCmd, "DistrictName", DbType.String, DistrictName);
            db.AddInParameter(dbCmd, "EntryBy", DbType.Int32, UserId);

            ret = db.ExecuteNonQuery(dbCmd);

            return ret;
        }
        public int InsertUpdateDelete_Class(int action, string ClassName, int UserId, int ClassId = 0)
        {
            int ret = 0;

            Database db;
            DbCommand dbCmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbCmd = db.GetStoredProcCommand("conSp_InsertUpdateClass");
            db.AddInParameter(dbCmd, "action", DbType.Int32, action);
            db.AddInParameter(dbCmd, "ClassId", DbType.Int32, ClassId);
            db.AddInParameter(dbCmd, "ClassName", DbType.String, ClassName);
            db.AddInParameter(dbCmd, "EntryBy", DbType.Int32, UserId);

            ret = db.ExecuteNonQuery(dbCmd);

            return ret;
        }
        public int InsertUpdateDelete_Subject(int action, string SubjectName, int UserId, int SubjectId = 0)
        {
            int ret = 0;

            Database db;
            DbCommand dbCmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbCmd = db.GetStoredProcCommand("conSp_InsertUpdateSubject");
            db.AddInParameter(dbCmd, "action", DbType.Int32, action);
            db.AddInParameter(dbCmd, "SubjectId", DbType.Int32, SubjectId);
            db.AddInParameter(dbCmd, "SubjectName", DbType.String, SubjectName);
            db.AddInParameter(dbCmd, "EntryBy", DbType.Int32, UserId);

            ret = db.ExecuteNonQuery(dbCmd);

            return ret;
        }
        public int InsertUpdateDelete_InstitutionType(int action, string InstitutionTypeName, int UserId, int InstitutionTypeId = 0)
        {
            int ret = 0;

            Database db;
            DbCommand dbCmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbCmd = db.GetStoredProcCommand("conSp_InsertUpdateInstituteType");
            db.AddInParameter(dbCmd, "action", DbType.Int32, action);
            db.AddInParameter(dbCmd, "InstituteTypeId", DbType.Int32, InstitutionTypeId);
            db.AddInParameter(dbCmd, "InstituteTypeName", DbType.String, InstitutionTypeName);
            db.AddInParameter(dbCmd, "EntryBy", DbType.Int32, UserId);

            ret = db.ExecuteNonQuery(dbCmd);

            return ret;
        }
        public int InsertUpdateDelete_Religion(int action, string ReligionName, int ReligionId = 0)
        {
            int ret = 0;

            Database db;
            DbCommand dbCmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbCmd = db.GetStoredProcCommand("conSp_InsertUpdateReligion");
            db.AddInParameter(dbCmd, "action", DbType.Int32, action);
            db.AddInParameter(dbCmd, "ReligionId", DbType.Int32, ReligionId);
            db.AddInParameter(dbCmd, "ReligionName", DbType.String, ReligionName);

            ret = db.ExecuteNonQuery(dbCmd);

            return ret;
        }


        public DataTable Set_getCategory()
        {
            DataTable dt = new DataTable();
            Database db;
            DbCommand dbCmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbCmd = db.GetStoredProcCommand("SetupSp_GetCategory");
            dt = db.ExecuteDataSet(dbCmd).Tables[0];
            return dt;
        }

        public DataTable Set_getSubCategory()
        {
            DataTable dt = new DataTable();
            Database db;
            DbCommand dbCmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbCmd = db.GetStoredProcCommand("SetupSp_GetSubCategory");
            dt = db.ExecuteDataSet(dbCmd).Tables[0];
            return dt;
        }

        public DataTable Set_getSitePost()
        {
            DataTable dt = new DataTable();
            Database db;
            DbCommand dbCmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbCmd = db.GetStoredProcCommand("SetupSp_GetSitePost");
            dt = db.ExecuteDataSet(dbCmd).Tables[0];
            return dt;
        }

        public DataTable Set_getDesignation()
        {
            DataTable dt = new DataTable();
            Database db;
            DbCommand dbCmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbCmd = db.GetStoredProcCommand("SetupSp_GetDesignation");
            dt = db.ExecuteDataSet(dbCmd).Tables[0];
            return dt;
        }
        public DataTable Set_getUpazila()
        {
            DataTable dt = new DataTable();
            Database db;
            DbCommand dbCmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbCmd = db.GetStoredProcCommand("SetupSp_GetUpazila");
            dt = db.ExecuteDataSet(dbCmd).Tables[0];
            return dt;
        }
        public DataTable Set_getDistrict()
        {
            DataTable dt = new DataTable();
            Database db;
            DbCommand dbCmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbCmd = db.GetStoredProcCommand("SetupSp_GetDistrict");
            dt = db.ExecuteDataSet(dbCmd).Tables[0];
            return dt;
        }
        public DataTable Set_getClass()
        {
            DataTable dt = new DataTable();
            Database db;
            DbCommand dbCmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbCmd = db.GetStoredProcCommand("SetupSp_GetClass");
            dt = db.ExecuteDataSet(dbCmd).Tables[0];
            return dt;
        }
        public DataTable Set_getSubject()
        {
            DataTable dt = new DataTable();
            Database db;
            DbCommand dbCmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbCmd = db.GetStoredProcCommand("SetupSp_GetSubject");
            dt = db.ExecuteDataSet(dbCmd).Tables[0];
            return dt;
        }
        public DataTable Set_getInstitutionType()
        {
            DataTable dt = new DataTable();
            Database db;
            DbCommand dbCmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbCmd = db.GetStoredProcCommand("SetupSp_GetInstituteType");
            dt = db.ExecuteDataSet(dbCmd).Tables[0];
            return dt;
        }
        public DataTable Set_getReligion()
        {
            DataTable dt = new DataTable();
            Database db;
            DbCommand dbCmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbCmd = db.GetStoredProcCommand("SetupSp_GetReligion");
            dt = db.ExecuteDataSet(dbCmd).Tables[0];
            return dt;
        }
    }
}
