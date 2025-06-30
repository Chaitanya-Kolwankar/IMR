<%@ Page Title="" Language="C#" MasterPageFile="~/Portals/Staff/MasterPage.master" AutoEventWireup="true" CodeFile="GroupMapping.aspx.cs" Inherits="Portals_Staff_Admission_Master_GroupMapping" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%--<script src="../../../Assets/multiselect/JavaScript.js"></script>
    <script src="../../../Assets/multiselect/Multiselect1.js"></script>
    <link href="../../../Assets/multiselect/StyleSheet.css" rel="stylesheet" />
    <link href="../../../Assets/multiselect/StyleSheet2.css" rel="stylesheet" />--%>
   <%-- <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
<script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
<script src="https://cdn.jsdelivr.net/npm/popper.js@1.12.9/dist/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
<script src="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.js"></script>--%>
      <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
<script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
<script src="https://cdn.jsdelivr.net/npm/popper.js@1.12.9/dist/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
<script src="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.js"></script>

    <script src="../../../Assets/notify-master/js/notify.js"></script>
    <link href="../../../Assets/notify-master/css/notify.css" rel="stylesheet" />



    <link href="../../../Assets/multiselect/css/bootstrap-multiselect.css" rel="stylesheet" />
    <script src="../../../Assets/multiselect/js/bootstrap-multiselect.js"></script> <style>
        .multiselect {
            margin-top: 5px;
            border: 1px solid #ced4da;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="main" id="main">
        <div class="container-fluid">
            <div class="pagetitle " style="font-size: 32px; margin-left: 34px; font-weight: 300; color: #012970;">
                Master
            </div>
            <div class="container-fluid">
                <div class="card">
                 <%--   <div class="card-title mx-4">
                        Mapping
                    </div>--%>
                    <div class="card-title mx-4">Group Mapping  </div>
                    <div class="card-body">
                        <div class="container-fluid">
                            
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <div class="row">
                                <div class="col-lg-2">
                                    <label for="inputstate" class="form-label">
                                        Course
                                    </label>
                                    <asp:DropDownList ID="ddl_Course" runat="server" AutoPostBack="true" CssClass="form-select" OnSelectedIndexChanged="ddl_Course_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-lg-2">
                                    <label for="inputstate" class="form-label">
                                        SubCourse
                                    </label>
                                    <asp:DropDownList ID="ddl_subcou" runat="server" AutoPostBack="true" CssClass="form-select" OnSelectedIndexChanged="ddl_subcou_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-lg-2">
                                    <div class="row">
                                        <label for="inputstate" class="form-label" style="margin-bottom: 2px; margin-left: 14px;">
                                            From Group
                                        </label>
                                    </div>
                                    
                                            <asp:ListBox CssClass="form-select" ID="lstfrmgroup" SelectionMode="Multiple" runat="server" AutoPostBack="true" OnSelectedIndexChanged="lstfrmgroup_SelectedIndexChanged" ></asp:ListBox>

                                    
                                </div>
                                <div class="col-lg-2">
                                    <div class="row">
                                        <label for="inputstate" class="form-label" style="margin-bottom: 2px; margin-left: 14px;">
                                            To Group
                                        </label>
                                    </div>
                                    
                                            <asp:ListBox ID="lsttogroup" CssClass="form-select" SelectionMode="Multiple" runat="server" OnSelectedIndexChanged="lsttogroup_SelectedIndexChanged" AutoPostBack="true"></asp:ListBox>
                                    

                                </div>
                                <div class="col-lg-2">
                                    <br />
                                    <asp:Button ID="btnadd" runat="server" CssClass="btn btn-primary form-control" Text="Add" OnClick="btnadd_Click" /> 
                                </div>
                                            </div>
</ContentTemplate>
                                </asp:UpdatePanel>
                            
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script>
        loadmulti();
        function loadmulti() {
            $(function () {
                $('[id*=lstfrmgroup]').multiselect({
                    includeSelectAllOption: true
                });
            });
            $(function () {
                $('[id*=lsttogroup]').multiselect({
                    includeSelectAllOption: true
                });
            });
        }
        function notify(msg, type) {
            $.notify(msg, { type: type, animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.2, delay: 0 });
        }

    </script>

</asp:Content>

