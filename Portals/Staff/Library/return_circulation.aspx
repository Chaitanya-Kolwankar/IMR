<%@ Page Title="" Language="C#" MasterPageFile="~/Portals/Staff/MasterPage.master" AutoEventWireup="true" CodeFile="return_circulation.aspx.cs" Inherits="return_circulation" EnableEventValidation="false" %>

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
}*/




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
    <link href="../../../Assets/Fonts/css/font-awesome.css" rel="stylesheet" />
    <link href="../../../Assets/Fonts/css/font-awesome.min.css" rel="stylesheet" />

    <!---------------->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--<asp:ScriptManager ID="script" runat="server" EnablePageMethods="true"></asp:ScriptManager>--%>

    <div id="main" class="main">
         <div class="pagetitle "  style="font-size: 32px; margin-left: 34px; font-weight: 300; color: #012970;">
            Return 
        </div>

        <div class="container-fluid">
            <div class="row" style="margin-top: 5px">
                <div class="col-lg-12" >

                    <div class="card card-info" style="margin-top: 10px;">
                          <div class="card-heading">
                        <div class="row" style="margin-top:40px;"></div>
                    </div>

                        <div class="card-body" style="background-color: none;">
                            <div class="row">

                                <div class="col-lg-3" style="display:none;">
                                    Academic Year:
                                <asp:DropDownList ID="ddlyear" CssClass="form-control input-sm" runat="server" placeholder="Select Year">
                                </asp:DropDownList>
                                </div>
                                <div class="col-lg-3">
                                    Enter Accession ID:
                                <div class="row">
                                    <div class="col-lg-9">
                                        <input name="Student ID" type="text" id="txt_accession_ret" class="form-control input-sm" placeholder="Enter ID" />
                                        <input name="Student ID" type="text" id="txtStudId" class="form-control input-sm" style="display: none" placeholder="Enter ID" />

                                    </div>
                                    <div class="col-lg-3">
                                        <a id="btn_accession_ret" class="btn btn-success btn-sm" style=" margin-top: 4px; margin-left: 20px"><span class="bi-search"></span></a>
                                    </div>

                                </div>
                                </div>

                                <div class="col-lg-2" id="reset" style="display: none">
                                    <br class="hidden-xs hidden-sm" />
                                    <a id="btn_reset" runat="server" class="form-control btn btn-warning btn-md">Reset</a>
                                </div>

                                <div class="col-lg-3" style="margin-left: 20px;">
                                    Connect To:
                                <select class="form-control" id="ddlselect">
                                    <option>Viva Engg</option>
                                    <option>MCA</option>
                                    <option>pharmacy</option>
                                    <option>Viva IMR</option>
                                    <%-- <option>Viva IMS</option>--%>
                                </select>
                                </div>
                            </div>


                            <section class="content">
                                <div class="row" id="paneldetailsall" style="padding-left: 15px; padding-right: 10px;">

                                    <div class="col-lg-4 col-md-4 col-xs-12">
                                        <div class="card" id="paneldetails" style="display: none; margin-top: 15px; width: 560px; margin-left: -15px;border: 1px solid deepskyblue;">
                                            <div class="card-header panel-heading-sm" style="height: 35px">
                                                <span style="font-size: 15px; font-weight: bold;color: #012970">Profile</span>
                                            </div>

                                            <div class="box-body box-profile" style="padding: 20px">

                                                <div class="row">
                                                   
                                                    <div class="col-lg-2" style="margin-left: -15px;">

                                                        <center>
                                                            <img id="imgstud" class="profile-user-img img-responsive img-circle" alt="" style="height: 130px; width: 130px;" />
                                                        </center>
                                                    </div>
                                                    <div class="col-lg-9" style="margin-left: 55px;">


                                                        <div class="row" style="border-top: 1px solid lightgray; border-bottom: 1px solid lightgray; padding: 2px">
                                                            <div class="col-lg-3 col-xs-3">
                                                                <span style="font-weight: bold; color: black; font-size: 12px; text-align: left;">Name</span>
                                                                <span style="float: right; color: black">:</span>
                                                            </div>
                                                            <div class="col-lg-9 col-xs-9" style="font-size: 13px; margin-left: -10px;">
                                                                <p style="text-align: left; margin-bottom: 0px" id="txtStudName"></p>
                                                            </div>
                                                        </div>
                                                        <div class="row" style="border-top: 1px solid lightgray; border-bottom: 1px solid lightgray; padding: 2px">
                                                            <div class="col-lg-3 col-xs-3">
                                                                <span style="font-weight: bold; color: black; font-size: 12px; text-align: left;">Roll No</span>
                                                                <span style="float: right; color: black">:</span>
                                                            </div>
                                                            <div class="col-lg-9 col-xs-9">
                                                                <p style="text-align: left; margin-bottom: 0px" id="txtRollNo"></p>
                                                            </div>
                                                        </div>
                                                        <div class="row" style="border-top: 1px solid lightgray; border-bottom: 1px solid lightgray; padding: 2px">
                                                            <div class="col-lg-3 col-xs-3">
                                                                <span style="font-weight: bold; color: black; font-size: 12px; text-align: left;">CLASS</span>
                                                                <span style="float: right; color: black">:</span>
                                                            </div>
                                                            <div class="col-lg-9 col-xs-9" style="font-size: 15px;margin-left: -10px;">
                                                                <p style="text-align: left; margin-bottom: 0px" id="txtclass"></p>
                                                            </div>
                                                        </div>
                                                        <div class="row" style="border-bottom: 1px solid lightgray; padding: 2px">
                                                            <div class="col-lg-3 col-xs-3">
                                                                <span style="font-weight: bold; color: black; font-size: 12px; text-align: left;">DIV</span>
                                                                   <span style="float: right; color: black">:</span>
                                                            </div>
                                                            <div class="col-lg-9 col-xs-9">
                                                                <p style="text-align: left; margin-bottom: 0px" id="txtDiv"></p>
                                                            </div>
                                                        </div>
                                                        <div class="row" style="border-bottom: 1px solid lightgray; padding: 2px">
                                                            <div class="col-lg-3 col-xs-3">
                                                                <span style="font-weight: bold; color: black; font-size: 12px; text-align: left;">MOBILE NO</span>
                                                                 <span style="float: right; color: black">:</span>
                                                            </div>
                                                            <div class="col-lg-9 col-xs-9" style="margin-left: -10px;">
                                                                <p style="text-align: left; margin-bottom: 0px" id="txtmobno"></p>
                                                            </div>
                                                        </div>
                                                        <div class="row" style="padding: 2px">
                                                            <div class="col-lg-3 col-xs-3">
                                                                <span style="font-weight: bold; color: black; font-size: 11px; text-align: left;">ADDRESS</span>
                                                                <span style="float: right; color: black">:</span>
                                                            </div>
                                                            <div class="col-lg-9 col-xs-9" style="font-size: 12px; margin-left: -10px;">
                                                                <p style="text-align: left; margin-bottom: 0px" id="txtaddress"></p>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    
                                                </div>



                                                <%--   <h3 class="profile-username text-center" id="txtStudName" style="font-weight: bold"><i class="fa fa-user"></i></h3>
                                        <p class="text-muted text-center" style="font-weight: bold">Roll No: <span id="txtRollNo"></span></p>--%>
                                                <span id="lblSubcourseId" style="display: none"></span>







                                            </div>
                                        </div>

                                        <div class="card row" id="Employee" style="display: none;">
                                            <div class="card-header">
                                                <span style="font-size: 15px; font-weight: bold">Profile</span>
                                            </div>

                                            <div class="box-body box-profile" style="padding: 20px">
                                                <center>
                                                    <img id="imgemployee" class="profile-user-img img-responsive img-circle" alt="" style="height: 125px; width: 125px;">
                                                </center>
                                                <h3 class="profile-username text-center" id="txtempname" style="font-weight: bold"><i class="fa fa-user"></i></h3>

                                                <div class="row" style="border-top: 1px solid lightgray; border-bottom: 1px solid lightgray; padding: 2px">
                                                    <div class="col-lg-3 col-xs-3">
                                                        <span style="font-weight: bold; color: black; text-align: left;">MOBILE NO </span>
                                                        <span style="float: right; color: black">:</span>
                                                    </div>
                                                    <div class="col-lg-9 col-xs-9">
                                                        <p style="text-align: left; margin-bottom: 0px" id="txtempmobno"></p>
                                                    </div>
                                                </div>
                                                <div class="row" style="border-bottom: 1px solid lightgray; padding: 2px">
                                                    <div class="col-lg-3 col-xs-3">
                                                        <span style="font-weight: bold; color: black; text-align: left;">DEPARTMET</span>
                                                        <span style="float: right; color: black">:</span>
                                                    </div>
                                                    <div class="col-lg-9 col-xs-9">
                                                        <p style="text-align: left; margin-bottom: 0px" id="txtempdepart"></p>
                                                    </div>
                                                </div>
                                                <div class="row" style="border-bottom: 1px solid lightgray; padding: 2px">
                                                    <div class="col-lg-3 col-xs-3">
                                                        <span style="font-weight: bold; color: black; text-align: left;">DESIGNATION</span>
                                                        <span style="float: right; color: black">:</span>
                                                    </div>
                                                    <div class="col-lg-9 col-xs-9">
                                                        <p style="text-align: left; margin-bottom: 0px" id="txtempdesing"></p>
                                                    </div>
                                                </div>
                                                <div class="row" style="padding: 2px">
                                                    <div class="col-lg-3 col-xs-3">
                                                        <span style="font-weight: bold; color: black; text-align: left;">ADDRESS </span>
                                                        <span style="float: right; color: black">:</span>
                                                    </div>
                                                    <div class="col-lg-9 col-xs-9">
                                                        <p style="text-align: left; margin-bottom: 0px" id="txtempaddress"></p>
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
                                                            <a id="btn_guestsearch" class="btn btn-success btn-sm"><span class="glyphicon glyphicon-search"></span></a>
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
                                                        <asp:TextBox ID="txtguestmobno" runat="server" CssClass="form-control" placeholder="Enter Mobile No"></asp:TextBox>
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
                                    
                                    <%--New--%>
                                    <div class="col-lg-8 col-md-8 col-xs-12" id="transactions" style="display: none;margin-left:160px;width:643px">
                                        <div class="row" style="margin-top:15px">

                                            <div class="col-lg-6 ">
                                                <span style="font-size: 17px; font-weight: bold;">Transactions :</span>

                                                <asp:DropDownList ID="ddltransactions" runat="server" CssClass="form-control">
                                                    <%--<asp:ListItem>--Select--</asp:ListItem>--%>
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
                                            <br />

                                            <div class="col-lg-3 " id="finee" style="margin-top: 20px; margin-left:120px">
                                                <span style="font-size: 16px; font-weight: bold;">Fine To Be Paid:</span>
                                            </div>
                                            <div class="col-lg-1" style="margin-top: 20px; margin-left:-30px">
                                                <span style="font-size: 17px; font-weight: bold;" id="lblfin"></span>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row" style="margin-top: -15px;">
                                            <div class="col-lg-10">
                                                <span style="font-size: 17px; font-weight: bold;">Book Name :</span>
                                                <span id="txtbookname"></span>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row" style="margin-top: -18px;">
                                            <div class="col-lg-8">
                                                <div class="hidden-md hidden-sm hidden-xs"><span style="font-size: 17px; font-weight: bold;">Change Already Given Return Date  <i>(dd-mm-yyyy)  :</i> </span></div>
                                            </div>
                                            <div class="col-lg-4" style="width:196px;margin-left:12px">
                                                <%--<div class="hidden-lg">Change Already Given Return Date</div>--%>
                                                <input type="text" id="returndate" class="form-control" />
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row" style="margin-top: -8px;">
                                            <div class="col-lg-8">
                                                <div class="hidden-md hidden-sm hidden-xs"><span style="font-size: 17px; font-weight: bold;">Book Return On <i>(dd-mm-yyyy)   :</i> </span></div>
                                            </div>
                                            <div class="col-sm-4" style="margin-left:13px;width:196px">
                                                <%--<div class="hidden-lg">Book Return On</div>--%>
                                                <input type="text" id="returnbookdate" class="form-control" />
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row" style="margin-top: -8px;">
                                            <div class="col-lg-8" style="width:515px">
                                                <div class="hidden-md hidden-sm hidden-xs"><span style="font-size: 17px; font-weight: bold;">New Return Date for Renewing Book <i>(dd-mm-yyyy)  :</i> </span></div>
                                            </div>
                                            <div class="col-sm-4" style="width:196px;margin-left:-80px">
                                                <%--<div class="hidden-lg">New Return Date for Renewing Book</div>--%>
                                                <input type="text" id="renewdate" class="form-control" />
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="col-lg-3">
                                            </div>
                                            <div class="col-lg-3">
                                                <a id="btn_return" runat="server" class="form-control btn btn-success btn-md">Return</a>
                                            </div>
                                            <div class="col-lg-3">
                                                <a id="btn_cancel" runat="server" class="form-control btn btn-success btn-md">Cancel</a>
                                            </div>
                                        </div>
                                    </div>
                                    <%--<hr />--%>
                                    <center>
                                        <div class="loader" style="display: none;"></div>
                                    </center>
                                </div>

                                <div class="row" style="margin-left: 10px">
                                    <div class="col-lg-6">
                                        <div class="panel panel-info" style="display: none" id="pay">
                                            <div class="panel-heading">
                                                <span style="font-size: 15px; font-weight: bold;">Pending Payments</span>
                                            </div>
                                            <div class="panel-body">
                                                <div id="gridpendingpayments"></div>
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
    </div>
    <div class="modal fade" id="transactionpayment" role="dialog">
        <%-- style="height: auto; WIDTH: 768px"--%>
        <div class="modal-dialog" style="height: auto; width: 768px">
            <!-- Modal content -->
            <div class="modal-content">
                <div class="modal-header" style="background-color: #337ab7">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title" style="color: white;" id="H2">Transaction</h4>
                </div>
                <div class="modal-body">
                    <%--     
                        <div class="panel panel-info" id="transactions" style="display:none">--%>

                    <%-- <div class=" panel panel-body">--%>


                    <div class="row">
                        <div class="col-lg-4">
                            <span style="font-size: 17px; font-weight: bold;">Total Fine :</span>
                            <span id="lblfine"></span>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-lg-4">
                            <span style="font-size: 17px; font-weight: bold;">Total Fine Paid :</span>
                            <span id="lblfinepaid"></span>
                        </div>



                    </div>
                    <br />
                    <div class="row">

                        <div class="col-lg-4">
                            <span style="font-size: 17px; font-weight: bold;">Total Discount Given :</span>
                            <span id="lbldisamount"></span>
                        </div>


                    </div>
                    <br />
                    <div class="row">
                        <div class="col-lg-4">
                            <span style="font-size: 17px; font-weight: bold;">Enter Amount :</span>

                        </div>
                        <div class="col-lg-4">
                            <span>
                                <asp:TextBox ID="txtamount" runat="server" CssClass="form-control" placeholder="Enter Amount"></asp:TextBox></span>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-lg-4">
                            <span style="font-size: 17px; font-weight: bold;">Enter Discount Amount :</span>

                        </div>
                        <div class="col-lg-4">
                            <span>
                                <asp:TextBox ID="txtdiscountamt" runat="server" CssClass="form-control" placeholder="Enter Discount Amount"></asp:TextBox></span>
                        </div>

                    </div>
                    <br />
                    <div class="row">
                        <div class="col-lg-4">
                            <span style="font-size: 17px; font-weight: bold;">Remark :</span>

                        </div>
                        <div class="col-lg-4">
                            <span>
                                <asp:TextBox ID="txtremark" runat="server" CssClass="form-control" placeholder="Enter Remark"></asp:TextBox></span>
                        </div>

                    </div>
                    <%-- </div>--%>
                    <br />
                    <div class="row">
                        <div class="col-lg-3">
                        </div>
                        <div class="col-lg-3">
                            <a id="btn_pay" runat="server" class="form-control btn btn-success btn-md">PAY</a>
                        </div>

                        <div class="col-lg-3">
                            <a id="btn_can" runat="server" class="form-control btn btn-success btn-md">CANCEl</a>
                        </div>
                        <div class="col-lg-3">
                        </div>
                    </div>

                    <%-- </div>--%>
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

    <script src="../../../Assets/confirmJs/jquery.confirm.min.js"></script>
    <script src="../../../Assets/notify-master/js/notify.js"></script>
    <script src="../../../Assets/notify-master/js/prettify.js"></script>

    <script src="../../../Assets/jsgrid-1.5.3/jsgrid.min.js"></script>
    <script src="../../../Assets/js/jquery.dialogBox.js"></script>
    <script src="../../../Assets/JsForm/return_circulation.js"></script>

</asp:Content>

