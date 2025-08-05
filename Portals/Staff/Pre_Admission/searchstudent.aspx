<%@ Page Title="" Language="C#" MasterPageFile="~/Portals/Staff/MasterPage.master" AutoEventWireup="true" CodeFile="searchstudent.aspx.cs" Inherits="searchstudent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="../../../Assets/js/jquery.datetimepicker.js"></script>
    <link href="../../Assets/css/jquery.datetimepicker.css" rel="stylesheet" />
    <style>
        #btnupdate {
            margin-left: 5px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--<asp:UpdatePanel ID="updatepnl" runat="server">
        <ContentTemplate>--%>
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
                            <div class="panel-body">
                                <%--<div class="container-fluid">--%>
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <div class="container-fluid">
                                            <div class="row">
                                                <div class="col-lg-2">
                                                    Form No
                                            <asp:TextBox ID="txtformno" runat="server" AutoComplete="off" CssClass="form-control" MaxLength="5" onkeypress="return alphanum(event)" />

                                                </div>
                                                <div class="col-lg-2">
                                                    &nbsp
                                                <div>
                                                    <asp:Button ID="btnsearch" runat="server" Text="Search" CssClass="form-control text-center btn btn-primary" OnClick="btnsearch_Click1" />
                                                </div>
                                                </div>

                                                <div class="col-lg-2">
                                                    &nbsp
                                                <div>
                                                    <asp:Button ID="btncancel" runat="server" Text="Cancel" CssClass="form-control text-center btn btn-primary" OnClick="btncancel_Click" />
                                                </div>

                                                </div>

                                            </div>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>

                                <br />

                                <div>
                                    <%--   <asp:UpdatePanel runat="server">
                                                    <ContentTemplate>--%>

                                    <div class="accordion" id="accordion1">

                                        <div class="accordion-item">
                                            <h2 class="accordion-header" id="headingOne">
                                                <%-- <asp:UpdatePanel runat="server">
                                                                <ContentTemplate>--%>


                                                <button class="accordion-button" type="button" data-bs-toggle="collapse" data-bs-target="#collap1" aria-expanded="true" aria-controls="collap1">
                                                    Step - 1 : Basic Details
                                                </button>
                                            </h2>
                                            <div id="collap1"  class="accordion-collapse collapse in show" aria-labelledby="headingOne" data-bs-parent="#accordion1">
                                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                    <ContentTemplate>

                                                        <div class="accordion-body">

                                                            <div class="row">

                                                                <div class="col-lg-2">
                                                                    Last Name
                                                           <asp:TextBox ID="lastname" oncut="return false" onpaste="return false" AutoComplete="off" oncopy="return false" CssClass="form-control" MaxLength="20" onkeypress="return allowOnlyLetters(event,this);" runat="server"></asp:TextBox>
                                                                    <asp:RegularExpressionValidator ID="reg" runat="server" ControlToValidate="lastname" ErrorMessage="
                                         Enter Min 3 Character"
                                                                        ForeColor="Red" ValidationExpression=".{3}.*" Display="Dynamic"></asp:RegularExpressionValidator>
                                                                </div>
                                                                <div class="col-lg-2">
                                                                    First Name<span style="COLOR: #ff3333">*</span>
                                                           <asp:TextBox ID="firstname" oncut="return false" onpaste="return false" AutoComplete="off" oncopy="return false" CssClass="form-control" MaxLength="20" onkeypress="return allowOnlyLetters(event,this);" runat="server"></asp:TextBox>
                                                                    <asp:RegularExpressionValidator ID="reg2" runat="server" ControlToValidate="firstname" ErrorMessage="Enter Min 3 Character" ForeColor="Red" ValidationExpression=".{3}.*" Display="Dynamic"></asp:RegularExpressionValidator>
                                                                </div>
                                                                <div class="col-lg-2">
                                                                    Middle Name<span style="COLOR: #ff3333">*</span>
                                                           <asp:TextBox ID="midname" oncut="return false" onpaste="return false" AutoComplete="off" oncopy="return false" CssClass="form-control" MaxLength="20" onkeypress="return allowOnlyLetters(event,this);" runat="server"></asp:TextBox>
                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="midname" ErrorMessage="Enter Min 3 Character" ForeColor="Red" ValidationExpression=".{3}.*" Display="Dynamic"></asp:RegularExpressionValidator>
                                                                </div>
                                                                <div class="col-lg-2">
                                                                    Mother's Name<span style="COLOR: #ff3333">*</span>
                                                           <asp:TextBox ID="mothername" oncut="return false" onpaste="return false" AutoComplete="off" oncopy="return false" CssClass="form-control" MaxLength="20" onkeypress="return allowOnlyLetters(event,this);" runat="server"></asp:TextBox>
                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="mothername" ErrorMessage="Enter Min 3 Character" ForeColor="Red" ValidationExpression=".{3}.*" Display="Dynamic"></asp:RegularExpressionValidator>
                                                                </div>


                                                                <br />


                                                                <div class="col-lg-2">
                                                                    D.O.B<span style="COLOR: #ff3333">*</span> 
                                                              <asp:TextBox runat="server" ID="dob" CssClass="form-control" MaxLength="20" oncopy="return false" onpaste="return false" oncut="return false" autocomplete="off">                                                                 </asp:TextBox>
                                                                </div>
                                                                <div class="col-lg-2">
                                                                    Email Address<span style="COLOR: #ff3333">*</span> 
                                                           <asp:TextBox ID="emailbox" CssClass="form-control" TextMode="Email" MaxLength="50" runat="server"></asp:TextBox>
                                                                </div>


                                                                <br />

                                                                <div class="row">
                                                                    <div class="col-lg-2">
                                                                        Mobile Number<span style="COLOR: #ff3333">*</span>
                                                           <asp:TextBox ID="mobno" MaxLength="10" oncopy="return false" onpaste="return false" oncut="return false" autocomplete="off" CssClass="form-control" onkeypress="return allowonlynumbers(event,this);" runat="server"></asp:TextBox>
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="mobno" ErrorMessage="Invalid Mobile No." ForeColor="Red" ValidationExpression=".{10}.*" Display="Dynamic"></asp:RegularExpressionValidator>
                                                                    </div>
                                                                    <div class="col-lg-2">
                                                                        Other Contact No<span style="COLOR: #ff3333">*</span>
                                                           <asp:TextBox ID="othercont" CssClass="form-control" MaxLength="10" oncut="return false" onpaste="return false" AutoComplete="off" oncopy="return false" onkeypress="return allowonlynumbers(event,this);" runat="server"></asp:TextBox>
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="othercont" ErrorMessage="Invalid Mobile No." ForeColor="Red" ValidationExpression=".{10}.*" Display="Dynamic"></asp:RegularExpressionValidator>
                                                                    </div>
                                                                </div>

                                                                <br />

                                                                <div class="row">
                                                                    <div class="col-lg-5">
                                                                    </div>
                                                                    <div class="col-lg-2">
                                                                        <asp:Button ID="btnupdate" runat="server" Text="Update" CssClass="form-control text-center btn btn-primary" OnClick="btnupdate_Click" />
                                                                    </div>
                                                                    <div class="col-lg-5">
                                                                    </div>
                                                                </div>


                                                            </div>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>

                                            </div>
                                            <%--    </ContentTemplate>
                                                            </asp:UpdatePanel>--%>
                                        </div>
                                    </div>
                                    <%--     <asp:UpdatePanel runat="server">
                                                        <ContentTemplate>--%>

                                    <div class="accordion-item">
                                        <h2 class="accordion-header" id="headingTwo">
                                            <button class="accordion-button" type="button" data-bs-toggle="collapse" data-bs-target="#collap2" aria-expanded="false" aria-controls="collap2">
                                                Step - 2 : Personal Details
                                            </button>
                                        </h2>
                                        <div id="collap2" class="accordion-collapse collapse" aria-labelledby="headingTwo" data-bs-parent="#accordionExample">
                                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                <ContentTemplate>
                                                    <div class="accordion-body">
                                                        <div class="row">

                                                            <div class="col-lg-2">
                                                                Gender<span style="COLOR: #ff3333">*</span> 
                                                                <asp:RadioButtonList ID="rdgender" runat="server" CssClass="form-control" RepeatDirection="Horizontal">
                                                                    <asp:ListItem Text="Male" Value="1" />
                                                                    <asp:ListItem Text="Female" Value="0" />
                                                                </asp:RadioButtonList>
                                                            </div>

                                                            <div class="col-lg-2">
                                                                Blood Group :
                                                                   <asp:DropDownList ID="ddlblood" runat="server" CssClass="form-select">
                                                                       <asp:ListItem Text="--Select--" Value="0">--Select--</asp:ListItem>
                                                                       <asp:ListItem Text="A+ve" Value="1"> </asp:ListItem>
                                                                       <asp:ListItem Text="A-ve" Value="2"> </asp:ListItem>
                                                                       <asp:ListItem Text="B+ve" Value="3"> </asp:ListItem>
                                                                       <asp:ListItem Text="B-ve" Value="4"> </asp:ListItem>
                                                                       <asp:ListItem Text="AB+ve" Value="5">  </asp:ListItem>
                                                                       <asp:ListItem Text="AB-ve" Value="6">  </asp:ListItem>
                                                                       <asp:ListItem Text="O+ve" Value="7"> </asp:ListItem>
                                                                       <asp:ListItem Text=" O-ve" Value="8"> </asp:ListItem>
                                                                   </asp:DropDownList>
                                                            </div>

                                                            <div class="col-lg-2">
                                                                Place Of Birth<span style="COLOR: #ff3333">*</span> 
                                                           <asp:TextBox ID="birthplace" oncopy="return false" AutoComplete="off" oncut="return paste" onpaste="return false" MaxLength="150" CssClass="form-control" onkeypress="return allowOnlyLetters(event,this);" runat="server"></asp:TextBox>
                                                            </div>
                                                            <%-- <div class="col-lg-2">
                                                                AadharCard No :
                                                           <asp:TextBox ID="aadharno" CssClass="form-control" runat="server"></asp:TextBox>
                                                            </div>--%>

                                                            <div class="col-lg-2">
                                                                City <span style="COLOR: #ff3333">*</span>  
                                                           <asp:TextBox ID="citytxtbox" CssClass="form-control" oncopy="return false" AutoComplete="off" oncut="return paste" onpaste="return false" MaxLength="150" onkeypress="return allowOnlyLetters(event,this);" runat="server"></asp:TextBox>
                                                            </div>
                                                            <div class="col-lg-2">
                                                                Marital Status<span style="COLOR: #ff3333">*</span> 
                                                          <asp:DropDownList ID="ddlmarrystatus" runat="server" CssClass="form-select">
                                                              <asp:ListItem Selected="True">--Select--</asp:ListItem>
                                                              <asp:ListItem Value="0"> UNMARRIED </asp:ListItem>
                                                              <asp:ListItem Value="1"> MARRIED </asp:ListItem>
                                                          </asp:DropDownList>
                                                            </div>

                                                            <div class="col-lg-2">
                                                                Domiciled In :
                                                           <asp:TextBox ID="domicileid" oncopy="return false" oncut="return paste" onpaste="return false" AutoComplete="off" CssClass="form-control" MaxLength="80" onkeypress="return allowOnlyLetters(event,this);" runat="server"></asp:TextBox>
                                                            </div>
                                                        </div>

                                                        <br />
                                                        <div class="row">

                                                            <div class="col-lg-2">
                                                                Flat No / Bldg <span style="COLOR: #ff3333">*</span> 
                                                           <asp:TextBox ID="flattxtbox" oncopy="return false" oncut="return paste" onpaste="return false" AutoComplete="off" CssClass="form-control" MaxLength="80" onkeypress="return allowaddress(event,this);" runat="server"></asp:TextBox>
                                                            </div>

                                                            <div class="col-lg-2">
                                                                Area <span style="COLOR: #ff3333">*</span> 
                                                           <asp:TextBox ID="areatxtbox" AutoComplete="off" oncopy="return false" oncut="return paste" onpaste="return false" CssClass="form-control" MaxLength="80" onkeypress="return allowaddress(event,this);" runat="server"></asp:TextBox>
                                                            </div>

                                                            <div class="col-lg-2">
                                                                Street <span style="COLOR: #ff3333">*</span> 
                                                           <asp:TextBox ID="streettxtbox" AutoComplete="off" oncopy="return false" oncut="return paste" onpaste="return false" CssClass="form-control" MaxLength="80" onkeypress="return allowaddress(event,this);" runat="server"></asp:TextBox>
                                                            </div>

                                                            <div class="col-lg-2">
                                                                Pincode <span style="COLOR: #ff3333">*</span> 
                                                           <asp:TextBox ID="pintxtbox" autocomplete="off" oncopy="return false" oncut="return paste" onpaste="return false" CssClass="form-control" MaxLength="6" onkeypress="return allowonlynumbers(event,this);" runat="server"></asp:TextBox>
                                                                 <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="pintxtbox" ErrorMessage="Invalid Pincode" Display="Dynamic" ValidationExpression=".{6}.*" ForeColor="Red"></asp:RegularExpressionValidator>
                                                            </div>

                                                            <div class="col-lg-2">
                                                                State<span style="COLOR: #ff3333">*</span> 
                                                           <asp:TextBox ID="statetxtbox" AutoComplete="off" oncut="return false" onpaste="return false" oncopy="return false" CssClass="form-control" MaxLength="100" onkeypress="return allowOnlyLetters(event,this);" runat="server"></asp:TextBox>
                                                            </div>

                                                        </div>

                                                        <br />

                                                        <div class="row">
                                                            <div class="col-lg-5">
                                                            </div>
                                                            <div class="col-lg-2">
                                                                <asp:Button ID="btnupdate1" runat="server" Text="Update" CssClass="form-control text-center btn btn-primary" OnClick="btnupdate1_Click1" />
                                                            </div>
                                                            <div class="col-lg-5">
                                                            </div>
                                                        </div>

                                                    </div>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                    <%--       
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>--%>
                                    <%-- <asp:UpdatePanel runat="server">
                                                        <ContentTemplate>--%>


                                    <div class="accordion-item">
                                        <h2 class="accordion-header" id="headingThree">
                                            <button class="accordion-button" type="button" data-bs-toggle="collapse" data-bs-target="#collap3" aria-expanded="false" aria-controls="collap3">
                                                Step - 3 : Educational Details
                                            </button>
                                        </h2>
                                        <div id="collap3" class="accordion-collapse collapse" aria-labelledby="headingThree" data-bs-parent="#accordionExample">
                                            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                <ContentTemplate>
                                                    <div class="accordion-body">

                                                        <div class="row">
                                                            <div class="col-lg-6">
                                                                <div class="card">
                                                                    <div class="card-header bg-primary" style="font-weight: 600; color: white">S.S.C </div>
                                                                    <div class="card-body">

                                                                        <div class="row">
                                                                            <div class="col-lg-3">
                                                                                State<span style="COLOR: #ff3333">*</span>
                                                           <asp:DropDownList ID="ddlstate" runat="server" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlstate_SelectedIndexChanged">
                                                               <%--<asp:ListItem Selected="True">--Select--</asp:ListItem>
                                                               <asp:ListItem> Maharashtra </asp:ListItem>
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

                                                                            <div class="col-lg-3">
                                                                                Board <span style="COLOR: #ff3333">*</span>
                                                           <asp:DropDownList ID="ddlboard" runat="server" CssClass="form-select">
                                                               <%--<asp:ListItem Selected="True">--Select--</asp:ListItem>
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

                                                                            <div class="col-lg-3">
                                                                                School Name<span style="COLOR: #ff3333">*</span>
                                                           <asp:TextBox ID="schoolname" CssClass="form-control" MaxLength="100" oncut="return false" onpaste="return false" oncopy="return false" autocomplete="off" onkeypress="return allowOnlyLetters(event,this);" runat="server"></asp:TextBox>
                                                                            </div>

                                                                            <div class="col-lg-3">
                                                                                School place<span style="COLOR: #ff3333">*</span>
                                                           <asp:TextBox ID="schoolplace" CssClass="form-control" MaxLength="100" oncut="return false" onpaste="return false" oncopy="return false" autocomplete="off" onkeypress="return allowaddress(event,this);" runat="server"></asp:TextBox>
                                                                            </div>
                                                                        </div>

                                                                        <br />

                                                                        <div class="row">

                                                                            <div class="col-lg-3">
                                                                                First Attempt<span style="COLOR: #ff3333">*</span>
                                                           <asp:RadioButtonList ID="rdattempt" runat="server" CssClass="form-control" RepeatDirection="Horizontal">
                                                               <asp:ListItem Text="Yes" Value="1" />
                                                               <asp:ListItem Text="No" Value="0" />
                                                           </asp:RadioButtonList>
                                                                            </div>

                                                                            <div class="col-lg-3">
                                                                                Passing Year<span style="COLOR: #ff3333">*</span>
                                                           <asp:DropDownList ID="ddlpassyear" runat="server" CssClass="form-select">
                                                               <asp:ListItem value="0">--Select--</asp:ListItem>
                                                               <asp:ListItem value="2023"> 2023 </asp:ListItem>
                                                               <asp:ListItem value="2022"> 2022 </asp:ListItem>
                                                               <asp:ListItem value="2021"> 2021 </asp:ListItem>
                                                               <asp:ListItem value="2020"> 2020 </asp:ListItem>
                                                               <asp:ListItem value="2019"> 2019 </asp:ListItem>
                                                               <asp:ListItem value="2018"> 2018 </asp:ListItem>
                                                               <asp:ListItem value="2017"> 2017 </asp:ListItem>
                                                               <asp:ListItem value="2016"> 2016 </asp:ListItem>
                                                               <asp:ListItem value="2015"> 2015 </asp:ListItem>
                                                               <asp:ListItem value="2014"> 2014 </asp:ListItem>
                                                               <asp:ListItem value="2013"> 2013 </asp:ListItem>
                                                               <asp:ListItem value="2012"> 2012 </asp:ListItem>
                                                               <asp:ListItem value="2011"> 2011 </asp:ListItem>
                                                               <asp:ListItem value="2010"> 2010 </asp:ListItem>
                                                               <asp:ListItem value="2009"> 2009 </asp:ListItem>
                                                               <asp:ListItem value="2008"> 2008 </asp:ListItem>
                                                               <asp:ListItem value="2007"> 2007 </asp:ListItem>
                                                               <asp:ListItem value="2006"> 2006 </asp:ListItem>
                                                               <asp:ListItem value="2005"> 2005 </asp:ListItem>
                                                               <asp:ListItem value="2004"> 2004 </asp:ListItem>
                                                               <asp:ListItem value="2003"> 2003 </asp:ListItem>
                                                               <asp:ListItem value="2002"> 2002 </asp:ListItem>
                                                               <asp:ListItem value="2001"> 2001  </asp:ListItem>
                                                               <asp:ListItem value="2000"> 2000 </asp:ListItem>
                                                               <asp:ListItem value="1999"> 1999  </asp:ListItem>
                                                               <asp:ListItem value="1998"> 1998  </asp:ListItem>
                                                               <asp:ListItem value="1997"> 1997  </asp:ListItem>
                                                               <asp:ListItem value="1996"> 1996 </asp:ListItem>
                                                               <asp:ListItem value="1995"> 1995 </asp:ListItem>
                                                               <asp:ListItem value="1994"> 1994 </asp:ListItem>
                                                               <asp:ListItem value="1993"> 1993 </asp:ListItem>
                                                               <asp:ListItem value="1992"> 1992 </asp:ListItem>
                                                               <asp:ListItem value="1991"> 1991  </asp:ListItem>
                                                               <asp:ListItem value="1990"> 1990 </asp:ListItem>
                                                           </asp:DropDownList>
                                                                            </div>

                                                                            <div class="col-lg-3">
                                                                                Passing Month <span style="COLOR: #ff3333">*</span>
                                                           <asp:DropDownList ID="ddlpassmth" runat="server" CssClass="form-select">
                                                               <asp:ListItem  Value="0">--Select--</asp:ListItem>
                                                               <asp:ListItem Value="Jan"> Jan </asp:ListItem>
                                                               <asp:ListItem Value="Feb"> Feb </asp:ListItem>
                                                               <asp:ListItem Value="Mar"> Mar </asp:ListItem>
                                                               <asp:ListItem Value="Apr"> Apr </asp:ListItem>
                                                               <asp:ListItem Value="May"> May </asp:ListItem>
                                                               <asp:ListItem Value="Jun"> Jun </asp:ListItem>
                                                               <asp:ListItem Value="Jul"> Jul </asp:ListItem>
                                                               <asp:ListItem Value="Aug"> Aug </asp:ListItem>
                                                               <asp:ListItem Value="Sept"> Sept </asp:ListItem>
                                                               <asp:ListItem Value="Oct"> Oct </asp:ListItem>
                                                               <asp:ListItem Value="Nov"> Nov </asp:ListItem>
                                                               <asp:ListItem Value="Dec"> Dec </asp:ListItem>
                                                           </asp:DropDownList>
                                                                            </div>

                                                                            <div class="col-lg-3">
                                                                                Seat No<span style="COLOR: #ff3333">*</span>
                                                           <asp:TextBox ID="seatno" CssClass="form-control" autocomplete="off" oncut="return false" onpaste="return false" oncopy="return false" MaxLength="10" onkeypress="return allow(event,this);" runat="server"></asp:TextBox>
                                                                                                                                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="seatno" ErrorMessage="Seat No. Must Be Of 7 Digit" Display="Dynamic" ValidationExpression=".{7}.*" ForeColor="Red"></asp:RegularExpressionValidator>

                                                                            </div>

                                                                        </div>

                                                                        <br />

                                                                        <div class="row">

                                                                            <div class="col-lg-4">
                                                                                Total Marks Obtained<span style="COLOR: #ff3333">*</span>
                                                           <asp:TextBox ID="mksobt" CssClass="form-control" autocomplete="off" oncut="return false" onpaste="return false" oncopy="return false" MaxLength="3" onkeypress="return allowonlynumbers(event,this);" runat="server"></asp:TextBox>
                                                                            </div>

                                                                            <div class="col-lg-4">
                                                                                Out of Marks<span style="COLOR: #ff3333">*</span>
                                                           <asp:TextBox ID="outofmks" autocomplete="off" oncut="return false" onpaste="return false" oncopy="return false" CssClass="form-control" MaxLength="3" onkeypress="return allowonlynumbers(event,this);" runat="server"></asp:TextBox>
                                                                            </div>

                                                                            <div class="col-lg-4">
                                                                                Grade Obtained<span style="COLOR: #ff3333">*</span>
                                                           <asp:TextBox ID="gradeobt" style="text-transform:uppercase" CssClass="form-control" MaxLength="2" autocomplete="off" oncut="return false" onpaste="return false" oncopy="return false" onkeypress="return grade(event)" runat="server"></asp:TextBox>
                                                                                <%-- onkeypress="return allowgrade(event,this);" --%>
                                                                            </div>



                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                            <div class="col-lg-6">
                                                                <div class="card">
                                                                    <div class="card-header bg-primary" style="font-weight: 600; color: white">H.S.C </div>
                                                                    <div class="card-body">

                                                                        <div class="row">
                                                                            <div class="col-lg-3">
                                                                                State <span style="COLOR: #ff3333">*</span>
                                                           <asp:DropDownList ID="ddlstate1" runat="server" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlstate1_SelectedIndexChanged">
                                                               <%--<asp:ListItem Selected="True" Value="0">--Select--</asp:ListItem>--%>
                                                             <%--  <asp:ListItem Value="MAHARASHTRA"> Maharashtra </asp:ListItem>
<asp:ListItem Value="ANDAMAN AND NICOBAR"> Andaman and Nicobar </asp:ListItem>
<asp:ListItem Value="ANDHRA PRADESH"> Andhra Pradesh </asp:ListItem>
<asp:ListItem Value="ARUNACHAL PRADESH"> Arunachal Pradesh </asp:ListItem>
<asp:ListItem Value="ASSAM"> Assam </asp:ListItem>
<asp:ListItem Value="BIHAR"> Bihar </asp:ListItem>
<asp:ListItem Value="CHANDIGARH"> Chandigarh </asp:ListItem>
<asp:ListItem Value="CHATTISGARH"> Chattisgarh </asp:ListItem>
<asp:ListItem Value="DADRA AND NAGAR HAVELI"> Dadra and Nagar Haveli </asp:ListItem>
<asp:ListItem Value="DAMAN AND DIU"> Daman and Diu </asp:ListItem>
<asp:ListItem Value="DELHI"> Delhi </asp:ListItem>
<asp:ListItem Value="GOA"> Goa </asp:ListItem>
<asp:ListItem Value="GUJARAT"> Gujarat </asp:ListItem>
<asp:ListItem Value="HARYANA"> Haryana </asp:ListItem>
<asp:ListItem Value="HIMACHAL PRADESH"> Himachal Pradesh </asp:ListItem>
<asp:ListItem Value="JAMMU AND KASHMIR"> Jammu and Kashmir </asp:ListItem>
<asp:ListItem Value="JHARKHAND"> Jharkhand </asp:ListItem>
<asp:ListItem Value="KARNATAKA"> Karnataka </asp:ListItem>
<asp:ListItem Value="KERALA"> Kerala </asp:ListItem>
<asp:ListItem Value="LAKSHADWEEP"> Lakshadweep </asp:ListItem>
<asp:ListItem Value="MADHYA PRADESH"> Madhya Pradesh </asp:ListItem>
<asp:ListItem Value="MANIPUR"> Manipur </asp:ListItem>
<asp:ListItem Value="MEGHALAYA"> Meghalaya </asp:ListItem>
<asp:ListItem Value="MIZORAM"> Mizoram </asp:ListItem>
<asp:ListItem Value="NAGALAND"> Nagaland </asp:ListItem>
<asp:ListItem Value="ORISSA"> Orissa </asp:ListItem>
<asp:ListItem Value="PONDICHERRY"> Pondicherry </asp:ListItem>
<asp:ListItem Value="PUNJAB"> Punjab </asp:ListItem>
<asp:ListItem Value="RAJASTHAN"> Rajasthan </asp:ListItem>
<asp:ListItem Value="SIKKIM"> Sikkim </asp:ListItem>
<asp:ListItem Value="TAMIL NADU"> Tamil Nadu </asp:ListItem>
<asp:ListItem Value="TRIPURA"> Tripura </asp:ListItem>
<asp:ListItem Value="UTTAR PRADESH"> Uttar Pradesh </asp:ListItem>
<asp:ListItem Value="UTTARAKHAND"> Uttarakhand </asp:ListItem>
<asp:ListItem Value="WEST BENGAL"> West Bengal </asp:ListItem>--%>
  
                                                               
                                                               <%--<asp:ListItem Value="Maharashtra"> Maharashtra </asp:ListItem>
                                                               <asp:ListItem Value="Andaman and Nicobar"> Andaman and Nicobar </asp:ListItem>
                                                               <asp:ListItem Value="Andhra Pradesh"> Andhra Pradesh </asp:ListItem>
                                                               <asp:ListItem Value="Arunachal Pradesh"> Arunachal Pradesh </asp:ListItem>
                                                               <asp:ListItem Value="Assam"> Assam </asp:ListItem>
                                                               <asp:ListItem Value="Bihar"> Bihar </asp:ListItem>
                                                               <asp:ListItem Value="Chandigarh"> Chandigarh </asp:ListItem>
                                                               <asp:ListItem Value="Chattisgarh"> Chattisgarh </asp:ListItem>
                                                               <asp:ListItem Value="Dadra and Nagar Haveli"> Dadra and Nagar Haveli </asp:ListItem>
                                                               <asp:ListItem Value="Daman and Diu"> Daman and Diu </asp:ListItem>
                                                               <asp:ListItem Value="Delhi"> Delhi </asp:ListItem>
                                                               <asp:ListItem Value="Goa"> Goa </asp:ListItem>
                                                               <asp:ListItem Value="Gujarat"> Gujarat </asp:ListItem>
                                                               <asp:ListItem Value="Haryana"> Haryana </asp:ListItem>
                                                               <asp:ListItem Value="Himachal Pradesh"> Himachal Pradesh </asp:ListItem>
                                                               <asp:ListItem Value="Jammu and Kashmir"> Jammu and Kashmir </asp:ListItem>
                                                               <asp:ListItem Value="Jharkhand"> Jharkhand </asp:ListItem>
                                                               <asp:ListItem Value="Karnataka"> Karnataka </asp:ListItem>
                                                               <asp:ListItem Value="Kerala"> Kerala </asp:ListItem>
                                                               <asp:ListItem Value="Lakshadweep"> Lakshadweep </asp:ListItem>
                                                               <asp:ListItem Value="Madhya Pradesh"> Madhya Pradesh </asp:ListItem>
                                                               <asp:ListItem Value="Manipur"> Manipur </asp:ListItem>
                                                               <asp:ListItem Value="Meghalaya"> Meghalaya  </asp:ListItem>
                                                               <asp:ListItem Value="Mizoram"> Mizoram  </asp:ListItem>
                                                               <asp:ListItem Value="Nagaland"> Nagaland  </asp:ListItem>
                                                               <asp:ListItem Value="Orissa"> Orissa </asp:ListItem>
                                                               <asp:ListItem Value="Pondicherry"> Pondicherry </asp:ListItem>
                                                               <asp:ListItem Value="Punjab"> Punjab </asp:ListItem>
                                                               <asp:ListItem Value="Rajasthan"> Rajasthan </asp:ListItem>
                                                               <asp:ListItem Value="Sikkim"> Sikkim </asp:ListItem>
                                                               <asp:ListItem Value="Tamil Nadu"> Tamil Nadu </asp:ListItem>
                                                               <asp:ListItem Value="Tripura"> Tripura </asp:ListItem>
                                                               <asp:ListItem Value="Uttar Pradesh"> Uttar Pradesh </asp:ListItem>
                                                               <asp:ListItem Value="Uttarakhand"> Uttarakhand </asp:ListItem>
                                                               <asp:ListItem Value="West Bengal"> West Bengal </asp:ListItem>--%>
                                                           </asp:DropDownList>
                                                                            </div>

                                                                            <div class="col-lg-3">
                                                                                Board <span style="COLOR: #ff3333">*</span>
                                                           <asp:DropDownList ID="ddlboard1" runat="server" CssClass="form-control">
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

                                                                            <div class="col-lg-3">
                                                                                College Name<span style="COLOR: #ff3333">*</span>
                                                           <asp:TextBox ID="colgname" CssClass="form-control" oncut="return false" onpaste="return false" oncopy="return false" autocomplete="off" MaxLength="100" onkeypress="return allowOnlyLetters(event,this);" runat="server"></asp:TextBox>
                                                                            </div>

                                                                            <div class="col-lg-3">
                                                                                College place<span style="COLOR: #ff3333">*</span>
                                                           <asp:TextBox ID="colgplace" CssClass="form-control" autocomplete="off" oncut="return false" onpaste="return false" oncopy="return false" MaxLength="100" onkeypress="return allowaddress(event,this);" runat="server"></asp:TextBox>
                                                                            </div>
                                                                        </div>

                                                                        <br />

                                                                        <div class="row">

                                                                            <div class="col-lg-3">
                                                                                First Attempt<span style="COLOR: #ff3333">*</span>
                                                           <asp:RadioButtonList ID="rdattempt1" runat="server" CssClass="form-control" RepeatDirection="Horizontal">
                                                               <asp:ListItem Text="Yes" Value="1" />
                                                               <asp:ListItem Text="No" Value="0" />
                                                           </asp:RadioButtonList>
                                                                            </div>

                                                                            <div class="col-lg-3">
                                                                                Passing Year<span style="COLOR: #ff3333">*</span>
                                                           <asp:DropDownList ID="ddlpassyear1" runat="server" CssClass="form-select">
                                                               <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                               <asp:ListItem  Value="2025"> 2025 </asp:ListItem>
                                                               <asp:ListItem  Value="2024"> 2024 </asp:ListItem>
                                                               <asp:ListItem  Value="2023"> 2023 </asp:ListItem>
                                                               <asp:ListItem  Value="2022"> 2022 </asp:ListItem>
                                                               <asp:ListItem  Value="2021"> 2021 </asp:ListItem>
                                                               <asp:ListItem  Value="2020"> 2020 </asp:ListItem>
                                                               <asp:ListItem  Value="2019"> 2019 </asp:ListItem>
                                                               <asp:ListItem  Value="2018"> 2018 </asp:ListItem>
                                                               <asp:ListItem  Value="2017"> 2017 </asp:ListItem>
                                                               <asp:ListItem  Value="2016"> 2016 </asp:ListItem>
                                                               <asp:ListItem  Value="2015"> 2015 </asp:ListItem>
                                                               <asp:ListItem  Value="2014"> 2014 </asp:ListItem>
                                                               <asp:ListItem  Value="2013"> 2013 </asp:ListItem>
                                                               <asp:ListItem  Value="2012"> 2012 </asp:ListItem>
                                                               <asp:ListItem  Value="2011"> 2011 </asp:ListItem>
                                                               <asp:ListItem  Value="2010"> 2010 </asp:ListItem>
                                                               <asp:ListItem  Value="2009"> 2009 </asp:ListItem>
                                                               <asp:ListItem  Value="2008"> 2008 </asp:ListItem>
                                                               <asp:ListItem  Value="2007"> 2007 </asp:ListItem>
                                                               <asp:ListItem  Value="2006"> 2006 </asp:ListItem>
                                                               <asp:ListItem  Value="2005"> 2005 </asp:ListItem>
                                                               <asp:ListItem  Value="2004"> 2004 </asp:ListItem>
                                                               <asp:ListItem  Value="2003"> 2003 </asp:ListItem>
                                                               <asp:ListItem  Value="2002"> 2002 </asp:ListItem>
                                                               <asp:ListItem  Value="2001"> 2001  </asp:ListItem>
                                                               <asp:ListItem  Value="2000"> 2000 </asp:ListItem>
                                                               <asp:ListItem  Value="1999"> 1999  </asp:ListItem>
                                                               <asp:ListItem  Value="1998"> 1998  </asp:ListItem>
                                                               <asp:ListItem  Value="1997"> 1997  </asp:ListItem>
                                                               <asp:ListItem  Value="1996"> 1996 </asp:ListItem>
                                                               <asp:ListItem  Value="1995"> 1995 </asp:ListItem>
                                                               <asp:ListItem  Value="1994"> 1994 </asp:ListItem>
                                                               <asp:ListItem  Value="1993"> 1993 </asp:ListItem>
                                                               <asp:ListItem  Value="1992"> 1992 </asp:ListItem>
                                                               <asp:ListItem  Value="1991"> 1991  </asp:ListItem>
                                                               <asp:ListItem  Value="1990"> 1990 </asp:ListItem>
                                                           </asp:DropDownList>
                                                                            </div>

                                                                            <div class="col-lg-3">
                                                                                Passing Month<span style="COLOR: #ff3333">*</span>
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
                                                                 <asp:ListItem  Value="0">--Select--</asp:ListItem>
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

                                                                            <div class="col-lg-3">
                                                                                Seat No<span style="COLOR: #ff3333">*</span>
                                                           <asp:TextBox ID="seatno1" oncut="return false" onpaste="return false" oncopy="return false" CssClass="form-control" MaxLength="10" autocomplete="off" onkeypress="return allow(event,this);" runat="server"></asp:TextBox>
                                                                                
                                                                                                                                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="seatno1" ErrorMessage="Seat No. Must Be Of 7 Digit" Display="Dynamic" ValidationExpression=".{7}.*" ForeColor="Red"></asp:RegularExpressionValidator>
                                                                            </div>

                                                                        </div>

                                                                        <br />

                                                                        <div class="row">

                                                                            <div class="col-lg-4">
                                                                                Total Marks Obtained<span style="COLOR: #ff3333">*</span>
                                                           <asp:TextBox ID="mksobt1" MaxLength="4" oncut="return false" autocomplete="off" onpaste="return false" oncopy="return false" CssClass="form-control" onkeypress="return allowonlynumbers(event,this);" runat="server"></asp:TextBox>
                                                                            </div>

                                                                            <div class="col-lg-4">
                                                                                Out of Marks<span style="COLOR: #ff3333">*</span>
                                                           <asp:TextBox ID="outofmks1" MaxLength="4" autocomplete="off" oncut="return false" onpaste="return false" oncopy="return false" CssClass="form-control" onkeypress="return allowonlynumbers(event,this);" runat="server"></asp:TextBox>
                                                                            </div>

                                                                            <div class="col-lg-4">
                                                                                Grade Obtained<span style="COLOR: #ff3333">*</span>
                                                           <asp:TextBox ID="gradeobt1"  style="text-transform:uppercase" onkeypress="return grade(event)" autocomplete="off"  oncut="return false" onpaste="return false" oncopy="return false" CssClass="form-control" MaxLength="2" runat="server"></asp:TextBox>
                                                                                <%--  onkeypress="return allowgrade(event,this);"--%>
                                                                            </div>



                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>

                                                        <br />

                                                        <div class="row">
                                                            <div class="col-lg-5">
                                                            </div>
                                                            <div class="col-lg-2">
                                                                <asp:Button ID="btnupdate2" runat="server" Text="Update" CssClass="form-control text-center btn btn-primary" OnClick="btnupdate2_Click" />
                                                            </div>
                                                            <div class="col-lg-5">
                                                            </div>
                                                        </div>
                                                    </div>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>

                                    <%--  </ContentTemplate>
                                                    </asp:UpdatePanel>--%>


                                    <%--  <asp:UpdatePanel runat="server">
                                                        <ContentTemplate>--%>

                                    <div class="accordion-item">
                                        <h2 class="accordion-header" id="headingFour">
                                            <button class="accordion-button" type="button" data-bs-toggle="collapse" data-bs-target="#collap4" aria-expanded="false" aria-controls="collap4">
                                                Step - 4 : Family Details
                                            </button>
                                        </h2>
                                        <div id="collap4" class="accordion-collapse collapse" aria-labelledby="headingFour" data-bs-parent="#accordionExample">
                                            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                <ContentTemplate>
                                                    <div class="accordion-body">

                                                        <div class="row">
                                                            <div class="col-lg-6">
                                                                <div class="card">
                                                                    <div class="card-header" style="font-weight: 500; background-color: #0d6efd; color: white">Father's Details : </div>
                                                                    <div class="card-body">

                                                                        <div class="row">
                                                                            <div class="col-lg-3">
                                                                                Father's Name <span style="COLOR: #ff3333">*</span>
                                                                     <asp:TextBox ID="fathername" CssClass="form-control" MaxLength="25" oncut="return false" onpaste="return false" oncopy="return false" onkeypress="return allowOnlyLetters(event,this);" runat="server"></asp:TextBox>
                                                                            </div>

                                                                            <div class="col-lg-3">
                                                                                Father's Age :
                                                           <asp:TextBox ID="fage" oncut="return false" onpaste="return false" oncopy="return false" CssClass="form-control" MaxLength="2" onkeypress="return allowonlynumbers(event,this);" runat="server"></asp:TextBox>
                                                                            </div>

                                                                            <div class="col-lg-3">
                                                                                Email ID :
                                                           <asp:TextBox ID="fmail" CssClass="form-control" MaxLength="80" TextMode="Email" onkeypress="return checkEmail(event)" oncut="return false" onpaste="return false" oncopy="return false" runat="server"></asp:TextBox>
                                                                            </div>

                                                                            <div class="col-lg-3">
                                                                                Contact No<span style="COLOR: #ff3333">*</span>
                                                             <asp:TextBox ID="fcontact" CssClass="form-control" MaxLength="10" onkeypress="return allowonlynumbers(event,this);" runat="server" oncut="return false" onpaste="return false" oncopy="return false"></asp:TextBox>
                                                                            </div>
                                                                        </div>

                                                                        <br />

                                                                        <div class="row">

                                                                            <div class="col-lg-3">
                                                                                Qualification
                                                         <asp:TextBox ID="fquali" oncut="return false" onpaste="return false" oncopy="return false" CssClass="form-control" MaxLength="80" onkeypress="return allow(event,this);" runat="server"></asp:TextBox>
                                                                            </div>

                                                                            <div class="col-lg-3">
                                                                                <asp:Label runat="server" Text="">Occupation<span style="COLOR: #ff3333">*</span></asp:Label>
                                                                                <asp:DropDownList ID="focupation" runat="server" CssClass="form-select">
                                                                                    <asp:ListItem  Value="0">--Select--</asp:ListItem>
                                                                                    <asp:ListItem Value="SERVICE" Text="Service"></asp:ListItem>
<asp:ListItem Value="BUSINESS" Text="Business"></asp:ListItem>
<asp:ListItem Value="PROFESSIONAL" Text="Professional"></asp:ListItem>
<asp:ListItem Value="FARMER" Text="Farmer"></asp:ListItem>
<asp:ListItem Value="LABOURER" Text="Labourer"></asp:ListItem>
<asp:ListItem Value="RETIRED" Text="Retired"></asp:ListItem>
<asp:ListItem Value="OTHER" Text="Other"></asp:ListItem>

                                                                                </asp:DropDownList>
                                                                            </div>

                                                                            <div class="col-lg-3">
                                                                                Designation:
                                                           <asp:TextBox ID="fdesg" CssClass="form-control" MaxLength="80" oncut="return false" onpaste="return false" oncopy="return false" onkeypress="return allowOnlyLetters(event,this);" runat="server"></asp:TextBox>
                                                                            </div>

                                                                            <div class="col-lg-3">
                                                                                Office Address :
                                                           <asp:TextBox ID="fadd" CssClass="form-control" onkeypress="return allowaddress(event,this);" oncut="return false" MaxLength="80" onpaste="return false" oncopy="return false" runat="server"></asp:TextBox>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                            <div class="col-lg-6">
                                                                <div class="card">
                                                                    <div class="card-header bg-primary" style="font-weight: 500; background-color: #0d6efd; color: white">Mother's Details : </div>
                                                                    <div class="card-body">

                                                                        <div class="row">
                                                                            <div class="col-lg-3">
                                                                                Mother's Name<span style="COLOR: #ff3333">*</span>
                                                                     <asp:TextBox ID="mname" CssClass="form-control" MaxLength="25" onkeypress="return allowOnlyLetters(event,this);" runat="server" oncut="return false" onpaste="return false" oncopy="return false"></asp:TextBox>
                                                                            </div>

                                                                            <div class="col-lg-3">
                                                                                Mother's Age :
                                                           <asp:TextBox ID="mage" CssClass="form-control" MaxLength="2" oncut="return false" onpaste="return false" oncopy="return false" onkeypress="return allowonlynumbers(event,this);" runat="server"></asp:TextBox>
                                                                            </div>

                                                                            <div class="col-lg-3">
                                                                                Email ID :
                                                           <asp:TextBox ID="mmail" CssClass="form-control" TextMode="Email" oncut="return false" MaxLength="80" onpaste="return false" oncopy="return false" runat="server"></asp:TextBox>
                                                                            </div>

                                                                            <div class="col-lg-3">
                                                                                Contact No<span style="COLOR: #ff3333">*</span>
                                                             <asp:TextBox ID="mcontact" CssClass="form-control" MaxLength="10" onkeypress="return allowonlynumbers(event,this);" oncut="return false" onpaste="return false" oncopy="return false" runat="server"></asp:TextBox>
                                                                            </div>
                                                                        </div>

                                                                        <br />

                                                                        <div class="row">

                                                                            <div class="col-lg-3">
                                                                                Qualification
                                                         <asp:TextBox ID="mquali" CssClass="form-control" oncut="return false" onpaste="return false" oncopy="return false" MaxLength="80" onkeypress="return allow(event,this);" runat="server"></asp:TextBox>
                                                                            </div>

                                                                            <div class="col-lg-3">
                                                                                Occupation <span style="COLOR: #ff3333">*</span>
                                                           <asp:DropDownList ID="Moccupation" runat="server" CssClass="form-select">
                                                               <asp:ListItem  Value="0">--Select--</asp:ListItem>
                                                              <asp:ListItem Value="SERVICE">Service</asp:ListItem>
<asp:ListItem Value="BUSINESS">Business</asp:ListItem>
<asp:ListItem Value="PROFESSIONAL">Professional</asp:ListItem>
<asp:ListItem Value="FARMER">Farmer</asp:ListItem>
<asp:ListItem Value="LABOURER">Labourer</asp:ListItem>
<asp:ListItem Value="RETIRED">Retired</asp:ListItem>
<asp:ListItem Value="HOUSE WIFE">Housewife</asp:ListItem>
<asp:ListItem Value="OTHER">Other</asp:ListItem>

                                                           </asp:DropDownList>
                                                                            </div>

                                                                            <div class="col-lg-3">
                                                                                Designation :
                                                           <asp:TextBox ID="mdesig" oncut="return false" onpaste="return false" oncopy="return false" CssClass="form-control" MaxLength="80" onkeypress="return allowOnlyLetters(event,this);" runat="server"></asp:TextBox>
                                                                            </div>

                                                                            <div class="col-lg-3">
                                                                                Office Address :
                                                           <asp:TextBox ID="Madd" CssClass="form-control" MaxLength="80" oncut="return false" onpaste="return false" oncopy="return false" onkeypress="return allowaddress(event,this);" runat="server"></asp:TextBox>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>

                                                        <br />

                                                        <div class="row">
                                                            <div class="col-lg-5">
                                                            </div>
                                                            <div class="col-lg-2">
                                                                <asp:Button ID="btnupdate3" runat="server" Text="Update" CssClass="form-control text-center btn btn-primary" OnClick="btnupdate3_Click" />
                                                            </div>
                                                            <div class="col-lg-5">
                                                            </div>
                                                        </div>
                                                    </div>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>

                                    <%--</ContentTemplate>
                                                    </asp:UpdatePanel> --%>
                                    <%-- ///////////////////////////////////////////////////////////////////////////////////////////////// --%>
                                    <%--  <asp:UpdatePanel ID="updt5" runat="server">
                                                        <ContentTemplate>--%>
                                    <div class="accordion-item">
                                        <h2 class="accordion-header" id="headingFive">
                                            <button class="accordion-button" type="button" data-bs-toggle="collapse" data-bs-target="#collap5" aria-expanded="false" aria-controls="collap5">
                                                Step - 5 : Other Details
                                            </button>
                                        </h2>
                                        <div id="collap5" class="accordion-collapse collapse" aria-labelledby="headingFive" data-bs-parent="#accordionExample">
                                            <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                                <ContentTemplate>
                                                    <div class="accordion-body">

                                                        <div class="row">

                                                            <div class="col-lg-3">
                                                                Category<span style="COLOR: #ff3333">*</span>
                                                                        <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:DropDownList ID="ddlcat" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlcat_SelectedIndexChanged2">
                                                                                </asp:DropDownList>
                                                                            </ContentTemplate>
                                                                        </asp:UpdatePanel>

                                                            </div>

                                                            <div class="col-lg-3">
                                                                Caste
                                                           <asp:DropDownList ID="ddlcaste" runat="server" OnSelectedIndexChanged="ddlcaste_SelectedIndexChanged" CssClass="form-select">
                                                           </asp:DropDownList>
                                                            </div>

                                                            <div class="col-lg-3">
                                                                Certificate No :
                                                           <asp:TextBox ID="certibox" oncut="return false" MaxLength="80" onpaste="return false" oncopy="return false" CssClass="form-control" runat="server"></asp:TextBox>
                                                            </div>

                                                            <div class="col-lg-3">
                                                                Religion<span style="COLOR: #ff3333">*</span>
                                                           <asp:DropDownList ID="ddlrel" runat="server" CssClass="form-control">
                                                               
                                                           </asp:DropDownList>
                                                            </div>


                                                        </div>


                                                        <div class="row">
                                                            <div class="col-lg-3" style="margin-top: 23px;">
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
                                                            <div class="col-lg-3">
                                                                Proficiency Acquired in extra Curricular Activities 
                                                                        <asp:RadioButtonList ID="ddlProficien" runat="server" CssClass="form-control" AutoPostBack="true" RepeatDirection="Horizontal">

                                                                            <asp:ListItem Text="Yes" Value="1" />
                                                                            <asp:ListItem Text="No" Value="0" />


                                                                        </asp:RadioButtonList>

                                                            </div>
                                                            <div class="col-lg-3" style="margin-top:25px">
                                                                Whether a Member of NCC / NSS
                                                                        <asp:DropDownList ID="ddlnccnss" runat="server" CssClass="form-select" AutoPostBack="true">
                                                                            <asp:ListItem Text="None" Value="0"></asp:ListItem>
                                                                            <asp:ListItem Text="Both" Value="1"></asp:ListItem>
                                                                            <asp:ListItem Text="NCC" Value="2"></asp:ListItem>
                                                                            <asp:ListItem Text="NSS" Value="3"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                            </div>
                                                            <div class="col-lg-3">
                                                                Are you proposed to apply for Scholarship/Freeship * 
                                                      <asp:RadioButtonList ID="rdbscholar" runat="server" CssClass="form-control" RepeatDirection="Horizontal">
                                                          <asp:ListItem Text="Yes" Value="1" />
                                                          <asp:ListItem Text="No" Value="0" />
                                                      </asp:RadioButtonList>
                                                            </div>



                                                        </div>
                                                        <div class="row">

                                                            <div class="card">
                                                                <div class="card-title" style="font-size: 14px">
                                                                    NO. OF PERSONS IN THE FAMILY  *

                                                                </div>
                                                                <div class="card-body" style="padding:0px">
                                                                    <div class="row">
                                                                        <div class="col-lg-2">
                                                                            Earning<span style="COLOR: #ff3333">*</span>
                                                                                      <asp:TextBox ID="txtearn" autocomplete="off" onKeyPress="return OnlyNum(event)"  runat="server" MaxLength="2" CssClass="form-control" oncut="return false" onpaste="return false" oncopy="return false"></asp:TextBox>
                                                                        </div>
                                                                        <div class="col-lg-2">
                                                                            Non-Earning<span style="COLOR: #ff3333">*</span>
                                                                                      <asp:TextBox ID="txtnonear" OnTextChanged="txtnonear_TextChanged"  onKeyPress="return OnlyNum(event)" AutoPostBack="true"  autocomplete="off" MaxLength="2" oncut="return false" onpaste="return false" oncopy="return false" runat="server" CssClass="form-control"></asp:TextBox>
                                                                        </div>
                                                                        <div class="col-lg-2">
                                                                            Total<span style="COLOR: #ff3333">*</span>
                                                                                      <asp:TextBox ID="txttotal" runat="server" autocomplete="off" ReadOnly="true" CssClass="form-control"></asp:TextBox>
                                                                        </div>
                                                                        <div class="col-lg-6">
                                                                            Yearly income of the Family from all sources :(in RS.): <span style="COLOR: #ff3333">*</span>
                                                                                        <asp:TextBox ID="txtincome" runat="server" oncut="return false" onpaste="return false" autocomplete="off" oncopy="return false" onkeypress="return num(event)" MaxLength="10" CssClass="form-control"></asp:TextBox>

                                                                        </div>
                                                                    </div>
                                                                    <div class="row">
                                                                    </div>

                                                                </div>
                                                            </div>

                                                        </div>
                                                        <div class="row">
                                                            <div class="col-lg-5">
                                                            </div>
                                                            <div class="col-lg-2">
                                                                <asp:Button ID="btnupdt5" runat="server" Text="Update" CssClass="form-control text-center btn btn-primary" OnClick="btnupdt5_Click" />
                                                            </div>
                                                            <div class="col-lg-5">
                                                            </div>
                                                        </div>
                                                    </div>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                </div>

                                <%--   </ContentTemplate>
                                                    </asp:UpdatePanel>
                                --%>
                                <%--</div>--%>

                                <%-- </ContentTemplate>
                                                </asp:UpdatePanel>--%>
                            </div>
                        </div>
                    </div>

                </div>

            </div>
        </div>

    </div>

    <%--    </ContentTemplate>
    </asp:UpdatePanel>--%>

    <script>
        function ValidateEmail(mail) {
            if (/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(myForm.emailAddr.value)) {
                return (true)
            }
            alert("Invalid Email Address!")
            return (false)
        }

        $
        function email(event) {
            var value = String.fromCharCode(event.which);
            var pattern = new RegExp(/ ^ [a - zA - Z0 - 9 + _.-] +@[a - zA - Z0 - 9. -]+$/);
            return pattern.test(value);
        }


        function num(event) {
            var value = String.fromCharCode(event.which);
            var pattern = new RegExp(/^[0-9]+$/);
            return pattern.test(value);
        }


        datepic();
        function datepic() {
            $('[id*=dob]').datetimepicker(
                {
                    changeMonth: false,
                    changeYear: false,
                    timepicker: false,
                    format: 'd/m/Y',
                    viewMode: "months",
                    minViewMode: "months",
                    //maxDate: 0
                    maxDate: new Date(2004, 0, 1)

                    //endDate: "+0m"
                });
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

        function isNumber(evt) {
            evt = (evt) ? evt : window.event;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode < 48 && charCode > 57) {

                return false;
            }
            else {

                return true;
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

        function allowaddress(e, t) {
            if (window.event) {
                var charCode = window.event.keyCode;
            }
            else if (e) {
                var charCode = e.which;
            }
            else { return true; }
            if ((charCode > 64 && charCode < 91) || (charCode > 96 && charCode < 123) || charCode == 32 || charCode == 39 || (charCode > 46 && charCode < 58) || charCode == 44 || charCode == 45 || charCode == 40 || charCode == 41)
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
            if ((charCode > 64 && charCode < 91) || (charCode > 96 && charCode < 123) || charCode == 32 || charCode == 39 || (charCode > 47 && charCode < 58))
                return true;
            else {
                return false;
            }
        }

        function allowgrade(e, t) {
            if (window.event) {
                var charCode = window.event.keyCode;
            }
            else if (e) {
                var charCode = e.which;
            }
            else { return true; }
            if ((charCode > 64 && charCode < 91) || (charCode > 96 && charCode < 123))
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

        function notify(msg, type) {
            $.notify(msg, { type: type, animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.2, delay: 0 });
        }


        //function grade(event) {
        //    var value = String.fromCharCode(event.which);
        //    var pattern = new RegExp(/^[A-Z]+$+-/);
        //    return pattern.test(value);
        //}

        function alphanum(event) {
            var value = String.fromCharCode(event.which);
            var pattern = new RegExp(/^[A-Za-z0-9]+$/);
            return pattern.test(value);
        }


        function num(event) {
            var value = String.fromCharCode(event.which);
            var pattern = new RegExp(/^[0-9]+$/);
            return pattern.test(value);
        }

        function OnlyNum(event) {
            var value = String.fromCharCode(event.which);
            var pattern = new RegExp(/[0-9]/i);
            return pattern.test(value);
        }
        function grade(event) {
            var value = String.fromCharCode(event.which);
            var pattern = new RegExp(/[ABCDEF abcdef +]+$/);
            return pattern.test(value);
        }

    </script>
</asp:Content>

