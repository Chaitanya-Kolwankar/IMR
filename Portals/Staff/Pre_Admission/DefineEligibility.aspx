<%@ Page Title="" Language="C#" MasterPageFile="~/Portals/Staff/MasterPage.master" AutoEventWireup="true" CodeFile="DefineEligibility.aspx.cs" Inherits="Portals_Staff_Pre_Admission_DefineEligibility" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="main" class="main">
        <div class="container-fluid">
              <div class="pagetitle " style="font-size: 32px; margin-left: 34px; font-weight: 300; color: #012970;">
            Pre Admission
            </div>
            <div class="container-fluid">
                <div class="card">
                    <div class="card-title mx-4">Define Eligibilty</div>
                    <div class="card-body">
                        <div class="container-fluid">
                            <div class="row">
                                <div class="col-lg-2" >
                                     To Year <span style="color:red">*</span>
                                    <asp:DropDownList ID="ddltoyear" runat="server" CssClass="form-select">

                                    </asp:DropDownList>
                                </div>
                                <div class="col-lg-2">
                                    Course
                                    <asp:DropDownList ID="ddlCourse" runat="server" CssClass="form-select">

                                    </asp:DropDownList>
                                 </div>
                                <div class="col-lg-2">
                                   Sub Course
                                    <asp:DropDownList ID="ddlsubcou" runat="server" CssClass="form-select">

                                    </asp:DropDownList>
                                 </div>
                                <div class="col-lg-2">
                                    From Group*
                                    <asp:DropDownList ID="ddlgroup" runat="server" CssClass="form-select">

                                    </asp:DropDownList>
                                 </div>
                                 <div class="col-lg-2">
                                    Student ID:
                                    <asp:TextBox ID="txtstudid" runat="server" CssClass="form-control">

                                    </asp:TextBox>
                                 </div>
                                <div class="col-lg-2">
                                    <div class="row">
                                        <div class="col-lg-5">
                                            <asp:Button ID="btnsearch" runat="server" Text="Search" CssClass="btn btn-primary"  style="margin-top: 21px;">

                                    </asp:Button>
                                        </div>
                                        <div class="col-lg-7">
                                            <span>Search Student</span>
                                            <asp:CheckBox ID="chkbxsearchstud" runat="server" style="margin-top: 31px;"/>
                                        </div>
                                    </div>
                                    
                                 </div>
                                <div class="col-lg-2">
                                    
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>


</asp:Content>

