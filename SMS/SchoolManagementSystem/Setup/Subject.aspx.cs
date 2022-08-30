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
    public partial class Subject : System.Web.UI.Page
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
            dt = objSetup.Set_getSubjectInfo();
            if (dt.Rows.Count > 0)
            {
                gvSubject.DataSource = dt;
                gvSubject.DataBind();
            }
            else
            {
                gvSubject.DataSource = null;
                gvSubject.DataBind();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.Text == "Save")
            {
                int Save = objSetup.InsertUpdateDelete_SubjectInfo(1, txtSubject.Text, int.Parse(Session["UserId"].ToString()), 0);
                if (Save>0)
                {
                    rmMsg.SuccessMessage = "Save done";
                    LoadGrid();
                }
                
            }
            else if (btnSave.Text == "Update")
            {
                int Save = objSetup.InsertUpdateDelete_SubjectInfo(2, txtSubject.Text, int.Parse(Session["UserId"].ToString()), int.Parse(hdnUpdateSubjectId.Value));
                if (Save > 0)
                {
                    rmMsg.SuccessMessage = "Update done";
                    LoadGrid();
                    txtSubject.Text = "";
                    btnSave.Text = "Save";
                }
            }

        }

        

        protected void gvSubject_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = int.Parse(e.CommandArgument.ToString());
            HiddenField hdnSubjectId = (HiddenField)gvSubject.Rows[rowIndex].FindControl("hdnSubjectId");
            Label lblSubject = (Label)gvSubject.Rows[rowIndex].FindControl("lblSubject");

            if (e.CommandName == "editc")
            {
                hdnUpdateSubjectId.Value = hdnSubjectId.Value;
                txtSubject.Text = lblSubject.Text;
                btnSave.Text = "Update";
            }
            else if (e.CommandName == "deletec")
            {
                int delete = objSetup.InsertUpdateDelete_SubjectInfo(3, lblSubject.Text, int.Parse(Session["UserId"].ToString()), int.Parse(hdnSubjectId.Value));
                if (delete > 0)
                {
                    rmMsg.SuccessMessage = "delete done";
                    LoadGrid();
                }
            }
        }
    }
}