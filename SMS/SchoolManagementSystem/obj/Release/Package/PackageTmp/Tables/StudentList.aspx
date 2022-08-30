<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminMaster.Master" AutoEventWireup="true" CodeBehind="StudentList.aspx.cs" Inherits="SchoolManagementSystem.Tables.StudentList" %>
<%@ Register Src="~/ResponseMessage.ascx" TagPrefix="uc1" TagName="ResponseMessage" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function ConfirmationMsg() {
            return confirm("Are u sure to Delete");
        }
    </script>
    <style>
        .input-group-text, .form-control {
            border-radius: 0px !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
        <div class="container">
            <div class="card card-primary">
                <uc1:ResponseMessage runat="server" ID="rmMsg" />
                <div class="card-header">
                    <h3 class="card-title">Student List</h3>
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-md-4 form-group">
                            <label class="form-label">Student Name</label>
                            <asp:TextBox runat="server" ID="txtFirstName" placeholder="Enter First Name" CssClass="form-control" />
                        </div>
                        
                  
                        <div class="col-md-3">
                            <label class="form-label">Gender</label>
                            <asp:DropDownList runat="server" ID="ddlGender" CssClass="form-control" >
                                <asp:ListItem Value="0">--select--</asp:ListItem>
                                <asp:ListItem>male</asp:ListItem>
                                <asp:ListItem>female</asp:ListItem>
                                <asp:ListItem>others</asp:ListItem>
                            </asp:DropDownList>
                            
                        </div>
                        <div class="col-md-3">
                            <label class="form-label">Religion</label>
                            <asp:DropDownList runat="server" ID="ddlReligion" CssClass="form-control" />
                        </div>
                        
                    
                        <div class="col-md-2">
                            <label class="form-label">&nbsp;</label>
                            <asp:HiddenField ID="hdnUpdateStudentId" runat="server" />
                            <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="form-control btn btn-primary" OnClick="btnSearch_Click"   />
                        </div>
                    </div>
                </div>

               
                <div class="card-body" style="overflow:scroll">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group ">
                                <asp:GridView ID="gvStudentRegistration" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-striped" OnRowCommand="gvStudentRegistration_RowCommand" OnRowDataBound="gvStudentRegistration_RowDataBound"  >
                                    <Columns>

                                        <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                                        <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                                        <asp:BoundField DataField="FathersName" HeaderText="Father's Name" />
                                        <asp:BoundField DataField="ContactNo" HeaderText="Contact No" />
                                        <asp:BoundField DataField="Gender" HeaderText="Gender" />
                                        <asp:BoundField DataField="ReligionName" HeaderText="Religion" />
                                        <asp:BoundField DataField="RegistrationNo" HeaderText="Registration No" />
                                        <asp:BoundField DataField="Shift" HeaderText="Shift" />
                                        <asp:BoundField DataField="ClassName" HeaderText="Class" />
                                        <asp:BoundField DataField="SessionYear" HeaderText="Session" />
                                        <asp:BoundField DataField="RollNo" HeaderText="Roll" />
                                        <asp:BoundField DataField="AddmissionDate" HeaderText="Addmission Date" />

                                        <asp:TemplateField>
                                            <HeaderTemplate>Admission</HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:HiddenField ID="hdnAddmissionId" runat="server" Value='<%# Eval("AddmissionId") %>' />
                                                <asp:Label ID="txtAdmissionInfo" runat="server" Text=""></asp:Label>
                                                <asp:LinkButton ID="lbAdCancel" Text="AdmissionCancel" runat="server" CommandName="adcancel" CommandArgument="<%# Container.DataItemIndex %>" ></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                         <asp:TemplateField HeaderText="Action">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgEdit" runat="server" ImageUrl="~/assets/site/images/bg_menu_trigger.png" Width="25px" CommandName="addmission" CommandArgument='<%# Container.DataItemIndex %>' />
                                                <asp:ImageButton ID="imgdelete" runat="server" ImageUrl="~/assets/img/cancel.png" Width="25px" CommandName="deletec" CommandArgument='<%# Container.DataItemIndex %>' OnClientClick="if ( ! ConfirmationMsg()) return false;" meta:resourcekey="imgDelete" />
                                                <asp:HiddenField ID="hdnStudentId" runat="server" Value='<%# Eval("StudentId") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>