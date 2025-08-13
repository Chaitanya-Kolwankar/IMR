<%@ Page Title="" Language="C#" MasterPageFile="~/Portals/Staff/MasterPage.master" AutoEventWireup="true" CodeFile="Fee_Master.aspx.cs" Inherits="Fee_Master" %>

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
                Admission Master
            </div>
            <div class="container-fluid ">
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <div class="card">
                            <div class="card-title mx-4" style="font-size: 21px">
                                Fee Master
                            </div>
                            <div class="card-body">
                                <div class="row">
                                    <%--<div class="col-lg-1 col-md-1 col-sm-0 col-xs-0"></div>--%>
                                    <div class="col-lg-2 col-md-2 col-sm-12 col-xs-12">
                                        <asp:Label ID="Label2" runat="server" Text="Faculty :"></asp:Label><br />
                                        <asp:DropDownList ID="ddl_faculty" runat="server" CssClass="form-select" OnSelectedIndexChanged="ddl_faculty_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                    </div>
                                    <div class="col-lg-2 col-md-2 col-sm-12 col-xs-12">
                                        <asp:Label ID="Label3" runat="server" Text="Course :"></asp:Label><br />
                                        <asp:DropDownList ID="ddl_course" runat="server" CssClass="form-select" OnSelectedIndexChanged="ddl_course_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                    </div>
                                    <div class="col-lg-2 col-md-2 col-sm-12 col-xs-12">
                                        <asp:Label ID="Label4" runat="server" Text="Subcourse :"></asp:Label><br />
                                        <asp:DropDownList ID="ddl_subcourse" runat="server" CssClass="form-select" OnSelectedIndexChanged="ddl_subcourse_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                    </div>
                                    <div class="col-lg-2 col-md-2 col-sm-12 col-xs-12">
                                        <asp:Label ID="Label5" runat="server" Text="Group :"></asp:Label><br />
                                        <asp:DropDownList ID="ddl_group" runat="server" CssClass="form-select" OnSelectedIndexChanged="ddl_group_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                    </div>
                                    <div class="col-lg-2 col-md-2 col-sm-12 col-xs-12">
                                        <asp:Label ID="Label1" runat="server" Text="Structure Type :"></asp:Label><br />
                                        <asp:DropDownList ID="ddl_struct_type" runat="server" CssClass="form-select" OnSelectedIndexChanged="ddl_struct_type_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                    </div>
                                    <div class="col-lg-1 col-md-1 col-sm-12 col-xs-12">
                                        <br />
                                        <asp:LinkButton ID="btn_struct_type" runat="server" Text="" CssClass="btn btn-primary" OnClick="btn_struct_type_Click" OnClientClick="modal_confirm();"><i class="bi bi-plus"></i></asp:LinkButton>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-lg-4 col-md-4 col-sm-0 col-xs-0"></div>
                                    <div class="col-lg-2 col-md-4 col-sm-12 col-xs-12">
                                        <asp:Button ID="btn_save" runat="server" Text="Save" CssClass="btn btn-primary btn-block form-control" OnClick="btn_save_Click" />
                                    </div>
                                    <div class="col-lg-2 col-md-4 col-sm-12 col-xs-12">
                                        <asp:Button ID="btn_clear" runat="server" Text="Clear" CssClass="btn btn-primary btn-block form-control" OnClick="btn_clear_Click" />
                                    </div>
                                </div>
                                <div runat="server" visible="false" id="div_use_warning" class="card card-body bg-danger-light p-0 mt-4" style="text-align:center"><span class="p-2 text-danger">Updation Prohibited as Fee Structure Already Is In Use !!</span></div>
                                <br />
                                <div class="row">
                                    <div class="col-md-12 col-sm-12 col-xs-12 table-responsive" style="overflow: auto; max-height: 400px; width: 100%;">
                                        <asp:GridView ID="grd_fee" runat="server" AutoGenerateColumns="false" CssClass="table">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Hstruct_id" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="struct_id" runat="server" Text='<%# Eval("Struct_id") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Hupdt_flag" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="updt_flag" runat="server" Text='<%# Eval("updt_flag") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Struct Name">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txt_struct" runat="server" placeholder="Struct Name" Text='<%# Eval("Struct_name") %>' CssClass="form-control" onkeypress="return allowOnlyLetters(event,this);" AutoComplete="off" MaxLength="30"></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Amount">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txt_amount" runat="server" placeholder="Amount" Text='<%# Eval("Amount") %>' CssClass="form-control" onkeypress="return allowonlynumbers(event,this);" AutoComplete="off" MaxLength="7"></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Rank">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txt_rank" runat="server" placeholder="Rank" Text='<%# Eval("Rank") %>' CssClass="form-control" onkeypress="return allowonlynumbers(event,this);" AutoComplete="off" MaxLength="7"></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Edit">
                                                    <ItemTemplate>
                                                        <asp:LinkButton runat="server" ID="btn_edit" ToolTip="Edit" OnClick="btn_edit_Click"><i class="bi bi-pencil"  style="font-size:18px;"></i></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Delete">
                                                    <ItemTemplate>
                                                        <asp:LinkButton runat="server" ID="btn_delete" ForeColor="red" OnClick="btn_delete_Click" OnClientClick='<%# Convert.ToString(Eval("Struct_id")) == ""?"return false;":"Confirm();" %>' ToolTip="Delete"><i class="bi bi-trash" style="font-size:18px;"></i></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                                    <HeaderTemplate>
                                                        <asp:LinkButton runat="server" ID="btn_add" CssClass="btn btn-outline-primary bg-primary-light form-control" ToolTip="Add Row" OnClick="btn_add_Click"><i class="bi bi-plus"></i></asp:LinkButton>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:LinkButton runat="server" ID="btn_remove" CssClass="btn btn-outline-danger bg-danger-light form-control" ToolTip="Remove Row" OnClick="btn_remove_Click"><i class="bi bi-dash"></i></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-12 col-sm-12 col-xs-12 table-responsive" style="overflow: auto; max-height: 400px; width: 100%;">
                                        <asp:GridView ID="grd_subdata" runat="server" AutoGenerateColumns="false" CssClass="table">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Sr.no">
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex + 1 %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="group_id" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="sub_grp_id" runat="server" Text='<%# Eval("group_id") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Subcourse_id" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="sub_Subcourse_id" runat="server" Text='<%# Eval("Subcourse_id") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="GROUP NAME">
                                                    <ItemTemplate>
                                                        <asp:Label ID="sub_grp_name" runat="server" Text='<%# Eval("Group_title") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Structure Type">
                                                    <ItemTemplate>
                                                        <asp:Label ID="sub_struct_type" runat="server" Text='<%# Eval("Struct_type") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Edit">
                                                    <ItemTemplate>
                                                        <asp:LinkButton runat="server" ID="sub_btn_edit" ToolTip="Edit" OnClick="sub_btn_edit_Click"><i class="bi bi-pencil"  style="font-size:18px;"></i></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Delete">
                                                    <ItemTemplate>
                                                        <asp:LinkButton runat="server" ID="sub_btn_delete" ForeColor="red" ToolTip="Delete" OnClick="sub_btn_delete_Click" OnClientClick="Confirm()"><i class="bi bi-trash" style="font-size:18px;"></i></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        <%-- Modal for Search Button --%>
        <div class="modal fade" id="Modal_Search" tabindex="-1" role="dialog" aria-labelledby="initialModalLabel" aria-hidden="true" data-bs-backdrop="static">
            <div class="modal-dialog">
                <div class="modal-content transparent-modal">
                    <div class="modal-body align-content-center flex-container transparent-modal">
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <div class="card shadow">
                                    <div class="card-header  border-bottom border-primary border-3 align-middle pt-2 pb-2">
                                        <label style="font-size: 1.1rem;">Structure Type</label>
                                        <span onclick="return modal_confirm_close();" style="cursor: pointer; font-size: 1.5rem; padding-left: 61%;">&times;</span>
                                    </div>
                                    <div class="card-body p-4">
                                        <div class="row">
                                            <div class="col-lg-8 col-md-8 col-sm-12 col-xs-12">
                                                <asp:HiddenField ID="hidden_Id_type" runat="server" ClientIDMode="Static" />
                                                <asp:Label ID="Label6" runat="server" Text="Type Name :"></asp:Label><br />
                                                <asp:TextBox runat="server" ID="txt_type_nm" CssClass="form-control caps" onkeypress="return allowOnlyLetters(event,this);" MaxLength="18"></asp:TextBox>
                                            </div>
                                            <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">
                                                <br />
                                                <asp:Button ID="btn_save_type" runat="server" Text="Save" CssClass="btn btn-primary btn-block form-control" OnClick="btn_save_type_Click" />
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="col-md-12 col-sm-12 col-xs-12 table-responsive" style="overflow: auto; max-height: 400px; width: 100%;">
                                                <asp:GridView ID="grd_type" runat="server" AutoGenerateColumns="false" CssClass="table">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Sr.no">
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex + 1 %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Struct_type_id" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Struct_type_id" runat="server" Text='<%# Eval("Struct_type_id") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Struct Type Name">
                                                            <ItemTemplate>
                                                                <asp:Label ID="type_name" runat="server" Text='<%# Eval("Struct_type_name") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Edit">
                                                            <ItemTemplate>
                                                                <asp:LinkButton runat="server" ID="tye_edit" ToolTip="Edit" OnClick="tye_edit_Click"><i class="bi bi-pencil"  style="font-size:18px;"></i></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Delete">
                                                            <ItemTemplate>
                                                                <asp:LinkButton runat="server" ID="type_delete" ForeColor="red" ToolTip="Delete" OnClick="type_delete_Click" OnClientClick="Confirm()"><i class="bi bi-trash" style="font-size:18px;"></i></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
        </div>
        <%-- Modal for Search Button --%>
    </div>
    <script type="text/javascript">
        function allowOnlyLetters(e, t) {
            if (window.event) {
                var charCode = window.event.keyCode;
            }
            else if (e) {
                var charCode = e.which;
            }
            else { return true; }
            if ((charCode > 64 && charCode < 91) || (charCode > 96 && charCode < 123) || charCode == 32)
                return true;
            else {
                return false;
            }
        }

        function allowonlynumbers(m, n) {
            if (window.event) {
                var phn = window.event.keyCode;
            }
            else if (m) {
                var phn = m.which;
            }
            else { return true; }
            if (phn > 47 && phn < 58)
                return true;
            else {
                return false;
            }
        }

        function Confirm() {
            var form = document.forms[0];

            var confirm_value = document.createElement("INPUT");
            if (confirm_value.value != "") {
                form.lastChild.remove();
            }

            confirm_value.defaultValue = "";
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Do you want to Delete data?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }

            form.appendChild(confirm_value);
        }
        function modal_confirm() {
            $('#Modal_Search').modal('show');
        }

        function modal_confirm_close() {
            $('#Modal_Search').modal('hide');
        };

        function notify(msg, type) {
            $.notify(msg, { type: type, animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.2, delay: 0 });
        }
    </script>
</asp:Content>

