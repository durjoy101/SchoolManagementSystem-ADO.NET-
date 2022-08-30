using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DAL;

namespace SchoolManagementSystem.Setup
{
    public partial class Upazila : System.Web.UI.Page
    {
        SetupBLL objSetup = new SetupBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CommonDAL.ddlLoad(ddlDistrict, "SELECT  DistrictId, DistrictName FROM dbo.Conf_District ORDER BY DistrictName", "DistrictName", "DistrictId");
                btnSave.Text = "Save";
                LoadGrid();
            }
        }

        private void LoadGrid()
        {
            DataTable dt = new DataTable();
            dt = objSetup.Set_getUpazilaInfo();
            if (dt.Rows.Count > 0)
            {
                gvUpazila.DataSource = dt;
                gvUpazila.DataBind();
            }
            else
            {
                gvUpazila.DataSource = null;
                gvUpazila.DataBind();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (ddlDistrict.SelectedValue != "0" && txtUpazila.Text!="")
            {
                if (btnSave.Text == "Save")
                {
                    int Save = objSetup.InsertUpdateDelete_UpazilaInfo(1, int.Parse(ddlDistrict.SelectedValue), txtUpazila.Text, int.Parse(Session["UserId"].ToString()), 0);
                    if (Save > 0)
                    {
                        rmMsg.SuccessMessage = "Save done";
                        LoadGrid();
                    }

                }
                else if (btnSave.Text == "Update")
                {
                    int Save = objSetup.InsertUpdateDelete_UpazilaInfo(2, int.Parse(ddlDistrict.SelectedValue), txtUpazila.Text, int.Parse(Session["UserId"].ToString()), int.Parse(hdnUpdateUpazilaId.Value));
                    if (Save > 0)
                    {
                        rmMsg.SuccessMessage = "Update done";
                        LoadGrid();
                        txtUpazila.Text = "";
                        btnSave.Text = "Save";

                    }
                }
            }
            else
            {
                rmMsg.FailureMessage = "Give correct information";
            }

        }

        protected void gvUpazila_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = int.Parse(e.CommandArgument.ToString());
            HiddenField hdnDistrictId = (HiddenField)gvUpazila.Rows[rowIndex].FindControl("hdnDistrictId");
            HiddenField hdnUpazilaId = (HiddenField)gvUpazila.Rows[rowIndex].FindControl("hdnUpazilaId");
            Label lblUpazila = (Label)gvUpazila.Rows[rowIndex].FindControl("lblUpazila");

            if (e.CommandName == "editc")
            {
                ddlDistrict.SelectedValue = hdnDistrictId.Value;
                hdnUpdateUpazilaId.Value = hdnUpazilaId.Value;
                txtUpazila.Text = lblUpazila.Text;
                btnSave.Text = "Update";
            }
            else if (e.CommandName == "deletec")
            {
                int delete = objSetup.InsertUpdateDelete_UpazilaInfo(3, 1, lblUpazila.Text, int.Parse(Session["UserId"].ToString()), int.Parse(hdnUpazilaId.Value));
                if (delete > 0)
                {
                    rmMsg.SuccessMessage = "delete done";
                    LoadGrid();
                }
            }
        }

        
    }
}