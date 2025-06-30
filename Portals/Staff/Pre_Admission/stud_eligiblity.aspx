<%@ Page Title="" Language="C#" MasterPageFile="~/Portals/Staff/MasterPage.master" AutoEventWireup="true" CodeFile="stud_eligiblity.aspx.cs" Inherits="stud_eligiblity" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="head">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
<script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
<script src="https://cdn.jsdelivr.net/npm/popper.js@1.12.9/dist/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
<script src="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.js"></script>

    <link href="../../../Assets/multiselect/css/bootstrap-multiselect.css" rel="stylesheet" />
    <script src="../../../Assets/multiselect/js/bootstrap-multiselect.js"></script>

    <link href="../../../Assets/notify-master/css/notify.css" rel="stylesheet" />
    <script src="../../../Assets/notify-master/js/notify.js"></script>
    <%--<link href="preloader/preloader.css" rel="stylesheet" />--%>
    <link href="css/preloader.css" rel="stylesheet" />
     <style>
        .multiselect {
            margin-top: 5px;
            border: 1px solid #ced4da;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
     <div id="main" class="main">
        <div class="container-fluid my-1">
            <div class="card">
                <div class="container-fluid">
                    <div class="row">

                        <div class="panel panel-primary">
                            <div class="card-title" style="font-size: large">Search Student </div>
                            <div class="panel-body">
    <div class="container-fluid">
       <%-- <div class="panel-heading">
            <div class="row">
                <div class="col-lg-6">
                    <h2>STUDENT ELIGIBILITY</h2>
                </div>
                <div class="col-lg-6">
                    <a href="Helpfile/Stud_eligibility.pdf" style="color: white; float: right; margin-top: 5px;" target="_blank"><i style="font-size: 26px" data-toggle="tooltip" data-placement="top" title="Help!" class="fa fa-question-circle"></i></a>
                </div>
                
            </div>
        </div>--%>
        <span id="dmltype" style="display: none"></span>
            <div class="row">
                <%--<div class="col-lg-2">
                    <span id="lbl_from_year">From Year</span><span style="color: red; margin-bottom: 0px">*</span>
                    <select id="ddl_fromyear" class="form-control">
                        <option>--Select--</option>
                    </select>
                </div>--%>

                <div class="col-lg-2">
                    <span id="lbltoyear">To Year</span><span style="color: red; margin-bottom: 0px">*</span>
                    <select id="ddltoyear" class="form-control">
                        <option>--Select--</option>
                    </select>
                </div>
                <div class="col-lg-2">
                    <span id="lblcrs">Course</span><span style="color: red; margin-bottom: 0px">*</span>
                    <select id="ddlcourse" class="form-control">
                        <option>--Select--</option>
                    </select>
                </div>

                <div class="col-lg-2">
                    <span id="lblscrs">Sub-Course</span><span style="color: red; margin-bottom: 0px">*</span>
                    <select id="ddlsubgrp" class="form-control">
                        <option>--Select--</option>
                    </select>
                </div>
                <div class="col-lg-2">
                    <span id="lblfgrp">From Group</span><span style="color: red; margin-bottom: 0px">*</span>
                    <select id="ddltogroup" class="form-control">
                        <option>--Select--</option>
                    </select>
                </div>
                <div class="col-lg-3" runat="server" id="show" style="display: none;">
                    <span id="lbltgrp">To Group</span>
                    <br />
                    <select class="select2_multiple form-control" id="lst_maping" multiple="multiple">
                    </select>
                </div>
            </div>
            <br />
            <div class="row">
                <br />
                <div class="col-lg-2" style="padding-left: 50px;">
                    <input type="checkbox" name="Search" value="Search" id="chk_search" />
                    Search Student
                </div>
                <div class="col-lg-2">
                    <input type="text" id="txt_search" class="form-control" disabled="disabled" placeholder="Student ID" />
                </div>
                <div class="col-lg-2">
                    <button type="button" style="width:100%" class="btn btn-primary" id="btn_IDsearch" disabled="disabled">Search</button>
                </div>
            </div>

            <div class="row">
                <br />
                <div class="col-lg-2" style="padding-left: 50px;">
                    <input type="checkbox" name="Search" value="Search" id="chk_roll" />
                    Roll No. Wise
                </div>
                <div class="col-lg-2" id="rollfrom" style="display:none">
                    <input type="text" id="txt_from" class="form-control" placeholder="From Roll No." />
                </div>
                <div class="col-lg-2" id="rollto" style="display:none">
                    <input type="text" id="txt_to" class="form-control"  placeholder="To Roll No." />
                </div>
            </div>

            <div class="row">
                <div class="col-lg-2">
                    <br />
                    <a type="button" id="btn_get" style="width:100%" class="btn btn-primary" href="#"><span class="glyphicon glyphicon-download-alt"></span>&nbsp Getdata</a>
                </div>
                <div class="col-lg-2">
                    <br />
                    <a type="button" id="btnreset" style="width:100%" class="btn btn-primary" href="#"><span class="glyphicon glyphicon-refresh"></span>Reset</a>
                </div>
                <div class="col-lg-2">
                    <br />
                    <a type="button" id="btnsave" style="width:100%" class="btn btn-primary" href="#"><span class="glyphicon glyphicon-saved"></span>Save</a>
                </div>
                <div class="col-lg-2">
                    <br />
                    <a type="button" id="btn_excel" style="width:100%;display: none" class="btn btn-primary"  href="#"><span class="glyphicon glyphicon-download-alt"></span>Get Excel</a>
                </div>
            </div>
        
        <br />
        <div class="well well-lg" id="divgrid" style="display: none">
            <div class="panel panel-primary">
                <div class="panel-body">
                    <div class="table-responsive" style="overflow-y: scroll; height: 600px; width: 100%; overflow-x: scroll;">
                        <table id="dgv_load" class="table table-condensed table-bordered">
                        </table>
                    </div>
                </div>
            </div>
        </div>
            
        </div>
    

    <center style="padding-top: 400px;">  
        <div class="loader">Loading...</div>       
        </center>
                                </div></div></div></div></div></div></div>
    <div class="modal" id="searchModal" role="dialog">
        <div class="modal-dialog">
            <div class="modal-content" style="overflow-y: scroll; height: 250px; width: 1002px; overflow-x: scroll;">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Student Details</h4>
                </div>
                <div class="modal-body">
                    <div class="table-responsive" style="overflow-y: scroll; height: 250px; overflow-x: scroll;">
                        <table id="gv_modal" class="table table-condensed table-bordered">
                        </table>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript">
        var empId = '<%=Session["emp_id"] %>'
        var group_ids = '<%=Session["group_ids"] %>'
        var from_yr = '<%=Session["acdyear"] %>'
        $(document).ready(function () {
            $('#lst_maping').multiselect({
                includeSelectAllOption: true,
                buttonWidth: '300px'
            });
        });
    </script>
    <script src="../../../Assets/JsForm/stud_eligiblity.js"></script>
    <%--<script src="jsForms/stud_eligiblity.js?ver<%=DateTime.Now.Ticks.ToString()%>"></script>--%>
</asp:Content>

