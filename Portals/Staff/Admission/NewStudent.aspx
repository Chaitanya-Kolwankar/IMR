<%@ Page Title="" Language="C#" MasterPageFile="~/Portals/Staff/MasterPage.master" AutoEventWireup="true" CodeFile="NewStudent.aspx.cs" Inherits="Portals_Staff_Admission_Master_NewStudent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
     <script src="../../../Assets/js/jquery.datetimepicker.js"></script>
    <link href="../../../Assets/css/jquery.datetimepicker.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main" class="main">
        <div class="container-fluid my-1">
               <div class="pagetitle " style="font-size: 32px; margin-left: 34px; font-weight: 300; color: #012970;">
            Admission 
            </div>
            <div class="card">
                <div class="container-fluid">
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
                              <asp:DropDownList ID="ddlyear" CssClass="form-control" TabIndex="4" runat="server">
                              </asp:DropDownList>
                                                </div>
                                                <div class="col-lg-3">
                                                    Form ID
   <asp:TextBox ID="txt_formid" runat="server" CssClass="form-control" placeholder="Enter Form ID" OnTextChanged="txt_formid_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                </div>
                                                <div id="studid" class="col-lg-2">
                                                    <asp:Label runat="server" ID="lblstudid" Style="color: red"></asp:Label>
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
                                                    <div class="hidden-md hidden-sm hidden-xs">Date Of Birth <i>(dd-mm-yyyy)</i></div>
                                                    <div class="hidden-lg">Select Date </div>
                                                    <input type="text" id="birthdate" class="form-control" />
                                                </div>
                                            </div>


                                        </div>

                                    </div>
                                    <div class="panel panel-info" style="margin: 10px">
                                        <div class=" panel panel-body">
                                            <div class="row">
                                                <div class="col-lg-3 ">
                                                    Faculty Name
                              <asp:DropDownList ID="ddlfaculty" CssClass="form-control" TabIndex="4" runat="server">
                              </asp:DropDownList>
                                                </div>
                                                <div class="col-lg-3 ">
                                                    Course Name
                              <asp:DropDownList ID="ddlcourse" CssClass="form-control" TabIndex="4" runat="server">
                              </asp:DropDownList>
                                                </div>
                                                <div class="col-lg-3 ">
                                                    Subcourse Name
                              <asp:DropDownList ID="ddlsubcourse" CssClass="form-control" TabIndex="4" runat="server">
                              </asp:DropDownList>
                                                </div>
                                                <div class="col-lg-3 ">
                                                    Group Name
                              <asp:DropDownList ID="ddlgroup" CssClass="form-control" TabIndex="4" runat="server">
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
                                                <asp:GridView runat="server" id="grid_studentadm" class="table table-inverse" style="background-color: #D9EDF7"></asp:GridView>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="panel panel-info" style="margin: 10px">
                                        <div class=" panel panel-body">
                                            <div class="row">
                                                <div class="col-lg-2">
                                                    <asp:Button runat="server" id="btn_confirm" class="btn btn-block btn-primary" test="Confirm" />  <%-- data-toggle="modal" data-target="#myEditModal"--%>
                                                </div>
                                                <div class="col-lg-3" style="display:none">
                                                     <asp:Button runat="server" id="btn_transfer" class="btn btn-block btn-primary" test="Cancel and Transfer" />
                                                </div>
                                                <div class="col-lg-2 ">
                                                    <asp:Button runat="server" id="Button1" class="btn btn-block btn-primary" test="Cancel and Transfer" />
                                                    <a id="btn_refresh" class="btn btn-block btn-primary">Refresh</a>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        var empId = '<%=Session["emp_id"] %>'
        var emp_role = '<%=Session["emp_role"] %>'
        var stud_form_no = '<%=Session["stud_form"] %>'
        var ayid = '<%=Session["acdyear"] %>'
    </script>
    <script src="../../../Assets/JsForm/Admissionconfirm.js"></script>
    <%--<script src="notify-master/js/jquery-1.11.0.js"></script>--%>
    <%--  <script src="js/jquery.datetimepicker.js"></script>
    
    <script src="confirmJs/jquery.confirm.min.js"></script>
    <script src="notify-master/js/notify.js"></script>
    <script src="notify-master/js/prettify.js"></script>
    <script src="autosearchjs/jquery.autocomplete.min.js"></script>--%>
</asp:Content>

