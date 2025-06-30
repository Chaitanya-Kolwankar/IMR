<%@ Page Title="" Language="C#" MasterPageFile="~/Portals/Staff/MasterPage.master" AutoEventWireup="true" CodeFile="EmployeeEntry.aspx.cs" Inherits="Portals_Staff_Employee_EmployeeEntry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">


    <%--<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.2.0/css/all.min.css" integrity="sha512-xh6O/CkQoPOWDdYTDqeRdPCVd1SpvCA9XXcUnZS2FmJNp1coAFzvtCN9BmamE+4aHK8yyUHUSCcJHgXloTyT2A==" crossorigin="anonymous" referrerpolicy="no-referrer" />

    <link href="vendors/bootstrap/bootstrap-multiselect.css" rel="stylesheet" />
    <script src="jquery/dist/jquery.min.js"></script>
    <script src="js/bootstrap-multiselect.js"></script>
    <link href="notify-master/css/notify.css" rel="stylesheet" />
    <script src="notify-master/js/notify.js"></script>
    <link href="multiselect/css/bootstrap-multiselect.css" rel="stylesheet" />--%>

    <%-- <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.12.9/dist/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.js"></script>

    <script src="../../../Assets/notify-master/js/notify.js"></script>
    <link href="../../../Assets/notify-master/css/notify.css" rel="stylesheet" />

    <link href="../../../Assets/multiselect/css/bootstrap-multiselect.css" rel="stylesheet" />
    <script src="../../../Assets/multiselect/js/bootstrap-multiselect.js"></script>
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet" />--%>

    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous"/>
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.12.9/dist/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.js"></script>
    <script src="http://code.jquery.com/jquery-1.11.2.min.js"></script>
    
    <%--<script src="../../../assets/js/main.js"></script>--%>
    <link href="../../../Assets/notify-master/css/notify.css" rel="stylesheet" />

    <script src="../../../Assets/notify-master/js/notify.js"></script>


    <link href="../../../Assets/multiselect/css/bootstrap-multiselect.css" rel="stylesheet" />
    <script src="../../../Assets/multiselect/js/bootstrap-multiselect.js"></script>

<%--    <link href="../../Assets/css/jquery.datetimepicker.css" rel="stylesheet" />

    <script src="../../../Assets/js/jquery.datetimepicker.js"></script>
    <script src="../../../Assets/js/datepicker/daterangepicker.js"></script>--%>
   
        <link href="../../../Assets/css/jquery.datetimepicker.css" rel="stylesheet" />

    <script src="../../../Assets/js/jquery.datetimepicker.js"></script>
    <script src="js/jquery.datetimepicker.js"></script>

   
    <style>
        #chkbx_phys {
            width: 20px;
            height: 20px;
        }

        #btndep {
            color: #0d6efd;
        }

        .multiselect {
            /*margin-top: 5px;*/
            border: 1px solid #ced4da;
            width: 210px;
        }

        /* .multiselect-container {
            height: 150px;
            width: 100%;
            overflow: scroll;
        }*/

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

        .redcolor {
            color: red;
        }

        .chkbxx {
            height: 50px;
            width: 40px;
        }

        .caps {
            text-transform: capitalize;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div id="main" class="main">
        <%--department modal--%>
        <div class="modal fade" id="adddept" role="dialog">
            <div class="modal-dialog modal-lg">
                <div class="modal-content">
                    <div class="modal-header" style="background-color: #337ab7; color: white">
                        <%--<p style="color: #012970; font-size: 21px">--%>Add Department <%--</p>--%>
                        <%--<button type="button" class="close" data-dismiss="modal"></button>--%>
                        <button type="button" id="dept_cross" onclick="myFunction()" class="close" data-dismiss="modal" aria-label="Close">&times;</button>
                    </div>
                    <div class="modal-body">
                        <div class="container-fluid">
                            <div class="row">
                                <div class="col-lg-4">
                                    Department Name
                                    <asp:UpdatePanel ID="updt2" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox runat="server" CssClass="form-control" autocomplete="off" Style="text-transform: uppercase" onkeypress="return onlyalpha(event)" ID="dep_name" MaxLength="40"></asp:TextBox>
                                            <asp:TextBox runat="server" ID="txtdepid" Visible="false"></asp:TextBox>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <div class="col-lg-4">
                                    Department Prefix
                                    <asp:UpdatePanel ID="updt3" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox runat="server" ID="dpt_prefix" Style="text-transform: uppercase" CssClass="form-control" autocomplete="off" MaxLength="3" onkeypress="return onlyalpha(event)" oncut="return false" onpaste="return false" oncopy="return false"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="dpt_prefix" ForeColor="Red" ErrorMessage="*3 Characters Required" ValidationExpression=".{3}.*"></asp:RegularExpressionValidator>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>

                                </div>
                                <div class="col-lg-2" style="margin-top: 20px">
                                    <asp:UpdatePanel ID="gddd" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <asp:Button UseSubmitBehavior="false" runat="server" ID="btn_save" Text="Save" OnClick="btn_save_Click" EnableViewState="true" CssClass=" btn btn-primary form-control" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <div class="col-lg-2" style="margin-top: 20px">
                                   <%-- <asp:UpdatePanel ID="depupdte" runat="server">
                                        <ContentTemplate>--%>
                                            <asp:Button runat="server" ID="btn_clear" OnClick="btn_clear_Click" Text="Clear" CssClass="btn btn-primary form-control" />
                                      <%--  </ContentTemplate>
                                    </asp:UpdatePanel>--%>
                                </div>
                                <asp:UpdatePanel ID="updte" runat="server">
                                    <ContentTemplate>
                                        <div style="max-height: 500px; width: 100%; overflow: auto">
                                            <asp:GridView ID="grd_dept" runat="server" AutoGenerateColumns="false" OnRowDataBound="grd_dept_RowDataBound" OnRowEditing="grd_dept_RowEditing" OnRowCommand="grd_dept_RowCommand" HeaderStyle-CssClass="FixedHeader" HeaderStyle-BackColor="White">

                                                <Columns>
                                                    <asp:TemplateField HeaderText="Sr no." HeaderStyle-CssClass="text-blue">
                                                        <ItemTemplate>
                                                            <%#Container.DataItemIndex+1 %>
                                                            <%--<asp:Label ID="grd_srno"  ItemStyle-CssClass="caps" runat="server" Text='<%#Eval("")%>'></asp:Label>--%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Prefix" HeaderStyle-CssClass="text-blue">
                                                        <ItemTemplate>
                                                            <asp:Label ID="grd_pre" ItemStyle-CssClass="caps" runat="server" Text='<%#Eval("PREFIX") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Department Name" HeaderStyle-CssClass="text-blue">
                                                        <ItemTemplate>
                                                            <asp:Label ID="grd_dept_nam" ItemStyle-Cssclass="caps" runat="server" Text='<%#Eval("Department_name") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:ButtonField ButtonType="Button" runat="server" Text="Edit" ControlStyle-CssClass="btn btn-primary" CommandName='edit' HeaderText="Edit"></asp:ButtonField>
                                                    <asp:ButtonField ButtonType="Button" runat="server" Text="Delete" ControlStyle-CssClass="btn btn-primary" CommandName="dept_Delete" HeaderText="Delete"></asp:ButtonField>

                                                    <asp:TemplateField Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lbldeptid" Text='<%#Eval("Dept_id") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lbldate" Text='<%#Eval("date_establishment") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lbldelfg" Text='<%#Eval("del_flag") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblcurr" Text='<%#Eval("curr_dt") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblmodt" Text='<%#Eval("mod_dt") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
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
        <%--designation modal---------------------------------------------------------------------------------------------------------------%>
        <div class="modal" id="modal_desg">
            <div class="modal-dialog modal-lg">
                <div class="modal-content">
                    <div class="modal-header" style="background-color: #337ab7; color: white">
                        <%--<p style="color: #012970; font-size: 21px">--%>Add Designation 
                        <button type="button" class="close" onclick="DESGFUN()" data-dismiss="modal" aria-label="Close">&times;</button>
                    </div>
                    <div class="modal-body">
                        <div class="container-fluid">
                            <div class="row">
                                <div class="col-lg-4">
                                    Designation Name
                                    <asp:UpdatePanel runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox runat="server" ID="txtdesname" autocomplete="off" MaxLength="50" onkeypress="return onlyalpha(event)" Style="text-transform: uppercase" oncopy="return false" onpaste="return false" oncut="return false" CssClass="form-control"></asp:TextBox>
                                            <asp:TextBox runat="server" ID="txtdes_id" Visible="false"></asp:TextBox>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>

                                </div>
                                <div class="col-lg-3" style="margin-top: 20px;">
                                    <asp:UpdatePanel runat="server">
                                        <ContentTemplate>
                                            <asp:Button ID="btn_des" OnClick="btn_des_Click" runat="server" Text="ADD" CssClass="btn btn-primary form-control" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>

                                </div>
                                <div class="col-lg-3" style="margin-top: 20px;">
                                    <asp:UpdatePanel runat="server">
                                        <ContentTemplate>
                                            <asp:Button runat="server" ID="btn_desclear" OnClick="btn_desclear_Click" Text="Clear" CssClass="btn btn-primary form-control" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>

                                </div>
                            </div>
                            <br />
                            <asp:UpdatePanel ID="updtedesmodal" runat="server">
                                <ContentTemplate>
                                    <div style="max-height: 500px; width: 100%; overflow: auto">


                                        <asp:GridView ID="grddes" runat="server" AutoGenerateColumns="false" OnRowCommand="grddes_RowCommand" HeaderStyle-CssClass="FixedHeader" HeaderStyle-BackColor="White">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Sr no." HeaderStyle-CssClass="text-blue">
                                                    <ItemTemplate>
                                                        <%#Container.DataItemIndex+1 %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Designation Name" HeaderStyle-CssClass="text-blue">
                                                    <ItemTemplate>
                                                        <asp:Label ID="grdlbl_des" runat="server" ItemStyle-Cssclass="caps" Text='<%#Eval("Designation_title") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbldesgid" runat="server" Text='<%#Eval("Designation_id") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbldesgnation_delf" runat="server" Text='<%#Eval("del_flag") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:ButtonField ButtonType="button" runat="server" Text="Edit" ControlStyle-CssClass="btn btn-primary" CommandName="desedit" HeaderText="Edit" />
                                                <asp:ButtonField ButtonType="Button" runat="server" Text="Delete" ControlStyle-CssClass="btn btn-primary" CommandName="des_del" HeaderText="Delete" />

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
        <%--add role modal------------------------------------------------------------------%>
        <div class="modal" id="addrol">
            <div class="modal-dialog modal-lg">
                <div class="modal-content">
                    <div class="modal-header" style="background-color: #337ab7; color: white">
                        Add Role 
                        <%--<button type="button" class="close" data-dismiss="modal">&times;</button>--%>
                        <%--<button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>--%>
                        <button type="button" class="close" onclick="ROLEE()" data-dismiss="modal" aria-label="Close">&times;</button>

                    </div>
                    <div class="modal-body">
                        <div class="container-fluid">
                            <div class="row">
                                <div class="col-lg-3">
                                    Role
                                    <asp:UpdatePanel runat="server" ID="rolupdtw">
                                        <ContentTemplate>
                                            <asp:TextBox ID="txt_rol" runat="server" Style="text-transform: uppercase" CssClass="form-control" autocomplete="off" MaxLength="30" onkeypress="return singleQuote(event)"></asp:TextBox>
                                            <asp:TextBox ID="txt_rolid" runat="server" Visible="false"></asp:TextBox>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>

                                </div>
                                <div class="col-lg-3" style="margin-top: 20px;">
                                    <asp:UpdatePanel runat="server" ID="rolupdt">
                                        <ContentTemplate>
                                            <asp:Button ID="btn_roladd" runat="server" OnClick="btn_roladd_Click" CssClass="form-control btn btn-primary" Text="Add" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>

                                </div>
                                <div class="col-lg-3" style="margin-top: 20px;">
                                    <asp:UpdatePanel runat="server" ID="updteclear">
                                        <ContentTemplate>
                                            <asp:Button ID="btnrol_clear" OnClick="btnrol_clear_Click" runat="server" Text="Clear" CssClass="form-control btn btn-primary" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>

                                </div>
                                <div class="col-lg-3" style="margin-top: 20px;">
                                    <asp:UpdatePanel ID="uihdww" runat="server">
                                        <ContentTemplate>
                                            <asp:Button ID="btn_editRole" OnClick="btn_editRole_Click" runat="server" Text="Edit Role" CssClass="form-control btn btn-primary" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>

                                </div>
                            </div>
                            <br />

                            <asp:UpdatePanel ID="grdupdte" runat="server">
                                <ContentTemplate>

                                    <div style="max-height: 500px; width: 100%; overflow: auto">
                                        <asp:GridView ID="grdrole" runat="server" AutoGenerateColumns="false" OnRowCommand="grdrole_RowCommand" HeaderStyle-CssClass="FixedHeader" HeaderStyle-BackColor="White">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Select" HeaderStyle-CssClass="text-blue">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkbx_sel" runat="server" />

                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Form Name" HeaderStyle-CssClass="text-blue">
                                                    <ItemTemplate>
                                                        <asp:Label ID="grdlbl_form" runat="server" ItemStyle-Cssclass="caps" Text='<%#Eval("Form_Name") %>'></asp:Label>
                                                        <asp:Label ID="grdlbl_formid" runat="server" Visible="false" Text='<%#Eval("Form_id") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>

                            <asp:UpdatePanel runat="server" ID="updrolegrd">
                                <ContentTemplate>

                                    <div style="max-height: 500px; width: 100%; overflow: auto">


                                        <asp:GridView ID="grddefine" runat="server" AutoGenerateColumns="false" OnRowCommand="grddefine_RowCommand1" HeaderStyle-CssClass="FixedHeader" HeaderStyle-BackColor="White">
                                            <Columns>

                                                <asp:TemplateField HeaderText="Sr no." HeaderStyle-CssClass="text-blue">
                                                    <ItemTemplate>
                                                        <%#Container.DataItemIndex+1 %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Role Name" HeaderStyle-CssClass="text-blue">
                                                    <ItemTemplate>
                                                        <asp:Label ID="grdlbl_sr" runat="server" ItemStyle-Cssclass="caps" Text='<%#Eval("role_name") %>'></asp:Label>
                                                        <%--<asp:Label ID="grdlblb_srid" runat="server" Visible="false" Text='<%#Eval("role_id") %>'

                                                        --%>
                                                        <asp:Label ID="grdlbl_roleid" runat="server" Visible="false" Text='<%#Eval("role_id") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:ButtonField ButtonType="Button" runat="server" Text="Edit" ControlStyle-CssClass="form-control btn  btn-primary" CommandName="roleedit" HeaderText="Edit" />
                                                <asp:ButtonField ButtonType="Button" runat="server" Text="Delete" ControlStyle-CssClass="form-control btn btn-primary" CommandName="roledelete" HeaderText="Delete" />

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
        <asp:UpdatePanel ID="mainupdtpl" runat="server">
            <ContentTemplate>



                <div class="container-fluid">

                    <%--                    <div class="panel panel-primary">--%>
                    <div class="pagetitle" style="font-size: 20px; margin-left: 34px; font-weight: 300; color: #012970;">
                        Employee 
                    </div>
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col-lg-12">
                                <div class="card">
                                    <%--<div class="panel panel-body">--%>
                                    <%--row1-----------------------%>

                                    <%--  <div class="panel panel-primary">--%>
                                    <div class="card-title mx-4" style="margin-bottom: 0px">
                                        <%--Employee Entry--%>
                                        Personal Details

                                    </div>
                                    <div class="card-body">

                                        <%--   <div class="panel panel-body">--%>

                                        <div class="row">
                                            <div class="col-lg-2 col-md-3 col-sm-12">
                                                <label for="inputState" class="form-label">Employee ID</label>
                                                <asp:TextBox ID="txtEmpId" runat="server" OnTextChanged="txtEmpId_TextChanged" TabIndex="0" AutoPostBack="true" autocomplete="off" onkeypress="return alphanum(event)" MaxLength="8" Style="text-transform: uppercase" CssClass="form-control"></asp:TextBox>
                                            </div>
                                            <div class="col-lg-2 col-md-2 col-sm-12">
                                                <label for="inputState" class="form-label">Last Name</label>
                                                <%--<asp:UpdatePanel ID="UPDTTXTXLAST" runat="server">
                                                    <ContentTemplate>--%>
                                                        <asp:TextBox ID="txtlastname" runat="server" TabIndex="1" onkeypress="return nametxt(event)" autocomplete="off" Style="text-transform: uppercase" MaxLength="19" oncopy="return false" onpaste="return false" oncut="return false" CssClass="form-control"></asp:TextBox>
                                              <%--      </ContentTemplate>

                                                </asp:UpdatePanel>--%>

                                                <asp:RegularExpressionValidator ID="regtxtlastname" runat="server" ControlToValidate="txtlastname" ForeColor="Red" ErrorMessage="*3 Characters Required" ValidationExpression=".{3}.*"></asp:RegularExpressionValidator>
                                            </div>
                                            <div class="col-lg-2 col-md-2 col-sm-12">
                                                <label for="inputState" class="form-label">First Name<span class="redcolor">*</span></label>
                                                <asp:TextBox ID="txtfirstname" runat="server" autocomplete="off" TabIndex="2" Style="text-transform: uppercase" onkeypress="return nametxt(event)" CssClass="form-control" oncopy="return false" MaxLength="19" onpaste="return false" oncut="return false"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="regexpressionid2" runat="server" ControlToValidate="txtfirstname" ForeColor="Red" ErrorMessage="3 Characters Required" ValidationExpression=".{3}.*"></asp:RegularExpressionValidator>
                                            </div>
                                            <div class="col-lg-2 col-md-2 col-sm-12">
                                                <label for="inputState" class="form-label">Middle Name<span class="redcolor">*</span></label>
                                                <asp:TextBox ID="txtmiddlename" autocomplete="off" MaxLength="19" Style="text-transform: uppercase" TabIndex="3" runat="server" onkeypress="return nametxt(event)" CssClass="form-control" oncopy="return false" onpaste="return false" oncut="return false"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="regid3" runat="server" ControlToValidate="txtmiddlename" ForeColor="Red" ErrorMessage="*3 Characters Required" ValidationExpression=".{3}.*"></asp:RegularExpressionValidator>
                                            </div>
                                            <div class="col-lg-2 col-md-2 col-sm-12">
                                                <label for="inputState" class="form-label">Mother Name<span class="redcolor">*</span></label>
                                                <asp:TextBox ID="txtmothername" autocomplete="off" runat="server" MaxLength="19" Style="text-transform: uppercase" TabIndex="4" onkeypress="return nametxt(event)" CssClass="form-control" oncopy="return false" onpaste="return false" oncut="return false"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtmothername" ForeColor="Red" ErrorMessage="*3 Characters Required" ValidationExpression=".{3}.*" Display="Dynamic"></asp:RegularExpressionValidator>
                                            </div>
                                            <div class="col-lg-2 col-md-3 col-sm-12 ">
                                                <label for="inputState" class="form-label">Gender<span class="redcolor">*</span></label>
                                                <br />
                                                <div class="form-control" style="height: 40px;">
                                            
                                                                 <asp:RadioButton ID="rad_gender" runat="server" Text="Male" AutoPostBack="true" TabIndex="5" OnCheckedChanged="rad_gender_CheckedChanged" CssClass="" />&nbsp &nbsp       
                                                <asp:RadioButton ID="rad_female" runat="server" Text="Female" AutoPostBack="true"  TabIndex="6" OnCheckedChanged="rad_female_CheckedChanged" CssClass="" />
                                                       
                                                     
                                               
                                                </div>

                                            </div>
                                        </div>
                                        <div class="row ">
                                            <%----------------row2--%>

                                            <div class="col-lg-2 col-md-3 col-sm-12">
                                                <label for="inputState" class="form-label">D.O.B<span class="redcolor">*</span></label>
                                           <asp:UpdatePanel runat="server">
                                               <ContentTemplate>
                                                   <asp:TextBox ID="txtdob" runat="server" TabIndex="7"  autocomplete="off" CssClass="form-control"></asp:TextBox>
                                               </ContentTemplate>
                                           </asp:UpdatePanel>
                                                        
                                                 

                                            </div>
                                            <div class="col-lg-2 col-md-3 col-sm-12">
                                                <label for="inputState" class="form-label">D.O.J<span class="redcolor">*</span></label>
                                      <asp:UpdatePanel runat="server">
                                          <ContentTemplate>
                                              <asp:TextBox UseSubmitBehaviour="false" ID="txtDOJ"  autocomplete="off" TabIndex="8" runat="server" CssClass="form-control"></asp:TextBox>
                                          </ContentTemplate>
                                      </asp:UpdatePanel>
                                                        
                                                  
                                            </div>
                                            <div class="col-lg-2">

                                                <label for="inputState" class="form-label">Email ID<span class="redcolor">*</span></label>
                                                <asp:TextBox UseSubmitBehaviour="false" ID="txtemail" runat="server" TabIndex="9" oncopy="return false" MaxLength="90" Style="text-transform: lowercase" onpaste="return false" oncut="return false" autocomplete="off" CssClass="form-control"></asp:TextBox>
                                            </div>
                                            <div class="col-lg-2">
                                                <label for="inputState" class="form-label">Mobile no<span class="redcolor">*</span></label>
                                                <asp:TextBox ID="txtmobno" runat="server" MaxLength="10" autocomplete="off" TabIndex="10" onkeypress="return OnlyNum(event)" oncopy="return false" onpaste="return false" oncut="return false" CssClass="form-control"></asp:TextBox>
                                                <%-- <asp:RegularExpressionValidator ID="REDMOBNO" ControlToValidate="txtmobno" runat="server" ForeColor="Red" ErrorMessage="Invalid Mobile no." ValidationExpression=".{10}.*"></asp:RegularExpressionValidator>--%>
                                            </div>
                                            <div class="col-lg-2">
                                                <label for="inputState" class="form-label">Alternate Mobile no<span class="redcolor">*</span></label>
                                                <asp:TextBox ID="txtmobile" runat="server" autocomplete="off" MaxLength="10" TabIndex="11" oncopy="return false" onpaste="return false" oncut="return false" onkeypress="return OnlyNum(event)" CssClass="form-control"></asp:TextBox>
                                                <%--     <asp:RegularExpressionValidator ID="Regmob" runat="server" ControlToValidate="txtmobile" ForeColor="Red" ErrorMessage="Invalid Mobile no." ValidationExpression=".{10}.*"></asp:RegularExpressionValidator>--%>
                                            </div>
                                            <div class="col-lg-2">
                                                <label for="inputState" class="form-label">Marital status<span class="redcolor">*</span></label><br />
                                           <%--     <asp:UpdatePanel runat="server">
                                                    <ContentTemplate>--%>
                                                        <asp:DropDownList ID="ddlmart" runat="server" TabIndex="12"  CssClass="form-control" Width="100%" Height="32px">
                                                            <asp:ListItem Selected="True" Text="--Select--"></asp:ListItem>
                                                            <asp:ListItem Text="Married" Value="Married"></asp:ListItem>
                                                            <asp:ListItem Text="Unmarried" Value="Unmarried"></asp:ListItem>
                                                        </asp:DropDownList>
                                             <%--       </ContentTemplate>
                                                </asp:UpdatePanel>--%>

                                            </div>
                                        </div>
                                        <br>
                                        <div class="row">
                                            <%--row3-----%>
                                            <div class="col-lg-2">
                                                <label for="inputState" class="form-label">Blood Group<span class="redcolor">*</span></label>

                                                <asp:DropDownList ID="ddlbloodgroup" runat="server" TabIndex="13" CssClass="form-control">
                                                    <asp:ListItem Text="--Select--"></asp:ListItem>

                                                    <asp:ListItem Value="A +ve" Text="A+"> </asp:ListItem>
                                                    <asp:ListItem Value="A +ve" Text="A-"> </asp:ListItem>
                                                    <asp:ListItem Value="B +ve" Text="B+"> </asp:ListItem>
                                                    <asp:ListItem Value="B +ve" Text="B-"> </asp:ListItem>
                                                    <asp:ListItem Value="O +ve" Text="O+"> </asp:ListItem>
                                                    <asp:ListItem Value="O -ve" Text="O-"> </asp:ListItem>
                                                    <asp:ListItem Value="AB +ve" Text="AB+"></asp:ListItem>
                                                    <asp:ListItem Value="AB -ve" Text="AB-"> </asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-lg-2">
                                                <label for="inputState" class="form-label">Nationality<span class="redcolor">*</span></label>
                                                <asp:DropDownList ID="ddlnation" runat="server"  TabIndex="14" CssClass="form-control">
                                                    <asp:ListItem Selected="True" Text="--Select--"></asp:ListItem>
                                                    <asp:ListItem Text="INDIAN" Value="INDIAN"></asp:ListItem>
                                                    <asp:ListItem Text="OTHERS" Value="OTHERS"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-lg-2">
                                                <label for="inputState" class="form-label">Religion<span class="redcolor">*</span></label>
                                                <asp:DropDownList ID="ddl_rel" CssClass="form-control" runat="server" TabIndex="15" OnSelectedIndexChanged="ddl_rel_SelectedIndexChanged"></asp:DropDownList>
                                            </div>
                                            <div class="col-lg-2">
                                                <label for="inputState" class="form-label">
                                                    Category<span class="redcolor">*</span>
                                                </label>
                                                
                                                        <asp:DropDownList ID="ddlcat" TabIndex="16" CssClass="form-control" runat="server"  AutoPostBack="true" OnSelectedIndexChanged="ddlcat_SelectedIndexChanged"></asp:DropDownList>                                                                                                                                             
                                                
                                            </div>
                                            <div class="col-lg-2">
                                                <label for="inputState" class="form-label">
                                                    Caste<span class="redcolor">*</span>
                                                </label>
                                       
                                                <asp:DropDownList ID="ddlcast" runat="server" TabIndex="17" CssClass="form-control" ></asp:DropDownList>    
                                            </div>
                                            <div class="col-lg-2" style="margin-top: 24px">
                                                <asp:CheckBox runat="server" CssClass="form-control" TabIndex="18" ID="chkbx_phys" Class="larger" Text="&nbsp;Physical Handicap" />
                                            </div>

                                        </div>
                                        <%--</div>--%>
                                        <%--   </div>--%>




                                        <%--      <div class="panel panel-primary">--%>

                                        <div class="card-title" style="margin-bottom: 0px">
                                            <%--Employee Entry--%>
                                        Address

                                        </div>
                                        <div class="container-fluid">
                                            <div class="row">
                                                <br />
                                                <%--------------row4--%>
                                                <div class="col-lg-6">
                                                    <div class="row">
                                                        <div class="col-lg-12">
                                                            <label for="inputState" class="form-label">Current Address<span class="redcolor">*</span></label>
                                                            <asp:TextBox ID="txtaddress" runat="server" TabIndex="19" autocomplete="off" Style="text-transform: uppercase" oncopy="return false" MaxLength="200" onpaste="return false" oncut="return false" onkeypress="return adres(event)" CssClass="form-control"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <br />
                                                    <div class="row">
                                                        <div class="col-lg-4">
                                                            <label for="inputState" class="form-label">Current City<span class="redcolor">*</span></label>
                                                            <asp:TextBox ID="txtcity" TabIndex="20" runat="server" oncut="return false" onpaste="return false" onkeypress="return onlyalpha(event)" CssClass="form-control" oncopy="return false" MaxLength="25" autocomplete="off"></asp:TextBox>
                                                        </div>

                                                        <div class="col-lg-4">
                                                            <label for="inputState" class="form-label">Current State<span class="redcolor">*</span></label>
                                                            <asp:DropDownList ID="ddlstate" TabIndex="21" runat="server" CssClass="form-control"></asp:DropDownList>
                                                        </div>
                                                        <div class="col-lg-4">
                                                            <label for="inputState" class="form-label">Current Pin Code<span class="redcolor">*</span></label>
                                                            <asp:TextBox runat="server" ID="TXTPIN" TabIndex="22" oncopy="return false" onpaste="return false" oncut="return false" MaxLength="6" onkeypress="return OnlyNum(event)" autocomplete="off" CssClass="form-control"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="TXTPIN" ForeColor="Red" ErrorMessage="Invalid Pin Code." ValidationExpression=".{6}.*"></asp:RegularExpressionValidator>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-lg-6">
                                                    <div class="row">
                                                        <div class="col-lg-12">
                                                            <label for="inputState" class="form-label">
                                                                Permanent Address<span class="redcolor">*</span>
                                                                &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp<asp:CheckBox ID="sameabov" OnCheckedChanged="sameabov_CheckedChanged" TabIndex="23" AutoPostBack="true" CssClass="chkbxx" Style="height: 40px; width: 40px" runat="server" />&nbsp<span style="color: black">Same As Current Address</span>
                                                            </label>
                                                            <asp:TextBox ID="txtadd" runat="server" oncopy="return false" TabIndex="24" Style="text-transform: uppercase" MaxLength="200" autocomplete="off" onpaste="return false" oncut="return false" onkeypress="return adres(event)" CssClass="form-control"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <br />

                                                    <div class="row">
                                                        <div class="col-lg-4">
                                                            <label for="inputState" class="form-label">Permanent City<span class="redcolor">*</span></label>
                                                            <asp:TextBox ID="txtpercity" runat="server" oncut="return false" TabIndex="25" onpaste="return false" onkeypress="return onlyalpha(event)" CssClass="form-control" oncopy="return false" MaxLength="25" autocomplete="off"></asp:TextBox>
                                                        </div>

                                                        <div class="col-lg-4">
                                                            <label for="inputState" class="form-label">
                                                                Permanent State<span class="redcolor">*</span>

                                                            </label>

                                                            <asp:DropDownList ID="ddlperState" CssClass="form-control" runat="server" TabIndex="26"></asp:DropDownList>
                                                        </div>
                                                        <div class="col-lg-4">
                                                            <label for="inputState" class="form-label">Permanent Pin Code<span class="redcolor">*</span></label>
                                                            <asp:TextBox runat="server" ID="txtperpin" TabIndex="27" oncopy="return false" onpaste="return false" oncut="return false" MaxLength="6" onkeypress="return OnlyNum(event)" autocomplete="off" CssClass="form-control"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>


                                            </div>
                                        </div>
                                        <%--</div>--%>
                                        <%--            <div class="panel panel-primary">--%>

                                        <div class="card-title" style="margin-bottom: 0px">
                                            <%--Employee Entry--%>
                                        Other Details

                                        </div>
                                        <div class="container-fluid">
                                            <div class="row">
                                                <br />
                                                <div class="col-lg-2">
                                                    <label for="inputState" class="form-label">Annual Salary<span class="redcolor">*</span></label>
                                                    <asp:TextBox ID="txtannualsal" runat="server" TabIndex="28" CssClass="form-control" autocomplete="off" MaxLength="7" oncopy="return false" onpaste="return false" oncut="return false" onkeypress="return OnlyNum(event)"> </asp:TextBox>
                                                </div>
                                                <div class="col-lg-2">
                                                    <label for="inputState" class="form-label">Aadhaar no.<span class="redcolor">*</span></label>
                                                    <asp:TextBox ID="txtaadhar" runat="server" CssClass="form-control" TabIndex="29" autocomplete="off" onkeypress="return OnlyNum(event)" MaxLength="12"></asp:TextBox>
                                                    <%--<asp:RegularExpressionValidator ID="aadhaarreg" runat="server" ControlToValidate="txtaadhar" ForeColor="Red" ErrorMessage="Invalid Aadhar Card No." ValidationExpression=".{12}.*"></asp:RegularExpressionValidator>--%>
                                                </div>
                                                <div class="col-lg-2">
                                                    <label for="inputState" class="form-label">Pan card no.<span class="redcolor">*</span></label>
                                                    <asp:TextBox ID="txtpan" runat="server" Style="text-transform: uppercase" TabIndex="30" CssClass="form-control" onkeypress="return alphanum(event)" autocomplete="off" MaxLength="10"></asp:TextBox>
                                                    <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtfirstname" ForeColor="Red" ErrorMessage="3 Characters Required" ValidationExpression=".{3}.*"></asp:RegularExpressionValidator>--%>
                                                    <%--<asp:RegularExpressionValidator ID="regi" runat="server" ControlToValidate="txtpan" ForeColor="Red" ErrorMessage="Invalid Pan Card no." ValidationExpression=".{10}.*"></asp:RegularExpressionValidator>--%>
                                                </div>
                                                <div class="col-lg-2">
                                                    <label for="inputState" class="form-label">PF No.<span class="redcolor">*</span></label>
                                                    <asp:TextBox ID="txt_pf" runat="server" CssClass="form-control" TabIndex="31" autocomplete="off" onkeypress="return pf(event)" MaxLength="22"></asp:TextBox>
                                                    <%--<asp:RegularExpressionValidator ID="reg_pf" runat="server" ControlToValidate="txt_pf" ForeColor="Red" ErrorMessage="Invalid PF no." ValidationExpression=".{20}.*"></asp:RegularExpressionValidator>--%>
                                                </div>
                                                <div class="col-lg-2">
                                                    <label for="inputState" class="form-label">Staff Type<span class="redcolor">*</span></label>
                                                    <asp:DropDownList ID="ddl_stafftype" TabIndex="32" runat="server" CssClass="form-control">
                                                        <asp:ListItem Text="--Select--" Selected="True"></asp:ListItem>
                                                        <asp:ListItem Text="PRINCIPAL" Value="PRINCIPAL"></asp:ListItem>
                                                        <asp:ListItem Text="STAFF" Value="STAFF"></asp:ListItem>
                                                        <asp:ListItem Text="OFFICE" Value="OFFICE"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="col-lg-2">
                                                    <label for="inputState" class="form-label">Group<span class="redcolor">*</span></label>
                                                <%--    <asp:UpdatePanel runat="server">
                                                        <ContentTemplate>--%>
                                                            <asp:ListBox ID="lstgroup" SelectionMode="Multiple" TabIndex="32" runat="server"></asp:ListBox>
                                                  <%--      </ContentTemplate>
                                                    </asp:UpdatePanel>--%>
                                                </div>
                                            </div>
                                            <br />
                                        </div>
                                        <%--   </div>--%>

                                        <div class="card-title" style="margin-bottom: 0px">
                                            <%--Employee Entry--%>
                                       Access

                                        </div>
                                        <%--<div class="panel panel-primary">--%>
                                        <%--<div class="panel-heading" style="margin-bottom: 0px; padding-top: 0px">--%>

                                        <%--   </div>--%>
                                        <div class="container-fluid">
                                            <br />
                                            <div class="row  my-2">
                                                <div class="col-lg-1"></div>
                                                <div class="col-lg-2">
                                                    <div class="row">
                                                        <div class="col-lg-9">
                                                            <label for="inputState" class="form-label">Department<span class="redcolor">*</span></label>
                                                         <%--   <asp:UpdatePanel ID="deptupdate" runat="server">
                                                                <ContentTemplate>--%>
                                                                    <asp:DropDownList ID="ddldepart1" runat="server" TabIndex="33"   CssClass="form-control"></asp:DropDownList>
                                                         <%--       </ContentTemplate>
                                                            </asp:UpdatePanel>--%>
                                                        </div>
                                                        <div class="col-lg-3">
                                                            <br />
                                                            <asp:LinkButton ID="btndep" runat="server" TabIndex="34" data-toggle="modal" data-target="#adddept" CssClass=" btn btn-primary" Style="margin-top: 5px"><i class="bi bi-plus"></i></asp:LinkButton>
                                                        </div>
                                                    </div>

                                                </div>
                                                <div class="col-lg-2">
                                                    <div class="row">
                                                        <div class="col-lg-9">
                                                            <%--<asp:UpdatePanel runat="server" ID="updt">
                                                                <ContentTemplate--%>
                                                                    <label for="inputState" class="form-label">Designation<span class="redcolor">*</span></label>
                                                                    <asp:DropDownList ID="ddlDesignation1" TabIndex="35" runat="server" AutoPostBack="false" CssClass="form-control" >
                                                                    </asp:DropDownList>
                                                           <%--     </ContentTemplate>
                                                            </asp:UpdatePanel>--%>
                                                        </div>
                                                        <div class="col-lg-3">
                                                            <br />
                                                            <asp:LinkButton ID="btndesignation" runat="server" TabIndex="36" data-toggle="modal" data-target="#modal_desg" CssClass=" btn btn-primary justify-content-center " Style="margin-top: 5px;"><i class="bi bi-plus" style=""></i></asp:LinkButton>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-lg-2">
                                                    <div class="row">
                                                        <div class="col-lg-9">
                                                            <label for="inputState" class="form-label">Role<span class="redcolor">*</span></label><br />
                                                         <%--   <asp:UpdatePanel ID="uy" runat="server">
                                                                <ContentTemplate>--%>
                                                                    <asp:DropDownList ID="ddlRole" runat="server" TabIndex="37" OnSelectedIndexChanged="ddlRole_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>
                                                             <%--   </ContentTemplate>
                                                            </asp:UpdatePanel>--%>

                                                        </div>
                                                        <div class="col-lg-3">
                                                            <br />

                                                            <asp:LinkButton ID="btnRole" data-toggle="modal" TabIndex="38" data-target="#addrol" runat="server" CssClass="btn btn-primary justify-content-center" Style="margin-top: 5px;">
                                                    <i class="bi bi-plus" ></i>
                                                            </asp:LinkButton>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="col-lg-2" style="margin-top: 4px;">
                                                    <label for="inputState" class="form-label">Module</label>
                                                    <br />
                                              <%--      <asp:UpdatePanel runat="server">
                                                        <ContentTemplate>--%>
                                                            <asp:ListBox runat="server" ID="lstbx_Module" AutoPostBack="true" SelectionMode="Multiple" OnSelectedIndexChanged="lstbx_Module_SelectedIndexChanged"></asp:ListBox>
                                             <%--           </ContentTemplate>
                                                    </asp:UpdatePanel>--%>



                                                </div>
                                                <div class="col-lg-2" style="margin-top: 4px;">
                                                    <label for="inputState" class="form-label">Form Name</label>
                                                    <br />
                                                    <%--<asp:UpdatePanel runat="server">
                                                        <ContentTemplate>--%>
                                                            <asp:ListBox runat="server" ID="lstbx_formname" SelectionMode="Multiple"></asp:ListBox>
                                          <%--              </ContentTemplate>
                                                    </asp:UpdatePanel>--%>

                                                </div>
                                            </div>
                                        </div>
                                        <%--</div>--%>

                                        <br />
                                        <div class="container">
                                            <div class="row my-5">
                                                <div class="col-lg-3"></div>
                                                <div class="col-lg-2">
                                                    <asp:Button widh="100%" Style="width: 100%;background: linear-gradient(to right, #72afd3 0%, #37ecba 104%);" ID="btnmodify" TabIndex="39" runat="server" OnClick="btnmodify_Click" Text="Modify" CssClass="btn btn-primary  mx-auto" />
                                                </div>
                                                <div class="col-lg-2">
                                                    <asp:Button widh="100%" Style="width: 100%;background: linear-gradient(to right, #72afd3 0%, #37ecba 104%);" ID="btnsave" TabIndex="40" runat="server" Text="Save" OnClick="btnsave_Click" CssClass="btn btn-primary  mx-auto" />
                                                </div>
                                                <div class="col-lg-2">
                                                    
                                                    <asp:Button widh="100%" Style="width: 100%;background: linear-gradient(to right, #72afd3 0%, #37ecba 104%);" ID="btnclear" TabIndex="41" runat="server" OnClick="btnclear_Click"  Text="Clear" CssClass="btn  btn-primary " />
                                                </div>
                                            </div>
                                            <div class="col-lg-3"></div>
                                        </div>
                                        <%--</div>--%>
                                    </div>
                                </div>

                                <%--    </div>--%>
                            </div>
                        </div>
                    </div>
                </div>


            </ContentTemplate>
        </asp:UpdatePanel>

    </div>

    <script>
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        if (prm != null) {
            prm.add_endRequest(function (sender, e) {
                if (sender._postBackSettings.panelsToUpdate != null) {
                    datepic();
                }
            });
        };
        function onlyalpha(event) {
            var value = String.fromCharCode(event.which);
            var pattern = new RegExp(/^[A-Za-z\s\']+$/);
            return pattern.test(value);
        }

        function singleQuote(event) {
            var value = String.fromCharCode(event.which);
            var pattern = new RegExp(/^[A-Za-z\s\'\n]+$/);
            return pattern.test(value);
        }
        function OnlyNum(event) {
            var value = String.fromCharCode(event.which);
            var pattern = new RegExp(/[0-9]/);
            return pattern.test(value);
        }
        function date22(event) {
            var value = String.fromCharCode(event.which);
            var pattern = new RegExp(/[0-9/]/i);
            return pattern.test(value);
        }
        function adres(event) {
            var value = String.fromCharCode(event.which);
            var pattern = new RegExp(/^[A-Za-z 0-9'\.\-\s\,\(\)\/]+$/);
            return pattern.test(value);
        }

        function alphanum(event) {
            var value = String.fromCharCode(event.which);
            var pattern = new RegExp(/^[A-Za-z 0-9]+$/);
            return pattern.test(value);
        }
        function pf(event) {
            var value = String.fromCharCode(event.which);
            var pattern = new RegExp(/^[A-Za-z 0-9 \/]+$/);
            return pattern.test(value);
        }
        loadmulti();
        function loadmulti() {

            $('[id*=lstgroup]').multiselect({
                includeSelectAllOption: true

            });

            $('[id*=lstbx_Module]').multiselect({
                includeSelectAllOption: true
            });


            $('[id*=lstbx_formname]').multiselect({
                includeSelectAllOption: true
            });

        }

  

/*        datepic();*/
        function datepic() {
            $('[id*=txtDOJ]').datetimepicker(
                {
                    changeMonth: false,
                    changeYear: false,
                    timepicker: false,
                    format: 'd-m-Y'
                });
            $('[id*=txtdob]').datetimepicker(
                {
                    changeMonth: false,
                    changeYear: false,
                    timepicker: false,
                    format: 'd-m-Y'
                    /* maxDate: new Date(2004, 0, 1)*/
                }
            );
        }

   

        function notify(msg, type) {
            $.notify(msg, { type: type, animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.2, delay: 0 });
        }
        /*  loadmulti();*/
        //function OnlyNum(event) {
        //    var value = String.fromCharCode(event.which);
        //    var pattern = new RegExp(/[0-9]/i);
        //    return pattern.test(value);
        //}


        function EnterKeyFilter() {
            if (window.event.keyCode == 13) {
                event.returnValue = false
                event.cancel = true
            }
        }
        window.addEventListener('keydown', EnterKeyFilter)
        function nametxt(e) {
            isIE = document.all ? 1 : 0
            keyEntry = !isIE ? e.which : event.keyCode;
            if (((keyEntry >= '65') && (keyEntry <= '90')) || ((keyEntry >= '97') && (keyEntry <= '122')) || (keyEntry == '32') || (keyEntry == '39'))
                return true;
            else {
                return false;
            }
        }
        function myFunction() {
            var valhh = document.getElementById('<%=dep_name.ClientID%>').value;
            document.getElementById('<%=dep_name.ClientID%>').value = '';
            document.getElementById('<%=dpt_prefix.ClientID%>').value = '';

        }
        function DESGFUN() {
            document.getElementById('<%=txtdesname.ClientID%>').value = '';

        }
        function ROLEE() {
            document.getElementById('<%=txt_rol.ClientID%>').value = '';

        }


    </script>


</asp:Content>

