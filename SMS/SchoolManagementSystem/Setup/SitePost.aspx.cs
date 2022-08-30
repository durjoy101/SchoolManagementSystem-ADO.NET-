using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using BLL;
using System.Data;

namespace SchoolManagementSystem.Setup
{
    public partial class SitePost : System.Web.UI.Page
    {
        SetupBLL objSetup = new SetupBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CommonDAL.ddlLoad(ddlCategory, "SELECT  CategoryId, Category FROM dbo.Site_Category ORDER BY Category", "Category", "CategoryId");
                LoadGrid();
            }
        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str = "SELECT SubCategoryId, SubCategory FROM dbo.Site_SubCategory WHERE (CategoryId = " + ddlCategory.SelectedValue + ")";
            CommonDAL.ddlLoad(ddlSubCategory, str, "SubCategory", "SubCategoryId");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //--todo

            if (ddlCategory.SelectedValue != "0" && ddlSubCategory.SelectedValue != "0")
            {
                if (btnSave.Text == "Save")
                {
                    int Save = objSetup.InsertUpdateDelete_SitePostInfo(1, int.Parse(ddlCategory.SelectedValue), int.Parse(ddlSubCategory.SelectedValue), txtTitle.Text , txtDescription.Text, txtShortDescription.Text, fuImg.FileName , int.Parse(Session["UserId"].ToString()), 0);
                    if (Save > 0)
                    {
                        rmMsg.SuccessMessage = "Save done";
                        LoadGrid();
                    }

                }
                else if (btnSave.Text == "Update")
                {
                    int Save = objSetup.InsertUpdateDelete_SitePostInfo(1, int.Parse(ddlCategory.SelectedValue), int.Parse(ddlSubCategory.SelectedValue), txtTitle.Text, txtDescription.Text, txtShortDescription.Text, fuImg.FileName, int.Parse(Session["UserId"].ToString()), int.Parse(hdnUpdateId.Value));
                    if (Save > 0)
                    {
                        rmMsg.SuccessMessage = "Update done";
                        LoadGrid();
                        
                        btnSave.Text = "Save";

                    }
                }
            }
            else
            {
                rmMsg.FailureMessage = "Give correct information";
            }

            //--/todo
        }

        private void LoadGrid()
        {
            DataTable dt = new DataTable();
            dt = objSetup.Set_getSitePostInfo();
            if (dt.Rows.Count > 0)
            {
                gvSitePost.DataSource = dt;
                gvSitePost.DataBind();
            }
            else
            {
                gvSitePost.DataSource = null;
                gvSitePost.DataBind();
            }
        }

        protected void gvSitePost_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = int.Parse(e.CommandArgument.ToString());
            HiddenField hdnId = (HiddenField)gvSitePost.Rows[rowIndex].FindControl("hdnId");
            HiddenField hdncatId = (HiddenField)gvSitePost.Rows[rowIndex].FindControl("hdncatId");
            HiddenField hdnSubcatId = (HiddenField)gvSitePost.Rows[rowIndex].FindControl("hdnSubcatId");
            Label lblCategory = (Label)gvSitePost.Rows[rowIndex].FindControl("lblCategory");
            Label lblSubCategory = (Label)gvSitePost.Rows[rowIndex].FindControl("lblSubCategory");
            Label lblTitle = (Label)gvSitePost.Rows[rowIndex].FindControl("lblTitle");
            Label lblDescription = (Label)gvSitePost.Rows[rowIndex].FindControl("lblDescription");
            Label lblShortDescription = (Label)gvSitePost.Rows[rowIndex].FindControl("lblShortDescription");
            

            if (e.CommandName == "editc")
            {
                ddlCategory.SelectedValue = lblCategory.Text;
                ddlSubCategory.SelectedValue = lblSubCategory.Text;
                txtTitle.Text = lblTitle.Text;
                txtDescription.Text = lblDescription.Text;
                txtShortDescription.Text = lblShortDescription.Text;
                
                hdnUpdateId.Value = hdnId.Value;
                ddlCategory.SelectedValue = lblSubCategory.Text;

                btnSave.Text = "Update";
            }
            else if (e.CommandName == "deletec")
            {
                int delete = objSetup.InsertUpdateDelete_SitePostInfo(3, 1, 1, txtTitle.Text, txtDescription.Text, txtShortDescription.Text, fuImg.FileName, int.Parse(Session["UserId"].ToString()), int.Parse(hdnId.Value));
                if (delete > 0)
                {
                    rmMsg.SuccessMessage = "delete done";
                    LoadGrid();
                }
            }
        }
    }
}