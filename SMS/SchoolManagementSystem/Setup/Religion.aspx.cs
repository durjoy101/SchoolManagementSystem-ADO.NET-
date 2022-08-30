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
    public partial class Religion : System.Web.UI.Page
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
            dt = objSetup.Set_getReligionInfo();
            if (dt.Rows.Count > 0)
            {
                gvReligion.DataSource = dt;
                gvReligion.DataBind();
            }
            else
            {
                gvReligion.DataSource = null;
                gvReligion.DataBind();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.Text == "Save")
            {
                int Save = objSetup.InsertUpdateDelete_ReligionInfo(1, txtReligion.Text, 0);
                if (Save>0)
                {
                    rmMsg.SuccessMessage = "Save done";
                    LoadGrid();
                }
                
            }
            else if (btnSave.Text == "Update")
            {
                int Save = objSetup.InsertUpdateDelete_ReligionInfo(2, txtReligion.Text, int.Parse(hdnUpdateReligionId.Value));
                if (Save > 0)
                {
                    rmMsg.SuccessMessage = "Update done";
                    LoadGrid();
                    txtReligion.Text = "";
                    btnSave.Text = "Save";
                }
            }

        }

        protected void gvReligion_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = int.Parse(e.CommandArgument.ToString());
            HiddenField hdnReligionId = (HiddenField)gvReligion.Rows[rowIndex].FindControl("hdnReligionId");
            Label lblReligion = (Label)gvReligion.Rows[rowIndex].FindControl("lblReligion");

            if (e.CommandName == "editc")
            {
                hdnUpdateReligionId.Value = hdnReligionId.Value;
                txtReligion.Text = lblReligion.Text;
                btnSave.Text = "Update";
            }
            else if (e.CommandName == "deletec")
            {
                int delete = objSetup.InsertUpdateDelete_ReligionInfo(3, lblReligion.Text, int.Parse(hdnReligionId.Value));
                if (delete > 0)
                {
                    rmMsg.SuccessMessage = "delete done";
                    LoadGrid();
                }
            }
        }

       
    }
}