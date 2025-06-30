<%@ Page Title="" Language="C#" MasterPageFile="~/Portals/Staff/MasterPage.master" AutoEventWireup="true" CodeFile="leaveConsumedRpt_datewise.aspx.cs" Inherits="Portals_Staff_Employee_leaveConsumedRpt_datewise" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
   <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous" />
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.12.9/dist/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.js"></script>
    <script src="http://code.jquery.com/jquery-1.11.2.min.js"></script>

    
    <link href="../../../Assets/notify-master/css/notify.css" rel="stylesheet" />

    <script src="../../../Assets/notify-master/js/notify.js"></script>


    <link href="../../../Assets/multiselect/css/bootstrap-multiselect.css" rel="stylesheet" />
    <script src="../../../Assets/multiselect/js/bootstrap-multiselect.js"></script>

  

    <link href="../../../Assets/css/jquery.datetimepicker.css" rel="stylesheet" />

    <script src="../../../Assets/js/jquery.datetimepicker.js"></script>
    <script src="js/jquery.datetimepicker.js"></script>


    <style>
        .borderred {
            border-color: red;
        }

        .FixedHeader {
            position: sticky;
            font-weight: 100;
            top: 0;
            z-index: 1;
        }

        fieldset.scheduler-border {
            border: 1px groove #ddd !important;
            padding: 0 1.4em 1.4em 1.4em !important;
            margin: 0 0 1.5em 0 !important;
            -webkit-box-shadow: 0px 0px 0px 0px #000;
            box-shadow: 0px 0px 0px 0px #000;
        }

        legend.scheduler-border {
            width: inherit;
            padding: 0 10px;
            border-bottom: none;
        }

        .header-cont {
            width: 100%;
            position: fixed;
            top: 0px;
        }

        body {
            font-family: sans-serif;
            font-size: 10pt;
        }

        label {
            font-weight: 100;
        }

        .hover_row {
            background-color: #A1DCF2;
        }

        table {
            width: 100%;
        }

        th, td {
            text-align: center;
            word-wrap: break-word;
            padding: 8px;
            border: 1px solid #ddd;
        }

        table th {
            background-color: white;
            word-wrap: break-word;
            color: #012970;
            border: 1px solid #ddd;
        }

        .multiselect-selected-text{
            margin-left:-10px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main" class="main">
        <div class="container-fluid">
            <div class="card" style="border: 1px solid #337ab7;">
                 <div class="card-text" style="height: auto;margin-left: 20px;margin: 20px;">
                    <div class="row">
                        <div class="col-lg-10">
                            <span style="font-family: Verdana; font-size: 20px;color:#012970;margin-left: 10px;"><strong>LEAVE CONSUMED REPORT</strong></span>
                        </div>
                    </div>
                </div>
            <div class="card-body">

                <div class="row" style="gap: 10px;margin: 0 0px;">
                    <div class="col-lg-2">
                        <div class="form-group">
                            <asp:Label ID="lbl_department" runat="server" Text="Department :"></asp:Label><br />

                            <asp:ListBox ID="ddl_department" class="multistyle" runat="server" SelectionMode="Multiple"></asp:ListBox>
                        </div>
                    </div>
                    <div class="col-lg-2 col-md-2 col-sm-2 col-xs-2">
                        <div class="form-group">
                            <asp:Label ID="lbl_month" runat="server" Text="SELECT MONTH :"></asp:Label>
                            <asp:DropDownList ID="ddl_month" CssClass="form-control" runat="server" >
                                <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                                <asp:ListItem Value="1" Text="JANUARY"></asp:ListItem>
                                <asp:ListItem Value="2" Text="FEBRUARY"></asp:ListItem>
                                <asp:ListItem Value="3" Text="MARCH"></asp:ListItem>
                                <asp:ListItem Value="4" Text="APRIL"></asp:ListItem>
                                <asp:ListItem Value="5" Text="MAY"></asp:ListItem>
                                <asp:ListItem Value="6" Text="JUNE"></asp:ListItem>
                                <asp:ListItem Value="7" Text="JULY"></asp:ListItem>
                                <asp:ListItem Value="8" Text="AUGUST"></asp:ListItem>
                                <asp:ListItem Value="9" Text="SEPTEMBER"></asp:ListItem>
                                <asp:ListItem Value="10" Text="OCTOBER"></asp:ListItem>
                                <asp:ListItem Value="11" Text="NOVEMBER"></asp:ListItem>
                                <asp:ListItem Value="12" Text="DECEMBER"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <br />
                    <div class="col-lg-2" style="display:flex;align-items:center;">
                        <asp:Button ID="btn_report" runat="server" CssClass="btn btn-block btn-success" Text="Get Report" OnClick="btn_report_Click"></asp:Button>
                    </div>
                    <div class="col-lg-2" style="display:flex;align-items:center;">
                        <asp:Button ID="btn_refresh" runat="server" CssClass="btn btn-block btn-danger" Text="Refresh" OnClick="btn_refresh_Click"></asp:Button>
                    </div>
                    <div class="col-lg-2" style="display:flex;align-items:center;">
                        <input type="button" id="btn_excel" value="Get Excel" runat="server" class="btn btn-block btn-success" text="Get Excel" onclick="TableToExcel.convert(document.getElementById('ctl00_ContentPlaceHolder1_grd_load'));" />
                        <%-- ctl00_  --%>
                    </div>
                </div>

                <br />

                <div class="row">
                    <div class="container-fluid">
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="overflow: auto; height: 700px">
                            <asp:GridView ID="grd_load" runat="server" ShowHeader="true" HeaderStyle-ForeColor="#3C763D" HeaderStyle-BackColor="#9599a3" BorderColor="#000" Font-Size="12pt" Style="text-align: center;overflow:auto" Width="100%" Height="100%" HeaderStyle-CssClass="FixedHeader" OnDataBound="grd_load_DataBound" AutoGenerateColumns="false">
                                <Columns>
                                    <asp:BoundField DataField="Sr No." HeaderText="Sr No." ItemStyle-Width="150" />
                                    <asp:BoundField DataField="EMPLOYEE ID" HeaderText="EMPLOYEE ID" ItemStyle-Width="150" />

                                    <asp:BoundField DataField="EMPLOYEE NAME" HeaderText="EMPLOYEE NAME" ItemStyle-Width="150" />
                                    <asp:BoundField DataField="DESIGNATION" HeaderText="DESIGNATION" ItemStyle-Width="150" />
                                    <asp:BoundField DataField="DEPARTMENT" HeaderText="DEPARTMENT" ItemStyle-Width="150" />
                                    <asp:BoundField DataField="DATE OF JOINING" HeaderText="DATE OF JOINING" ItemStyle-Width="150" />

                                    <asp:BoundField DataField="LWP" HeaderText="LWP" ItemStyle-Width="150" />
                                   <%-- <asp:BoundField DataField="CO_OUTD" HeaderText="CO/OUTD" ItemStyle-Width="150" />--%>
                                    <asp:BoundField DataField="CL_dates" HeaderText="CL DATES" ItemStyle-Width="150" />
                                    <asp:BoundField DataField="ML_dates" HeaderText="ML DATES" ItemStyle-Width="150" />
                                    <asp:BoundField DataField="EL_dates" HeaderText="EL DATES" ItemStyle-Width="150" />
                                    <asp:BoundField DataField="OUTD_dates" HeaderText="OD DATES" ItemStyle-Width="150" />
                                    <asp:BoundField DataField="CO_dates" HeaderText="CO DATES" ItemStyle-Width="150" />
                                    <asp:BoundField DataField="LWP_dates" HeaderText="LWP DATES" ItemStyle-Width="150" />
                                    <asp:BoundField DataField="MATERNITY_dates" HeaderText="MATERNITY DATES" ItemStyle-Width="150" />

                                    <%--   <asp:BoundField DataField="OPENING BALANCE" HeaderText="OPENING BALANCE" ItemStyle-Width="150" />--%>
                                    <asp:BoundField DataField="CL" HeaderText="CL" ItemStyle-Width="150" />
                                    <asp:BoundField DataField="ML" HeaderText="ML" ItemStyle-Width="150" />
                                    <asp:BoundField DataField="EL" HeaderText="EL" ItemStyle-Width="150" />

                                    <%--   <asp:BoundField DataField="LEAVE TAKEN" HeaderText="LEAVE TAKEN" ItemStyle-Width="150" />--%>
                                    <asp:BoundField DataField="LT_CL" HeaderText="CL" ItemStyle-Width="150" />
                                    <asp:BoundField DataField="LT_ML" HeaderText="ML" ItemStyle-Width="150" />
                                    <asp:BoundField DataField="LT_EL" HeaderText="EL" ItemStyle-Width="150" />

                                    <%--   <asp:BoundField DataField="BALANCE LEAVE" HeaderText="OPENING LEAVE" ItemStyle-Width="150" />--%>
                                    <asp:BoundField DataField="BCL" HeaderText="CL" ItemStyle-Width="150" />
                                    <asp:BoundField DataField="BML" HeaderText="ML" ItemStyle-Width="150" />
                                    <asp:BoundField DataField="BEL" HeaderText="EL" ItemStyle-Width="150" />




                                </Columns>

                            </asp:GridView>

                        </div>
                    </div>
                </div>

            </div>
        </div>
        </div>
    </div>

    <script src="jsForms/table_to_excel.js"></script>

    <script>
        $(document).ready(function () {

            jQuery('[id*=fdate]').datetimepicker(
                {
                    changeMonth: false,
                    changeYear: false,
                    timepicker: false,
                    format: 'd-M-Y',
                    viewMode: "months",
                    minViewMode: "months"
                    //endDate: "+0m"
                });

            jQuery('[id*=tdate]').datetimepicker(
                {

                    changeMonth: false,
                    changeYear: false,
                    timepicker: false,
                    format: 'd-M-Y',
                    viewMode: "months",
                    minViewMode: "months"
                    //endDate: "+0m"                  
                });

        });

        //setting mindate for tdate
        $('[id*=fdate]').change(function () {


            $('[id*=tdate]').datetimepicker({
                defaultDate: new Date(),
                minDate: new Date($('[id*=fdate]').val()),


            });

        });


        $('[id*=fdate]').on('input', function () {

            $('[id*=fdate]').val("");
        })
        //setting mindate for tdate

        //TableToExcel.convert(document.getElementById("ContentPlaceHolder1_grd_load"));


    </script>

    <%--<script type="text/javascript">

        loadmulti();

        function loadmulti() {
            $('[id*=ddl_department]').multiselect({
                includeSelectAllOption: true,
                buttonWidth: '100%',
                enableFiltering: true,
                enableCaseInsensitiveFiltering: true,

            });

        }

    </script>--%>
     <script>
         loadmulti();
         function loadmulti() {

             $('[id*=ddl_department]').multiselect({
                 includeSelectAllOption: true

             });
         }

     </script>

</asp:Content>

