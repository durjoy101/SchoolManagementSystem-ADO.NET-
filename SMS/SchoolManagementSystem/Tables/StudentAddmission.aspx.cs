using BLL;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchoolManagementSystem.Tables
{
    public partial class StudentAddmission : System.Web.UI.Page
    {
        AddmissionBLL objAddmission = new AddmissionBLL();
        DummyStudentBLL objDummySBLL = new DummyStudentBLL();
        CommonDAL objc = new CommonDAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CommonDAL.ddlLoad(ddlClass, "SELECT  ClassId, ClassName FROM Conf_Class ORDER BY ClassName", "ClassName", "ClassId");

                hdnStuId.Value = Request.QueryString["StudentId"].ToString();

                txtStudentName.Text = objc.getString(@"select (FirstName+' '+ LastName) as StuName from [dbo].[DummyStudent] where [StudentId] =" + hdnStuId.Value + " ");

                SessionLoad();

                //loadStudentName();
            }
        }

        private void RegLoad()
        {
             string regNo = objc.getString(@"select isnull(max(RegSl),0) as RegSl from [dbo].[Addmission] where (SessionYear= " + ddlSession.SelectedValue + ") and (ClassId= " + ddlClass.SelectedValue + ") and (Shift = '" + ddlShift.SelectedItem.Text + "') ");

            txtRegistrationNo.Text = "KR" + ddlSession.SelectedValue.Substring(2, 2) + ddlShift.SelectedItem.Text.Substring(0,1) + ddlClass.SelectedValue.PadLeft(2, '0') + (int.Parse(regNo) + 1).ToString().PadLeft(3,'0');
            
        }

        private void SessionLoad ()
        {
            ListItem li1 = new ListItem("--select--", "0");
            ListItem li2 = new ListItem((DateTime.Now.Year + 1).ToString(), (DateTime.Now.Year +1).ToString());

            ddlSession.Items.Insert(0,li1);
            ddlSession.Items.Insert(1,li2);
            for (int i=2; i<10; i++)
            {
                ListItem li = new ListItem((DateTime.Now.Year - (i-2)).ToString(), (DateTime.Now.Year - (i-2)).ToString());
                ddlSession.Items.Insert(i,li);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
            int save = 0;
            save = objAddmission.Insert_deleteAddmissionInfo(1,0, int.Parse(txtRegistrationNo.Text.Substring(7, 3)) , txtRegistrationNo.Text, int.Parse(hdnStuId.Value), ddlShift.SelectedValue,int.Parse(ddlClass.SelectedValue),int.Parse(txtRollNo.Text),int.Parse(ddlSession.SelectedValue),txtAddmissionDate.Text, int.Parse(Session["UserId"].ToString()),true);
            if (save > 0)
            {
                rmMsg.SuccessMessage = "action complete";
            }
        }

        protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            RegLoad();
        }

        //private void loadStudentName()
        //{
        //    DataTable dt = new DataTable();
        //    dt = objDummySBLL.ShowGetDummyStudentInfo(int.Parse(hdnStuId.Value));
        //    if(dt.Rows.Count>0)
        //    {
        //        string FirstName = dt.Rows[0]["FirstName"].ToString();
        //        string LastName = dt.Rows[0]["LastName"].ToString();
        //        string FullName = FirstName + ' ' + LastName;
        //        txtStudentName.Text = FullName;
        //    }
        //}
    }
}