using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using DAL.Entity;
using BLL;
using System.Data;

namespace SchoolManagementSystem.Setup
{
    public partial class ConInstitute : System.Web.UI.Page
    {
        InstituteBLL objInsBLL = new InstituteBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CommonDAL.ddlLoad(ddlInstitutionType, @"SELECT InstituteTypeId, InstituteTypeName FROM Conf_InstituteType ORDER BY InstituteTypeName", "InstituteTypeName", "InstituteTypeId");
                CommonDAL.ddlLoad(ddlDistrict, @"SELECT DistrictId, DistrictName FROM Conf_District ORDER BY DistrictName", "DistrictName", "DistrictId");
                ShowInstitute();

                btnSave.Text = "Save";
            }
        }

        protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            CommonDAL.ddlLoad(ddlUpazila, @"SELECT UpazilaId, UpazilaName FROM Conf_Upazila WHERE (DistrictId = "+ddlDistrict.SelectedValue+") ORDER BY UpazilaName", "UpazilaName", "UpazilaId");
        }
        

        private bool CheckFieldValue()
        {
            bool IsReq = false;
            if (txtEIIN.Text == "")
            {
                IsReq = true;
                rmMsg.FailureMessage="EIIN cant n be empty";
            }
            else if (txtInstituteName.Text == "")
            {
                IsReq = true;
                rmMsg.FailureMessage="Name cant be empty";
            }
            else if (txtEmail.Text == "")
            {
                IsReq = true;
                rmMsg.FailureMessage="Email cant be empty";
            }
            else if (txtPhone.Text == "")
            {
                IsReq = true;
                rmMsg.FailureMessage="phone cant be empty";
            }
            else if (txtFax.Text == "")
            {
                IsReq = true;
                rmMsg.FailureMessage="fax cant be empty";
            }
            else if (ddlInstitutionType.SelectedValue == "0")
            {
                IsReq = true;
                rmMsg.FailureMessage="institue cant be empty";
            }
            else if (ddlDistrict.SelectedValue == "0")
            {
                IsReq = true;
                rmMsg.FailureMessage="district cant be empty";
            }
            else if (ddlUpazila.SelectedValue == "0" || ddlUpazila.SelectedIndex == -1)
            {
                IsReq = true;
                rmMsg.FailureMessage="select upazila";
            }
            else if (txtAddress.Text == "")
            {
                IsReq = true;
                rmMsg.FailureMessage="address cant be empty";
            }

            return IsReq;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Save();
            ShowInstitute();
        }

        private void Save()
        {
            int save = 0;
            EInstitute objEIns = new EInstitute();

            objEIns.EIIN_RegistrationNo = txtEIIN.Text;
            objEIns.InstituteName = txtInstituteName.Text;
            objEIns.Email = txtEmail.Text;
            objEIns.Phone = txtPhone.Text;
            objEIns.Fax = txtFax.Text;
            objEIns.InstituteTypeId = int.Parse(ddlInstitutionType.SelectedValue);
            objEIns.DistrictId = int.Parse(ddlDistrict.SelectedValue);
            objEIns.UpazilaId = int.Parse(ddlUpazila.SelectedValue);
            objEIns.Address = txtAddress.Text;
            objEIns.EntryBy = int.Parse(Session["UserId"].ToString());
            objEIns.IsActive = true;

            if (btnSave.Text == "Save")
            {
                objEIns.action = 1;
                objEIns.InstituteId = 0;
            }
            else if (btnSave.Text=="Update")
            {
                objEIns.action = 2;
                objEIns.InstituteId = int.Parse(hdnUpdateInsId.Value);
            }

            save = objInsBLL.Insert_Update_DeleteInstituteInfo(objEIns);
            if (save>0)
            {
                rmMsg.SuccessMessage = "action complete";
            }
        }

        private void ShowInstitute()
        {
            
            DataTable dt = new DataTable();
            dt = objInsBLL.ShowGetInstituteInfo();

            if (dt.Rows.Count > 0)
            {
                gvInstituteList.DataSource = dt;
                gvInstituteList.DataBind();
            }
            else
            {
                gvInstituteList.DataSource = null;
                gvInstituteList.DataBind();
            }
        }

        protected void gvInstituteList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = int.Parse(e.CommandArgument.ToString());
            HiddenField hdnInstituteId = (HiddenField)gvInstituteList.Rows[rowIndex].FindControl("hdnInstituteId");

            
            

            if (e.CommandName == "editc")
            {
                FillControl(int.Parse(hdnInstituteId.Value));
                btnSave.Text = "Update";
            }
            else if (e.CommandName == "deletec")
            {
                EInstitute objEIns = new EInstitute();
                objEIns.action = 3;
                objEIns.InstituteId = int.Parse(hdnInstituteId.Value);
                objEIns.EIIN_RegistrationNo = txtEIIN.Text;
                objEIns.InstituteName = txtInstituteName.Text;
                objEIns.Email = txtEmail.Text;
                objEIns.Phone = txtPhone.Text;
                objEIns.Fax = txtFax.Text;
                objEIns.InstituteTypeId = 0;
                objEIns.DistrictId = 0;
                objEIns.UpazilaId = 0;
                objEIns.Address = txtAddress.Text;
                objEIns.EntryBy = int.Parse(Session["UserId"].ToString());
                objEIns.IsActive = true;

                objInsBLL.Insert_Update_DeleteInstituteInfo(objEIns);

                rmMsg.SuccessMessage = "delete done";
                ShowInstitute();
                
            }
        }
        private void FillControl(int InstituteId)
        {
            DataTable dt = new DataTable();
            dt = objInsBLL.ShowGetInstituteInfo(InstituteId);
            if (dt.Rows.Count>0)
            {
                hdnUpdateInsId.Value = InstituteId.ToString();
                txtEIIN.Text = dt.Rows[0]["EIIN_RegistrationNo"].ToString();
                txtInstituteName.Text = dt.Rows[0]["InstituteName"].ToString();
                txtEmail.Text = dt.Rows[0]["Email"].ToString();
                txtPhone.Text = dt.Rows[0]["Phone"].ToString();
                txtFax.Text = dt.Rows[0]["Fax"].ToString();
                txtAddress.Text = dt.Rows[0]["Address"].ToString();
                ddlDistrict.SelectedValue = dt.Rows[0]["DistrictId"].ToString();

                CommonDAL.ddlLoad(ddlUpazila, @"SELECT UpazilaId, UpazilaName FROM Conf_Upazila WHERE (DistrictId = " + ddlDistrict.SelectedValue + ") ORDER BY UpazilaName", "UpazilaName", "UpazilaId");

                ddlUpazila.SelectedValue = dt.Rows[0]["UpazilaId"].ToString();

                ddlInstitutionType.SelectedValue = dt.Rows[0]["InstituteTypeId"].ToString();
                
                btnSave.Text = "Update";
            }
        }
    }
}