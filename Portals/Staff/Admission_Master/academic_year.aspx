<%@ Page Title="" Language="C#" MasterPageFile="~/Portals/Staff/MasterPage.master" AutoEventWireup="true" CodeFile="academic_year.aspx.cs" Inherits="Portals_Staff_Admission_academic_year" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="../../../Assets/js/jquery.datetimepicker.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.20/js/jquery.dataTables.min.js"></script>
    <link href="https://cdn.datatables.net/1.10.20/css/jquery.dataTables.css" rel="stylesheet" type="text/css" />
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
                Admission Master
            </div>
            <div class="container-fluid ">
                <div class="row">
                    <div class="col-lg-12">
                        <div class="card">
                            <div class="card-title mx-4" style="font-size: 21px">Academic Year </div>
                            <div class="card-body">
                                <%--<div class="container-fluid">--%>
                                                                    <div class="row">
                                        <div class="col-sm-2">
                                            From Year:
                                     
                                            <asp:UpdatePanel ID="txt_from" runat="server">
                                                <ContentTemplate>

                                                    <input runat="server"  id="txtfrom" class="form-control" oncopy="return false"
                                                        onpaste="return false"
                                                        oncut="return false" autocomplete="off" data-format="d/MMMM/yyyy" readonly/>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>


                                        </div>

                                        <br />
                                        <div class="col-sm-2">
                                            To Year:
                                            <asp:UpdatePanel ID="txt_to" runat="server">
                                                <ContentTemplate>

                                                    <input runat="server" id="txtto" class="form-control" oncopy="return false"
                                                        onpaste="return false"
                                                        oncut="return false" autocomplete="off" data-format="d/MMMM/yyyy" readonly/>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>


                                        </div>


                                        <div class="col-sm-2" style="margin-top: 21px">
                                               <%--<asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                <ContentTemplate>--%>
                                            <asp:Button ID="btnsave" CssClass="form-control btn-primary" Style="color: white; font-size: larger" OnClick="Button1_Click" runat="server" Text="Save" />
                                                    <%--</ContentTemplate></asp:UpdatePanel>--%>
                                        </div>
                                    </div>


                                    <div class="row">
                                        <div class="col-lg" style="margin-top: 25px; text-align: center; overflow-y: auto; max-height: 550px">
                                           <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                <ContentTemplate>--%>
                                            <%--<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" HeaderStyle-CssClass="FixedHeader" HeaderStyle-BackColor="White" Style="overflow: auto; max-height: 400px;" OnRowDataBound="GridView1_RowDataBound">--%>
                                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" DataKeyNames="AYID"  HeaderStyle-BackColor="White"  OnRowDataBound="GridView1_RowDataBound">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Academic Year" HeaderStyle-CssClass="text-blue" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="grdlblayid" runat="server" ItemStyle-CssClass="caps" Text='<%#Eval("AYID")%>'></asp:Label>

                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Duration" HeaderStyle-CssClass="text-blue">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDuration" runat="server" ItemStyle-CssClass="caps" Text='<%#Eval("Duration")%>'></asp:Label>

                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Is Current" HeaderStyle-CssClass="text-blue" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="IsCurrent" runat="server" ItemStyle-CssClass="caps" Text='<%#Eval("IsCurrent")%>'></asp:Label>

                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Is Current" HeaderStyle-CssClass="text-blue">
                                                        <ItemTemplate>
                                                            <asp:RadioButton onclick="RadioCheck(this)" ID="chk_IsCurrent" runat="server" ItemStyle-CssClass="caps" OnCheckedChanged="chk_IsCurrent_CheckedChanged" AutoPostBack="true" ></asp:RadioButton>

                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>



                                            </asp:GridView>
                                            <%--</ContentTemplate></asp:UpdatePanel>--%>

                                        </div>
                                    </div>

                                <%--</div>--%>




                            </div>
                            <br />
                        </div>
                    </div>
                </div>

            </div>

        </div>
    </div>

    <script type="text/javascript">
        
        function RadioCheck(rb) {
            var gv = document.getElementById("<%=GridView1.ClientID%>");
            var rbs = gv.getElementsByTagName("input");
            for (var i = 0; i < rbs.length; i++) {
                if (rbs[i].type == "radio") {
                    if (rbs[i].checked && rbs[i] != rb) {
                        rbs[i].checked = false;
                        break;
                    }
                }
            }
        }
        datepic();
        function datepic() {
            $('[id*=txtfrom]').datetimepicker(
                        {
                            changeMonth: false,
                            changeYear: false,
                            timepicker: false,
                            format: 'd/F/Y',
        

                            //viewMode: "months",
                            //minViewMode: "months",
                            //maxDate: 0
                            //maxDate: new Date(2004, 0, 1)
                            //endDate: "+0m"
                        });

            $('[id*=txtto]').datetimepicker(
                        {
                            changeMonth: false,
                            changeYear: false,
                            timepicker: false,
                            format: 'd/F/Y',
                            viewMode: "months",
                            minViewMode: "months",
                            //maxDate: 0


                            //endDate: "+0m"
                        });


        }
        



       var prm = Sys.WebForms.PageRequestManager.getInstance();

        prm.add_endRequest(function () {
          createDataTable();
      });

       createDataTable();
       //"order": [[0, "desc"]]
       function createDataTable() {
           $('#<%= GridView1.ClientID %>').DataTable({
               
                   "ordering": false

           });
           
       }
        function notify(msg, type) {
            $.notify(msg, { type: type, animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.2, delay: 0 });
        }
    </script>

</asp:Content>

