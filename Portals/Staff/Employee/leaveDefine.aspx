<%@ Page Title="" Language="C#" MasterPageFile="~/Portals/Staff/MasterPage.master" AutoEventWireup="true" CodeFile="leaveDefine.aspx.cs" Inherits="Portals_Staff_Employee_leaveDefine" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous" />
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.12.9/dist/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.js"></script>
    <script src="http://code.jquery.com/jquery-1.11.2.min.js"></script>

    
    <link href="../../../Assets/notify-master/css/notify.css" rel="stylesheet" />

    <script src="../../../Assets/notify-master/js/notify.js"></script>


    <link href="../../../Assets/multiselect/css/bootstrap-multiselect.css" rel="stylesheet" />
    <script src="../../../Assets/multiselect/js/bootstrap-multiselect.js"></script>

  

    <link href="../../../Assets/css/jquery.datetimepicker.css" rel="stylesheet" />

    <script src="../../../Assets/js/jquery.datetimepicker.js"></script>
    <script src="js/jquery.datetimepicker.js"></script>


    <style>
        table {
            /*border-collapse: collapse;*/
            width: 100%;
        }

        table, td, th {
            border: 1px solid #ddd;
            text-align: left;
        }

        th, td {
            text-align: center;
            padding: 8px;
        }

        /*tr:nth-child(even){background-color: #f2f2f2}*/

        th {
            color: #012970;
            background-color:white;
        }

        .FixedHeader {
            position: sticky;
            font-weight: bold;
            top: 0;
        }

         .multiselect-container {
            overflow: scroll;
            max-height: 250px;
        }

       

        .multiselect {
            /*margin-top: 5px;*/
            border: 1px solid #ced4da;
            width: 210px;
        }

        .card {
            display: flex;
            margin-left: -12vh;
        }

        .card-header {
            background-color: #337ab7;
            color: #fff;
            font-weight: 700;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <div id="main" class="main">
        <div class="row" style="margin-top: 10px;">

            <div class="col-lg-1 col-md-1 col-sm-1"></div>
            <div class="col-lg-11 col-md-11 col-sm-11">


                <div class="card-text" style="margin-left: -60px; color: #012970;">
                    <span style="font-family: Verdana; font-size: 18pt"><strong>Leave Define</strong></span>
                    <div class="pull-right">
                        <div class="form-group">
                        </div>
                    </div>
                </div>

                <div class="card">

                    <%--<div class="card-body">--%>
                    <%--<form role="form">--%>
                    <div class="row mt-3">
                        <div class="col-lg-12 col-md-12 col-sm-12">
                            <%--<form role="form">--%>
                            <div class="container-fluid">
                                <div class="card-body">

                                    <div class="row">
                                        <div class="col-lg-3 col-md-3 col-sm-3">
                                            <div class="form-group">
                                                <asp:Label ID="lbl_emp_type" runat="server" Text="Employee Type :"></asp:Label>
                                                <asp:DropDownList ID="ddl_emp_type" AutoPostBack="true" OnSelectedIndexChanged="ddl_emp_type_SelectedIndexChanged" CssClass="form-control" runat="server">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-lg-3 col-md-3 col-sm-3">
                                            <div class="form-group">
                                                <asp:Label ID="lbl_department" runat="server" Text="Department :"></asp:Label>
                                                <asp:DropDownList ID="ddl_department" AutoPostBack="true" OnSelectedIndexChanged="ddl_department_SelectedIndexChanged" CssClass="form-control" runat="server">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-lg-3 col-md-3 col-sm-3">
                                            <div class="form-group">
                                                <asp:Label ID="lbl_year" runat="server" Text="Year :"></asp:Label>
                                                <asp:DropDownList ID="ddl_year" CssClass="form-control" runat="server">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-lg-3 col-md-3 col-sm-3">
                                            <div class="form-group">
                                                <asp:Label ID="lbl_emp_name" runat="server" Text="Employee Name:"></asp:Label>
                                                <asp:ListBox ID="ddl_emp_name" runat="server" SelectionMode="Multiple"></asp:ListBox>
                                            </div>

                                        </div>
                                    </div>
                                    <br />

                                    <%--Types of Leave--%>
                                    <div class="row">
                                        <div class="col-lg-1 col-md-1 col-sm-1">
                                            <div class="form-group">
                                                <asp:Label ID="lbl_cl" runat="server" Text="Casual Leave :"></asp:Label>
                                                <asp:TextBox ID="txtcl" runat="server" CssClass="form-control" MaxLength="5" AutoCompleteType="Disabled" onkeypress="return CheckNumeric(event)" onpaste="return false"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-lg-1 col-md-1 col-sm-1">
                                            <div class="form-group">
                                                <asp:Label ID="lbl_ml" runat="server" Text="Medical Leave :"></asp:Label>
                                                <asp:TextBox ID="txtml" runat="server" CssClass="form-control" MaxLength="5" AutoCompleteType="Disabled" onkeypress="return CheckNumeric(event)" onpaste="return false"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-lg-2 col-md-2 col-sm-2">
                                            <div class="form-group">
                                                <asp:Label ID="lbl_Pml" runat="server" Text="Previous Medical Leave :"></asp:Label>
                                                <asp:TextBox ID="txt_Pml" runat="server" CssClass="form-control" MaxLength="5" AutoCompleteType="Disabled" onkeypress="return CheckNumeric(event)" onpaste="return false"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-lg-1 col-md-1 col-sm-1">
                                            <div class="form-group">
                                                <asp:Label ID="lbl_el" runat="server" Text="Earned Leave :"></asp:Label>
                                                <asp:TextBox ID="txtel" runat="server" CssClass="form-control" MaxLength="5" AutoCompleteType="Disabled" onkeypress="return CheckNumeric(event)" onpaste="return false"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-lg-2 col-md-2 col-sm-2">
                                            <div class="form-group">
                                                <asp:Label ID="lbl_Pel" runat="server" Text="Previous Earned Leave :"></asp:Label>
                                                <asp:TextBox ID="txt_Pel" runat="server" CssClass="form-control" MaxLength="5" AutoCompleteType="Disabled" onkeypress="return CheckNumeric(event)" onpaste="return false"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-lg-2 col-md-2 col-sm-2" style="visibility: hidden">
                                            <div class="form-group">
                                                <asp:Label ID="lbl_outd" runat="server" Text="Outdoor Duty :"></asp:Label>
                                                <asp:TextBox ID="txtoutd" runat="server" CssClass="form-control" MaxLength="5" onkeypress="return CheckNumeric(event)" onpaste="return false"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-lg-2 col-md-2 col-sm-2" style="visibility: hidden">
                                            <div class="form-group">
                                                <asp:Label ID="lbl_comp" runat="server" Text="Compensatory Leave :"></asp:Label>
                                                <asp:TextBox ID="txtcomp" runat="server" CssClass="form-control" MaxLength="5" onkeypress="return CheckNumeric(event)" onpaste="return false"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>

                                    <%--Button Save and Reset--%>
                                    <div class="row" style="text-align: center">
                                        <div class="col-lg-12">
                                            <center>
                                                <div class="row mt-2">
                                                    <div class="col-lg-4 col-md-4 col-sm-4"></div>
                                                    <div class="col-lg-2 col-md-2 col-sm-2">
                                                        <br />
                                                        <asp:Button runat="server" class="btn btn-block btn-success form-control" Text="Save" OnClick="btnsave_Click" ID="btnsave" />
                                                    </div>
                                                    <div class="col-lg-2 col-md-2 col-sm-2">
                                                        <br />
                                                        <asp:Button type="button" runat="server" class="btn btn-block btn-success form-control" Text="Reset" OnClick="btnreset_Click" ID="btnreset" />
                                                    </div>
                                                    <div class="col-lg-4 col-md-4 col-sm-4"></div>
                                                </div>
                                            </center>
                                        </div>
                                    </div>

                                    <br />

                                    <%--GridTable--%>
                                    <div class="row">
                                        <div class="container" runat="server" id="grid" style="overflow-y: auto; overflow-x: auto; max-height: 500px;">
                                            <div class="col-lg-12 col-md-12 col-sm-12">


                                                <asp:GridView ID="grd_load" runat="server" OnRowDeleting="grd_load_RowDeleting" HeaderStyle-BackColor="#9599a3" BorderColor="#000" Width="100%" AutoGenerateColumns="false" OnRowCommand="grd_load_RowCommand" Style="text-align: center">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="SR.NO">

                                                            <ItemTemplate>
                                                                <asp:Label ID="lblsrno" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                                            </ItemTemplate>

                                                        </asp:TemplateField>

                                                        <asp:TemplateField ItemStyle-Width="30px" HeaderText="ID" visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl_id" runat="server" Text='<%#Eval("id")%>'></asp:Label>
                                                            </ItemTemplate>

                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Employee ID" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblempid" runat="server" Text='<%#Eval("emp_id")%>'></asp:Label>
                                                            </ItemTemplate>

                                                        </asp:TemplateField>

                                                        <asp:TemplateField ItemStyle-Width="50px" HeaderText="Department ID" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblDeptid" runat="server" Text='<%#Eval("emp_dept_id")%>'></asp:Label>
                                                            </ItemTemplate>

                                                        </asp:TemplateField>

                                                        <asp:TemplateField ItemStyle-Width="30px" HeaderText="Role id" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblroleid" runat="server" Text='<%#Eval("role_id")%>'></asp:Label>
                                                            </ItemTemplate>

                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Employee Name">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblempname" runat="server" Text='<%#Eval("name")%>'></asp:Label>
                                                            </ItemTemplate>

                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="CL">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblcl" runat="server" Text='<%#Eval("CL")%>'></asp:Label>
                                                            </ItemTemplate>

                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="CO" ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblco" runat="server" Text='<%#Eval("CO")%>'></asp:Label>
                                                            </ItemTemplate>

                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="ML">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblml" runat="server" Text='<%#Eval("ML")%>'></asp:Label>
                                                            </ItemTemplate>

                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Previous ML">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblPml" runat="server" Text='<%#Eval("PML")%>'></asp:Label>
                                                            </ItemTemplate>

                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="EL">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblel" runat="server" Text='<%#Eval("EL")%>'></asp:Label>
                                                            </ItemTemplate>

                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Previous EL">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblPel" runat="server" Text='<%#Eval("PEL")%>'></asp:Label>
                                                            </ItemTemplate>

                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="OUTD" ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbloutd" runat="server" Text='<%#Eval("OUTD")%>'></asp:Label>
                                                            </ItemTemplate>

                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Year">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblyear" runat="server" Text='<%#Eval("Duration")%>'></asp:Label>
                                                            </ItemTemplate>

                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="ayid" Visible="false" >
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblayid" runat="server" Text='<%#Eval("year")%>'></asp:Label>
                                                            </ItemTemplate>

                                                        </asp:TemplateField>

                                                        <asp:ButtonField ButtonType="Link" runat="server" HeaderText="Delete" Text="Delete" CommandName="delete"></asp:ButtonField>

                                                        <asp:ButtonField ButtonType="Link" runat="server" HeaderText="Select" Text="Select" CommandName="select"></asp:ButtonField>

                                                    </Columns>
                                                </asp:GridView>


                                            </div>
                                        </div>
                                    </div>

                                </div>
                            </div>
                            <%--</form>--%>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>

    <script>
        loadmulti();
        function loadmulti() {

            $('[id*=ddl_emp_name]').multiselect({
                includeSelectAllOption: true

            });
        }
        
    </script>
    <script>
        function CheckNumeric(e) {

            if (window.event) // IE
            {
                if ((e.keyCode < 48 || e.keyCode > 57) & e.keyCode != 8 & e.keyCode != 46) {
                    event.returnValue = false;
                    return false;

                }
            }
            else { // Fire Fox
                if ((e.which < 48 || e.which > 57) & e.which != 8 & e.which != 46) {
                    e.preventDefault();
                    return false;

                }
            }
        }
    </script>

</asp:Content>

