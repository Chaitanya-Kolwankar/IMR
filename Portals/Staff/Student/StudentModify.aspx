<%@ Page Title="" Language="C#" MasterPageFile="~/Portals/Staff/MasterPage.master" AutoEventWireup="true" CodeFile="StudentModify.aspx.cs" Inherits="Portals_Staff_Student_StudentModify" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../../../Assets/css/style.css" rel="stylesheet" />
    <link href="../../../Assets/css/jquery.datetimepicker.css" rel="stylesheet" />

    <script src="../../../Assets/js/jquery.datetimepicker.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.20/js/jquery.dataTables.min.js"></script>
    <link href="https://cdn.datatables.net/1.10.20/css/jquery.dataTables.css" rel="stylesheet" type="text/css" />
    <style>
         input {
            text-transform: uppercase;
        }


        #MODAL_HEAD_TEXT {
            color: #012970;
        }

        table, td, th {
            border: 1px solid #ddd;
            text-align: left;
        }

        .FixedHeader {
            position: sticky;
            font-weight: 100;
            top: 0;
        }

        table {
            border-collapse: collapse;
            width: 100%;
        }

        th, td {
            padding: 8px;
        }

        th {
            color: #293f72;
            font-weight: bold;
        }

        .FixedHeader {
            position: sticky;
            font-weight: 100;
            top: 0;
        }
    </style>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div id="main" class="main">
        <div class="modal fade" id="searchmodal" data-bs-backdrop="static" role="dialog">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header" style="background-color: lightgrey; color: black; font-weight: bold;">
                        <div class="modal-title" id="#MODAL_HEAD_TEXT">
                            <%--        <p style="color:#012970"></p> --%>     Search By Student ID
                        </div>

                        <asp:Button runat="server" OnClick="modal_cross_Click" type="button" id="modal_cross" class="btn-close" data-bs-dismiss="modal" aria-label="close"/>
                    </div>
                    <div class="modal-body">
                        <div class="container">
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <div class="row">
                                        <div class="col-lg-9">
                                            <label for="inputState" class="form-label">
                                                Enter Student ID
                                            </label>
                                            <asp:TextBox ID="txtstd_id" CssClass="form-control" autocomplete="off" onkeyPress="return OnlyNum(event)" MaxLength="8" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-lg-3">
                                            <asp:LinkButton ID="btnsearch" Text="search by student" runat="server" OnClick="btnsearch_Click" CssClass="btn btn-primary" Style="margin-top: 31px;"><i class="bi bi-search"></i>
                                            </asp:LinkButton>
                                        </div>
                                    </div>
                                    <br />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
            </div>
        </div>
       
        <div class="modal fade" id="img_edit_modal" data-bs-backdrop="static"  role="dialog" >
            <div class="modal-dialog modal-lg">
                <div class="modal-content">
                    <div class="modal-header" style="background-color: lightgrey; color: black; font-weight: bold;">
                        Edit Photo / Signature.
                        <asp:Button type="button" OnClick="modal_cross_img_Click" runat="server" ID="modal_cross_img" class="btn-close imageclear" data-bs-dismiss="modal" aria-label="close"/>
                    </div>
                    <div class="modal-body">
                        <div class="container" style="width: 100%">
                            <div class="row">
                                <div class="col-lg-6" style="border: solid #cdb1b1 1px; text-align: center; padding: 20px;">

                                    <asp:Image ID="edit_image" ImageUrl="~/user.png" runat="server" AlternateText="PHOTO" Height="120px" Width="150px" Style="align-items: center; border: solid BLACK 1px; border-radius: 60px; padding: 5px;" />
                                    <asp:FileUpload runat="server" ClientIDMode="Static" accept=".png,.jpg,.jpeg,.gif" ID="edit_file_upload" onchange="ShowImagePreview(this);" Style="padding: 45px;" />
                                </div>
                                <div class="col-lg-6" style="border: solid #cdb1b1 1px; text-align: center; padding: 20px;">

                                    <asp:Image ID="EDIT_SIGN" ImageUrl="~/sign.jpg" runat="server" AlternateText="SIGN" Height="120px" Width="150px" Style="align-items: center; border: solid BLACK 1px; border-radius: 60px; padding: 5px;" />
                                    <asp:FileUpload runat="server" ID="EDIT_SIGN_FILEUPLOAD" accept=".png,.jpg,.jpeg,.gif" onchange="ShowImagePreview1(this);" Style="padding: 45px;" />


                                </div>

                            </div>
                            <br />
                            <div class="row">
                                <div class="col-lg-4">
                                </div>
                                <div class="col-lg-2">
                                    <asp:Button ID="BTN_SAVE_IMAGE" runat="server" CssClass="btn btn-primary form-control" Text="UPDATE" OnClick="BTN_SAVE_IMAGE_Click" />
                                </div>
                                <div class="col-lg-2">
                                    <asp:Button type="button" runat="server" Text="Close" ID="footermodalclose" OnClick="footermodalclose_Click" class="btn btn-primary form-control imageclear" data-bs-dismiss="modal"/>
                                </div>
                                <div class="col-lg-4">
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>

        <div class="container-fluid">
            <div class="pagetitle " style="font-size: 32px; margin-left: 34px; font-weight: 300; color: #012970;">
            </div>
            <div class="card" style="height: 100%">
                <div class="card-title mx-4" style="font-size: 21px">Student Modify </div>
                <div class="card-body">
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col-md-11">
                                <ul class="nav nav-tabs" id="nav-tab" role="tablist">

                                    <%--<div class="col-lg-1">--%>
                                    <li class="nav-item" role="presentation">

                                        <button class="nav-link active" onclick="oncoursetab()" id="navstudenttab" data-bs-toggle="tab" data-bs-target="#nav-student" type="button" role="tab" aria-controls="nav-student" aria-selected="true">
                                            <p style="font-size: 19px">Student</p>
                                        </button>

                                    </li>
                                    <%--</div>--%>
                                    <%--<div class="col-lg-2">--%>
                                    <li class="nav-item" role="presentation">
                                        <button class="nav-link" id="nav-Personal-tab" data-bs-toggle="tab" data-bs-target="#nav-Personal" type="button" role="tab" aria-controls="nav-Personal" aria-selected="false">
                                            <p style="font-size: 19px">Personal Details</p>
                                        </button>
                                    </li>
                                    <%--</div>--%>
                                    <%--<div class="col-lg-1">--%>
                                    <li class="nav-item" role="presentation">
                                        <button class="nav-link" id="nav-Educational-tab" data-bs-toggle="tab" data-bs-target="#nav-Educational" type="button" role="tab" aria-controls="nav-Educational" aria-selected="false">
                                            <p style="font-size: 19px">Educational </p>
                                        </button>
                                    </li>
                                </ul>
                            </div>
                            <div class="col-md-1">
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <asp:Button runat="server" CssClass="btn btn-primary" data-bs-toggle="modal" data-bs-target="#searchmodal" Text="Edit Student" data-backdrop='false' data-keyboard="false" />

                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="tab-content" id="nav-tabContent">
                            <div class="tab-pane fade show active" id="nav-student" role="tabpanel" aria-labelledby="navstudenttab">
                                <br />
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <div class="card">
                                            <div class="card-header">
                                                Personal Details                             
                                            </div>
                                            <div class="card-body">
                                                <br />
                                                <div class="row">
                                                    <div class="col-lg-9">
                                                        <div class="row">
                                                            <div class="col-lg-2">
                                                                <label for="inputState" class="form-label">
                                                                    Student ID
                                                                </label>
                                                                <asp:TextBox ID="txt_studid" runat="server" CssClass="form-control">
                                                                </asp:TextBox>
                                                            </div>
                                                            <div class="col-lg-2">
                                                                <label for="inputState" class="form-label">
                                                                    Prn no.
                                                                </label>
                                                                <asp:TextBox ID="txt_prn" runat="server" onkeypress="return aplha(event)" oncopy="return false" onpaste="return false" oncut="return false" autocomplete="off" MaxLength="20" CssClass="form-control "></asp:TextBox>
                                                            </div>
                                                            <div class="col-lg-2">
                                                                <label for="inputState" class="form-label">
                                                                    First Name<span style="color: #ff3333; font-weight: 800">*</span>
                                                                </label>
                                                                <asp:TextBox ID="txt_fname" runat="server" oncopy="return false" onpaste="return false" oncut="return false" onkeypress="return ONLY_ALPHA(event)" autocomplete="off" MaxLength="20" CssClass="form-control input">
                                                                </asp:TextBox>
                                                            </div>
                                                            <div class="col-lg-2">
                                                                <label for="inputState" class="form-label">
                                                                    Middle Name<span style="color: #ff3333; font-weight: 800">*</span>
                                                                </label>
                                                                <asp:TextBox ID="txt_mname" runat="server" oncopy="return false" onpaste="return false" oncut="return false" CssClass="input form-control" onkeypress="return ONLY_ALPHA(event)" autocomplete="off" MaxLength="20">
                                                                </asp:TextBox>
                                                            </div>
                                                            <div class="col-lg-2">
                                                                <label for="inputState" class="form-label">
                                                                    Last Name
                                                                </label>
                                                                <asp:TextBox ID="txt_lname" runat="server" oncopy="return false" onpaste="return false" oncut="return false" CssClass="input form-control" onkeypress="return ONLY_ALPHA(event)" autocomplete="off" MaxLength="20">
                                                                </asp:TextBox>
                                                            </div>

                                                            <div class="col-lg-2">
                                                                <label for="inputState" class="form-label">Gender<span style="color: #ff3333; font-weight: 800">*</span></label>
                                                                <br />
                                                                <div class="form-control" id="gen" runat="server" style="height: 40px;">
                                                                    <asp:RadioButton ID="rad_gender" runat="server" Text="Male" AutoPostBack="true" OnCheckedChanged="rad_gender_CheckedChanged" TabIndex="5" CssClass="" />&nbsp &nbsp
                                                <asp:RadioButton ID="rad_female" runat="server" Text="Female" AutoPostBack="true" OnCheckedChanged="rad_female_CheckedChanged" TabIndex="6" CssClass="" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="row">

                                                            <div class="col-lg-3">

                                                                <label for="inputState" class="form-label">
                                                                    D.O.B<span style="color: #ff3333; font-weight: 800">*</span>
                                                                </label>
                                                                <%--    <asp:UpdatePanel runat="server">
                                                                            <ContentTemplate>--%>
                                                                <asp:TextBox ID="txt_dob" runat="server" ReadOnly="true" CssClass="form-control" autocomplete="off"></asp:TextBox>
                                                                <%--      </ContentTemplate>
                                                                        </asp:UpdatePanel>--%>
                                                            </div>
                                                            <div class="col-lg-2">
                                                                <label for="inputState" class="form-label">
                                                                    Bloodgroup
                                                                </label>
                                                                <asp:DropDownList ID="ddlbldgrp" runat="server" CssClass="form-select">
                                                                </asp:DropDownList>
                                                            </div>
                                                            <div class="col-lg-2">
                                                                <label for="inputState" class="form-label">
                                                                    Nationality<span style="color: #ff3333; font-weight: 800">*</span>
                                                                </label>
                                                                <asp:DropDownList ID="ddlnation" runat="server" CssClass="form-select">
                                                                    <asp:ListItem Text="--Select--"></asp:ListItem>
                                                                    <asp:ListItem Text="INDIAN" Value="INDIAN"></asp:ListItem>
                                                                    <asp:ListItem Text="OTHERS" Value="OTHERS"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </div>
                                                            <div class="col-lg-2">
                                                                <label for="inputState" class="form-label">
                                                                    Category<span style="color: #ff3333; font-weight: 800">*</span>
                                                                </label>
                                                                <asp:DropDownList ID="ddlcat" runat="server" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlcat_SelectedIndexChanged"></asp:DropDownList>
                                                            </div>
                                                            <div class="col-lg-3">
                                                                <label for="inputState" class="form-label">
                                                                    Caste
                                                                </label>

                                                                <asp:DropDownList ID="ddlcast" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlcast_SelectedIndexChanged" CssClass="form-select">
                                                                </asp:DropDownList>
                                                            </div>

                                                        </div>
                                                        <br />
                                                                <div class="row">
                                                    <div class="col-lg-6"></div>
                                                    <div class="col-lg-3" style="margin-left: 57px;">
                                                        <asp:Button ID="btn_pd" runat="server" CssClass="btn btn-primary form-control" Width="100%" OnClick="btn_pd_Click" Text="Save" />
                                                    </div>
                                                    <div class="col-lg-1"></div>

                                                </div>
                                                    </div>
                                                    <div class="col-lg-3" style="text-align: end;">
                                                        <div class="container">
                                                            <div class="row">
                                                                <div class="col-lg-12">
                                                                    <asp:Image runat="server" ID="stud_img" ImageUrl="~/user__image.png" Width="59%" Height="161PX" Style="border: solid #cdb1b1 2px; border-radius: 50%;" />
                                                                    <asp:LinkButton runat="server" ID="btnUpload"  data-bs-target="#img_edit_modal">
                                                <img src="https://img.icons8.com/windows/25/000000/edit--v1.png" style="margin-bottom: 123px;"/> 
                                                                    </asp:LinkButton>
                                                                </div>
                                                            </div>
                                                            <br />
                                                            <div class="row">

                                                                <div class="col-lg-3"></div>
                                                                <div class="col-lg-4">
                                                                    <asp:Button ID="PHOTO" runat="server" OnClick="PHOTO_Click" CssClass="btn btn-primary form-control" Text="Photo" />
                                                                </div>
                                                                <div class="col-lg-4" style="text-align: end">
                                                                    <asp:Button runat="server" ID="SIGN" OnClick="SIGN_Click" CssClass="btn btn-primary form-control" Text="Sign" />
                                                                </div>

                                                            </div>
                                                        </div>
                                                        <br />


                                                    </div>
                                                </div>
                                        
                                                <%--  <div class="row">
                                                            <div class="col-lg-2">
                                                                
                                                            </div>
                                                        </div>--%>
                                            </div>
                                        </div>
                                        <div class="card">
                                            <div class="card-header">
                                                Birth place/other details
                                            </div>
                                            <div class="card-body">
                                                <br />
                                                <div class="row">
                                                    <%--<div class="col-lg-2"></div>--%>
                                                    <div class="col-lg-3">
                                                        <label for="inputState" class="form-label">
                                                            Birth Place<span style="color: #ff3333; font-weight: 800">*</span>
                                                        </label>
                                                        <asp:TextBox ID="txtbirthplace" runat="server" oncopy="return false" onpaste="return false" oncut="return false" onkeypress="return ALPHAa(event)" autocomplete="off" MaxLength="40" CssClass="form-control"></asp:TextBox>
                                                    </div>
                                                    <div class="col-lg-3">
                                                        <label for="inputState" class="form-label">
                                                            Maritial Status<span style="color: #ff3333; font-weight: 800">*</span>
                                                        </label>
                                                        <asp:DropDownList ID="ddlmart" runat="server" CssClass="form-select">
                                                            <asp:ListItem Text="--Select--"></asp:ListItem>
                                                            <asp:ListItem Text="Married" Value="Married"></asp:ListItem>
                                                            <asp:ListItem Text="Unmarried" Value="Unmarried"></asp:ListItem>

                                                        </asp:DropDownList>
                                                    </div>
                                                    <div class="col-lg-3">
                                                        <label for="inputState" class="form-label">
                                                            Email ID<span style="color: #ff3333; font-weight: 800">*</span>
                                                        </label>
                                                        <asp:TextBox ID="txtemail" style="text-transform:lowercase"  MaxLength="99"  TextMode="Email" autocomplete="off" runat="server" oncopy="return false" onpaste="return false" oncut="return false" CssClass="form-control"></asp:TextBox>
                                                    </div>
                                                    <div class="col-lg-3">
                                                        <label for="inputState" class="form-label">
                                                            Religion <span style="color: #ff3333; font-weight: 800">*</span>
                                                        </label>
                                                        <asp:DropDownList ID="ddlreli" runat="server" CssClass="form-select"></asp:DropDownList>
                                                    </div>
                                                    <%--<div class="col-lg-2"></div>--%>
                                                </div>
                                                <br />
                                                <div class="row">
                                                    <div class="col-lg-5"></div>
                                                    <div class="col-lg-2">
                                                        <asp:Button runat="server" Text="Save" CssClass="btn btn-primary form-control" ID="btn_brthplace_updt" OnClick="btn_brthplace_updt_Click" />
                                                    </div>
                                                    <div class="col-lg-5"></div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="card">
                                            <div class="card-header">
                                              Current  Address
                                            </div>
                                            <div class="card-body">
                                                <br />
                                                <div class="row">
                                                    
                                                    <div class="col-lg-4">
                                                        Address<span style="color: #ff3333; font-weight: 800">*</span>
                                                        <asp:TextBox ID="txtadd" runat="server" oncopy="return false" onpaste="return false" oncut="return false" onkeypress="return address_exp(event)" autocomplete="off" MaxLength="100" CssClass="form-control"></asp:TextBox>
                                                    </div>
                                                    <div class="col-lg-2">
                                                        State<span style="color: #ff3333; font-weight: 800">*</span>
                                                        <asp:DropDownList ID="ddlstate" runat="server" CssClass="form-select">
                                                        </asp:DropDownList>
                                                    </div>
                                                    <div class="col-lg-2">
                                                        City<span style="color: #ff3333; font-weight: 800">*</span>
                                                        <asp:TextBox ID="txtcity" runat="server" oncopy="return false" onpaste="return false" oncut="return false" onkeypress="return ONLY_ALPHA(event)" AutoComplete="off" MaxLength="25" CssClass="form-control">
                                                        </asp:TextBox>
                                                    </div>
                                                    <div class="col-lg-2">
                                                        Pincode No.<span style="color: #ff3333; font-weight: 800">*</span>
                                                        <asp:TextBox ID="txtpin" runat="server" oncopy="return false" onpaste="return false" oncut="return false" onkeypress="return OnlyNum(event)" autocomplete="off" MaxLength="6" CssClass="form-control"></asp:TextBox>
                                                    </div>
                                                    <div class="col-lg-2">
                                                        Phone No.<span style="color: #ff3333; font-weight: 800">*</span>
                                                        <asp:TextBox runat="server" ID="txtphone" oncopy="return false" onpaste="return false" oncut="return false" onkeypress="return OnlyNum(event)" autocomplete="off" MaxLength="10" CssClass="form-control">
                                                        </asp:TextBox>
                                                    </div>
                                                    
                                                </div>
                                                <div class="row">
                                                    <div class="col-lg-5"></div>
                                                    <div class="col-lg-2" style="margin-top: 23PX;">
                                                        <asp:Button runat="server" ID="btnaddrss" OnClick="btnaddrss_Click" Text="Save" CssClass="btn btn-primary form-control"></asp:Button>
                                                    </div>
                                                    <div class="col-lg-5"></div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="card">
                                            <div class="card-header">
                                                Native Address
                                            </div>
                                            <div class="card-body">
                                                <br />
                                                <div class="row">
                                               
                                                    <div class="col-lg-4">
                                                        Address
                                               <asp:TextBox ID="nat_address" runat="server" oncopy="return false" onpaste="return false" oncut="return false" onkeypress="return address_exp(event)" autocomplete="off" MaxLength="200" CssClass="form-control"></asp:TextBox>
                                                    </div>
                                                    <div class="col-lg-2">
                                                        State
                                                <asp:DropDownList ID="ddl_nat_state" runat="server" CssClass="form-select">
                                                </asp:DropDownList>
                                                    </div>
                                                    <div class="col-lg-2">
                                                        City
                                                <asp:TextBox ID="nat_txt_city" oncopy="return false" onpaste="return false" oncut="return false" runat="server" onkeypress="return ONLY_ALPHA(event)" CssClass="form-control">

                                                </asp:TextBox>
                                                    </div>
                                                    <div class="col-lg-2">
                                                        Pincode No.
                                                <asp:TextBox ID="txt_nat_pin" runat="server" oncopy="return false" onpaste="return false" oncut="return false" onkeypress="return OnlyNum(event)" autocomplete="off" MaxLength="6" CssClass="form-control"></asp:TextBox>
                                                    </div>
                                                    <div class="col-lg-2">
                                                        Phone no.
                                                <asp:TextBox runat="server" oncopy="return false" onpaste="return false" oncut="return false" ID="txt_nat_phone" onkeypress="return OnlyNum(event)" autocomplete="off" MaxLength="10" CssClass="form-control">

                                                </asp:TextBox>
                                                    </div>

                                                    
                                                </div>
                                                <br />
                                                <div class="row">
                                                    <div class="col-lg-5">
                                                    </div>
                                                    <div class="col-lg-2">
                                                        <asp:Button ID="btn_natUPdate" runat="server" CssClass="btn btn-primary form-control" Text="Save" OnClick="btn_natUPdate_Click" />
                                                    </div>
                                                    <div class="col-lg-5"></div>
                                                </div>
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="tab-pane fade" id="nav-Personal" role="tabpanel" aria-labelledby="nav-Personal-tab">
                                <br />
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>

                                        <div class="row">
                                            <br />
                                            <div class="card">
                                                <div class="card-header">
                                                    Father Details
                                                </div>
                                                <div class="card-body">
                                                    <br />
                                                    <div class="row">
                                                        <div class="col-lg-2">
                                                            <label for="inputSate" class="form-label">First Name<span style="color: #ff3333; font-weight: 800">*</span></label>
                                                            <asp:TextBox ID="txt_Fathernam" onkeypress="return ONLY_ALPHA(event)" autocomplete="off" MaxLength="20" oncopy="return false" onpaste="return false" oncut="return false" runat="server" CssClass="form-control"></asp:TextBox>
                                                        </div>
                                                        <div class="col-lg-2">
                                                            <label for="inputState" class="form-label">Middle Name</label>
                                                            <asp:TextBox ID="txt_father_mname" onkeypress="return ONLY_ALPHA(event)" autocomplete="off" MaxLength="20" oncopy="return false" onpaste="return false" oncut="return false" runat="server" CssClass="form-control"></asp:TextBox>
                                                        </div>
                                                        <div class="col-lg-2">
                                                            <label for="inputState" class="form-label">Last Name</label>
                                                            <asp:TextBox ID="txt_fatherLstnam" onkeypress="return ONLY_ALPHA(event)" autocomplete="off" MaxLength="20" oncopy="return false" onpaste="return false" oncut="return false" runat="server" CssClass="form-control"></asp:TextBox>
                                                        </div>
                                                        <div class="col-lg-2">
                                                            <label for="inputState" class="form-label">Occupation<span style="color: #ff3333; font-weight: 800">*</span></label>
                                                            <asp:DropDownList ID="ddl_fath_occupation" runat="server" CssClass="form-select">
                                                                <asp:ListItem>--select--</asp:ListItem>
                                                                <asp:ListItem>Service</asp:ListItem>
                                                                <asp:ListItem>Business</asp:ListItem>
                                                                <asp:ListItem>Professional</asp:ListItem>
                                                                <asp:ListItem>Farmer</asp:ListItem>
                                                                <asp:ListItem>Laborer</asp:ListItem>
                                                                <asp:ListItem>Retired</asp:ListItem>
                                                                <asp:ListItem>Other</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                        <div class="col-lg-2">
                                                            <label for="inputState" class="form-label">Phone no.<span style="color: #ff3333; font-weight: 800">*</span></label>
                                                            <asp:TextBox ID="txt_fath_phone" onkeypress="return OnlyNum(event)" autocomplete="off" MaxLength="10" oncopy="return false" onpaste="return false" oncut="return false" runat="server" CssClass="form-control"></asp:TextBox>
                                                        </div>
                                                        <div class="col-lg-2">
                                                            <label for="inputState" class="form-label">Service/Business Address.</label>
                                                            <asp:TextBox ID="txt_fath_address" onkeypress="return address_exp(event)" autocomplete="off" MaxLength="20" oncopy="return false" onpaste="return false" oncut="return false" runat="server" CssClass="form-control">  </asp:TextBox>
                                                        </div>

                                                    </div>
                                                    <div class="row">


                                                        <div class="col-lg-5">
                                                        </div>
                                                        <div class="col-lg-2">
                                                            <br />
                                                            <asp:Button ID="btn_fath_det" OnClick="btn_fath_det_Click" Text="Save" runat="server" CssClass="btn btn-primary form-control" />
                                                        </div>

                                                        <div class="col-lg-5">
                                                        </div>

                                                    </div>
                                                </div>
                                            </div>
                                            <div class="card">
                                                <div class="card-header">
                                                    Mother Details
                                                </div>
                                                <div class="card-body">
                                                    <br />

                                                    <div class="row">
                                                        <div class="col-lg-2">
                                                            <label for="inputSate" class="form-label">First Name<span style="color: #ff3333; font-weight: 800">*</span></label>
                                                            <asp:TextBox ID="txtMother_fname" onkeypress="return ONLY_ALPHA(event)" autocomplete="off" MaxLength="20" runat="server" oncopy="return false" onpaste="return false" oncut="return false" CssClass="form-control"></asp:TextBox>
                                                        </div>
                                                        <div class="col-lg-2">
                                                            <label for="inputState" class="form-label">Middle Name</label>
                                                            <asp:TextBox ID="txtMother_Mname" onkeypress="return ONLY_ALPHA(event)" autocomplete="off" MaxLength="20" runat="server" oncopy="return false" onpaste="return false" oncut="return false" CssClass="form-control"></asp:TextBox>
                                                        </div>
                                                        <div class="col-lg-2">
                                                            <label for="inputState" class="form-label">Last Name</label>
                                                            <asp:TextBox ID="txtMother_LstName" onkeypress="return ONLY_ALPHA(event)" autocomplete="off" MaxLength="20" runat="server" oncopy="return false" onpaste="return false" oncut="return false" CssClass="form-control"></asp:TextBox>
                                                        </div>
                                                        <div class="col-lg-2">
                                                            <label for="inputState" class="form-label">Occupation<span style="color: #ff3333; font-weight: 800">*</span></label>
                                                            <asp:DropDownList ID="ddl_Moth_occu" runat="server" CssClass="form-select">
                                                                <asp:ListItem>--select--</asp:ListItem>
                                                                <asp:ListItem>Homemaker</asp:ListItem>
                                                                <asp:ListItem>Service</asp:ListItem>
                                                                <asp:ListItem>Business</asp:ListItem>
                                                                <asp:ListItem>Professional</asp:ListItem>
                                                                <asp:ListItem>Farmer</asp:ListItem>
                                                                <asp:ListItem>Laborer</asp:ListItem>
                                                                <asp:ListItem>Retired</asp:ListItem>
                                                                <asp:ListItem>Other</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                        <div class="col-lg-2">
                                                            <label for="inputState" class="form-label">Phone no.<span style="color: #ff3333; font-weight: 800">*</span></label>
                                                            <asp:TextBox ID="txt_Mothe_Phon" onkeypress="return OnlyNum(event)" autocomplete="off" MaxLength="10" runat="server" oncopy="return false" onpaste="return false" oncut="return false" CssClass="form-control"></asp:TextBox>
                                                        </div>
                                                        <div class="col-lg-2">
                                                            <label for="inputState" class="form-label">Service/Business Address.</label>
                                                            <asp:TextBox ID="txt_Moth_servaddres" onkeypress="return address_exp(event)" autocomplete="off" MaxLength="50" runat="server" oncopy="return false" onpaste="return false" oncut="return false" CssClass="form-control">  </asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-lg-5"></div>

                                                        <div class="col-lg-2">
                                                            <br />
                                                            <asp:Button Text="Save" runat="server" ID="btn_Mortherdetail" OnClick="btn_Mortherdetail_Click" CssClass="btn btn-primary form-control" />
                                                        </div>
                                                        <div class="col-lg-5"></div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="card">
                                                <div class="card-header">
                                                    Guardian Details
                                                </div>
                                                <div class="card-body">
                                                    <br />
                                                    <div class="row">
                                                        
                                                        <div class="col-lg-2">
                                                            <label for="inputSate" class="form-label">First Name</label>
                                                            <asp:TextBox ID="txtguard_fname" onkeypress="return ONLY_ALPHA(event)" autocomplete="off" MaxLength="20" runat="server" oncopy="return false" onpaste="return false" oncut="return false" CssClass="form-control"></asp:TextBox>
                                                        </div>
                                                        <div class="col-lg-2">
                                                            <label for="inputState" class="form-label">Middle Name</label>
                                                            <asp:TextBox ID="txt_guard_MiddleName" onkeypress="return ONLY_ALPHA(event)" autocomplete="off" MaxLength="20" oncopy="return false" onpaste="return false" oncut="return false" runat="server" CssClass="form-control"></asp:TextBox>
                                                        </div>
                                                        <div class="col-lg-2">
                                                            <label for="inputState" class="form-label">Last Name</label>
                                                            <asp:TextBox ID="txt_guard_lstname" onkeypress="return ONLY_ALPHA(event)" autocomplete="off" MaxLength="20" oncopy="return false" onpaste="return false" oncut="return false" runat="server" CssClass="form-control"></asp:TextBox>
                                                        </div>

                                                        <div class="col-lg-2">
                                                            <label for="inputState" class="form-label">Phone no.</label>
                                                            <asp:TextBox ID="txt_guard_phone" MaxLength="10" onkeypress="return OnlyNum(event)" autocomplete="off" oncopy="return false" onpaste="return false" oncut="return false" runat="server" CssClass="form-control"></asp:TextBox>
                                                        </div>
                                                        <div class="col-lg-4">
                                                            <label for="inputState" class="form-label">Address.</label>
                                                            <asp:TextBox ID="txt_guard_address" onkeypress="return address_exp(event)" MaxLength="50" autocomplete="off" oncopy="return false" onpaste="return false" oncut="return false" runat="server" CssClass="form-control">  </asp:TextBox>
                                                        </div>
                                                        
                                                    </div>


                                                    <div class="row">
                                                        <div class="col-lg-5"></div>
                                                        <div class="col-lg-2">
                                                            <br />
                                                            <asp:Button Text="Save" ID="btn_guard_updte" OnClick="btn_guard_updte_Click" CssClass="btn btn-primary form-control" runat="server" />
                                                        </div>
                                                        <div class="col-lg-5"></div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="card">
                                                <div class="card-header">
                                                    No. Of Person In The Family
                                                </div>
                                                <div class="card-body">
                                                    <br />
                                                    <div class="row">
                                                    
                                                        <div class="col-lg-3">
                                                            <label for="inputSate" class="form-label">Earning<span style="color: #ff3333; font-weight: 800">*</span></label>
                                                            <asp:TextBox ID="txt_earning" onkeypress="return OnlyNum(event)" MaxLength="3" AutoPostBack="true" OnTextChanged="txt_earning_TextChanged" autocomplete="off" oncopy="return false" onpaste="return false" oncut="return false" runat="server" CssClass="form-control"></asp:TextBox>
                                                        </div>
                                                        <div class="col-lg-3">
                                                            <label for="inputState" class="form-label">Non Earning<span style="color: #ff3333; font-weight: 800">*</span></label>
                                                            <asp:TextBox ID="txt_Nonearn" onkeypress="return OnlyNum(event)" OnTextChanged="txt_Nonearn_TextChanged" AutoPostBack="true" autocomplete="off" oncopy="return false" onpaste="return false" oncut="return false" MaxLength="3" runat="server" CssClass="form-control"></asp:TextBox>
                                                        </div>
                                                        <div class="col-lg-3">
                                                            <label for="inputState" class="form-label">Total Members</label>
                                                            <asp:TextBox ID="txt_tot_Member" onkeypress="return OnlyNum(event)" AutoPostBack="true" autocomplete="off" oncopy="return false" onpaste="return false" oncut="return false" runat="server" CssClass="form-control"></asp:TextBox>
                                                        </div>

                                                        <div class="col-lg-3">
                                                            <label for="inputState" class="form-label">Yearly Income<span style="color: #ff3333; font-weight: 800">*</span></label>
                                                            <asp:TextBox ID="txt_Incone" onkeypress="return OnlyNum(event)" MaxLength="8" autocomplete="off" oncopy="return false" onpaste="return false" oncut="return false" runat="server" CssClass="form-control"></asp:TextBox>
                                                        </div>
                                                     

                                                    </div>
                                                    <div class="row">
                                                        <%--<div class="col-lg-2" style="margin-top:30px">--%>
                                                        <div class="col-lg-5"></div>
                                                        <div class="col-lg-2">
                                                            <br />
                                                            <asp:UpdatePanel ID="updt" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:Button ID="btn_no_of_fam" OnClick="btn_no_of_fam_Click" CssClass="btn btn-primary form-control" Style="text-align: center" runat="server" Text="Save" />
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </div>
                                                        <div class="col-lg-5"></div>
                                                        <%--</div>--%>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="tab-pane fade" id="nav-Educational" role="tabpanel" aria-labelledby="nav-Educational-tab">
                                <br />
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>

                                        <div class="row">
                                            <div class="card">
                                                <div class="card-header">
                                                    Exam/Institute Details
                                                </div>
                                                <div class="card-body">
                                                    <br />
                                                    <div class="row">
                                                        <div class="col-lg-2">
                                                            <label for="inputState" class="form-label">Exam<span style="color: #ff3333; font-weight: 800">*</span></label>
                                                            <asp:DropDownList ID="txtexam" runat="server" OnSelectedIndexChanged="txtexam_SelectedIndexChanged" AutoPostBack="true" CssClass="form-select">
                                                                <asp:ListItem>--Select--</asp:ListItem>
                                                                <asp:ListItem>S.S.C</asp:ListItem>
                                                                <asp:ListItem>H.S.C</asp:ListItem>
                                                               <asp:ListItem>GRADUATION</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                        <div class="col-lg-2">
                                                            <label for="inputState" class="form-label">Institute Name<span style="color: #ff3333; font-weight: 800">*</span></label>
                                                            <asp:TextBox ID="txt_inst_Name" runat="server" onkeypress="return Institute(event)" autocomplete="off" MaxLength="99" CssClass="form-control" oncopy="return false" onpaste="return false" oncut="return false"></asp:TextBox>
                                                        </div>
                                                        <div class="col-lg-2">
                                                            <label for="inputState" class="form-label">Institute Place<span style="color: #ff3333; font-weight: 800">*</span></label>
                                                            <asp:TextBox ID="txt_inst_place" runat="server" CssClass="form-control" MaxLength="150" autocomplete="off" onkeypress="return Institute(event)" oncopy="return false" onpaste="return false" oncut="return false"></asp:TextBox>
                                                        </div>
                                                        <div class="col-lg-2">
                                                            <label for="inputState" class="form-label">Major Subject</label>
                                                            <asp:TextBox ID="txt_Major_sub" runat="server" CssClass="form-control" MaxLength="20" autocomplete="off" onkeypress="return ONLY_ALPHA(event)" oncopy="return false" onpaste="return false" oncut="return false"></asp:TextBox>
                                                        </div>
                                                        <div class="col-lg-2">
                                                            <label for="inputState" class="form-label">Seat Number <span style="color: #ff3333; font-weight: 800">*</span></label>
                                                            <asp:TextBox ID="txt_seat" runat="server" CssClass="form-control" onkeypress="return aplha(event)" autocomplete="off" MaxLength="10" oncopy="return false" onpaste="return false" oncut="return false"></asp:TextBox>
                                                        </div>
                                                        <div class="col-lg-2">
                                                            <label for="inputState" class="form-label">Board/University<span style="color: #ff3333; font-weight: 800">*</span></label>
                                                            <asp:TextBox ID="txt_boardUniver" MaxLength="45" runat="server" onkeypress="return Institute(event)" autocomplete="off" CssClass="form-control" oncopy="return false" onpaste="return false" oncut="return false"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-lg-2">
                                                            <label for="inputState" class="form-label">
                                                                Specialization
                                                            </label>
                                                            <asp:TextBox ID="txtspec" runat="server" onkeypress="return spec(event)" CssClass="form-control" autocomplete="off" MaxLength="19" oncopy="return false" onpaste="return false" oncut="return false"></asp:TextBox>
                                                        </div>
                                                        <div class="col-lg-2">
                                                            <label for="inputState" class="form-label">
                                                                Certificate no.
                                                            </label>
                                                            <asp:TextBox ID="txtcertificate" runat="server" CssClass="form-control" autocomplete="off" onkeypress="return Certifi(event)" MaxLength="14" oncopy="return false" onpaste="return false" oncut="return false"></asp:TextBox>
                                                        </div>
                                                        <div class="col-lg-2">
                                                            <label for="inputState" class="form-label">
                                                                Passing Month<span style="color: #ff3333; font-weight: 800">*</span>
                                                            </label>
                                                            <asp:DropDownList ID="txtPassingmonth" runat="server" CssClass="form-select">
                                                                <asp:ListItem>--Select--</asp:ListItem>
                                                                <asp:ListItem>Jan</asp:ListItem>
                                                                <asp:ListItem>Feb</asp:ListItem>
                                                                <asp:ListItem>Mar</asp:ListItem>
                                                                <asp:ListItem>Apr</asp:ListItem>
                                                                <asp:ListItem>May</asp:ListItem>
                                                                <asp:ListItem>Jun</asp:ListItem>
                                                                <asp:ListItem>Jul</asp:ListItem>
                                                                <asp:ListItem>Aug</asp:ListItem>
                                                                <asp:ListItem>Sept</asp:ListItem>
                                                                <asp:ListItem>Oct</asp:ListItem>
                                                                <asp:ListItem>Nov</asp:ListItem>
                                                                <asp:ListItem>Dec</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                        <div class="col-lg-2">
                                                            <label for="inputState" class="form-label">
                                                                Passing Year<span style="color: #ff3333; font-weight: 800">*</span>
                                                            </label>
                                                            <asp:DropDownList ID="txtPassingyear" runat="server" CssClass="form-select">
                                                                <asp:ListItem>--select--</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                        <div class="col-lg-2">
                                                            <label for="inputState" class="form-label">
                                                                Obtained Marks<span style="color: #ff3333; font-weight: 800">*</span>
                                                            </label>
                                                            <asp:TextBox ID="txtobtmrks" runat="server" CssClass="form-control" onkeypress="return OnlyNum(event)" autocomplete="off" MaxLength="4" oncopy="return false" onpaste="return false" oncut="return false"></asp:TextBox>
                                                        </div>
                                                        <div class="col-lg-2">
                                                            <label for="inputState" class="form-label">
                                                                Out Of Marks<span style="color: #ff3333; font-weight: 800">*</span>
                                                            </label>
                                                            <asp:TextBox ID="txt_OutOfMarks" runat="server" CssClass="form-control" onkeypress="return OnlyNum(event)" autocomplete="off" MaxLength="4" oncopy="return false" onpaste="return false" oncut="return false"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <br />
                                                    <div class="row">
                                                        <div class="col-lg-4">
                                                        </div>
                                                        <div class="col-lg-2">
                                                            <asp:Button runat="server" CssClass="btn btn-primary form-control" ID="btn_new" Text="Save" OnClick="btn_new_Click" />
                                                        </div>
                                                        <div class="col-lg-2">
                                                            <asp:Button runat="server" CssClass="btn btn-primary form-control" ID="btn_clr" Text="Clear" OnClick="btn_clr_Click" />
                                                        </div>
                                                        <div class="col-lg-4"></div>


                                                    </div>
                                                    <br />
                                                    <asp:UpdatePanel runat="server" ID="upgrd">
                                                        <ContentTemplate>
                                                            <div id="divGridViewScroll" style="width: 100%; height: 300px; overflow-x: auto">

                                                                <asp:GridView runat="server" ID="grdviw" AutoGenerateColumns="false" HeaderStyle-CssClass="FixedHeader" HeaderStyle-BackColor="White">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="Exam" HeaderStyle-BackColor="White">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblgrdexam" runat="server" Text='<%#Eval("Exam") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Institute Name" HeaderStyle-BackColor="White">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblgrd_InstituteName" runat="server" Text='<%#Eval("Institute_Name") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Institute Place" HeaderStyle-BackColor="White">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblgrd_Instituteplace" runat="server" Text='<%#Eval("Institute_Place") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Exam Seat No." HeaderStyle-BackColor="White">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbl_grd_seatno" runat="server" Text='<%#Eval("Exam_seatno") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Board/University" HeaderStyle-BackColor="White">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbl_grd_Board_univer" runat="server" Text='<%#Eval("Board_University") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Month & Year of Passing" HeaderStyle-BackColor="White">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbl_grd_monthpassing" runat="server" Text='<%#Eval("Month_year_Passing") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Marks Obtained" HeaderStyle-BackColor="White">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbl_grd_mrksobt" runat="server" Text='<%#Eval("Marks_Obtained") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Out OfMarks" HeaderStyle-BackColor="White">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbl_grd_outofMark" runat="server" Text='<%#Eval("Outof") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Class Obtained" HeaderStyle-BackColor="White">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbl_grd_Classobt" runat="server" Text='<%#Eval("Class_obtained") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Exact Percentage" HeaderStyle-BackColor="White">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbl_grd_Exct_Perct" runat="server" Text='<%#Eval("Exact_Percentage") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderText="Major Subject" HeaderStyle-BackColor="White">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbl_grd_Majorsub" runat="server" Text='<%#Eval("Major_subject") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderText="Specialization" HeaderStyle-BackColor="White">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbl_grd_spec" runat="server" Text='<%#Eval("Specialization") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Certificate No." HeaderStyle-BackColor="White">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbl_grd_certi" runat="server" Text='<%#Eval("Certificate_no") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Edit">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="grd_select" runat="server" CommandName="select" OnClick="grd_select_Click" CommandArgument="<%#Container.DataItemIndex%>"><i class="bi bi-pencil"></i></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Delete">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="grd_del" runat="server" Style="color: red" CommandName="del" OnClick="grd_del_Click"> <i class="bi bi-trash"></i></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </div>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </div>
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

    <script>
        function ShowImagePreview(input) {                                                  // to show image before saving
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                     $('#<%=edit_image.ClientID%>').prop('src', e.target.result)
                        .width(200)
                        .height(150);
                };
                reader.readAsDataURL(input.files[0]);
            }
        }
        


        function ShowImagePreview1(input) {                                                  // to show image before saving
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                     $('#<%=EDIT_SIGN.ClientID%>').prop('src', e.target.result)
                        .width(200)
                        .height(150);
                };
                reader.readAsDataURL(input.files[0]);
            }
        }
        function notify(msg, type) {
            $.notify(msg, { type: type, animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.2, delay: 0 });
        }
        datepic();
        function datepic() {
            $('[id*=txt_dob]').datetimepicker(
                {
                    changeMonth: false,
                    changeYear: false,
                    timepicker: false,
                    format: 'd/M/Y',


                    //viewMode: "months",
                    //minViewMode: "months",
                    //maxDate: 0
                    //maxDate: new Date(2004, 0, 1)
                    //endDate: "+0m"
                });
        }
        function OnlyNum(event) {
            var value = String.fromCharCode(event.which);
            var pattern = new RegExp(/[0-9]/i);
            return pattern.test(value);
        }
        function ALPHAa(event) {
            var value = String.fromCharCode(event.which);
            var pattern = new RegExp(/[a-zA-Z]/i);
            return pattern.test(value);
        }

        function Certifi(event) {
            var value = String.fromCharCode(event.which);
            var pattern = new RegExp(/[a-zA-Z0-9 /-]/i);
            return pattern.test(value);
        }



        function spec(event) {
            var value = String.fromCharCode(event.which);
            var pattern = new RegExp(/[a-zA-Z /(/)/ \/\-/']/i);
            return pattern.test(value);
        }




        function ONLY_ALPHA(event) {
            var value = String.fromCharCode(event.which);
            var pattern = new RegExp(/[a-zA-Z ']/i);
            return pattern.test(value);
        }
        function address_exp(event) {
            var value = String.fromCharCode(event.which);
            var pattern = new RegExp(/[a-zA-Z0-9 (),./ &'-]/i);
            return pattern.test(value);
        }

        function aplha(event) {
            var value = String.fromCharCode(event.which);
            var pattern = new RegExp(/[a-zA-Z0-9 ']/i);
            return pattern.test(value);
        }
        function Institute(event) {
            var value = String.fromCharCode(event.which);
            var pattern = new RegExp(/[a-zA-Z/,/./(/)/-/'\s]/i);
            return pattern.test(value);
        }
        function oncoursetab() {
            $.ajax({
                type: "get",
                url: 'StudentModify.aspx.aspx/Coursetab',
                data: {},
                contentType: "application/json;",
                success: function (msg) {
                },
                error: function (e) {

                }
            });
        }
        function coursetab() {
            $.ajax({
                type: "get",
                url: 'StudentModify.aspx.aspx/Coursetab',
                data: {},
                contentType: "application/json;",
                success: function (msg) {
                },
                error: function (e) {

                }
            });
        }

        $('[id*=btnUpload]').click(function () {
            $('[id*=img_edit_modal]').modal({ backdrop: "static" });
        });
       
    </script>

</asp:Content>

