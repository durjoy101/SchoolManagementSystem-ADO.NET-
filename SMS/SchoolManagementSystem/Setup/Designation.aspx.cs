using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace SchoolManagementSystem.Setup
{
    public partial class Designation : System.Web.UI.Page
    {
        SetupBLL objSetup = new SetupBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnSave.Text = "Save";
                LoadGrid();
            }
        }

        private void LoadGrid()
        {
            DataTable dt = new DataTable();
            dt = objSetup.Set_getDesignationInfo();
            if (dt.Rows.Count > 0)
            {
                gvDesignation.DataSource = dt;
                gvDesignation.DataBind();
            }
            else
            {
                gvDesignation.DataSource = null;
                gvDesignation.DataBind();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.Text == "Save")
            {
                int Save = objSetup.InsertUpdateDelete_DesignationInfo(1, txtDesignation.Text, int.Parse(Session["UserId"].ToString()), 0);
                if (Save>0)
                {
                    rmMsg.SuccessMessage = "Save done";
                    LoadGrid();
                }
                
            }
            else if (btnSave.Text == "Update")
            {
                int Save = objSetup.InsertUpdateDelete_DesignationInfo(2, txtDesignation.Text, int.Parse(Session["UserId"].ToString()), int.Parse(hdnUpdateDesignationId.Value));
                if (Save > 0)
                {
                    rmMsg.SuccessMessage = "Update done";
                    LoadGrid();
                    txtDesignation.Text = "";
                    btnSave.Text = "Save";
                }
            }

        }

        protected void gvDesignation_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = int.Parse(e.CommandArgument.ToString());
            HiddenField hdcDesignationId = (HiddenField)gvDesignation.Rows[rowIndex].FindControl("hdcDesignationId");
            Label lblDesignation = (Label)gvDesignation.Rows[rowIndex].FindControl("lblDesignation");

            if (e.CommandName == "editc")
            {
                hdnUpdateDesignationId.Value = hdcDesignationId.Value;
                txtDesignation.Text = lblDesignation.Text;
                btnSave.Text = "Update";
            }
            else if (e.CommandName == "deletec")
            {
                int delete = objSetup.InsertUpdateDelete_DesignationInfo(3, lblDesignation.Text, int.Parse(Session["UserId"].ToString()), int.Parse(hdcDesignationId.Value));
                if (delete > 0)
                {
                    rmMsg.SuccessMessage = "delete done";
                    LoadGrid();
                }
            }
        }

       
    }
}