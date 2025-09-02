<%@ Page Title="" Language="C#" MasterPageFile="~/Portals/Staff/MasterPage.master" AutoEventWireup="true" CodeFile="Prov_feeEntry.aspx.cs" Inherits="Portals_Staff_Admission_Prov_feeEntry" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        input[type=number] {
            -moz-appearance: textfield;
        }

        table, td, th {
            border: 1px solid #ddd;
            /*text-align: left;*/
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

        .form-control:disabled {
            background-color: #e9ecef;
        }

        .form-control[readonly] {
            background-color: #fff;
        }

        .form-control:disabled {
            background-color: #e9ecef;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main" class="main">
        <div class="container-fluid">
            <div class="pagetitle " style="font-size: 32px; margin-left: 34px; font-weight: 300; color: #012970;">
                Provisional Fee Entry
            </div>
            <div class="container-fluid">
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <div class="card">
                            <div class="card-title mx-4" style="font-size: 21px">
                                Provisional Fee Entry
                            </div>
                            <div class="card-body">
                                <div class="row">
                                    <div class="col-md-2 text-center" style="align-content: center;">
                                        <asp:CheckBox ID="chk_bx" runat="server" Text="Search by Name" OnCheckedChanged="chk_bx_CheckedChanged" AutoPostBack="true" />
                                    </div>
                                    <div class="col-md-2" runat="server" id="div_stud_id">
                                        <asp:TextBox ID="txt_studid" runat="server" CssClass="form-control" placeholder="Form Number" MaxLength="5" onkeypress="return isNumberAlpha(event, this)" Text="" oninput="alphabetUsed = /[a-zA-Z]/.test(this.value);"></asp:TextBox>
                                    </div>
                                    <div class="col-md-8" runat="server" id="div_name" visible="false">
                                        <div class="row">
                                            <div class="col-md-4">
                                                <asp:TextBox ID="txt_fname" runat="server" autoComplete="off" CssClass="form-control" MaxLength="25" Style="text-transform: uppercase" placeholder="First Name"></asp:TextBox>
                                            </div>
                                            <div class="col-md-4">
                                                <asp:TextBox ID="txt_mname" runat="server" autoComplete="off" CssClass="form-control" MaxLength="25" Style="text-transform: uppercase" placeholder="Middle Name"></asp:TextBox>
                                            </div>
                                            <div class="col-md-4">
                                                <asp:TextBox ID="txt_lname" runat="server" autoComplete="off" MaxLength="25" CssClass="form-control" Style="text-transform: uppercase" placeholder="Last Name"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-1 text-center">
                                        <asp:LinkButton ID="lnksearch" runat="server" CssClass="btn btn-primary" OnClick="lnksearch_Click"><span class="bi bi-search"></span></asp:LinkButton>
                                    </div>
                                    <div class="col-md-1">
                                        <asp:Button ID="btn_refresh" runat="server" Text="Refresh" CssClass="form-control btn btn-primary" OnClick="btn_refresh_Click" />
                                    </div>
                                </div>
                                <div id="div_grd_name" runat="server" visible="false">
                                    <br />
                                    <div class="row">
                                        <div class="col-md-12 col-sm-12 col-xs-12 table-responsive" style="overflow: auto; max-height: 400px; width: 100%;">
                                            <asp:GridView ID="grd_name" runat="server" Style="text-align: left;" AutoGenerateColumns="False" CssClass="table">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Form No">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_stud_id" runat="server" Text='<%# Eval("form_no")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Student Name">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_studentname" runat="server" Text='<%# Eval("name")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Gender">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_dob" runat="server" Text='<%# Eval("Gender")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Select" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnk_name_view" runat="server" CssClass="btn btn-outline-primary bi bi-pencil-square" OnClick="lnk_name_view_Click"></asp:LinkButton>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
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
                                                <b>Gender : </b>
                                                <asp:Label ID="lblgender" runat="server"></asp:Label>
                                            </div>
                                            <div class="col-md-3">
                                                <b>CATEGORY : </b>
                                                <asp:Label ID="lblcategory" runat="server"></asp:Label>
                                            </div>
                                            <div class="col-md-3">
                                                <b>GROUP : </b>
                                                <asp:Label ID="lblgroup" runat="server"></asp:Label>
                                                <asp:Label ID="lblgroupid" runat="server" Visible="false"></asp:Label>
                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class="col-md-3" style="display: none">
                                                <b>ACADEMIC YEAR : </b>
                                                <asp:Label ID="lblyear" runat="server"></asp:Label>
                                                <asp:Label ID="lblayid" runat="server" Visible="false"></asp:Label>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row" id="ddlmode1" runat="server">
                                            <div class="col-md-2">
                                                Payment Mode
                                                    <asp:DropDownList ID="ddlmode" runat="server" AutoPostBack="true" CssClass="form-select" OnSelectedIndexChanged="ddlmode_SelectedIndexChanged">
                                                        <asp:ListItem>--Select--</asp:ListItem>
                                                        <asp:ListItem>Cash</asp:ListItem>
                                                        <asp:ListItem>Cheque</asp:ListItem>
                                                        <asp:ListItem>DD</asp:ListItem>
                                                        <asp:ListItem>ECS\NEFT\RTGS</asp:ListItem>
                                                        <asp:ListItem>Online</asp:ListItem>
                                                    </asp:DropDownList>
                                            </div>
                                            <div class="col-md-2" id="txtpaydate1" runat="server">
                                                Pay Date
                                                    <asp:TextBox ID="txtpaydate" runat="server" CssClass="form-control" placeholder=" (dd/mm/yyyy)" autocomplete="off"></asp:TextBox>
                                            </div>
                                            <div class="col-md-2" id="div_amount" runat="server" visible="false">
                                                Enter Amount :
                                                <asp:TextBox ID="txt_amount" runat="server" CssClass="form-control" placeholder="Amount" MaxLength="8" onkeypress="return isNumber(event)" autocomplete="off" AutoPostBack="true" OnTextChanged="txt_amount_TextChanged"></asp:TextBox>
                                                <asp:HiddenField ID="hidden_install_bal" runat="server" ClientIDMode="Static" />
                                                <asp:HiddenField ID="hidden_install_Id" runat="server" ClientIDMode="Static" />
                                                <asp:HiddenField ID="hidden_recpt_no" runat="server" ClientIDMode="Static" />
                                            </div>
                                            <div class="col-md-6" runat="server" id="btn" visible="false">
                                                <br />
                                                <div class="row">
                                                    <div class="col-md-6">
                                                        <asp:Button ID="btnsave" runat="server" CssClass="btn btn-primary  form-control" Text="Save" OnClick="btnsave_Click" />
                                                    </div>
                                                    <div class="col-md-6">
                                                        <asp:Button ID="btncancel" runat="server" CssClass="btn btn-primary form-control" Text="Cancel" OnClick="btncancel_Click" />
                                                    </div>
                                                </div>
                                            </div>

                                        </div>
                                        <div runat="server" id="details" visible="false">
                                            <br />
                                            <div class="row">
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
                                                            Instrument Date
                                                        <asp:TextBox ID="txtchdate" CssClass="form-control" runat="server" placeholder=" (dd/mm/yyyy)"></asp:TextBox>
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
                                        </div>
                                        <br />


                                        <br />
                                        <div class="row">
                                            <div class="col-md-12 col-sm-12 col-xs-12 table-responsive" style="overflow: auto; max-height: 400px; width: 100%;">
                                                <asp:GridView ID="grdedit" runat="server" Style="text-align: left;" AutoGenerateColumns="False" CssClass="table">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="SR.NO">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl_sr_no" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Status" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Chq_status" runat="server" Text='<%# Eval("Chq_status")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="RECEIPT NO">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Receipt_no" runat="server" Text='<%# Convert.ToString(Eval("Receipt_no")).Trim()==""?"-NA-":Eval("Receipt_no")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="AMOUNT">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Amount" runat="server" Text='<%# Eval("Amount")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="PAYMENT MODE">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Recpt_mode" runat="server" Text='<%# Eval("Recpt_mode")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="PAY Date">
                                                            <ItemTemplate>
                                                                <div style="display: flex; align-items: center; gap: 6px;">
                                                                    <asp:TextBox ID="Pay_Date" runat="server" placeholder="Date" Text='<%# Eval("Pay_date") %>' CssClass="form-control datepicker" onkeypress="preventKeyPress(event);" AutoComplete="off" Enabled='<%# Convert.ToString(Eval("Pay_date")) ==""?true:false %>'></asp:TextBox>
                                                                </div>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="EDIT">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="btnfeeedit" runat="server" CssClass="btn btn-outline-primary bi bi-pencil-square" OnClick="btnfeeedit_Click"></asp:LinkButton>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="DELETE">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="btndelete" runat="server" OnClientClick="Confirm()" CssClass="btn btn-outline-danger bi bi-trash" OnClick="btndelete_Click"></asp:LinkButton>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="PAY">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="btnPay" runat="server" CssClass="btn btn-outline-success bi bi-wallet2" OnClick="btnPay_Click"></asp:LinkButton>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Print">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="btnPrint" runat="server" CssClass="btn btn-outline-success bi bi-printer" OnClick="btnPrint_Click"></asp:LinkButton>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" />
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
                confirm_value.value = "Yes";
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
            //$("[id*=" + name + "]").data('bs.modal').options.backdrop = 'static';
            //$("[id*=" + name + "]").data('bs.modal').options.keyboard = false;
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


    <script>
        let alphabetUsed = false;

        function isNumberAlpha(e, input) {
            let k = e.which || e.keyCode, ch = String.fromCharCode(k);
            if (k < 32) return true;
            if (/\d/.test(ch)) return true;
            if (/[a-zA-Z]/.test(ch)) return !alphabetUsed && !/[a-zA-Z]/.test(input.value) ? (alphabetUsed = true) : false;
            return false;
        }
    </script>





    <script type="text/javascript">
        function ConfirmFine(sender, args) {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            confirm_value.value = "";
            var confirmed = confirm("Do you want to remove the fine?");
            if (!confirmed) {
                sender.checked = false;
                args.set_cancel(true);
            }
        }
    </script>
</asp:Content>

