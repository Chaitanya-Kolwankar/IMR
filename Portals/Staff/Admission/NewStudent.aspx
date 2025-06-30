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
   <asp:TextBox ID="txt_formid" runat="server" CssClass="form-control" placeholder="Enter Form ID"></asp:TextBox>

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

                                                <table id="grid_studentadm" class="table table-inverse" style="background-color: #D9EDF7"></table>
                                                <%-- table table-condensed table-bordered table-striped  style="width: 97%; margin-left: 15px"--%>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="panel panel-info" style="margin: 10px">
                                        <div class=" panel panel-body">
                                            <div class="row">
                                                <div class="col-lg-1">

                                                    <a id="btn_confirm" class="btn btn-block btn-primary">Confirm</a>  <%-- data-toggle="modal" data-target="#myEditModal"--%>
                                                </div>

                                                <div class="col-lg-2">
                                                    <a id="btn_transfer" class="btn btn-block btn-primary">Cancel and Transfer</a>

                                                </div>
                                                <div class="col-lg-1 ">

                                                    <a id="btn_refresh" class="btn btn-block btn-primary">Refresh</a>
                                                </div>
                                            </div>
                                        </div>
                                    </div>



                                    <!-- Edit Modal -->
                                    <div class="modal fade" id="myEditModal" role="dialog">
                                        <div class="modal-dialog">
                                            <!-- Modal content -->
                                            <div class="modal-content">
                                                <div class="modal-header" style="background-color: #337ab7">
                                                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                                                    <h4 class="modal-title" style="color: white;" id="modalHeader">Fees Entry </h4>
                                                </div>
                                                <div class="modal-body">


                                                    <div class="panel panel-info">
                                                        <%-- <div class="panel-heading">
                            <div class="row">
                                <div class="col-lg-8">
                                    <h3>FY Fees Entry</h3>
                                </div>

                            </div>
                        </div>--%>
                                                        <div class=" panel panel-body">
                                                            <div class="row">

                                                                <div class="col-lg-4">
                                                                    Student ID : 
                                    <%--  <asp:Label runat="server" ID="lblstud_id"></asp:Label>--%>
                                                                    <%-- <label id="lblstud_id"></label>--%>
                                                                    <span id="lblstud_id"></span>
                                                                </div>

                                                            </div>
                                                            <br />
                                                            <div class="row">
                                                                <div class="col-lg-12">
                                                                    Name :
       <%-- <asp:Label runat="server" ID="lblname"></asp:Label>--%>
                                                                    <span id="lblstudname"></span>

                                                                </div>
                                                            </div>

                                                            <br />
                                                            <div class="row">
                                                                <div class="col-lg-6">
                                                                    SubCourse :
               <%-- <asp:Label runat="server" ID="lblsubcourse"></asp:Label>--%>
                                                                    <span id="lblsubcourse"></span>

                                                                </div>
                                                            </div>
                                                            <br />
                                                            <div class="row">
                                                                <div class="col-lg-6">
                                                                    Group :
               <%-- <asp:Label runat="server" ID="lblgroup"></asp:Label>--%>
                                                                    <span id="lblgroup"></span>

                                                                </div>
                                                            </div>
                                                            <br />
                                                            <div class="row">
                                                                <div class="col-lg-6">
                                                                    Category  :          
                         <span id="lblcategory"></span>

                                                                </div>
                                                            </div>
                                                        </div>


                                                    </div>


                                                    <div class="panel panel-info">

                                                        <div class=" panel panel-body">

                                                            <div class="row">

                                                                <div class="col-lg-4">
                                                                    Amount
            <asp:TextBox ID="txt_amount" runat="server" CssClass="form-control input-sm"></asp:TextBox>

                                                                </div>
                                                                <div class="col-lg-4">
                                                                    Fees Pay
                          <asp:TextBox ID="txt_feespay" runat="server" CssClass="form-control input-sm">
                       
                          </asp:TextBox>
                                                                </div>
                                                                <%--  <div class="col-lg-1 " style="padding-top:18px">
                                    <a id="fee"  class="btn-success btn btn-md" > 
                                        <span class="glyphicon glyphicon-asterisk"></span>
                                    </a>

                                </div>--%>
                                                                <div class="col-lg-4 ">
                                                                    Receipt No
                          <asp:TextBox ID="txt_receiptno" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <br />

                                                            <div class="row">
                                                                <div class="col-lg-6 ">
                                                                    Remark
               <asp:DropDownList ID="dobremark" runat="server" CssClass="form-control input-sm">
                   <asp:ListItem>--Select--</asp:ListItem>
                   <asp:ListItem>Management Quotta </asp:ListItem>
                   <asp:ListItem>Management Discount</asp:ListItem>
                   <asp:ListItem>Sports</asp:ListItem>
                   <asp:ListItem>Freeship / Scholarship</asp:ListItem>
                   <asp:ListItem>Admission Permission</asp:ListItem>

               </asp:DropDownList>
                                                                </div>
                                                                <div class="col-lg-6 ">
                                                                    Authorized By
                          <%--<asp:TextBox ID="txt_auth" runat="server" CssClass="form-control input-sm"></asp:TextBox>--%>
                                                                    <input type="text" class="form-control ui-autocomplete-input" name="autocomplete" id="txt_auth" value="" style="" autocomplete="off" />

                                                                </div>

                                                            </div>
                                                            <br />
                                                            <div class="row">
                                                                <div class="col-lg-6 ">
                                                                    Pay Mode
                      <asp:DropDownList ID="dobpaymode" runat="server" CssClass="form-control input-sm">
                          <asp:ListItem>--Select--</asp:ListItem>
                          <asp:ListItem>Cash</asp:ListItem>
                          <asp:ListItem>Cheque</asp:ListItem>
                          <asp:ListItem>DD</asp:ListItem>
                          <asp:ListItem>Card Payment</asp:ListItem>
                          <asp:ListItem>NEFT</asp:ListItem>
                          <asp:ListItem>Online Pay</asp:ListItem>
                      </asp:DropDownList>

                                                                </div>

                                                                <div class="col-lg-6" id="divcard">
                                                                    Card No. :
            <asp:TextBox ID="txt_card_no" runat="server" CssClass="form-control input-sm"></asp:TextBox>

                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="panel panel-info" id="divbank">
                                                    <div class=" panel panel-body">
                                                        <div class="row">

                                                            <div class="col-lg-6">
                                                                Bank Name
            <%--<asp:TextBox ID="txt_bankname" runat="server" CssClass="form-control input-sm"></asp:TextBox>--%>
                                                                <input type="text" class="form-control ui-autocomplete-input" name="autocomplete" id="txt_bankname" value="" style="" autocomplete="off" />

                                                            </div>
                                                            <div class="col-lg-6">
                                                                Branch Name
            <asp:TextBox ID="txt_branchname" runat="server" CssClass="form-control input-sm"></asp:TextBox>

                                                            </div>
                                                        </div>
                                                        <br />
                                                        <div class="row">
                                                            <div class="col-lg-6 " id="chqdt">
                                                                <div class="hidden-md hidden-sm hidden-xs">Cheque Date <i>(dd-mm-yyyy)</i></div>
                                                                <div class="hidden-lg">Select Date </div>
                                                                <input type="text" id="chq_date" class="form-control input-sm" />
                                                            </div>
                                                            <div class="col-lg-6">
                                                                Cheque No.
            <asp:TextBox ID="txtchequeno" runat="server" CssClass="form-control input-sm" MaxLength="6"></asp:TextBox>

                                                            </div>

                                                        </div>
                                                    </div>


                                                </div>

                                                <div class="panel panel-info" id="divbank2">
                                                    <div class=" panel panel-body">
                                                        <div class="row">

                                                            <div class="col-lg-6">
                                                                Bank Name
            <asp:TextBox ID="txt_bankname2" runat="server" CssClass="form-control input-sm"></asp:TextBox>

                                                            </div>
                                                            <div class="col-lg-6">
                                                                Branch Name
            <asp:TextBox ID="txt_branchname2" runat="server" CssClass="form-control input-sm"></asp:TextBox>

                                                            </div>
                                                        </div>
                                                        <br />
                                                        <div class="row">
                                                            <div class="col-lg-6 " id="chqdt2">
                                                                <div class="hidden-md hidden-sm hidden-xs">Cheque Date <i>(dd-mm-yyyy)</i></div>
                                                                <div class="hidden-lg">Select Date </div>
                                                                <input type="text" id="chq_date2" class="form-control input-sm" />
                                                            </div>
                                                            <div class="col-lg-6">
                                                                Transaction No.
            <asp:TextBox ID="txtchequeno2" runat="server" CssClass="form-control input-sm" MaxLength="10"></asp:TextBox>

                                                            </div>

                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="panel panel-info" style="margin: 10px; flex-align: center">
                                                    <div class=" panel panel-body">
                                                        <div class="row">
                                                            <div class="col-lg-offset-4 col-lg-4">
                                                                <%-- <asp:Button ID="btn_fees" runat="server" class="btn btn-block btn-success" Text="Fees" />--%>
                                                                <a id="btnfeesconfirm" class="btn btn-block btn-success" style="flex-align: center">Fees</a>
                                                            </div>

                                                        </div>
                                                    </div>
                                                </div>

                                            </div>
                                        </div>
                                    </div>

                                    <div class="modal fade" id="idmodel" role="dialog" style="height: 10px; width: 10px">
                                        <div class="modal-dialog">
                                            <!-- Modal content -->
                                            <div class="modal-content">
                                                <div class="modal-header" style="background-color: #337ab7">
                                                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                                                    <h4 class="modal-title" style="color: black;" id="H1"></h4>
                                                </div>
                                                <div class="modal-body">
                                                    <div class=" panel panel-body">
                                                        <div class="row">
                                                            <div class="col-lg-4">
                                                                <span id="stdid"></span>
                                                            </div>

                                                        </div>
                                                    </div>
                                                    <br />

                                                    <div class="panel panel-info" style="margin: 10px; flex-align: center">
                                                        <div class=" panel panel-body">
                                                            <div class="row">
                                                                <div class="col-lg-6 ">
                                                                    <%-- <asp:Button ID="btn_fees" runat="server" class="btn btn-block btn-success" Text="Fees" />--%>
                                                                    <a id="btn_ok" class="btn btn-block btn-success">OK</a>
                                                                </div>

                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>


                                    <!-- Edit Modal  for part amount-->
                                    <div class="modal fade" id="feemodel" role="dialog">
                                        <div class="modal-dialog">
                                            <!-- Modal content -->
                                            <div class="modal-content">
                                                <div class="modal-header" style="background-color: #7e8f9e">
                                                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                                                    <h4 class="modal-title" style="color: black;" id="H2"></h4>
                                                </div>
                                                <div class="modal-body">

                                                    <div class="panel panel-info">
                                                        <div class="panel-heading">
                                                            <div class="row">
                                                                <div class="col-lg-8">
                                                                    <h3>Permission Fees Entry</h3>
                                                                </div>

                                                            </div>
                                                        </div>
                                                        <div class=" panel panel-body">
                                                            <div class="row">

                                                                <div class="col-lg-4">
                                                                    Password : 
                                                                </div>
                                                                <div class="col-lg-4">
                                                                    <asp:TextBox ID="txtpasswd" runat="server" CssClass="form-control" placeholder="Password"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <br />
                                                            <div class="row">
                                                                <div class="col-lg-offset-4 col-lg-4">
                                                                    <a id="btn_okpass" class="btn btn-block btn-success">OK</a>
                                                                </div>

                                                            </div>
                                                        </div>

                                                    </div>

                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="modal fade" id="transfermodel" role="dialog">
                                        <div class="modal-dialog">
                                            <!-- Modal content -->
                                            <div class="modal-content">
                                                <div class="modal-header" style="background-color: #337ab7">
                                                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                                                    <h4 class="modal-title" style="color: white;" id="H3">ADMISSION</h4>
                                                </div>
                                                <div class="modal-body">

                                                    <div class="panel panel-info">

                                                        <div class=" panel panel-body">

                                                            <div class="row">
                                                                <div class="col-lg-12">
                                                                    <span id="messg" style="font-size: medium"></span>
                                                                </div>
                                                            </div>
                                                            <br />
                                                            <div class="row">
                                                                <div class="col-lg-offset-4 col-lg-2">
                                                                    <a id="btn_yes" class="btn btn-block btn-success">YES</a>
                                                                </div>
                                                                <div class="col-lg-2">
                                                                    <a id="btn_no" class="btn btn-block btn-danger">NO</a>
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

