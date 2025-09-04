<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Installment_Receipt.aspx.cs" Inherits="Portals_Staff_Fee_Installment_Receipt" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>RGCMS | Staff Receipt</title>
    <link href="<%= ResolveUrl("~/Assets/img/mu.png") %>" rel="icon" />
    <link href="<%= ResolveUrl("~/Assets/img/mu.png") %>" rel="apple-touch-icon" />
    <script src="https://code.jquery.com/jquery-latest.min.js"></script>
    <link href="<%= ResolveUrl("~/Assets/notify-master/css/notify.css") %>" rel="stylesheet" />
    <script src="<%= ResolveUrl("~/Assets/notify-master/js/notify.js") %>"></script>
    <style>
        @page {
            size: A4;
        }

        .watermark {
            color: #d0d0d0;
            position: absolute;
            margin-top: 330px;
            height: 50px;
            margin-left: 180px;
            z-index: 100;
            opacity: 0.1;
            text-align: center;
        }

            .watermark img {
                height: 550px;
                width: 100%;
                margin-top: 40px
            }

        .table > thead > tr > th, .table > tbody > tr > th, .table > tfoot > tr > th, .table > thead > tr > td, .table > tbody > tr > td, .table > tfoot > tr > td {
            padding: 0.3em;
            /*margin-bottom: -20px;*/
            border: 1px solid gray;
        }

        .upperFont {
            font-size: 15px;
        }

        table th {
            text-align: center;
        }

        .table td:first-child {
            padding: 0 0 0 4px;
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
                padding: 0 8px;
                margin: 2px 10px;
                box-sizing: border-box;
                font-size: 14px;
            }

            table {
                width: 100%;
                table-layout: fixed;
                word-wrap: break-word;
            }

            #grd_install th {
                font: 16px;
            }

            #grd_install td {
                font: 14px;
                padding: 10px 14px 10px 14px;
            }

                #grd_install td:first-child {
                    font-size: 14px;
                    padding: 4px;
                    width: 5px !important;
                    padding: 10px 14px 10px 14px;
                }

                #grd_install th:first-child {
                    font-size: 14px;
                    padding: 4px;
                    width: 35px !important;
                    padding: 10px 14px 10px 14px;
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
                                <img src="../../../Assets/img/mu.png" style="height: 400px" />
                            </div>
                            <div class="container" style="width: 100%">
                                <div class="row">
                                    <div class="row" style="margin-top: 8px;">
                                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                            <img src="../../../Assets/img/RJC.png" style="width: 790px;" />
                                        </div>
                                    </div>
                                </div>
                                <hr style="border-color: black;" />

                                <div style="width: 100%; max-width: 800px; margin: auto; border: 2px solid #000; font-family: Arial, sans-serif; font-size: 14px; padding: 15px; box-sizing: border-box;">
                                    <div style="display: grid; grid-template-columns: 2fr 1fr 1fr; gap: 8px 14px; font-size: 14px;">
                                        <div>
                                            <b>Date:</b>
                                            <asp:Label ID="lbl_date" runat="server" Text=""></asp:Label>
                                        </div>
                                        <div>
                                            <b>Class:</b>
                                            <asp:Label ID="lblcourse" runat="server" Text=""></asp:Label>
                                        </div>
                                        <div>
                                            <b>Student ID:</b>
                                            <asp:Label ID="lbl_stud_id" runat="server" Text=""></asp:Label>
                                        </div>

                                        <div>
                                            <b>Category:</b>
                                            <asp:Label ID="lblcategory" runat="server" Text=""></asp:Label>
                                        </div>
                                        <div>
                                            <b>Roll No:</b>
                                            <asp:Label ID="lbl_rollno" runat="server" Text=""></asp:Label>
                                        </div>
                                        <div style="grid-column: span 3;">
                                            <b>Name:</b>
                                            <asp:Label ID="lblName" runat="server" Text=""></asp:Label>
                                        </div>

                                    </div>
                                    <table style="width: 100%; border-top: 2px solid #000; border-bottom: 1px solid #000; border-collapse: collapse; margin-top: 5px; font-size: 16px;">
                                        <tr style="background-color: #f2f2f2;">
                                            <th style="text-align: left; padding: 5px;">Fee Payment Schedule Terms & Conditions</th>
                                        </tr>
                                    </table>
                                    <div class="row" style="height: 64vh; padding: 0 2px 0 2px">
                                        <div class="table-responsive">
                                            <br />
                                            <asp:GridView ID="grd_install" runat="server" AutoGenerateColumns="false" CssClass="table" Width="100%">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Sr.no">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_sr_no" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle Width="5%" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="installemntId" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Install_id" runat="server" Text='<%# Eval("Install_id") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle Width="19%" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Installment No">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_install_no" runat="server" Text='<%# (Container.DataItemIndex + 1) +" ("+ getnum(Container.DataItemIndex + 1)+")" %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle Width="19%" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Due Date">
                                                        <ItemTemplate>
                                                            <div style="display: flex; align-items: center; gap: 6px;">
                                                                <asp:Label ID="Due_date" runat="server" Text='<%# Eval("Due_date") %>'></asp:Label>
                                                            </div>
                                                        </ItemTemplate>
                                                        <ItemStyle Width="19%" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Installment Amount">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Install_Amount" runat="server" Text='<%# Eval("Install_Amount") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle Width="19%" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Installment Balance">
                                                        <ItemTemplate>
                                                            <asp:Label ID="balance_Amount" runat="server" Text='<%# Eval("balance_Amount") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle Width="19%" />
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                        <div>
                                            <br />
                                            <br />
                                            <div style="font-size: 16px; font-weight: bold; margin-bottom: 10px;">TERMS & CONDITIONS</div>
                                            <ul style="font-size: 14px; line-height: 1.6; list-style-position: outside; padding-left: 18px;">
                                                <li style="margin-bottom: 12px;">
                                                    <strong>Fee Payment Undertaking:</strong>
                                                    I hereby confirm that I will adhere to the above-mentioned fee payment schedule.  
    In the event of delayed payment, RGCMS reserves the right to levy late payment charges @ Rs.10/- per day from the due date of instalment.  
                                                </li>
                                                <li style="margin-bottom: 12px;">
                                                    <strong>Additional Terms:</strong>
                                                    If I discontinue the course within the academic year, I understand that I will be liable to pay the full fees for that academic year.  
                                                </li>
                                            </ul>
                                        </div>
                                    </div>
                                    <div style="text-align: right; margin-bottom: 15px; font-size: 14px;">
                                        <div style="display: inline-block; border-top: 1px solid #000; padding-top: 5px;">
                                            <span class="copy-label"><b>RECEIVER'S SIGNATURE</b></span>
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

            var cloneLabel = document.querySelector("#receipt-clone .copy-label b");
            if (cloneLabel) {
                cloneLabel.textContent = "ACCOUNTANT SIGNATURE";
            }
        };
    </script>
</body>
</html>
