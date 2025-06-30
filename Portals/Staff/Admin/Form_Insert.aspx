<%@ Page Title="" Language="C#" MasterPageFile="~/Portals/Staff/MasterPage.master" AutoEventWireup="true" CodeFile="Form_Insert.aspx.cs" Inherits="Form_Insert" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%--<link href="/../netdna.bootstrapcdn.com/twitter-bootstrap/2.3.2/css/bootstrap-combined.min.css" rel="stylesheet" />
    <link href="bower_components/bootstrap/dist/css/bootstrap.min.css" rel="stylesheet" />--%>
    <link href="http://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/css/bootstrap-multiselect.css" rel="stylesheet" type="text/css" />
    
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.2.0/css/all.min.css" integrity="sha512-xh6O/CkQoPOWDdYTDqeRdPCVd1SpvCA9XXcUnZS2FmJNp1coAFzvtCN9BmamE+4aHK8yyUHUSCcJHgXloTyT2A==" crossorigin="anonymous" referrerpolicy="no-referrer" />
    <link href="notify-master/css/notify.css" rel="stylesheet" />
    <%--  <script src="notify-master/js/notify.js"></script>
    <script src="notify-master/js/jquery-1.11.0.js"></script>--%>
    <link href="notify-master/css/notify.css" rel="stylesheet" />
    <script src="notify-master/js/notify.js"></script>
    
    <style type="text/css">
        .WordWrap {
            width: 100%;
            word-break: break-all;
        }

        .WordBreak {
            width: 100px;
            overflow: hidden;
            text-overflow: ellipsis;
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

        .FixedHeader {
            position: sticky;
            font-weight: bold;
            top: 0;
        }

        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--<asp:ScriptManager ID="scp1" runat="server" EnablePageMethods="true"></asp:ScriptManager>--%>

    <div id="main" class="main">
    <div class="modal" id="Module_Modal">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Add Module</h4>
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                </div>
                <div class="modal-body">
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col-lg-6">
                                Module Name
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox runat="server" autocomplete="off" MaxLength="20" ID="txtModalname" onkeypress="return alphaandnum(event)" CssClass="form-control"></asp:TextBox>
                                        <asp:Label runat="server" ID="lblmod_id" CssClass="form-control" Visible="false"></asp:Label>
                                    </ContentTemplate>
                                </asp:UpdatePanel>

                            </div>
                            <div class="col-lg-3">
                                <br />
                                <asp:UpdatePanel runat="server" ID="hkj">
                                    <ContentTemplate>
                                        <asp:Button runat="server" ID="btn_saveModulename" Text="Save" OnClick="btn_saveModulename_Click" CssClass=" form-control btn btn-primary"></asp:Button>
                                    </ContentTemplate>
                                </asp:UpdatePanel>

                            </div>
                            <div class="col-lg-3">
                                <br />
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <asp:Button runat="server" ID="btn_Clear" OnClick="btn_Clear_Click" Text="Clear" CssClass="form-control btn btn-primary"></asp:Button>
                                    </ContentTemplate>
                                </asp:UpdatePanel>

                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>

 <div style="max-height: 500px; width: 100%; overflow: auto">
                                    <asp:GridView runat="server" AutoGenerateColumns="false" OnRowCommand="grd_module_RowCommand" ID="grd_module" HeaderStyle-CssClass="FixedHeader" HeaderStyle-BackColor="White"  style="max-height:400px; overflow: auto">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Module Name" HeaderStyle-CssClass="text-blue">
                                                <ItemTemplate>
                                                    <asp:Label ID="modal_grd_lblmodalname" ItemStyle-CssClass="caps" runat="server" Text='<%#Eval("module_name") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="modal_id" runat="server" Text='<%#Eval("mod_id") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:ButtonField ButtonType="Button" runat="server" Text="Select" ControlStyle-CssClass="btn btn-primary" CommandName="Module_Select" />
                                            <asp:ButtonField ButtonType="Button" runat="server" Text="Delete" ControlStyle-CssClass="btn btn-primary" CommandName="module_del" />
                                        </Columns>
                                    </asp:GridView>

</div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>


        <div class="container-fluid">

         <div class="card" style="margin: 10px">
                       <div class="pagetitle" style="font-size: 20px; margin-left: 34px; font-weight: 300; color: #012970;">
                        Add Form
                    </div>
      <%--  <div class="panel-heading">
            <div>
                <h3></h3>
            </div>
        </div>--%>


        <div class="card-body">
            <div class="panel-heading">
               

            
                   
                        <!--//logo-->
                            

                        <center>
                            <div>
                           
                            </div>
                            <div>
      <p style="font-family: 'Times New Roman'; font-size: 15px; text-align: center">
                                    <b> Vishnu Waman Thakur Charitable Trust's</b><br />
                             <b>VIVA Institute of Applied Art</b><br />
                                <%--<h4 style="font-size: 15pt; font-family: 'Times New Roman'"></h4>--%>
                                  <b>Approved by AICTE & Affiliated to University of Mumbai</b>
                            </p>
                            </div>
                         
                        </center>
                   
             
                 </div>
            </div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                 <%--   <div class="panel-body">--%>
                        <div class="container">
                        <div class="container">

                        
                        <div class="row">
                     
                            <div class="col-lg-2">
                                <div class="row">
                                    <div class="col-lg-9">
                                          Module Name:
                                <asp:DropDownList runat="server" ID="txt_li_name" CssClass="form-control" OnSelectedIndexChanged="txt_li_name_SelectedIndexChanged" AutoPostBack="true">  </asp:DropDownList>
                                    </div>
                                   <div class="col-lg-3"  style="margin-top:17px">
                                       <asp:LinkButton ID="lnkbtn_adddep" runat="server" data-bs-toggle="modal" data-bs-target="#Module_Modal" CssClass="btn btn-primary" data-backdrop="false"><i class="fa-plus" ></i></asp:LinkButton>
                                   </div>

                                </div>
                              
                            </div>
                          
                            <div class="col-lg-2">
                                Form Name :
                        <asp:TextBox ID="txt_formname" runat="server" AutoComplete="off" CssClass="form-control" onkeypress="return alphaandnum(event)" placeholder="Form Name"></asp:TextBox>

                            </div>
                            <div class="col-lg-1"  style="margin-top:7px" >
                                <asp:Button ID="btn_save" CssClass="btn btn-primary form-control" runat="server" Text="Save" Style="margin-top: 10px" OnClick="btn_save_Click" />
                                
                            </div>
                            <div class="col-lg-1"  style="margin-top:7px">
                                <asp:Button ID="btn_cancel" CssClass="btn btn-danger  form-control" runat="server" Text="Cancel" Style="margin-top: 10px" OnClick="btn_cancel_Click" />
                            </div>
                        </div>
                            </div>
                            </div>
                        <div class="row">
                            <div class="col-lg-4 col-sm-4 col-md-3 col-xs-2"></div>
                            
                        </div>
                        <br />
                        <div class="container-fluid">
                            <div class="container">

          


                            <asp:GridView runat="server" ID="grd_maingrd" AutoGenerateColumns="false" OnRowCommand="grd_maingrd_RowCommand" HeaderStyle-CssClass="FixedHeader" HeaderStyle-BackColor="White">
                                <Columns>
                                    <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="maingrdlblformid" runat="server" ItemStyle-CssClass="caps" Text='<%#Eval("Form_id") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="maingrdmod_id" runat="server" ItemStyle-CssClass="caps" Text='<%#Eval("mod_id") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Sr no." HeaderStyle-CssClass="text-blue" >
                                        <ItemTemplate>
                                            <%#Container.DataItemIndex+1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Module Name" HeaderStyle-CssClass="text-blue">
                                        <ItemTemplate>
                                            <asp:Label ID="grd_Modname" runat="server" ItemStyle-CssClass="caps" Text='<%#Eval("module_Name") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Form Name" HeaderStyle-CssClass="text-blue">
                                        <ItemTemplate>
                                            <asp:Label ID="grd_form_name" runat="server" ItemStyle-CssClass="caps" Text='<%#Eval("Form_name") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:ButtonField ButtonType="Button" runat="server" CommandName="mainSelect" ControlStyle-CssClass="btn btn-primary" Text="Select" />
                                    <asp:ButtonField ButtonType="Button" runat="server" CommandName="mainDel" ControlStyle-CssClass="btn btn-primary" Text="Delete" />
                                </Columns>
                            </asp:GridView>
                                                  </div>

                        </div>
                    <br></br>
                  <%--  </div>--%>
                </ContentTemplate>
            </asp:UpdatePanel>
            <div class="row">
                <span style="font-size: medium;" id="msg" runat="server"></span>
            </div>

        </div>
    
        </div>
        </div>
    <%----%>
    <script src="jsForms/grantAccess.js"></script>
 
    <%--<script src="confirmJs/jquery.confirm.min.js"></script>--%>
    <script>
        function alphaandnum(event) {
            var val = String.fromCharCode(event.which);
            var pattern = new RegExp(/^[A-Za-z0-9()-\s]+$/);
            return pattern.test(val);
        }
        function notify(msg, type) {
            $.notify(msg, { type: type, animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.2, delay: 0 });
        }
    </script>
</asp:Content>

