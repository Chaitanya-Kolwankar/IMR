<%@ Page Title="" Language="C#" MasterPageFile="~/Portals/Staff/MasterPage.master" enableEventValidation="false" AutoEventWireup="true" CodeFile="FeeEntry_New.aspx.cs" EnableSessionState="True" Inherits="FeeEntry_New" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="../../../Assets/js/jquery.datetimepicker.js"></script>
    <link href="../../Assets/css/jquery.datetimepicker.css" rel="stylesheet" />
    <link href="../../../Assests/notify-master/css/notify.css" rel="stylesheet" />
    <script src="../../../Assests/notify-master/js/notify.js"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/jquery-confirm/3.3.2/jquery-confirm.min.css">
<script src="https://cdnjs.cloudflare.com/ajax/libs/jquery-confirm/3.3.2/jquery-confirm.min.js"></script>
v

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main" class="main" style="text-transform:capitalize;margin-top:30px">

        <div class="container-fluid">
            <div class="pagetitle " style="font-size: 32px; margin-left: 34px; font-weight: 300; color: #012970;">
                Student Fees Entry
            </div>
            <div class="container-fluid ">
                <div class="card">
                    <div class="card-body">
                        <br />
                        <div class="container-fluid">
                <div class="row">
                    
                    <div class="col-lg-3">
                        <div class="form-group">
                            <input name="Student ID" maxlength="8" type="text" id="txt_studid" runat="server" class="form-control input-sm"  placeholder="Enter Student ID" />
                        </div>
                    </div>
                    <div class="col-lg-1">
                        <div class="form-group">
                            <a id="btn_search" class="btn btn-success btn-sm"><i class="bi bi-search"></i></a>
                        </div>
                    </div>
                    <div class="col-lg-3">
                        <div class="form-group">
                            <a class="btn btn-block btn-success" id="btn_refresh">Refresh</a>
                        </div>
                    </div>
                </div>
                            <br />
                <div class="row" id="feediv" style="display: none;">
                    <div class="panel panel-primary" id="feepanel">
                        <div class=" panel panel-body">
                            <div class="row">
                                <div class="col-lg-3">
                                    Name :
                                    <span id="lblstudname"></span>
                                </div>
                                <div class="col-lg-3">
                                    Course :          
                                    <span id="lblsubcourse"></span>
                                </div>

                                <div class="col-lg-3">
                                    Class  :          <span id="lblclass"></span>
                                </div>
                                <div class="col-lg-3">
                                    Caste :     <span id="lblCaste"></span>

                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-lg-3">
                                    Group :
                                    <span id="lblgroup"></span>
                                </div>
                                <div class="col-lg-3">
                                    Total Course Fees  :          <span id="lblcoursefees"></span>
                                </div>


                                <div class="col-lg-3">
                                    Total Paid Amount :             <span id="lbl_preamount"></span>

                                </div>
                                <div class="col-lg-3">
                                    Academic Year :         <span id="lbl_academicyear"></span>

                                </div>
                            </div>

                            <div class="row" style="display: none;">
                                <div class="col-lg-3" style="display: none;">
                                    Total Refunded Amount :     <span id="lbl_refundedamount"></span>

                                </div>
                                <div class="col-lg-3" style="display: none;">
                                    Total Refundable Amount :       <span id="lbl_refundableamount"></span>

                                </div>

                                <div class="col-lg-3" style="display: none;">
                                    Total Balance Amount :      <span id="lbl_balanceamount"></span>

                                </div>
                            </div>

                            <div class="row">
                                <div class="col-lg-3" id="remarkdiv" style="display: none">
                                    Remark :        <span id="lbl_Remark"></span>
                                </div>
                            </div>

                            
                            <div class="row">
                                <div class="col-lg-3">
                                    Fees Type
                            <asp:DropDownList ID="ddlstructure" runat="server" CssClass="form-control input-sm">
                                <asp:ListItem>--Select--</asp:ListItem>
                                <asp:ListItem>All Fees</asp:ListItem>
                                <asp:ListItem>Narration Fees</asp:ListItem>
                                <%--<asp:ListItem>Tution/Development Fees</asp:ListItem>
                                <asp:ListItem>NASA FUND</asp:ListItem>--%>
                                <%--<asp:ListItem>ICHH Fees</asp:ListItem>--%>
                                <%-- <asp:ListItem>Other Fees</asp:ListItem>--%>
                                <%--<asp:ListItem>Refund Fees</asp:ListItem>--%>
                            </asp:DropDownList>
                                </div>
                                <div class="col-lg-6">
                                    <div class="row" id="refundiv" style="display: none;">
                                        <div class="col-lg-6">
                                            Amount : 
                                         <input type="text" id="txtrefund" class="form-control" />
                                        </div>
                                        <div class="col-lg-6">
                                            Year : 
                                         <%--<input type="text" id="txtrefdet" class="form-control" />--%>
                                            <asp:DropDownList ID="ddlnarryear" runat="server" CssClass="form-control input-sm">
                                                <asp:ListItem>--Select--</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <div class="row" id="fees" style="display: none;">
                                <div class="row">
                                    <div class="col-lg-2">
                                        Pay Mode
                                  <asp:DropDownList ID="ddlpaymode" runat="server" CssClass="form-control input-sm">
                                      <asp:ListItem>--Select--</asp:ListItem>
                                      <asp:ListItem>Cash</asp:ListItem>
                                      <asp:ListItem>Cheque</asp:ListItem>
                                      <asp:ListItem>DD</asp:ListItem>
                                      <asp:ListItem>ECS\NEFT\RTGS</asp:ListItem>
                                      <asp:ListItem>Online Pay</asp:ListItem>
                                  </asp:DropDownList>
                                    </div>
                                    <div class="col-lg-2" style="font-size:18px">
                                        <br />
                                        Receipt No :
                                    <label ID="txtrecipt" runat="server" CssClass="form-control" disabled="disabled"></label>
                                    </div>
                                    <div class="col-lg-2">
                                        Remark :
                                   <asp:DropDownList ID="ddlremark" runat="server" CssClass="form-control input-sm">
                                       <asp:ListItem>--Select--</asp:ListItem>
                                       <%--<asp:ListItem>Admission Permission</asp:ListItem>
                                       <asp:ListItem>Drop Student</asp:ListItem>
                                       <asp:ListItem>Freeship / Scholarship</asp:ListItem>
                                       <asp:ListItem>Management Discount</asp:ListItem>
                                       <asp:ListItem>Management Quota</asp:ListItem>
                                       <asp:ListItem>Part Payment Facility</asp:ListItem>
                                       <asp:ListItem>Provisional</asp:ListItem>
                                       <asp:ListItem>Sports Quota</asp:ListItem>
                                       <asp:ListItem>TWFS</asp:ListItem>
                                       <asp:ListItem>Others</asp:ListItem>--%>
                                   </asp:DropDownList>
                                    </div>
                                    <div class="col-lg-2" id="authodiv">
                                        Authorized By
                                     <asp:DropDownList ID="ddlauthorize" runat="server" CssClass="form-control input-sm">
                                         <asp:ListItem>--Select--</asp:ListItem>
                                     </asp:DropDownList>
                                        <%--<asp:TextBox ID="txt_auth" runat="server" CssClass="form-control input-sm"></asp:TextBox>--%>
                                    </div>
                                    <div class="col-lg-2" style="display: none;" id="divauth">
                                        Authorized By:
                                    <input type="text" id="txtautho" class="form-control" />
                                    </div>
                                    <div class="col-lg-2" id="divcaste">
                                        Caste
                                     <asp:DropDownList ID="ddlcaste" runat="server" CssClass="form-control input-sm">
                                         <asp:ListItem>--Select--</asp:ListItem>
                                         <asp:ListItem>EBC</asp:ListItem>
                                         <asp:ListItem>EWS</asp:ListItem>
                                         <asp:ListItem>NT-1 (NT-B)</asp:ListItem>
                                         <asp:ListItem>NT-2 (NT-C)</asp:ListItem>
                                         <asp:ListItem>NT-3 (NT-D)</asp:ListItem>
                                         <asp:ListItem>OBC</asp:ListItem>
                                         <asp:ListItem>SBC</asp:ListItem>
                                         <asp:ListItem>SC</asp:ListItem>
                                         <asp:ListItem>SEBC</asp:ListItem>
                                         <asp:ListItem>ST</asp:ListItem>
                                         <asp:ListItem>TWFS</asp:ListItem>
                                         <asp:ListItem>VJ/DT(A)</asp:ListItem>
                                     </asp:DropDownList>
                                        <%--<asp:TextBox ID="txt_auth" runat="server" CssClass="form-control input-sm"></asp:TextBox>--%>
                                    </div>
                                    <div class="col-lg-2">
                                        <div class="hidden-md hidden-sm hidden-xs">Pay Date</div>
                                        <%--<div class="hidden-lg">Select Date </div>--%>
                                        <input type="text" id="txtpaydate" class="form-control" />
                                    </div>
                                </div>
                                <br />
                                <div class="row" id="chqddiv" style="display: none;">
                                    <div class="col-lg-2">
                                        Bank Name
                                    <input type="text" id="txt_bnk_name" class="form-control" />
                                    </div>
                                    <div class="col-lg-2">
                                        Branch Name
                                     <input type="text" id="txt_bran_name" class="form-control" />
                                    </div>
                                    <div class="col-lg-2">
                                        <div class="hidden-md hidden-sm hidden-xs">Cheque/DD/NEFT Date <i>(dd-mm-yyyy)</i></div>
                                        <div class="hidden-lg">Select Date </div>
                                        <input type="text" id="chk_date" class="form-control" />
                                    </div>
                                    <div class="col-lg-2">
                                        Cheque/DD/NEFT No.
                                         <input type="text" id="chk_no" class="form-control" maxlength="21" />
                                    </div>
                                    <div class="col-lg-2" style="display: none;" id="statusdiv">
                                        Cheque/NEFT Status:
                                   <asp:DropDownList ID="ddlstatus" runat="server" CssClass="form-control input-sm">
                                       <asp:ListItem>--Select--</asp:ListItem>
                                       <asp:ListItem>Clear</asp:ListItem>
                                       <asp:ListItem>Pending</asp:ListItem>
                                       <asp:ListItem>Bounce</asp:ListItem>
                                   </asp:DropDownList>
                                    </div>

                                </div>
                                <br />
                                <br />
                                <div class="row" id="divtbl" style="display: none;">
                                    <div class="col-lg-12">
                                        <div class="table-responsive" style="height: 100%; WIDTH: 100%; OVERFLOW-X: scroll;">
                                            <table id="tblfees" class="table table-condensed table-bordered table-striped">
                                            </table>
                                        </div>
                                    </div>
                                    <br />
                                    <%-- <div class="col-lg-3"></div>
                                <div class="col-lg-3">TOTAL :
                                <input type="text" id="totaltxt" class="form-control" disabled="disabled" />
                                    </div>
                                <div class="col-lg-3"></div>--%>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-lg-3"></div>
                                    <div class="col-lg-3">
                                        <a id="btnsave" style="width:100%" class="btn btn-success btn-block">Save</a>
                                    </div>
                                    <div class="col-lg-3">
                                        <a id="btnclear" style="width:100%" class="btn btn-success btn-block">Clear</a>
                                    </div>
                                    <div class="col-lg-3"></div>
                                </div>
                            </div>

                            <br />
                            <div class="row" id="transaction" style="display: none">
                                <div class="col-lg-12">
                                    <div class="table-responsive" style="height: 100%; WIDTH: 100%; OVERFLOW-X: scroll;">
                                        <table id="tbltransaction" class="table table-condensed table-bordered table-striped">
                                        </table>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal fade" id="newstud" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                    <div class="vertical-alignment-helper">
                        <div class="modal-dialog modal-xl vertical-align-center" >
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal">
                                        <span aria-hidden="true">&times;</span><span class="sr-only">Close</span>
                                    </button>
                                    <h4 class="modal-title" id="myModalLabel">Student Details</h4>
                                </div>
                                <div class="modal-body">
                                    <div class="row">
                                        <div class="col-lg-12">
                                            <div class="table-responsive" style="height: 100%; WIDTH: 100%;">
                                                <table id="tbldata" class="table table-condensed table-bordered">
                                                </table>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                        </div></div>
                </div>
            </div>
        </div>
        </div>
        <script type="text/javascript">
            var empId = '<%=Session["emp_id"] %>'
            var emp_role = '<%=Session["emp_role"] %>'

        </script>
        <script src="js/jquery.datetimepicker.js"></script>
        <script src="confirmJs/jquery.confirm.min.js"></script>
        <script src="../../../Assets/JsForm/FeeEntryNew.js"></script>
</asp:Content>

