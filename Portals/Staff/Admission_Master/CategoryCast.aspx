<%@ Page Title="" Language="C#" MasterPageFile="~/Portals/Staff/MasterPage.master" AutoEventWireup="true" CodeFile="CategoryCast.aspx.cs" Inherits="Portals_Staff_Admission_Master_CategoryCast" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <%--    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>--%>
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.20/js/jquery.dataTables.min.js"></script>
    <link href="https://cdn.datatables.net/1.10.20/css/jquery.dataTables.css" rel="stylesheet" type="text/css" />
    <script src="notify-master/js/notify.js"></script>
    <link href="notify-master/css/notify.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />
    <style>
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
            text-transform: capitalize;
        }

        .FixedHeader {
            position: sticky;
            font-weight: bold;
            top: 0;
        }
    </style>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">

                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">

                        <ContentTemplate>

                            <asp:TextBox runat="server" class="form-control" Visible="false" ID="mainId" />
                            <label id="Label1" runat="server">Enter:</label>
                            <asp:TextBox runat="server" class="form-control" AutoCompleteType="Disabled" onkeyPress="return alphaandnum(event)" ValidationGroup="insertMain" ID="categoryTxt" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="insertMain" ControlToValidate="categoryTxt" runat="server" ErrorMessage="please fill up this feild"></asp:RequiredFieldValidator>
                            <br />

                            <br />
                            <br />
                            <asp:Button runat="server" Text="Insert" ValidationGroup="insertMain" ID="insertMain" OnClick="insertMain_Click" class="btn btn-primary" />
                            <asp:Button runat="server" Text="Clear" ID="clearTxt" OnClick="clearTxt_Click" class="btn btn-primary" />
                            <br />
                            <br />
                        </ContentTemplate>

                    </asp:UpdatePanel>
                </div>
                <div class="" style="width: 100%">
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>


                            <asp:GridView ID="mainGrid1" DataKeyNames="id" AutoGenerateColumns="false" OnRowUpdating="mainGrid_RowUpdating" runat="server">
                                <Columns>
                                    <asp:TemplateField HeaderText="Id" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="idmodal" Text='<%# Eval("id") %>'>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Main">
                                        <ItemTemplate>
                                            <asp:Label ID="txtmodal" runat="server" Text='<%# Eval("main") %>'>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField>
                                        <ItemTemplate>

                                            <asp:LinkButton runat="server" ID="modalEdit" CommandName="Update" ToolTip="Select"><i class="bi bi-pencil"></i></asp:LinkButton>


                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" ID="modalDelete" OnClick="modalDelete_Click" ToolTip="Delete">
                                                       
                                                        <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" color="red" fill="currentColor" class="bi bi-trash3" viewBox="0 0 16 16">
  <path d="M6.5 1h3a.5.5 0 0 1 .5.5v1H6v-1a.5.5 0 0 1 .5-.5ZM11 2.5v-1A1.5 1.5 0 0 0 9.5 0h-3A1.5 1.5 0 0 0 5 1.5v1H2.506a.58.58 0 0 0-.01 0H1.5a.5.5 0 0 0 0 1h.538l.853 10.66A2 2 0 0 0 4.885 16h6.23a2 2 0 0 0 1.994-1.84l.853-10.66h.538a.5.5 0 0 0 0-1h-.995a.59.59 0 0 0-.01 0H11Zm1.958 1-.846 10.58a1 1 0 0 1-.997.92h-6.23a1 1 0 0 1-.997-.92L3.042 3.5h9.916Zm-7.487 1a.5.5 0 0 1 .528.47l.5 8.5a.5.5 0 0 1-.998.06L5 5.03a.5.5 0 0 1 .47-.53Zm5.058 0a.5.5 0 0 1 .47.53l-.5 8.5a.5.5 0 1 1-.998-.06l.5-8.5a.5.5 0 0 1 .528-.47ZM8 4.5a.5.5 0 0 1 .5.5v8.5a.5.5 0 0 1-1 0V5a.5.5 0 0 1 .5-.5Z"/>
</svg>
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                </Columns>
                            </asp:GridView>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>

    <div class="main" id="main">
        <div class="container-fluid">
            <div class="pagetitle" style="font-size: 29px; margin-left: 34px; font-weight: 300; color: #012970;">
                Admission Master 
            </div>
            <div class="container-fluid">
                <div class="card">
                    <div class="card-title mx-4">
                        Category And Caste Master 
                 
                    </div>
                    <div class="card-body">
                        <div class="container-fluid">
                            <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="dropDown" EventName="SelectedIndexChanged" />
            </Triggers>
            <ContentTemplate>--%>


                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div class="row">



                                        <div class="col-2">
                                            <asp:Label runat="server" ID="id" placeholder="AUTO-INCREMENTED" hidden="true"></asp:Label>

                                            <label class="">Main :</label>
                                            <%--<asp:TextBox runat="server" ID="main" placeholder="" ValidationGroup="Register" class="mt-2" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="nameRequired" ControlToValidate="main" ValidationGroup="Register" runat="server" ErrorMessage="please fill up this feild"></asp:RequiredFieldValidator>--%>

                                            <asp:DropDownList runat="server" ID="dropDown" ValidationGroup="Register" OnSelectedIndexChanged="dropDown_SelectedIndexChanged" CssClass="form-select" AutoPostBack="true">

                                            </asp:DropDownList>


                                        </div>

                                        <div class="col-1">

                                            <button type="button" class="bg-white border-white" style="outline: none; margin-top: 25px" data-bs-toggle="modal" data-bs-target="#exampleModal">
                                                <i class="bi bi-plus-lg"></i>
                                            </button>
                                        </div>


                                     
                                        <div class="col-2">

                                            <label class="">Parent :</label>
                                            <asp:TextBox runat="server" CssClass="form-control" ID="parent" onkeyPress="return alphaandnum(event)" MaxLength="100" placeholder="" class="mt-2" ValidationGroup="Register"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="parentRequired" ControlToValidate="parent" runat="server" ValidationGroup="Register" ErrorMessage="please fill up this feild"></asp:RequiredFieldValidator>
                                            <br />

                                            <%-- <asp:RegularExpressionValidator runat="server" ID="parentRegex" ErrorMessage="special character are not allowed"  ValidationExpression="^(?=[a-zA-Z0-9~@#$^*()_+=[\]{}|\\,.?: -]*$)(?!.*[<>'"/;`%])" ControlToValidate="parent" > </asp:RegularExpressionValidator>--%>
                                        </div>


                                        <div class="col-2">
                                            <label class="">Child :</label>
                                            <asp:TextBox runat="server" CssClass="form-control" MaxLength="200" onkeyPress="return alphaandnum(event)" ID="child" placeholder="" ValidationGroup="Register" class="mt-2"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="childRequired" ControlToValidate="child" runat="server" ValidationGroup="Register" ErrorMessage="please fill up this feild"></asp:RequiredFieldValidator>
                                            <br />

                                        </div>









                                        <div class="col-1">
                                            <label class="">&nbsp</label><br />
                                            <asp:Button runat="server" ID="insert" ValidationGroup="Register" class="btn btn-primary" Text="Add" OnClick="insert_Click" Width="100%" />
                                        </div>
                                        <%--   <div class="col-1">
                            <label class=""> &nbsp</label><br />
                            <asp:Button runat="server" ID="update" ValidationGroup="Register" class="btn btn-primary" Text="Update" OnClick="update_Click" Width="100%"/>
                            </div>--%>
                                        <div class="col-1">
                                            <label class="">&nbsp</label><br />
                                            <asp:Button runat="server" ID="clear" class="btn btn-primary" Text="clear" OnClick="clear_Click" Width="100%" />
                                        </div>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="dropDown" EventName="SelectedIndexChanged" />
                                </Triggers>

                            </asp:UpdatePanel>

                        </div>



                        <%-- gridview  class="text-center mt-5 w-100 "CellPadding="4" ForeColor="#333333"--%>

                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>


                                <div class="" id="mydiv" style="height: 400px">
                                    <asp:GridView runat="server" ID="gridView1" AutoGenerateColumns="False" DataKeyNames="id" OnRowUpdating="gridView1_RowUpdating" OnRowDataBound="gridView1_RowDataBound">
                                        <%----%>

                                        <Columns>
                                            <asp:TemplateField HeaderText="Id" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label runat="server" ID="id" Text='<%# Eval("id") %>'>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Main">
                                                <ItemTemplate>
                                                    <asp:Label ID="mainTxt" runat="server" Text='<%# Eval("Main") %>'>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Parent">
                                                <ItemTemplate>
                                                    <asp:Label ID="parentTxt" runat="server" Text='<%# Eval("Parent") %>'>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Child">
                                                <ItemTemplate>
                                                    <asp:Label ID="childTxt" runat="server" Text='<%# Eval("Child") %>'>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField>
                                                <ItemTemplate>

                                                    <asp:LinkButton runat="server" ID="selectData" CommandName="Update" ToolTip="Select" Text="" OnClick="selectData_Click" class=""><i class="bi bi-pencil"></i></asp:LinkButton>


                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:LinkButton runat="server" ID="deleteData" Text="" OnClick="deleteData_Click" class="">
                                                       
                                                        <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" color="red" fill="currentColor" class="bi bi-trash3" viewBox="0 0 16 16">
  <path d="M6.5 1h3a.5.5 0 0 1 .5.5v1H6v-1a.5.5 0 0 1 .5-.5ZM11 2.5v-1A1.5 1.5 0 0 0 9.5 0h-3A1.5 1.5 0 0 0 5 1.5v1H2.506a.58.58 0 0 0-.01 0H1.5a.5.5 0 0 0 0 1h.538l.853 10.66A2 2 0 0 0 4.885 16h6.23a2 2 0 0 0 1.994-1.84l.853-10.66h.538a.5.5 0 0 0 0-1h-.995a.59.59 0 0 0-.01 0H11Zm1.958 1-.846 10.58a1 1 0 0 1-.997.92h-6.23a1 1 0 0 1-.997-.92L3.042 3.5h9.916Zm-7.487 1a.5.5 0 0 1 .528.47l.5 8.5a.5.5 0 0 1-.998.06L5 5.03a.5.5 0 0 1 .47-.53Zm5.058 0a.5.5 0 0 1 .47.53l-.5 8.5a.5.5 0 1 1-.998-.06l.5-8.5a.5.5 0 0 1 .528-.47ZM8 4.5a.5.5 0 0 1 .5.5v8.5a.5.5 0 0 1-1 0V5a.5.5 0 0 1 .5-.5Z"/>
</svg>
                                                    </asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                        </Columns>

                                        <%--  <AlternatingRowStyle BackColor="White" />

                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />--%>
                                        <%--<EmptyDataTemplate>Data Not Found </EmptyDataTemplate>--%>
                                    </asp:GridView>

                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%--   </div>--%>
    <script>
        var prm = Sys.WebForms.PageRequestManager.getInstance();

        prm.add_endRequest(function () {
            createDataTable();
        });

        createDataTable();

        function createDataTable() {
            $('#<%= gridView1.ClientID %>').DataTable();
        }


        function notify(msg, type) {
            $.notify(msg, { type: type, animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.2, delay: 0 });
        }
        function alphaandnum(event) {
            var val = String.fromCharCode(event.which);
            var pattern = new RegExp(/^[A-Za-z0-9\s]+$/);
            return pattern.test(val);
        }
    </script>
</asp:Content>

