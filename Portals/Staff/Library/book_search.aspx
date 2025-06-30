<%@ Page Language="C#" AutoEventWireup="true" CodeFile="book_search.aspx.cs" Inherits="book_search" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <!--master-->
    <script src="../../../Assets/js/jquery.min.js"></script>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css" />
    <!-- Bootstrap -->
    <%--<link href="vendors/bootstrap/dist/css/bootstrap.min.css" rel="stylesheet" />--%>
    <!-- Font Awesome -->
    <link href="../../../Assets/Fonts/css/font-awesome.min.css" rel="stylesheet" />
    <!-- NProgress -->
    <link href="../../../Assets/vendor/nprogress/nprogress.css" rel="stylesheet" />
    <!-- Select2 -->
    <link href="../../../Assets/vendor/select2/dist/css/select2.min.css" rel="stylesheet" />
    <!-- Custom styling plus plugins -->
    <link href="../../../Assets/build/css/custom.min.css" rel="stylesheet" />
    <!--master-->
    <!--default-->
    <link href="../../../Assets/notify-master/css/notify.css" rel="stylesheet" />
    <!--default-->
    <%--<script src="jquery/dist/jquery.min.js"></script>--%>
    <meta charset="utf-8" />
    <%-- <link href="notify-master/css/notify.css" rel="stylesheet" />--%>
    <!--Bootstrap5 cdn link-->
    <!--Bootstrap5 css-->
    <%--<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous" />--%>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" />
    <%--<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />--%>
    <!--Bootstrap5 js-->
    <%--<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>--%>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js"></script>
    <%--<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>--%>
    <!---------------->

    <style>
        .modal-backdrop.in {
            opacity: 0;
        }

        .loader {
            visibility: hidden;
            border: 16px solid #f3f3f3;
            border-radius: 50%;
            border-top: 16px solid #172D44;
            width: 120px;
            height: 120px;
            -webkit-animation: spin 2s linear infinite;
            animation: spin 2s linear infinite;
        }

        @-webkit-keyframes spin {
            0% {
                -webkit-transform: rotate(0deg);
            }

            100% {
                -webkit-transform: rotate(360deg);
            }
        }

        @keyframes spin {
            0% {
                transform: rotate(0deg);
            }

            100% {
                transform: rotate(360deg);
            }
        }

        element.style {
        }

        .box.box-primary {
            border-top-color: #3c8dbc;
        }

        .box {
            position: relative;
            border-radius: 3px;
            background: #ffffff;
            border-top: 3px solid #d2d6de;
            margin-bottom: 20px;
            width: 100%;
            box-shadow: 0 1px 1px rgba(0,0,0,0.1);
        }


        .profile-user-img {
            margin: 0 auto;
            width: 100px;
            padding: 3px;
            border: 3px solid #d2d6de;
        }


        .img-circle {
            border-radius: 50%;
        }

        element.style {
        }

        .box-body {
            border-top-left-radius: 0;
            border-top-right-radius: 0;
            border-bottom-right-radius: 3px;
            border-bottom-left-radius: 3px;
            padding: 10px;
        }





        @media screen and (max-width: 768px) {

            *[class*='modal-width-media'] {
                width: auto;
            }
        }

        @media screen and (max-width: 992px) {

            *[class*='modal-width-media'] {
                width: auto;
            }
        }

        @media screen and (max-width: 1200px) {

            *[class*='modal-width-media'] {
                width: 800px;
            }
        }

        @media screen and (max-width: 1920px) {

            *[class*='modal-width-media'] {
                width: 800px;
            }
        }
    </style>
    <style>
        .card-header {
            background-color: #e6f9ff;
            color: #444;
            cursor: pointer;
            padding: 18px;
            width: 100%;
            border: none;
            border-radius: 15px 50px 30px;
            text-align: left;
            outline: none;
            font-size: 25px;
            transition: 0.4s;
            padding-bottom: 4px;
            padding-top: 3px;
        }
        /*.card-header {
            background-color: #eee;
            color: #444;
            cursor: pointer;
            padding: 18px;
            width: 100%;
            border: none;
            text-align: left;
            outline: none;
            font-size: 15px;
            transition: 0.4s;
        }*/

        /*.active, .card-header:hover {
                background-color: #ccc;
            }*/

        .collapse {
            padding: 0 18px;
            display: none;
            background-color: white;
            overflow: hidden;
        }
    </style>
    <style>
        .modal-backdrop.in {
            opacity: 0;
        }



        .loader {
            border: 16px solid #f3f3f3;
            border-radius: 50%;
            border-top: 16px solid #172D44;
            width: 120px;
            height: 120px;
            -webkit-animation: spin 2s linear infinite;
            animation: spin 2s linear infinite;
        }

        @-webkit-keyframes spin {
            0% {
                -webkit-transform: rotate(0deg);
            }

            100% {
                -webkit-transform: rotate(360deg);
            }
        }

        @keyframes spin {
            0% {
                transform: rotate(0deg);
            }

            100% {
                transform: rotate(360deg);
            }
        }


        element.style {
        }

        .box.box-primary {
            border-top-color: #3c8dbc;
        }

        .box {
            position: relative;
            border-radius: 3px;
            background: #ffffff;
            border-top: 3px solid #d2d6de;
            margin-bottom: 20px;
            width: 100%;
            box-shadow: 0 1px 1px rgba(0,0,0,0.1);
        }

        .profile-user-img {
            margin: 0 auto;
            width: 100px;
            padding: 3px;
            border: 3px solid #d2d6de;
        }

        .img-circle {
            border-radius: 50%;
        }

        element.style {
        }

        .box-body {
            border-top-left-radius: 0;
            border-top-right-radius: 0;
            border-bottom-right-radius: 3px;
            border-bottom-left-radius: 3px;
            padding: 10px;
        }

        table#t01 {
            width: 100%;
            background-color: #f1f1c1;
        }


        @media screen and (max-width: 768px) {

            *[class*='modal-width-media'] {
                width: auto;
            }
        }

        @media screen and (max-width: 992px) {

            *[class*='modal-width-media'] {
                width: auto;
            }
        }

        @media screen and (max-width: 1200px) {

            *[class*='modal-width-media'] {
                width: 800px;
            }
        }

        @media screen and (max-width: 1920px) {

            *[class*='modal-width-media'] {
                width: 800px;
            }
        }
    </style>

    <script>
        //$(document).ready(function () {
        //    $("#myBtn").click(function () {
        //        $("#collapseOne").collapse("toggle");
        //    });
        //});
    </script>

</head>
<body>
    <form runat="server">
        <asp:ScriptManager ID="scrip" runat="server">
        </asp:ScriptManager>

        <div id="main" class="main">
           <%-- <div class="pagetitle " style="font-size: 32px; margin-left: 34px; font-weight: 300; color: #012970;">
                SEARCH BOOK 
            </div>--%>

            <div class="container-fluid ">
                <div class="row">
                    <div class="col-lg-12 ">
                        <div class="card" style="margin: 20px;">
                            <div class="card-header" style="font-size: 32px;  font-weight: 600; color: #012970;"> SEARCH BOOK</div>
                            <div class="card-body" >
                                <div class="row">
                                    <div class="col-lg-6">
                                        <ul class="nav nav-tabs" id="myTab" role="tablist">
                                            <li class="nav-item" role="presentation" style="font-weight: bold;">
                                                <%--<a class="nav-link active" href="#BASIC">BASIC</a>--%>
                                                <button class="nav-link active" id="basic-tab" data-bs-toggle="tab" type="button" data-bs-target="#BASIC" role="tab" aria-controls="basic" aria-selected="true">BASIC</button>
                                            </li>
                                            <li class="nav-item" role="presentation" style="font-weight: bold;">
                                                <%--<a class="nav-link" href="#ADVANCED">ADVANCED</a>--%>
                                                <button class="nav-link" id="advanced-tab" data-bs-toggle="tab" type="button" data-bs-target="#ADVANCED" role="tab" aria-controls="ADVANCED" aria-selected="false">ADVANCED</button>
                                            </li>
                                        </ul>
                                    </div>
                                    <div class="col-lg-6">
                                        <div class="row">
                                              <div class="col-lg-7"></div>
                                            <div class="col-lg-2" style=" margin-top: 8px">Connect To:</div>
                                            <div class="col-lg-3" style=" margin-top: 3px">
                                                <select class="form-control form-select" id="ddlselect">
                                                    <option>--Select--</option>
                                                    <option>Viva Engg</option>
                                                    <option>MCA</option>
                                                    <option>pharmacy</option>
                                                    <option>Viva IMR</option>
                                                    <%--<option>Viva IMS</option>--%>
                                                </select>
                                            </div>
                                             <div class="col-lg-1"></div>                           
                                        </div>
                                    </div>
                                </div>
                                <div class="tab-content" id="myTabContent">
                                    <div class="tab-pane fade show active" id="basic" role="tabpanel" aria-labelledby="basic-tab"></div>
                                    <div class="tab-pane fade" id="advanced" role="tabpanel" aria-labelledby="advanced-tab"></div>
                                </div>
                                <div class="tab-content">
                                    <div id="BASIC" class="tab-pane active">
                                        <div class="row" style=" margin: 10px">
                                            <div class="col-lg-2">
                                                Select Category:
                <asp:DropDownList ID="ddl_selectcat" CssClass="form-control form-select" runat="server">
                    <asp:ListItem>--Select--</asp:ListItem>
                    <asp:ListItem>Book</asp:ListItem>
                    <asp:ListItem>CD</asp:ListItem>
                    <asp:ListItem>Map</asp:ListItem>
                    <asp:ListItem>Periodical</asp:ListItem>
                </asp:DropDownList>
                                            </div>
                                            <div class="col-lg-2">
                                                Search By:
                <asp:DropDownList ID="ddl_search" CssClass="form-control form-select" runat="server">
                    <asp:ListItem>--Select--</asp:ListItem>
                    <asp:ListItem>Title</asp:ListItem>
                    <asp:ListItem>Author</asp:ListItem>
                    <asp:ListItem>Publisher</asp:ListItem>
                    <asp:ListItem>Keywords</asp:ListItem>
                    <asp:ListItem>ISBN No</asp:ListItem>
                </asp:DropDownList>
                                            </div>
                                            <div class="col-lg-4" style="margin-top: 22px">

                                                <input type="text" id="Text1" class="form-control " />
                                            </div>
                                            <div class="col-lg-2 ">
                                                <br />
                                                <a id="btnSave" style="width: 100%" class="btn btn-primary">Search</a>
                                            </div>
                                            <div class="col-lg-2 ">
                                                <br />
                                                <a id="brn_refresh" class="btn  btn-primary" style="width: 100%">Refresh</a>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-12">
                                                <div id="accordion">
                                                    <div class="card" id="divhideshow" style="display: none">
                                                    </div>
                                                    <br />
                                                    <!--For CD-->
                                                    <div class="card" id="div2" style="display: none">
                                                        <div class="card-header" style="border-radius: 15px;">
                                                            <a class="collapsed card-link" data-toggle="collapse" href="#collapseTwo">CD
                                           <label id="Label1"></label>
                                                            </a>
                                                        </div>
                                                        <div id="Div1" class="collapse" data-bs-parent="#accordion">
                                                            <div class="card-body">
                                                                <div class="row" style="padding-top: 10px">
                                                                    <div class="col-lg-12 col-md-12 col-sm-12">
                                                                        <%--<div class="panel-default" style="border: 1px solid #375C8F;">
                                                                        <div class="panel-body">--%>
                                                                        <div class="row">
                                                                            <table id="Table1" class="table table-condensed table-responsive table-bordered table-striped">
                                                                            </table>
                                                                        </div>
                                                                        <%--</div>
                                                                    </div>--%>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <br />
                                                    <!--For MAP-->
                                                    <div class="card" id="div4" style="display: none">
                                                        <div class="card-header" style="border-radius: 15px;">
                                                            <a class="collapsed card-link" data-toggle="collapse" href="#collapseThree">Map
                                           <label id="Label2">count</label>
                                                            </a>
                                                        </div>
                                                        <div id="Div3" class="collapse" data-bs-parent="#accordion">
                                                            <div class="card-body">
                                                                <div class="row" style="padding-top: 10px">
                                                                    <div class="col-lg-12 col-md-12 col-sm-12">
                                                                        <%--<div class="panel-default" style="border: 1px solid #375C8F;">
                                                                        <div class="panel-body">--%>
                                                                        <div class="row">
                                                                            <table id="Table2" class="table table-condensed table-responsive table-bordered table-striped">
                                                                            </table>
                                                                        </div>
                                                                        <%--   </div>
                                                                    </div>--%>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <br />
                                                <center>
                                                    <div class="loader"></div>
                                                </center>
                                            </div>
                                        </div>
                                        <%--Table for BOOK--%>
                                        <div class="row" id="tbl_row"  style="width: 100%;height:400px; overflow-x: scroll; overflow-y: scroll; margin-left: 0px">
                                            <div class="card-body">
                                                <div class="row">
                                                    <table id="TBL_BK_SR"  class="table table-condensed table-responsive table-bordered table-striped" >
                                                    </table>
                                                </div>
                                            </div>
                                        </div>
                                        <%--=========--%>
                                      
                                    </div>

                                    <div id="ADVANCED" class="tab-pane">
                                        <div class="row" style="padding-top: 10px">
                                            <div class="col-sm-12 col-lg-4">
                                                Select Category:
                                <select id="DDL_CAT" class="form-control form-select">
                                    <option value="">--Select--</option>
                                    <option value="Book">Book</option>
                                    <option value="CD">CD</option>
                                    <option value="Map">Map</option>
                                    <option value="Periodical">Periodical</option>
                                </select>
                                            </div>
                                        </div>

                                        <div class="row" style="padding-top: 30px">
                                            <%--<div class="col-sm-12 col-lg-12">--%>
                                            <div class="col-sm-3 col-lg-4">
                                                <%--<input id="txtTitle" class="form-control" type="text"  />--%>
                                                <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-3 col-lg-4">
                                                <select id="keyword1" class="form-control form-select">
                                                    <option value="">--Keyword--</option>
                                                    <option value="Title">Title</option>
                                                    <option value="Author">Author</option>
                                                    <option value="Publisher">Publisher</option>
                                                </select>
                                            </div>
                                            <%--</div>--%>
                                        </div>

                                        <div class="row">
                                            <div class="col-sm-12 col-lg-12">
                                                &nbsp;&nbsp;
     <asp:RadioButton ID="rdbAND" runat="server" Text="AND" GroupName="Logic1" />&nbsp;&nbsp;
     <asp:RadioButton ID="rdbOR" runat="server" Text="OR" GroupName="Logic1" />&nbsp;&nbsp;
     <asp:RadioButton ID="rdbNOT" runat="server" Text="NOT" GroupName="Logic1" />&nbsp;&nbsp;
                                            </div>
                                        </div>
                                        <div class="row" style="margin-top: 10px;">
                                            <%-- <div class="col-sm-12 col-lg-12">--%>
                                            <div class="col-sm-3 col-lg-4">
                                                <%--<input id="txtAuthor" class="form-control"  />--%>
                                                <asp:TextBox ID="txtAuthor" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-3 col-lg-4">
                                                <select id="keyword2" class="form-control form-select">
                                                    <option value="">--Keyword--</option>
                                                    <option value="Title">Title</option>
                                                    <option value="Author">Author</option>
                                                    <option value="Publisher">Publisher</option>
                                                    <option value="Edition">Edition</option>
                                                    <option value="Standard No">ISBN</option>
                                                </select>
                                            </div>
                                            <%--</div>--%>
                                        </div>

                                        <div class="row">
                                            <div class="col-sm-12 col-lg-12">
                                                &nbsp;&nbsp;
     <asp:RadioButton ID="rdbAND1" runat="server" Text="AND" GroupName="Logic" />&nbsp;&nbsp;
     <asp:RadioButton ID="rdbOR1" runat="server" Text="OR" GroupName="Logic" />&nbsp;&nbsp;
     <asp:RadioButton ID="rdbNOT1" runat="server" Text="NOT" GroupName="Logic" />&nbsp;&nbsp;
                                            </div>
                                        </div>

                                        <div class="row" style="margin-top: 10px;">
                                            <%--<div class="col-sm-12 col-lg-12">--%>
                                            <div class="col-sm-3 col-lg-4">
                                                <asp:TextBox ID="txtPublisher" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-3 col-lg-4">
                                                <select id="keyword3" runat="server" class="form-control form-select">
                                                    <option value="">--Keyword--</option>
                                                    <option value="Title">Title</option>
                                                    <option value="Author">Author</option>
                                                    <option value="Publisher">Publisher</option>
                                                    <option value="Edition">Edition</option>
                                                    <option value="Standard No">ISBN</option>
                                                </select>
                                            </div>
                                            <%--</div>--%>
                                        </div>

                                        <div class="row">
                                            <div class="col-sm-3 col-lg-4">
                                                &nbsp;&nbsp;<a id="Search" class="btn btn-block btn-primary" style="width: 100%">SEARCH</a>
                                            </div>
                                            <div class="col-sm-3 col-lg-4">
                                                &nbsp;&nbsp;<a id="reset" class="btn btn-block btn-primary" style="width: 100%">REFRESH</a>
                                            </div>
                                        </div>
                                        <br />

                                        <div class="row">
                                            <div class="col-lg-12">
                                                <div class="row" style="width: 100%; height: 275px; overflow-x: scroll; overflow-y: scroll; margin-left: 0px; margin-top: 10px">
                                                    <div class="card-body">
                                                        <div class="row">
                                                            <table id="ADV_BOOK_T" class="table table-condensed table-responsive table-bordered table-striped">
                                                            </table>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div id="accordion23">
                                                    <div class="card" id="divhideshow_ADV" style="display: none">
                                                        <div class="card-header" style="border-radius: 15px;">
                                                            <a class="card-link" data-toggle="collapse" href="#collapseOne_ADV">Book
                               <label id="lbA">count</label>
                                                            </a>
                                                        </div>
                                                        <div id="collapseOne_ADV" class="collapse" data-parent="#accordion23">
                                                            <div class="card-body">
                                                                <div class="row" style="padding-top: 10px">
                                                                    <div class="col-lg-12 col-md-12 col-sm-12">
                                                                        <div class="row">
                                                                            <%-- <table id="ADV_BOOK_T" class="table table-condensed table-responsive table-bordered table-striped">
                                                                        </table>--%>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <br />








                                                    <!--For CD-->
                                                    <div class="card" id="div2_HH" style="display: none">
                                                        <div class="card-header" style="border-radius: 15px;">
                                                            <a class="collapsed card-link" data-toggle="collapse" href="#collapseTwo">CD
                                           <label id="Label1_ADV"></label>
                                                            </a>
                                                        </div>
                                                        <div id="Div1_FF" class="collapse" data-parent="#accordion">
                                                            <div class="card-body">
                                                                <div class="row" style="padding-top: 10px">
                                                                    <div class="col-lg-12 col-md-12 col-sm-12">
                                                                        <%--<div class="panel-default" style="border: 1px solid #375C8F;">
                                                                        <div class="panel-body">--%>
                                                                        <div class="row">
                                                                            <table id="Table1_ADV" class="table table-condensed table-responsive table-bordered table-striped">
                                                                            </table>
                                                                        </div>
                                                                        <%--</div>
                                                                    </div>--%>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                        </div>
                                                    </div>
                                                    <br />
                                                    <!--For Map-->
                                                    <div class="card" id="div4_Adv" style="display: none">
                                                        <div class="card-header" style="border-radius: 15px;">
                                                            <a class="collapsed card-link" data-toggle="collapse" href="#collapseThree">Map
                                           <label id="Label2_ADV">count</label>
                                                            </a>
                                                        </div>
                                                        <div id="Div3_ADV" class="collapse" data-parent="#accordion">
                                                            <div class="card-body">
                                                                <div class="row" style="padding-top: 10px">
                                                                    <div class="col-lg-12 col-md-12 col-sm-12">
                                                                        <%-- <div class="panel-default" style="border: 1px solid #375C8F;">
                                                                        <div class="panel-body">--%>
                                                                        <div class="row">
                                                                            <table id="Table2SD" class="table table-condensed table-responsive table-bordered table-striped">
                                                                            </table>
                                                                        </div>
                                                                        <%-- </div>
                                                                    </div>--%>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <br />
                                                <center>
                                                    <div class="loader" id="loadss"></div>
                                                </center>

                                                <!--Table for book-->
                                                <%--  <div class="row">
                                                <table id="ADV_BOOK_T" class="table table-condensed table-responsive table-bordered table-striped">
                                                </table>
                                            </div>--%>
                                            </div>

                                            

                                            <div class="row">
                                                <div class="col-sm-12 col-lg-12">
                                                    <div class="col-sm-3 col-lg-3">
                                                        &nbsp;&nbsp;<asp:Label ID="lblerr" Text="error" runat="server" ForeColor="Red" Visible="false" />
                                                    </div>
                                                </div>
                                            </div>

                                        </div>
                                    </div>
                                </div>
                                <div class="loader"></div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>

       <%-- ******************************************************** Modal for basic Search ******************************************************************--%>

          <div class="modal fade" id="searchModal" role="dialog" data-bs-backdrop="static" aria-labelledby="myModalLabel">
                                            
               <div class="modal-dialog modal-lg">
                                                    <div class="modal-content">
                                                        <div class="modal-header" style="background-color: #0d6efd; color: white">
                                                            <h5 class="modal-title" id="myModalLabel">Book Details</h5>
                                                            <button type="button" class="btn-close" data-bs-dismiss="modal" id="btnclose" style="background-color: white; font-size: 10px;"></button>
                                                        </div>
                                                        <div class="modal-body">
                                                            <div class="row">
                                                                <div class="col-lg-4">
                                                                    <center>
                                                                        <img id="img1" src="" class="profile-user-img img-responsive img-rounded" alt="" style="height: 100px; width: 100px;" />
                                                                    </center>
                                                                </div>
                                                                <div class="col-lg-8">
                                                                    <div class="row" style="border-top: 1px solid lightgray; border-bottom: 1px solid lightgray; padding: 2px">
                                                                        <div class="col-lg-3 col-xs-3">
                                                                            <span style="font-weight: bold; color: black; font-size: 14px; text-align: left;">Title:</span>
                                                                        </div>
                                                                        <div class="col-lg-9 col-xs-9">
                                                                            <label style="text-align: left; margin-bottom: 0px" id="txtbooktitle"></label>
                                                                        </div>
                                                                    </div>
                                                                    <div class="row" style="border-top: 1px solid lightgray; border-bottom: 1px solid lightgray; padding: 2px">
                                                                        <div class="col-lg-3 col-xs-3">
                                                                            <span style="font-weight: bold; color: black; font-size: 12px; text-align: left;">Author:</span>
                                                                        </div>
                                                                        <div class="col-lg-9 col-xs-9">
                                                                            <label style="text-align: left; margin-bottom: 0px" id="txtauthor"></label>
                                                                        </div>
                                                                    </div>
                                                                    <div class="row" style="border-top: 1px solid lightgray; border-bottom: 1px solid lightgray; padding: 2px">
                                                                        <div class="col-lg-3 col-xs-3">
                                                                            <span style="font-weight: bold; color: black; font-size: 12px; text-align: left;">Key Words:</span>
                                                                        </div>
                                                                        <div class="col-lg-9 col-xs-9">
                                                                            <label style="text-align: left; margin-bottom: 0px" id="txtkeywords"></label>
                                                                        </div>
                                                                    </div>
                                                                    <div class="row" style="border-top: 1px solid lightgray; border-bottom: 1px solid lightgray; padding: 2px">
                                                                        <div class="col-lg-3 col-xs-3">
                                                                            <span style="font-weight: bold; color: black; font-size: 12px; text-align: left;">Count:</span>
                                                                        </div>
                                                                        <div class="col-lg-9 col-xs-9">
                                                                            <label style="text-align: left; margin-bottom: 0px" id="txtcount"></label>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-lg-12">
                                                                    <div class="row" style="border-top: 1px solid lightgray; border-bottom: 1px solid lightgray; padding: 2px">
                                                                        <div class="col-lg-3 col-xs-3">
                                                                            <span style="font-weight: bold; color: black; font-size: 12px; text-align: left;">Publication:</span>
                                                                        </div>
                                                                        <div class="col-lg-9 col-xs-9">
                                                                            <label style="text-align: left; margin-bottom: 0px" id="txtpublication"></label>
                                                                        </div>
                                                                    </div>
                                                                    <div class="row" style="border-top: 1px solid lightgray; border-bottom: 1px solid lightgray; padding: 2px">
                                                                        <div class="col-lg-3 col-xs-3">
                                                                            <span style="font-weight: bold; color: black; font-size: 12px; text-align: left;">Accession No:</span>
                                                                        </div>
                                                                        <div class="col-lg-9 col-xs-9">
                                                                            <label style="text-align: left; margin-bottom: 0px" id="txtdescription"></label>
                                                                        </div>
                                                                    </div>
                                                                    <div class="row" style="border-top: 1px solid lightgray; border-bottom: 1px solid lightgray; padding: 2px">
                                                                        <div class="col-lg-3 col-xs-3">
                                                                            <span style="font-weight: bold; color: black; font-size: 12px; text-align: left;">Issued Books:</span>
                                                                        </div>
                                                                        <div class="col-lg-9 col-xs-9">
                                                                            <label style="text-align: left; margin-bottom: 0px; color: red" id="txtissuedbook"></label>
                                                                        </div>
                                                                    </div>
                                                                    <div class="row" style="border-top: 1px solid lightgray; border-bottom: 1px solid lightgray; padding: 2px">
                                                                        <div class="col-lg-3 col-xs-3">
                                                                            <span style="font-weight: bold; color: black; font-size: 12px; text-align: left;">Available Books:</span>
                                                                        </div>
                                                                        <div class="col-lg-9 col-xs-9">
                                                                            <label style="text-align: left; margin-bottom: 0px; color: green" id="txtavailablebook"></label>
                                                                        </div>
                                                                    </div>
                                                                    <div class="row" style="border-top: 1px solid lightgray; border-bottom: 1px solid lightgray; display:none; padding: 2px">
                                                                        <div class="col-lg-3 col-xs-3">
                                                                            <span style="font-weight: bold; color: black; font-size: 12px; text-align: left;">Withdraw Books:</span>
                                                                        </div>
                                                                        <div class="col-lg-9 col-xs-9">
                                                                            <div class="col-lg-1 col-xs-3">
                                                                                <label style="text-align: left; margin-bottom: 0px; color: red" id="txtwithdraw"></label>
                                                                            </div>
                                                                            <div class="col-lg-3 col-xs-3">
                                                                                <span style="font-weight: bold; color: black; font-size: 12px; text-align: left;">Accession No:</span>

                                                                            </div>
                                                                            <div class="col-lg-5 col-xs-3">
                                                                                <label style="text-align: left; margin-bottom: 0px; color: red" id="txtWid"></label>

                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div class="row" style="border-top: 1px solid lightgray; border-bottom: 1px solid lightgray; display:none; padding: 2px">
                                                                        <div class="col-lg-3 col-xs-3">
                                                                            <span style="font-weight: bold; color: black; font-size: 12px; text-align: left;">Missing  Books:</span>

                                                                        </div>
                                                                        <div class="col-lg-9 col-xs-9">
                                                                            <div class="col-lg-1 col-xs-3">
                                                                                <label style="text-align: left; margin-bottom: 0px; color: red" id="txtmissing"></label>
                                                                            </div>
                                                                            <div class="col-lg-3 col-xs-3">
                                                                                <span style="font-weight: bold; color: black; font-size: 12px; text-align: left;">Accession No:</span>

                                                                            </div>
                                                                            <div class="col-lg-5 col-xs-3">
                                                                                <label style="text-align: left; margin-bottom: 0px; color: red" id="txtMisAcc"></label>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <%--<div class="row">
                                                                    <span>
                                                                        <button type="button" style="width: 70px; float: right; height: 35px; margin-top: 5px;"
                                                                            id="btn_cancel" class="btn btn-warning btn-sm form-control" data-dismiss="modal">
                                                                            Close</button>
                                                                    </span>
                                                                </div>--%>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
               </div>
                                              
                                        </div>


          <%-- ******************************************************** Modal for Advanced Search ******************************************************************--%>

        <div class="modal" id="Advance_searchModal_1" role="dialog">
                                                <div class="vertical-alignment-helper">
                                                    <div class="modal-dialog vertical-align-center">
                                                        <div class="modal-content" style="height: 440px; width: 600px">
                                                            <div class="modal-header" style="background-color: #5BC0DE; color: white">

                                                                <h4 class="modal-title" id="H6_ADV">Book Details</h4>
                                                                <button type="button" class="btn-close" data-dismiss="modal" id="btnclose1" style="background-color: white; font-size: 10px;"></button>
                                                            </div>
                                                            <div class="modal-body">
                                                                <div class="row">
                                                                    <div class="col-lg-4">
                                                                        <center>
                                                                            <img id="12img" class="profile-user-img img-responsive img-rounded" alt="" style="height: 100px; width: 100px;" />
                                                                        </center>
                                                                    </div>
                                                                    <div class="col-lg-8">
                                                                        <div class="row" style="border-top: 1px solid lightgray; border-bottom: 1px solid lightgray; padding: 2px">
                                                                            <div class="col-lg-3 col-xs-3">
                                                                                <span style="font-weight: bold; color: black; font-size: 14px; text-align: left;">Title:</span>

                                                                            </div>
                                                                            <div class="col-lg-9 col-xs-9">
                                                                                <label style="text-align: left; margin-bottom: 0px" id="txtbooktitle_ADV"></label>
                                                                            </div>
                                                                        </div>

                                                                        <div class="row" style="border-top: 1px solid lightgray; border-bottom: 1px solid lightgray; padding: 2px">
                                                                            <div class="col-lg-3 col-xs-3">
                                                                                <span style="font-weight: bold; color: black; font-size: 12px; text-align: left;">Author:</span>

                                                                            </div>
                                                                            <div class="col-lg-9 col-xs-9">
                                                                                <label style="text-align: left; margin-bottom: 0px" id="txtauthor_ADV"></label>
                                                                            </div>
                                                                        </div>
                                                                        <div class="row" style="border-top: 1px solid lightgray; border-bottom: 1px solid lightgray; padding: 2px">
                                                                            <div class="col-lg-3 col-xs-3">
                                                                                <span style="font-weight: bold; color: black; font-size: 12px; text-align: left;">Key Words:</span>

                                                                            </div>
                                                                            <div class="col-lg-9 col-xs-9">
                                                                                <label style="text-align: left; margin-bottom: 0px" id="txtkeywords_ADV"></label>
                                                                            </div>
                                                                        </div>
                                                                        <div class="row" style="border-top: 1px solid lightgray; border-bottom: 1px solid lightgray; padding: 2px">
                                                                            <div class="col-lg-3 col-xs-3">
                                                                                <span style="font-weight: bold; color: black; font-size: 12px; text-align: left;">Count:</span>

                                                                            </div>
                                                                            <div class="col-lg-9 col-xs-9">
                                                                                <label style="text-align: left; margin-bottom: 0px" id="txtcount_ADV"></label>
                                                                            </div>
                                                                        </div>


                                                                    </div>
                                                                </div>
                                                                <div class="row">
                                                                    <div class="col-lg-12">
                                                                        <div class="row" style="border-top: 1px solid lightgray; border-bottom: 1px solid lightgray; padding: 2px">
                                                                            <div class="col-lg-3 col-xs-3">
                                                                                <span style="font-weight: bold; color: black; font-size: 12px; text-align: left;">Publication:</span>

                                                                            </div>
                                                                            <div class="col-lg-9 col-xs-9">
                                                                                <label style="text-align: left; margin-bottom: 0px" id="txtpublication_ADV"></label>
                                                                            </div>
                                                                        </div>
                                                                        <div class="row" style="border-top: 1px solid lightgray; border-bottom: 1px solid lightgray; padding: 2px">
                                                                            <div class="col-lg-3 col-xs-3">
                                                                                <span style="font-weight: bold; color: black; font-size: 12px; text-align: left;">Accession No:</span>

                                                                            </div>
                                                                            <div class="col-lg-9 col-xs-9">
                                                                                <label style="text-align: left; margin-bottom: 0px" id="txtdescription_ADV"></label>
                                                                            </div>
                                                                        </div>
                                                                        <div class="row" style="border-top: 1px solid lightgray; border-bottom: 1px solid lightgray; padding: 2px">
                                                                            <div class="col-lg-3 col-xs-3">
                                                                                <span style="font-weight: bold; color: black; font-size: 12px; text-align: left;">Issued Books:</span>

                                                                            </div>
                                                                            <div class="col-lg-9 col-xs-9">
                                                                                <label style="text-align: left; margin-bottom: 0px; color: red" id="txtissuedbook_ADV"></label>
                                                                            </div>
                                                                        </div>
                                                                        <div class="row" style="border-top: 1px solid lightgray; border-bottom: 1px solid lightgray; padding: 2px">
                                                                            <div class="col-lg-3 col-xs-3">
                                                                                <span style="font-weight: bold; color: black; font-size: 12px; text-align: left;">Available Books:</span>

                                                                            </div>
                                                                            <div class="col-lg-9 col-xs-9">
                                                                                <label style="text-align: left; margin-bottom: 0px; color: green" id="txtavailablebook_ADV"></label>
                                                                            </div>
                                                                        </div>
                                                                        <div class="row" style="border-top: 1px solid lightgray; border-bottom: 1px solid lightgray; padding: 2px">
                                                                            <div class="col-lg-3 col-xs-3">
                                                                                <span style="font-weight: bold; color: black; font-size: 12px; text-align: left;">Withdraw Books:</span>

                                                                            </div>
                                                                            <div class="col-lg-9 col-xs-9">
                                                                                <div class="col-lg-1 col-xs-3">
                                                                                    <label style="text-align: left; margin-bottom: 0px; color: red" id="txtwithdraw_ADV"></label>
                                                                                </div>
                                                                                <div class="col-lg-3 col-xs-3">
                                                                                    <span style="font-weight: bold; color: black; font-size: 12px; text-align: left;">Accession No:</span>

                                                                                </div>
                                                                                <div class="col-lg-5 col-xs-3">
                                                                                    <label style="text-align: left; margin-bottom: 0px; color: red" id="txtWid_ADV"></label>

                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                        <div class="row" style="border-top: 1px solid lightgray; border-bottom: 1px solid lightgray; padding: 2px">
                                                                            <div class="col-lg-3 col-xs-3">
                                                                                <span style="font-weight: bold; color: black; font-size: 12px; text-align: left;">Missing  Books:</span>

                                                                            </div>
                                                                            <div class="col-lg-9 col-xs-9">
                                                                                <div class="col-lg-1 col-xs-3">
                                                                                    <label style="text-align: left; margin-bottom: 0px; color: red" id="txtmissing_ADV"></label>
                                                                                </div>
                                                                                <div class="col-lg-3 col-xs-3">
                                                                                    <span style="font-weight: bold; color: black; font-size: 12px; text-align: left;">Accession No:</span>

                                                                                </div>
                                                                                <div class="col-lg-5 col-xs-3">
                                                                                    <label style="text-align: left; margin-bottom: 0px; color: red" id="txtMisAcc_ADV"></label>

                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                        <%--<div class="row">
                                                                        <span>
                                                                            <button type="button" style="width: 70px; float: right; height: 35px; margin-top: 5px;"
                                                                                id="btn_cancel1" class="btn btn-warning btn-sm form-control" data-dismiss="modal">
                                                                                Close</button>
                                                                        </span>
                                                                    </div>--%>
                                                                    </div>

                                                                </div>



                                                            </div>
                                                            <%--<div class="modal-footer">
                                                        <button type="button" class="btn btn-warning" data-dismiss="modal">Close</button>
                                                    </div>--%>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>





        <script type="text/javascript">
            var acc = document.getElementsByClassName("accordion");
            var i;

            for (i = 0; i < acc.length; i++) {
                acc[i].addEventListener("click", function () {
                    this.classList.toggle("active");
                    var panel1 = this.nextElementSibling;
                    if (panel1.style.display === "block") {
                        panel1.style.display = "none";
                    } else {
                        panel1.style.display = "block";
                    }
                });
            }
        </script>
        <%--<script type="text/javascript">
            var acc = document.getElementsByClassName("accordion23");
            var i;

            for (i = 0; i < acc.length; i++) {
                acc[i].addEventListener("click", function () {
                    this.classList.toggle("active");
                    var panel2 = this.nextElementSibling;
                    if (panel2.style.display === "block") {
                        panel2.style.display = "none";
                    } else {
                        panel2.style.display = "block";
                    }
                });
            }
        </script>--%>
    </form>

    <!-- Bootstrap -->
    <script src="../../../Assets/vendor/bootstrap/js/bootstrap.min.js"></script>
    <%--<script src="vendors/bootstrap/dist/js/bootstrap.min.js"></script>--%>
    <!-- bootstrap-daterangepicker -->
    <script src="../../../Assets/js/moment/moment.min.js"></script>
    <script src="../../../Assets/JsForm/book_search.js"></script>

    <script src="../../../Assets/notify-master/js/jquery-1.11.0.js"></script>

    <script src="../../../Assets/notify-master/js/notify.js"></script>
    <script src="../../../Assets/notify-master/js/prettify.js"></script>

    <%--    <script src="jsForms/book_search.js"></script>--%>
    <%--<script src="notify-master/js/jquery-1.11.0.js"></script>--%>
    <script src="../../../Assets/js/jquery.datetimepicker.js"></script>

    <%--<script src="notify-master/js/notify.js"></script>
    <script src="notify-master/js/prettify.js"></script>--%>
</body>
<%--<script src="notify-master/js/notify.js"></script>--%>
</html>

