using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.Entity;
using DAL;
using BLL;
using System.Data;

namespace SchoolManagementSystem.Tables
{
    public partial class StudentRegistration : System.Web.UI.Page
    {
        AuthBLL objAuthSR = new AuthBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadGridStudentReg();
                CommonDAL.ddlLoad(ddlReligion, "select ReligionId,ReligionName from [dbo].[Conf_Religion]", "ReligionName", "ReligionId");
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int result = SaveUReg();
            if (result > 0)
            {
                
                rmMsg.SuccessMessage = "Save Success";
                LoadGridStudentReg();
            }
            else
            {
                rmMsg.FailureMessage = "Save Fail";
            }
        }

        private int SaveUReg()
        {
            int result = 0;
            EStudentReg objEStudent = new EStudentReg();
            objEStudent.Action = 1;
            objEStudent.StudentId = 0;
            objEStudent.FirstName = txtFirstName.Text.Trim();
            objEStudent.LastName = txtLastName.Text.Trim();
            objEStudent.FathersName = txtFathersName.Text.Trim();
            objEStudent.FathersOccupation = txtFathersOccupation.Text.Trim();
            objEStudent.FathersContact = txtFathersContact.Text.Trim();
            objEStudent.MothersName = txtMothersName.Text.Trim();
            objEStudent.MothersOccupation = txtMothersOccupation.Text.Trim();
            objEStudent.MothersContact = txtMothersContact.Text.Trim();
            objEStudent.PresentAddress = txtPresentAddress.Text.Trim();
            objEStudent.PermanentAddress = txtPermanentAddress.Text.Trim();
            objEStudent.ContactNo = txtContactNumber.Text.Trim();
            objEStudent.Email = txtEmail.Text.Trim();
            objEStudent.Nationality = txtNationality.Text.Trim();

            objEStudent.Gender = ddlGender.SelectedValue;
            objEStudent.ReligionId = int.Parse(ddlReligion.SelectedValue);
            objEStudent.DateOfBirth = txtDateOfBirth.Text;
            objEStudent.BloodGroup = ddlBloodGroup.SelectedValue;
            objEStudent.GuardianName = txtguardianName.Text;
            objEStudent.GuardianContact = txtGuardianContact.Text;

            result = objAuthSR.InsertUpdateDelete_StudentRegInfo(objEStudent);
            return result;
        }

        private void LoadGridStudentReg()
        {
            DataTable dt = new DataTable();
            dt = objAuthSR.LoadGridStudentRegInfo();
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

        
        private void FillControl(int StudentId)
        {
            DataTable dt = new DataTable();
            dt = objAuthSR.LoadGridStudentRegInfo(StudentId);
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

        protected void gvStudentRegistration_RowCommand1(object sender, GridViewCommandEventArgs e)
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
                EStudentReg objEStudent = new EStudentReg();
                objEStudent.Action = 3;
                objEStudent.StudentId = int.Parse(hdnStudentId.Value);
                objEStudent.FirstName = txtFirstName.Text;
                objEStudent.LastName = txtLastName.Text;
                objEStudent.FathersName = txtFathersName.Text;
                objEStudent.FathersOccupation = txtFathersOccupation.Text;
                objEStudent.FathersContact = txtFathersContact.Text;
                objEStudent.MothersName = txtMothersName.Text;
                objEStudent.MothersOccupation = txtMothersOccupation.Text;
                objEStudent.MothersContact = txtMothersContact.Text;
                objEStudent.PresentAddress = txtPresentAddress.Text;
                objEStudent.PermanentAddress = txtPermanentAddress.Text;
                objEStudent.ContactNo = txtContactNumber.Text;
                objEStudent.Email = txtEmail.Text;
                objEStudent.Nationality = txtNationality.Text;
                objEStudent.Gender = ddlGender.SelectedValue;
                objEStudent.ReligionId = int.Parse(ddlReligion.SelectedValue);
                objEStudent.DateOfBirth = txtDateOfBirth.Text;
                objEStudent.BloodGroup = ddlBloodGroup.SelectedValue;
                objEStudent.GuardianName = txtguardianName.Text;
                objEStudent.GuardianContact = txtGuardianContact.Text;
                objEStudent.IsActive = 1;
                objEStudent.EntryBy = int.Parse(Session["UserId"].ToString());

                objAuthSR.InsertUpdateDelete_StudentRegInfo(objEStudent);

                rmMsg.SuccessMessage = "delete done";
                LoadGridStudentReg();
            }
        }
    }
}