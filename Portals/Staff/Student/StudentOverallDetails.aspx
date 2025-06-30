<%@ Page Title="" Language="C#" MasterPageFile="~/Portals/Staff/MasterPage.master" AutoEventWireup="true" CodeFile="StudentOverallDetails.aspx.cs" Inherits="Portals_Staff_Student_StudentOverallDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">


    <style>
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

        .pascal {
            text-transform: capitalize;
        }

        .FixedHeader {
            position: sticky;
            font-weight: bold;
            top: 0;
        }
    </style>

    <link href="http://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/css/bootstrap.min.css"
        rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="http://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/js/bootstrap.min.js"></script>
    <link href="http://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/css/bootstrap-multiselect.css"
        rel="stylesheet" type="text/css" />
    <script src="http://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/js/bootstrap-multiselect.js"
        type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="main" id="main">
        <div class="container-fluid">
            <div class="pagetitle" style="font-size: 29px; margin-left: 34px; font-weight: 300; color: #012970;">
                Student Overall Details
            </div>
            <div class="container-fluid">
                <div class="card">
                    
                    <div class="card-title mx-4">
                        Student Overall Details
                    </div>
                    <div class="card-body">                       
                                <div class="row my-2">
                                            <div class="col-lg-2">
                                                <label for="inputstate" class="form-label">
                                                    Course
                                                </label>
                                                <asp:DropDownList ID="ddlcourse" runat="server" AutoPostBack="true" Class="form-select" OnSelectedIndexChanged="ddlcourse_SelectedIndexChanged"></asp:DropDownList>
                                            </div>                                  
                                    <div class="col-lg-2">
                                        <label for="inputstate" class="form-label" style="margin-top: 22px;">
                                            Report Type
                                        </label>
                                        <asp:ListBox ID="lstreporttype" Class="form-control" SelectionMode="Multiple" runat="server" OnSelectedIndexChanged="lstreporttype_SelectedIndexChanged" AutoPostBack="true">
                                            <asp:ListItem Text="Personal" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Fee Details" Value="2"></asp:ListItem>
                                        </asp:ListBox>
                                    </div>
                                    <div class="col-lg-2">
                                        <label for="inputstate" class="form-label" style="margin-top: 22px;">
                                            Select Fields
                                        </label>
                                        <asp:ListBox ID="lstselectfields" Class="form-control" SelectionMode="Multiple" runat="server" OnSelectedIndexChanged="lstselectfields_SelectedIndexChanged" AutoPostBack="true"></asp:ListBox>
                                    </div>
                                    <div class="col-lg-2">
                                        <asp:Button ID="btngetdata" runat="server" Text="Get Data" CssClass="form-control btn btn-primary" OnClick="btngetdata_Click" Style="margin-top: 31px" />
                                    </div>
                                    <div class="col-lg-2">
                                        <asp:Button ID="btnclear" runat="server" Text="Clear" CssClass="form-control btn btn-primary" Style="margin-top: 31px" />
                                    </div>
                                    <div class="col-lg-2">
                                        <asp:Button ID="btnexcel" runat="server" Text="Excel" CssClass="form-control btn btn-primary" onclick="btnexcel_Click" Style="margin-top: 31px" />
                                    </div>
                                </div>            
                        
                        
                        
                                    
                        <div style="max-height: 400px; width: 100%; overflow: auto">
                            <asp:GridView ID="grd" runat="server" AutoGenerateColumns="true" HeaderStyle-CssClass="FixedHeader" HeaderStyle-BackColor="White" Style="overflow: auto; max-height: 400px;">
                          
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script>
        $(function () {
            $('[id*=lstreporttype]').multiselect({
                includeSelectAllOption: true

            });
        });
        $(function () {
            $('[id*=lstselectfields]').multiselect({
                includeSelectAllOption: true
            });
        });


    </script>

</asp:Content>

