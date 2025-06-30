<%@ Page Title="" Language="C#" MasterPageFile="~/Portals/Staff/MasterPage.master" AutoEventWireup="true" CodeFile="FeeStructure.aspx.cs" Inherits="Portals_Staff_Admission_Master_FeeStructure" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="main" id="main">
        <div class="container-fluid">
            <div class="pagetitle" style="font-size: 29px; margin-left: 34px; font-weight: 300; color: #012970;">
                Fee Master 
            </div>
            <div class="container-fluid">
                <div class="card">
                <div class="card-title mx-4">
                        Fee Master 
                  </div>
                    <div class="card-body">
                        <div class="row">
                            <div class="col-lg-3 col-md-6 col-sm-6">
                                <label for="inputstate" class="form-label">
                                    Faculty
                                </label>
                                <asp:DropDownList ID="ddlfac" runat="server" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlfac_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                            <div class="col-lg-3 col-md-6 col-sm-6">
                                <label for="inputstate" class="form-label">Course</label>
                                <asp:DropDownList ID="ddlcourse" runat="server" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlcourse_SelectedIndexChanged">

                                </asp:DropDownList>
                            </div>
                            <div class="col-lg-3 col-md-6 col-sm-6">
                                <label for="inputstate" class="form-label">Sub Course</label>
                                <asp:DropDownList ID="ddlsubcou" runat="server" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlsubcou_SelectedIndexChanged">

                                </asp:DropDownList>
                            </div>
                            <div class="col-lg-3 col-md-6 col-sm-6">
                                <label for="inputstate" class="form-label">Group</label>
                                <asp:DropDownList ID="ddlgrup" runat="server" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlgrup_SelectedIndexChanged">

                                </asp:DropDownList>
                            </div>
                        </div>
                        <br />

                        <div class="row">
                            <div class="col-lg-5">
                                <div class="row">
                                    <div class="col-lg-6">
                                        <label for="inputstate" class="form-label">
                                    Particular Name
                                </label>
                                <asp:DropDownList ID="ddlpartiname" runat="server" CssClass="form-select" AutoPostBack="true"></asp:DropDownList>

                                    </div>
                                    <div class="col-lg-6">
                                         <label for="inputstate" class="form-label"> Amount</label>
                                <asp:DropDownList ID="ddlamount" runat="server" CssClass="form-select" AutoPostBack="true">

                                </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-5">
                                <div class="row">
                                    <div class="col-lg-6">
<label for="inputstate" class="form-label"> Last Date of Payment </label>
                                <asp:DropDownList ID="ddllastdate" runat="server" CssClass="form-select" AutoPostBack="true">

                                </asp:DropDownList>

                                    </div>
                                    <div class="col-lg-6">
                                        <label for="inputstate" class="form-label">Rank</label>
                                <asp:DropDownList ID="ddlrank" runat="server" CssClass="form-select" AutoPostBack="true">

                                </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-2">
                                <label for="inputstate" class="form-label"> Installment</label>
                                <asp:DropDownList ID="ddlinstall" runat="server" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlinstall_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                        </div>


                        
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

