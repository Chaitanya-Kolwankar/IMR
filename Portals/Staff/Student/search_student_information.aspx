<%@ Page Language="C#" AutoEventWireup="true" CodeFile="search_student_information.aspx.cs" Inherits="search_student_informatiom" MasterPageFile="~/Portals/Staff/MasterPage.master" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="../../../Assets/datatable/DataTable.js"></script>
    <link href="../../../Assets/datatable/DataTable.css" rel="stylesheet" />
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

        .label {
            font-weight: 600;
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
    <main id="main" class="main">

    
    <div class="container-fluid">
        <!--Start modal -->
        <div class="modal" id="myModal">
            <div class="modal-dialog">
                <div class="modal-content">

                    <!-- Modal Header -->
                    <div class="modal-header">
                    <div class="container">
                        <h3 class="modal-title"> <span class="label"> More Details</span>  </h3>
                        </div>
                    </div>
                    <!-- Modal body -->
                    <div class="modal-body">
                        <div class="panel">
                            <div class="panel-body" >
                                <asp:UpdatePanel ID="uptpanel" runat="server">
                                    <ContentTemplate>                                        
                                        <div class="row">
                                            <div class="col-lg-3">
                                                <span class="label">
                                                  Student ID 
                                              </span>             
                                            </div>
                                            <div class="col-lg-9">
                                                <asp:Label ID="lbl_studID_crd" runat="server" CssClass="form-Label "></asp:Label>
                                            </div>
                                        </div>                                            
                                        <br />
                                          <div class="row">
                                            <div class="col-lg-3">
                                                <span class="label">
                                                  Name 
                                              </span>             
                                            </div>
                                            <div class="col-lg-9">
                                                <asp:Label ID="lblname" runat="server" CssClass="form-Label"></asp:Label>
                                            </div>
                                        </div>                                           
                                        <br />
                                        <%--</div>--%>
                                        <%--<div class="row">--%>
                                            <div class="row">
                                            <div class="col-lg-3">
                                                <span class="label">
Parents no  
                                              </span>             
                                            </div>
                                            <div class="col-lg-9">
                                                <asp:Label ID="lbl_Parent" runat="server" CssClass="form-Label"></asp:Label>
                                            </div>
                                        </div>                                       
                                        <br />
                                            <div class="row">
                                          <div class="col-lg-3">
                                              <span class="label">
                                                  DOB
                                              </span>                                               
                                            </div>
                                                <div class="col-lg-9">
                                                    <asp:Label ID="lbldobcrd" runat="server" CssClass="form-Label"></asp:Label>
                                                </div>
                                                </div>
                                        <br />
                                        <div class="row">
                                            <div class="col-lg-3">
                                                <span class=" label">
                                                    Address
                                                </span>    
                                            </div>
                                            <div class="col-lg-9">
                                                <asp:Label ID="addressID" runat="server" CssClass="form-Label caps " ReadOnly />
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    <!-- Modal footer -->
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary"  data-bs-dismiss="modal">Close</button>
                    </div>
                        </div>
                </div>
            </div>
            <!--End Modal--->
        </div>
        <asp:UpdatePanel ID="pnl_updt" runat="server">
            <ContentTemplate>
                  <div class="pagetitle " style="font-size: 32px; margin-left: 34px; font-weight: 300; color: #012970;">
            Student
            </div>
                <div class="card ">


                    <div class="card-body">
                          <div class="container-fluid">
                <h5 class="card-title">
                    Search Student ID / Password
                </h5>
                    </div>
                        <div class="container-fluid">
                            <div class="row ">
                                <div class="col-lg-2">
                                    Stud ID
                            <asp:TextBox ID="txtstudid" runat="server" CssClass="form-control" MaxLength="8" onKeyPress="return OnlyNum(event)"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtstudid" ErrorMessage="
                                         Enter Min 8 Digit"
                                        ForeColor="Red" ValidationExpression=".{8}.*" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                                <div class="col-lg-2">
                                    First Name
                            <asp:TextBox ID="txtfirstname" runat="server" CssClass="form-control onlytxt" MaxLength="25" onKeyPress="return singleQuote(event)"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="regtxtfirstname" runat="server" ControlToValidate="txtfirstname" ErrorMessage="
                                         Enter Min 3 Character"
                                        ForeColor="Red" ValidationExpression=".{3}.*" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                                <div class="col-lg-2">
                                    Middle Name
                            <asp:TextBox ID="txtmiddlname" runat="server" CssClass="form-control onlytxt" MaxLength="25" onKeyPress="return singleQuote(event)"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtmiddlname" ErrorMessage="
                                         Enter Min 3 Character"
                                        ForeColor="Red" ValidationExpression=".{3}.*" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>


                                <div class="col-lg-2">
                                    Last Name
                            <asp:TextBox ID="txtlastname" runat="server" CssClass="form-control" MaxLength="25" onKeyPress="return singleQuote(event)"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="regtxtlastname" runat="server" ControlToValidate="txtlastname" ErrorMessage=" Enter Min 3 Character" ForeColor="Red" ValidationExpression=".{3}.*" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                                <div class="col-lg-2">
                                    <br />
                                    <asp:Button ID="btnsearch" runat="server" Text="Search" CssClass="form-control text-center btn btn-primary" OnClick="btnsearch_Click" />
                                </div>
                                <div class="col-lg-2">
                                    <br />
                                    <asp:Button ID="btnclear" runat="server" Text="Clear" CssClass="form-control Text-center btn btn-primary" CausesValidation="false" OnClick="btnclear_Click" />
                                </div>
                            </div>
<br />
                             <div style=" width:100%;">
                            <div>
                            <asp:GridView ID="grid1" AutoGenerateColumns="false" runat="server" OnRowDataBound="grid1_RowDataBound" HeaderStyle-BackColor="White"  OnRowCommand="grid1_RowCommand1" style="width:100%">
                                <Columns>
                                    <asp:TemplateField HeaderText="Student ID" HeaderStyle-CssClass="text-blue">
                                        <ItemTemplate>
                                            <asp:Label ID="gridlblStudid"  ItemStyle-CssClass="caps" runat="server" Text='<%#Eval("stud_id")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Student Name" >
                                        <ItemTemplate>
                                            <asp:Label ID="gridlblStudentname" runat="server" Text='<%#Eval("stud_name") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Roll no." >
                                        <ItemTemplate>
                                            <asp:Label ID="gridlblrollno" runat="server" Text='<%#Eval("roll_no") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Password">
                                        <ItemTemplate>
                                            <asp:Label ID="gridlblpassword" runat="server" Text='<%#Eval("password") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Group Title" >
                                        <ItemTemplate>
                                            <asp:Label ID="gridlblclass" runat="server" Text='<%#Eval("group_title") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:ButtonField ButtonType="Button" runat="server" CommandName="btnclick" ControlStyle-CssClass="btn btn-primary"   Text="View More" HeaderText="View"  />
                                </Columns>
                            </asp:GridView>
                                </div>
                            </div>

                        </div>
                        <br />


                       
                        </div>
                        <div class="panel">
                            <div class="panel-footer"></div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <script type="text/javascript">
        //ForStudid
        function OnlyNum(event) {
            var value = String.fromCharCode(event.which);
            var pattern = new RegExp(/[0-9]/i);
            return pattern.test(value);
        }




        //for lastname,middlename, Firstname
        function singleQuote(event) {
            var value = String.fromCharCode(event.which);
            var pattern = new RegExp(/^[A-Za-z\/\s\']+$/);
            return pattern.test(value);
        }

        function notify() {
            $.notify('Invalid Student ID', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });
        }

        var prm = Sys.WebForms.PageRequestManager.getInstance();

        prm.add_endRequest(function () {
            createDataTable();
        });

        createDataTable();
        //"order": [[0, "desc"]]
        function createDataTable() {
            $('#<%= grid1.ClientID %>').DataTable({



            });

        }
        function notify(msg, type) {
            $.notify(msg, { type: type, animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.2, delay: 0 });
        }

    </script>
        </main>
</asp:Content>
