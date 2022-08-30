//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Linq;
//using System.Web;
//using System.Web.UI;
//using System.Web.UI.WebControls;
//using BLL;
//using DAL;

//namespace SchoolManagementSystem.Setup
//{
//    public partial class ExamMark : System.Web.UI.Page
//    {
//        AssignBLL objAssign = new AssignBLL();
//        protected void Page_Load(object sender, EventArgs e)
//        {
//            if (!IsPostBack)
//            {
//                CommonDAL.ddlLoad(ddlClass, "SELECT  ClassId, ClassName FROM Conf_Class ORDER BY ClassName", "ClassName", "ClassId");
//                CommonDAL.ddlLoad(ddlSubject, "SELECT SubjectId, SubjectName FROM Conf_Subject ORDER BY SubjectName", "SubjectName", "SubjectId");
//                //btnSave.Text = "Save";
//                //LoadGrid();
//            }
//        }

//        //private void LoadGrid()
//        //{
//        //    DataTable dt = new DataTable();
//        //    dt = objAssign.Set_getClassAssignInfo();
//        //    if (dt.Rows.Count > 0)
//        //    {
//        //        gvClassSchedule.DataSource = dt;
//        //        gvClassSchedule.DataBind();
//        //    }
//        //    else
//        //    {
//        //        gvClassSchedule.DataSource = null;
//        //        gvClassSchedule.DataBind();
//        //    }
//        //}

//        protected void btnSave_Click(object sender, EventArgs e)
//        {
//            ListAdd();
//        }
//        private void ListAdd()
//        {
//            DataTable dt = new DataTable();
//            DataColumn dc = new DataColumn();
//            dc = new DataColumn("Shift", typeof(string)); dt.Columns.Add(dc);
//            dc = new DataColumn("Class", typeof(string)); dt.Columns.Add(dc);
//            dc = new DataColumn("ClassId", typeof(string)); dt.Columns.Add(dc);
//            dc = new DataColumn("WeekDay", typeof(string)); dt.Columns.Add(dc);
//            dc = new DataColumn("Subject", typeof(string)); dt.Columns.Add(dc);
//            dc = new DataColumn("SubjectId", typeof(string)); dt.Columns.Add(dc);
//            dc = new DataColumn("StartTime", typeof(string)); dt.Columns.Add(dc);
//            dc = new DataColumn("EndTime", typeof(string)); dt.Columns.Add(dc);

//            DataRow dr = dt.NewRow();

//            if (ViewState["VSCS"] != null)
//            {
//                DataTable dt2 = (DataTable)ViewState["VSCS"];
//            }

//            dr[0] = ddlShift.SelectedValue;
//            dr[1] = ddlClass.SelectedItem.Text;
//            dr[2] = ddlClass.SelectedValue;
//            dr[3] = ddlWeekDay.SelectedValue;
//            dr[4] = ddlSubject.SelectedItem.Text;
//            dr[5] = ddlSubject.SelectedValue;
//            dr[6] = txtStartTime.Text;
//            dr[7] = txtEndTime.Text;

//            dt.Rows.Add(dr);

//            gvClassSchedule.DataSource = dt;
//            gvClassSchedule.DataBind();

//            ViewState["VSCS"] = dt;
//        }

//        //protected void btnSave_Click(object sender, EventArgs e)
//        //{
//        //    if (btnSave.Text == "Save")
//        //    {
//        //        int Save = objAssign.InsertUpdateDelete_ClassAssignInfo(1,ddlShift.SelectedValue,int.Parse(ddlClass.SelectedValue),ddlWeekDay.SelectedValue,int.Parse(ddlSubject.SelectedValue),txtStartTime.Text,txtEndTime.Text,0);
//        //        if (Save > 0)
//        //        {
//        //            rmMsg.SuccessMessage = "Save done";
//        //            LoadGrid();
//        //        }

//        //    }
//        //    else if (btnSave.Text == "Update")
//        //    {
//        //        int Save = objAssign.InsertUpdateDelete_ClassAssignInfo(2, ddlShift.SelectedValue, int.Parse(ddlClass.SelectedValue), ddlWeekDay.SelectedValue, int.Parse(ddlSubject.SelectedValue), txtStartTime.Text, txtEndTime.Text,int.Parse(hdnUpdateClassScheduleId.Value));
//        //        if (Save > 0)
//        //        {
//        //            rmMsg.SuccessMessage = "Update done";
//        //            LoadGrid();
//        //            txtStartTime.Text = "";
//        //            txtEndTime.Text = "";
//        //            ddlShift.SelectedValue ="0";
//        //            ddlWeekDay.SelectedValue = "0";
//        //            btnSave.Text = "Save";

//        //        }
//        //    }

//        //            else
//        //            {
//        //                rmMsg.FailureMessage = "Give correct information";
//        //            }
//        //}

//        //protected void gvClassSchedule_RowCommand(object sender, GridViewCommandEventArgs e)
//        //{
//        //    int rowIndex = int.Parse(e.CommandArgument.ToString());
//        //    HiddenField hdnClassScheduleId = (HiddenField)gvClassSchedule.Rows[rowIndex].FindControl("hdnClassScheduleId");




//        //    if (e.CommandName == "editc")
//        //    {
//        //        FillControl(int.Parse(hdnClassScheduleId.Value));
//        //        btnSave.Text = "Update";
//        //    }
//        //    else if (e.CommandName == "deletec")
//        //    {

//        //        objAssign.InsertUpdateDelete_ClassAssignInfo(3,ddlShift.SelectedValue,0,ddlWeekDay.SelectedValue,0,txtStartTime.Text,txtEndTime.Text,int.Parse(hdnUpdateClassScheduleId.Value));

//        //        rmMsg.SuccessMessage = "delete done";
//        //        LoadGrid();
//        //    }
//        //}
//        //private void FillControl(int ClassScheduleId)
//        //{
//        //    DataTable dt = new DataTable();
//        //    dt = objAssign.Set_getClassAssignInfo(ClassScheduleId);
//        //    if (dt.Rows.Count > 0)
//        //    {
//        //        hdnUpdateClassScheduleId.Value = ClassScheduleId.ToString();

//        //        ddlShift.SelectedValue = dt.Rows[0]["Shift"].ToString();
//        //        ddlClass.SelectedValue = dt.Rows[0]["ClassId"].ToString();
//        //        ddlWeekDay.SelectedValue = dt.Rows[0]["WeekDay"].ToString();
//        //        ddlSubject.SelectedValue = dt.Rows[0]["SubjectId"].ToString();
//        //        txtStartTime.Text = dt.Rows[0]["StartTime"].ToString();
//        //        txtEndTime.Text = dt.Rows[0]["EndTime"].ToString();

//        //        btnSave.Text = "Update";
//        //    }
//        //}



//    }
//}