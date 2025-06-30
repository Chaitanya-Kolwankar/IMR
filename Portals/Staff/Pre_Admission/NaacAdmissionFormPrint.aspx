<%@ Page Title="" Language="C#" MasterPageFile="~/Portals/Staff/MasterPage.master" AutoEventWireup="true" CodeFile="NaacAdmissionFormPrint.aspx.cs" Inherits="Portals_Staff_Pre_Admission_NaacAdmissionFormPrint" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
        <link href="http://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/css/bootstrap-multiselect.css" rel="stylesheet" type="text/css" />
    
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.2.0/css/all.min.css" integrity="sha512-xh6O/CkQoPOWDdYTDqeRdPCVd1SpvCA9XXcUnZS2FmJNp1coAFzvtCN9BmamE+4aHK8yyUHUSCcJHgXloTyT2A==" crossorigin="anonymous" referrerpolicy="no-referrer" />
    <link href="notify-master/css/notify.css" rel="stylesheet" />
    <%--  <script src="notify-master/js/notify.js"></script>
    <script src="notify-master/js/jquery-1.11.0.js"></script>--%>
    <link href="notify-master/css/notify.css" rel="stylesheet" />
    <script src="notify-master/js/notify.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main" class="main">
        <div class="container-fluid">
            <div class="card">
                <div class="card-body">
                        <div class="row">
                    <div class="col-lg-2">
                        Academic Year
                      <%--  <asp:UpdatePanel runat="server">
                            <ContentTemplate>--%>
                                <asp:DropDownList runat="server" ID="ddlyear" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlyear_SelectedIndexChanged"></asp:DropDownList>
                       <%--     </ContentTemplate>
                        </asp:UpdatePanel>--%>
                        
                    </div>
                    <div class="col-lg-2">
                        Group
                        <asp:DropDownList runat="server" ID="ddlgroup" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlgroup_SelectedIndexChanged" ></asp:DropDownList>
                    </div>
                </div>
                </div>
            
            </div>


        </div>
    </div>

</asp:Content>

