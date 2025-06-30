<%@ Page Title="" Language="C#" MasterPageFile="~/Portals/Staff/MasterPage.master" AutoEventWireup="true" CodeFile="AccessionNumberPrinting.aspx.cs" Inherits="AccessionNumberPrinting" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--<asp:ScriptManager runat="server"></asp:ScriptManager>--%>
    <%--accession printing numbre--%>
   <div id="main" class="main">
        <div class="pagetitle " style="font-size: 32px; margin-left: 34px; font-weight: 300; color: #012970;">
            Range 
        </div>
        <div class="container-fluid">


            <div id="Range" class="">
                <div class="card card-primary">
                    <div class="card-body">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <%--UpdateMode="Always"--%>
                                <div class="row" style="padding-top:12px;">
                                    <div class="col-lg-4"></div>
                                    <div class="col-lg-4"></div>
                                    <div class="col-lg-4">
                                        Connect To:
        <asp:DropDownList CssClass="form-control" runat="server" ID="ddl_connect" AutoPostBack="true" OnSelectedIndexChanged="ddl_connect_SelectedIndexChanged">
           <%-- <asp:ListItem>Viva Engg</asp:ListItem>
            <asp:ListItem>MCA</asp:ListItem>--%>
            <asp:ListItem>VIVA IMR</asp:ListItem>
            <%--<asp:ListItem>Viva IMR</asp:ListItem>--%>
            <%-- <asp:ListItem>Viva IMS</asp:ListItem>--%>
        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="row">

                                    <div class="col-lg-3">
                                        SEARCH FOR:
                                <asp:DropDownList ID="ddlsearchtype" runat="server" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="ddlsearchtype_SelectedIndexChanged" OnTextChanged="ddlsearchtype_TextChanged">
                                    <asp:ListItem>--Select--</asp:ListItem>
                                    <asp:ListItem>BOOK</asp:ListItem>
                                    <asp:ListItem>CD</asp:ListItem>
                                    <%--<asp:ListItem>SERIAL</asp:ListItem>--%>
                                </asp:DropDownList>
                                    </div>
                                    <div class="col-lg-3">
                                        PREFIX:
                                <asp:DropDownList ID="ddlloadaccession" runat="server" CssClass="form-control">
                                </asp:DropDownList>
                                    </div>
                                    <div class="col-lg-3">
                                        From:
                                 <input type="number" runat="server" id="numfrom" class="form-control" min="1" style="border-radius: 5px" />
                                    </div>
                                    <div class="col-lg-3">
                                        To:
                                 <input type="number" runat="server" id="numto" class="form-control" min="1" style="border-radius: 5px" />
                                    </div>
                                </div>
                                <div class="row" style="padding-top:12px;">
                                    <div class="col-lg-12">
                                        <div class="col-lg-4">
                                            Enter Accession:
                                    <asp:TextBox ID="txtenteraccession" runat="server" CssClass="form-control" placeholder="Enter Accession Number" Style="text-transform: uppercase" OnTextChanged="txtenteraccession_TextChanged"></asp:TextBox>

                                        </div>
                                    </div>
                                </div>
                                <asp:PlaceHolder ID="plBarCode" runat="server" />
                                <div class="row" style="padding-top: 35px">

                                    <div class="col-lg-2">
                                        <asp:Button ID="btnadd" runat="server" class="btn btn-success" style="width:100%" OnClick="btnadd_Click" Text="Add"></asp:Button>
                                         
                                    </div>

                                    <div class="col-lg-2">
                                        <asp:Button ID="btnprintallno" runat="server" class="btn btn-primary " style="width:100%" Text="PRINT ALL IN ONE" OnClick="btnprintallno_Click"></asp:Button>

                                    </div>
                                    <%--<div class="col-lg-4">
                                    <a id="btnprintsingle" runat="server" class="btn btn-primary btn-block btn-sm"><i class="fa fa-print">&nbsp;PRINT FOR SINGLE</i></a>
                                </div>--%>
                                    <div class="col-lg-2">
                                        <asp:Button ID="btnclear" runat="server" CssClass="btn btn-danger"  style="width:100%" OnClick ="btnclear_Click" Text="Clear"></asp:Button>
                                    </div>
                                    <div class="col-lg-2">
                                        <asp:Label runat="server" CssClass="form-control" BorderStyle="None" ForeColor="Red" style="width:112%" Text="(Note:- Maximum range should be 36 numbers)"></asp:Label>
                                    </div>
                                    <div class="col-lg-2">
                                        <asp:Label ID="Label1" runat="server" CssClass="form-control" BorderStyle="None" Font-Bold="true" ForeColor="Green" Text="Total:-0"></asp:Label>
                                    </div>
                                    <div class="col-lg-2">
                                        <asp:Label ID="Label2" runat="server" CssClass="form-control" BorderStyle="None" ForeColor="Red"></asp:Label>
                                    </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>

                    <div class="row" style="padding-top: 5px;">
                        <center>
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <div class="table-responsive" style="overflow-y: scroll; overflow-x: scroll; height: 400px;">
                                    <asp:GridView ID="gdvloaddata" runat="server" BorderColor="#DEBA84" GridLines="Horizontal" BorderStyle="None" Font-Size="12pt" BorderWidth="1px" CellSpacing="2" Style="width: 500px; text-align: center">
                                        <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                                        <HeaderStyle BackColor="SteelBlue" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" HorizontalAlign="Center" />
                                        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                                        <SortedAscendingCellStyle BackColor="#FFF1D4" />
                                        <SortedAscendingHeaderStyle BackColor="#B95C30" />
                                        <SortedDescendingCellStyle BackColor="#F1E5CE" />
                                        <SortedDescendingHeaderStyle BackColor="#93451F" />
                                    </asp:GridView>
                                        </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </center>
                    </div>

                </div>
            </div>

            <%--<asp:ScriptManager ID="ScriptManager1" runat="server" />--%>
            <%--<div id="Accessionno" class="tab-pane fade">

                <div class="panel panel-primary">
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-lg-12">
                                <div class="col-lg-4">
                                    Enter Accession:
                                    <asp:TextBox ID="txtenteraccession" runat="server" CssClass="form-control" placeholder="Enter Accession Number"></asp:TextBox>
                                </div>
                                 <asp:UpdatePanel runat="server" id="UpdatePanel" updatemode="Always">
                                      <ContentTemplate>
                                  <div class="col-lg-2" style="padding-top:18px">
                                    <asp:Button id="Button1" runat="server" class="btn btn-success btn-block btn-sm" OnClick="Button1_Click" Text="Add"></asp:Button>
                                </div>
                                          </ContentTemplate>
                                      </asp:UpdatePanel>
                                <div class="col-lg-2" style="padding-top:18px">
                                    <asp:Button ID="Button2" runat="server" class="btn btn-primary btn-block btn-sm" Text="PRINT ALL IN ONE" OnClick="Button2_Click"></asp:Button>
                                </div>
<%--                                <div class="col-lg-2" style="padding-top:18px">
                                    <asp:Button id="btnforsingle" runat="server" class="btn btn-primary btn-block btn-sm" Text="PRINT FOR SINGLE"></asp:Button>
                                </div>
                                <div class="col-lg-2" style="padding-top:18px">
                                    <asp:Button ID="Button3" runat="server" CssClass="btn btn-danger btn-block btn-sm" OnClick="btnclear_Click" Text="Clear"></asp:Button>
                                </div>
                            </div>
                        </div>
                             <asp:UpdatePanel runat="server" id="UpdatePanel1">
                                      <ContentTemplate>
                      <d class="row" style="padding-top: 5px;">
                    <center>
                                <asp:GridView ID="gdvaccess" runat="server"  BorderColor="#DEBA84" GridLines="Horizontal" BorderStyle="None" Font-Size = "12pt" BorderWidth="1px"  CellSpacing="2"   style="width: 1000px;text-align:center"   >
                                    <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                                    <HeaderStyle BackColor="SteelBlue" Font-Bold="True" ForeColor="White"/>
                                    <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" HorizontalAlign="Center" />
                                    <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                                    <SortedAscendingCellStyle BackColor="#FFF1D4" />
                                    <SortedAscendingHeaderStyle BackColor="#B95C30" />
                                    <SortedDescendingCellStyle BackColor="#F1E5CE" />
                                    <SortedDescendingHeaderStyle BackColor="#93451F" />
                                </asp:GridView>
                               </center>
                        </div>
 </ContentTemplate>
                                      </asp:UpdatePanel>

                    </div>
                </div>
            </div>

        </div>--%>
        </div>


    </div>



    <%--end--%>
    <%--
    <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
<script src="Scripts/ScrollableGridViewPlugin_ASP.NetAJAXmin.js" type="text/javascript"></script>--%>
    <%--<script type="text/javascript">
    $(document).ready(function () {
        $('#<%=gdvloaddata.ClientID %>').Scrollable({
            ScrollHeight: 300,
            IsInUpdatePanel: true
        });
    });
</script>--%>

    <script type="text/javascript" language="javascript">
        function ShowConfirm() {
            window.open("lib_barcode.aspx", '_blank');
        }
    </script>
</asp:Content>

