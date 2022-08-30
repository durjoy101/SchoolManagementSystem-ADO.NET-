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

namespace SchoolManagementSystem.Tables
{
    public partial class EmployeeInfo : System.Web.UI.Page
    {


        EmployeeInfoBLL objEBLL = new EmployeeInfoBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CommonDAL.ddlLoad(ddlReligion, @"SELECT ReligionId, ReligionName FROM Conf_Religion ORDER BY ReligionName", "ReligionName", "ReligionId");
                CommonDAL.ddlLoad(ddlDesignation, @"SELECT DesignationId, DesignationName FROM Conf_Designation ORDER BY DesignationName", "DesignationName", "DesignationId");
                CommonDAL.ddlLoad(ddlDistrict, @"SELECT DistrictId, DistrictName FROM Conf_District ORDER BY DistrictName", "DistrictName", "DistrictId");

                ShowEmployee();
                btnSave.Text = "Save";
            }
            txtPhone.Attributes.Add("OnKeyUp", "chkNumber('" + txtPhone.ClientID + "')");
        }
        protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            CommonDAL.ddlLoad(ddlUpazila, @"SELECT UpazilaId, UpazilaName FROM Conf_Upazila WHERE (DistrictId = " + ddlDistrict.SelectedValue + ") ORDER BY UpazilaName", "UpazilaName", "UpazilaId");
        }


        //private bool CheckFieldValue()
        //{
        //    bool IsReq = false;
        //    if (txtEIIN.Text == "")
        //    {
        //        IsReq = true;
        //        rmMsg.FailureMessage = "EIIN cant n be empty";
        //    }
        //    else if (txtInstituteName.Text == "")
        //    {
        //        IsReq = true;
        //        rmMsg.FailureMessage = "Name cant be empty";
        //    }
        //    else if (txtEmail.Text == "")
        //    {
        //        IsReq = true;
        //        rmMsg.FailureMessage = "Email cant be empty";
        //    }
        //    else if (txtPhone.Text == "")
        //    {
        //        IsReq = true;
        //        rmMsg.FailureMessage = "phone cant be empty";
        //    }
        //    else if (txtFax.Text == "")
        //    {
        //        IsReq = true;
        //        rmMsg.FailureMessage = "fax cant be empty";
        //    }
        //    else if (ddlInstitutionType.SelectedValue == "0")
        //    {
        //        IsReq = true;
        //        rmMsg.FailureMessage = "institue cant be empty";
        //    }
        //    else if (ddlDistrict.SelectedValue == "0")
        //    {
        //        IsReq = true;
        //        rmMsg.FailureMessage = "district cant be empty";
        //    }
        //    else if (ddlUpazila.SelectedValue == "0" || ddlUpazila.SelectedIndex == -1)
        //    {
        //        IsReq = true;
        //        rmMsg.FailureMessage = "select upazila";
        //    }
        //    else if (txtAddress.Text == "")
        //    {
        //        IsReq = true;
        //        rmMsg.FailureMessage = "address cant be empty";
        //    }

        //    return IsReq;
        //}

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Save();
            ShowEmployee();
        }

        private void Save()
        {
            int save = 0;
            EEmployeeInfo objEE = new EEmployeeInfo();

            objEE.FirstName = txtFirsteName.Text;
            objEE.LastName = txtLastName.Text;
            objEE.EmployeeType = ddlEmployeeType.SelectedValue;
            objEE.DesignationId = int.Parse(ddlDesignation.SelectedValue);
            objEE.StartingSalary = Convert.ToDouble(txtStartingSalary.Text);
            objEE.Nationality = txtNationality.Text;
            objEE.NID = txtNID.Text;
            objEE.DOB = txtDOB.Text;
            objEE.JoiningDate = txtDOJ.Text;
            objEE.ReligionId = int.Parse(ddlReligion.SelectedValue);
            objEE.DistrictId = int.Parse(ddlDistrict.SelectedValue);
            objEE.UpazilaId = int.Parse(ddlUpazila.SelectedValue);
            objEE.Address = txtAddress.Text;
            objEE.Email = txtEmail.Text;
            objEE.ContactNo = txtPhone.Text;
            objEE.Gender = ddlGender.SelectedValue;
            objEE.BloodGroup = ddlBloodGroup.SelectedValue;
            objEE.EmpImg = "1.jpg";
            objEE.IsActive = true;
            objEE.EntryBy = int.Parse(Session["UserId"].ToString());




            if (btnSave.Text == "Save")
            {
                objEE.action = 1;
                objEE.EmployeeId = 0;
            }
            else if (btnSave.Text == "Update")
            {
                objEE.action = 2;
                objEE.EmployeeId = int.Parse(hdnUpdateEmployeeId.Value);
            }

            save = objEBLL.Insert_Update_DeleteEmployeeInfo(objEE);
            if (save > 0)
            {
                rmMsg.SuccessMessage = "action complete";
            }
        }

        private void ShowEmployee()
        {

            DataTable dt = new DataTable();
            dt = objEBLL.GetEmployeeInfo();

            if (dt.Rows.Count > 0)
            {
                gvEmployee.DataSource = dt;
                gvEmployee.DataBind();
            }
            else
            {
                gvEmployee.DataSource = null;
                gvEmployee.DataBind();
            }
        }

        protected void gvEmployee_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = int.Parse(e.CommandArgument.ToString());
            HiddenField hdnEmployeeId = (HiddenField)gvEmployee.Rows[rowIndex].FindControl("hdnEmployeeId");




            if (e.CommandName == "editc")
            {
                FillControl(int.Parse(hdnEmployeeId.Value));
                btnSave.Text = "Update";
            }
            else if (e.CommandName == "deletec")
            {
                EEmployeeInfo objEE = new EEmployeeInfo();
                objEE.action = 3;
                objEE.EmployeeId = int.Parse(hdnEmployeeId.Value);
                objEE.FirstName = txtFirsteName.Text;
                objEE.LastName = txtLastName.Text;
                objEE.EmployeeType = ddlEmployeeType.SelectedValue;
                objEE.DesignationId = 0;
                objEE.StartingSalary = 0;
                objEE.Nationality = txtNationality.Text;
                objEE.NID = txtNID.Text;
                objEE.DOB = txtDOB.Text;
                objEE.JoiningDate = txtDOJ.Text;
                objEE.ReligionId = 0;
                objEE.DistrictId = 0;
                objEE.UpazilaId = 0;
                objEE.Address = txtAddress.Text;
                objEE.Email = txtEmail.Text;
                objEE.ContactNo = txtPhone.Text;
                objEE.Gender = ddlGender.SelectedValue;
                objEE.BloodGroup = ddlBloodGroup.SelectedValue;
                objEE.EmpImg = "1.jpg";
                objEE.IsActive = true;
                objEE.EntryBy = int.Parse(Session["UserId"].ToString());

                objEBLL.Insert_Update_DeleteEmployeeInfo(objEE);

                rmMsg.SuccessMessage = "delete done";
                ShowEmployee();
            }
        }
        private void FillControl(int EmployeeId)
        {
            DataTable dt = new DataTable();
            dt = objEBLL.GetEmployeeInfo(EmployeeId);
            if (dt.Rows.Count > 0)
            {
                hdnUpdateEmployeeId.Value = EmployeeId.ToString();

                txtFirsteName.Text = dt.Rows[0]["FirstName"].ToString();
                txtLastName.Text = dt.Rows[0]["LastName"].ToString(); 
                ddlEmployeeType.SelectedValue = dt.Rows[0]["EmployeeType"].ToString();
                ddlDesignation.SelectedValue = dt.Rows[0]["DesignationId"].ToString();
                txtStartingSalary.Text = dt.Rows[0]["StartingSalary"].ToString(); 
                txtNationality.Text = dt.Rows[0]["Nationality"].ToString();
                txtNID.Text = dt.Rows[0]["NID"].ToString();
                txtDOB.Text = (Convert.ToDateTime(dt.Rows[0]["DOB"].ToString())).ToString("yyyy-MM-dd");
                txtDOJ.Text = (Convert.ToDateTime(dt.Rows[0]["JoiningDate"].ToString())).ToString("yyyy-MM-dd");
                ddlReligion.SelectedValue = dt.Rows[0]["ReligionId"].ToString();
                ddlDistrict.SelectedValue = dt.Rows[0]["DistrictId"].ToString();

                CommonDAL.ddlLoad(ddlUpazila, @"SELECT UpazilaId, UpazilaName FROM Conf_Upazila WHERE (DistrictId = " + ddlDistrict.SelectedValue + ") ORDER BY UpazilaName", "UpazilaName", "UpazilaId");

                ddlUpazila.SelectedValue = dt.Rows[0]["UpazilaId"].ToString();
                txtAddress.Text = dt.Rows[0]["Address"].ToString();
                txtEmail.Text = dt.Rows[0]["Email"].ToString();
                txtPhone.Text = dt.Rows[0]["ContactNo"].ToString();
                ddlGender.SelectedValue = dt.Rows[0]["Gender"].ToString();
                ddlBloodGroup.SelectedValue = dt.Rows[0]["BloodGroup"].ToString();

                btnSave.Text = "Update";
            }
        }

        
    }
}
