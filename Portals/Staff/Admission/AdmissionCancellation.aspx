<%@ Page Title="" Language="C#" MasterPageFile="~/Portals/Staff/MasterPage.master" EnableEventValidation="true" AutoEventWireup="true" CodeFile="AdmissionCancellation.aspx.cs" Inherits="StudentInformation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">


    <link href="notify-master/css/notify.css" rel="stylesheet" />

    <link href="notify-master/css/prettify.css" rel="stylesheet" />
    <link href="css/jquery.datetimepicker.css" rel="stylesheet" />
    <link href="../../../Assets/css/jquery.datetimepicker.css" rel="stylesheet" />

    <script src="../../../Assets/notify-master/js/jquery-1.11.0.js"></script>
    <script src="../../../Assets/js/jquery.datetimepicker.js"></script>
    <script src="../../../Assets/notify-master/js/notify.js"></script>
    <%--<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/jquery-confirm/3.3.2/jquery-confirm.min.css">--%>
    <%--<script src="https://cdnjs.cloudflare.com/ajax/libs/jquery-confirm/3.3.2/jquery-confirm.min.js"></script>--%>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style>
        /*.form-control {
            height: 30px;
        }

        span {
            font-size: smaller;
        }*/
    </style>
    <div id="main" class="main">
        <div class="container-fluid my-1">
              <div class="pagetitle " style="font-size: 32px; margin-left: 34px; font-weight: 300; color: #012970;">
            Admission
            </div>
            <div class="card">
                <div class="container-fluid">
                    <div class="row">

                        <div class="panel panel-primary">
                            <div class="card-title" style="font-size: 23px;margin-left: 22px;">Admission Cancel </div>
                            <div class="panel-body">

            <div class="panel-body" style="padding-bottom: 0px; padding-right: 5px; padding-top: 5px; padding-left: 5px;">


                <div class="row">
                    <div class="col-lg-6">


                        <%--<div class="well well-lg" style="padding-left: 5px;    padding-top: 5px;    padding-right: 5px;    padding-bottom: 5px">--%>
                        <div class="row">
                            <div class="col-lg-3">
                                <div class="form-group">
                                    <asp:Label ID="Label1" Font-Size="Medium" runat="server" Text="Student ID"></asp:Label>
                                    <input name="Student ID" type="text" id="txt_studid" class="form-control" />
                                </div>
                            </div>
                            <div class="col-md-1">
                                <br />
                                <div class="form-group">
                                    <a id="btn_search" class="btn btn-primary btn-md"><i class="bi bi-search"></i></a>
                                </div>
                            </div>
                            <div class="col-lg-3">
                                <br />
                                <div class="form-group">
                                    <asp:LinkButton ID="btn_report" CssClass="btn btn-block btn-primary" OnClick="btn_report_Click" runat="server"><span class="glyphicon glyphicon-download-alt"></span> GET REPORT</asp:LinkButton>
                                </div>
                            </div>

                        </div>
                        <br />
                        <%--<div class="row">
                                    <div class="col-lg-3">
                                        <div class="form-group">
                                            <asp:Label ID="Label2" runat="server" Text="First Name"></asp:Label>
                                            <asp:TextBox ID="txtfNme" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                      <div class="col-lg-3">
                                        <div class="form-group">
                                            <asp:Label ID="Label5" runat="server" Text="Middle Name"></asp:Label>
                                            <asp:TextBox ID="txtmName" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                      <div class="col-lg-3">
                                        <div class="form-group">
                                            <asp:Label ID="Label6" runat="server" Text="Last Name"></asp:Label>
                                            <asp:TextBox ID="txtlname" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    </div>--%>
                        <%--<div class="row" >
                                    <div class="col-lg-3">
                                        <div class="form-group" style="margin-top: 8px">
                                           
                                            <span id="btnSearch" runat="server" class="btn btn-info btn-block">Search</span>
                                        </div>
                                    </div>
                                      <div class="col-lg-3">
                                        <div class="form-group" style="margin-top: 8px">
                                           
                                            <span id="btnCancel" runat="server" class="btn btn-warning btn-block">Cancel</span>
                                        </div>
                                    </div>
                                </div>--%>



                        <%--</div>--%>
                    </div>
                    <!--add div-->

                </div>

                <div class="panel panel-info" id="divShow" style="display: none">
                    <div class="panel panel-body">


                        <div class="row">


                            <div class="col-lg-6">
                                NAME :
                                    <b><span style="font-size: small;" id="lblstudname"></span></b>

                            </div>
                        </div>

                        <br />
                        <div class="row">
                            <%--<div class="col-lg-3">
                            FACULTY :
          
                                    <span id="lblfaculty"></span>

                        </div>
                        <div class="col-lg-3">
                            COURSE  :          
 <span id="lblcourse"></span>

                        </div>--%>
                            <div class="col-lg-3">
                                COURSE :

                                    <b><span style="font-size: small;" id="lblsubcourse"></span></b>

                            </div>
                            <div class="col-lg-3">
                                CLASS :

                 <b><span style="font-size: small;" id="lblgroup"></span></b>

                            </div>

                        </div>
                        <br />
                        <div class="row">

                            <div class="col-lg-3">
                                COURSE FEES :
           <b><span style="font-size: small;" id="lblcourseamt"></span></b>

                            </div>
                            <div class="col-lg-3">
                                PAID AMOUNT :
          <b><span style="font-size: small;" id="lblpaidamt"></span></b>

                            </div>
                            <div class="col-lg-3">
                                FEES STATUS :
          <b><span style="font-size: small;" id="lblfeesstatus"></span></b>

                            </div>
                        </div>

                        <br />

                        <div class="row">


                            <div class="col-lg-2">
                                ADMISSION DATE :
                                     <asp:TextBox ID="txtadmdate" disabled runat="server" CssClass="form-control"></asp:TextBox>

                            </div>
                            <div class="col-lg-2">
                                CANCELLATION DATE :

                                    <asp:TextBox ID="txtcanceldate" runat="server" CssClass="form-control"></asp:TextBox>

                            </div>

                            <div class="col-lg-2">
                                DAY DIFFERENCE :

                 <input type="text" id="txtdaydiff" class="form-control" disabled></input>

                            </div>

                            <div class="col-lg-3">
                                REASON :
           <asp:DropDownList ID="ddlreason" CssClass="form-control" runat="server">
               <asp:ListItem>--SELECT--</asp:ListItem>
               <asp:ListItem>WRONG ENTRY</asp:ListItem>
               <asp:ListItem>CANCEL ADMISSION</asp:ListItem>
               <%--<asp:ListItem>GROUP CHANGE</asp:ListItem>--%>
           </asp:DropDownList>

                            </div>
                        </div>

                        <br />
                        <div class="row">
                            <div class="col-lg-6">

                                <div class="panel panel-danger" id="divnote" style="display: none">
                                    <div class="panel-heading">

                                        <b>Note:</b>
                                        <br>
                                        <b><span style="font-size: small" id="deduction"></span>
                                            <br>
                                        </b>

                                        <b><span style="font-size: small" id="refundamt">Contract Donated Amount Till Date: 100000</span><br>
                                        </b>

                                    </div>
                                </div>
                            </div>

                        </div>

                        <br />
                        <div class="row" id="buttons" style="display: none">
                            <div class="col-lg-2">
                                <a id="btnCanceladm" class="btn btn-lg btn-success" >Cancel Admission</a>

                            </div>
                            <div class="col-lg-2">
                                <a id="btnClear" class="btn btn-lg btn-danger" >Clear</a>

                            </div>

                        </div>
                        <br />
                    </div>


                </div>

                <%-- gridview for report...always invisible --%>
                <div class="row">
                    <div class="col-lg-12">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <div class="well well-lg" runat="server" id="grid_show" style="overflow: scroll; height: 450px; WIDTH: 100%; OVERFLOW-X: scroll;">
                                    <%-- <asp:GridView ID="GridView1" runat="server" BorderColor="Black" GridLines="Horizontal" BorderStyle="None" Font-Size="12pt" BorderWidth="2px" CellSpacing="4"
                                Style="text-align: center; border: 2px solid" AutoGenerateColumns="False" CssClass="table table-hover table-striped table-bordered">--%>
                                    <asp:GridView ID="GridView1" runat="server" Font-Size="12pt"
                                        Style="text-align: center; border: 2px solid" AutoGenerateColumns="False" CssClass="table table-hover table-striped table-bordered" BorderColor="Black">

                                        <RowStyle HorizontalAlign="Center"></RowStyle>
                                        <Columns>
                                            <asp:TemplateField HeaderText="SERIAL NO.">
                                                <ItemTemplate>
                                                    <asp:Label ID="srno" runat="server" Text='<%#Container.DataItemIndex+1%>' AutoPostBack="true"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="STUDENT ID">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblstudid" runat="server" Text='<%# Eval("STUD_ID")%>' Style="margin: 9px;"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="STUDENT NAME">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblname" runat="server" Text='<%# Eval("NAME")%>' Style="margin: 9px;"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <%--  <asp:TemplateField HeaderText="DOB">
                                            <ItemTemplate>
                                                <asp:Label ID="lbldob" runat="server" Text='<%# Convert.ToDateTime(Eval("DOB")).Date.ToString("dd-MM-yyyy") %>' Style="margin: 9px;"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                            <asp:TemplateField HeaderText="GROUP">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblamount" runat="server" Text='<%# Eval("GROUP_NAME") %>' Style="margin: 9px;"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>


                                            <asp:TemplateField HeaderText="PAID AMOUNT">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblamount" runat="server" Text='<%# Eval("PAID") %>' Style="margin: 9px;"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>


                                            <asp:TemplateField HeaderText="CANCELLED DATE">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblamount" runat="server" Text='<%# Convert.ToDateTime(Eval("del_dt")).Date.ToString("dd-MM-yyyy") %>' Style="margin: 9px;"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="CASTE">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblamount" runat="server" Text='<%# Eval("CATEGORY") %>' Style="margin: 9px;"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--   <asp:TemplateField HeaderText="CANCELLATION DATE">
                                            <ItemTemplate>
                                                <asp:Label ID="lblcanceldate" runat="server" Text='<%# Convert.ToDateTime(Eval("cancelled_date")).Date.ToString("dd-MM-yyyy") %>' Style="margin: 9px;"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                        </Columns>
                                        <FooterStyle ForeColor="#8C4510" />
                                        <%-- <HeaderStyle BackColor="SteelBlue" Font-Bold="True" ForeColor="White" />--%>
                                        <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />

                                        <SelectedRowStyle Font-Bold="True" />
                                        <SortedAscendingCellStyle BackColor="#FFF1D4" />
                                        <SortedAscendingHeaderStyle BackColor="#B95C30" />
                                        <SortedDescendingCellStyle BackColor="#F1E5CE" />
                                        <SortedDescendingHeaderStyle BackColor="#93451F" />
                                    </asp:GridView>
                                    <br />
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <%-- ********** --%>
            </div>
    </div></div></div></div></div></div></div>
    <script type="text/javascript">
        var empId = '<%=Session["emp_id"] %>'

        // $.notify("Error ! Data not saved.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });

    </script>
    <script type="text/javascript">

        $(document).ready(function () {

            //$("[id='demo']").slideUp();
            //$("[id='btncollapse']").on('click', function () {

            //    $("[id='demo']").slideDown();
            //});
            jQuery('[id*=txtadmdate]').datetimepicker(
                    {
                        changeMonth: false,
                        changeYear: false,
                        timepicker: false,
                        format: 'd-M-Y',
                        viewMode: "months",
                        minViewMode: "months"
                        //endDate: "+0m"
                    });
            jQuery('[id*=txtcanceldate]').datetimepicker(
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
    </script>
    <script>


        var empId = '<%=Session["emp_id"] %>'

        // $.notify("Error ! Data not saved.", { color: "#fff", background: "#D44950", blur: 0.2, delay: 0 });

    </script>

    <script type="text/javascript">
        var empId = '<%=Session["emp_id"] %>'
    </script>
    <script>
        $(document).ready(function () {

            //$("[id='demo']").slideUp();
            //$("[id='btncollapse']").on('click', function () {

            //    $("[id='demo']").slideDown();
            //});
            jQuery('[id*=txtcanceldate]').datetimepicker(
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
    </script>
    <%-- <script type="text/javascript">
        $(document).ready(function () {
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);

            function EndRequestHandler(sender, args) {
                $('[id*=txtdate]').datepicker({
                    changeMonth: false,
                    changeYear: false,
                    timepicker: false,
                    format: 'd-M-Y',
                    viewMode: "months",
                    minViewMode: "months"
                });
            }

        });
    </script>--%>
    <script src="notify-master/js/jquery-1.11.0.js"></script>

    <script src="../../../Assets/JsForm/AdmissionCancellation.js"></script>


    <script src="confirmJs/jquery.confirm.min.js"></script>
    <script src="notify-master/js/notify.js"></script>
    <script src="notify-master/js/prettify.js"></script>
    <script src="js/jquery.datetimepicker.js"></script>
</asp:Content>

