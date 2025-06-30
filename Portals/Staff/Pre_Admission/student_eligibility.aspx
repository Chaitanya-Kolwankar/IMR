<%@ Page Title="" Language="C#" MasterPageFile="~/Portals/Staff/MasterPage.master" AutoEventWireup="true" CodeFile="student_eligibility.aspx.cs" Inherits="Portals_Staff_Pre_Admission_student_eligibility" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
  
<%--    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
<link href="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/css/bootstrap.min.css"
    rel="stylesheet" type="text/css" />
<script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/js/bootstrap.min.js"></script>
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-multiselect/0.9.13/css/bootstrap-multiselect.css">
<script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-multiselect/0.9.13/js/bootstrap-multiselect.js"></script>--%>

      <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
<script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
<script src="https://cdn.jsdelivr.net/npm/popper.js@1.12.9/dist/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
<script src="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.js"></script>

    <link href="../../../Assets/multiselect/css/bootstrap-multiselect.css" rel="stylesheet" />
    <script src="../../../Assets/multiselect/js/bootstrap-multiselect.js"></script>
    <script src="../../../Assets/notify-master/js/notify.js"></script>
    <link href="../../../Assets/notify-master/css/notify.css" rel="stylesheet" />
    <style>
      
        .multiselect {
            
            border: 1px solid #ced4da;
        }
  
        table, td, th {
            border: 1px solid #ddd;
            text-align: left;
        }

        table {
            border-collapse: collapse;
            width: 100%;
        }

        th, td {
            padding: 15px;
        }

        th {                                                
            color: #012970;
        }

        .caps {
            text-transform: capitalize;
        }

        .label {
            font-weight: 600;
            color: #012970;
        }

        .FixedHeader {
            position: sticky;
            font-weight: bold;
            top: 0;
        }

        .hidden {
            display: none;
        }
    </style>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="main" id="main">
        <div class="container-fluid">
            <div class="pagetitle " style="font-size: 32px; margin-left: 34px; font-weight: 300; color: #012970;">
                Pre Admission
            </div>
            <div class="container-fluid">
                <div class="card" style="border:0px solid;box-shadow:0px 0 30px rgb(30 79 167 / 22%)"> 
                    <div class="card-title mx-4">
                        Define Eligibility
                    </div>
                    <div class="card-body">
                        <div class="container-fluid">
                            <div class="row">
                               
                                <div class="col-lg-2">
                                    <label for="inputstate" class="form-label">
                                        Course
                                    </label>
                                    <asp:UpdatePanel runat="server">
                                        <ContentTemplate>
                                             <asp:DropDownList ID="ddlcourse" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlcourse_SelectedIndexChanged" CssClass="form-select"></asp:DropDownList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                   
                                </div>
                                <div class="col-lg-2">
                                    <label for="inputstate" class="form-label">
                                       Sub Course                                        
                                    </label>
                                    <asp:UpdatePanel runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="ddlsubcou" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlsubcou_SelectedIndexChanged" CssClass="form-select"></asp:DropDownList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    
                                </div>
                                <div class="col-lg-2">
                                     <label for="inputstate" class="form-label">
                                      From Group                                        
                                    </label>
                                    <asp:UpdatePanel runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="ddlfrmgrp" runat="server" AutoPostBack="true" CssClass="form-select" OnSelectedIndexChanged="ddlfrmgrp_SelectedIndexChanged">
                                    </asp:DropDownList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <div class="col-lg-2">
                                     <label for="inputstate" class="form-label">
                                      To Group                                        
                                    </label>
                                    <asp:UpdatePanel ID="updt" runat="server">
                                        <ContentTemplate>
                                           
                                            <asp:ListBox ID="lsttogrp" runat="server" SelectionMode="Multiple"  CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="lsttogrp_SelectedIndexChanged" ></asp:ListBox>
                                        </ContentTemplate>
                                       
                                    </asp:UpdatePanel>

                                </div>
                                 <div class="col-lg-2">
                                    <label for="inputstate" class="form-label">
                                        To Year                                        
                                    </label>
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="ddltoyear" runat="server" AutoPostBack="true" class="form-select" OnSelectedIndexChanged="ddltoyear_SelectedIndexChanged"></asp:DropDownList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-lg-2">
                                    <asp:UpdatePanel runat="server">
                                        <ContentTemplate>
                                            <asp:CheckBox ID="chk_search" runat="server" Text="Search By Student ID" AutoPostBack="true" OnCheckedChanged="chk_search_CheckedChanged" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    
                                </div>
                                <div class="col-lg-2">
                                    <asp:UpdatePanel runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="txtstudid" runat="server" CssClass="form-control" MaxLength="8" autocomplete="off" onkeypress="return OnlyNum(event)" placeholder="Student ID"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="validtaore" runat="server" ControlToValidate="txtstudid" ErrorMessage="Student ID Must Be Of 8 Digit." Display="Dynamic" ValidationExpression=".{8}.*" ForeColor="Red"></asp:RegularExpressionValidator>
<%--                                                 <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txt_aadhar" ErrorMessage=" Aadhaar Card No Must Be Of 12 Digit" Display="Dynamic" ValidationExpression=".{6}.*" ForeColor="Red"></asp:RegularExpressionValidator>--%>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                   
                                </div>
                                <div class="col-lg-2">
                                    <asp:UpdatePanel runat="server">
                                        <ContentTemplate>
                                            <asp:Button ID="btn_stud_search" runat="server" CssClass="form-control btn btn-primary" onclick="btn_stud_search_Click" Text="Search"/>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    
                                </div>

                                <div class="col-lg-2">
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <asp:Button runat="server" ID="btnsave" Text="Save" OnClick="btnsave_Click" CssClass="form-control btn btn-primary" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    
                                </div>
                            </div>

                            <div class="row">
                               <%-- <div class="col-lg-2">
                                    <asp:Button runat="server" ID="btngetdata" Text="Get Data" OnClick="btngetdata_Click" CssClass="btn btn-primary" /> 
                                </div>--%>
                                
                            </div>
                            <br />
                            
<asp:UpdatePanel runat="server">
    <ContentTemplate>

    
                            <div style="max-height:400px; width:100%; overflow:auto">
                                <asp:GridView runat="server" ID="grd1" AutoGenerateColumns="false" OnRowDataBound="grd1_RowDataBound" OnRowCommand="grd1_RowCommand"  HeaderStyle-CssClass="FixedHeader" HeaderStyle-BackColor="White" style="max-height:400px;" >
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="headchk" runat="server" AutoPostBack="true" OnCheckedChanged="headchk_CheckedChanged" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="grdchk" runat="server" AutoPostBack="true"  OnCheckedChanged="grdchk_CheckedChanged1"/>

                                            </ItemTemplate>
                                        </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Student ID" HeaderStyle-CssClass="text-blue">
                                        <ItemTemplate>
                                            <asp:Label ID="gridlblStudid"  ItemStyle-CssClass="caps" runat="server" Text='<%#Eval("stud_id")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Student Name" HeaderStyle-CssClass="text-blue">
                                            <ItemTemplate>
                                                <asp:Label ID="grdlblstudname" ItemStyle-CssClass="caps" runat="server" Text='<%#Eval("studname") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Roll no." HeaderStyle-CssClass="text-blue">
                                            <ItemTemplate>
                                                <asp:Label ID="grdlblRoll" ItemStyle-CssClass="caps" runat="server" Text='<%#Eval("Roll_no") %>'></asp:Label>
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
            </div>
        </div>

    </div>
    
        <script>
        loadmulti();
        function loadmulti() {
            $(function () {
                $('[id*=lsttogrp]').multiselect({
                    includeSelectAllOption: true
                });
            });
          
        }
        function notify(msg, type) {
            $.notify(msg, { type: type, animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.2, delay: 0 });
        }


        function OnlyNum(event) {
            var value = String.fromCharCode(event.which);
            var pattern = new RegExp(/[0-9]/i);
            return pattern.test(value);
        }

        function notify(msg, type) {
            $.notify(msg, { type: type, animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.2, delay: 0 });
        }

       

        </script>

    
</asp:Content>

