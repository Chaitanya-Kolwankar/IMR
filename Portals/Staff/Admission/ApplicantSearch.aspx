<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Portals/Staff/MasterPage.master" CodeFile="ApplicantSearch.aspx.cs" Inherits="ApplicantSearch" UnobtrusiveValidationMode="None" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../../../Assets/datatable/DataTable.css" rel="stylesheet" />
    <script src="../../../Assets/datatable/DataTable.js"></script>
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
        .FixedHeader {
            position: sticky;
            font-weight: bold;
            top:0;
        } 
         caps {
            text-transform: capitalize;
        }    
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    
    <div id="main" class="main">
        <div class="container-fluid">
              <div class="pagetitle " style="font-size: 32px; margin-left: 34px; font-weight: 300; color: #012970;">
            Applicant
            </div>

            <div class="container-fluid">
            <div class="card">
               
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <div class="card-title mx-4">Search Applicant ID / Password</div>
                <div class="card-body">
                    
                    <div class="container-fluid">
                    <div class="row">
                        <div class="col-lg-2">
                            Form no. 
                    <asp:TextBox ID="txt_form_no" runat="server" placeholder="" onkeypress="return alphaandnum(event) " MaxLength="25" CssClass="form-control" 
autocomplete="off" 
 ></asp:TextBox>
                            <asp:RegularExpressionValidator ID="rev1" runat="server" ControlToValidate="txt_form_no" ErrorMessage="Enter Min 5 Characters" ForeColor="Red" ValidationExpression=".{5}.*" Display="Dynamic"></asp:RegularExpressionValidator>
                        </div>
                        <div class="col-lg-2">
                            First Name 
                  <asp:TextBox ID="txtfirstname" runat="server" placeholder="" MaxLength="25" onkeyPress="return singleQuote(event)" CssClass="form-control" oncopy="return false"
autocomplete="off" 
onpaste="return false"
oncut="return false"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="txtfirstnamereq" runat="server" ControlToValidate="txtfirstname" ErrorMessage="Enter Min 3 Characters" ForeColor="Red" ValidationExpression=".{3}.*" Display="Dynamic"></asp:RegularExpressionValidator>
                        </div>
                        <div class="col-lg-2">
                            Middle Name
                       <asp:TextBox ID="txtMiddlename" runat="server" placeholder="" MaxLength="25" onkeyPress="return singleQuote(event)" oncopy="return false"
autocomplete="off" 
onpaste="return false"
oncut="return false" CssClass="form-control"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtMiddlename" ErrorMessage="Enter Min 3 Characters" ForeColor="Red" ValidationExpression=".{3}.*" Display="Dynamic"></asp:RegularExpressionValidator>

                        </div>
                        <div class="col-lg-2">
                            Last Name
                        <asp:TextBox ID="txtLastName" runat="server" placeholder="" MaxLength="20" onkeyPress="return singleQuote(event)" CssClass="form-control" oncopy="return false"
autocomplete="off" 
onpaste="return false"
oncut="return false"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtLastName" ErrorMessage=" Enter Min 3 Characters" ForeColor="Red" ValidationExpression=".{3}.*" Display="Dynamic"></asp:RegularExpressionValidator>
                            
                        </div>
                        <div class="col-lg-2">
                            <br />
                            <asp:Button ID="btn_search" runat="server" placeholder="" CssClass="form-control text-center btn btn-primary" Text="Search" OnClick="btn_search_Click" />
                        </div>
                        <div class="col-lg-2">
                            <br />
                            <asp:Button ID="btn_clear" runat="server" placeholder="" CssClass="form-control text-center btn btn-primary" Text="Clear" CausesValidation="false" OnClick="btn_clear_Click" />
                        </div>
                    </div>
                    <br />
                    <br />
                         

                    <div style="width: 100%;">
                        <asp:GridView ID="grid1" AutoGenerateColumns="false"  runat="server" HeaderStyle-BackColor="White"    OnRowDataBound="grid1_RowDataBound" style="width:100%" >
                            <Columns>
        <asp:BoundField DataField="formno" ItemStyle-CssClass="caps" HeaderText="Form no."  />
        <asp:BoundField DataField="name" HeaderText="Student Name" />
        <asp:BoundField DataField="passwd" HeaderText="Password"/>
    
                            </Columns>
                        </asp:GridView>
                    </div>
                            

                        
                        </div>
                </div>
        </ContentTemplate>
    </asp:UpdatePanel>
            </div>
        </div></div>
    </div>


    <script>
        
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

        function alphaandnum(event) {
            var val = String.fromCharCode(event.which);
            var pattern = new RegExp(/^[A-Za-z0-9]+$/);
            return pattern.test(val);

        }

        function singleQuote(event) {
            var value = String.fromCharCode(event.which);
            var pattern = new RegExp(/^[A-Za-z\/\s\']+$/);
            return pattern.test(value);
        }
    </script>
</asp:Content>

