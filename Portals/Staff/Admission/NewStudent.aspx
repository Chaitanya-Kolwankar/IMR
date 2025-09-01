<%@ Page Title="" Language="C#" MasterPageFile="~/Portals/Staff/MasterPage.master" AutoEventWireup="true" CodeFile="NewStudent.aspx.cs" Inherits="Portals_Staff_Admission_Master_NewStudent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
   <script src="<%= ResolveUrl("~/Assets/js/jquery.datetimepicker.js") %>"></script>
<link href="<%= ResolveUrl("~/Assets/css/jquery.datetimepicker.css") %>" rel="stylesheet" />
<style>
    input[type=number] {
        -moz-appearance: textfield;
    }

    table, td, th {
        border: 1px solid #ddd;
        text-align: left;
    }

    table {
        border-collapse: collapse;
        width: 100%;
    }

    th, td {
        padding: 15px;
    }

    th {
        color: #012970;
        background-color: white !important;
        position: sticky;
        font-weight: bold;
        top: 0;
    }

    .caps {
        text-transform: uppercase;
    }

    .FixedHeader {
        position: sticky;
        font-weight: bold;
        top: 0;
    }

    .transparent-modal {
        background-color: #0000;
        border: 0px;
    }

    .form-control[readonly] {
        background-color: #fff;
    }
</style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main" class="main">
        <div class="container-fluid my-1">
            <div class="pagetitle " style="font-size: 32px; margin-left: 34px; font-weight: 300; color: #012970;">
                Admission 
            </div>
            <div class="card">
                <div class="container-fluid">
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <div class="row">

                                <div class="panel panel-primary">
                                    <div class="card-title mx-4" style="font-size: large">New Student </div>
                                    <div class="panel-body">
                                        <div class="container-fluid">
                                            <style>
                                                .autocomplete-suggestions {
                                                    width: 250px !important;
                                                }
                                            </style>

                                            <div class="panel panel-info" style="margin: 10px">

                                                <div class=" panel panel-body">
                                                    <div class="row">
                                                        <div class="col-lg-3">
                                                            Acedemic Year
                              <asp:DropDownList ID="ddlyear" CssClass="form-select" TabIndex="4" runat="server">
                              </asp:DropDownList>
                                                        </div>
                                                        <div class="col-lg-3">
                                                            Form ID
   <asp:TextBox ID="txt_formid" runat="server" CssClass="form-control" placeholder="Enter Form ID"></asp:TextBox>
                                                            <asp:HiddenField ID="hidden_form_no" runat="server" ClientIDMode="Static" />
                                                            <asp:HiddenField ID="hidden_grp_id" runat="server" ClientIDMode="Static" />
                                                            <asp:HiddenField ID="hidden_gender" runat="server" ClientIDMode="Static" />
                                                            <asp:HiddenField ID="hidden_category" runat="server" ClientIDMode="Static" />
                                                        </div>
                                                        <div class="col-lg-1">
                                                            <br />
                                                            <asp:LinkButton ID="lnksearch" runat="server" CssClass="btn btn-primary" OnClick="lnksearch_Click"><span class="bi bi-search"></span></asp:LinkButton>
                                                        </div>
                                                        <div id="studid" class="col-lg-2">
                                                            <br />
                                                            <asp:Label runat="server" ID="lblstudid" CssClass="btn btn-outline-success form-control" Visible="false"></asp:Label>
                                                        </div>
                                                        <div id="Div2" class="col-lg-2">
                                                            <asp:Label runat="server" ID="chkMeritListDate"></asp:Label>
                                                            <%--<asp:CheckBox ID="chkMeritListDate" runat="server" />--%>
                                                        </div>


                                                    </div>
                                                    <br />
                                                    <div class="row">
                                                        <div class="col-lg-3">
                                                            First Name
                 <asp:TextBox ID="txt_fname" runat="server" CssClass="form-control"></asp:TextBox>

                                                        </div>
                                                        <div class="col-lg-3">
                                                            Middle Name
                 <asp:TextBox ID="txt_mname" runat="server" CssClass="form-control"></asp:TextBox>

                                                        </div>
                                                        <div class="col-lg-3">
                                                            Last Name
                 <asp:TextBox ID="txt_lname" runat="server" CssClass="form-control"></asp:TextBox>

                                                        </div>
                                                        <div class="col-lg-3">
                                                            <div>Date</div>
                                                            <asp:TextBox type="text" ID="txt_birthdate" class="form-control" runat="server" CssClass="form-control"></asp:TextBox>
                                                        </div>
                                                    </div>


                                                </div>

                                            </div>
                                            <div class="panel panel-info" style="margin: 10px">
                                                <div class=" panel panel-body">
                                                    <div class="row">
                                                        <div class="col-lg-3 ">
                                                            Faculty Name
                              <asp:DropDownList ID="ddlfaculty" CssClass="form-select" TabIndex="4" runat="server">
                              </asp:DropDownList>
                                                        </div>
                                                        <div class="col-lg-3 ">
                                                            Course Name
                              <asp:DropDownList ID="ddlcourse" CssClass="form-select" TabIndex="4" runat="server">
                              </asp:DropDownList>
                                                        </div>
                                                        <div class="col-lg-3 ">
                                                            Subcourse Name
                              <asp:DropDownList ID="ddlsubcourse" CssClass="form-select" TabIndex="4" runat="server">
                              </asp:DropDownList>
                                                        </div>
                                                        <div class="col-lg-3 ">
                                                            Group Name
                              <asp:DropDownList ID="ddlgroup" CssClass="form-select" TabIndex="4" runat="server">
                              </asp:DropDownList>
                                                        </div>
                                                    </div>

                                                </div>

                                            </div>
                                            <div id="dialog" style="display: none" align="center">
                                                Already an taken. Do you want to cancel it and transfer this one ??
                                            </div>
                                            <br />
                                            <div class="panel panel-info" style="margin: 10px" id="gridpanel">
                                                <div class=" panel panel-body">
                                                    <div class="row">
                                                        <asp:GridView ID="grid_studentadm" runat="server" Style="text-align: left;" AutoGenerateColumns="False" CssClass="table table-bordered">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Student ID">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbl_stud_id" runat="server" Text='<%# Eval("StudId") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Student Name">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbl_studentname" runat="server" Text='<%# Eval("StudentName") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Group Title">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbl_group" runat="server" Text='<%# Eval("GroupTitle") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Total Fees">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbl_totalfees" runat="server" Text='<%# Eval("TotalAmount") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Fees Paid">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbl_feespaid" runat="server" Text='<%# Eval("PaidAmount") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Fees Balance">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbl_fbalpaid" runat="server" Text='<%# Eval("Balance") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Select" HeaderStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lnk_select" runat="server" CssClass="btn btn-outline-primary bi bi-link-45deg" OnClick="lnk_select_Click">
                                                                        </asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>

                                                    </div>
                                                </div>
                                            </div>
                                            <div class="panel panel-info" style="margin: 10px">
                                                <div class=" panel panel-body">
                                                    <div class="row">
                                                        <div class="col-lg-2">
                                                            <asp:Button runat="server" ID="btn_confirm" class="btn btn-block btn-primary form-control" Text="Confirm" OnClick="btn_confirm_Click" />
                                                            <%-- data-toggle="modal" data-target="#myEditModal"--%>
                                                        </div>
                                                        <div class="col-lg-3" style="display: none">
                                                            <asp:Button runat="server" ID="btn_transfer" class="btn btn-block btn-primary" Text="Cancel and Transfer" />
                                                        </div>
                                                        <div class="col-lg-2">
                                                            <a id="btn_refresh" class="btn btn-block btn-primary form-control" href="javascript:location.reload(true);">Refresh</a>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function redirect(name) {
            window.open(name);
        }
    </script>
</asp:Content>

