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
    public partial class StudentList : System.Web.UI.Page
    {
        AddmissionBLL objAddmission = new AddmissionBLL();
        DummyStudentBLL objDSBLL = new DummyStudentBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CommonDAL.ddlLoad(ddlReligion, @"SELECT ReligionId, ReligionName FROM Conf_Religion ORDER BY ReligionName", "ReligionName", "ReligionId");

                LoadGrid();
            }
        }

        private void LoadGrid()
        {
            string stName = txtFirstName.Text.Trim();
            int Rel = int.Parse(ddlReligion.SelectedValue);
            string gender = ddlGender.SelectedValue;
            DataTable dt = new DataTable();
            dt = objDSBLL.StudentSearchInfo(stName, Rel, gender, 0);

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


        protected void btnSearch_Click(object sender, EventArgs e)
        {
            LoadGrid();
        }

        protected void gvStudentRegistration_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = int.Parse(e.CommandArgument.ToString());
            HiddenField hdnStudentId = (HiddenField)gvStudentRegistration.Rows[rowIndex].FindControl("hdnStudentId");
            HiddenField hdnAddmissionId = (HiddenField)gvStudentRegistration.Rows[rowIndex].FindControl("hdnAddmissionId");




            if (e.CommandName == "addmission")
            {
                string url = "StudentAddmission.aspx?StudentId=" + hdnStudentId.Value;
                string totalUrl = "var Mleft = (screen.width/2)-(800/2);var Mtop = (screen.height/2)-(500/2);window.open( '" + url + "', null, 'height=500,width=820,status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );";
                ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", totalUrl, true);
            }
            else if (e.CommandName == "adcancel")
            {
                objAddmission.Insert_deleteAddmissionInfo(2,int.Parse(hdnAddmissionId.Value),0,"0",0,"",0,0,0,"",0,true);
                LoadGrid();
            }
            else if (e.CommandName == "deletec")
            {

            }
        }

        protected void gvStudentRegistration_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            for (int i = 0; i < gvStudentRegistration.Rows.Count; i++)
            {
                LinkButton lbAdCancel = (LinkButton)gvStudentRegistration.Rows[i].FindControl("lbAdCancel");
                HiddenField hdnAddmissionId = (HiddenField)gvStudentRegistration.Rows[i].FindControl("hdnAddmissionId");
                Label adLabel = (Label)gvStudentRegistration.Rows[i].FindControl("txtAdmissionInfo");

                if (int.Parse(hdnAddmissionId.Value) == 0)
                {
                    lbAdCancel.Visible = false;
                    adLabel.Text = "Not Admitted";
                    
                }

            }
        }
    }
}