<%@ Page Title="" Language="C#" MasterPageFile="~/Portals/Staff/MasterPage.master" AutoEventWireup="true" CodeFile="Fee_Master.aspx.cs" Inherits="Fee_Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="../../../Assets/js/jquery.datetimepicker.js"></script>
    <link href="../../Assets/css/jquery.datetimepicker.css" rel="stylesheet" />
     <script type="text/javascript" src="https://cdn.datatables.net/1.10.20/js/jquery.dataTables.min.js"></script>
    <link href="https://cdn.datatables.net/1.10.20/css/jquery.dataTables.css" rel="stylesheet" type="text/css" />



    <style>

        /* Chrome, Safari, Edge, Opera */
/*input::-webkit-outer-spin-button,
input::-webkit-inner-spin-button {
  -webkit-appearance: none;
  margin: 0;
}
*/
/* Firefox */
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
                Admission Master
            </div>
            <div class="container-fluid ">
                <%--<div class="card">--%>


                <%--<asp:UpdatePanel ID="updatepnl" runat="server">
            <ContentTemplate>--%>
                <%--<div class="container-fluid">--%>
                <div class="row">
                    <div class="">
                        <div class="card">
                            <div class="card-title mx-4" style="font-size: 21px">
                                Fee Master
                            </div>
                            <div class="card-body">
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <div class="container-fluid">
                                            <div class="row">

                                             <%--   <div class="col-lg-2">
                                                    <label for="inputstate" runat="server">Year</label>
                                        <asp:DropDownList ID="ddlyearfee" CssClass="form-select" TabIndex="1" runat="server" AutoPostBack="true" Style="border-radius: 5px;">
                                        </asp:DropDownList>
                                                </div>--%>
                                                <div class="col-lg-2">
                                                    <label id="Label1" for="inputstate" runat="server">Faculty</label>
                                                     
                                        <asp:DropDownList ID="ddl_Faculty" OnSelectedIndexChanged="ddl_Faculty_SelectedIndexChanged" CssClass="form-select" TabIndex="1" runat="server" AutoPostBack="true" Style="border-radius: 5px;">
                                        </asp:DropDownList>
                                                </div>
                                                <div class="col-lg-2">
                                                    <label id="Label2" for="inputstate" runat="server">Course</label>
                                        <asp:DropDownList ID="ddl_course" OnSelectedIndexChanged="ddl_course_SelectedIndexChanged" CssClass="form-select" TabIndex="1" runat="server" AutoPostBack="true" Style="border-radius: 5px;">
                                        </asp:DropDownList>
                                                </div>
                                                <div class="col-lg-2">
                                                    <label id="Label3" for="inputstate" runat="server">Subcourse</label>
                                        <asp:DropDownList ID="ddl_Subcourse" OnSelectedIndexChanged="ddl_Subcourse_SelectedIndexChanged" CssClass="form-select" TabIndex="1" runat="server" AutoPostBack="true" Style="border-radius: 5px;">
                                        </asp:DropDownList>
                                                </div>
                                                <div class="col-lg-2">
                                                    <label id="Label4" for="inputstate" runat="server">Group</label>
                                        <asp:DropDownList ID="dll_Group" OnSelectedIndexChanged="dll_Group_SelectedIndexChanged" CssClass="form-select" TabIndex="1" runat="server" AutoPostBack="true" Style="border-radius: 5px;">
                                        </asp:DropDownList>
                                                </div>
                                                <div class="col-lg-2">
                                                    Structure Name
                                                <asp:TextBox ID="txtstruct" runat="server" CssClass="form-control" AutoComplete="off" onkeyPress="return singleQuote(event)" oncopy="return false"
onpaste="return false"
oncut="return false" MaxLength="100" />
                                                </div>
                                                <div class="col-lg-2">
                                                    Amount
                                                <asp:TextBox ID="txtamunt" runat="server" CssClass="form-control" AutoComplete="off" onkeyPress="return OnlyNum(event)" oncopy="return false"
onpaste="return false"
oncut="return false" MaxLength ="9"/>
                                                </div>

                                            </div>
                                        </div>
                                        <br />
                                        <div class="container-fluid">
                                            <div class="row">
                                                
                                                
                                                <div class="col-lg-2">
                                                   Rank
                                                 <asp:TextBox  runat="server" ID="rankTxt"  onkeypress="return  OnlyNum(event)"  CssClass="form-control"  
 oncopy="return false"     onpaste="return false"
oncut="return false" MaxLength ="3"                                                  
       AutoComplete="off"></asp:TextBox>

                                                    <asp:RegularExpressionValidator runat="server" ControlToValidate="rankTxt" ForeColor="Red" ErrorMessage="Rank Number Should be Between 1 to 100" ValidationExpression="^[1-9]$|^[1-9][0-9]$|^(100)$"></asp:RegularExpressionValidator>
                                                </div>
                                                <div class="col-lg-2">
                                                    Last Date Of Payment
                                                 <asp:TextBox  runat="server" ID="lastdt" CssClass="form-control"  oncopy="return false"
                                                        onpaste="return false"

                                                        oncut="return false" AutoComplete="off"></asp:TextBox>
                                                </div>

                        
                                                <div class="col-lg-2">
                                                    
                                                <asp:Button OnClick="save_Click" style="margin-top:22px;" ID="save" Text="Add" runat="server" CssClass="form-control btn btn-primary" />
                                                </div>
                                                <div class="col-lg-2">
                                                    <asp:Button ID="btncancel" runat="server" style="margin-top:22px;" CssClass="btn btn-primary form-control" Text="Cancel" OnClick="btncancel_Click" />
                                                </div>
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                
                                <%--<div style="width: 100%; max-height: 400px;">--%>
                                    <div>
                                        <div class="container-fluid">
                                        <asp:UpdatePanel runat="server">
                                        <ContentTemplate>
                                            <div  style="max-height:400px; width:100%; overflow:auto">
                                            <asp:GridView ID="grid" runat="server" AutoGenerateColumns="false" HeaderStyle-CssClass="FixedHeader" OnRowDataBound="grid_RowDataBound" HeaderStyle-BackColor="White" Style=" max-height: 400px;">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Faculty" HeaderStyle-CssClass="text-blue">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblgrdfaculname" runat="server" ItemStyle-CssClass="caps" Text='<%#Eval("faculty_name")%>'></asp:Label>

                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Course Name" HeaderStyle-CssClass="text-blue">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblgrdCou" runat="server" ItemStyle-CssClass="caps" Text='<%#Eval("course_name")%>'></asp:Label>

                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="SubCourse Name" HeaderStyle-CssClass="text-blue">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblgrdsubcou" runat="server" MaxLength="20" ItemStyle-CssClass="caps" Text='<%#Eval("subcourse_name")%>' oncopy="return false"
onpaste="return false"
oncut="return false" ></asp:Label>

                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Group Title" HeaderStyle-CssClass="text-blue">
                                                        <ItemTemplate>
                                                            <asp:label runat="server" ID="lblgrdgroup" ItemStyle-Cssclass="caps" Text='<%#Eval("Group_title") %>'></asp:label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Structure Name" HeaderStyle-CssClass="text-blue">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblgrdstruct" ItemStyle-CssClass="caps" Text='<%#Eval("Struct_name") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Amount " HeaderStyle-CssClass="text-blue">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblgrdamunt" runat="server" ItemStyle-CssClass="caps" Text='<%#Eval("Amount") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Rank " HeaderStyle-CssClass="text-blue">
                                                        <ItemTemplate>
                                                            <asp:Label ID="RankLbl" runat="server"  Text='<%# Eval("Rank") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    

                                                    <asp:TemplateField HeaderText="Last Date of Payment " HeaderStyle-CssClass="text-blue">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblgrdlstdatpay" runat="server" ItemStyle-CssClass="caps" Text='<%#Eval("lstdate") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    
                                                    <asp:TemplateField HeaderText="Edit " HeaderStyle-CssClass="text-blue">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="grdbtnedit" runat="server"  OnClick="grdbtnedit_Click" >
                                                                <i class="bi bi-pencil"></i>
                                                            </asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Delete " HeaderStyle-CssClass="text-blue">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="grdbtndel" runat="server"  OnClick="grdbtndel_Click" Text="Delete" >
                                                                <i class="bi bi-trash" style="color:red"></i>
                                                            </asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderStyle-CssClass="hidden" Visible="false" ItemStyle-CssClass="hidden">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="facid" runat="server" Visible="false" Text='<%#Eval("faculty_id") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                    
                                                    <asp:TemplateField HeaderStyle-CssClass="hidden" Visible="false" ItemStyle-CssClass="hidden">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="couid" runat="server" Visible="false" Text='<%#Eval("course_id") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>

                                                    <asp:TemplateField HeaderStyle-CssClass="hidden" Visible="false" ItemStyle-CssClass="hidden">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="subcouid" runat="server" Visible="false" Text='<%#Eval("subcourse_id") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-CssClass="hidden" Visible="false" ItemStyle-CssClass="hidden">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="grpid" runat="server" Visible="false" Text='<%#Eval("Group_id") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>

                                                </Columns>



                                            </asp:GridView>
                                                </div>
                                        </ContentTemplate></asp:UpdatePanel>
                                    </div></div>
                                    <%--</div>--%>
                            </div>
                        </div>
                    </div>

                </div>
                <%--</div>--%>
                <%--</ContentTemplate>
        </asp:UpdatePanel>--%>
            </div>
        </div>
    </div>
    <script>
       <%-- var prm = Sys.WebForms.PageRequestManager.getInstance();

        prm.add_endRequest(function () {
            createDataTable(); 
        });

        createDataTable();

        function createDataTable() {
            $('#<%= grid.ClientID %>').DataTable();
        }--%>


        function OnlyNum(event) {
            var value = String.fromCharCode(event.which);
            var pattern = new RegExp(/[0-9]/i);
            return pattern.test(value);
        }

        function singleQuote(event) {
            var value = String.fromCharCode(event.which);
            var pattern = new RegExp(/^[A-Za-z\/\s\']+$/);
            return pattern.test(value);
        }

        datepicker();
        function datepicker() {

            $('[id*=lastdt]').datetimepicker(
                           {
                               changeMonth: false,
                               changeYear: false,
                               timepicker: false,
                               format: 'd/m/Y',
                               viewMode: "months",
                               minViewMode: "months",
                               //maxDate: 0
                               minDate:0
                               //endDate: "+0m"
                           });
        }

        function notify(msg, type) {
            $.notify(msg, { type: type, animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.2, delay: 0 });
            createDataTable();
        }

    </script>
</asp:Content>

