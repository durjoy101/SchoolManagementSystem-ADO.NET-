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
    public partial class District : System.Web.UI.Page
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
            dt = objSetup.Set_getDistrictInfo();
            if (dt.Rows.Count > 0)
            {
                gvDistrict.DataSource = dt;
                gvDistrict.DataBind();
            }
            else
            {
                gvDistrict.DataSource = null;
                gvDistrict.DataBind();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.Text == "Save")
            {
                int Save = objSetup.InsertUpdateDelete_DesignationInfo(1, txtDistrict.Text, int.Parse(Session["UserId"].ToString()), 0);
                if (Save>0)
                {
                    rmMsg.SuccessMessage = "Save done";
                    LoadGrid();
                }
                
            }
            else if (btnSave.Text == "Update")
            {
                int Save = objSetup.InsertUpdateDelete_DesignationInfo(2, txtDistrict.Text, int.Parse(Session["UserId"].ToString()), int.Parse(hdnUpdateDistrictId.Value));
                if (Save > 0)
                {
                    rmMsg.SuccessMessage = "Update done";
                    LoadGrid();
                    txtDistrict.Text = "";
                    btnSave.Text = "Save";
                }
            }

        }

        protected void gvDistrict_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = int.Parse(e.CommandArgument.ToString());
            HiddenField hdnDistrictId = (HiddenField)gvDistrict.Rows[rowIndex].FindControl("hdnDistrictId");
            Label lblDistrict = (Label)gvDistrict.Rows[rowIndex].FindControl("lblDistrict");

            if (e.CommandName == "editc")
            {
                hdnUpdateDistrictId.Value = hdnDistrictId.Value;
                txtDistrict.Text = lblDistrict.Text;
                btnSave.Text = "Update";
            }
            else if (e.CommandName == "deletec")
            {
                int delete = objSetup.InsertUpdateDelete_DesignationInfo(3, lblDistrict.Text, int.Parse(Session["UserId"].ToString()), int.Parse(hdnDistrictId.Value));
                if (delete > 0)
                {
                    rmMsg.SuccessMessage = "delete done";
                    LoadGrid();
                }
            }
        }

       
    }
}