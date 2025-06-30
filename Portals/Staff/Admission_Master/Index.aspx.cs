<%@ Page Title="" Language="C#" MasterPageFile="~/Portals/Staff/MasterPage.master" AutoEventWireup="true" CodeFile="Define_Intake.aspx.cs" Inherits="Portals_Staff_Admission_Master_Define_Intake" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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
    <div id="main" class="main">
        <div class="container-fluid">
            <div class="pagetitle " style="font-size: 32px; margin-left: 34px; font-weight: 300; color: #012970;">
                Admission
            </div>
            <div class="container-fluid ">

                <%--<asp:ScriptManager ID="scriptmanager1" runat="server">
                </asp:ScriptManager>--%>
                <div class="row">
                    <div class="col-md-12">
                        <div class="card">
                            <div class="card-title mx-4" style="font-size: 21px">Define Intake </div>
                            <div class="card-body ">
                                <div class="row">
                                    <div class="col-lg-2">
                                        <label for="inputState" class="form-label"> Course</label>
                                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddl_Course" CssClass="form-select" runat="server" OnSelectedIndexChanged="ddl_Course_SelectedIndexChanged" AutoPostBack="true">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="col-lg-2">
                                        <label for="inputState" class="form-label"> SubCourse</label>
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddl_SubCourse" CssClass="form-select" runat="server" OnSelectedIndexChanged="ddl_SubCourse_SelectedIndexChanged" AutoPostBack="true">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="col-lg-1">
                                        <asp:UpdatePanel runat="server">
                                            <ContentTemplate>
                                                <asp:Button ID="Button2" Text="Save" runat="server" CssClass="btn btn-primary" Style="width: 100%; margin-top:31px;" OnClick="Save_Click" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        
                                    </div>
                                    <div class="col-lg-1">
                                          <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                            <ContentTemplate>
                                        <asp:Button ID="Button1" Text="Clear" runat="server" CssClass="btn btn-primary" Style="width: 100%; margin-top:31px" OnClick="Clear_Click" />
                                                </ContentTemplate></asp:UpdatePanel>
                                    </div>

                                </div>
                                <br />
                                <div style="width: 100%; max-height: 400px; overflow:auto"> 
                                <div>
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
                                            <asp:GridView ID="GrdIn" runat="server" AutoGenerateColumns="false" HeaderStyle-CssClass="FixedHeader" HeaderStyle-BackColor="White" Style="overflow: auto; max-height: 400px;">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Group Id" HeaderStyle-CssClass="text-blue" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="GroupId" runat="server" ItemStyle-CssClass="caps" Text='<%#Eval("Group_id")%>'></asp:Label>

                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Group Title" HeaderStyle-CssClass="text-blue">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDuration" runat="server" ItemStyle-CssClass="caps" Text='<%#Eval("Group_title")%>'></asp:Label>

                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Intake" HeaderStyle-CssClass="text-blue">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="chk_IsCurrent" runat="server" MaxLength="10" onkeyPress="return OnlyNum(event)" ItemStyle-CssClass="form-control caps" Text='<%#Eval("intake")%>' oncopy="return false"
onpaste="return false"
oncut="return false" ></asp:TextBox>

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
                    </div>

                </div>

            </div>
        </div>
    </div>
    <script>
        function OnlyNum(event) {
            var value = String.fromCharCode(event.which);
            var pattern = new RegExp(/[0-9]/i);
            return pattern.test(value);
        }

        function notify(msg, type) {
            $.notify(msg, { type: type, animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.2, delay: 0 });
        }
    </script>
</asp:Content>

