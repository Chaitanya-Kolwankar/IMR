<%@ Page Title="" Language="C#" MasterPageFile="~/Portals/Staff/MasterPage.master" AutoEventWireup="true" CodeFile="leaveApproval.aspx.cs" Inherits="Portals_Staff_Employee_leaveApproved" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .FixedHeader {
            position: sticky;
            font-weight: 100;
            top: 0;
            z-index: 1;
            background-color: white;
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

        table {
            width: 100%;
            background-color: white;
        }

        th, td {
            text-align: center;
            word-wrap: break-word;
            padding: 8px;
        }

        th {
            word-wrap: break-word;
            color: #012970;
            height:20px !important;
        }

        .table-hover th {
            background-color: white;
            color: #012970;
            height:20px;
        }

        .customCursor {
            background: #26B99A;
            border: 1px solid #169F85;
            color: white;
            cursor: not-allowed;
        }

        .grdcontainer-fluid {
            padding: 0;
        }
        .btn-dark{
            border:none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main" class="main">
        <div class="container-fluid">
            <div class="row" style="margin-top: 10px">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <div class="card">
                        <div class="card-text" style="height: auto; margin-top: 15px; margin-left: 20px; margin-top: 15px;">
                            <div class="row">
                                <div class="col-lg-10">
                                    <span style="font-family: Verdana; font-size: 20px; color: #012970"><strong>LEAVE APPROVAL</strong></span>
                                </div>
                            </div>
                        </div>
                        <div class="card-body" style="background-color: none; margin-top: 15px; border: 1px solid #337ab7; margin: 15px 20px;">
                            <div class="row" style="margin-top: 15px; display: flex; align-items: center;">

                                <div class="col-lg-2 col-md-2 col-sm-2 col-xs-2">
                                    <div class="form-group">
                                        <asp:Label ID="lbl_month" runat="server" Text="SELECT MONTH :"></asp:Label>
                                        <asp:DropDownList ID="ddl_month" CssClass="form-control" runat="server" OnSelectedIndexChanged="ddl_month_SelectedIndexChanged" AutoPostBack="true">
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
                                <div class="col-lg-2 col-md-2 col-sm-2 col-xs-2" style="margin-left: 60px;">
                                    <asp:Button ID="btn_refresh" runat="server" class="btn btn-block btn-danger" OnClick="btn_refresh_Click" Text="REFRESH" Style="margin-top: 17px"></asp:Button>
                                </div>
                                <div class="col-lg-2 col-md-2 col-sm-2 col-xs-2" style="margin-left: -55px;">
                                    <asp:Button ID="btn_Excel" runat="server" class="btn btn-block btn-success" Text="GET REPORT" OnClick="btn_Excel_Click" Style="margin-top: 17px" AutoPostBack="true"></asp:Button>
                                </div>


                                <div class="row" style="margin: 20px; overflow-x: auto; overflow-y: auto; max-height: 500px; margin-left: -5px;">
                                    <div class="grdcontainer-fluid">
                                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                            <asp:GridView ID="GridView" runat="server" CssClass="table table-container table-bordered " Style="font-family: Verdana; overflow: auto; height: 700px; border: 1px solid #ddd;" AutoGenerateColumns="false" OnRowDataBound="GridView_RowDataBound" OnRowCommand="GridView_RowCommand" Height="100%" Width="100%" HeaderStyle-CssClass="FixedHeader">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="SR NO" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="sr_no" runat="server" Text='<%#Eval("srno")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="EMPLOYEE ID" ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:Label ID="emp_id" runat="server" Text='<%#Eval("emp_id")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="EMPLOYEE NAME">
                                                        <ItemTemplate>
                                                            <asp:Label ID="name" runat="server" Text='<%#Eval("name")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="DEPARTMENT" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="current_department_name" runat="server" Text='<%#Eval("current_department_name")%>' Visible="false"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="DESIGNATION">
                                                        <ItemTemplate>
                                                            <asp:Label ID="current_designation" runat="server" Text='<%#Eval("current_designation")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="LEAVE DATE">
                                                        <ItemTemplate>
                                                            <asp:Label ID="leave" runat="server" Text='<%#Eval("leave","{0:dd-MMM-yyyy}")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="WORK ADJUSTMENT DETAILS">
                                                        <ItemTemplate>
                                                            <asp:Label ID="details" runat="server" Text='<%#Eval("details")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="LEAVE REASON">
                                                        <ItemTemplate>
                                                            <asp:Label ID="resleave" runat="server" Text='<%#Eval("resleave")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="LEAVE TYPE">
                                                        <ItemTemplate>
                                                            <asp:Label ID="leavetype" runat="server" Text='<%#Eval("leavetype")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="ALTERNATIVE ARRANGEMENT">
                                                        <ItemTemplate>
                                                            <asp:Label ID="names" runat="server" Text='<%#Eval("locumName")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="APPLICATION DATE">
                                                        <ItemTemplate>
                                                            <asp:Label ID="applc_dt" runat="server" Text='<%#Eval("Application Date")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="BALANCE LEAVE ">
                                                        <ItemTemplate>
                                                            <asp:Label ID="balanceleave" runat="server" Text='<%#Eval("Bal")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Certificate">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkbtn_view" runat="server" Text="View" CssClass="btn btn-success btn-block" CommandName="view" CommandArgument='<%# Container.DataItemIndex %>' autopostback="true"></asp:LinkButton>
                                                        </ItemTemplate>

                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="UNPAID FLAG" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="paid_unpaid_flag" runat="server" Text='<%#Eval("paid_unpaid")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="PAID/UNPAID">
                                                        <ItemTemplate>
                                                            <asp:UpdatePanel ID="updtpnl1" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList ID="ddl_paid_unpaid" runat="server" OnSelectedIndexChanged="ddl_paid_unpaid_SelectedIndexChanged" CssClass="form-control btn btn-dark" AutoPostBack="true">
                                                                        <asp:ListItem>--SELECT--</asp:ListItem>
                                                                        <asp:ListItem Value="0" Text="PAID"></asp:ListItem>
                                                                        <asp:ListItem Value="1" Text="UNPAID"></asp:ListItem>
                                                                        <asp:ListItem Value="2" Text="HALFPAID"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="CO-ORDINATOR STATUS">
                                                        <ItemTemplate>
                                                            <asp:UpdatePanel ID="updtpnl2" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList ID="ddl_hodstatus" runat="server" OnSelectedIndexChanged="ddl_hodstatus_SelectedIndexChanged" CssClass=" form-control btn btn-dark" AutoPostBack="true">
                                                                        <asp:ListItem>--SELECT--</asp:ListItem>
                                                                        <asp:ListItem Value="0" Text="Sanctioned"></asp:ListItem>
                                                                        <asp:ListItem Value="1" Text="Not Sanctioned"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    <asp:Label ID="ddlhodflag" runat="server" Text='<%#Eval("approved_flag_HOD")%>' ForeColor="#000" Visible="false"></asp:Label>
                                                                    <asp:Label ID="lbl_approved_reason_hod" runat="server" Text='<%#Eval("approved_reason_HOD")%>' ForeColor="#73879c"></asp:Label>
                                                                    <asp:TextBox ID="txtreason_hod" TextMode="MultiLine" runat="server" Style="max-width: 110px; min-height: 123px" placeholder="Type Reason Here..." Visible="false"></asp:TextBox>
                                                                    <asp:Button ID="save_btn_hod" runat="server" Text="Save" CssClass="btn btn-success" Visible="false" Style="margin-top: 10px" />
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="PRINCIPAL STATUS">
                                                        <ItemTemplate>
                                                            <asp:UpdatePanel ID="updtpnl3" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList ID="ddl_principalstatus" OnSelectedIndexChanged="ddl_principalstatus_SelectedIndexChanged" runat="server" CssClass=" form-control btn btn-dark" AutoPostBack="true">
                                                                        <asp:ListItem>--SELECT--</asp:ListItem>
                                                                        <asp:ListItem Value="0" Text="Sanctioned"></asp:ListItem>
                                                                        <asp:ListItem Value="1" Text="Not Sanctioned"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    <asp:Label ID="ddlprincipalflag" runat="server" Text='<%#Eval("approved_flag_PRINCIPLE")%>' ForeColor="#000" Visible="false"></asp:Label>
                                                                    <asp:Label ID="lbl_approved_reason_principal" runat="server" Text='<%#Eval("approved_reason_PRINCIPLE")%>' ForeColor="#73879c"></asp:Label>
                                                                    <asp:TextBox ID="txtreason_principal" TextMode="MultiLine" runat="server" Style="max-width: 110px; min-height: 123px" placeholder="Type Reason Here..." Visible="false"></asp:TextBox>
                                                                    <asp:Button ID="save_btn_principal" runat="server" Text="Save" OnClick="save_btn_principal_Click" CssClass="btn btn-success" Visible="false" Style="margin-top: 10px" />
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="HOD STATUS" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_A_hod" runat="server" Text='<%#Eval("hod_status")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="PRINCIPAL STATUS" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_A_principle" runat="server" Text='<%#Eval("principle_status")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Print">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkbtn_print" runat="server" Text="Print" CssClass="btn btn-success btn-block" OnClick="lnkbtn_print_Click"></asp:LinkButton>
                                                        </ItemTemplate>

                                                    </asp:TemplateField>

                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

