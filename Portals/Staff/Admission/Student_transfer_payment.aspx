<%@ Page Title="" Language="C#" MasterPageFile="~/Portals/Staff/MasterPage.master" AutoEventWireup="true" CodeFile="Student_transfer_payment.aspx.cs" EnableEventValidation="false" Inherits="Student_transfer_payment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%--<link href="css/jquery.datetimepicker.css" rel="stylesheet" />--%>
    <link href="../../../assets/vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <script src="../../../assets/vendor/bootstrap/js/bootstrap.bundle.min.js"></script>
    <link href="../../../Assets/notify-master/css/notify.css" rel="stylesheet" />
    <link href="../../../Assets/notify-master/css/prettify.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<%--    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
</asp:ScriptManager>--%>

    <div id="main" class="main">
    <div class="container-fluid my-1">
        <div class="card">
            <div class="container-fluid">
                <div class="row">

                    <div class="panel panel-primary">
                        <div class="card-title" style="font-size: large">Student Transfer and Fee Payment</div>
                        <div class="panel panel-primary">
                            <%--<div class="panel-heading">
            <div class="row">
                <div class="col-lg-6">
                    <h2>Student Transfer & Fee Payment</h2>
                </div>
                <div class="col-lg-6">
                    <a href="Helpfile/Inhouse_student_transfer.pdf" style="color: white; float: right; margin-top: 5px;" target="_blank"><i style="font-size: 26px" data-toggle="tooltip" data-placement="top" title="Help!" class="fa fa-question-circle"></i></a>
                </div>
            </div>
        </div>--%>
                            <div class="panel-body">
                                <div class="row">
                                    <div class="col-lg-3">
                                        Academic Year
                              <asp:DropDownList ID="ddl_year" CssClass="form-control" TabIndex="4" runat="server" AutoPostBack="false">
                              </asp:DropDownList>
                                    </div>
                                    <div class="col-lg-3">
                                        Student ID
   <input type="text" id="txt_stud_id" class="form-control" placeholder="Enter Student ID" />
                                    </div>
                                    <div class="col-lg-3">
                                        <br />
                                        <asp:Button ID="btn_refresh" class="btn btn-success btn-block" OnClick="btn_refresh_Click" runat="server" Text="Refresh" />
                                    </div>
                                </div>
                                <div class="panel panel-info" style="margin: 10px; display: none;" id="gridpanel">
                                    <div class=" panel panel-body">
                                        <div class="row">
                                            <table id="grid_studentadm" class="table table-condensed table-bordered" style="width: 100%"></table>
                                        </div>
                                    </div>
                                </div>
                                <br />
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

    <script src="../../../Assets/notify-master/js/jquery-1.11.0.js"></script>
    <script src="../../../Assets/js/jquery.datetimepicker.js"></script>
    <script src="../../../Assets/JsForm/student_transfer_payment.js"></script>
    <script src="../../../Assets/confirmJs/jquery.confirm.min.js"></script>
    <script src="../../../Assets/notify-master/js/notify.js"></script>
    <script src="../../../Assets/notify-master/js/prettify.js"></script>

</asp:Content>

