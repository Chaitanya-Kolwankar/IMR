<%@ Page Title="" Language="C#" MasterPageFile="~/Portals/Staff/MasterPage.master" AutoEventWireup="true" CodeFile="FeeReport.aspx.cs" Inherits="Portals_Staff_Fee_FeeReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="../../../Assets/notify-master/js/notify.js"></script>
    <link href="../../../Assets/notify-master/css/notify.css" rel="stylesheet" />
    <script src="../../../Assets/js/jquery.datetimepicker.js"></script>

    <style>
        .multiselect {
            width: 100%;
            margin-top: 5px;
            border: 1px solid #ced4da;
        }

        .multiselect-container {
            height: 350px;
            width: 100%;
            overflow: scroll;
        }

        .btn-group {
            width: 100%;
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

        .redcolor {
            color: red;
        }

        .chkbxx {
            height: 50px;
            width: 40px;
        }

        .caps {
            text-transform: capitalize;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main" class="main">
        <div class="container-fluid">
            <div class="pagetitle " style="font-size: 32px; margin-left: 34px; font-weight: 300; color: #012970;">
                Fee Report
            </div>
            <div class="card">
                <div class="card-title mx-4">
                    Fee Report
                </div>
                <div class="card-body">
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
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
                                    <%--<div class="col-lg-2">
                                        <label for="inputState" class="form-label">Select Category:</label>
                                        <asp:DropDownList ID="ddlcat" runat="server" AutoPostBack="true" CssClass="form-select" OnSelectedIndexChanged="ddlcat_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>--%>
                                    <div class="col-lg-2">
                                        <label for="inputState" class="form-label">Select Group:</label>
                                        <asp:DropDownList ID="ddlgroup" runat="server" AutoPostBack="true" CssClass="form-select" OnSelectedIndexChanged="ddlgroup_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>

                                    <%--<div class="col-2">
                                        <div class="col-lg-4">
                                                <span>Data In</span>
                                            </div>
                                        <asp:RadioButton runat="server" ID="rdb_detl" Text="Detailed" GroupName="Category" OnCheckedChanged="rdb_detl_CheckedChanged" AutoPostBack="true" />

                                    </div>
                                    <div class="col-2">
                                        <asp:RadioButton runat="server" ID="rdb_sumar" Text="Summarized" GroupName="Category" OnCheckedChanged="rdb_sumar_CheckedChanged" AutoPostBack="true" />
                                    </div>--%>
                                    <div class="col-6">
                                        <fieldset>
                                            <span class="m-3">Data In:</span>
                                            <div class="row mx-3 my-3">
                                                <div class="col-lg-3">
                                                    <asp:RadioButton runat="server"
                                                        ID="rdb_detl"
                                                        Text="Detailed"
                                                        GroupName="Category"
                                                        OnCheckedChanged="rdb_detl_CheckedChanged"
                                                        AutoPostBack="true" />
                                                </div>

                                                <div class="col-lg-3">
                                                    <asp:RadioButton runat="server"
                                                        ID="rdb_sumar"
                                                        Text="Summarized"
                                                        GroupName="Category"
                                                        OnCheckedChanged="rdb_sumar_CheckedChanged"
                                                        AutoPostBack="true" />
                                                </div>
                                            </div>
                                        </fieldset>
                                    </div>


                                    <asp:HiddenField runat="server" ID="ddlcategory" />


                                </div>
                                <br />
                                <div class="row d-flex justify-content-center">
                                    <div class="col-lg-2">
                                        <asp:Button ID="btngtdata" Text="Get Data" OnClick="btngtdata_Click" runat="server" CssClass="mt-1 form-control btn btn-primary btn-block" />
                                    </div>
                                    <div class="col-lg-2">
                                        <asp:Button ID="btnclear" runat="server" Text="Clear" OnClick="btnclear_Click" CssClass="mt-1 form-control btn btn-primary btn-block" />
                                    </div>
                                    <div class="col-lg-2">
                                        <asp:Button ID="btnexcel" runat="server" Text="Get Excel" OnClick="btnexcel_Click" CssClass="mt-1 form-control btn btn-success btn-block" />
                                    </div>
                                </div>

                                <div id="scrll" style="width: 100%; overflow-x: auto;margin-top:30px">
                                    <asp:GridView ID="grd" runat="server" AutoGenerateColumns="True" HeaderStyle-CssClass="FixedHeader" HeaderStyle-BackColor="white">
                                    </asp:GridView>
                                </div>
                                <div>
                                </div>
                            </div>
                        </ContentTemplate>
                        <Triggers>
                            <asp:PostBackTrigger ControlID="btngtdata" />
                            <asp:PostBackTrigger ControlID="btnexcel" />
                            <asp:PostBackTrigger ControlID="btnclear" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>
    <script>
       <%-- var prm = Sys.WebForms.PageRequestManager.getInstance();

        prm.add_endRequest(function () {
            createDataTable();
        });

        createDataTable();
        //"order": [[0, "desc"]]
        function createDataTable() {
            $('#<%= grd.ClientID %>').DataTable({
             
            
           });

       }--%>


        createDataTable();
        function createDataTable() {
            $('#<%= grd.ClientID %>').DataTable({


            });
        }

        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(function () {
            datepic();
            createDataTable();
        });


        function notify(msg, type) {
            $.notify(msg, { type: type, animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.2, delay: 0 });
        }
        datepic();
        function datepic() {
            $('[id*=txtfrmdate]').datetimepicker(
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

            $('[id*=txttodate]').datetimepicker(
                {
                    changeMonth: false,
                    changeYear: false,
                    timepicker: false,
                    format: 'd/M/Y',
                    viewMode: "months",
                    minViewMode: "months",
                    //maxDate: 0
                    //endDate: "+0m"
                });
        }
    </script>
</asp:Content>

