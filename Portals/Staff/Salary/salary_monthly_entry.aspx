<%@ Page Title="" Language="C#" MasterPageFile="~/Portals/Staff/MasterPage.master" AutoEventWireup="true" CodeFile="salary_monthly_entry.aspx.cs" Inherits="salary_monthly_entry" EnableEventValidation="false"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="../../../Assets/notify-master/js/notify.js"></script>
    <link href="../../../Assets/notify-master/css/notify.css" rel="stylesheet" />
    <script src="../../../Assets/fix-header-top/jquery.fixedTableHeader.js"></script>
    <link href="../../../Assets/css/preloader.css" rel="stylesheet" />
    <style>
        /* Chrome, Safari, Edge, Opera */
        input::-webkit-outer-spin-button,
        input::-webkit-inner-spin-button {
            -webkit-appearance: none;
            margin: 0;
        }

        /* Firefox */
        input[type=number] {
            -moz-appearance: textfield;
        }

        .required:after {
            content: " *";
            color: red;
        }

        .compwidth {
            width: 90px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main" class="main">
    <div class="panel panel-primary" >
        <div class="panel-heading">
            <div class="row">
                <div class="col-md-8">
                    <span style="font-family: Verdana; font-size: 12pt"><strong>Monthly Salary</strong></span>
                </div>
            </div>
        </div>
        <div class="panel panel-body">
            <div class="row">
                <div class="col-md-2">
                    Department
                    <asp:DropDownList ID="ddldept" runat="server" CssClass="form-control drop"></asp:DropDownList>
                </div>
                <div class="col-md-2">
                    Category
                    <asp:DropDownList ID="ddlcategory" runat="server" CssClass="form-control drop">
                        <asp:ListItem>--Select--</asp:ListItem>
                        <asp:ListItem Value="1">Teaching</asp:ListItem>
                        <asp:ListItem Value="0">Non-Teaching</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-md-2">
                    Month
                        <asp:DropDownList ID="ddlappmonth" runat="server" CssClass="form-control drop">
                            <asp:ListItem>--Select--</asp:ListItem>
                            <asp:ListItem Value="1">January</asp:ListItem>
                            <asp:ListItem Value="2">February</asp:ListItem>
                            <asp:ListItem Value="3">March</asp:ListItem>
                            <asp:ListItem Value="4">April</asp:ListItem>
                            <asp:ListItem Value="5">May</asp:ListItem>
                            <asp:ListItem Value="6">June</asp:ListItem>
                            <asp:ListItem Value="7">July</asp:ListItem>
                            <asp:ListItem Value="8">August</asp:ListItem>
                            <asp:ListItem Value="9">September</asp:ListItem>
                            <asp:ListItem Value="10">October</asp:ListItem>
                            <asp:ListItem Value="11">November</asp:ListItem>
                            <asp:ListItem Value="12">December</asp:ListItem>
                        </asp:DropDownList>
                </div>
                <div class="col-md-2">
                    Year
                        <asp:DropDownList ID="ddlappyear" runat="server" CssClass="form-control drop">
                        </asp:DropDownList>
                </div>
                <div class="col-md-1">
                    <br />
                    <input type="button" id="btngetdata" class="btn btn-success form-control" value="New" />
                </div>
                <div class="col-md-1">
                    <br />
                    <input type="button" id="btnedit" class="btn btn-success form-control" value="Edit" />
                </div>
                <div class="col-md-1">
                    <br />
                    <input type="button" id="btnclear" value="Clear" class="btn btn-success form-control" />
                </div>
            </div>
            <div class="row" style="padding-top: 10px">
                <div class="col-md-12" style="overflow-x: auto;overflow-y: auto;height: 400px;">
                    <table id="tblstruct" runat="server" class="table table-responsive table-bordered">
                    </table>
                </div>
            </div>
        </div>
    </div></div>
    <script src="../../../Assets/jsForm/SalaryMonthly.js?ver<%=DateTime.Now.Ticks.ToString()%>"></script>
    <script>
        var empId = '<%=Session["emp_id"] %>'
    </script>
</asp:Content>

