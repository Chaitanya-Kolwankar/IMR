<%@ Page Title="" Language="C#" MasterPageFile="~/Portals/Staff/MasterPage.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="FeeEntry_New.aspx.cs" EnableSessionState="True" Inherits="FeeEntry_New" %>

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
                                    <div class="col-md-2 text-center" style="align-content: center;">
                                        <asp:CheckBox ID="chk_bx" runat="server" Text="Search by Name" OnCheckedChanged="chk_bx_CheckedChanged" AutoPostBack="true" />
                                    </div>
                                    <div class="col-md-2" runat="server" id="div_stud_id">
                                        <asp:TextBox ID="txt_studid" runat="server" CssClass="form-control" placeholder="Student ID" MaxLength="8" onkeypress="return isNumber(event)" Text="22101096"></asp:TextBox>
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
                                                <b>BALANCE AMOUNT : </b>
                                                <asp:Label ID="lblbal" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="col-md-2">
                                                Payment Mode
                                                    <asp:DropDownList ID="ddlmode" runat="server" AutoPostBack="true" CssClass="form-select" OnSelectedIndexChanged="ddlmode_SelectedIndexChanged">
                                                        <asp:ListItem>--Select--</asp:ListItem>
                                                        <asp:ListItem>Cash</asp:ListItem>
                                                        <asp:ListItem>Cheque</asp:ListItem>
                                                        <asp:ListItem>DD</asp:ListItem>
                                                        <asp:ListItem>ECS\NEFT\RTGS</asp:ListItem>
                                                        <asp:ListItem>Online Pay</asp:ListItem>
                                                    </asp:DropDownList>
                                            </div>
                                            <div class="col-md-2">
                                                Pay Date
                                                    <asp:TextBox ID="txtpaydate" runat="server" CssClass="form-control" placeholder=" (dd/mm/yyyy)" autocomplete="off"></asp:TextBox>
                                            </div>
                                            <div class="col-md-2" id="div_install" runat="server" visible="false">
                                                Installment.
                                                <asp:DropDownList ID="ddl_install" runat="server" AutoPostBack="true" CssClass="form-select" OnSelectedIndexChanged="ddl_install_SelectedIndexChanged"></asp:DropDownList>
                                                <asp:HiddenField ID="hidden_install_amount" runat="server" ClientIDMode="Static" />
                                            </div>
                                            <div class="col-md-2" id="div_amount" runat="server" visible="false">
                                                Enter Amount :
                                                <asp:TextBox ID="txt_amount" runat="server" CssClass="form-control" placeholder="Amount" MaxLength="8" onkeypress="return isNumber(event)" autocomplete="off" AutoPostBack="true" OnTextChanged="txt_amount_TextChanged"></asp:TextBox>
                                                <asp:HiddenField ID="hidden_install_bal" runat="server" ClientIDMode="Static" />
                                                <asp:HiddenField ID="hidden_install_Id" runat="server" ClientIDMode="Static" />
                                                <asp:HiddenField ID="hidden_recpt_no" runat="server" ClientIDMode="Static" />
                                            </div>
                                            <div class="col-md-2" id="div_fine" runat="server" visible="false">
                                                <div class="row">
                                                    <div class="col-md-2 d-flex align-items-end justify-content-center fs-3">+</div>
                                                    <div class="col-md-10">
                                                        <asp:CheckBox ID="chk_fine" runat="server" Text="Fine" OnCheckedChanged="chk_fine_CheckedChanged" AutoPostBack="true" />
                                                        <asp:TextBox ID="txt_fine" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
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
                                        <div class="row" runat="server" id="feetable">
                                            <div class="col-md-12 table-responsive" style="overflow: auto; max-height: 400px;">
                                                <asp:GridView ID="grdfees" runat="server" Style="text-align: left;" AutoGenerateColumns="False" CssClass="table">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Sr.no">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl_sr_no" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle Width="10%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblflag" runat="server" Text='<%# Eval("flag")%>'></asp:Label>
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
                                                                <asp:TextBox ID="txtpay" runat="server" onkeypress="return isNumber(event)" ReadOnly="true" MaxLength="10" placeholder="Pay Amount" Enabled='<%# !(Convert.ToBoolean(Eval("flag"))) %>' CssClass="form-control"></asp:TextBox>
                                                            </ItemTemplate>
                                                            <ItemStyle Width="20%" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </div>

                                        <div class="row" runat="server" id="btn" visible="false">
                                            <br />
                                            <div class="col-md-4"></div>
                                            <div class="col-md-2">
                                                <asp:Button ID="btnsave" runat="server" CssClass="btn btn-primary  form-control" Text="Save" OnClick="btnsave_Click" />
                                            </div>
                                            <div class="col-md-2">
                                                <asp:Button ID="btncancel" runat="server" CssClass="btn btn-primary form-control" Text="Cancel" OnClick="btncancel_Click" />
                                            </div>
                                            <div class="col-md-4"></div>
                                        </div>
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
                                                        <asp:TemplateField HeaderText="Install_id" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Install_id" runat="server" Text='<%# Eval("Install_id")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="RECEIPT NO">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Receipt_no" runat="server" Text='<%# Eval("Receipt_no")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="STRUCTURE TYPE">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Type" runat="server" Text='<%# Eval("Type")%>'></asp:Label>
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
                                                        <asp:TemplateField HeaderText="PAY DATE">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Pay_date" runat="server" Text='<%# Eval("Pay_date")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="RECEIPT">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="btnprint" runat="server" CssClass="btn btn-outline-success bi bi-printer" OnClick="btnprint_Click"></asp:LinkButton>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" />
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

        <div class="modal" id="modal_fine" data-bs-backdrop="static">
            <div class="modal-dialog modal-lg">
                <div class="modal-content">
                    <div class="modal-header row">
                        <div class="col-md-10">
                            <h2 class="modal-title">Remove Fine</h2>
                        </div>
                        <div class="col-md-2" style="display: flex; justify-content: flex-end;">
                            <button type="button" class="close btn btn-outline-secondary" data-bs-dismiss="modal" aria-bs-label="Close"><span aria-hidden="true">&times;</span></button>
                        </div>
                    </div>
                    <div class="modal-body">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <div class="row" style="font-size: 15px; text-align: center">
                                    <div class="col-md-4">
                                        <b>STUDENT ID :</b>
                                        <asp:Label ID="fine_stud_id" runat="server"></asp:Label>
                                    </div>
                                    <div class="col-md-8">
                                        <b>NAME :</b>
                                        <asp:Label ID="fine_name" runat="server"></asp:Label>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-12 table-responsive" style="max-height: 300px; overflow: auto">
                                        <asp:GridView ID="grd_fine" runat="server" Style="text-align: center;" AutoGenerateColumns="False" CssClass="table">
                                            <RowStyle HorizontalAlign="Center"></RowStyle>
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
                                                        <asp:Label ID="Due_date" runat="server" placeholder="Date" Text='<%# Eval("Due_date") %>' CssClass="datepicker" onkeypress="preventKeyPress(event);" AutoComplete="off" Enabled='<%# Convert.ToString(Eval("Due_date")) ==""?true:false %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Installment Amount">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Install_Amount" runat="server" placeholder="Installment Amount" Text='<%# Eval("Install_Amount") %>' onkeypress="return allowonlynumbers(event,this);" ReadOnly="true"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Installment Balance">
                                                    <ItemTemplate>
                                                        <asp:Label ID="balance_Amount" runat="server" placeholder="Balance Amount" Text='<%# Eval("balance_Amount") %>' onkeypress="return allowonlynumbers(event,this);" ReadOnly="true"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Fine Amount">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Fine_Amount" runat="server" placeholder="Balance Amount" Text='<%# Eval("Fine_Amount") %>' onkeypress="return allowonlynumbers(event,this);" ReadOnly="true"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Days Past">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Days_Past" runat="server" placeholder="Balance Amount" Text='<%# Eval("Days_Past") %>' onkeypress="return allowonlynumbers(event,this);" ReadOnly="true"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Remove Fine">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="Remove_Fine" runat="server" CssClass="btn btn-outline-danger bi bi-check" OnClick="Remove_Fine_Click"></asp:LinkButton>
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

