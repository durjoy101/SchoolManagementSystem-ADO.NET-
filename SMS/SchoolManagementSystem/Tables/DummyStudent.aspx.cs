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
    public partial class DummyStudent : System.Web.UI.Page
    {


        DummyStudentBLL objDSBLL = new DummyStudentBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CommonDAL.ddlLoad(ddlReligion, @"SELECT ReligionId, ReligionName FROM Conf_Religion ORDER BY ReligionName", "ReligionName", "ReligionId");

                ShowInstitute();
                btnSave.Text = "Save";
            }
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

        protected void btnSave_Click1(object sender, EventArgs e)
        {
            Save();
            ShowInstitute();
        }

        private void Save()
        {
            int save = 0;
            EDummyStudent objEDS = new EDummyStudent();

            objEDS.FirstName = txtFirstName.Text;
            objEDS.LastName = txtLastName.Text;
            objEDS.FathersName = txtFathersName.Text;
            objEDS.FathersOccupation = txtFathersOccupation.Text;
            objEDS.FathersContact = txtFathersContact.Text;
            objEDS.MothersName = txtMothersName.Text;
            objEDS.MothersOccupation = txtMothersOccupation.Text;
            objEDS.MothersContact = txtMothersContact.Text;
            objEDS.PresentAddress = txtPresentAddress.Text;
            objEDS.PermanentAddress = txtPermanentAddress.Text;
            objEDS.ContactNo = txtContactNumber.Text;
            objEDS.Email = txtEmail.Text;
            objEDS.Nationality = txtNationality.Text;
            objEDS.Gender = ddlGender.SelectedValue;
            objEDS.ReligionId = int.Parse(ddlReligion.SelectedValue);
            objEDS.DateOfBirth = txtDateOfBirth.Text;
            objEDS.BloodGroup = ddlBloodGroup.SelectedValue;
            objEDS.GuardianName = txtguardianName.Text;
            objEDS.GuardianContact = txtGuardianContact.Text;
            objEDS.IsActive = true;




            if (btnSave.Text == "Save")
            {
                objEDS.action = 1;
                objEDS.StudentId = 0;
            }
            else if (btnSave.Text == "Update")
            {
                objEDS.action = 2;
                objEDS.StudentId = int.Parse(hdnUpdateStudentId.Value);
            }

            save = objDSBLL.Insert_Update_DeleteDummyStudentInfo(objEDS);
            if (save > 0)
            {
                rmMsg.SuccessMessage = "action complete";
            }
        }

        private void ShowInstitute()
        {

            DataTable dt = new DataTable();
            dt = objDSBLL.ShowGetDummyStudentInfo();

            if (dt.Rows.Count > 0)
            {
                gvStudentRegistration.DataSource = dt;
                gvStudentRegistration.DataBind();
            }
            else
            {
                gvStudentRegistration.DataSource = null;
                gvStudentRegistration.DataBind();
            }
        }

        protected void gvStudentRegistration_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = int.Parse(e.CommandArgument.ToString());
            HiddenField hdnStudentId = (HiddenField)gvStudentRegistration.Rows[rowIndex].FindControl("hdnStudentId");




            if (e.CommandName == "editc")
            {
                FillControl(int.Parse(hdnStudentId.Value));
                btnSave.Text = "Update";
            }
            else if (e.CommandName == "deletec")
            {
                EDummyStudent objEDS = new EDummyStudent();
                objEDS.action = 3;
                objEDS.StudentId = int.Parse(hdnStudentId.Value);
                objEDS.FirstName = txtFirstName.Text;
                objEDS.LastName = txtLastName.Text;
                objEDS.FathersName = txtFathersName.Text;
                objEDS.FathersOccupation = txtFathersOccupation.Text;
                objEDS.FathersContact = txtFathersContact.Text;
                objEDS.MothersName = txtMothersName.Text;
                objEDS.MothersOccupation = txtMothersOccupation.Text;
                objEDS.MothersContact = txtMothersContact.Text;
                objEDS.PresentAddress = txtPresentAddress.Text;
                objEDS.PermanentAddress = txtPermanentAddress.Text;
                objEDS.ContactNo = txtContactNumber.Text;
                objEDS.Email = txtEmail.Text;
                objEDS.Nationality = txtNationality.Text;
                objEDS.Gender = ddlGender.SelectedValue;
                objEDS.ReligionId = int.Parse(ddlReligion.SelectedValue);
                objEDS.DateOfBirth = txtDateOfBirth.Text;
                objEDS.BloodGroup = ddlBloodGroup.SelectedValue;
                objEDS.GuardianName = txtguardianName.Text;
                objEDS.GuardianContact = txtGuardianContact.Text;
                objEDS.IsActive = true;
                objEDS.EntryBy = int.Parse(Session["UserId"].ToString());

                objDSBLL.Insert_Update_DeleteDummyStudentInfo(objEDS);

                rmMsg.SuccessMessage = "delete done";
                ShowInstitute();
            }
        }
        private void FillControl(int StudentId)
        {
            DataTable dt = new DataTable();
            dt = objDSBLL.ShowGetDummyStudentInfo(StudentId);
            if (dt.Rows.Count > 0)
            {
                hdnUpdateStudentId.Value = StudentId.ToString();

                txtFirstName.Text = dt.Rows[0]["FirstName"].ToString();
                txtLastName.Text = dt.Rows[0]["LastName"].ToString();
                txtFathersName.Text = dt.Rows[0]["FathersName"].ToString();
                txtFathersContact.Text = dt.Rows[0]["FathersContact"].ToString();
                txtFathersOccupation.Text = dt.Rows[0]["FathersOccupation"].ToString();
                txtMothersName.Text = dt.Rows[0]["MothersName"].ToString();
                txtMothersOccupation.Text = dt.Rows[0]["MothersOccupation"].ToString();
                txtMothersContact.Text = dt.Rows[0]["MothersContact"].ToString();
                txtPresentAddress.Text = dt.Rows[0]["PresentAddress"].ToString();
                txtPermanentAddress.Text = dt.Rows[0]["PermanentAddress"].ToString();
                txtEmail.Text = dt.Rows[0]["Email"].ToString();
                txtContactNumber.Text = dt.Rows[0]["ContactNo"].ToString();
                txtNationality.Text = dt.Rows[0]["Nationality"].ToString();
                ddlGender.SelectedValue = dt.Rows[0]["Gender"].ToString();
                ddlBloodGroup.SelectedValue = dt.Rows[0]["BloodGroup"].ToString();
                ddlReligion.SelectedValue = dt.Rows[0]["ReligionId"].ToString();
                txtDateOfBirth.Text = dt.Rows[0]["DateOfBirth"].ToString();
                txtguardianName.Text = dt.Rows[0]["GuardianName"].ToString();
                txtGuardianContact.Text = dt.Rows[0]["GuardianContact"].ToString();
          

                btnSave.Text = "Update";
            }
        }

        
    }      
}
