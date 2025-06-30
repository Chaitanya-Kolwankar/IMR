<%--<%@ Page Language="C#" AutoEventWireup="true" CodeFile="editDelete.aspx.cs" Inherits="editDelete" %>--%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>


    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous">


   <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
<script type="text/javascript" src="https://cdn.datatables.net/1.10.20/js/jquery.dataTables.min.js"></script>
<link href="https://cdn.datatables.net/1.10.20/css/jquery.dataTables.css" rel="stylesheet" type="text/css" />
    
    
</head>
<body>
    <form id="form1" runat="server">
        <%-- Registration Form  --%>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="dropDown" EventName="SelectedIndexChanged" />
            </Triggers>
            <ContentTemplate>
                <div class="text-center text-uppercase">
                    <h1>Registration Page</h1>
                </div>
                <div class="row">
                    <div class="col"></div>
                    <div class="col d-flex flex-column">


                     

                        <asp:label runat="server" ID="id" placeholder="AUTO-INCREMENTED" hidden="true"  class="mt-2" ></asp:label>

                        <label class="mt-3">Main :</label>
                        <%--<asp:TextBox runat="server" ID="main" placeholder="" ValidationGroup="Register" class="mt-2" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="nameRequired" ControlToValidate="main" ValidationGroup="Register" runat="server" ErrorMessage="please fill up this feild"></asp:RequiredFieldValidator>--%>
                        <asp:DropDownList runat="server" ID="dropDown" OnSelectedIndexChanged="dropDown_SelectedIndexChanged" AutoPostBack="true">

                            <asp:ListItem Value="0">--Select--</asp:ListItem>

                            <asp:ListItem Value="State" Text="state">State</asp:ListItem>
                            <asp:ListItem Value="Reserved Category" Text="Reserved">Reserved Category</asp:ListItem>
                        </asp:DropDownList>



                        <label class="mt-3">Parent :</label>
                        <asp:TextBox runat="server" ID="parent" placeholder="" class="mt-2" ValidationGroup="Register"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="parentRequired" ControlToValidate="parent" runat="server" ValidationGroup="Register" ErrorMessage="please fill up this feild"></asp:RequiredFieldValidator>




                        <label class="mt-3">Child :</label>
                        <asp:TextBox runat="server" ID="child" placeholder="" ValidationGroup="Register" class="mt-2"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="childRequired" ControlToValidate="child" runat="server" ValidationGroup="Register" ErrorMessage="please fill up this feild"></asp:RequiredFieldValidator>













                        <div class="mt-3">
                            <asp:Button runat="server" ID="insert" ValidationGroup="Register" class="btn btn-primary" Text="Add" OnClick="insert_Click" />
                            <asp:Button runat="server" ID="update" ValidationGroup="Register" class="btn btn-primary" Text="Update" OnClick="update_Click" />
                            <asp:Button runat="server" ID="clear" class="btn btn-primary" Text="clear" OnClick="clear_Click" />
                        </div>



                    </div>
                    <div class="col"></div>

                </div>

                <%-- gridview --%>
                <div class=" overflow-scroll mt-3" id="mydiv" style="height: 400px">
                    <asp:GridView runat="server" ID="gridView1" CellPadding="4" AutoGenerateColumns="false" class="text-center mt-5 w-100 " DataKeyNames="id" ForeColor="#333333" GridLines="None" OnRowUpdating="gridView1_RowUpdating" OnRowDataBound="gridView1_RowDataBound">
                        <%----%>

                        <Columns>
                            <asp:TemplateField HeaderText="ID">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="id" Text='<%# Eval("id") %>'>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="MAIN">
                                <ItemTemplate>
                                    <asp:Label ID="mainTxt" runat="server" Text='<%# Eval("Main") %>'>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="PARENT">
                                <ItemTemplate>
                                    <asp:Label ID="parentTxt" runat="server" Text='<%# Eval("Parent") %>'>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="CHILD">
                                <ItemTemplate>
                                    <asp:Label ID="childTxt" runat="server" Text='<%# Eval("Child") %>'>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" ID="selectData" CommandName="Update" ToolTip="Select" Text="Select" class="btn btn-primary" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" ID="deleteData" Text="Delete" OnClick="deleteData_Click" class="btn btn-danger" a />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>

                        <AlternatingRowStyle BackColor="White" />

                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                        <%--<EmptyDataTemplate>Data Not Found </EmptyDataTemplate>--%>
                    </asp:GridView>

                </div>
            </ContentTemplate>
            
        </asp:UpdatePanel>
    </form>

    <script>
        var prm = Sys.WebForms.PageRequestManager.getInstance();

        prm.add_endRequest(function () {
            createDataTable();
        });

        createDataTable();

        function createDataTable() {
            $('#<%= gridView1.ClientID %>').DataTable();
        }
    </script>
</body>
</html>
