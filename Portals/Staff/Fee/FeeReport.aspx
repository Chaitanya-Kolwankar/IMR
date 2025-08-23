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
                                        <label for="inputState" class="form-label">From Date</label>
                                        <asp:TextBox ID="txtfrmdate" runat="server" autocomplete="off" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-2">
                                        <label for="inputState" class="form-label">To Date</label>
                                        <asp:TextBox ID="txttodate" runat="server" autocomplete="off" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-2">
                                        <label for="inputState" class="form-label">Select Category:</label>
                                        <asp:DropDownList ID="ddlcat" runat="server" AutoPostBack="true" CssClass="form-select" OnSelectedIndexChanged="ddlcat_SelectedIndexChanged">
                                            <asp:ListItem>--Select--</asp:ListItem>
                                            <asp:ListItem>OPEN</asp:ListItem>
                                            <asp:ListItem>Other</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <asp:HiddenField runat="server" ID="ddlcategory" />
                                    <div class="col-lg-1" style="margin-top: 32px">
                                        <asp:Button ID="btngtdata" Text="Get Data" OnClick="btngtdata_Click" runat="server" CssClass="form-control btn btn-primary btn-block" />
                                    </div>
                                    <div class="col-lg-1" style="margin-top: 32px">
                                        <asp:Button ID="btnclear" runat="server" Text="Clear" OnClick="btnclear_Click" CssClass="form-control btn btn-primary btn-block" />
                                    </div>


                                    <div class="col-lg-1" style="margin-top: 32px">
                                        <asp:Button ID="btnexcel" runat="server" Text="Get Excel" OnClick="btnexcel_Click" CssClass="form-control btn btn-primary btn-block" />
                                    </div>

                                </div>
                                <br />

                                <div id="scrll" style="width: 100%; overflow-x: auto">
                                    <asp:GridView ID="grd" runat="server" OnDataBound="grd_DataBound" AutoGenerateColumns="false" HeaderStyle-CssClass="FixedHeader" HeaderStyle-BackColor="white">
                                        <Columns>
                                            <asp:BoundField DataField="stud_id" ItemStyle-CssClass="caps" HeaderText="Student ID" />
                                            <asp:BoundField DataField="NAME" ItemStyle-CssClass="caps" HeaderText="Student Name" />
                                            <asp:BoundField DataField="Group_title" HeaderText="Course Name" />
                                            <asp:BoundField DataField="paydate" HeaderText="Payment Date" />
                                            <asp:BoundField DataField="receipt_No" HeaderText="Receipt No." />
                                            <asp:BoundField DataField="structure" HeaderText="Structure" />
                                            <asp:BoundField DataField="Amount" HeaderText="Amount" />
                                            <asp:BoundField DataField="Recpt_mode" HeaderText="Payment Mode" />
                                            <asp:BoundField DataField="Recpt_Chq_No" HeaderText="Cheque No." />
                                            <asp:BoundField DataField="Cheque_dt" HeaderText="Cheque Date" />
                                            <asp:BoundField DataField="Bank_details" HeaderText="Bank Details" />
                                            <asp:BoundField DataField="stud_Category" HeaderText="Category" />
                                            <asp:BoundField DataField="duration" HeaderText="Duration" />
                                            <asp:BoundField DataField="Total" HeaderText="Total" />
                                            <asp:BoundField DataField="Paid" HeaderText="Total Paid" />
                                            <asp:BoundField DataField="Balance" HeaderText="Balance" />
                                        </Columns>
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

