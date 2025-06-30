<%@ Page Title="" Language="C#" MasterPageFile="~/Portals/Staff/MasterPage.master" AutoEventWireup="true" CodeFile="IssueReturn.aspx.cs" Inherits="IssueReturn" EnableEventValidation="false"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <!---------------->
    <style>
        /*hr.style17 {
            border-top: 1px solid #8c8b8b;
            text-align: center;
        }

            hr.style17:after {
                /*content: '&';*/
        /*display: inline-grid;
                position: relative;
                top: -14px;
                padding: 0 10px;
                background: #f0f0f0;
                color: #8c8b8b;
                font-size: 18px;*/
        /*-webkit-transform: rotate(60deg);
	-moz-transform: rotate(60deg);
	transform: rotate(60deg);*/
        /*}*/
        /*
        .modal-backdrop.in {
            opacity: 0;
        }*/

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

        /*.list-group-item {
    position: relative;
    display: block;
    padding: 10px 15px;
    margin-bottom: -1px;
    background-color: #fff;
    border: 1px solid #ddd;
}
ul, menu, dir {
    display: block;
    list-style-type: disc;
    -webkit-margin-before: 1em;
    -webkit-margin-after: 1em;
    -webkit-margin-start: 0px;
    -webkit-margin-end: 0px;
    -webkit-padding-start: 40px;
}

        /*element.style {
}

.content {
    min-height: 250px;
    padding: 15px;
    margin-right: auto;
    margin-left: auto;
    padding-left: 15px;
    padding-right: 15px;
}

article, aside, details, figcaption, figure, footer, header, hgroup, main, menu, nav, section, summary {
    display: block;
}


.profile-username {
    font-size: 21px;
    margin-top: 5px;
}


.text-center {
    text-align: center;
}






.margin-r-5 {
    margin-right: 5px;
}


.fa {
    display: inline-block;
    font: normal normal normal 14px/1 FontAwesome;
    font-size: inherit;
    text-rendering: auto;
    -webkit-font-smoothing: antialiased;
    -moz-osx-font-smoothing: grayscale;
}*/ sss
        /*th, td {
    padding: 15px;
    text-align: left;
}*/
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



    <!-----------Materialize-------->
    <%--<link href="materialize/css/materialize.min.css" rel="stylesheet" />--%>
    <!------------------------------>
    <link href="../../../Assets/jsgrid-1.5.3/jsgrid.min.css" rel="stylesheet" />
    <link href="../../../Assets/jsgrid-1.5.3/jsgrid-theme.min.css" rel="stylesheet" />

    <link href="../../../Assets/css/jquery.datetimepicker.css" rel="stylesheet" />
    <link href="../../../Assets/notify-master/css/notify.css" rel="stylesheet" />
    <link href="../../../Assets/notify-master/css/prettify.css" rel="stylesheet" />
   <%-- <link href="../../../Assets/Fonts/css/font-awesome.css" rel="stylesheet" />
    <link href="../../../Assets/Fonts/css/font-awesome.min.css" rel="stylesheet" />--%>

    <!---------------->



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%-- <asp:ScriptManager ID="script" runat="server" EnablePageMethods="true"></asp:ScriptManager>--%>

   <div id="main" class="main">
        <div class="pagetitle " style="font-size: 32px; margin-left: 34px; font-weight: 300; color: #012970;">
            BOOK CIRCULATION 
        </div>
        <!------------------>
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-12">

                    <div class="card card-info" style="margin-top: 10px;">

                        <div class="card card-body" style="margin-top: 5px;">

                            <div class="row">

                                <div class="col-lg-3 col-md-4 col-xs-6" style="display: none;">
                                    <%-- Academic Year:--%>
                                    <asp:DropDownList ID="ddlyear" CssClass="form-control input-sm" runat="server" placeholder="Select Year">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-lg-3 col-md-4 col-xs-6" style="margin-left: 25px;">
                                    Enter ID:
                                <div class="form-group row">
                                    <div class="col-lg-9 col-sm-10 col-xs-9">
                                        <input name="Student ID" type="text" id="txtStudId" class="form-control input-sm" placeholder="Enter ID" />
                                    </div>
                                    <div class="col-lg-3 col-sm-2 col-xs-3">
                                        <%--<a id="btn_search" class="btn btn-success btn-sm" style="float: right; height: 30px; width: 30px"><span class="glyphicon glyphicon-search"></span></a>--%>
                                        <a id="btn_search" class="btn btn-success btn-sm" style="margin-left: 25px; margin-top: 4px; height: 36px; width: 40px"><span class="bi-search"></span></a>
                                    </div>

                                </div>
                                </div>

                                <%-- <div class="col-md-1">
                                <br />
                                <div class="form-group">
                                   
                                </div>
                            </div>--%>
                                <div class="col-lg-2 col-md-4">
                                    Connect To:
                                <select class="form-control" id="ddlselect">
                                    <option>Viva Engg</option>
                                    <option>MCA</option>
                                    <option>pharmacy</option>
                                    <option>Viva IMR</option>
                                    <%-- <option>Viva IMS</option>--%>
                                </select>
                                </div>

                                  <div class="col-lg-1 col-md-1">
                                     <a href="../Profile/ViewProfile.aspx" class="btn btn-primary btn-block btn-md" style="margin-top:29px;" >Go Back</a>
                                </div>

                                <div class="col-lg-2 col-md-4 col-xs-6" style="margin-left: 25px;">
                                    <div class="form-group">
                                        <br class="hidden-xs hidden-sm" />

                                        <a id="btn_forguest" class="btn btn-success btn-sm btn-block form-control">&nbsp;<span style="font-size: 15px; font-weight: bold">Other</span></a>
                                    </div>
                                </div>
                                <div class="col-lg-1 col-md-4" id="reset" style="display: none; margin-left: 25px;">
                                    <br class="hidden-xs hidden-sm" />
                                    <a id="btn_reset" runat="server" class="form-control btn btn-warning btn-md">Reset</a>
                                </div>

                            </div>

                            <section class="content">
                                <div class="row" id="paneldetailsall" style="display: none; padding-left: 20px; padding-right: 10px; margin-top: 30px">

                                    <br />
                                    <div class="col-lg-4 col-xs-12">
                                        <div class="card" id="paneldetails" style="display: none; height: 390px">

                                            <div class="card-header">
                                                <div class="row" style="margin-bottom: -15px;">
                                                    <span style="font-size: 15px; font-weight: bold; color: #012970">Profile</span>
                                                </div>
                                            </div>

                                            <div class="card-body">
                                                <div class="box-body box-profile" style="padding: 0px; margin-top: 20px">
                                                    <center>
                                                        <img id="imgstud" class="profile-user-img img-responsive img-circle" alt="User profile picture" style="height: 125px; width: 125px; margin-top: -19px; margin-bottom: 5px;" />
                                                    </center>
                                                    <h3 class="profile-username text-center" id="txtStudName" style="font-weight: bold; font-size: 10pt;"><i class="fa fa-user"></i></h3>
                                                    <p class="text-muted text-center" style="font-size: 15px; font-weight: bold; color: black; margin-top: -10px;">Roll No: <span id="txtRollNo"></span></p>
                                                    <span id="lblSubcourseId" style="display: none"></span>

                                                    <div class="row" style="margin-left: -14px; margin-top: -12px;">

                                                        <div class="row" style="border-top: 1px solid lightgray; border-bottom: 1px solid lightgray; padding: 2px">
                                                            <div class="col-lg-3 col-xs-3">
                                                                <span style="color: black; text-align: left; font-size: 12px; font-weight: bold;">CLASS </span>
                                                                <span style="float: right; color: black; margin-right: 1px">:</span>
                                                            </div>
                                                            <div class="col-lg-9 col-xs-9">
                                                                <p style="text-align: left; margin-bottom: 0px; margin-left: -8px" id="txtclass"></p>
                                                            </div>
                                                        </div>
                                                        <div class="row" style="border-bottom: 1px solid lightgray; padding: 2px">
                                                            <div class="col-lg-3 col-xs-3">
                                                                <span style="color: black; text-align: left; font-size: 12px; font-weight: bold">DIV </span>
                                                                <span style="float: right; color: black; margin-right: 1px">:</span>
                                                            </div>
                                                            <div class="col-lg-9 col-xs-9">
                                                                <p style="text-align: left; margin-bottom: 0px; margin-left: -25px" id="txtDiv"></p>
                                                            </div>
                                                        </div>
                                                        <div class="row" style="border-bottom: 1px solid lightgray; padding: 1px">
                                                            <div class="col-lg-3 col-xs-3">
                                                                <span style="color: black; text-align: left; font-size: 12px; font-weight: bold">MOBILE NO</span>
                                                                <span style="float: right; color: black; margin-right: 1px">:</span>
                                                            </div>
                                                            <div class="col-lg-9 col-xs-9">
                                                                <p style="text-align: left; margin-bottom: 0px; margin-left: -10px" id="txtmobno" onkeypress="return Number(event)" onchange="ValidateNo(this)"></p>
                                                            </div>
                                                        </div>
                                                        <div class="row" style="padding: 2px">
                                                            <div class="col-lg-3 col-xs-3">
                                                                <span style="color: black; text-align: left; font-size: 12px; font-weight: bold">ADDRESS</span>
                                                                <span style="float: right; color: black; margin-right: 13px">:</span>
                                                            </div>
                                                            <div class="col-lg-9 col-xs-9">
                                                                <p style="text-align: left; margin-bottom: 0px; margin-left: -20px; font-size: 14px" id="txtaddress"></p>
                                                            </div>
                                                        </div>
                                                    </div>


                                                </div>
                                            </div>
                                        </div>

                                        <div class="card" id="Employee" style="display: none; height: 390px">
                                            <div class="card-header">
                                                <div class="row" style="margin-bottom: -15px;">
                                                    <span style="font-size: 15px; font-weight: bold; color: #012970">Profile</span>
                                                </div>
                                            </div>

                                            <div class="card-body">
                                                <div class="box-body box-profile" style="padding: 0px; margin-top: 20px">
                                                    <center>
                                                        <img id="imgemployee" class="profile-user-img img-responsive img-circle" alt="User profile picture" style="height: 125px; width: 125px; margin-top: -19px; margin-bottom: 5px;">
                                                    </center>
                                                    <h3 class="profile-username text-center" id="txtempname" style="font-weight: bold; font-size: 10pt;"><i class="fa fa-user"></i></h3>

                                                    <div class="row" style="margin-left: -14px;">

                                                        <div class="row" style="border-top: 1px solid lightgray; border-bottom: 1px solid lightgray; padding: 2px">
                                                            <div class="col-lg-3 col-xs-3">
                                                                <span style="color: black; text-align: left; font-size: 12px; font-weight: bold;">MOBILE NO </span>
                                                                <span style="float: right; color: black; margin-right: 1px">:</span>
                                                            </div>
                                                            <div class="col-lg-9 col-xs-9">
                                                                <p style="text-align: left; margin-bottom: 0px;" id="txtempmobno"></p>
                                                            </div>
                                                        </div>
                                                        <div class="row" style="border-top: 1px solid lightgray; border-bottom: 1px solid lightgray; padding: 2px">
                                                            <div class="col-lg-3 col-xs-3">
                                                                <span style="color: black; text-align: left; font-size: 12px; font-weight: bold;">DEPARTMENT</span>
                                                                <span style="float: right; color: black;">:</span>
                                                            </div>
                                                            <div class="col-lg-9 col-xs-9">
                                                                <p style="text-align: left; margin-bottom: 0px;" id="txtempdepart"></p>
                                                            </div>
                                                        </div>
                                                        <div class="row" style="border-bottom: 1px solid lightgray; padding: 1px">
                                                            <div class="col-lg-3 col-xs-3">
                                                                <span style="color: black; text-align: left; font-size: 12px; font-weight: bold">DESIGNATION</span>
                                                                <span style="float: right; color: black; margin-right: 1px">:</span>
                                                            </div>
                                                            <div class="col-lg-9 col-xs-9">
                                                                <p style="text-align: left; margin-bottom: 0px; margin-left: -10px" id="txtempdesing"></p>
                                                            </div>
                                                        </div>
                                                        <div class="row" style="padding: 2px">
                                                            <div class="col-lg-3 col-xs-3">
                                                                <span style="color: black; text-align: left; font-size: 12px; font-weight: bold">ADDRESS </span>
                                                                <span style="float: right; color: black; margin-right: 13px">:</span>
                                                            </div>
                                                            <div class="col-lg-9 col-xs-9">
                                                                <p style="text-align: left; margin-bottom: 0px; margin-left: -20px; font-size: 14px" id="txtempaddress"></p>
                                                            </div>
                                                        </div>
                                                    </div>

                                                </div>
                                            </div>
                                        </div>

                                        <div class="row" id="Guestpanel" style="display: none;">
                                            <div class="col-lg-12 col-xs-12">
                                                <div class="row" style="padding-top: 10px">
                                                    <div class="col-lg-8 col-xs-10">
                                                        <asp:TextBox ID="txtGuestID" runat="server" CssClass="form-control" placeholder="Enter Name"></asp:TextBox>
                                                    </div>
                                                    <div class="col-md-2 col-xs-2">
                                                        <div class="form-group" style="float: right">
                                                            <a id="btn_guestsearch" class="btn btn-success btn-sm"><span class="bi-search"></span></a>
                                                        </div>
                                                    </div>

                                                </div>
                                                <div class="row" style="padding-top: 10px">
                                                    <div class="col-lg-10 col-xs-12">
                                                        <span style="font-weight: bold">Name:</span>
                                                        <asp:TextBox ID="txtguestnameee" runat="server" CssClass="form-control" placeholder="Enter Name"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="row" style="padding-top: 10px">
                                                    <div class="col-lg-4 col-xs-5">
                                                        <span style="font-weight: bold">Mobile No:</span>
                                                        <asp:TextBox ID="txtguestmobno" runat="server" CssClass="form-control" placeholder="Enter Mobile No" MaxLength="10" onkeypress="return Number(event)" onchange="ValidateNo(this)"></asp:TextBox>
                                                    </div>
                                                    <div class="col-lg-6 col-xs-7">
                                                        <span style="font-weight: bold">Remark:</span>
                                                        <asp:TextBox ID="txtGuestRemark" runat="server" CssClass="form-control" placeholder="Enter Remark"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="row" style="padding-top: 10px">
                                                    <div class="col-lg-10 col-xs-12">
                                                        <span style="font-weight: bold">Address:</span>
                                                        <asp:TextBox ID="txtguestAddress" runat="server" CssClass="form-control" TextMode="MultiLine" placeholder="Enter Address"></asp:TextBox>
                                                    </div>

                                                </div>
                                            </div>

                                        </div>
                                        <br />
                                    </div>

                                    <div class="col-lg-8 col-xs-12">

                                    <div class="row" id="assesion_panel_id" style="display: none">

                                        <div class="row" style="padding-right: 10px">
                                            <div class="col-lg-4 col-md-4" style="margin-left: 12px">
                                                Enter Accession No:

                                                        <span>
                                                            <%--<asp:TextBox ID="txtAccessionNo" runat="server" CssClass="form-control" placeholder="Enter Accession No."></asp:TextBox></span>--%>
                                                            <input name="txtAccessionNo" type="text" id="txtAccessionNo" class="form-control input-sm" placeholder="Enter Accession No." />
                                            </div>

                                            <div class="col-md-1">
                                                <br />
                                                <div class="form-group" style="height: 36px; width: 40px; margin-left: 15px;">
                                                    <a id="btn_accessionsearch" class="btn btn-success btn-sm"><span class="bi-search"></span></a>
                                                </div>
                                            </div>
                                            <br />
                                            <br />
                                            <div class="row">
                                                <div class="col-lg-12" style="margin-left: 12px">
                                                    <span style="font-size: 17px; font-weight: bold; display: none; margin-left: 10px; margin-left: 3px; margin-top: 10px" id="accessiontype"></span>

                                                </div>
                                            </div>

                                        </div>

                                        <div class="row" style="padding-left: 20px">
                                            <div class="col-lg-12">
                                                <span style="font-size: 17px; font-weight: bold; display: none; color: red" id="lblissuedbook"></span>
                                            </div>
                                        </div>
                                        <div class="row" style="padding-top: 15px; display: none; margin-left: 8px" id="bookaccession">


                                            <div class="box-body box-profile" style="margin-top: -15px;">


                                                <div class="row" style="margin-top: -10px">
                                                    <div class="col-lg-3 col-xs-3">
                                                        <span style="font-weight: bold; color: black; text-align: left">BOOK TITLE </span>
                                                        <span style="float: right; color: black">:</span>
                                                    </div>
                                                    <div class="col-lg-9 col-xs-9">
                                                        <p style="text-align: left;" id="txtbooktitle"></p>
                                                    </div>
                                                </div>
                                                <div class="row" style="margin-top: -10px">
                                                    <div class="col-lg-3 col-xs-3">
                                                        <span style="font-weight: bold; color: black; text-align: left">AUTHOR</span>
                                                        <span style="float: right; color: black">:</span>
                                                    </div>
                                                    <div class="col-lg-9 col-xs-9">
                                                        <p style="text-align: left;" id="txtauthor"></p>
                                                    </div>
                                                </div>
                                                <div class="row" style="margin-top: -10px">
                                                    <div class="col-lg-3 col-xs-3">
                                                        <span style="font-weight: bold; color: black; text-align: left">PUBLISHER</span>
                                                        <span style="float: right; color: black">:</span>
                                                    </div>
                                                    <div class="col-lg-9 col-xs-9">
                                                        <p style="text-align: left;" id="txtPublisher"></p>
                                                    </div>
                                                </div>


                                            </div>

                                        </div>

                                        <div class="row" style="padding-top: 15px; display: none" id="cdaccession">

                                            <div class="box-body box-profile">


                                                <div class="row">
                                                    <div class="col-lg-3 col-xs-3">
                                                        <span style="font-weight: bold; color: black; text-align: left;">CD TITLE </span>
                                                        <span style="float: right; color: black">:</span>
                                                    </div>
                                                    <div class="col-lg-9 col-xs-9">
                                                        <p style="text-align: left;" id="txtcdtitle"></p>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-lg-3 col-xs-3">
                                                        <span style="font-weight: bold; color: black; text-align: left;">CONTENT TYPE</span>
                                                        <span style="float: right; color: black">:</span>
                                                    </div>
                                                    <div class="col-lg-9 col-xs-9">
                                                        <p style="text-align: left;" id="txtcdauthor"></p>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-lg-3 col-xs-3">
                                                        <span style="font-weight: bold; color: black; text-align: left;">PUBLISHER</span>
                                                        <span style="float: right; color: black">:</span>
                                                    </div>
                                                    <div class="col-lg-9 col-xs-9">
                                                        <p style="text-align: left;" id="txcdtPublisher"></p>
                                                    </div>
                                                </div>


                                            </div>


                                        </div>


                                        <div class="row" style="padding-top: 15px; display: none" id="serialaccession">

                                            <div class="col-lg-3" style="font-size: 17px;">
                                                <span style="font-weight: bold;">SERIAL TITLE:</span>
                                                <span id="txtserialtitle"></span>
                                            </div>
                                            <div class="col-lg-3" style="font-size: 17px;">
                                                <span style="font-weight: bold;">TYPE:</span>
                                                <span id="txtserialtyp;e"></span>
                                            </div>
                                            <div class="col-lg-3" style="font-size: 17px;">
                                                <span style="font-weight: bold;">VOLUMN NO. :</span>
                                                <span id="txtvolume"></span>
                                            </div>
                                            <div class="col-lg-3" style="font-size: 17px;">
                                                <span style="font-weight: bold;">ISSUE NO. :</span>
                                                <span id="txtissueno"></span>
                                            </div>
                                        </div>




                                        <div class="row" style="padding-top: 0px; display: none; margin-left: 15px" id="makeissue">
                                            <div class="col-lg-12">
                                                <div class="row" style="margin-top: -15px;">
                                                    <div class="col-lg-6 col-xs-12">
                                                        <div class="hidden-md hidden-sm hidden-xs">Issue Date </div>
                                                        <%--<div class="hidden-lg">Issue Date </div>--%>

                                                        <div class="col-lg-12">
                                                            <input type="text" class="form-control has-feedback-left active" id="issuedate" placeholder="Date" aria-describedby="inputSuccess2Status" />
                                                           <%-- <span class="fa fa-calendar-o form-control-feedback left" aria-hidden="true"></span>--%>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-6 col-xs-12">
                                                        <div class="hidden-md hidden-sm hidden-xs">Return Date </div>
                                                        <%--<div class="hidden-lg">Return Date </div>--%>
                                                        <div class="col-lg-12">
                                                            <input type="text" class="form-control has-feedback-left active" id="return_date" placeholder="Date" aria-describedby="inputSuccess2Status" />
                                                           <%-- <span class="fa fa-calendar-o form-control-feedback left" aria-hidden="true"></span>--%>
                                                        </div>
                                                    </div>
                                                </div>


                                                <div class="row" style="margin-top: 15px">
                                                    <div class="col-lg-2 col-xs-12" style="padding-left: 2px; padding-right: 5px; margin-top: 5px">
                                                        Return After:
                                                            
                                                    </div>
                                                    <div class="col-6" style="margin-left: -20px;">
                                                        <div class="form-group row" style="margin-left: -20px;">
                                                            <div class="input-group mb-3">
                                                                <span class="input-group-text" style="margin-left: 21px">Day/Days</span>
                                                                <asp:TextBox ID="txtday" runat="server" type="number" value="0" class="form-control" placeholder="Day/Days" Style="margin-left: -5px;"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-6"></div>
                                                </div>

                                            </div>





                                        </div>

                                        <div class="row" style="padding-top: 0px; display: none; margin-left: 15px" id="btn">

                                            <%--<div class="col-lg-12">--%>

                                            <div class="col-lg-6">
                                                <center>
                                                    <a id="btn_homecard" runat="server" class="form-control btn btn-success btn-md">Home Card</a>
                                                </center>
                                            </div>
                                            <div class="col-lg-6">
                                                <center>
                                                    <a id="btn_readercard" runat="server" class="form-control btn btn-success btn-md">Reader Card</a>
                                                </center>
                                            </div>

                                            <%-- </div>--%>
                                        </div>




                                    </div>

                                </div>


                                </div>
          
                        </div>
                        <div class="row" style="padding: 10px; margin-top: -15px">
                            <div class="col-lg-12" style="margin-top: -15px">

                                <div class="card" style="display: none" id="issue">
                                    <div class="card-header">
                                        <span style="font-size: 15px; font-weight: bold; color: #012970">Issued Items</span>
                                    </div>
                                    <div class="card-body" style="margin-top:10px;">
                                        <div id="gridpending"></div>
                                    </div>
                                </div>

                                <div class="card" style="display: none" id="pay">
                                    <div class="card-header">
                                        <span style="font-size: 15px; font-weight: bold;">Pending Payments</span>
                                    </div>
                                    <div class="card-body">
                                        <div id="gridpendingpayments"></div>
                                    </div>
                                </div>

                                <div class="card" style="display: none" id="guest">
                                    <div class="card-header">
                                        <span style="font-size: 15px; font-weight: bold;">Guest Details</span>
                                    </div>
                                    <div class="card-body">
                                        <div id="bookissueforguest"></div>
                                    </div>
                                </div>
                            </div>
                        </div>

                         <div class="row" id="rowgridd" style="display: none;padding: 0px 12px;";>
                            <div class="col-lg-12" style="margin-top: -15px">
                                <div class="card">
                                <div class="card-header">
                                     <span style="font-size: 15px; font-weight: bold; color: #012970">Transaction Details</span>
                                </div>
                                <div class="card-body" style="margin-top:10px;">
                                    <div class="row">
                                        <div class="col-lg-12">
                                            <div class="table-responsive" style="OVERFLOW-Y: scroll;height:225px; overflow-x: scroll; WIDTH: 100%; OVERFLOW-X: scroll;text-align:left">
                                                <table id="tbltransactionbooks" class="table table-container table-responsive table-bordered" style="text-align:left">
                                                </table>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                    </div>
                                </div>
                        </div>

                        </section>

                    </div>

                </div>


            </div>
        </div>

    </div>

    <center>
        <div class="loader"></div>
    </center>


    </div>



    <!-- Edit Modal -->
     <div class="modal" id="transaction" data-bs-backdrop="static" style="display: none;" tabindex="-1" aria-labelledby="myModalLabel1" aria-hidden="true">
        <%--    style="height: auto; WIDTH: 768px">--%>
        <div class="modal-dialog modal-lg">
            <!-- Modal content -->
            <div class="modal-content">
                <div class="modal-header" style="background-color: #0d6efd">
                    <h4 class="modal-title" id="h2" style="color: white">Transaction</h4>
                    <button type="button" class="btn-close" data-dismiss="modal" id="btnclose" style="background-color: white; font-size: 10px;"></button>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-lg-6 " style="margin-top: -15px">
                            <span style="font-size: 17px; font-weight: bold;">Transactions :</span>

                            <asp:DropDownList ID="ddltransactions" runat="server" CssClass="form-control">
                                <asp:ListItem>--Select--</asp:ListItem>
                                <asp:ListItem>Return This Book</asp:ListItem>
                                <asp:ListItem>Change Return Date</asp:ListItem>
                                <asp:ListItem>Renew This Book</asp:ListItem>
                            </asp:DropDownList>
                            <%-- <select id="ddltransactions" class="form-control input-sm">
                                            <option>--Select--</option>
                                            <option>Return This Book</option>
                                            <option>Change Return Date</option>
                                            <option>Renew This Book</option>
                                        </select>--%>
                        </div>

                        <div class="col-lg-6 " id="finee">
                            <span style="font-size: 16px; font-weight: bold; margin-left: 110px">Fine To Be Paid:</span>
                            <span style="font-size: 17px; font-weight: bold; margin-left: -5px" id="lblfin"></span>
                        </div>
                    </div>
                    <br />
                    <div class="card" id="transactions" style="display: none; margin-top: -10px;">
                        <div class="card-body">
                            <div class="row">
                                <div class="col-lg-2"  style="margin-top: 10px">
                                     <span style="font-size: 17px; font-weight: bold;">Book Name :</span>
                                </div>

                                <div class="col-lg-10"  style="margin-top: 10px">
                                      <span id="txtbookname"></span>
                                </div>

                        <%--        <div class="col-lg-12" style="margin-top: 10px">    
                                </div>--%>

                            </div>
                            <br />
                            <div class="row" style="margin-top: -15px">
                                <div class="col-lg-7">
                                    <div class="hidden-md hidden-sm hidden-xs"><span style="font-size: 17px; font-weight: bold;">Change Already Given Return Date :</span></div>
                                </div>
                                <div class="col-lg-5">
                                    <input type="text" id="returndate" class="form-control" />
                                </div>
                            </div>
                            <br />
                            <div class="row" style="margin-top: -10px">
                                <div class="col-lg-7">
                                    <div class="hidden-md hidden-sm hidden-xs"><span style="font-size: 17px; font-weight: bold;">Book Return On :</span></div>
                                </div>
                                <div class="col-sm-5">
                                    <input type="text" id="returnbookdate" class="form-control" />
                                </div>
                            </div>
                            <br />
                            <div class="row" style="margin-top: -10px">
                                <div class="col-lg-7">
                                    <div class="hidden-md hidden-sm hidden-xs"><span style="font-size: 17px; font-weight: bold;">New Return Date for Renewing Book :</span></div>
                                </div>
                                <div class="col-sm-5">
                                    <input type="text" id="renewdate" class="form-control" />
                                </div>
                            </div>
                        </div>
                        <div class="row" style="margin-bottom: 20px">
                            <div class="col-lg-3">
                            </div>
                            <div class="col-lg-3">
                                <a id="btn_return" runat="server" class="form-control btn btn-success btn-md">OK</a>
                            </div>
                            <div class="col-lg-3">
                                <a id="btn_cancel" class="form-control btn btn-danger btn-md" data-bs-dismiss="modal">Cancel</a>
                            </div>
                            <div class="col-lg-3">
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


    </script>

    <script type="text/javascript">
        function Number(evt) {
            evt = (evt) ? evt : window.event;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                return false;
            }
            return true;
        }

        function ValidateNo() {
            var phoneNo = document.getElementById('txtmobno');

            if (phoneNo.value == "" || phoneNo.value == null) {
                toastr.warning("Please enter your Mobile No.");
                return false;
            }
            if (phoneNo.value.length < 10 || phoneNo.value.length > 10) {
                toastr.info("Enter 10 Digit Mobile No.");
                return false;
            }
        }
    </script>

    <script src="../../../Assets/notify-master/js/jquery-1.11.0.js"> </script>
   <script src="../../../Assets/js/jquery.datetimepicker.js"></script>

<%--    <script src="../../../Assets/confirmJs/jquery.confirm.min.js"></script>--%>
    <script src="../../../Assets/notify-master/js/notify.js"></script>
    <%--<script src="../../../Assets/notify-master/js/prettify.js"></script>--%>

    <script src="../../../Assets/jsgrid-1.5.3/jsgrid.min.js"></script>
    <%--<script src="../../../Assets/js/jquery.dialogBox.js"></script>--%>
    <script src="../../../Assets/vendor/nprogress/nprogress.js"></script>
    <script src="../../../Assets/JsForm/IssueReturn.js"></script>
   <%-- <script src="../../../Assets/js/jquery.min.js"></script>--%>

    <!------Materialixze----->
    <%-- <script src="materialize/js/materialize.min.js"></script>--%>
    <!----------------------->
</asp:Content>

