<%@ Page Title="" Language="C#" MasterPageFile="~/Portals/Staff/MasterPage.master" AutoEventWireup="true" CodeFile="StudentCancellation.aspx.cs" Inherits="Portals_Staff_Admission_StudentCancellation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script src="../../../Assets/js/jquery.datetimepicker.js"></script>
    <link href="../../../Assets/css/jquery.datetimepicker.css" rel="stylesheet" />


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="main" id="main">

        <div class="container-fluid">
            <div class="pagetitle " style="font-size: 32px; margin-left: 34px; font-weight: 300; color: #012970;">
                Admission
            </div>

            <div class="container-fluid">
                <div class="card">
                    <div class="card-title mx-4">Student Cancellation</div>

                    <div class="card-body">
                        <div class="container-fluid">




                            <div class="row">
                                <div class="col-lg-2">
                                    <label for="inputState" class="form-label">
                                        Student ID
                                    </label>

                                    <asp:TextBox ID="txtstudid" runat="server" onKeyPress="return OnlyNum(event)" MaxLength="20" oncopy="return false"
autocomplete="off" 
 CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-lg-2">
                                    <asp:LinkButton runat="server" ID="lbsearch" OnClick="lbsearch_Click" CssClass=" btn btn-primary" Style="margin-top: 33px;"><i class="bi bi-search"></i></asp:LinkButton>
                                </div>
                                <div class="col-lg-2">
                                    <asp:LinkButton runat="server" Text="Get Report" ID="lbgetreport" CssClass="btn  btn-primary" Style="margin-top: 33px;"><i class="bi bi-download"></i>&nbsp  Get Report</asp:LinkButton>
                                </div>
                            </div>
                            <div class="row my-4">
                                <div class="col-lg-4">

                                    <label for="inputState" class="form-label">
                                        Name
                                    </label>
                                    <asp:TextBox ID="txtname" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                </div>
                                <div class="col-lg-2">
                                    <label for="inputState" class="form-label">
                                        Course
                                    </label>
                                    <asp:TextBox ID="txtcou" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                </div>
                                <div class="col-lg-2">
                                    <label for="inputState" class="form-label">
                                        Class
                                    </label>
                                    <asp:TextBox ID="txtclass" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                </div>
                                <div class="col-lg-2">
                                    <label for="inputState" class="form-label">
                                        Course Fees
                                    </label>
                                    <asp:TextBox ID="txtcoufees" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                </div>
                                <div class="col-lg-2">
                                    <label for="inputState" class="form-label">
                                        Paid
                                    </label>
                                    <asp:TextBox ID="txtpaid" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-2">
                                    <label for="inputState" class="form-label">
                                        Fees Status
                                    </label>
                                    <asp:TextBox ID="txtfeestat" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                </div>
                                <div class="col-lg-2">
                                    <label for="inputState" class="form-label">
                                        Admission Date
                                    </label>
                                    <asp:TextBox ID="txtadmdate" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                </div>
                                <div class="col-lg-2">
                                    <label for="inputState" class="form-label">
                                        Cancellation Date
                                    </label>
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="txtcncldte" runat="server" Autocomplete="off" CssClass="form-control" OnTextChanged="txtcncldte_TextChanged" AutoPostBack="true"></asp:TextBox>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <div class="col-lg-2">
                                    <label for="inputState" class="form-label">
                                        Day Difference
                                    </label>

                                    <asp:TextBox ID="txtdaydiff" runat="server" CssClass="form-control" ReadOnly></asp:TextBox>
                                </div>

                                <div class="col-lg-2">
                                    <label for="inputState" class="form-label">
                                        Reason
                                    </label>
                                    <asp:DropDownList ID="ddlreason" runat="server" CssClass="form-select">
                                        <asp:ListItem Selected="True" Text="--Select--" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="Wrong Entry" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Cancel Admission" Value="2"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-6">
                                    <asp:UpdatePanel runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="lbltxtchange" CssClass="form-control" runat="server" AutoPostBack="true"></asp:TextBox>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                
                                    </div>
                            </div>
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
                            <div class="row">
                                
                                <div class="col-lg-2">
                                    

                                            <asp:Button ID="btncncladmn" runat="server" Text="Cancel Admission" CssClass="btn btn-primary" OnClick="btncncladmn_Click"/>
                                    
                                    
                                </div> 
                                            <div class="col-lg-2">
                                    

                                            <asp:Button ID="btnclear" OnClick="btnclear_Click" runat="server" Text="Clear"  CssClass=" btn btn-primary"/>
                                    
                                    
                                </div> 
                                    
                            </div>
                                    </ContentTemplate>
                                    </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script>
        $("[id*='txtcncldte']").on("change", function () {
            var days = daysdiff(new Date($("[id*='txtadmdate']")[0].value), new Date($("[id*='txtcncldte']")[0].value));
            $("[id*='txtdaydiff']")[0].value = days;
        });
        function daysdiff(date1, date2) {
            //Get 1 day in milliseconds
            var one_day = 1000 * 60 * 60 * 24;

            // Convert both dates to milliseconds
            var date1_ms = date1.getTime();
            var date2_ms = date2.getTime();

            // Calculate the difference in milliseconds
            var difference_ms = date2_ms - date1_ms;

            // Convert back to days and return
            return Math.round(difference_ms / one_day);
        };
        function notify(msg, type) {
            $.notify(msg, { type: type, animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.2, delay: 0 });
        }
        datepic();
        function datepic() {
            $('[id*=txtcncldte]').datetimepicker(
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
        }

        function OnlyNum(event) {
            var value = String.fromCharCode(event.which);
            var pattern = new RegExp(/[0-9]/i);
            return pattern.test(value);
        }
    </script>

</asp:Content>

