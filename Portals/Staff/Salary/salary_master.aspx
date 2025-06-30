<%@ Page Title="" Language="C#" MasterPageFile="~/Portals/Staff/MasterPage.master" AutoEventWireup="true" CodeFile="salary_master.aspx.cs" Inherits="salary_master" EnableEventValidation="false"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="../../../Assets/js/jquery.datetimepicker.js"></script>
    <link href="../../../Assets/css/jquery.datetimepicker.css" rel="stylesheet" />
    <script src="../../../Assets/notify-master/js/notify.js"></script>
    <link href="../../../Assets/notify-master/css/notify.css" rel="stylesheet" />
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
    <script>
        function addressval(e, t) {
            if (window.event) {
                var charCode = window.event.keyCode;
            }
            else if (e) {
                var charCode = e.which;
            }
            else { return true; }
            if ((charCode > 46 && charCode < 58) || (charCode > 64 && charCode < 91) || (charCode > 96 && charCode < 123) || (charCode == 45) || (charCode == 32))
                return true;
            else {
                //alert("enter only alphabets");
                return false;
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main" class="main">
    <div class="panel panel-primary">
        <div class="panel-heading">
            <div class="row">
                <div class="col-md-8">
                    <span style="font-family: Verdana; font-size: 12pt"><strong>Salary Master</strong></span>
                </div>
            </div>
        </div>
        <div class="panel panel-body">
            <div class="row">
                <div class="col-md-3">
                    Employee Id<br />
                    <input name="Employee ID" type="text" id="txt_empid" class="text-uppercase form-control" maxlength="8" />
                </div>
                <div class="col-md-9" runat="server" id="personal">
                    <div class="row">
                        <div class="col-md-4">
                            Employee Name<br />
                            <input type="text" id="txtname" runat="server" class="form-control" disabled="disabled" />
                        </div>
                        <div class="col-md-4">
                            Designation<br />
                            <input type="text" id="txtdes" runat="server" class="form-control" disabled="disabled" />
                        </div>
                        <div class="col-md-4">
                            <br />
                            <div class="row">
                                <div class="col-lg-4">
                                    <input type="button" id="btnadd" value="Define" class="btn btn-success form-control" />
                                </div>
                                <div class="col-lg-4">
                                    <input type="button" id="btnclear" value="Clear" class="btn btn-success form-control" />
                                </div>
                                <div class="col-lg-4">
                                    <input type="button" id="btndelete" value="Delete" class="btn btn-success form-control" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div id="details" style="display: none">
                <div class="row" style="padding-top: 7px;" runat="server">
                    <div class="col-md-3">
                        Qualification<br />
                        <input type="text" runat="server" id="txtqual" class="form-control" />
                    </div>
                    <div class="col-md-3">
                        Pay Scale<br />
                        <input type="text" id="txtscale" runat="server" class="form-control" />
                    </div>
                    <div class="col-md-3">
                        Date of Joining (dd/mm/yyyy)<br />
                        <input type="text" id="txtjoining" runat="server" class="form-control" />
                    </div>
                    <div class="col-md-3">
                        Date of Retirement (dd/mm/yyyy)<br />
                        <input type="text" id="txtretire" runat="server" class="form-control" />
                    </div>
                </div>
                <div class="row" style="padding-top: 7px;" runat="server">
                    <div class="col-md-2">
                        <label class="required">Month</label>
                        <asp:DropDownList ID="ddlappmonth" runat="server" CssClass="form-control">
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
                        <label style="display:none" id="lblmonth"></label>
                        <label style="display:none" id="lblcombined"></label>
                    </div>
                    <div class="col-md-2">
                        <label class="required">Year</label>
                        <asp:DropDownList ID="ddlappyear" runat="server" CssClass="form-control">
                        </asp:DropDownList>
                        <label style="display:none" id="lblyear"></label>
                    </div>
                    <div class="col-md-2">
                        <label class="required">Category</label>
                        <asp:DropDownList ID="ddlcategory" runat="server" CssClass="form-control">
                            <asp:ListItem>--Select--</asp:ListItem>
                            <asp:ListItem Value="1">Teaching</asp:ListItem>
                            <asp:ListItem Value="0">Non-Teaching</asp:ListItem>
                        </asp:DropDownList>
                        <label style="display:none" id="lblid"></label>
                    </div>
                    <div class="col-md-2">
                        Account No.
                        <br />
                        <input type="text" id="txtacno" runat="server" class="form-control" onkeypress="return addressval(event,this);" maxlength="20"/>
                    </div>
                    <div class="col-md-4">
                        Remark
                        <br />
                        <input type="text" id="txtremark" runat="server" class="form-control" />
                    </div>
                </div>
                <div class="row" style="padding-top: 10px">
                    <div class="col-md-12" style="overflow-x: auto">
                        <table id="tblstruct" runat="server" class="table table-responsive table-bordered">
                        </table>
                    </div>
                </div>
            </div>
            <div class="row" style="padding-top: 10px;">
                <div class="col-md-12" style="overflow-x: auto;">
                    <table id="tbldefined" runat="server" class="table table-responsive table-bordered">
                    </table>
                </div>
            </div>
        </div>
    </div>
        </div>
    <script src="../../../Assets/jsForm/SalaryMaster.js?ver<%=DateTime.Now.Ticks.ToString()%>"></script>
    <script>
        var empId = '<%=Session["emp_id"] %>'
    </script>
</asp:Content>

