<%@ Page Title="" Language="C#" MasterPageFile="~/Portals/Staff/MasterPage.master" AutoEventWireup="true" CodeFile="AdmissionURL.aspx.cs" Inherits="Portals_Staff_Pre_Admission_AdmissionURL" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
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
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

       <div id="main" class="main">
        <div class="container-fluid">
              <div class="pagetitle " style="font-size: 32px; margin-left: 34px; font-weight: 300; color: #012970;">
           Pre Admission
            </div>

            <div class="container-fluid">
            <div class="card">
               
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <div class="card-title mx-4">Admission URL</div>
                <div class="panel panel-body">
             <div class="row">
                  <div class="col-lg-12">
                       <div class="table-responsive">
                           
                           <div class="container-fluid" style=" height: 450px; WIDTH: 100%; ">
                                <br />
                               <asp:GridView ID="grd" runat="server" AutoGenerateColumns="False" >
                                    
                                    <AlternatingRowStyle Wrap="false" />
                                    <Columns>
                                         <asp:TemplateField HeaderText="Link"  HeaderStyle-Width="130px" ItemStyle-Width="130px" ItemStyle-VerticalAlign="Middle" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lbllink" runat="server" Text='<%#Eval("Link")%>' Style="font-weight: bold"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Description"  HeaderStyle-Width="130px" ItemStyle-Width="130px" ItemStyle-VerticalAlign="Middle">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDescription" runat="server" Text='<%#Eval("Description")%>' Style="font-weight: bold"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="ON/OFF"  HeaderStyle-Width="130px" ItemStyle-Width="130px" ItemStyle-VerticalAlign="Middle">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="check" runat="server" OnCheckedChanged="check_CheckedChanged"  AutoPostBack="true"/>  
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        </Columns>
                                   </asp:GridView>
                               </div>
                           </div>
                      </div>
                 </div>
             </div>  
        </ContentTemplate>
    </asp:UpdatePanel>
            </div>
        </div></div>
    </div>
    <script>

        function notify(msg, type) {
            $.notify(msg, { type: type, animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.2, delay: 0 });
        }
    </script>

</asp:Content>

