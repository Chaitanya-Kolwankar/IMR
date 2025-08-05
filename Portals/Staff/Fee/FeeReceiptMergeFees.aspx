<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FeeReceiptMergeFees.aspx.cs" Inherits="FeeReceiptMergeFees" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="vendors/bootstrap/dist/css/bootstrap.min.css" rel="stylesheet" />
    <script src="https://code.jquery.com/jquery-latest.min.js"></script>
    <script src="https://code.jquery.com/jquery-migrate-1.2.1.js"></script>
    <script src="vendors/bootstrap/dist/js/bootstrap.js"></script>
    <script src="js/jquery-min.js"></script>
    <script src="notify-master/js/jquery-1.11.0.js"></script>
    <script src="js/jquery.qrcode.min.js"></script>
    <script src="js/jquery-barcode.js"></script>
    <style>
        @page {
            size: A4;
        }

        .watermark {
            color: #d0d0d0;
            position: absolute;
            margin-top: 260px;
            height: 100px;
            margin-bottom: 190px;
            margin-left: 110px;
            margin-right: 110px;
            z-index: 100;
            opacity: 0.2;
        }

        .watermark img{
            height:550px;
            width:100%;
            margin-top:40px
        }

        .table > thead > tr > th, .table > tbody > tr > th, .table > tfoot > tr > th, .table > thead > tr > td, .table > tbody > tr > td, .table > tfoot > tr > td {
            padding: 0.156em;
            border: 1px solid black;
            margin-bottom: -20px;
            border: 1px solid;
        }

        .upperFont {
            font-size: 15px;
        }

        table th {
            text-align: center;
        }

        .itemCss {
            margin-left: 5px;
            font-size: 8px;
        }

        .p-5 {
            padding: 5px;
        }
    </style>
    <style>
        @media print {
            @page {
                size: A4 landscape;
                margin: 3mm;
            }

            body {
                margin: 0;
                -webkit-print-color-adjust: exact;
                print-color-adjust: exact;
                font-family: Arial, sans-serif;
            }

            .print-wrapper {
                display: flex;
                justify-content: space-between;
                align-items: flex-start;
                width: 100%;
                page-break-inside: avoid;
            }

            .receipt-copy {
                flex: 1;
                border: 1px solid #000;
                padding: 8px;
                margin: 2px 5px;
                box-sizing: border-box;
                font-size: 12px;
            }

            table {
                width: 100%;
                table-layout: fixed;
                word-wrap: break-word;
            }
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid">
            <div class="row">

                <div class="print-wrapper" id="receipt-original">
                    <div class="receipt-copy">
                        <div class="col-lg-12 col-sm-12">
                            <div class="watermark">
                                <img src="../../../Assets/img/mu.png" style="opacity: 0.3;" />
                            </div>
                            <div class="container" style="width: 100%">
                                <div class="row">
                                    <div class="row" style="margin-top: 8px;">
                                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                            <img src="../../../Assets/img/RJC.png" />
                                        </div>
                                    </div>
                                </div>
                                <hr style="border-color: black;" />

                                <div style="width: 100%; max-width: 800px; margin: auto; border: 2px solid #000; font-family: Arial, sans-serif; font-size: 14px; padding: 15px; box-sizing: border-box;">

                                    <div style="display: grid; grid-template-columns: 2fr 1fr 1fr; gap: 8px 16px; font-size: 14px;">
                                        <div><b>Rec No:</b>
                                            <asp:Label ID="lblNo" runat="server" Text=""></asp:Label></div>
                                       <%-- <div><b>Adm. No:</b>
                                            <asp:Label ID="lbl_admno" runat="server" Text=""></asp:Label></div>--%>
                                        <div><b>Date:</b>
                                            <asp:Label ID="lbl_date" runat="server" Text=""></asp:Label></div>

                                        <div><b>Class:</b>
                                            <asp:Label ID="lblcourse" runat="server" Text=""></asp:Label></div>
                                        <%--<div><b>Section:</b>
                                            <asp:Label ID="lbl_section" runat="server" Text=""></asp:Label></div>--%>
                                        <div><b>Student ID:</b>
                                            <asp:Label ID="lbl_stud_id" runat="server" Text=""></asp:Label></div>

                                        <div><b>Category:</b>
                                            <asp:Label ID="lblcategory" runat="server" Text=""></asp:Label></div>
                                        <div><b>Roll No:</b>
                                            <asp:Label ID="lbl_rollno" runat="server" Text=""></asp:Label></div>
                                        <div><b>Fee Type:</b>
                                            <asp:Label ID="lbl_feetype" runat="server" Text=""></asp:Label></div>
                                        <div style="grid-column: span 3;"><b>Name:</b>
                                            <asp:Label ID="lblName" runat="server" Text=""></asp:Label></div>
                                    
                                        </div>
                                    <table style="width: 100%; border-top: 2px solid #000; border-bottom: 1px solid #000; border-collapse: collapse; margin-top: 5px;">
                                        <tr style="background-color: #f2f2f2;">
                                            <th style="text-align: left; padding: 5px;">Received the following</th>
                                            <th style="text-align: right; padding: 5px;">(₹) Amount</th>
                                        </tr>
                                    </table>

                                     <div class="row" style="height:550px">
                                     <asp:GridView ID="gridstructre" CssClass="table" AutoGenerateColumns="false" runat="server">
                                    <Columns>
                                        <asp:BoundField DataField="Struct_name" ItemStyle-Font-Size="15px" ItemStyle-CssClass="itemCss" ItemStyle-VerticalAlign="Middle" HeaderText="PARTICULARS" HeaderStyle-HorizontalAlign="left" ControlStyle-Font-Size="15px" />
                                        <asp:BoundField DataField="Amount" ItemStyle-Font-Size="15px" ItemStyle-VerticalAlign="Middle" ItemStyle-CssClass="itemCss" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderText="AMOUNT (IN Rs.)" ControlStyle-Font-Size="15px" />
                                    </Columns>
                                </asp:GridView>
                                </div>

                                    <table style="width: 100%; border-top: 2px solid #000; border-collapse: collapse; margin-top: 5px;">
                                        <tr>
                                            <td style="padding: 8px;"><b>Total:</b></td>
                                            <td style="text-align: right; padding: 8px;">
                                                <b>₹ 
                                                <asp:Label Id="amt_no" runat="server" Text=""></asp:Label>
                                                    </b>
                                            </td>
                                        </tr>
                                    </table>

                                    <div style="margin-top: 15px; font-size: 13px; line-height: 1.5; padding: 12px; border: 1px solid #ccc; border-radius: 6px;">

                                        <p style="margin-bottom: 6px;"><b>In Words:</b>
                                            <asp:Label ID="lblamount" runat="server" Text=""></asp:Label></p>
                                        <table style="width: 100%; border-collapse: collapse;">
                                           <%-- <tr>
                                                <td><b>Medium:</b>
                                                    <asp:Label ID="lblmedium" runat="server" Text=""></asp:Label>
                                                </td>
                                                <td><b>Subject:</b> 
                                                    <asp:Label ID="lblSubjects" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>--%>
                                            <tr>
                                                <td><b>Payment Mode:</b> 
                                                    <asp:Label ID="lbl_payment_mode" runat="server" Text=""></asp:Label>
                                                </td>
                                                <td><b>Transaction ID:</b>
                                                    <asp:Label ID="lbltrans_id" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td><b>Bank Name: </b>
                                                    <asp:Label ID="lbl_bank_name" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2"><b>Remarks:</b> 
                                                    <asp:Label ID="lblremark" runat="server" Text="Payment for Academic Term 2025-2026"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                        <div style="text-align: right; margin-bottom: 15px;">
                                            <div style="display: inline-block; border-top: 1px solid #000; padding-top: 5px;">
                                                <b>RECEIVER'S SIGNATURE</b>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <br />

                               
                            </div>
                        </div>
                    </div>


                    <div class="receipt-copy" id="receipt-clone">
                    </div>
                </div>
            </div>
        </div>
    </form>

    <script>
        window.onload = function () {
            document.getElementById("receipt-clone").innerHTML =
                document.querySelector("#receipt-original .receipt-copy").innerHTML;
            window.print();
        };
    </script>
</body>
</html>
