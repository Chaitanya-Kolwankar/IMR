<%@ Page Title="" Language="C#" MasterPageFile="~/Portals/Staff/MasterPage.master" AutoEventWireup="true" CodeFile="frm_update_applicant_details.aspx.cs" Inherits="frm_update_applicant_details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="../../../Assets/js/jquery.datetimepicker.js"></script>
    <link href="../../Assets/css/jquery.datetimepicker.css" rel="stylesheet" />
    <style>
        #btnupdate {
            margin-left: 5px;
        }

        .linkunderline {
            color: black;
            text-decoration: none;
        }

        .rbl input[type="radio"] {
            margin-left: 5px;
            margin-right: 1px;
        }

        .btn-primary:disabled {
            background-color: #337ab7;
        }

        label {
            margin-bottom: 0px !important;
        }

        .chk input[type=checkbox] {
            margin: 0px;
        }

        .flex-container1 {
            width: 100%;
            display: flex;
            flex-direction: row;
            flex-wrap: wrap;
        }

        .flex-grow1 {
            flex-grow: 1;
            flex-direction: column;
            flex-wrap: wrap;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main" class="main">
        <div class="container-fluid">
            <div class="pagetitle " style="font-size: 32px; margin-left: 34px; font-weight: 300; color: #012970;">
                Pre-Admission
            </div>
            <div class="container-fluid">
                <div class="card">
                    <div class="row">
                        <div class="panel panel-primary">
                            <div class="card-title mx-4">
                                Update Registration
                            </div>
                            <div class="panel panel-body">
                                <div class="container-fluid">
                                    <asp:UpdatePanel runat="server">
                                        <ContentTemplate>
                                            <div class="row">
                                                <div class="col-lg-2 col-md-2 col-sm-12 col-xs-12">
                                                    Form No
                        <asp:TextBox ID="txtformno" runat="server" AutoComplete="off" CssClass="form-control" MaxLength="6" onkeypress="return alphanum(event)" />
                                                </div>
                                                <div class="col-lg-2 col-md-2 col-sm-12 col-xs-12">
                                                    &nbsp
                                    <div>
                                        <asp:Button ID="btnsearch" runat="server" Text="Search" CssClass="form-control text-center btn btn-primary" OnClick="btnsearch_Click1" />
                                    </div>
                                                </div>
                                                <div class="col-lg-2 col-md-2 col-sm-12 col-xs-12">
                                                    &nbsp
                        <div>
                            <asp:Button ID="btncancel" runat="server" Text="Cancel" CssClass="form-control text-center btn btn-primary" OnClick="btncancel_Click" />
                        </div>
                                                </div>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <br />
                                    <div class="accordion" id="accordion1">
                                        <div class="accordion-item">
                                            <h2 class="accordion-header" id="headingOne">
                                                <button class="accordion-button" type="button" data-bs-toggle="collapse" data-bs-target="#collap1" aria-expanded="true" aria-controls="collap1">
                                                    Step - 1 : Basic Details
                                                </button>
                                            </h2>
                                            <div id="collap1" class="accordion-collapse collapse in show" aria-labelledby="headingOne" data-bs-parent="#accordion1">
                                                <div class="accordion-body">
                                                    <asp:UpdatePanel runat="server">
                                                        <ContentTemplate>
                                                            <div class="row">
                                                                <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
                                                                    Last Name
      <asp:TextBox ID="lastname" oncut="return false" onpaste="return false" AutoComplete="off" oncopy="return false" CssClass="form-control" MaxLength="25" onkeypress="return allowOnlyLetters(event,this);" runat="server"></asp:TextBox>
                                                                </div>
                                                                <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
                                                                    First Name<span style="color: #ff3333">*</span>
                                                                    <asp:TextBox ID="firstname" oncut="return false" onpaste="return false" AutoComplete="off" oncopy="return false" CssClass="form-control" MaxLength="25" onkeypress="return allowOnlyLetters(event,this);" runat="server"></asp:TextBox>
                                                                </div>
                                                                <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
                                                                    Middle Name<span style="color: #ff3333">*</span>
                                                                    <asp:TextBox ID="midname" oncut="return false" onpaste="return false" AutoComplete="off" oncopy="return false" CssClass="form-control" MaxLength="25" onkeypress="return allowOnlyLetters(event,this);" runat="server"></asp:TextBox>
                                                                </div>
                                                                <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
                                                                    Mother's Name<span style="color: #ff3333">*</span>
                                                                    <asp:TextBox ID="mothername" oncut="return false" onpaste="return false" AutoComplete="off" oncopy="return false" CssClass="form-control" MaxLength="25" onkeypress="return allowOnlyLetters(event,this);" runat="server"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <br />
                                                            <div class="row">
                                                                <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
                                                                    Mobile Number<span style="color: #ff3333">*</span>
                                                                    <asp:TextBox ID="mobno" MaxLength="10" oncopy="return false" onpaste="return false" oncut="return false" autocomplete="off" CssClass="form-control" onkeypress="return allowonlynumbers(event,this);" runat="server"></asp:TextBox>
                                                                </div>
                                                                <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
                                                                    Other Contact No<span style="color: #ff3333">*</span>
                                                                    <asp:TextBox ID="othercont" CssClass="form-control" MaxLength="10" oncut="return false" onpaste="return false" AutoComplete="off" oncopy="return false" onkeypress="return allowonlynumbers(event,this);" runat="server"></asp:TextBox>
                                                                </div>
                                                                <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
                                                                    D.O.B<span style="color: #ff3333">*</span>
                                                                    <asp:TextBox runat="server" ID="dob" CssClass="form-control" MaxLength="20" oncopy="return false" onpaste="return false" oncut="return false" autocomplete="off" onKeyDown="return numdate1(event,this);">                                                                 </asp:TextBox>
                                                                </div>
                                                                <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
                                                                    Email Address<span style="color: #ff3333">*</span>
                                                                    <asp:TextBox ID="emailbox" CssClass="form-control" MaxLength="50" runat="server" autocomplete="off"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <br />
                                                            <div class="row">
                                                                <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12">
                                                                </div>
                                                                <div class="col-lg-2 col-md-2 col-sm-12 col-xs-12">
                                                                    <asp:Button ID="btnupdate" runat="server" Text="Update" CssClass="form-control text-center btn btn-primary" OnClick="btnupdate_Click" ValidationGroup="valgrp1" />
                                                                </div>
                                                                <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12">
                                                                </div>
                                                            </div>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="accordion-item">
                                            <h2 class="accordion-header" id="headingTwo">
                                                <button class="accordion-button" type="button" data-bs-toggle="collapse" data-bs-target="#collap2" aria-expanded="false" aria-controls="collap2">
                                                    Step - 2 : Personal Details
                                                </button>
                                            </h2>
                                            <div id="collap2" class="accordion-collapse collapse" aria-labelledby="headingTwo" data-bs-parent="#accordionExample">
                                                <div class="accordion-body">
                                                    <asp:UpdatePanel runat="server">
                                                        <ContentTemplate>
                                                            <div class="row">
                                                                <div class="col-lg-2 col-md-2 col-sm-12 col-xs-12">
                                                                    Gender<span style="color: #ff3333">*</span>
                                                                    <asp:RadioButtonList ID="rdgender" runat="server" CssClass="form-control rbl" RepeatDirection="Horizontal">
                                                                        <asp:ListItem Text="Male" Value="1" />
                                                                        <asp:ListItem Text="Female" Value="0" />
                                                                    </asp:RadioButtonList>
                                                                </div>
                                                                <div class="col-lg-2 col-md-2 col-sm-12 col-xs-12">
                                                                    Blood Group :
                                                                     <asp:DropDownList ID="ddlblood" runat="server" CssClass="form-control">
                                                                         <asp:ListItem Text="A -ve" Value="A -ve"></asp:ListItem>
                                                                         <asp:ListItem Text="B +ve" Value="B +ve"></asp:ListItem>
                                                                         <asp:ListItem Text="B -ve" Value="B -ve"></asp:ListItem>
                                                                         <asp:ListItem Text="AB +ve" Value="AB +ve"></asp:ListItem>
                                                                         <asp:ListItem Text="AB -ve" Value="AB -ve"></asp:ListItem>
                                                                         <asp:ListItem Text="O +ve" Value="O +ve"></asp:ListItem>
                                                                         <asp:ListItem Text="O -ve" Value="O -ve"></asp:ListItem>
                                                                     </asp:DropDownList>

                                                                </div>
                                                                <div class="col-lg-2 col-md-2 col-sm-12 col-xs-12">
                                                                    Place Of Birth<span style="color: #ff3333">*</span>
                                                                    <asp:TextBox ID="birthplace" oncopy="return false" AutoComplete="off" oncut="return paste" onpaste="return false" MaxLength="80" CssClass="form-control" onkeypress="return allowaddress(event,this);" runat="server"></asp:TextBox>
                                                                </div>
                                                                <div class="col-lg-2 col-md-2 col-sm-12 col-xs-12">
                                                                    City <span style="color: #ff3333">*</span>
                                                                    <asp:TextBox ID="citytxtbox" CssClass="form-control" oncopy="return false" AutoComplete="off" oncut="return paste" onpaste="return false" MaxLength="80" onkeypress="return allowaddress(event,this);" runat="server"></asp:TextBox>
                                                                </div>
                                                                <div class="col-lg-2 col-md-2 col-sm-12 col-xs-12">
                                                                    Marital Status<span style="color: #ff3333">*</span>
                                                                    <asp:DropDownList ID="ddlmarrystatus" runat="server" CssClass="form-control">
                                                                        <asp:ListItem Selected="True">--Select--</asp:ListItem>
                                                                        <asp:ListItem Value="0"> UNMARRIED </asp:ListItem>
                                                                        <asp:ListItem Value="1"> MARRIED </asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </div>

                                                                <div class="col-lg-2 col-md-2 col-sm-12 col-xs-12">
                                                                    Domiciled In :
                       <asp:TextBox ID="domicileid" oncopy="return false" oncut="return paste" onpaste="return false" AutoComplete="off" CssClass="form-control" MaxLength="80" onkeypress="return allowOnlyLetters(event,this);" runat="server"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <br />
                                                            <div class="row">

                                                                <div class="col-lg-2 col-md-2 col-sm-12 col-xs-12">
                                                                    Flat No. / Building <span style="color: #ff3333">*</span>
                                                                    <asp:TextBox ID="flattxtbox" oncopy="return false" oncut="return paste" onpaste="return false" AutoComplete="off" CssClass="form-control" MaxLength="80" onkeypress="return allowaddress(event,this);" runat="server"></asp:TextBox>
                                                                </div>

                                                                <div class="col-lg-2 col-md-2 col-sm-12 col-xs-12">
                                                                    Area <span style="color: #ff3333">*</span>
                                                                    <asp:TextBox ID="areatxtbox" AutoComplete="off" oncopy="return false" oncut="return paste" onpaste="return false" CssClass="form-control" MaxLength="80" onkeypress="return allowaddress(event,this);" runat="server"></asp:TextBox>
                                                                </div>

                                                                <div class="col-lg-2 col-md-2 col-sm-12 col-xs-12">
                                                                    Street <span style="color: #ff3333">*</span>
                                                                    <asp:TextBox ID="streettxtbox" AutoComplete="off" oncopy="return false" oncut="return paste" onpaste="return false" CssClass="form-control" MaxLength="80" onkeypress="return allowaddress(event,this);" runat="server"></asp:TextBox>
                                                                </div>

                                                                <div class="col-lg-2 col-md-2 col-sm-12 col-xs-12">
                                                                    Pincode <span style="color: #ff3333">*</span>
                                                                    <asp:TextBox ID="pintxtbox" autocomplete="off" oncopy="return false" oncut="return paste" onpaste="return false" CssClass="form-control" MaxLength="6" onkeypress="return allowonlynumbers(event,this);" runat="server"></asp:TextBox>
                                                                </div>

                                                                <div class="col-lg-2 col-md-2 col-sm-12 col-xs-12">
                                                                    State<span style="color: #ff3333">*</span><br />
                                                                    <asp:DropDownList ID="ddl_state_personal" CssClass="form-control" runat="server">
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </div>
                                                            <br />
                                                            <div class="row">
                                                                <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12">
                                                                </div>
                                                                <div class="col-lg-2 col-md-2 col-sm-12 col-xs-12">
                                                                    <asp:Button ID="btnupdate1" runat="server" Text="Update" CssClass="form-control text-center btn btn-primary" OnClick="btnupdate1_Click1" ValidationGroup="valgrp2" />
                                                                </div>
                                                                <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12">
                                                                </div>
                                                            </div>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="accordion-item">
                                            <h2 class="accordion-header" id="headingThree">
                                                <button class="accordion-button" type="button" data-bs-toggle="collapse" data-bs-target="#collap3" aria-expanded="false" aria-controls="collap3">
                                                    Step - 3 : Educational Details
                                                </button>
                                            </h2>
                                            <div id="collap3" class="accordion-collapse collapse" aria-labelledby="headingThree" data-bs-parent="#accordionExample">
                                                <div class="accordion-body">
                                                    <asp:UpdatePanel runat="server">
                                                        <ContentTemplate>
                                                            <div class="row">
                                                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                                    <div class="card">
                                                                        <div class="card-header bg-primary" style="font-weight: 600; color: white">
                                                                            <h7>S.S.C </h7>
                                                                        </div>
                                                                        <div class="card-body">
                                                                            <div class="row">
                                                                                <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
                                                                                    State<span style="color: #ff3333">*</span>
                                                                                    <asp:DropDownList ID="ddlstate" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlstate_SelectedIndexChanged">
                                                                                    </asp:DropDownList>
                                                                                </div>

                                                                                <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
                                                                                    Board <span style="color: #ff3333">*</span>
                                                                                    <asp:DropDownList ID="ddlboard" runat="server" CssClass="form-control">
                                                                                    </asp:DropDownList>
                                                                                </div>

                                                                                <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
                                                                                    School Name<span style="color: #ff3333">*</span>
                                                                                    <asp:TextBox ID="schoolname" CssClass="form-control" MaxLength="100" oncut="return false" onpaste="return false" oncopy="return false" autocomplete="off" onkeypress="return allowOnlyLetters(event,this);" runat="server"></asp:TextBox>
                                                                                </div>

                                                                                <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
                                                                                    School place<span style="color: #ff3333">*</span>
                                                                                    <asp:TextBox ID="schoolplace" CssClass="form-control" MaxLength="100" oncut="return false" onpaste="return false" oncopy="return false" autocomplete="off" onkeypress="return allowaddress(event,this);" runat="server"></asp:TextBox>
                                                                                </div>
                                                                            </div>

                                                                            <br />

                                                                            <div class="row">

                                                                                <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
                                                                                    First Attempt<span style="color: #ff3333">*</span>
                                                                                    <asp:RadioButtonList ID="rdattempt" runat="server" CssClass="form-control rbl" RepeatDirection="Horizontal">
                                                                                        <asp:ListItem Text="Yes" Value="1" />
                                                                                        <asp:ListItem Text="No" Value="0" />
                                                                                    </asp:RadioButtonList>
                                                                                </div>

                                                                                <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
                                                                                    Passing Year<span style="color: #ff3333">*</span>
                                                                                    <asp:DropDownList ID="ddlpassyear" runat="server" CssClass="form-select">
                                                                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                                        <asp:ListItem Value="2022"> 2022 </asp:ListItem>
                                                                                        <asp:ListItem Value="2021"> 2021 </asp:ListItem>
                                                                                        <asp:ListItem Value="2020"> 2020 </asp:ListItem>
                                                                                        <asp:ListItem Value="2019"> 2019 </asp:ListItem>
                                                                                        <asp:ListItem Value="2018"> 2018 </asp:ListItem>
                                                                                        <asp:ListItem Value="2017"> 2017 </asp:ListItem>
                                                                                        <asp:ListItem Value="2016"> 2016 </asp:ListItem>
                                                                                        <asp:ListItem Value="2015"> 2015 </asp:ListItem>
                                                                                        <asp:ListItem Value="2014"> 2014 </asp:ListItem>
                                                                                        <asp:ListItem Value="2013"> 2013 </asp:ListItem>
                                                                                        <asp:ListItem Value="2012"> 2012 </asp:ListItem>
                                                                                        <asp:ListItem Value="2011"> 2011 </asp:ListItem>
                                                                                        <asp:ListItem Value="2010"> 2010 </asp:ListItem>
                                                                                        <asp:ListItem Value="2009"> 2009 </asp:ListItem>
                                                                                        <asp:ListItem Value="2008"> 2008 </asp:ListItem>
                                                                                        <asp:ListItem Value="2007"> 2007 </asp:ListItem>
                                                                                        <asp:ListItem Value="2006"> 2006 </asp:ListItem>
                                                                                        <asp:ListItem Value="2005"> 2005 </asp:ListItem>
                                                                                        <asp:ListItem Value="2004"> 2004 </asp:ListItem>
                                                                                        <asp:ListItem Value="2003"> 2003 </asp:ListItem>
                                                                                        <asp:ListItem Value="2002"> 2002 </asp:ListItem>
                                                                                        <asp:ListItem Value="2001"> 2001  </asp:ListItem>
                                                                                        <asp:ListItem Value="2000"> 2000 </asp:ListItem>
                                                                                        <asp:ListItem Value="1999"> 1999  </asp:ListItem>
                                                                                        <asp:ListItem Value="1998"> 1998  </asp:ListItem>
                                                                                        <asp:ListItem Value="1997"> 1997  </asp:ListItem>
                                                                                        <asp:ListItem Value="1996"> 1996 </asp:ListItem>
                                                                                        <asp:ListItem Value="1995"> 1995 </asp:ListItem>
                                                                                        <asp:ListItem Value="1994"> 1994 </asp:ListItem>
                                                                                        <asp:ListItem Value="1993"> 1993 </asp:ListItem>
                                                                                        <asp:ListItem Value="1992"> 1992 </asp:ListItem>
                                                                                        <asp:ListItem Value="1991"> 1991  </asp:ListItem>
                                                                                        <asp:ListItem Value="1990"> 1990 </asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </div>

                                                                                <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
                                                                                    Passing Month <span style="color: #ff3333">*</span>
                                                                                    <asp:DropDownList ID="ddlpassmth" runat="server" CssClass="form-select">
                                                                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                                        <asp:ListItem Value="Jan"> Jan </asp:ListItem>
                                                                                        <asp:ListItem Value="Feb"> Feb </asp:ListItem>
                                                                                        <asp:ListItem Value="Mar"> Mar </asp:ListItem>
                                                                                        <asp:ListItem Value="Apr"> Apr </asp:ListItem>
                                                                                        <asp:ListItem Value="May"> May </asp:ListItem>
                                                                                        <asp:ListItem Value="Jun"> Jun </asp:ListItem>
                                                                                        <asp:ListItem Value="Jul"> Jul </asp:ListItem>
                                                                                        <asp:ListItem Value="Aug"> Aug </asp:ListItem>
                                                                                        <asp:ListItem Value="Sep"> Sept </asp:ListItem>
                                                                                        <asp:ListItem Value="Oct"> Oct </asp:ListItem>
                                                                                        <asp:ListItem Value="Nov"> Nov </asp:ListItem>
                                                                                        <asp:ListItem Value="Dec"> Dec </asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </div>

                                                                                <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
                                                                                    Seat No<span style="color: #ff3333">*</span>
                                                                                    <asp:TextBox ID="seatno" CssClass="form-control" autocomplete="off" oncut="return false" onpaste="return false" oncopy="return false" MaxLength="10" onkeypress="return allow(event,this);" runat="server"></asp:TextBox>
                                                                                </div>
                                                                            </div>
                                                                            <br />
                                                                            <div class="row">

                                                                                <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">
                                                                                    Total Marks Obtained<span style="color: #ff3333">*</span>
                                                                                    <asp:TextBox ID="mksobt" CssClass="form-control" autocomplete="off" oncut="return false" onpaste="return false" oncopy="return false" MaxLength="3" onkeypress="return allowonlynumbers(event,this);" runat="server"></asp:TextBox>
                                                                                </div>

                                                                                <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">
                                                                                    Out of Marks<span style="color: #ff3333">*</span>
                                                                                    <asp:TextBox ID="outofmks" autocomplete="off" oncut="return false" onpaste="return false" oncopy="return false" CssClass="form-control" MaxLength="3" onkeypress="return allowonlynumbers(event,this);" runat="server"></asp:TextBox>
                                                                                </div>

                                                                                <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">
                                                                                    Grade Obtained<span style="color: #ff3333">*</span>
                                                                                    <asp:TextBox ID="gradeobt" Style="text-transform: uppercase" CssClass="form-control" MaxLength="2" autocomplete="off" oncut="return false" onpaste="return false" oncopy="return false" onkeypress="return grade(event)" runat="server"></asp:TextBox>
                                                                                    <%-- onkeypress="return allowgrade(event,this);" --%>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                                    <div class="card">
                                                                        <div class="card-header bg-primary" style="font-weight: 600; color: white">
                                                                            <h7>H.S.C / Diploma</h7>
                                                                        </div>
                                                                        <div class="card-body">
                                                                            <div class="row">

                                                                                <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">
                                                                                    State <span style="color: #ff3333">*</span>
                                                                                    <asp:DropDownList ID="ddlstate1" runat="server" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlstate1_SelectedIndexChanged">
                                                                                        <%--<asp:ListItem Selected="True" Value="0">--Select--</asp:ListItem>--%>
                                                                                        <%--  <asp:ListItem> Maharashtra </asp:ListItem>
                            <asp:ListItem> Andaman and Nicobar </asp:ListItem>
                            <asp:ListItem> Andhra Pradesh </asp:ListItem>
                            <asp:ListItem> Arunachal Pradesh </asp:ListItem>
                            <asp:ListItem> Assam </asp:ListItem>
                            <asp:ListItem> Bihar </asp:ListItem>
                            <asp:ListItem> Chandigarh </asp:ListItem>
                            <asp:ListItem> Chattisgarh </asp:ListItem>
                            <asp:ListItem> Dadra and Nagar Haveli </asp:ListItem>
                            <asp:ListItem> Daman and Diu </asp:ListItem>
                            <asp:ListItem> Delhi </asp:ListItem>
                            <asp:ListItem> Goa </asp:ListItem>
                            <asp:ListItem> Gujarat </asp:ListItem>
                            <asp:ListItem> Haryana </asp:ListItem>
                            <asp:ListItem> Himachal Pradesh </asp:ListItem>
                            <asp:ListItem> Jammu and Kashmir </asp:ListItem>
                            <asp:ListItem> Jharkhand </asp:ListItem>
                            <asp:ListItem> Karnataka </asp:ListItem>
                            <asp:ListItem> Kerala </asp:ListItem>
                            <asp:ListItem> Lakshadweep </asp:ListItem>
                            <asp:ListItem> Madhya Pradesh </asp:ListItem>
                            <asp:ListItem> Manipur </asp:ListItem>
                            <asp:ListItem> Meghalaya  </asp:ListItem>
                            <asp:ListItem> Mizoram  </asp:ListItem>
                            <asp:ListItem> Nagaland  </asp:ListItem>
                            <asp:ListItem> Orissa </asp:ListItem>
                            <asp:ListItem> Pondicherry </asp:ListItem>
                            <asp:ListItem> Punjab </asp:ListItem>
                            <asp:ListItem> Rajasthan </asp:ListItem>
                            <asp:ListItem> Sikkim </asp:ListItem>
                            <asp:ListItem> Tamil Nadu </asp:ListItem>
                            <asp:ListItem> Tripura </asp:ListItem>
                            <asp:ListItem> Uttar Pradesh </asp:ListItem>
                            <asp:ListItem> Uttarakhand </asp:ListItem>
                            <asp:ListItem> West Bengal </asp:ListItem>--%>
                                                                                    </asp:DropDownList>
                                                                                </div>

                                                                                <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">
                                                                                    Board <span style="color: #ff3333">*</span>
                                                                                    <asp:DropDownList ID="ddlboard1" runat="server" CssClass="form-select">
                                                                                        <%-- <asp:ListItem Selected="True">--Select--</asp:ListItem>
                            <asp:ListItem> Central Board Of Secondary Education </asp:ListItem>
                            <asp:ListItem> Council For The Indian School Certificate Examinations </asp:ListItem>
                            <asp:ListItem> Directorate of Art Maharashtra State </asp:ListItem>
                            <asp:ListItem> Maharashtra State Board Of Secondary And Higher Secondary Education </asp:ListItem>
                            <asp:ListItem> Maharashtra State Board of Technical Education </asp:ListItem>
                            <asp:ListItem> Maharashtra Nursing Council Board </asp:ListItem>
                            <asp:ListItem> National Institute Of Open Schooling </asp:ListItem>
                            <asp:ListItem> University Of Mumbai </asp:ListItem>
                            <asp:ListItem> Dr. Babsaheb Ambedkar Marathwada University </asp:ListItem>
                            <asp:ListItem> SNDT Women's University </asp:ListItem>
                            <asp:ListItem> Yashwantrao Chavan Maharashtra Open University </asp:ListItem>
                            <asp:ListItem> Savitribai Phule Pune University </asp:ListItem>
                            <asp:ListItem> Shivaji University Kolhapur </asp:ListItem>
                            <asp:ListItem> University of Solapur </asp:ListItem>
                            <asp:ListItem> North Maharashtra University </asp:ListItem>
                            <asp:ListItem> Other </asp:ListItem>--%>
                                                                                    </asp:DropDownList>
                                                                                </div>

                                                                                <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">
                                                                                    College Name<span style="color: #ff3333">*</span>
                                                                                    <asp:TextBox ID="colgname" CssClass="form-control" oncut="return false" onpaste="return false" oncopy="return false" autocomplete="off" MaxLength="100" onkeypress="return allowOnlyLetters(event,this);" runat="server"></asp:TextBox>
                                                                                </div>


                                                                            </div>

                                                                            <br />

                                                                            <div class="row">
                                                                                <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
                                                                                    College place<span style="color: #ff3333">*</span>
                                                                                    <asp:TextBox ID="colgplace" CssClass="form-control" autocomplete="off" oncut="return false" onpaste="return false" oncopy="return false" MaxLength="100" onkeypress="return allowaddress(event,this);" runat="server"></asp:TextBox>
                                                                                </div>
                                                                                <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
                                                                                    First Attempt<span style="color: #ff3333">*</span>
                                                                                    <asp:RadioButtonList ID="rdattempt1" runat="server" CssClass="form-control rbl" RepeatDirection="Horizontal">
                                                                                        <asp:ListItem Text="Yes" Value="1" />
                                                                                        <asp:ListItem Text="No" Value="0" />
                                                                                    </asp:RadioButtonList>
                                                                                </div>

                                                                                <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
                                                                                    Passing Year<span style="color: #ff3333">*</span>
                                                                                    <asp:DropDownList ID="ddlpassyear1" runat="server" CssClass="form-select">
                                                                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                                        <asp:ListItem Value="2021"> 2021 </asp:ListItem>
                                                                                        <asp:ListItem Value="2020"> 2020 </asp:ListItem>
                                                                                        <asp:ListItem Value="2019"> 2019 </asp:ListItem>
                                                                                        <asp:ListItem Value="2018"> 2018 </asp:ListItem>
                                                                                        <asp:ListItem Value="2017"> 2017 </asp:ListItem>
                                                                                        <asp:ListItem Value="2016"> 2016 </asp:ListItem>
                                                                                        <asp:ListItem Value="2015"> 2015 </asp:ListItem>
                                                                                        <asp:ListItem Value="2014"> 2014 </asp:ListItem>
                                                                                        <asp:ListItem Value="2013"> 2013 </asp:ListItem>
                                                                                        <asp:ListItem Value="2012"> 2012 </asp:ListItem>
                                                                                        <asp:ListItem Value="2011"> 2011 </asp:ListItem>
                                                                                        <asp:ListItem Value="2010"> 2010 </asp:ListItem>
                                                                                        <asp:ListItem Value="2009"> 2009 </asp:ListItem>
                                                                                        <asp:ListItem Value="2008"> 2008 </asp:ListItem>
                                                                                        <asp:ListItem Value="2007"> 2007 </asp:ListItem>
                                                                                        <asp:ListItem Value="2006"> 2006 </asp:ListItem>
                                                                                        <asp:ListItem Value="2005"> 2005 </asp:ListItem>
                                                                                        <asp:ListItem Value="2004"> 2004 </asp:ListItem>
                                                                                        <asp:ListItem Value="2003"> 2003 </asp:ListItem>
                                                                                        <asp:ListItem Value="2002"> 2002 </asp:ListItem>
                                                                                        <asp:ListItem Value="2001"> 2001  </asp:ListItem>
                                                                                        <asp:ListItem Value="2000"> 2000 </asp:ListItem>
                                                                                        <asp:ListItem Value="1999"> 1999  </asp:ListItem>
                                                                                        <asp:ListItem Value="1998"> 1998  </asp:ListItem>
                                                                                        <asp:ListItem Value="1997"> 1997  </asp:ListItem>
                                                                                        <asp:ListItem Value="1996"> 1996 </asp:ListItem>
                                                                                        <asp:ListItem Value="1995"> 1995 </asp:ListItem>
                                                                                        <asp:ListItem Value="1994"> 1994 </asp:ListItem>
                                                                                        <asp:ListItem Value="1993"> 1993 </asp:ListItem>
                                                                                        <asp:ListItem Value="1992"> 1992 </asp:ListItem>
                                                                                        <asp:ListItem Value="1991"> 1991  </asp:ListItem>
                                                                                        <asp:ListItem Value="1990"> 1990 </asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </div>

                                                                                <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
                                                                                    Passing Month<span style="color: #ff3333">*</span>
                                                                                    <asp:DropDownList ID="ddlpassmth1" runat="server" CssClass="form-select">

                                                                                        <%--  <asp:ListItem> Jan </asp:ListItem>
                            <asp:ListItem> Feb </asp:ListItem>
                            <asp:ListItem> Mar </asp:ListItem>
                            <asp:ListItem> Apr </asp:ListItem>
                            <asp:ListItem> May </asp:ListItem>
                            <asp:ListItem> Jun </asp:ListItem>
                            <asp:ListItem> Jul </asp:ListItem>
                            <asp:ListItem> Aug </asp:ListItem>
                            <asp:ListItem> Sept </asp:ListItem>
                            <asp:ListItem> Oct </asp:ListItem>
                            <asp:ListItem> Nov </asp:ListItem>
                            <asp:ListItem> Dec </asp:ListItem>--%>
                                                                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                                        <asp:ListItem Value="Jan"> Jan </asp:ListItem>
                                                                                        <asp:ListItem Value="Feb"> Feb </asp:ListItem>
                                                                                        <asp:ListItem Value="Mar"> Mar </asp:ListItem>
                                                                                        <asp:ListItem Value="Apr"> Apr </asp:ListItem>
                                                                                        <asp:ListItem Value="May"> May </asp:ListItem>
                                                                                        <asp:ListItem Value="Jun"> Jun </asp:ListItem>
                                                                                        <asp:ListItem Value="Jul"> Jul </asp:ListItem>
                                                                                        <asp:ListItem Value="Aug"> Aug </asp:ListItem>
                                                                                        <asp:ListItem Value="Sep"> Sept </asp:ListItem>
                                                                                        <asp:ListItem Value="Oct"> Oct </asp:ListItem>
                                                                                        <asp:ListItem Value="Nov"> Nov </asp:ListItem>
                                                                                        <asp:ListItem Value="Dec"> Dec </asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </div>

                                                                            </div>
                                                                            <br />
                                                                            <div class="row">
                                                                                <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
                                                                                    Seat No<span style="color: #ff3333">*</span>
                                                                                    <asp:TextBox ID="seatno1" oncut="return false" onpaste="return false" oncopy="return false" CssClass="form-control" MaxLength="10" autocomplete="off" onkeypress="return allow(event,this);" runat="server"></asp:TextBox>

                                                                                </div>
                                                                                <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
                                                                                    Total Marks Obtained<span style="color: #ff3333">*</span>
                                                                                    <asp:TextBox ID="mksobt1" MaxLength="4" oncut="return false" autocomplete="off" onpaste="return false" oncopy="return false" CssClass="form-control" onkeypress="return allowonlynumbers(event,this);" runat="server"></asp:TextBox>
                                                                                </div>

                                                                                <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
                                                                                    Out of Marks<span style="color: #ff3333">*</span>
                                                                                    <asp:TextBox ID="outofmks1" MaxLength="4" autocomplete="off" oncut="return false" onpaste="return false" oncopy="return false" CssClass="form-control" onkeypress="return allowonlynumbers(event,this);" runat="server"></asp:TextBox>
                                                                                </div>

                                                                                <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
                                                                                    Grade Obtained<span style="color: #ff3333">*</span>
                                                                                    <asp:TextBox ID="gradeobt1" Style="text-transform: uppercase" onkeypress="return grade(event)" autocomplete="off" oncut="return false" onpaste="return false" oncopy="return false" CssClass="form-control" MaxLength="2" runat="server"></asp:TextBox>
                                                                                    <%--  onkeypress="return allowgrade(event,this);"--%>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-lg-12 col-md-12 col-xs-12">
                                                                    <div class="panel panel-primary">
                                                                        <div class="panel-heading">
                                                                            <h7>Graduation & Entrance Exam Details</h7>
                                                                        </div>
                                                                        <div class="panel-body">
                                                                            <div id="divgrad" runat="server">
                                                                                <div class="row">
                                                                                    <div class="col-lg-2 col-md-2 col-sm-12 col-xs-12">
                                                                                        <span>Graduation Course<span style="color: #ff3333">*</span> </span>
                                                                                        <asp:TextBox runat="server" type="text" ID="txtGraduationCourse" CssClass="form-control" MaxLength="20" autocomplete="off" onkeypress="return allowOnlyLetters(event,this);"></asp:TextBox>
                                                                                    </div>
                                                                                    <div class="col-lg-2 col-md-2 col-sm-12 col-xs-12">
                                                                                        <span>State <span style="color: #ff3333">*</span> </span>
                                                                                        <asp:DropDownList ID="ddlTYstate" CssClass="form-control" runat="server">
                                                                                            <%--<asp:ListItem>--SELECT--</asp:ListItem>
                         <asp:ListItem>MAHARASHTRA</asp:ListItem>
                         <asp:ListItem>ANDHRA PRADESH</asp:ListItem>
                         <asp:ListItem>ARUNACHAL PRADESH</asp:ListItem>
                         <asp:ListItem>ASSAM</asp:ListItem>
                         <asp:ListItem>BIHAR</asp:ListItem>
                         <asp:ListItem>CHHATTISGARH</asp:ListItem>
                         <asp:ListItem>GOA</asp:ListItem>
                         <asp:ListItem>GUJARAT</asp:ListItem>
                         <asp:ListItem>HARYANA</asp:ListItem>
                         <asp:ListItem>HIMACHAL PRADESH</asp:ListItem>
                         <asp:ListItem>JAMMU AND KASHMIR</asp:ListItem>
                         <asp:ListItem>JHARKHAND</asp:ListItem>
                         <asp:ListItem>KARNATAKA</asp:ListItem>
                         <asp:ListItem>KERALA</asp:ListItem>
                         <asp:ListItem>MADHYA PRADESH</asp:ListItem>
                         <asp:ListItem>MANIPUR</asp:ListItem>
                         <asp:ListItem>MEGHALAYA</asp:ListItem>
                         <asp:ListItem>MIZORAM</asp:ListItem>
                         <asp:ListItem>NAGALAND</asp:ListItem>
                         <asp:ListItem>ORISSA</asp:ListItem>
                         <asp:ListItem>PUNJAB</asp:ListItem>
                         <asp:ListItem>RAJASTHAN</asp:ListItem>
                         <asp:ListItem>SIKKIM</asp:ListItem>
                         <asp:ListItem>TAMIL NADU</asp:ListItem>
                         <asp:ListItem>TRIPURA</asp:ListItem>
                         <asp:ListItem>UTTAR PRADESH</asp:ListItem>
                         <asp:ListItem>UTTARAKHAND</asp:ListItem>
                         <asp:ListItem>WEST BENGAL</asp:ListItem>
                         <asp:ListItem>ANDAMAN AND NICOBAR ISLANDS</asp:ListItem>
                         <asp:ListItem>CHANDIGARH</asp:ListItem>
                         <asp:ListItem>DADRA AND NAGAR HAVELI</asp:ListItem>
                         <asp:ListItem>DAMAN AND DIU</asp:ListItem>
                         <asp:ListItem>LAKSHADWEEP</asp:ListItem>
                         <asp:ListItem>NATIONAL CAPITAL TERRITORY OF DELHI</asp:ListItem>
                         <asp:ListItem>PUDUCHERRY</asp:ListItem>--%>
                                                                                        </asp:DropDownList>
                                                                                    </div>
                                                                                    <div class="col-lg-2 col-md-2 col-sm-12 col-xs-12">
                                                                                        <span>University<span style="color: #ff3333">*</span> </span>
                                                                                        <asp:TextBox runat="server" ID="txt_graduation_university" CssClass="form-control" MaxLength="100" autocomplete="off" onkeypress="return allowOnlyLetters(event,this);"></asp:TextBox>
                                                                                    </div>
                                                                                    <div class="col-lg-2 col-md-2 col-sm-12 col-xs-12">
                                                                                        <span>Institute Name/College Name<span style="color: #ff3333">*</span> </span>
                                                                                        <asp:TextBox runat="server" ID="txtTYinstitutename" CssClass="form-control" MaxLength="100" autocomplete="off" onkeypress="return allowOnlyLetters(event,this);"></asp:TextBox>
                                                                                    </div>
                                                                                    <div class="col-lg-2 col-md-2 col-sm-12 col-xs-12">
                                                                                        <span>Institute place<span style="color: #ff3333">*</span></span>
                                                                                        <asp:TextBox runat="server" ID="txtTYinstituteplace" CssClass="form-control" MaxLength="100" autocomplete="off" onkeypress="return allowaddress(event,this);"></asp:TextBox>
                                                                                    </div>
                                                                                    <div class="col-lg-2 col-md-2 col-sm-12 col-xs-12">
                                                                                        <span>First Attempt<span style="color: #ff3333">*</span></span>
                                                                                        <asp:RadioButtonList ID="rbl_fstattemptgrd" runat="server" CssClass="form-control rbl" RepeatDirection="Horizontal">
                                                                                            <asp:ListItem Text="Yes" Value="1" />
                                                                                            <asp:ListItem Text="No" Value="0" />
                                                                                        </asp:RadioButtonList>
                                                                                    </div>
                                                                                </div>
                                                                                <br />
                                                                                <div class="row">
                                                                                    <div class="col-lg-2 col-md-2 col-sm-12 col-xs-12">
                                                                                        <span>Passing Year<span style="color: #ff3333">*</span> </span>
                                                                                        <asp:DropDownList ID="ddlTYpassyear" runat="server" CssClass="form-control">
                                                                                            <asp:ListItem Value="">--Select--</asp:ListItem>
                                                                                            <asp:ListItem Value="2022"> 2022 </asp:ListItem>
                                                                                            <asp:ListItem Value="2021"> 2021 </asp:ListItem>
                                                                                            <asp:ListItem Value="2020"> 2020 </asp:ListItem>
                                                                                            <asp:ListItem Value="2019"> 2019 </asp:ListItem>
                                                                                            <asp:ListItem Value="2018"> 2018 </asp:ListItem>
                                                                                            <asp:ListItem Value="2017"> 2017 </asp:ListItem>
                                                                                            <asp:ListItem Value="2016"> 2016 </asp:ListItem>
                                                                                            <asp:ListItem Value="2015"> 2015 </asp:ListItem>
                                                                                            <asp:ListItem Value="2014"> 2014 </asp:ListItem>
                                                                                            <asp:ListItem Value="2013"> 2013 </asp:ListItem>
                                                                                            <asp:ListItem Value="2012"> 2012 </asp:ListItem>
                                                                                            <asp:ListItem Value="2011"> 2011 </asp:ListItem>
                                                                                            <asp:ListItem Value="2010"> 2010 </asp:ListItem>
                                                                                            <asp:ListItem Value="2009"> 2009 </asp:ListItem>
                                                                                            <asp:ListItem Value="2008"> 2008 </asp:ListItem>
                                                                                            <asp:ListItem Value="2007"> 2007 </asp:ListItem>
                                                                                            <asp:ListItem Value="2006"> 2006 </asp:ListItem>
                                                                                            <asp:ListItem Value="2005"> 2005 </asp:ListItem>
                                                                                            <asp:ListItem Value="2004"> 2004 </asp:ListItem>
                                                                                            <asp:ListItem Value="2003"> 2003 </asp:ListItem>
                                                                                            <asp:ListItem Value="2002"> 2002 </asp:ListItem>
                                                                                            <asp:ListItem Value="2001"> 2001  </asp:ListItem>
                                                                                            <asp:ListItem Value="2000"> 2000 </asp:ListItem>
                                                                                            <asp:ListItem Value="1999"> 1999  </asp:ListItem>
                                                                                            <asp:ListItem Value="1998"> 1998  </asp:ListItem>
                                                                                            <asp:ListItem Value="1997"> 1997  </asp:ListItem>
                                                                                            <asp:ListItem Value="1996"> 1996 </asp:ListItem>
                                                                                            <asp:ListItem Value="1995"> 1995 </asp:ListItem>
                                                                                            <asp:ListItem Value="1994"> 1994 </asp:ListItem>
                                                                                            <asp:ListItem Value="1993"> 1993 </asp:ListItem>
                                                                                            <asp:ListItem Value="1992"> 1992 </asp:ListItem>
                                                                                            <asp:ListItem Value="1991"> 1991  </asp:ListItem>
                                                                                            <asp:ListItem Value="1990"> 1990 </asp:ListItem>
                                                                                        </asp:DropDownList>
                                                                                    </div>
                                                                                    <div class="col-lg-2 col-md-2 col-sm-12 col-xs-12">
                                                                                        <span>Passing Month<span style="color: #ff3333">*</span> </span>
                                                                                        <asp:DropDownList ID="ddlTYmonth" CssClass="form-control" runat="server">
                                                                                            <asp:ListItem Value="">--Select--</asp:ListItem>
                                                                                            <asp:ListItem Value="Jan">Jan</asp:ListItem>
                                                                                            <asp:ListItem Value="Feb">Feb</asp:ListItem>
                                                                                            <asp:ListItem Value="Mar">Mar</asp:ListItem>
                                                                                            <asp:ListItem Value="Apr">Apr</asp:ListItem>
                                                                                            <asp:ListItem Value="May">May</asp:ListItem>
                                                                                            <asp:ListItem Value="Jun">Jun</asp:ListItem>
                                                                                            <asp:ListItem Value="Jul">Jul</asp:ListItem>
                                                                                            <asp:ListItem Value="Aug">Aug</asp:ListItem>
                                                                                            <asp:ListItem Value="Sept">Sept</asp:ListItem>
                                                                                            <asp:ListItem Value="Oct">Oct</asp:ListItem>
                                                                                            <asp:ListItem Value="Nov">Nov</asp:ListItem>
                                                                                            <asp:ListItem Value="Dec">Dec</asp:ListItem>
                                                                                        </asp:DropDownList>
                                                                                    </div>
                                                                                    <div class="col-lg-2 col-md-2 col-sm-12 col-xs-12">
                                                                                        <span>Total Marks Obtained/CGPI<span style="color: #ff3333">*</span> </span>
                                                                                        <asp:TextBox runat="server" type="text" ID="txtTYmarksobtained" CssClass="form-control" autocomplete="off" onkeypress="return allowonlynumbersdot(event,this);" MaxLength="5"></asp:TextBox>
                                                                                    </div>
                                                                                    <div class="col-lg-2 col-md-2 col-sm-12 col-xs-12">
                                                                                        <span>Out of Marks/Total CGPI<span style="color: #ff3333">*</span> </span>
                                                                                        <asp:TextBox runat="server" type="text" ID="txtTYtotalmarks" CssClass="form-control" autocomplete="off" onkeypress="return allowonlynumbers(event,this);" MaxLength="5"></asp:TextBox>
                                                                                    </div>
                                                                                    <div class="col-lg-2 col-md-2 col-sm-12 col-xs-12">
                                                                                        <span>Grade Obtained<span style="color: #ff3333">*</span> </span>
                                                                                        <asp:TextBox runat="server" type="text" Style="text-transform: uppercase" ID="txtTYgrade" CssClass="form-control" autocomplete="off" onkeypress="return grade(event)" MaxLength="2"></asp:TextBox>
                                                                                    </div>
                                                                                    <div class="col-lg-2 col-md-2 col-sm-12 col-xs-12">
                                                                                        <span>Seat No<span style="color: #ff3333">*</span> </span>
                                                                                        <asp:TextBox runat="server" type="text" ID="txtTYseatno" CssClass="form-control" autocomplete="off" onkeypress="return allow(event,this);" MaxLength="9"></asp:TextBox>
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                            <br />
                                                                            <div class="row">
                                                                                <div class="col-lg-2 col-md-2 col-sm-12 col-xs-12">
                                                                                    <span>Exam Type<span style="color: #ff3333">*</span> </span>
                                                                                    <asp:DropDownList ID="ddl_examcet_type" runat="server" CssClass="form-control">
                                                                                        <asp:ListItem Value="">--Select--</asp:ListItem>
                                                                                        <asp:ListItem Value="JEE">JEE</asp:ListItem>
                                                                                        <asp:ListItem Value="MHT-CET">MHT-CET</asp:ListItem>
                                                                                        <asp:ListItem Value="OTHERS">OTHERS</asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </div>
                                                                                <div class="col-lg-2 col-md-2 col-sm-12 col-xs-12">
                                                                                    <span>Percentile<span style="color: #ff3333">*</span> </span>
                                                                                    <asp:TextBox runat="server" type="text" ID="txt_cet_mks_obt" CssClass="form-control" autocomplete="off" onkeypress="return allowonlynumbersdot(event,this);" MaxLength="5"></asp:TextBox>
                                                                                </div>
                                                                                <div class="col-lg-2 col-md-2 col-sm-12 col-xs-12">
                                                                                    <span>DTE/ARA Password<span style="color: #ff3333">*</span> </span>
                                                                                    <asp:TextBox runat="server" type="text" ID="txt_dtepasswd" CssClass="form-control" autocomplete="off" MaxLength="15"></asp:TextBox>
                                                                                </div>
                                                                                <div class="col-lg-2 col-md-2 col-sm-12 col-xs-12">
                                                                                    <span>CET/JEE ROLL NO<span style="color: #ff3333">*</span> </span>
                                                                                    <asp:TextBox runat="server" type="text" ID="txt_cetjee_rollno" CssClass="form-control" autocomplete="off" onkeypress="return allow(event,this);" MaxLength="30"></asp:TextBox>
                                                                                </div>
                                                                                <div class="col-lg-2 col-md-2 col-sm-12 col-xs-12">
                                                                                    <span>CET/JEE MERIT SCORE<span style="color: #ff3333">*</span> </span>
                                                                                    <asp:TextBox runat="server" type="text" ID="txt_cet_jee_meritscore" CssClass="form-control" autocomplete="off" onkeypress="return allowonlynumbers(event,this);" MaxLength="3"></asp:TextBox>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <br />
                                                            <div class="row">
                                                                <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12">
                                                                </div>
                                                                <div class="col-lg-2 col-md-2 col-sm-12 col-xs-12">
                                                                    <asp:Button ID="btnupdate2" runat="server" Text="Update" CssClass="form-control text-center btn btn-primary" OnClick="btnupdate2_Click" ValidationGroup="valgrp3" />
                                                                </div>
                                                                <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12">
                                                                </div>
                                                            </div>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="accordion-item">
                                            <h2 class="accordion-header" id="headingFour">
                                                <button class="accordion-button" type="button" data-bs-toggle="collapse" data-bs-target="#collap4" aria-expanded="false" aria-controls="collap4">
                                                    Step - 4 : Family Details
                                                </button>
                                            </h2>
                                            <div id="collap4" class="accordion-collapse collapse" aria-labelledby="headingFour" data-bs-parent="#accordionExample">
                                                <div class="accordion-body">
                                                    <asp:UpdatePanel runat="server">
                                                        <ContentTemplate>
                                                            <div class="row p-0">
                                                                <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                                                                    <div class="card">
                                                                        <div class="card-header bg-primary" style="font-weight: 600; color: white">
                                                                            Father's Details :
                                                                        </div>
                                                                        <div class="card-body">
                                                                            <div class="row">
                                                                                <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
                                                                                    Father's Name <span style="color: #ff3333">*</span>
                                                                                    <asp:TextBox ID="fathername" CssClass="form-control" MaxLength="50" oncut="return false" onpaste="return false" oncopy="return false" onkeypress="return allowOnlyLetters(event,this);" runat="server"></asp:TextBox>
                                                                                </div>

                                                                                <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
                                                                                    Father's Age :
                       <asp:TextBox ID="fage" oncut="return false" onpaste="return false" oncopy="return false" CssClass="form-control" MaxLength="2" onkeypress="return allowonlynumbers(event,this);" runat="server"></asp:TextBox>
                                                                                </div>

                                                                                <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
                                                                                    Email ID :
                       <asp:TextBox ID="fmail" CssClass="form-control" MaxLength="80" onkeypress="return checkEmail(event)" oncut="return false" onpaste="return false" oncopy="return false" runat="server"></asp:TextBox>
                                                                                </div>

                                                                                <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
                                                                                    Contact No<span style="color: #ff3333">*</span>
                                                                                    <asp:TextBox ID="fcontact" CssClass="form-control" MaxLength="10" onkeypress="return allowonlynumbers(event,this);" runat="server" oncut="return false" onpaste="return false" oncopy="return false"></asp:TextBox>
                                                                                </div>
                                                                            </div>

                                                                            <br />

                                                                            <div class="row">
                                                                                <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
                                                                                    Qualification
                     <asp:TextBox ID="fquali" CssClass="form-control" MaxLength="40" runat="server"></asp:TextBox>
                                                                                </div>

                                                                                <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
                                                                                    <asp:Label runat="server" Text="">Occupation<span style="COLOR: #ff3333">*</span></asp:Label>
                                                                                    <asp:DropDownList ID="focupation" runat="server" CssClass="form-control">
                                                                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                                        <asp:ListItem Value="Service" Text="Service">     </asp:ListItem>
                                                                                        <asp:ListItem Value="Business" Text="Business">    </asp:ListItem>
                                                                                        <asp:ListItem Value="Professional" Text="Professional">          </asp:ListItem>
                                                                                        <asp:ListItem Value="Farmer" Text=" Farmer">      </asp:ListItem>
                                                                                        <asp:ListItem Value="Labourer" Text=" Labourer">      </asp:ListItem>
                                                                                        <asp:ListItem Value="Retired" Text=" Retired">       </asp:ListItem>
                                                                                        <asp:ListItem Value="Other" Text=" Other">       </asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </div>

                                                                                <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
                                                                                    Designation:
                       <asp:TextBox ID="fdesg" CssClass="form-control" MaxLength="40" oncut="return false" onpaste="return false" oncopy="return false" onkeypress="return allowOnlyLetters(event,this);" runat="server"></asp:TextBox>
                                                                                </div>

                                                                                <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
                                                                                    Office Address :
                       <asp:TextBox ID="fadd" CssClass="form-control" MaxLength="80" runat="server"></asp:TextBox>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>

                                                                <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                                                                    <div class="card">
                                                                        <div class="card-header bg-primary" style="font-weight: 600; color: white">
                                                                            Mother's Details :
                                                                        </div>
                                                                        <div class="card-body">
                                                                            <div class="row">
                                                                                <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
                                                                                    Mother's Name<span style="color: #ff3333">*</span>
                                                                                    <asp:TextBox ID="mname" CssClass="form-control" MaxLength="50" onkeypress="return allowOnlyLetters(event,this);" runat="server" oncut="return false" onpaste="return false" oncopy="return false"></asp:TextBox>
                                                                                </div>

                                                                                <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
                                                                                    Mother's Age :
                       <asp:TextBox ID="mage" CssClass="form-control" MaxLength="2" oncut="return false" onpaste="return false" oncopy="return false" onkeypress="return allowonlynumbers(event,this);" runat="server"></asp:TextBox>
                                                                                </div>

                                                                                <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
                                                                                    Email ID :
                       <asp:TextBox ID="mmail" CssClass="form-control" oncut="return false" MaxLength="80" onpaste="return false" oncopy="return false" runat="server"></asp:TextBox>
                                                                                </div>

                                                                                <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
                                                                                    Contact No<span style="color: #ff3333">*</span>
                                                                                    <asp:TextBox ID="mcontact" CssClass="form-control" MaxLength="10" onkeypress="return allowonlynumbers(event,this);" oncut="return false" onpaste="return false" oncopy="return false" runat="server"></asp:TextBox>
                                                                                </div>
                                                                            </div>

                                                                            <br />

                                                                            <div class="row">

                                                                                <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
                                                                                    Qualification
                     <asp:TextBox ID="mquali" CssClass="form-control" MaxLength="40" runat="server"></asp:TextBox>
                                                                                </div>

                                                                                <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
                                                                                    Occupation <span style="color: #ff3333">*</span>
                                                                                    <asp:DropDownList ID="Moccupation" runat="server" CssClass="form-control">
                                                                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                                        <asp:ListItem Value="Service"> Service             </asp:ListItem>
                                                                                        <asp:ListItem Value="Business"> Business              </asp:ListItem>
                                                                                        <asp:ListItem Value="Professional"> Professional                    </asp:ListItem>
                                                                                        <asp:ListItem Value="Farmer"> Farmer            </asp:ListItem>
                                                                                        <asp:ListItem Value="Labourer"> Labourer           </asp:ListItem>
                                                                                        <asp:ListItem Value="Retired"> Retired           </asp:ListItem>
                                                                                        <asp:ListItem Value="Housewife"> Housewife           </asp:ListItem>
                                                                                        <asp:ListItem Value="Other"> Other               </asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </div>

                                                                                <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
                                                                                    Designation :
                       <asp:TextBox ID="mdesig" CssClass="form-control" MaxLength="40" runat="server"></asp:TextBox>
                                                                                </div>

                                                                                <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
                                                                                    Office Address :
                       <asp:TextBox ID="Madd" CssClass="form-control" MaxLength="80" runat="server"></asp:TextBox>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <br />
                                                            <div class="row">
                                                                <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12">
                                                                </div>
                                                                <div class="col-lg-2 col-md-2 col-sm-12 col-xs-12">
                                                                    <asp:Button ID="btnupdate3" runat="server" Text="Update" CssClass="form-control text-center btn btn-primary" OnClick="btnupdate3_Click" ValidationGroup="valgrp7" />
                                                                </div>
                                                                <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12">
                                                                </div>
                                                            </div>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="accordion-item">
                                            <h2 class="accordion-header" id="headingFive">
                                                <button class="accordion-button" type="button" data-bs-toggle="collapse" data-bs-target="#collap5" aria-expanded="false" aria-controls="collap5">
                                                    Step - 5 : Other Details
                                                </button>
                                            </h2>
                                            <div id="collap5" class="accordion-collapse collapse" aria-labelledby="headingFive" data-bs-parent="#accordionExample">
                                                <div class="accordion-body">
                                                    <asp:UpdatePanel runat="server">
                                                        <ContentTemplate>
                                                            <div class="row">
                                                                <div class="col-lg-2 col-md-2 col-sm-12 col-xs-12">
                                                                    Category<span style="color: #ff3333">*</span>
                                                                    <asp:DropDownList ID="ddlcat" runat="server" CssClass="form-select"
                                                                        AutoPostBack="true" OnSelectedIndexChanged="ddlcat_SelectedIndexChanged2">
                                                                    </asp:DropDownList>
                                                                </div>
                                                                <div class="col-lg-2 col-md-2 col-sm-12 col-xs-12">
                                                                    Caste <span style="color: #ff3333">*</span>
                                                                    <asp:DropDownList ID="ddlcaste" runat="server" OnSelectedIndexChanged="ddlcaste_SelectedIndexChanged" CssClass="form-control">
                                                                    </asp:DropDownList>
                                                                </div>

                                                                <div class="col-lg-2 col-md-2 col-sm-12 col-xs-12">
                                                                    Cast Validity/Receipt No.<span style="color: #ff3333">*</span>
                                                                    <asp:TextBox ID="certibox" oncut="return false" MaxLength="80" onpaste="return false" oncopy="return false" CssClass="form-control" runat="server" AutoComplete="off"></asp:TextBox>
                                                                </div>
                                                                <div class="col-lg-2 col-md-2 col-sm-12 col-xs-12">
                                                                    Cast Validity Date<span style="color: #ff3333">*</span>
                                                                    <asp:TextBox ID="txt_cast_date" oncut="return false" MaxLength="10" onpaste="return false" oncopy="return false" CssClass="form-control" runat="server" onKeyDown="return numdate1(event,this);" AutoComplete="off"></asp:TextBox>
                                                                </div>
                                                                <div class="col-lg-2 col-md-2 col-sm-12 col-xs-12">
                                                                    Income Certificate/Receipt No.<span style="color: #ff3333">*</span>
                                                                    <asp:TextBox ID="txt_income_cer" oncut="return false" MaxLength="80" AutoComplete="off" onpaste="return false" oncopy="return false" CssClass="form-control" runat="server"></asp:TextBox>
                                                                </div>
                                                                <div class="col-lg-2 col-md-2 col-sm-12 col-xs-12">
                                                                    Income Certificate Date<span style="color: #ff3333">*</span>
                                                                    <asp:TextBox ID="txt_income_date" oncut="return false" MaxLength="10" AutoComplete="off" onpaste="return false" oncopy="return false" CssClass="form-control" runat="server" onKeyDown="return numdate1(event,this);"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <br />
                                                            <div class="row">
                                                                <div class="col-lg-2 col-md-2 col-sm-12 col-xs-12">
                                                                    Religion<span style="color: #ff3333">*</span>
                                                                    <asp:DropDownList ID="ddlrel" runat="server" CssClass="form-select">
                                                                    </asp:DropDownList>
                                                                </div>
                                                                <div class="col-lg-2 col-md-2 col-sm-12 col-xs-12">
                                                                    Special Category
             <asp:DropDownList ID="ddl_special_category" runat="server" CssClass="form-control">
                 <asp:ListItem Value="">--Select--</asp:ListItem>
                 <asp:ListItem Value="None">None</asp:ListItem>
                 <asp:ListItem Value="Ex-Serviceman/Ward of Ex-Serviceman">Ex-Serviceman/Ward of Ex-Serviceman </asp:ListItem>
                 <asp:ListItem Value="Active-Serviceman/Ward of Active-Serviceman">Active-Serviceman/Ward of Active-Serviceman</asp:ListItem>
                 <asp:ListItem Value="Ward of Primary Teacher">Ward of Primary Teacher</asp:ListItem>
                 <asp:ListItem Value="Ward of Secondary Teacher">Ward of Secondary Teacher</asp:ListItem>
                 <asp:ListItem Value="Deserted/Divorced/Wodowed Woman">Deserted/Divorced/Wodowed Woman</asp:ListItem>
                 <asp:ListItem Value="Member of project Affected Family">Member of project Affected Family</asp:ListItem>
                 <asp:ListItem Value="Member of Earthquake Affected Family">Member of Earthquake Affected Family</asp:ListItem>
                 <asp:ListItem Value="Member of Flood/Famine Affected Family">Member of Flood/Famine Affected Family</asp:ListItem>
                 <asp:ListItem Value="Resident of Tribal Area">Resident of Tribal Area</asp:ListItem>
                 <asp:ListItem Value="Kashmir Migrant">Kashmir Migrant</asp:ListItem>
                 <asp:ListItem Value="Economically Backward Class">Economically Backward Class</asp:ListItem>
                 <asp:ListItem Value="University Staff Quota">University Staff Quota</asp:ListItem>
             </asp:DropDownList>
                                                                </div>
                                                                <div class="col-lg-2 col-md-2 col-sm-12 col-xs-12">
                                                                    Is Physically Reserved :
                       <asp:DropDownList ID="ddlphy" runat="server" CssClass="form-control">
                           <asp:ListItem Selected="True">--Select--</asp:ListItem>
                           <asp:ListItem Text="Visually Impaired" Value="Visually Impaired"></asp:ListItem>
                           <asp:ListItem Text="Speech and/or Hearing Impaired" Value="Speech and/or Hearing Impaired"></asp:ListItem>
                           <asp:ListItem Text="Orthopedic Disorder" Value="Orthopedic Disorder"></asp:ListItem>
                           <asp:ListItem Text="Mentally Retarded" Value="Mentally Retarded"></asp:ListItem>
                           <asp:ListItem Text="Learning Disability" Value="Learning Disability"></asp:ListItem>
                           <asp:ListItem Text="Dyslexia" Value="Dyslexia"></asp:ListItem>
                       </asp:DropDownList>
                                                                </div>
                                                                <div class="col-lg-2 col-md-2 col-sm-12 col-xs-12">
                                                                    <span style="font-size: small">Acquired in extra Curricular Activities</span>
                                                                    <asp:RadioButtonList ID="ddlProficien" runat="server" CssClass="form-control rbl" RepeatDirection="Horizontal">
                                                                        <asp:ListItem Text="Yes" Value="1" />
                                                                        <asp:ListItem Text="No" Value="0" />
                                                                    </asp:RadioButtonList>
                                                                </div>
                                                                <div class="col-lg-2 col-md-2 col-sm-12 col-xs-12">
                                                                    Whether a Member of NCC / NSS<span style="color: #ff3333">*</span>
                                                                    <asp:DropDownList ID="ddlnccnss" runat="server" CssClass="form-control">
                                                                        <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                                        <asp:ListItem Text="None" Value="None"></asp:ListItem>
                                                                        <asp:ListItem Text="Both" Value="Both"></asp:ListItem>
                                                                        <asp:ListItem Text="NCC" Value="NCC"></asp:ListItem>
                                                                        <asp:ListItem Text="NSS" Value="NSS"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </div>
                                                                <div class="col-lg-2 col-md-2 col-sm-12 col-xs-12">
                                                                    <span style="font-size: smaller">Are you proposed to apply Scholarship/Freeship<span style="color: #ff3333">*</span></span>
                                                                    <asp:RadioButtonList ID="rdbscholar" runat="server" CssClass="form-control rbl" RepeatDirection="Horizontal">
                                                                        <asp:ListItem Text="Yes" Value="1" />
                                                                        <asp:ListItem Text="No" Value="0" />
                                                                    </asp:RadioButtonList>
                                                                </div>
                                                            </div>
                                                            <br />
                                                            <div class="row">
                                                                <div class="panel panel-primary">
                                                                    <div class="panel-heading">
                                                                        NO. OF PERSONS IN THE FAMILY <span style="color: #ff3333">*</span>
                                                                    </div>
                                                                    <div class="panel-body">
                                                                        <div class="row">
                                                                            <div class="col-lg-2 col-md-2 col-sm-12 col-xs-12">
                                                                                Earning<span style="color: #ff3333">*</span>
                                                                                <asp:TextBox ID="txtearn" autocomplete="off" onKeyPress="return OnlyNum(event)" runat="server" MaxLength="2" CssClass="form-control" oncut="return false" onpaste="return false" oncopy="return false"></asp:TextBox>
                                                                            </div>
                                                                            <div class="col-lg-2 col-md-2 col-sm-12 col-xs-12">
                                                                                Non-Earning<span style="color: #ff3333">*</span>
                                                                                <asp:TextBox ID="txtnonear" OnTextChanged="txtnonear_TextChanged" onKeyPress="return OnlyNum(event)" AutoPostBack="true" autocomplete="off" MaxLength="2" oncut="return false" onpaste="return false" oncopy="return false" runat="server" CssClass="form-control"></asp:TextBox>
                                                                            </div>
                                                                            <div class="col-lg-2 col-md-2 col-sm-12 col-xs-12">
                                                                                Total<span style="color: #ff3333">*</span>
                                                                                <asp:TextBox ID="txttotal" runat="server" autocomplete="off" ReadOnly="true" CssClass="form-control"></asp:TextBox>
                                                                            </div>
                                                                            <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                                                                                Yearly income of the Family from all sources (in RS.): <span style="color: #ff3333">*</span>
                                                                                <asp:TextBox ID="txtincome" runat="server" oncut="return false" onpaste="return false" autocomplete="off" oncopy="return false" onkeypress="return num(event)" MaxLength="10" CssClass="form-control"></asp:TextBox>
                                                                            </div>
                                                                        </div>
                                                                        <br />
                                                                        <div class="row">
                                                                            <div class="col-lg-2 col-md-2 col-sm-12 col-xs-12">
                                                                                Student Aadhar No<span style="color: #ff3333">*</span>
                                                                                <asp:TextBox ID="txt_aadhar" autocomplete="off" onKeyPress="return OnlyNum(event)" runat="server" MaxLength="12" CssClass="form-control" oncut="return false" onpaste="return false" oncopy="return false"></asp:TextBox>
                                                                            </div>
                                                                            <div class="col-lg-2 col-md-2 col-sm-12 col-xs-12">
                                                                                DTE/ARA Application ID<span style="color: #ff3333">*</span>
                                                                                <asp:TextBox ID="txt_dte_application" autocomplete="off" onKeyPress="return allow(event)" runat="server" MaxLength="20" CssClass="form-control" oncut="return false" onpaste="return false" oncopy="return false"></asp:TextBox>
                                                                            </div>
                                                                            <div class="col-lg-2 col-md-2 col-sm-12 col-xs-12">
                                                                                Minority
                         <asp:DropDownList ID="ddl_minority" runat="server" CssClass="form-control">
                             <asp:ListItem Value=" ">--Select--</asp:ListItem>
                             <asp:ListItem Value="Muslim">Muslim</asp:ListItem>
                             <asp:ListItem Value="Jain">Jain</asp:ListItem>
                             <asp:ListItem Value="Parsi">Parsi</asp:ListItem>
                             <asp:ListItem Value="Catholic">Catholic</asp:ListItem>
                             <asp:ListItem Value="Other">Other</asp:ListItem>
                         </asp:DropDownList>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <br />
                                                            <div class="row">
                                                                <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12">
                                                                </div>
                                                                <div class="col-lg-2 col-md-2 col-sm-12 col-xs-12">
                                                                    <asp:Button ID="btnupdt5" runat="server" Text="Update" CssClass="form-control text-center btn btn-primary" OnClick="btnupdt5_Click" />
                                                                </div>
                                                                <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12">
                                                                </div>
                                                            </div>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
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

    <script>
        $(document).ready(function () {
            datepic();
        });
        function datepic() {
            $('[id*=dob]').datetimepicker(
                {
                    changeMonth: false,
                    changeYear: false,
                    timepicker: false,
                    format: 'd/m/Y',
                    viewMode: "months",
                    minViewMode: "months",
                }
            );
        }


        function allowOnlyLetters(e, t) {
            if (window.event) {
                var charCode = window.event.keyCode;
            }
            else if (e) {
                var charCode = e.which;
            }
            else { return true; }
            if ((charCode > 64 && charCode < 91) || (charCode > 96 && charCode < 123) || charCode == 32 || charCode == 39)
                return true;
            else {
                return false;
            }
        }

        function allowOnlyLettersnocoma(e, t) {
            if (window.event) {
                var charCode = window.event.keyCode;
            }
            else if (e) {
                var charCode = e.which;
            }
            else { return true; }
            if ((charCode > 64 && charCode < 91) || (charCode > 96 && charCode < 123) || charCode == 32)
                return true;
            else {
                return false;
            }
        }

        function allowonlynumbers(m, n) {
            if (window.event) {
                var phn = window.event.keyCode;
            }
            else if (m) {
                var phn = m.which;
            }
            else { return true; }
            if (phn > 47 && phn < 58)
                return true;
            else {
                return false;
            }
        }

        function allowonlynumbersdot(m, n) {
            if (window.event) {
                var phn = window.event.keyCode;
            }
            else if (m) {
                var phn = m.which;
            }
            else { return true; }
            if (phn > 47 && phn < 58 || phn == 46)
                return true;
            else {
                return false;
            }
        }

        function allowaddress(e, t) {
            if (window.event) {
                var charCode = window.event.keyCode;
            }
            else if (e) {
                var charCode = e.which;
            }
            else { return true; }
            if ((charCode > 64 && charCode < 91) || (charCode > 96 && charCode < 123) || charCode == 32 || charCode == 39 || (charCode > 46 && charCode < 58) || charCode == 44 || charCode == 45 || charCode == 40 || charCode == 41 || charCode == 46)
                return true;
            else {
                return false;
            }
        }

        function allow(e, t) {
            if (window.event) {
                var charCode = window.event.keyCode;
            }
            else if (e) {
                var charCode = e.which;
            }
            else { return true; }
            if ((charCode > 64 && charCode < 91) || (charCode > 96 && charCode < 123) || (charCode > 47 && charCode < 58))
                return true;
            else {
                return false;
            }
        }

        function allowpassmnth(e, t) {
            if (window.event) {
                var charCode = window.event.keyCode;
            }
            else if (e) {
                var charCode = e.which;
            }
            else { return true; }
            if ((charCode > 64 && charCode < 91) || (charCode > 96 && charCode < 123) || charCode == 32 || (charCode > 47 && charCode < 58) || charCode == 47)
                return true;
            else {
                return false;
            }
        }

        function checkEmail() {
            var email = document.getElementById('txtEmailID');
            var filter = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
            if (!filter.test(email.value)) {
                alert('Invalid Email Address');
                email.focus;
                return false;
            }
        }

        function alphanum(event) {
            var value = String.fromCharCode(event.which);
            var pattern = new RegExp(/^[A-Za-z0-9]+$/);
            return pattern.test(value);
        }

        function OnlyNum(event) {
            var value = String.fromCharCode(event.which);
            var pattern = new RegExp(/[0-9]/i);
            return pattern.test(value);
        }

        function grade(event) {
            var value = String.fromCharCode(event.which);
            var pattern = new RegExp(/[ABCDEFO abcdefo +]+$/);
            return pattern.test(value);
        }

        function numdate1(e, t) {
            if (window.event) {
                var charCode = window.event.keyCode;
            }
            else if (e) {
                var charCode = e.which;
            }
            else { return true; }
            if ((charCode > 129 && charCode < 0)) {
                return true;
            }
            else {
                return false;
            }
        }
    </script>
</asp:Content>

