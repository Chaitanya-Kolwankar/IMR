<%@ Page Title="" Language="C#" MasterPageFile="~/Portals/Staff/MasterPage.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="FeeEntry_New.aspx.cs" EnableSessionState="True" Inherits="FeeEntry_New" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        input[type=number] {
            -moz-appearance: textfield;
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
            padding: 15px;
        }

        th {
            color: #012970;
        }

        .caps {
            text-transform: uppercase;
        }

        .FixedHeader {
            position: sticky;
            font-weight: bold;
            top: 0;
        }

        .transparent-modal {
            background-color: #0000;
            border: 0px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main" class="main">
        <div class="container-fluid">
            <div class="pagetitle " style="font-size: 32px; margin-left: 34px; font-weight: 300; color: #012970;">
               Fees
            </div>
            <div class="container-fluid">
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <div class="card">
                            <div class="card-title mx-4" style="font-size: 21px">
                                Fee Entry
                            </div>
                            <div class="card-body">
                                <div class="row">
                                    <div class="col-md-2">
                                        <asp:TextBox ID="txt_studid" runat="server" CssClass="form-control" placeholder="Student ID" MaxLength="8" onkeypress="return isNumber(event)"></asp:TextBox>
                                    </div>
                                    <div class="col-md-1">
                                        <asp:LinkButton ID="lnksearch" runat="server" CssClass="btn btn-primary" OnClick="lnksearch_Click"><span class="bi bi-search"></span></asp:LinkButton>
                                    </div>
                                    <div class="col-md-1">
                                        <asp:Button ID="btn_refresh" runat="server" Text="Refresh" CssClass="form-control btn btn-primary" OnClick="btn_refresh_Click" />
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="card card-body" style="border: 1px solid; border-radius: 7px; border-color: #0078bc; padding: 15px;" runat="server" id="feepanel" visible="false">
                                        <div class="row">
                                            <div class="col-md-3">
                                                <b>NAME : </b>
                                                <asp:Label ID="lblname" runat="server"></asp:Label>
                                            </div>
                                            <div class="col-md-3">
                                                <b>COURSE : </b>
                                                <asp:Label ID="lblcourse" runat="server"></asp:Label>
                                            </div>
                                            <div class="col-md-3">
                                                <b>SUBCOURSE : </b>
                                                <asp:Label ID="lblsubcourse" runat="server"></asp:Label>
                                            </div>
                                            <div class="col-md-3">
                                                <b>GROUP : </b>
                                                <asp:Label ID="lblgroup" runat="server"></asp:Label>
                                                <asp:Label ID="lblgroupid" runat="server" Visible="false"></asp:Label>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="col-md-3">
                                                <b>ACADEMIC YEAR : </b>
                                                <asp:Label ID="lblyear" runat="server"></asp:Label>
                                                <asp:Label ID="lblayid" runat="server" Visible="false"></asp:Label>
                                            </div>
                                            <div class="col-md-3">
                                                <b>CATEGORY : </b>
                                                <asp:Label ID="lblcategory" runat="server"></asp:Label>
                                            </div>
                                            <div class="col-md-3">
                                                <b>TOTAL PAID FEES : </b>
                                                <asp:Label ID="lblpaidfees" runat="server"></asp:Label>
                                            </div>
                                            <div class="col-md-3">
                                                <b>TOTAL BALANCE AMOUNT : </b>
                                                <asp:Label ID="lblbal" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="row" style="margin-top: 10px; margin-bottom: 5px;">
                                            <div class="col-md-6" style="margin-top: 10px;">
                                                <div class="col-md-4">
                                                    Fees Type
                                                    <asp:DropDownList ID="ddlpay" runat="server" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="ddlpay_SelectedIndexChanged">
                                                        <asp:ListItem>--Select--</asp:ListItem>
                                                        <asp:ListItem>All Fees</asp:ListItem>
                                                        <%--<asp:ListItem>Refund Fees</asp:ListItem>--%>
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="col-md-4">
                                                    Payment Mode
                                                    <asp:DropDownList ID="ddlmode" runat="server" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="ddlmode_SelectedIndexChanged">
                                                        <asp:ListItem>--Select--</asp:ListItem>
                                                        <asp:ListItem>Cash</asp:ListItem>
                                                        <asp:ListItem>Cheque</asp:ListItem>
                                                        <asp:ListItem>DD</asp:ListItem>
                                                        <asp:ListItem>ECS\NEFT\RTGS</asp:ListItem>
                                                        <asp:ListItem>Online Pay</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="col-md-4">
                                                    Pay Date (dd/mm/yyyy)
                    <asp:TextBox ID="txtpaydate" runat="server" CssClass="form-control"></asp:TextBox>
                                                </div>
                                                <div class="col-md-2" style="display: none;">
                                                    Receipt No.
                    <asp:Label ID="lblreceiptno" runat="server" CssClass="form-control"></asp:Label>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row" runat="server" id="details" visible="false" style="margin-bottom: 5px;">
                                            <div class="col-md-3">
                                                Bank Name
                <asp:TextBox ID="txtbnkname" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="col-md-3" runat="server" id="branch">
                                                Branch Name
                <asp:TextBox ID="txtbranch" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="row">
                                                    <div class="col-md-4">
                                                        Instrument Date (dd/mm/yyyy)
                        <asp:TextBox ID="txtchdate" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </div>
                                                    <div class="col-md-4">
                                                        Instrument No.
                        <asp:TextBox ID="txtchno" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </div>
                                                    <div class="col-md-4" runat="server" id="status" visible="false">
                                                        Cheque/NEFT Status
                        <asp:DropDownList ID="ddlstatus" CssClass="form-control" runat="server">
                            <asp:ListItem>--Select--</asp:ListItem>
                            <asp:ListItem>Clear</asp:ListItem>
                            <asp:ListItem>Pending</asp:ListItem>
                            <asp:ListItem>Bounce</asp:ListItem>
                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row" runat="server" id="feetable" visible="false">
                                            <div class="col-md-12" style="overflow: auto">
                                                <asp:GridView ID="grdfees" runat="server" Font-Size="10pt"
                                                    Style="text-align: center;" AutoGenerateColumns="False" CssClass="table table-bordered table-hover">
                                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                    <RowStyle HorizontalAlign="Center" Height="10px"></RowStyle>
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <asp:CheckBox ID="chkall" runat="server" AutoPostBack="true" OnCheckedChanged="chkall_CheckedChanged" />
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="chkselect" runat="server" AutoPostBack="true" OnCheckedChanged="chkselect_CheckedChanged" />
                                                            </ItemTemplate>
                                                            <ItemStyle Width="10%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="STRUCTURE NAME">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblstructname" runat="server" Text='<%# Eval("Struct_name")%>'></asp:Label>
                                                                <asp:Label ID="lblflag" runat="server" Text='<%# Eval("flag")%>' Visible="false"></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle Width="25%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="TOTAL FEE">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblamount" runat="server" Text='<%# Eval("TotalFees")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle Width="15%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="PAID">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblpaid" runat="server" Text='<%# Eval("Paid")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle Width="15%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="BALANCE">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblpending" runat="server" Text='<%# Eval("Balance")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle Width="15%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="PAY">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtpay" runat="server" onkeypress="return isNumber(event)" Enabled="false" AutoPostBack="true" OnTextChanged="txtpay_TextChanged" MaxLength="10"></asp:TextBox>
                                                                <asp:Label ID="lblcurrentpaid" runat="server" Text='<%# Eval("CurrentPaid")%>' Visible="false"></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle Width="20%" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </div>
                                        <div class="row" runat="server" id="btn" visible="false">
                                            <div class="col-md-4"></div>
                                            <div class="col-md-2">
                                                <asp:Button ID="btnsave" runat="server" CssClass="btn btn-success form-control" Text="Save" OnClick="btnsave_Click" />
                                            </div>
                                            <div class="col-md-2">
                                                <asp:Button ID="btncancel" runat="server" CssClass="btn btn-success form-control" Text="Cancel" OnClick="btncancel_Click" />
                                            </div>
                                            <div class="col-md-4"></div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="col-md-12" style="overflow: auto">
                                                <asp:GridView ID="grdedit" runat="server" Font-Size="10pt"
                                                    Style="text-align: center;" AutoGenerateColumns="False" CssClass="table table-bordered table-hover" >
                                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                    <RowStyle HorizontalAlign="Center" Height="10px"></RowStyle>
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="RECEIPT NO">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblrecptno" runat="server" Text='<%# Eval("Recpt_no")%>'></asp:Label>
                                                                <asp:Label ID="lblstatus" runat="server" Text='<%# Eval("Status")%>' Visible="false"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="FEES TYPE">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbltype" runat="server" Text='<%# Eval("struct")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="AMOUNT">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblamount" runat="server" Text='<%# Eval("amt")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="PAYMENT MODE">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblmode" runat="server" Text='<%# Eval("Recpt_mode")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="PAY DATE">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbldate" runat="server" Text='<%# Eval("PAYDATE")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="RECEIPT">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="btnprint" runat="server" CommandName="Print" CommandArgument="<%# Container.DataItemIndex %>" Text="<i class='fa fa-print' aria-hidden='true'></i>" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="EDIT">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="btnedit" runat="server" CommandName="Select" Text="<i class='fa fa-edit' aria-hidden='true'></i>" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="DELETE">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="btndelete" runat="server" OnClientClick="Confirm()" CommandName="Delete" Text="<i class='fa fa-trash' aria-hidden='true'></i>" />
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
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        <%--Modal--%>
        <div class="modal" id="modalyear" data-bs-backdrop="static">
            <div class="modal-dialog modal-lg">
                <div class="modal-content">
                    <div class="modal-header row">
                        <div class="col-md-10">
                            <h2 class="modal-title">Student Details</h2>
                        </div>
                        <div class="col-md-2" style="display: flex; justify-content: flex-end;">
                            <button type="button" class="close btn btn-outline-secondary" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                        </div>
                    </div>
                    <div class="modal-body">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <div class="row" style="font-size: 15px; text-align: center">
                                    <div class="col-md-4">
                                        <b>STUDENT ID :</b>
                                        <asp:Label ID="lblmodalid" runat="server"></asp:Label>
                                    </div>
                                    <div class="col-md-8">
                                        <b>NAME :</b>
                                        <asp:Label ID="lblmodalname" runat="server"></asp:Label>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-12 table-responsive" style="max-height: 300px; overflow: auto">
                                        <asp:GridView ID="grdyear" runat="server" Style="text-align: center;" AutoGenerateColumns="False" CssClass="table">
                                            <RowStyle HorizontalAlign="Center"></RowStyle>
                                            <Columns>
                                                <asp:TemplateField HeaderText="Course">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblcourse" runat="server" Text='<%# Eval("Course")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Subcourse">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblsubcourse" runat="server" Text='<%# Eval("Subcourse")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Group">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgroup" runat="server" Text='<%# Eval("Group")%>'></asp:Label>
                                                        <asp:Label ID="lblgroupid" runat="server" Text='<%# Eval("Group ID")%>' Visible="false"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Academic Year">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblyear" runat="server" Text='<%# Eval("Year")%>'></asp:Label>
                                                        <asp:Label ID="lblayid" runat="server" Text='<%# Eval("AYID")%>' Visible="false"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="View">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnedit" runat="server" CommandName="Select" CssClass="text-primary" OnClick="btnedit_Click"><i class='bi bi-pencil-square' aria-hidden='true'></i></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script>
        function loaddate() {
            $('[id*=txtpaydate]').datetimepicker(
                {
                    todayHighlight: true,
                    timepicker: false,
                    format: 'd/m/Y',
                    orientation: 'bottom'
                });
            $('[id*=txtchdate]').datetimepicker(
                {
                    todayHighlight: true,
                    timepicker: false,
                    format: 'd/m/Y',
                    orientation: 'bottom'
                });
        }
        function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            confirm_value.value = "";
            if (confirm("Do you want to delete the selected fee entry ?")) {
                confirm_value.value = "OK";
            }
            else {
                confirm_value.value = "Cancel";
            }
            document.forms[0].appendChild(confirm_value);
        }
    </script>

    <script type="text/javascript">
        function openModal(name) {
            $("[id*=" + name + "]").modal('show');
            $("[id*=" + name + "]").data('bs.modal').options.backdrop = 'static';
            $("[id*=" + name + "]").data('bs.modal').options.keyboard = false;
        }
        function closeModal(name) {
            $("[id*=" + name + "]").modal('hide');
        }
        function isNumber(evt) {
            evt = (evt) ? evt : window.event;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                return false;
            }
            return true;
        }
        function redirect(name) {
            window.open(name, '_blank');
        }
    </script>
</asp:Content>

