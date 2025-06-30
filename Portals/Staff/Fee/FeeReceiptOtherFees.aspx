<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FeeReceiptOtherFees.aspx.cs" Inherits="FeeReceiptOtherFees" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <%--<link href="vendors/bootstrap/dist/css/bootstrap.min.css" rel="stylesheet" />--%>
    <link href="../../../assets/vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <script src="../../../assets/vendor/bootstrap/js/bootstrap.bundle.min.js"></script>
    <script src="https://code.jquery.com/jquery-latest.min.js"></script>
    <script src="https://code.jquery.com/jquery-migrate-1.2.1.js"></script>
    <%--<script src="vendors/bootstrap/dist/js/bootstrap.js"></script>
    <script src="js/jquery-min.js"></script>
    <script src="notify-master/js/jquery-1.11.0.js"></script>
    <script src="js/jquery.qrcode.min.js"></script>
    <script src="js/jquery-barcode.js"></script>--%>
    <style>
        .font-bold {
            font-weight: bold;
        }

        .upperFont {
            font-weight: bold;
            font-size: 11px;
        }

        #lblamount, #lblmode, #lblremark{
             font-weight: bold;
        }

        .watermark {
            color: #d0d0d0;
            position: absolute;
            margin-top: 260px;
            height: 180px;
            margin-bottom: 100px;
            margin-left: 130px;
            margin-right: 60px;
            z-index: 100;
            opacity: 0.2;
        }

        .table > thead > tr > th, .table > tbody > tr > th, .table > tfoot > tr > th, .table > thead > tr > td, .table > tbody > tr > td, .table > tfoot > tr > td {
            padding: 0.156em;
            border: 1px solid black;
            margin-bottom: -20px;
        }

         .tablenew > thead > tr > th, .table > tbody > tr > th, .table > tfoot > tr > th, .table > thead > tr > td, .table > tbody > tr > td, .table > tfoot > tr > td {
            border: 1px solid black;
        }

        .itemCss {
            margin-left: 5px;
            font-size: 8px;
        }
    </style>

    <style>
        .vertical_dotted_line {
            border-right: 1px solid black;
            height: 100%;
        }

        #GridView1 > tbody > tr:last-child {
            font-weight: bold !important;
        }

        #GridView2 > tbody > tr:last-child {
            font-weight: bold !important;
        }

        #grd_installment2 > tbody > tr {
            font-weight: bold !important;
        }

        #grd_installment > tbody > tr {
            font-weight: bold !important;
        }

        @page {
            size: A4;
        }

        table th {
            text-align: center;
        }

        hr {
            margin-bottom:0px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-12 col-sm-12" style="border: 1px solid black;">
                    <div class="watermark">
                        <img src="../../../assets/img/vivalogon.png" style="height: 440px" />
                    </div>
                    <div class="container" style="width: 100%">
                        <div class="row" style="text-align: center">
                            <br />
                            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                                <img src="../../../assets/img/vivalogon.png" class="pull-right" style="width: 90px; height: 90px" alt="" />
                            </div>
                            <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9 " style="text-align: initial;text-align:center">
                                <span style="font-size: 15px;"><b runat="server" id="lbl_header">Vishnu Waman Thakur Charitable Trust's</b></span><br />
                                <span style="font-size: 18px;"><b>VIVA Institute of Management and Research</b></span><br />
                                <span style="font-size: 15px;"><b>Shirgaon, Kumbharpada, Virar (E), Tal. Vasai, Dist.Palghar</b></span><br />
                                <span style="font-size: 15px;"><b>Pin.-401305 Tel No.: 7770002544</b></span><br />
                            </div>
                        </div>
                        <hr style="border-color: black" />
                        <div class="row" style="font-size: 15px">
                            <div class="container upperFont">
                                <div style="padding: 0px; float: left">
                                    <span style="font-size: 15px">Receipt No:</span>
                                    <span style="margin-left: 10px; font-size: 15px">
                                        <asp:Label ID="lblNo" runat="server" Text=""></asp:Label></span>
                                    <asp:Label ID="lbl_barcode" runat="server" Style="display: none"></asp:Label>
                                </div>
                                <div style="padding: 0px; float: right">
                                    <span style="font-size: 15px">Date:</span>
                                    <span style="margin-left: 10px; font-size: 15px">
                                        <asp:Label ID="lbl_date" runat="server" Text=""></asp:Label></span>
                                </div>
                            </div>
                            <div class="container">
                                <div class="col-lg-12" style="padding: 0px;">
                                    <span style="padding-left: 60px;">Received from Shri/Smt./Kum.</span>
                                    <b><span style="margin-left: 10px;">
                                        <asp:Label ID="lblName" runat="server" Text=""></asp:Label>
                                    </span></b>

                                    <span style="font-size: 15px">towards other fees the amount of Rs.</span>
                                    <span style="margin-left: 10px;">
                                        <asp:Label ID="lblamount" runat="server" Text=""></asp:Label>
                                        for this course 
                                         <asp:Label ID="lblmode" runat="server"></asp:Label></span>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-lg-6">
                                    <asp:Label ID="lblremark" runat="server" Text="" Visible="false" Style="font-size: 15px"></asp:Label>
                                </div>
                            </div>
                            <br />

                            <div class="row" style="font-size: 15px; margin-bottom: -21px; margin: 0px">
                                <asp:GridView ID="GridView2" CssClass="table tablenew" AutoGenerateColumns="false" runat="server">
                                    <Columns>
                                        <asp:BoundField DataField="Struct_name" ItemStyle-Font-Size="15px" ItemStyle-CssClass="itemCss" ItemStyle-VerticalAlign="Middle" HeaderText="PARTICULARS" ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="left" ControlStyle-Font-Size="15px" />
                                        <asp:BoundField DataField="Amount" ItemStyle-Font-Size="15px" ItemStyle-VerticalAlign="Middle" ItemStyle-CssClass="itemCss" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderText="AMOUNT Rs." ControlStyle-Font-Size="15px" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                            <div class="row">
                                <div class="col-lg-12" style="font-size: 15px;">
                                    <center><b><u>Payment Details</u></b></center>
                                </div>
                            </div>
                            <br />
                            <div class="row" style="margin-bottom: -21px; margin: 0px">
                                <asp:GridView ID="GridView1" CssClass="table tablenew" AutoGenerateColumns="false" runat="server">
                                    <Columns>
                                        <asp:BoundField DataField="Recpt_mode" ItemStyle-Font-Size="15px" ItemStyle-CssClass="itemCss" ItemStyle-VerticalAlign="Middle" HeaderText="Payment Mode" ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="left" ControlStyle-Font-Size="15px" />
                                        <asp:BoundField DataField="Recpt_Bnk_Name" ItemStyle-Font-Size="15px" ItemStyle-VerticalAlign="Middle" ItemStyle-CssClass="itemCss" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderText="Bank Name" ControlStyle-Font-Size="15px" />
                                        <asp:BoundField DataField="Recpt_Bnk_Branch" ItemStyle-Font-Size="15px" ItemStyle-CssClass="itemCss" ItemStyle-VerticalAlign="Middle" HeaderText="Branch Name" ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="left" ControlStyle-Font-Size="15px" />
                                        <asp:BoundField DataField="Recpt_Chq_dt" ItemStyle-Font-Size="15px" ItemStyle-VerticalAlign="Middle" ItemStyle-CssClass="itemCss" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderText="Date" ControlStyle-Font-Size="15px" />
                                        <asp:BoundField DataField="Amount" ItemStyle-Font-Size="15px" ItemStyle-VerticalAlign="Middle" ItemStyle-CssClass="itemCss" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderText="Amount" ControlStyle-Font-Size="15px" />
                                    </Columns>
                                </asp:GridView>
                            </div>

                            <div class="row">
                                <div class="col-lg-3"></div>
                                <div class="col-lg-2"></div>
                                <%--<div class="col-lg-7" id="lastdiv" runat="server" style="float:right"><span style="font-size: 15px">For VIVA Institute Of Technology</span></div>--%>
                            </div>
                            <div class="row">
                                <div class="col-lg-6">
                                    <asp:Label ID="lblautho" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="upperFont">
                            <div class="col-lg-12">
                                * Computer Generated Report Does Not Required Signature.
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
    <script type="text/javascript">
        window.onload = function () {
            window.print();
        }
    </script>
</body>
</html>
