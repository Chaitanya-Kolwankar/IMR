<%@ Page Title="" Language="C#" MasterPageFile="~/Portals/Staff/MasterPage.master" AutoEventWireup="true" CodeFile="DefineInstallment.aspx.cs" Inherits="Portals_Staff_Fee_DefineInstallment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="<%= ResolveUrl("~/Assets/js/jquery.datetimepicker.js") %>"></script>
    <link href="<%= ResolveUrl("~/Assets/css/jquery.datetimepicker.css") %>" rel="stylesheet" />
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
            background-color: white !important;
            position: sticky;
            font-weight: bold;
            top: 0;
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

        .form-control[readonly] {
            background-color: #fff;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main" class="main">
        <div class="container-fluid">
            <div class="pagetitle " style="font-size: 32px; margin-left: 34px; font-weight: 300; color: #012970;">
                Fee
            </div>
            <div class="container-fluid ">
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <div class="card">
                            <div class="card-title mx-4" style="font-size: 21px">
                                Define Installment
                            </div>
                            <div class="card-body">
                                <div class="row">
                                    <div class="col-md-2 text-center" style="align-content: center;">
                                        <asp:CheckBox ID="chk_bx" runat="server" Text="Search by Name" OnCheckedChanged="chk_bx_CheckedChanged" AutoPostBack="true" />
                                    </div>
                                    <div class="col-md-2" runat="server" id="div_stud_id">
                                        <asp:TextBox ID="txt_studid" runat="server" CssClass="form-control" placeholder="Student ID" MaxLength="8" onkeypress="return isNumber(event)"></asp:TextBox>
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
                                            <asp:GridView ID="grd_name" runat="server" Style="text-align: center;" AutoGenerateColumns="False" CssClass="table">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Student ID">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_stud_id" runat="server" Text='<%# Eval("stud_id")%>'></asp:Label>
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
                                                    <asp:TemplateField HeaderText="Select">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnk_name_view" runat="server" CssClass="btn btn-outline-primary bi bi-pencil-square" OnClick="lnk_name_view_Click"></asp:LinkButton>
                                                        </ItemTemplate>
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
                                        <br />
                                        <div class="row">
                                            <div class="col-md-3">
                                                <b>ACADEMIC YEAR : </b>
                                                <asp:Label ID="lblyear" runat="server"></asp:Label>
                                                <asp:Label ID="lblayid" runat="server" Visible="false"></asp:Label>
                                            </div>
                                            <div class="col-md-3">
                                                <b>TOTAL FEES : </b>
                                                <asp:Label ID="lbl_totalfees" runat="server"></asp:Label>
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
                                        <br />
                                        <div class="row">
                                            <div class="col-md-2">
                                                <asp:Label ID="Label3" runat="server" Text="Installment :"></asp:Label><br />
                                                <asp:DropDownList ID="ddl_installment" runat="server" CssClass="form-select" OnSelectedIndexChanged="ddl_installment_SelectedIndexChanged" AutoPostBack="true">
                                                    <asp:ListItem Value="" Text="--Select--"></asp:ListItem>
                                                    <asp:ListItem Value="1" Text="1 (ONE)"></asp:ListItem>
                                                    <asp:ListItem Value="2" Text="2 (TWO)"></asp:ListItem>
                                                    <asp:ListItem Value="3" Text="3 (THREE)"></asp:ListItem>
                                                    <asp:ListItem Value="4" Text="4 (FOUR)"></asp:ListItem>
                                                    <asp:ListItem Value="5" Text="5 (FIVE)"></asp:ListItem>
                                                    <asp:ListItem Value="6" Text="6 (SIX)"></asp:ListItem>
                                                    <asp:ListItem Value="7" Text="7 (SEVEN)"></asp:ListItem>
                                                    <asp:ListItem Value="8" Text="8 (EIGHT)"></asp:ListItem>
                                                    <asp:ListItem Value="9" Text="9 (NINE)"></asp:ListItem>
                                                    <asp:ListItem Value="10" Text="10 (TEN)"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-md-2">
                                                <br />
                                                <asp:Button ID="btnsave" runat="server" CssClass="btn btn-primary form-control" Text="Save" OnClick="btnsave_Click" />
                                            </div>
                                            <div class="col-md-1" id="div_print" runat="server" visible="false">
                                                <br />
                                                <asp:LinkButton ID="btn_print" runat="server" CssClass="btn btn-outline-success form-control bi bi-printer" OnClick="btn_print_Click"></asp:LinkButton>
                                            </div>
                                            <div class="col-md-2">
                                                <br />
                                                <asp:Button ID="btncancel" runat="server" CssClass="btn btn-primary form-control" Text="Cancel" OnClick="btncancel_Click" />
                                            </div>

                                            <div class="col-md-2" id="div_new" runat="server" visible="false">
                                                <br />
                                                <asp:LinkButton ID="btn_new" runat="server" CssClass="btn btn-outline-danger form-control" Text="Revise" OnClick="btn_new_Click" OnClientClick="Confirm();"></asp:LinkButton>
                                            </div>
                                            <div class="col-md-2">
                                                <br />
                                                <asp:Button ID="btn_waveoff" runat="server" CssClass="btn btn-primary form-control" Text="Waive Off" OnClick="btn_waveoff_Click" />
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row" runat="server" id="installtable">
                                            <div class="col-md-12 col-sm-12 col-xs-12 table-responsive" style="overflow: auto; max-height: 400px; width: 100%;">
                                                <asp:GridView ID="grd_install" runat="server" AutoGenerateColumns="false" CssClass="table">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Sr.no">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl_sr_no" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="installemntId" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Install_id" runat="server" Text='<%# Eval("Install_id") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle Width="10%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Installment No">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl_install_no" runat="server" Text='<%# (Container.DataItemIndex + 1) +" ("+ getnum(Container.DataItemIndex + 1)+")" %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Due Date">
                                                            <ItemTemplate>
                                                                <div style="display: flex; align-items: center; gap: 6px;">
                                                                    <asp:TextBox ID="Due_date" runat="server" placeholder="Date" Text='<%# Eval("Due_date") %>' CssClass="form-control datepicker" onkeypress="preventKeyPress(event);" AutoComplete="off" Enabled='<%# Convert.ToString(Eval("Due_date")) ==""?true:false %>'></asp:TextBox>
                                                                    <asp:LinkButton ID="lnkEnableDate" runat="server" CssClass="btn btn-outline-primary bi bi-pencil" Visible='<%# !string.IsNullOrEmpty(Eval("Due_date").ToString()) %>' OnClick="lnkEnableDate_Click">
                                                                    </asp:LinkButton>
                                                                </div>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Installment Amount">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="Install_Amount" runat="server" placeholder="Installment Amount" Text='<%# Eval("Install_Amount") %>' CssClass="form-control" onkeypress="return allowonlynumbers(event,this);" ReadOnly="true"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Installment Balance">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="balance_Amount" runat="server" placeholder="Balance Amount" Text='<%# Eval("balance_Amount") %>' CssClass="form-control" onkeypress="return allowonlynumbers(event,this);" ReadOnly="true"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row" runat="server" id="feetable" visible="true">
                                            <div class="col-md-12 table-responsive" style="overflow: auto; max-height: 400px;">
                                                <asp:GridView ID="grdfees" runat="server" Style="text-align: left;" AutoGenerateColumns="False" CssClass="table">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Sr.no">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl_sr_no" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle Width="5%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblflag" runat="server" Text='<%# Eval("flag")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblconcession" runat="server" Text='<%# Eval("concession")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl_struct_id" runat="server" Text='<%# Eval("Struct_id")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl_struct_type" runat="server" Text='<%# Eval("Struct_type")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="STRUCTURE NAME">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblstructname" runat="server" Text='<%# Eval("Struct_name")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle Width="20%" />
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
                                                                <div style="display: flex; align-items: center; gap: 6px;">
                                                                    <asp:TextBox ID="txtpay" runat="server" onkeypress="return isNumber(event)" MaxLength="10" placeholder="Pay Amount" Enabled='<%# !(Convert.ToBoolean(Eval("flag"))) %>' CssClass="form-control" Text='<%#Eval("concession") %>'></asp:TextBox>
                                                                    <asp:LinkButton ID="btn_save_waveoff" runat="server" CssClass='<%# Convert.ToBoolean(Eval("flag")) ? "btn btn-outline-danger bi bi-trash" : "btn btn-outline-success bi bi-save" %>' OnClick="btn_save_waveoff_Click">
                                                                    </asp:LinkButton>
                                                                </div>
                                                            </ItemTemplate>
                                                            <ItemStyle Width="30%" />
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
                            <button type="button" class="close btn btn-outline-secondary" data-bs-dismiss="modal" aria-bs-label="Close"><span aria-hidden="true">&times;</span></button>
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
                                                        <asp:Label ID="lblgroupid" runat="server" Text='<%# Eval("Group ID")%>' Style="display: none;"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Academic Year">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblyear" runat="server" Text='<%# Eval("Year")%>'></asp:Label>
                                                        <asp:Label ID="lblayid" runat="server" Text='<%# Eval("AYID")%>' Style="display: none;"></asp:Label>
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

    <script type="text/javascript">
        function preventKeyPress(e) {
            e.preventDefault();
        }
        Sys.Application.add_load(function () {
            datepic();
        });
        function openModal(name) {
            $("[id*=" + name + "]").modal('show');
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

        function datepic() {
            $('.datepicker').datetimepicker({
                timepicker: false,
                format: 'd/m/Y',
                minDate: 0 // Starts from today
            });
        }
        function Confirm() {
            var form = document.forms[0];

            var confirm_value = document.createElement("INPUT");
            if (confirm_value.value != "") {
                form.lastChild.remove();
            }
            var value = $('#<%= lblbal.ClientID %>').text().trim();
            confirm_value.defaultValue = "";
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Do you want to Redefine Installment with balance amount: " + value + " ?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }

            form.appendChild(confirm_value);
        }
        function redirect(name) {
            window.open(name, '_blank');
        }
    </script>
</asp:Content>

