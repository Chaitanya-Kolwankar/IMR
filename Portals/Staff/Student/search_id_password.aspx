<%@ Page Title="" Language="C#" MasterPageFile="~/Portals/Staff/MasterPage.master" AutoEventWireup="true" CodeFile="search_id_password.aspx.cs" Inherits="Student_search_id_password" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main" class="main">
        <div class="container-fluid my-1">
            <div class="card">
                <div class="container-fluid">
                    <div class="row">
                        <div class="col-md">
                            <div class="panel panel-primary">
                                <div class="card-title" style="font-size: large">Search Student ID/Password </div>
                                <div class="panel-body">
                                    <div class="row">
                                        <div class="col-sm-2">
                                            Student ID:<br />
                                            <asp:TextBox ID="txtstudentid" CssClass="form-control" runat="server" placeholder=""></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="regularexpressionvalidator1" runat="server" ControlToValidate="txtstudentid" ForeColor="Red" ErrorMessage="*3 Charachter Required" ValidationExpression=".{3}.*"></asp:RegularExpressionValidator>

                                        </div>


                                        <div class="col-sm-2">
                                            First Name:<br />
                                            <asp:TextBox ID="txtfname" CssClass="form-control" runat="server" placeholder=""></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="regularexpressionvalidator2" runat="server" ControlToValidate="txtfname" ForeColor="Red" ErrorMessage="*3 Characters Required" ValidationExpression=".{3}.*"></asp:RegularExpressionValidator>
                                        </div>

                                        <div class="col-sm-2">
                                            Middle Name:<br />
                                            <asp:TextBox ID="txtmname" CssClass="form-control" runat="server" placeholder=""></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="regularexpressionvalidator3" runat="server" ControlToValidate="txtmname" ForeColor="Red" ErrorMessage="*3 Characters Required" ValidationExpression=".{3}.*"></asp:RegularExpressionValidator>
                                        </div>
                                        <div class="col-sm-2">
                                            Last Name:<br />
                                            <asp:TextBox ID="txtlname" CssClass="form-control" runat="server" placeholder=""></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="regularexpressionvalidator4" runat="server" ControlToValidate="txtlname" ForeColor="Red" ErrorMessage="*3 Characters Required" ValidationExpression=".{3}.*"></asp:RegularExpressionValidator>
                                        </div>
                                        <div class="col-sm-2" style="margin-top: 23px">
                                            <asp:Button ID="button1" Class="btn btn-primary" runat="server" OnClick="button1_Click" Width="100%" BorderStyle="Groove" Text="Search" />
                                        </div>
                                        <div class="col-sm-2" style="margin-top: 23px">
                                            <asp:Button ID="button2" Class="btn btn-primary" runat="server" OnClick="button2_Click" Width="100%" BorderStyle="Groove" Text="Clear" />
                                        </div>
                                        <div class="container">
                                            <div class="row">
                                                <div class="col-lg" style="margin-top: 25px; text-align: center; overflow-y: auto; max-height: 450px">
                                                    <asp:GridView ID="GridView1" runat="server" CellPadding="15" CellSpacing="5" BorderColor="White" HorizontalAlign="Center" Width="100%" ForeColor="#333333" GridLines="None">
                                                        <AlternatingRowStyle BackColor="White" />
                                                        <EditRowStyle BackColor="#2461BF" />
                                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                        <HeaderStyle BackColor="#007bff" Font-Bold="True" ForeColor="White" />
                                                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                                        <RowStyle BackColor="#EFF3FB" />
                                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
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
        </div>
    </div>

</asp:Content>

