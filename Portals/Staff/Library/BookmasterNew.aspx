<%@ Page Title="" Language="C#" MasterPageFile="~/Portals/Staff/MasterPage.master" AutoEventWireup="true" CodeFile="BookmasterNew.aspx.cs" Inherits="BookmasterNew" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script src="../../../Assets/js/jquery.min.js"></script>
    <meta charset="utf-8" />
    <%--<link href="https://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/css/bootstrap-multiselect.css" rel="stylesheet" type="text/css" />--%>
    <link href="../../../Assets/css/bootstrap-multiselect.css" rel="stylesheet" />
    <%--<link href="Simple-jQuery-Tagging-Tokenizer-Input-with-Autocomplete-Tokens/lib/tokens.css" rel="stylesheet" />--%>
    <script src="../../../Assets/notify-master/js/notify.js"></script>
    <link href="../../../Assets/notify-master/css/notify.css" rel="stylesheet" />
    <link href="../../../Assets/Simple-jQuery-Tagging-Tokenizer-Input-with-Autocomplete-Tokens/token.css" rel="stylesheet" />
    <link href="../../../Assets/Google-Style-Easy-Autocomplete-Plugin-For-jQuery/jquery.autocomplete.css" rel="stylesheet" />
    <script src="../../../Assets/js/jquery.datetimepicker.js"></script>
    <link href="../../../Assets/css/jquery.datetimepicker.css" rel="stylesheet" />
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <!------------------------------>

    <div id="main" class="main">
        <div class="pagetitle " style="font-size: 32px; margin-left: 34px; font-weight: 300; color: #012970;">
            Masters 
        </div>

        <div class="container-fluid">


            <%--    <h2>Book Master</h2>--%>
            <div class="card card-info" style="margin: 10px">
                <div class="card-heading">
                    <div class="row">
                        <div class="col-lg-10">
                            <%-- <h3>Masters</h3>--%>
                        </div>
                        <div class="col-lg-2">
                            <a href="book_search.aspx" class="btn btn-primary" style="width: 100%; margin-bottom: 5%; margin-top: 5%;" target="_blank">Book Search</a>
                        </div>
                    </div>
                </div>
                <div class=" card card-body">

                    <div class="row">
                        <div class="col-lg-5">

                            <ul class="nav nav-tabs" id="myTab" role="tablist">
                                <%-- <li class="active"><a data-toggle="tab" href="#book">BOOK</a></li>
                            <li><a data-toggle="tab" href="#cd">CD</a></li>
                            <li><a data-toggle="tab" href="#map">MAP</a></li>
                            <li><a data-toggle="tab" href="#ebook">EBOOK</a></li>--%>

                                <li class="nav-item" role="presentation">
                                    <button class="nav-link active" id="booktab" data-bs-toggle="tab" data-bs-target="#book" type="button" role="tab" style="color: #012970" aria-controls="book" aria-selected="true">BOOK</button>
                                </li>

                                <li class="nav-item" role="presentation">
                                    <button class="nav-link " id="cdtab" data-bs-toggle="tab" data-bs-target="#cd" type="button" role="tab" style="color: #012970" aria-controls="cd" aria-selected="true">CD</button>
                                </li>

                                <li class="nav-item" role="presentation">
                                    <button class="nav-link " id="maptab" data-bs-toggle="tab" data-bs-target="#map" type="button" role="tab" style="color: #012970" aria-controls="map" aria-selected="true">MAP</button>
                                </li>

                                <li class="nav-item" role="presentation">
                                    <button class="nav-link " id="Ebooktab" data-bs-toggle="tab" data-bs-target="#ebook" type="button" role="tab" style="color: #012970" aria-controls="ebook" aria-selected="true">EBOOK</button>
                                </li>

                            </ul>

                        </div>

                        <div class="col-lg-4">
                            <div class="row">
                                <div class="col-lg-2"></div>
                                <div class="col-lg-4" style="margin-top: 4%;">Connect To:</div>
                                <div class="col-lg-5">
                                    <select class="form-select" style="margin-top: 8%; margin-bottom: 4%;" id="ddlselect">
                                        <option>Viva Engg</option>
                                        <option>MCA</option>
                                        <option>pharmacy</option>
                                        <option>Viva IMR</option>
                                        <%-- <option>Viva IMS</option>--%>
                                    </select>
                                </div>
                                <div class="col-lg-1"></div>

                            </div>

                        </div>


                        <div class="col-lg-3">
                            <a id="btncomman" class="btn btn-success" style="margin-top: 4%; margin-left: 20%;" data-bs-toggle="modal" data-bs-target="#myModal1">AUTHOR/PUB/DONOR</a>
                        </div>

                    </div>



                    <div class="tab-content">

                        <div id="book" class="tab-pane fade show active" role="tabpanel" aria-labelledby="booktab">
                            <div class="card card-primary">
                                <div class="card-body">

                                    <div class="row">
                                        <div class="col-lg-2">
                                            <%--       <div style="width: 100%">--%>
                                            <div class="row">
                                                <center>
                                                    <%--<div class="col-lg-12" style="padding-right: 100px;">--%>
                                                    <img class="img-bordered-sm" style="height: 160px; width: 160px" id="imgbook" src="../../../Assets/img/book_open.png" alt="Photo" />
                                                    <input type='file' id='book_photo' style="background-color: white; padding-top: 15px; font-size: 15px;" /><br />
                                                    <div style="width: 25%; height: 25%">
                                                    </div>
                                                    <%-- </div>--%>
                                                </center>
                                            </div>
                                            <%-- </div>--%>
                                        </div>

                                        <div class="col-lg-10">


                                            <div class="row">
                                                <%--       <div class="col-lg-12">--%>
                                                <div class="col-lg-4">
                                                    BOOK TITLE:
                                             			<input type="text" class="form-control" id="txtbooktitlee" style="border-radius: 5px; text-transform: uppercase" />

                                                </div>

                                                <div class="col-lg-4">
                                                    AUTHOR:
                                                        <br />
                                                    <input type="text" id="txtauthor" style="border-radius: 5px; height: 49px; width: 100%; border-width: 1px; text-transform: uppercase" />

                                                </div>
                                                <div class="col-lg-1" style="padding-top: 18px; display: none">
                                                    <button type="button" id="Button7" class="btn-info btn btn-md btn-block" data-toggle="modal" data-target="#myModal1" runat="server">
                                                        <span class="glyphicon glyphicon-plus"></span>
                                                    </button>
                                                </div>
                                                <div class="col-lg-4">
                                                    BOOK EDITION:
                        <input type="text" id="txtbookedition" runat="server" class="form-control" placeholder="Enter Book Edition" style="border-radius: 5px; text-transform: uppercase" />
                                                </div>
                                                <%--   </div>--%>
                                            </div>

                                            <div class="row">
                                                <%--<div class="col-lg-12 col-md-12 col-sm-12">--%>
                                                <div class="col-lg-4">
                                                    PUBLISHER:
                                            <input type="text" id="txtpublisher" style="border-radius: 5px; height: 49px; width: 100%; border-width: 1px; text-transform: uppercase" />
                                                </div>

                                                <div class="col-lg-1" style="padding-top: 18px; display: none">
                                                    <button type="button" id="Button1" class="btn-info btn btn-md btn-block" data-toggle="modal" data-target="#myModal1" runat="server">
                                                        <span class="glyphicon glyphicon-plus"></span>
                                                    </button>

                                                </div>
                                                <div class="col-lg-4">
                                                    CLASSIFICATION NO:
                                <input type="text" id="txtcallno" runat="server" class="form-control" placeholder="Enter Classification No" style="border-radius: 5px; text-transform: uppercase" />
                                                </div>

                                                <div class="col-lg-4">
                                                    ISBN NO:
                                <input type="text" id="txtisbnno" runat="server" class="form-control" placeholder="Enter Book ISBN No" style="border-radius: 5px; text-transform: uppercase" />
                                                </div>

                                                <%--  </div>--%>
                                            </div>


                                            <div class="row">
                                                <%-- <div class="col-lg-12 col-md-12 col-sm-12">--%>
                                                <div class="col-lg-3">
                                                    LANGUAGE:
                                <asp:DropDownList ID="ddllanguage" runat="server" CssClass="form-select" Style="border-radius: 5px; text-transform: uppercase">
                                </asp:DropDownList>
                                                </div>
                                                <div class="col-lg-1" style="padding-top: 30px">
                                                    <button type="button" id="Button8" class="btn-info btn btn-md btn-block" data-bs-toggle="modal" data-bs-target="#modallanguage" style="height: 50px; width: 80px;" runat="server">
                                                        <span class="bi bi-plus-square-fill" style="font-size: 25px;"></span>
                                                    </button>
                                                </div>
                                                <div class="col-lg-4">
                                                    KEYWORDS:
                                <input type="text" id="txtkeyword" runat="server" class="form-control" placeholder="Enter Book Keywords" style="border-radius: 5px; text-transform: uppercase" />
                                                </div>
                                                <div class="col-lg-2">
                                                    YEAR:
                                       <input type="text" id="txtyear" runat="server" class="form-control" placeholder="Enter Book Year" onkeypress="return isNumberKey(event,this)" style="border-radius: 5px" />
                                                </div>

                                                <div class="col-lg-2">
                                                    NO OF PAGES:
                                <input type="text" id="txtnoofpages" runat="server" class="form-control" placeholder="Enter Book No OF Pages" style="border-radius: 5px" />
                                                </div>
                                                <%--  </div>--%>
                                            </div>

                                            <div class="row" style="padding-top: 10px">
                                                <%--<div class="col-lg-12 col-md-12 col-sm-12">--%>
                                                <div class="col-lg-4">
                                                    SUBJECT:
                                    <input type="text" id="txtSubject" runat="server" class="form-control" placeholder="Enter Subjects" style="border-radius: 5px; text-transform: uppercase" />

                                                </div>
                                                <div class="col-lg-4">
                                                    REMARK:
                                       <input type="text" id="txtremark" runat="server" class="form-control" placeholder="Enter Book Remark" style="border-radius: 5px; text-transform: uppercase" />
                                                </div>
                                                <div class="col-lg-4">
                                                    ACCOMPANING MATERIAL:
                                     <input type="text" id="txtaccompaningmaterial" runat="server" class="form-control" placeholder="Enter Accompaning material" style="border-radius: 5px; text-transform: uppercase" />
                                                </div>

                                                <%--    </div>--%>
                                            </div>

                                            <div class="row" style="padding-top: 10px">
                                                <%-- <div class="col-lg-12 col-md-12 col-sm-12">--%>
                                                <div class="col-lg-2">
                                                    BOOK CATAGORY:
                                <asp:DropDownList ID="ddlbookcatogary" runat="server" CssClass="form-select" Style="border-radius: 5px">
                                    <asp:ListItem>--Select--</asp:ListItem>
                                    <asp:ListItem>REFERENCE</asp:ListItem>
                                    <asp:ListItem>TEXT BOOK</asp:ListItem>
                                    <asp:ListItem>GENERAL</asp:ListItem>
                                </asp:DropDownList>
                                                </div>
                                                <div class="col-lg-2">
                                                    BOOK TYPE:
                                <asp:DropDownList ID="ddlbooktype" runat="server" CssClass="form-select" Style="border-radius: 5px">
                                    <asp:ListItem>--Select--</asp:ListItem>
                                    <asp:ListItem>FOR ISSUE</asp:ListItem>
                                    <asp:ListItem> FOR NOT ISSUE</asp:ListItem>
                                </asp:DropDownList>
                                                </div>
                                                <div class="col-lg-2">
                                                    BOUND:
                                <asp:DropDownList ID="ddlbookbound" runat="server" CssClass="form-select" Style="border-radius: 5px">
                                    <asp:ListItem>--Select--</asp:ListItem>
                                    <asp:ListItem>HARD </asp:ListItem>
                                    <asp:ListItem> SOFT</asp:ListItem>
                                </asp:DropDownList>
                                                </div>

                                                <div class="col-lg-3">
                                                    DONOR:
                                          <input type="text" id="txtdonor" class="form-control" placeholder="Enter Donor" style="border-radius: 5px; text-transform: uppercase" />
                                                </div>
                                                <div class="col-lg-1" style="padding-top: 18px; display: none">
                                                    <button type="button" id="Button2" class="btn-info btn btn-md btn-block" data-toggle="modal" data-target="#myModal1" runat="server">
                                                        <span class="glyphicon glyphicon-plus"></span>
                                                    </button>

                                                </div>
                                                <div class="col-lg-3">
                                                    BOOK COUNT:
                                            <input type="text" id="txtbookcount" class="form-control" placeholder="Enter Book Count" onkeypress="return isNumberKey(event,this)" style="border-radius: 5px" />
                                                    <a id="btnnoofbooks" class="btn-block" style="display: none"></a>
                                                </div>

                                                <%--         </div>--%>
                                            </div>



                                        </div>
                                    </div>
                                    <%--new--%>
                                    <br />
                                    <div class="row" id="divhideshow" style="padding-top: 10px; display: none">
                                        <%--  <div class="col-lg-12 col-md-12 col-sm-12">--%>
                                        <div class="card card-default" style="border: 1px solid #375C8F;">
                                            <div class="card-body">
                                                <div class="table-responsive">
                                                    <table id="tableacceesiontable" class="table  table-responsive table-condensed table-bordered table-striped" style="margin-top: 15px;">
                                                    </table>
                                                </div>
                                            </div>
                                        </div>
                                        <%--</div>--%>
                                    </div>
                                    <%--end--%>

                                    <br />
                                    <div class="row" style="padding-top: 10px">
                                        <%-- <div class="col-lg-12">--%>
                                        <div class="col-lg-2"></div>
                                        <div class="col-lg-3">
                                            <button id="btnnsave" runat="server" style="width: 85%; margin-left: 20px;" class="btn btn-success"><span class="bi bi-book-fill">&nbsp;SAVE</span></button>
                                        </div>
                                        <div class="col-lg-3">
                                            <a id="btnnclear" runat="server" style="width: 85%; margin-left: 25px;" class="btn btn-danger"><span class="bi bi-x">&nbsp;CLEAR</span></a>
                                        </div>

                                        <div class="col-lg-3">
                                            <asp:UpdatePanel runat="server">
                                                <ContentTemplate>
                                                    <button id="btnbookedit" runat="server" style="width: 85%; margin-left: 28px;" class="btn btn-info" data-bs-toggle="modal" data-bs-target="#EditmodalBook"><span class="bi bi-pencil-square">&nbsp;EDIT</span></button>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>

                                        <div class="col-lg-1"></div>
                                        <%--</div>--%>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <%--CD--%>


                        <div id="cd" class="tab-pane fade">
                            <div class="card card-primary">
                                <div class="card-body">

                                    <div class="row">
                                        <div class="col-lg-2">
                                            <%--  <div style="width: 100%">--%>
                                            <div class="row">

                                                <center>
                                                    <%--<div class="col-lg-12" style="padding-right: 100px;">--%>
                                                    <img class="img-bordered-sm" style="height: 160px; width: 160px; margin-top: 15px;" id="imgcd" src="../../../Assets/img/cd.png" alt="Photo" />
                                                    <input type='file' id='cd_photo' style="background-color: white; padding-top: 15px; font-size: 15px;" /><br />
                                                    <div style="width: 25%; height: 25%">
                                                    </div>
                                                    <%--  </div>--%>
                                                </center>
                                            </div>
                                            <%-- </div>--%>
                                        </div>

                                        <div class="col-lg-10">
                                            <div class="row">

                                                <div class="col-lg-4">
                                                    CD TITLE:
                                            <input type="text" class="form-control" name="autocomplete" id="txt_cd_tit" value="" style="border-radius: 5px; text-transform: uppercase" autocomplete="off" />
                                                </div>

                                                <div class="col-lg-4">
                                                    ISBN NO:
                                <input type="text" id="txt_isbn" runat="server" class="form-control" placeholder="Enter ISBN No" style="border-radius: 5px; text-transform: uppercase" />
                                                </div>
                                                <div class="col-lg-3">
                                                    LANGUAGE:
                                <asp:DropDownList ID="cd_lang" runat="server" CssClass="form-select" Style="border-radius: 5px; text-transform: uppercase">
                                </asp:DropDownList>
                                                </div>
                                                <div class="col-lg-1" style="padding-top: 30px">
                                                    <button type="button" id="Button10" class="btn-info btn btn-md btn-block" style="width: 100%;" data-bs-toggle="modal" data-bs-target="#modallanguage" runat="server">
                                                        <span class="bi bi-plus-square-fill" style="font-size: 25px;"></span>
                                                    </button>
                                                </div>
                                            </div>

                                            <div class="row" style="margin-top: 3px;">

                                                <div class="col-lg-4">
                                                    Type:
                                            <asp:Label ID="Label2" runat="server" Text="BOOK TYPE:"></asp:Label>
                                                    <span style="color: red; font-size: 15px">*</span>
                                                    <div class="form-control" style="border-radius: 5px;">
                                                        <input type="radio" id="rd_cd_iss" value="FOR ISSUE" style="margin-left: 20px;" name="cdtype" />FOR ISSUE
                                        <input type="radio" id="rd_cd_n_iss" value="FOR NOT ISSUE" style="margin-left: 30px;" name="cdtype" />FOR NOT ISSUE
                                                    </div>

                                                </div>
                                                <div class="col-lg-4">
                                                    KEYWORDS:
                                <input type="text" id="txt_key" runat="server" class="form-control" placeholder="Enter CD Keywords" style="border-radius: 5px; text-transform: uppercase" />
                                                </div>
                                                <div class="col-lg-4">
                                                    Department:
                                   
                                            <asp:ListBox ID="ddlcourse_cd" runat="server" CssClass="form-control" SelectionMode="Multiple"></asp:ListBox>
                                                </div>


                                            </div>

                                            <div class="row" style="margin-top: 6px;">
                                                <%-- <div class="col-lg-12 col-md-12 col-sm-12">--%>
                                                <div class="col-lg-6">
                                                    PUBLISHER:
                                            <input type="text" id="txt_pub" style="border-radius: 5px; height: 45px; width: 100%; border-width: 1px; text-transform: uppercase" />

                                                </div>

                                                <div class="col-lg-1" style="padding-top: 18px; display: none">
                                                    <button type="button" id="btn_pub" class="btn-info btn btn-md btn-block" data-toggle="modal" data-target="#myModal1" runat="server">
                                                        <span class="glyphicon glyphicon-plus"></span>
                                                    </button>

                                                </div>

                                                <div class="col-lg-6">
                                                    AUTHOR:
                                             <input type="text" id="txt_auth" style="border-radius: 5px; height: 45px; width: 100%; border-width: 1px; text-transform: uppercase" />

                                                </div>
                                                <div class="col-lg-1" style="padding-top: 18px; display: none">
                                                    <button type="button" id="btn_auth" class="btn-info btn btn-md btn-block" data-toggle="modal" data-target="#myModal1" runat="server">
                                                        <span class="glyphicon glyphicon-plus"></span>
                                                    </button>

                                                </div>


                                                <%-- </div>--%>
                                            </div>

                                            <div class="row" style="margin-top: 10px;">
                                                <%--<div class="col-lg-12 col-md-12 col-sm-12">--%>
                                                <div class="col-lg-2">
                                                    YEAR:
                                       <input type="text" id="txt_yr" runat="server" class="form-control" placeholder="Enter CD Year" onkeypress="return isNumberKey(event,this)" style="border-radius: 5px" />
                                                </div>
                                                <div class="col-lg-2">
                                                    Duration:
                                                     <input type="text" id="txt_dur" runat="server" class="form-control" placeholder="Enter Duration" onchange="validateHhMm(this);" style="border-radius: 5px" />
                                                </div>


                                                <div class="col-lg-3">
                                                    Accompaning Materials:
                        <input type="text" id="txt_acc_mat" runat="server" class="form-control" placeholder="Enter Materials" style="border-radius: 5px; text-transform: uppercase" />
                                                </div>
                                                <div class="col-lg-2">
                                                    Subjects:
                                <input type="text" id="txt_sub" runat="server" class="form-control" placeholder="Enter Subjects" style="border-radius: 5px; text-transform: uppercase" />
                                                </div>
                                                <div class="col-lg-3">
                                                    REMARK:
                                       <input type="text" id="txt_rem" runat="server" class="form-control" placeholder="Enter CD Remark" style="border-radius: 5px; text-transform: uppercase" />
                                                </div>
                                                <%--  </div>--%>
                                            </div>

                                            <div class="row" style="margin-top: 5px;">

                                                <%-- <div class="col-lg-12 col-md-12 col-sm-12">--%>

                                                <div class="col-lg-2">
                                                    Count Of CD:
                                                     <input type="text" id="txt_cd_cnt" class="form-control" style="border-radius: 5px" onkeypress="return isNumber(event)" />
                                                </div>
                                                <div class="col-lg-5">
                                                    Donar Name:
                                               <input type="text" class="form-control" style="border-radius: 5px" id="donar_name" />
                                                </div>
                                                <div class="col-lg-1" style="padding-top: 18px; display: none">
                                                    <button type="button" id="Button3" class="btn-info btn btn-md btn-block" data-toggle="modal" data-target="#myModal1" runat="server">
                                                        <span class="glyphicon glyphicon-plus"></span>
                                                    </button>

                                                </div>

                                                <%--</div>--%>
                                            </div>
                                            <br />

                                        </div>

                                    </div>

                                    <br />

                                    <div class="table-responsive">
                                        <table id="tbl_cd" class="table table-condensed table-responsive table-bordered table-striped" style="margin-top: 15px;">
                                        </table>
                                    </div>
                                    <%-- <div class="row" id="divcdhide"  style="padding-top: 10px; display:none">
                                            <div class="card card-default" style="border: 1px solid #375C8F;">
                                                <div class="card-body">
                                                    
                                                </div>
                                            </div>
                                        </div>--%>

                                    <br />


                                    <div class="row">
                                        <div class="col-lg-2"></div>
                                        <div class="col-lg-3">
                                            <%-- <a id="cd_bthSave" runat="server" class="btn btn-success btn-block btn-sm"><i class="fa fa-save">&nbsp;SAVE</i></a>--%>
                                            <button id="cd_bthSave" runat="server" style="width: 85%; margin-left: 20px;" class="btn btn-success"><span class="bi bi-disc-fill">&nbsp;SAVE</span></button>
                                        </div>
                                        <div class="col-lg-3">
                                            <%--<a id="cd_bthclear" runat="server" class="btn btn-danger btn-block btn-sm"><i class="fa fa-times">&nbsp;CLEAR</i></a>--%>
                                            <button id="cd_bthclear" runat="server" style="width: 85%; margin-left: 25px;" class="btn btn-danger"><span class="bi bi-x">&nbsp;CLEAR</span></button>

                                        </div>
                                        <div class="col-lg-3">
                                            <%--  <a id="btnEditcd" class="btn-info btn btn-block btn-sm  pull-right" data-toggle="modal" data-target="#Editmodal_cd" runat="server">
                                                        <span class="glyphicon glyphicon-edit">EDIT</span>
                                                    </a>--%>
                                            <button id="btnEditcd" runat="server" style="width: 85%; margin-left: 28px;" class="btn btn-info" data-bs-toggle="modal" data-bs-target="#Editmodal_cd"><span class="bi bi-pencil-square">&nbsp;EDIT</span></button>

                                        </div>

                                        <div class="col-lg-1"></div>
                                    </div>







                                </div>
                                <%--end--%>
                            </div>
                        </div>

                        <%--MAP--%>


                        <div id="map" class="tab-pane fade">
                            <div class="card card-primary">
                                <div class="card-body">

                                    <div class="row">
                                        <div class="col-lg-2">
                                            <%--<div style="width: 100%">--%>
                                            <div class="row">
                                                <center>
                                                    <%--<div class="col-lg-12" style="padding-right: 100px;">--%>
                                                    <img class="img-bordered-sm" style="height: 160px; width: 160px; margin-top: 15px;" id="imgMap" src="../../../Assets/img/Map.png" alt="Photo" />
                                                    <input type='file' id='get_photo' style="background-color: white; padding-top: 15px; font-size: 15px;" /><br />

                                                    <div style="width: 25%; height: 25%">
                                                    </div>
                                                    <%-- </div>--%>
                                                </center>
                                            </div>
                                            <%-- </div>--%>
                                        </div>

                                        <div class="col-lg-10">
                                            <div class="row" style="margin-top: 8px;">
                                                <div class="col-lg-3">
                                                    MAP TITLE:
                                            <input type="text" class="form-control" id="txtmaptitle" style="border-radius: 5px; text-transform: uppercase" />

                                                </div>
                                                <div class="col-lg-2">
                                                    ISBN NO:
                                                 <input type="text" id="txtmapisbn" runat="server" class="form-control" placeholder="Enter Book ISBN No" style="border-radius: 5px; text-transform: uppercase" />
                                                </div>
                                                <div class="col-lg-2">
                                                    YEAR:
                                                  <input type="text" id="txtmapyear" runat="server" class="form-control" placeholder="Enter Book Year" onkeypress="return isNumberKey(event,this)" style="border-radius: 5px" />
                                                </div>
                                                <div class="col-lg-2">
                                                    LANGUAGE:
                                                <asp:DropDownList ID="ddlmaplang" runat="server" CssClass="form-select" Style="border-radius: 5px; text-transform: uppercase">
                                                </asp:DropDownList>
                                                </div>
                                                <div class="col-lg-1" style="padding-top: 30px">
                                                    <button type="button" id="Button9" class="btn-info btn btn-md btn-block" style="width: 100%; height: 50px;" data-bs-toggle="modal" data-bs-target="#modallanguage" runat="server">
                                                        <span class="bi bi-plus-square-fill" style="font-size: 25px;"></span>
                                                    </button>
                                                </div>
                                                <div class="col-lg-2">
                                                    MAP TYPE:
                                                <asp:DropDownList ID="dllmaptype" runat="server" CssClass="form-select" Style="border-radius: 5px">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                    <asp:ListItem>FOR ISSUE</asp:ListItem>
                                                    <asp:ListItem> FOR NOT ISSUE</asp:ListItem>
                                                </asp:DropDownList>
                                                </div>

                                            </div>

                                            <div class="row" style="margin-top: 10px;">

                                                <div class="col-lg-3">
                                                    KEYWORDS:
                                <input type="text" id="txtmapkeywords" runat="server" class="form-control" placeholder="Enter Book Keywords" style="border-radius: 5px; text-transform: uppercase" />
                                                </div>
                                                <div class="col-lg-2">
                                                    SUBJECT:
                                    <input type="text" id="txtmapsubj" runat="server" class="form-control" placeholder="Enter Subjects" style="border-radius: 5px; text-transform: uppercase" />

                                                </div>
                                                <div class="col-lg-2">
                                                    CALL NO:
                                     <input type="text" id="txtmapcallno" runat="server" class="form-control" placeholder="Call No" style="border-radius: 5px; text-transform: uppercase" />

                                                </div>
                                                <div class="col-lg-3">
                                                    ACCOMPANING MATERIAL:
                                     <input type="text" id="ttxmapacmaterial" runat="server" class="form-control" placeholder="Accompaning material" style="border-radius: 5px; text-transform: uppercase" />
                                                </div>
                                                <div class="col-lg-2">
                                                    REMARK:
                                          <input type="text" id="txtmapremrk" runat="server" class="form-control" placeholder="Enter Book Remark" style="border-radius: 5px; text-transform: uppercase" />
                                                </div>
                                            </div>



                                            <div class="row" style="margin-top: 10px;">
                                                <div class="col-lg-4">
                                                    AUTHOR:
                                             <input type="text" id="txtauthor_map" style="border-radius: 5px; height: 45px; width: 100%; border-width: 1px; text-transform: uppercase" />

                                                </div>
                                                <div class="col-lg-1" style="padding-top: 18px; display: none">
                                                    <button type="button" id="Button4" class="btn-info btn btn-md btn-block" data-toggle="modal" data-target="#myModal1" runat="server">
                                                        <span class="glyphicon glyphicon-plus"></span>
                                                    </button>
                                                </div>
                                                <div class="col-lg-4">
                                                    PUBLISHER:
                                            <input type="text" id="txtpublisher_map" style="border-radius: 5px; height: 45px; width: 100%; border-width: 1px; text-transform: uppercase" />


                                                </div>

                                                <div class="col-lg-1" style="padding-top: 18px; display: none">
                                                    <button type="button" id="Button5" class="btn-info btn btn-md btn-block" data-toggle="modal" data-target="#myModal1" runat="server">
                                                        <span class="glyphicon glyphicon-plus"></span>
                                                    </button>

                                                </div>

                                                <div class="col-lg-4">
                                                    DONOR:
                                          <input type="text" id="txtdonor_map" class="form-control" placeholder="Enter Donor" style="border-radius: 5px" />
                                                </div>
                                                <div class="col-lg-1" style="padding-top: 18px; display: none">
                                                    <button type="button" id="Button6" class="btn-info btn btn-md btn-block" data-toggle="modal" data-target="#myModal1" runat="server">
                                                        <span class="glyphicon glyphicon-plus"></span>
                                                    </button>

                                                </div>
                                            </div>

                                            <div class="row" style="margin-top: 10px;">


                                                <div class="col-lg-2">
                                                    MAP COUNT:
                                            <input type="number" id="txt_map_count" class="form-control" min="1" style="border-radius: 5px" />
                                                    <a id="A1" class="btn-block" style="display: none"></a>
                                                </div>
                                                <div class="col-lg-3">
                                                    DEPARTMENT:
                              
                                            <asp:ListBox ID="ddlMapDept" runat="server" CssClass="form-control" SelectionMode="Multiple"></asp:ListBox>
                                                </div>

                                            </div>

                                     

                                        </div>
                                    </div>

                                    <br />
                                    <div class="table-responsive">
                                        <table id="tblmap" class="table table-condensed table-responsive table-bordered table-striped" style="margin-top: 15px;">
                                        </table>
                                    </div>
                                    <br />

                                    <div class="row">

                                        <div class="col-lg-2"></div>
                                        <div class="col-lg-3">
                                            <%--   <a id="btnMapSave" runat="server" class="btn btn-success btn-block btn-sm"><i class="fa fa-save">&nbsp;SAVE</i></a>--%>
                                            <button id="btnMapSave" runat="server" style="width: 85%; margin-left: 20px;" class="btn btn-success"><span class="bi bi-map-fill">&nbsp;SAVE</span></button>
                                        </div>
                                        <div class="col-lg-3">
                                            <%--<a id="btnMapClear" runat="server" class="btn btn-danger btn-block btn-sm"><i class="fa fa-times">&nbsp;CLEAR</i></a>--%>
                                            <button id="btnMapClear" runat="server" style="width: 85%; margin-left: 25px;" class="btn btn-danger"><span class="bi bi-x">&nbsp;CLEAR</span></button>
                                        </div>
                                        <div class="col-lg-3">
                                            <%-- <a id="btnEditMap" class="btn-info btn  btn-block btn-sm pull-right" data-toggle="modal" data-target="#Editmodal" runat="server">
                                                    <span class="glyphicon glyphicon-edit"></span>Edit
                                                </a>--%>
                                            <button id="btnEditMap" runat="server" style="width: 85%; margin-left: 28px;" class="btn btn-info" data-bs-toggle="modal" data-bs-target="#Editmodal"><span class="bi bi-pencil-square">&nbsp;EDIT</span></button>
                                        </div>
                                        <div class="col-lg-1"></div>

                                    </div>
                                </div>
                            </div>
                        </div>

                        <%--EBOOK--%>


                        <div id="ebook" class="tab-pane fade">
                            <div class="card card-primary">
                                <div class="card-body">


                                    <div class="row" style="margin-top: 6px;">
                                        <div class="col-lg-3">
                                            EBOOK TITLE:
                                            <input type="text" class="form-control" id="txtebooktitle" style="border-radius: 5px; text-transform: uppercase" />
                                        </div>
                                        <div class="col-lg-4">
                                            AUTHOR:
                                              <input type="text" id="txt_author_ebook" style="border-radius: 5px; height: 45px; width: 100%; border-width: 1px; text-transform: uppercase" />
                                        </div>
                                        <div class="col-lg-3">
                                            KEYWORDS:
                                                 <input type="text" id="txt_keyword_ebook" runat="server" class="form-control" placeholder="Enter Book Keywords" style="border-radius: 5px; text-transform: uppercase" />
                                        </div>
                                        <div class="col-lg-2">
                                            NO OF PAGES:
                                                 <input type="text" id="txt_page_no_ebook" runat="server" class="form-control" placeholder="Enter Book No OF Pages" style="border-radius: 5px" />
                                        </div>
                                    </div>


                                    <div class="row" style="margin-top: 10px;">
                                        <div class="col-lg-3">
                                            CLASSIFICATION NO:
                                           <input type="text" id="txt_classification_no_ebook" runat="server" class="form-control" placeholder="Enter Classification No" style="border-radius: 5px; text-transform: uppercase" />
                                        </div>
                                        <div class="col-lg-2">
                                            EBOOK TYPE:
                                            <asp:DropDownList ID="ddl_ebook_type" runat="server" CssClass="form-select" Style="border-radius: 5px">
                                                <asp:ListItem>--Select--</asp:ListItem>
                                                <asp:ListItem>FOR ISSUE</asp:ListItem>
                                                <asp:ListItem> FOR NOT ISSUE</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>

                                        <div class="col-lg-2">
                                            BOUND:
                                            <asp:DropDownList ID="ddl_ebook_bound" runat="server" CssClass="form-select" Style="border-radius: 5px">
                                                <asp:ListItem>--Select--</asp:ListItem>
                                                <asp:ListItem>HARD </asp:ListItem>
                                                <asp:ListItem> SOFT</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-lg-2">
                                            LANGUAGE:
                                                    <asp:DropDownList ID="ddl_lang_ebook" runat="server" CssClass="form-select" Style="border-radius: 5px; text-transform: uppercase">
                                                    </asp:DropDownList>
                                        </div>
                                        <div class="col-lg-1" style="padding-top: 29px">
                                            <%--  <button type="button" id="Button11" class="btn-info btn btn-md btn-block" data-toggle="modal" data-target="#modallanguage" runat="server">
                                                        <span class="glyphicon glyphicon-plus"></span>
                                                    </button>--%>

                                            <button type="button" id="Button11" class="btn-info btn btn-md btn-block" style="width: 100%; height: 50px;" data-bs-toggle="modal" data-bs-target="#modallanguage" runat="server">
                                                <span class="bi bi-plus-square-fill" style="font-size: 25px;"></span>
                                            </button>

                                        </div>
                                        <div class="col-lg-2">
                                            ACCESSION-NO:
                                               <input type="text" class="form-control" id="txt_ebook_acc_no" placeholder="Enter Accession No" style="border-radius: 5px; text-transform: uppercase" />
                                        </div>

                                    </div>


                                    <br />
                                    <br />

                                    <div class="row">


                                        <div class="col-lg-2"></div>
                                        <div class="col-lg-3">
                                            <%--   <a id="btnMapSave" runat="server" class="btn btn-success btn-block btn-sm"><i class="fa fa-save">&nbsp;SAVE</i></a>--%>
                                            <button id="btnEbookSave" runat="server" style="width: 85%; margin-left: 20px;" class="btn btn-success"><span class="bi bi-book-fill">&nbsp;SAVE</span></button>
                                        </div>
                                        <div class="col-lg-3">
                                            <%--<a id="btnMapClear" runat="server" class="btn btn-danger btn-block btn-sm"><i class="fa fa-times">&nbsp;CLEAR</i></a>--%>
                                            <button id="btnEbookclear" runat="server" style="width: 85%; margin-left: 25px;" class="btn btn-danger"><span class="bi bi-x">&nbsp;CLEAR</span></button>
                                        </div>
                                        <div class="col-lg-3">
                                            <%-- <a id="btnEditMap" class="btn-info btn  btn-block btn-sm pull-right" data-toggle="modal" data-target="#Editmodal" runat="server">
                                                    <span class="glyphicon glyphicon-edit"></span>Edit
                                                </a>--%>
                                            <button id="btnEbookedit" runat="server" style="width: 85%; margin-left: 28px;" class="btn btn-info" data-bs-toggle="modal" data-bs-target="#EditmodalEBook"><span class="bi bi-pencil-square">&nbsp;EDIT</span></button>
                                        </div>
                                        <div class="col-lg-1"></div>

                                    </div>


                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </div>


        </div>

    </div>
    <!--------Modal-1--------->
    <!-- Trigger the modal with a button -->
    <!-- Modal -->
    <div class="modal fade" id="myModal1" data-bs-backdrop="static" tabindex="-1" role="dialog">
        <div class="modal-dialog modal-lg">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header" style="background-color: #0d6efd; color: white">

                    <h6 class="modal-title">ADD AUTHOR/PUBLISHER/DONOR</h6>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" style="background-color: white; font-size: 10px;"></button>
                </div>
                <div class="modal-body">
                    <div class="card border-primary mb-3">
                        <div class="container">
                            <div class="tab-content">
                                <div id="home">
                                    <div class="row">
                                        <div class="col-lg-1"></div>

                                        <div class="col-lg-10">
                                            <div class="form-group">
                                                <asp:Label ID="Label1" runat="server" Text="Select Here:"></asp:Label>

                                                <div class="form-control">

                                                    <input type="radio" name="Author" id="rdbvendor" />
                                                    VENDOR
                                                        
                                                <input type="radio" name="Author" style="margin-left: 30px;" id="rdbpublisher" />
                                                    PUBLISHER
                                                        
                                                <input type="radio" name="Author" style="margin-left: 40px;" id="rdbdonor" />
                                                    DONOR
                                                             
                                                <input type="radio" name="Author" style="margin-left: 45px;" id="rdbauthor" />
                                                    AUTHOR
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-lg-1"></div>
                                    </div>


                                    <%--     <div class="card-body">--%>
                                    <div class="row" style="margin-top: 10px;">
                                        <%--    <div class="col-lg-12">--%>

                                        <div class="col-lg-6">
                                            Name:
                                                        <asp:TextBox ID="txtauthorname" runat="server" CssClass="form-control" required="true" Style="text-transform: uppercase" placeholder="Enter Author Name Here..."></asp:TextBox>
                                        </div>

                                        <div class="col-lg-6">
                                            Mobile No:
                                                        <asp:TextBox ID="txtauthormobileno" runat="server" CssClass="form-control" onkeypress="return isNumberKey(event,this)" Style="text-transform: uppercase" placeholder="Enter Mobile Number"></asp:TextBox>
                                        </div>
                                        <%--  </div>--%>
                                    </div>
                                    <div class="row">
                                        <%-- <div class="col-lg-12" style="padding-top: 10px">--%>
                                        <div class="col-lg-6">
                                            Email Id:
                                                            <asp:TextBox ID="txtauthorEmailid" runat="server" CssClass="form-control" placeholder="Enter Email Id" onkyepresss="return ValidateEmail(email)"></asp:TextBox>
                                        </div>
                                        <div class="col-lg-6">
                                            Location:
                                                            <input type="text" id="txtauthorLocation" class="form-control" disabled="disabled" placeholder="Enter Location" />
                                            <%--<asp:TextBox ID="txtauthorLocation" runat="server" CssClass="form-control" placeholder="Enter Location" Enabled="false"></asp:TextBox>--%>
                                        </div>

                                        <%-- </div>--%>
                                    </div>

                                    <div class="row" style="padding-top: 10px">
                                        <%--  <div class="col-lg-12">--%>
                                        <div class="col-lg-6">
                                            Type:
                                                            <select id="ddltype" class="form-control" disabled="disabled">
                                                                <option>--Select--</option>
                                                                <option>Author</option>
                                                                <option>Editor</option>
                                                            </select>

                                        </div>
                                        <div class="col-lg-6">
                                            <asp:Label ID="lblIsUse" runat="server" Text="In Use:"></asp:Label>
                                            <div class="form-control">
                                                <asp:RadioButton ID="rdbyess" runat="server" Text="YES" GroupName="INUSE" />&nbsp;&nbsp;&nbsp;
                                                            <asp:RadioButton ID="rdbno" runat="server" Text="NO" GroupName="INUSE" />&nbsp;&nbsp;&nbsp;
                                            </div>
                                        </div>
                                        <%--  </div>--%>
                                    </div>
                                    <div class="row">
                                        <%-- <div class="col-lg-12">--%>
                                        <div class="col-lg-12" style="padding-top: 10px">
                                            Address:
                                                                <asp:TextBox ID="txtauthoraddress" runat="server" CssClass="form-control" Style="text-transform: uppercase" TextMode="MultiLine" placeholder="Enter Address Here"></asp:TextBox>
                                        </div>
                                        <%-- </div>--%>
                                    </div>

                                    <div class="row" style="margin-top: 25px; margin-bottom: 25px;">
                                        <%--<div class="col-lg-12" style="padding-top: 10px">--%>
                                        <div class="col-lg-2"></div>
                                        <div class="col-lg-4">
                                            <button id="btngeneraldetails" runat="server" style="width: 100%;" class="btn btn-success"><span class="bi bi-person-fill">&nbsp;SAVE</span></button>
                                            <%-- <a id="btngeneraldetails" runat="server" class=" btn btn-success btn-block btn-sm"><i class="fa fa-save">&nbsp;SAVE</i></a>--%>
                                        </div>
                                        <div class="col-lg-4">

                                            <button id="btnmodalclear" runat="server" style="width: 100%;" class="btn btn-danger"><span class="bi bi-x">&nbsp;CLEAR</span></button>
                                            <%--<a id="btnmodalclear" runat="server" class="btn btn-danger btn-block btn-sm"><i class="fa fa-times">&nbsp;Clear</i></a>--%>
                                        </div>
                                        <div class="col-lg-2"></div>
                                        <%--   <div class="col-lg-3">
                                                            <asp:Button ID="btnReport" runat="server" CssClass="form-control btn btn-info btn-sm" Text="Report" />
                                                        </div>
                                                        <div class="col-lg-3">
                                                            <asp:Button ID="btnAudit" runat="server" CssClass="form-control btn btn-default btn-sm" Text="Audit" />
                                                        </div>
                                                        <div class="col-lg-3">
                                                            <asp:Button ID="btnReplace" runat="server" CssClass="form-control btn btn-warning btn-sm" Text="Replace" />
                                                        </div>--%>
                                        <%--  </div>--%>
                                    </div>


                                    <%--</div>--%>
                                </div>
                            </div>
                        </div>
                    </div>


                </div>

            </div>
        </div>
    </div>

    <!--------Modal-2--------->
    <!-- Modal -->
    <div class="modal fade" id="EditmodalBook" data-bs-backdrop="static" tabindex="-1" aria-labelledby="myModalLabel">

        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="background-color: #0d6efd; color: white">
                    <h5 class="modal-title" id="myModalLabel">Search By Accession</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" style="background-color: white; font-size: 10px;"></button>

                </div>
                <div class="modal-body">
                    <b>Enter Book Accession</b>
                    <input type="text" id="txtbooksearch" class="form-control" placeholder="Enter Accession No" style="border-radius: 5px;" />
                </div>
                <div style="color: red; font-size: 17px;">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Note:- Enter Accession Number And Press Enter.
                </div>
                <div class="modal-footer">
                    <button type="button" id="btn_new_can" class="btn btn-danger" data-bs-dismiss="modal">CLOSE</button>

                </div>
            </div>
        </div>
    </div>


    <!-- EBOOK ---------------------------------------------------------------------------------------------------------------------------->
    <div class="modal fade" id="EditmodalEBook" data-bs-backdrop="static" aria-labelledby="myModalLabel">

        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="background-color: #0d6efd; color: white;">
                    <h5 class="modal-title" id="H4">Search By Accession</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" style="background-color: white; font-size: 10px;">
                    </button>
                </div>

                <div class="modal-body">
                    <b>Enter EBook Accession</b>
                    <input type="text" id="txt_ebook_search" class="form-control" placeholder="Enter Accession No" style="border-radius: 5px;" />
                </div>
                <div style="color: red; font-size: 17px;">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Note:- Enter Accession Number And Press Enter.
                </div>

                <div class="modal-footer">
                    <button type="button" id="btn_ebook_close" class="btn btn-danger" data-bs-dismiss="modal">CLOSE</button>
                    <%--<button type="button" id="btn_ebook_ok" class="btn btn-info">OK</button>--%>
                </div>
            </div>
        </div>

    </div>
    <!-- ------------------------------------------------------------------------------------------------- -->
    <div class="modal fade" id="Editmodal_cd" data-bs-backdrop="static" aria-labelledby="myModalLabel">

        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="background-color: #0d6efd; color: white;">
                    <h5 class="modal-title" id="H1">Search By Accession</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" style="background-color: white; font-size: 10px;">
                    </button>
                </div>

                <div class="modal-body">
                    <b>Enter CD Accession</b>
                    <input type="text" id="txt_cd_access" class="form-control" placeholder="Enter Accession no." style="border-radius: 5px;" />
                </div>
                <div style="color: red; font-size: 17px;">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Note:- Enter Accession Number And Press Enter.
                </div>
                <div class="modal-footer">
                    <button type="button" id="btn_cd_close" class="btn btn-danger" data-bs-dismiss="modal">CLOSE</button>
                </div>
            </div>
        </div>
    </div>


    <div class="modal fade" id="Editmodal" data-bs-backdrop="static" aria-labelledby="myModalLabel">

        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="background-color: #0d6efd; color: white;">
                    <h5 class="modal-title" id="H2">Search By Accession</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" style="background-color: white; font-size: 10px;">
                    </button>
                </div>

                <div class="modal-body">
                    <b>Enter MAP Accession</b>
                    <input type="text" id="txt_map_access" class="form-control" placeholder="Enter Accession no." style="border-radius: 5px;" />
                    <%--<asp:TextBox ID="txt_id_stud" runat="server" Visible="false"></asp:TextBox>--%>
                </div>
                <div style="color: red; font-size: 17px;">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Note:- Enter Accession Number And Press Enter.
                </div>
                <div class="modal-footer">
                    <button type="button" id="btn_map_close" class="btn btn-danger" data-bs-dismiss="modal">CLOSE</button>
                </div>
            </div>
        </div>

    </div>

    <%--   For Language--%>
    <div class="modal fade" id="modallanguage" data-bs-backdrop="static" tabindex="-1" role="dialog">

        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header" style="background-color: #0d6efd; color: white">
                    <h5 class="modal-title" id="H3">Add Language</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" style="background-color: white; font-size: 10px;"></button>
                </div>

                <div class="modal-body">
                    <div class="row">

                        <div class="col-lg-8">
                            <input type="text" id="txtaddlanguage" class="form-control" placeholder="Enter Language" style="text-transform: uppercase" />
                        </div>
                        <div class="col-lg-2">
                            <button id="btnlanguageadd" runat="server" class="btn btn-success btn-sm" style="margin-top: 4px; width: 100%;"><span class="bi bi-translate">&nbsp;SAVE</span></button>
                            <%-- <a id="btnlanguageadd" runat="server" class="btn btn-success btn-block btn-sm"><i class="fa fa-save">&nbsp;SAVE</i></a>--%>
                        </div>
                        <div class="col-lg-2">
                            <button id="btnlanguageclear" runat="server" class="btn btn-danger btn-sm" style="margin-top: 4px; width: 100%;"><span class="bi bi-x">&nbsp;CLEAR</span></button>
                            <%-- <a id="btnlanguageclear" runat="server" class="btn btn-danger btn-block btn-sm"><i class="fa fa-times">&nbsp;CLEAR</i></a>--%>
                        </div>

                    </div>

                </div>

            </div>
        </div>

    </div>

    <%--end--%>

    <!----------------------------->


    <script type="text/javascript">
        $(function () {
            $('[id*=ddlcourse_cd]').multiselect({
                includeSelectAllOption: true,
                buttonWidth: '100%',
                enableFiltering: true,
                enableCaseInsensitiveFiltering: true

            });
        });
        $(function () {
            $('[id*=ddlMapDept]').multiselect({
                includeSelectAllOption: true,
                buttonWidth: '100%',
                enableFiltering: true,
                enableCaseInsensitiveFiltering: true

            });
        });


        var empId = '<%=Session["emp_id"] %>'
        var emp_role = '<%=Session["emp_role"] %>'

    </script>

    <script type="text/JavaScript">
        function validateHhMm(inputField) {
            var isValid = /^([0-1]?[0-9]|2[0-4]):([0-5][0-9])(:[0-5][0-9])?$/.test(inputField.value);

            if (isValid) {
                // inputField.style.backgroundColor = '#bfa';
            } else {
                //inputField.style.backgroundColor = '#fba';
                $.notify("Time Format Should be HH:MM:SS.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });
            }

            return isValid;
        }
    </script>

    <%--<script src="https://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/js/bootstrap-multiselect.js" type="text/javascript"></script>--%>
    <script src="../../../Assets/js/bootstrap-multiselect.js"></script>
    <script src="../../../Assets/Google-Style-Easy-Autocomplete-Plugin-For-jQuery/jquery.autocomplete.js"></script>
    <script src="../../../Assets/JsForm/BookmasterNew.js"></script>
    <%--<script src="../../../Assets/notify-master/js/notify.js"></script>--%>
    <%--<script src="../../../Assets/js/jquery.datetimepicker.js"></script>--%>
    <script src="../../../Assets/confirmJs/jquery.confirm.min.js"></script>
    <script src="../../../Assets/Simple-jQuery-Tagging-Tokenizer-Input-with-Autocomplete-Tokens/lib/tokens.js"></script>
    <%--<script src="../../../Assets/confirmJs/jquery.confirm.min.js"></script>--%>
</asp:Content>

