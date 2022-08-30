<%--<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ExamMark.aspx.cs" Inherits="SchoolManagementSystem.Setup.ExamMark" %>

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
            <!-- general form elements -->
            <div class="card card-primary">
              <div class="card-header">
                <h3 class="card-title">Exam Mark Distribution</h3>
              </div>
                <uc1:responsemessage runat="server" id="rmMsg" />
              <!-- /.card-header -->
              <!-- form start -->

                <div class="card-body">
                    <div class="row">
                        <div class="col-md-4">
                            <div class="form-group ">
                                <label class="form-label">Shift</label>
                                <asp:DropDownList ID="ddlShift" runat="server" CssClass="form-control">
                                    <asp:ListItem Value="0">--select--</asp:ListItem>
                                    <asp:ListItem>Morning</asp:ListItem>
                                    <asp:ListItem>Day</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group ">
                                <label class="form-label">Class</label>
                                <asp:DropDownList ID="ddlClass" runat="server" CssClass="form-control"></asp:DropDownList>
                            </div>
                         </div>
                        
                        <div class="col-md-4">
                            <div class="form-group ">
                                <label class="form-label">Subject</label>
                                <asp:DropDownList ID="ddlSubject" runat="server" CssClass="form-control"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group ">
                                <label class="form-label">Exam Name</label>
                                <asp:DropDownList ID="ddlExamName" runat="server" CssClass="form-control">
                                    <asp:ListItem Value="0">--select--</asp:ListItem>
                                    <asp:ListItem>MidTerm</asp:ListItem>
                                    <asp:ListItem>FinalTerm</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                         </div>
                        
                   

                        </div>
                    </div>

               
                </div>
              
                <div class="card-header ">
                    <h3 class="card-title text-center">Class Schedule List</h3>
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group ">
                                <asp:GridView ID="gvClassSchedule" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-striped" >
                                    <Columns>

                                        <asp:BoundField DataField="Shift" HeaderText="Shift" />
                                        <asp:BoundField DataField="Class" HeaderText="Class" />
                                        <asp:BoundField DataField="WeekDay" HeaderText="WeekDay" />
                                        <asp:BoundField DataField="Subject" HeaderText="SubjectName" />
                                        <asp:BoundField DataField="StartTime" HeaderText="StartTime" />
                                        <asp:BoundField DataField="EndTime" HeaderText="EndTime" />

                                       <%-- <asp:TemplateField HeaderText="Sub Category">
                                            <ItemTemplate>
                                                <asp:HiddenField ID="hdncatId" runat="server" Value='<%# Eval("CategoryId") %>' />
                                                <asp:Label ID="lblSubCategory" runat="server" Text='<%# Eval("SubCategory") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>


                                        <asp:TemplateField HeaderText="Action">
                                            <ItemTemplate>
                                                <asp:HiddenField ID="hdnClassId" runat="server" Value='<%# Eval("ClassId") %>' />
                                                <asp:HiddenField ID="HdnSubjectId" runat="server" Value='<%# Eval("SubjectId") %>' />

                                                <asp:ImageButton ID="imgEdit" runat="server" ImageUrl="~/assets/site/images/ico_information.png" Width="25px" CommandName="editc" CommandArgument='<%# Container.DataItemIndex %>' />
                                                <asp:ImageButton ID="imgdelete" runat="server" ImageUrl="~/assets/img/cancel.png" Width="25px" CommandName="deletec" CommandArgument='<%# Container.DataItemIndex %>' OnClientClick="if ( ! ConfirmationMsg()) return false;" meta:resourcekey="imgDelete" />
                                            </ItemTemplate>
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
</asp:Content>--%>
