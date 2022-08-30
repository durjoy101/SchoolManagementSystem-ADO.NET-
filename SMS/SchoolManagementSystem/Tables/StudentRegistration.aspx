<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminMaster.Master" AutoEventWireup="true" CodeBehind="StudentRegistration.aspx.cs" Inherits="SchoolManagementSystem.Tables.StudentRegistration" %>

<%@ Register Src="~/ResponseMessage.ascx" TagPrefix="uc1" TagName="ResponseMessage" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
        <div class="container">
            <div class="card card-primary">
                <uc1:ResponseMessage runat="server" ID="rmMsg" />
                <div class="card-header">
                    <h3 class="card-title">Student Registration Form</h3>
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-md-6 form-group">
                            <label class="form-label">First Name</label>
                            <asp:TextBox runat="server" ID="txtFirstName" placeholder="Enter First Name" CssClass="form-control" />
                        </div>
                        <div class="col-md-6 form-group">
                            <label class="form-label">Last Name</label>
                            <asp:TextBox runat="server" ID="txtLastName" PlaceHolder="Enter Last Name" CssClass="form-control" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4">
                            <label class="form-label">Father's Name</label>
                            <asp:TextBox runat="server" ID="txtFathersName" CssClass="form-control" />
                        </div>
                        <div class="col-md-4">
                            <label class="form-label">Father's Occupation</label>
                            <asp:TextBox runat="server" ID="txtFathersOccupation" CssClass="form-control" />
                        </div>
                        <div class="col-md-4">
                            <label class="form-label">Father's Contact</label>
                            <asp:TextBox runat="server" ID="txtFathersContact" CssClass="form-control" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4">
                            <label class="form-label">Mother's Name</label>
                            <asp:TextBox runat="server" ID="txtMothersName" CssClass="form-control" />
                        </div>
                        <div class="col-md-4">
                            <label class="form-label">Mother's Occupation</label>
                            <asp:TextBox runat="server" ID="txtMothersOccupation" CssClass="form-control" />
                        </div>
                        <div class="col-md-4">
                            <label class="form-label">Mother's Contact</label>
                            <asp:TextBox runat="server" ID="txtMothersContact" CssClass="form-control" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <label class="form-label">Present Address</label>
                            <asp:TextBox runat="server" ID="txtPresentAddress" CssClass="form-control" TextMode="MultiLine" />
                        </div>
                        <div class="col-md-6">
                            <label class="form-label">Permanent Address</label>
                            <asp:TextBox runat="server" ID="txtPermanentAddress" CssClass="form-control" TextMode="MultiLine" />
                        </div>

                    </div>
                    <div class="row">
                        <div class="col-md-3">
                            <label class="form-label">Contact Number</label>
                            <asp:TextBox runat="server" ID="txtContactNumber" CssClass="form-control" />
                        </div>
                        <div class="col-md-3">
                            <label class="form-label">Nationality</label>
                            <asp:TextBox runat="server" ID="txtNationality" CssClass="form-control" />
                        </div>
                        <div class="col-md-6">
                            <label class="form-label">Email</label>
                            <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" />
                        </div>

                    </div>
                    <div class="row">
                        <div class="col-md-3">
                            <label class="form-label">Gender</label>
                            <asp:DropDownList runat="server" ID="ddlGender" CssClass="form-control">
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
                        <div class="col-md-3">
                            <label class="form-label">Date Of Birth</label>
                            <asp:TextBox runat="server" ID="txtDateOfBirth" CssClass="form-control" TextMode="Date" />
                        </div>
                        <div class="col-md-3">
                            <label class="form-label">Blood Group</label>
                            <asp:DropDownList runat="server" ID="ddlBloodGroup" CssClass="form-control">
                                <asp:ListItem Value="0">--select--</asp:ListItem>
                                <asp:ListItem>a+</asp:ListItem>
                                <asp:ListItem>b+</asp:ListItem>
                                <asp:ListItem>o+</asp:ListItem>
                                <asp:ListItem>ab+</asp:ListItem>
                                <asp:ListItem>a-</asp:ListItem>
                                <asp:ListItem>b-</asp:ListItem>
                                <asp:ListItem>o-</asp:ListItem>
                                <asp:ListItem>ab-</asp:ListItem>
                            </asp:DropDownList>

                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-5">
                            <label class="form-label">Guardian's Name</label>
                            <asp:TextBox runat="server" ID="txtguardianName" CssClass="form-control" />
                        </div>
                        <div class="col-md-5">
                            <label class="form-label">Guardian's Contact</label>
                            <asp:TextBox runat="server" ID="txtGuardianContact" CssClass="form-control" />
                        </div>
                        <div class="col-md-2">
                            <label class="form-label">&nbsp;</label>
                            <asp:HiddenField ID="hdnUpdateStudentId" runat="server" />
                            <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="form-control btn btn-primary" OnClick="btnSave_Click" />
                        </div>
                    </div>
                </div>

                <div class="card-header ">
                    <h3 class="card-title text-center">Student Registration List</h3>
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group ">
                                <asp:GridView ID="gvStudentRegistration" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-striped" OnRowCommand="gvStudentRegistration_RowCommand1">
                                    <Columns>

                                        <asp:BoundField DataField="StudentName" HeaderText="Student Name" />
                                        <asp:BoundField DataField="FathersName" HeaderText="Father's Name" />
                                        <asp:BoundField DataField="MothersName" HeaderText="Mother's Name" />
                                        <asp:BoundField DataField="PresentAddress" HeaderText="Present Address" />
                                        <asp:BoundField DataField="PermanentAddress" HeaderText="Permanent Address" />
                                        <asp:BoundField DataField="ContactNo" HeaderText="Contact No" />
                                        <asp:BoundField DataField="Nationality" HeaderText="Nationality" />
                                        <asp:BoundField DataField="Gender" HeaderText="Gender" />
                                        <asp:BoundField DataField="ReligionName" HeaderText="Religion" />
                                        <asp:BoundField DataField="DateOfBirth" HeaderText="Date Of Birth" />
                                        <asp:BoundField DataField="BloodGroup" HeaderText="Blood Group" />
                                        <asp:BoundField DataField="GuardianName" HeaderText="Guardian Name" />

                                        <asp:TemplateField HeaderText="Action">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgEdit" runat="server" ImageUrl="~/assets/site/images/ico_information.png" Width="25px" CommandName="editc" CommandArgument='<%# Container.DataItemIndex %>' />
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
