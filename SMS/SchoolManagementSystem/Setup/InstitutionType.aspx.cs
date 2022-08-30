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
    public partial class InstitutionType : System.Web.UI.Page
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
            dt = objSetup.Set_getInstitutionTypeInfo();
            if (dt.Rows.Count > 0)
            {
                gvInstitutionType.DataSource = dt;
                gvInstitutionType.DataBind();
            }
            else
            {
                gvInstitutionType.DataSource = null;
                gvInstitutionType.DataBind();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.Text == "Save")
            {
                int Save = objSetup.InsertUpdateDelete_InstitutionTypeInfo(1, txtInstitutionType.Text, int.Parse(Session["UserId"].ToString()), 0);
                if (Save>0)
                {
                    rmMsg.SuccessMessage = "Save done";
                    LoadGrid();
                }
                
            }
            else if (btnSave.Text == "Update")
            {
                int Save = objSetup.InsertUpdateDelete_InstitutionTypeInfo(2, txtInstitutionType.Text, int.Parse(Session["UserId"].ToString()), int.Parse(hdnUpdateInstitutionTypeId.Value));
                if (Save > 0)
                {
                    rmMsg.SuccessMessage = "Update done";
                    LoadGrid();
                    txtInstitutionType.Text = "";
                    btnSave.Text = "Save";
                }
            }

        }

       
        protected void gvInstitutionType_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = int.Parse(e.CommandArgument.ToString());
            HiddenField hdnInstitutionTypeId = (HiddenField)gvInstitutionType.Rows[rowIndex].FindControl("hdnInstitutionTypeId");
            Label lblInstitutionType = (Label)gvInstitutionType.Rows[rowIndex].FindControl("lblInstitutionType");

            if (e.CommandName == "editc")
            {
                hdnUpdateInstitutionTypeId.Value = hdnInstitutionTypeId.Value;
                txtInstitutionType.Text = lblInstitutionType.Text;
                btnSave.Text = "Update";
            }
            else if (e.CommandName == "deletec")
            {
                int delete = objSetup.InsertUpdateDelete_InstitutionTypeInfo(3, lblInstitutionType.Text, int.Parse(Session["UserId"].ToString()), int.Parse(hdnInstitutionTypeId.Value));
                if (delete > 0)
                {
                    rmMsg.SuccessMessage = "delete done";
                    LoadGrid();
                }
            }
        }
    }
}