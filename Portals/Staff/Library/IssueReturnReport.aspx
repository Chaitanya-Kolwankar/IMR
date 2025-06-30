<%@ Page Title="" Language="C#" MasterPageFile="~/Portals/Staff/MasterPage.master" AutoEventWireup="true" CodeFile="IssueReturnReport.aspx.cs" Inherits="IssueReturnReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

        <link href="../../../Assets/css/jquery.datetimepicker.css" rel="stylesheet" />
    <%--<link href="../../../Assets/notify-master/css/notify.css" rel="stylesheet" />--%>
    <!------------------------>

    <div id="main" class="main">
        <div class="pagetitle " style="font-size: 32px; margin-left: 34px; font-weight: 300; color: #012970;">
            Circulation Report 
        </div>
       <div class="container-fluid">
            <div class="row" style="margin-top: 10px">
                <div class="col-lg-12">
                    <div class="card card-info" style="margin-top: 10px;">

                        <div class=" card card-body">
                            <div class="row" style="margin-top: 10px;">
                                <div class="col-lg-12"></div>
                                <div class="col-lg-2 ">
                                    Connect To:
                                <select class="form-control" id="ddlselect">
                                    <option>Viva Engg</option>
                                    <option>MCA</option>
                                    <option>pharmacy</option>
                                    <option>Viva IMR</option>
                                    <%--<option>Viva IMS</option>--%>
                                </select>
                                </div>
                            </div>

                            <div class="row" style="margin-top: 7px;">

                                <div class="col-lg-3">
                                    Member Type:
                                <select class="form-control" id="ddlMembertype">
                                    <option>--Select--</option>
                                    <option value="E">Employee</option>
                                    <option value="S">Student</option>
                                </select>
                                </div>

                                <div class="col-lg-3">
                                    Issue/Return:
                                    <select class="form-control" id="ddlIssuereturn">
                                        <option>--Select--</option>
                                        <option value="0">Issue</option>
                                        <option value="1">Return</option>
                                    </select>
                                </div>

                                <div class="col-lg-3">
                                    <div class="hidden-md hidden-sm hidden-xs">&nbsp;From Date:</div>
                                    <div class="col-lg-12">
                                        <input type="text" id="datetimepicker1" autocomplete="off" readonly="readonly" placeholder="Date" class="form-control" />
                                        <span class="date-icon fa fa-calendar" aria-hidden="true"></span>
                                    </div>
                                </div>

                                <div class="col-lg-3">
                                    <div class="hidden-md hidden-sm hidden-xs">&nbsp; To Date:</div>
                                    <div class="col-lg-12">
                                        <input type="text" id="datetimepicker2" autocomplete="off" readonly="readonly" placeholder="Date" class="form-control" />
                                        <span class="fa fa-calendar-o form-control-feedback left" aria-hidden="true"></span>
                                    </div>
                                </div>

                            </div>

                            <div class="row">
                                <div class="col-lg-2"></div>
                                <div class="col-lg-2" style="padding-top: 28px;">
                                    <div class="form-group">
                                        <a id="btnsearch" class="btn btn-block btn-success" style="width: 100%;">Search</a>
                                    </div>
                                </div>
                                <div class="col-lg-2" style="padding-top: 28px;">
                                    <div class="form-group">
                                        <a id="btnclear" class="btn btn-block btn-success" style="width: 100%;">Clear</a>
                                    </div>
                                </div>
                                <div class="col-lg-2" style="padding-top: 28px;">
                                    <div class="form-group">
                                        <a id="btnExcel" style="display: none; width: 100%;" class="btn btn-block btn-success">Excel</a>
                                    </div>
                                </div>
                                <div class="col-lg-2"></div>
                            </div>
                        </div>

                        <div class="row topPadd" id="rowgridd" style="display: none; margin-top: 20px;">
                            <div class="col-lg-12">
                                <div class="well well-lg">
                                    <div class="row">
                                        <div class="col-lg-12">
                                            <div class="table-responsive" style="overflow-y: scroll; overflow-x: scroll; height: 600px; margin-left: 25px; overflow-x: scroll; text-align: left">
                                                <table id="tblfill" class="table table-container table-bordered" style="text-align: left">
                                                </table>
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
    <!------------------------>
    <%--<script src="datetime/jquery.js"></script>--%>
    <script type="text/javascript">
        var empId = '<%=Session["emp_id"] %>'
    </script>
    <script src="../../../Assets/JsForm/Issuereturnreport.js"></script>
    <script src="../../../Assets/js/jquery.datetimepicker.js"></script>
    <%--<script src="../../../Assets/js/jquery.min.js"></script>--%>
    <script src="../../../Assets/notify-master/js/notify.js"></script>
    <script src="../../../Assets/notify-master/js/prettify.js"></script>
    <script src="../../../Assets/confirmJs/jquery.confirm.min.js"></script>
    <script src="../../../Assets/vendor/nprogress/nprogress.js"></script>
</asp:Content>

