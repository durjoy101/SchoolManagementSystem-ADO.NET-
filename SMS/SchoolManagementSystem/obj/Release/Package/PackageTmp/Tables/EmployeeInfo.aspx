<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminMaster.Master" AutoEventWireup="true" CodeBehind="EmployeeInfo.aspx.cs" Inherits="SchoolManagementSystem.Tables.EmployeeInfo" %>
<%@ Register Src="~/ResponseMessage.ascx" TagPrefix="uc1" TagName="ResponseMessage" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script type="text/javascript" >
         function chkNumber(cntId) {
             var val = document.getElementById(cntId).value;
             var mainC = document.getElementById(cntId);
             var chkDigit = /^\d*$/;
             if (chkDigit.test(val)) {
                 mainC.style.backgroundColor = "white";
             }
             else {
                 alert("Invalid Number");
                 mainC.value = "";
                 mainC.style.backgroundColor = "red";
             }
         }
     </script>

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
            <!-- general form elements -->
            <div class="card card-primary">
                <div class="card-header">
                    <h3 class="card-title">Employee Info</h3>
                </div>
                <uc1:ResponseMessage runat="server" ID="rmMsg" />
                <!-- /.card-header -->
                <!-- form start -->
                <div class="card-body">
                    <div class="row">
                       <div class="col-md-4">
                            <div class="form-group ">
                                <label class="form-label">Employee Type</label>
                                <asp:DropDownList ID="ddlEmployeeType" CssClass="form-control dropdown" runat="server">
                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                    <asp:ListItem Value="Teacher">Teacher</asp:ListItem>
                                    <asp:ListItem Value="Others">Others</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group ">
                                <label class="form-label">First Name</label>
                                <asp:TextBox ID="txtFirsteName" runat="server" placeholder="Enter First Name" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group ">
                                <label class="form-label">Last Name</label>
                                <asp:TextBox ID="txtLastName" runat="server" placeholder="Enter Last Name" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group ">
                                <label class="form-label">Designation</label>
                                <asp:DropDownList ID="ddlDesignation" CssClass="form-control dropdown" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group ">
                                <label class="form-label">StartingSalary</label>
                                <asp:TextBox ID="txtStartingSalary" runat="server" placeholder="Enter Starting Salary" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group ">
                                <label class="form-label">Nationality</label>
                                <asp:TextBox ID="txtNationality" runat="server" placeholder="Enter Nationality" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group ">
                                <label class="form-label">NID</label>
                                <asp:TextBox ID="txtNID" runat="server" placeholder="Enter NID" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group ">
                                <label class="form-label">Date of Birth</label>
                                <asp:TextBox ID="txtDOB" runat="server" TextMode="Date" placeholder="Enter Date of Birth" CssClass="form-control" ></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group ">
                                <label class="form-label">Date of Joining</label>
                                <asp:TextBox ID="txtDOJ" TextMode="Date" runat="server" placeholder="Enter  Date of Joining" CssClass="form-control" ></asp:TextBox>

                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group ">
                                <label class="form-label">Religion</label>
                                <asp:DropDownList ID="ddlReligion" CssClass="form-control dropdown" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group ">
                                <label class="form-label">Gender</label>
                                <asp:DropDownList ID="ddlGender" CssClass="form-control dropdown" runat="server">
                                    <asp:ListItem Value="0">Select Gender...</asp:ListItem>
                                    <asp:ListItem Value="Male">Male</asp:ListItem>
                                    <asp:ListItem Value="Female">Female</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group ">
                                <label class="form-label">District</label>
                                <asp:DropDownList ID="ddlDistrict" CssClass="form-control dropdown" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group ">
                                <label class="form-label">Upazila</label>
                                <asp:DropDownList ID="ddlUpazila" CssClass="form-control dropdown" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-8">
                            <div class="form-group ">
                                <label class="form-label">Address</label>
                                <asp:TextBox ID="txtAddress" runat="server" placeholder="Enter Address" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                         <div class="col-md-4">
                            <div class="form-group ">
                                <label class="form-label">Email</label>
                                <asp:TextBox ID="txtEmail" runat="server" placeholder="Enter Email" CssClass="form-control"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"  ErrorMessage="Invalid Email Format." CssClass="text-danger" ></asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group ">
                                <label class="form-label">Contact Number</label>
                                <asp:TextBox ID="txtPhone" runat="server" placeholder="Enter Contact No." CssClass="form-control"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="revContact" runat="server" ControlToValidate="txtPhone" CssClass="text-danger" ValidationExpression="(^([+]{1}[8]{2}|0088)?(01){1}[3-9]{1}\d{8})$" ErrorMessage="Invalid Contact No"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group ">
                                <label class="form-label">Blood Group</label>
                                <asp:DropDownList ID="ddlBloodGroup" CssClass="form-control dropdown" runat="server">
                                    <asp:ListItem Value="0">Select...</asp:ListItem>
                                    <asp:ListItem Value="A+">A+</asp:ListItem>
                                    <asp:ListItem Value="A-">A-</asp:ListItem>
                                    <asp:ListItem Value="B+">B+</asp:ListItem>
                                    <asp:ListItem Value="B-">B-</asp:ListItem>
                                    <asp:ListItem Value="AB+">AB+</asp:ListItem>
                                    <asp:ListItem Value="AB-">AB-</asp:ListItem>
                                    <asp:ListItem Value="O+">O+</asp:ListItem>
                                    <asp:ListItem Value="O-">O-</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div> 
                        
                        <div class="col-md-2">
                            <div class="form-group ">
                                <label class="form-label">&nbsp;</label>
                                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-success form-control" Text="Save" OnClick="btnSave_Click" />
                            </div>
                        </div>
                    </div>


                </div>

                <div class="card-header">
                    <h3 class="card-title text-center">Employee List</h3>
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-md-12" style="overflow:scroll">
                            <div class="form-group ">
                                <asp:HiddenField ID="hdnUpdateEmployeeId" runat="server" />
                                <asp:GridView ID="gvEmployee" runat="server" CssClass="table table-bordered table-striped" Width="100%" OnRowCommand="gvEmployee_RowCommand" AutoGenerateColumns="true">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Action">
                                            <ItemTemplate>
                                                <asp:HiddenField ID="hdnEmployeeId" runat="server" Value='<%# Eval("EmployeeId") %>' />
                                                <asp:ImageButton ID="imgEdit" runat="server" ImageUrl="~/assets/site/images/ico_information.png" CommandName="editc" CommandArgument='<%# Container.DataItemIndex %>' Width="25px" />
                                                <asp:ImageButton ID="imgDelete" runat="server" ImageUrl="~/assets/img/cancel.png" CommandName="deletec" CommandArgument='<%# Container.DataItemIndex %>' OnClientClick="if ( ! ConfirmationMsg()) return false;" meta:resourcekey="imgDelete" Width="25px" />
                                            </ItemTemplate>
                                            <ItemStyle Wrap="False" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- /.card -->
        </div>
    </div>

</asp:Content>
