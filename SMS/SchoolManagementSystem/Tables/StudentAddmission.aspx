<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/BlankMaster.Master" AutoEventWireup="true" CodeBehind="StudentAddmission.aspx.cs" Inherits="SchoolManagementSystem.Tables.StudentAddmission" %>

<%@ Register Src="~/ResponseMessage.ascx" TagPrefix="uc1" TagName="ResponseMessage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField ID="hdnStuId" runat="server" />

    <div class="content-wrapper">
        <div class="container">
            <div class="card card-primary">

                <div class="card-header">
                    <h3 class="card-title">Student Addmission</h3>
                </div>

                <uc1:ResponseMessage runat="server" ID="rmMsg" />
                <div class="card-body">
                    <div class="row">
                        <div class="col-md-4 form-group">
                            <label class="form-label">Student Name</label>
                            <asp:TextBox runat="server" ID="txtStudentName" placeholder="Enter Student Name" CssClass="form-control" />
                        </div>


                        <div class="col-md-4 form-group">
                            <label class="form-label">Session Year</label>
                            <asp:DropDownList ID="ddlSession" CssClass="form-control" runat="server"></asp:DropDownList>         
                        </div>

                        <div class="col-md-3">
                            <label class="form-label">Shift</label>
                            <asp:DropDownList runat="server" ID="ddlShift" CssClass="form-control">
                                <asp:ListItem Value="0">--select--</asp:ListItem>
                                <asp:ListItem>Morning</asp:ListItem>
                                <asp:ListItem>Day</asp:ListItem>
                            </asp:DropDownList>

                        </div>
                        <div class="col-md-3">
                            <label class="form-label">Class</label>
                            <asp:DropDownList runat="server" ID="ddlClass" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlClass_SelectedIndexChanged" />
                        </div>

                        <div class="col-md-4 form-group">
                            <label class="form-label">Student Registration No</label>
                            <asp:TextBox runat="server" ID="txtRegistrationNo" placeholder="Enter Student Name" CssClass="form-control" />
                        </div>
                        <div class="col-md-4 form-group">
                            <label class="form-label">Roll No</label>
                            <asp:TextBox runat="server" ID="txtRollNo" placeholder="Enter  Roll No  " CssClass="form-control" />
                        </div>
                        <div class="col-md-4 form-group">
                            <label class="form-label">Addmission Date</label>
                            <asp:TextBox runat="server" ID="txtAddmissionDate" placeholder="Enter Addmission Date" CssClass="form-control" TextMode="Date" />
                        </div>

                        <div class="col-md-2">
                            <label class="form-label">&nbsp;</label>
                            <asp:HiddenField ID="hdnUpdateStudentId" runat="server" />
                            <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="form-control btn btn-primary" OnClick="btnSave_Click" />
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>
</asp:Content>
