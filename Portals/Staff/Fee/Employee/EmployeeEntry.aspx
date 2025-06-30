<%@ Page Title="" Language="C#" MasterPageFile="~/Portals/Staff/MasterPage.master" AutoEventWireup="true" CodeFile="EmployeeEntry.aspx.cs" Inherits="Portals_Staff_Employee_EmployeeEntry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

        <%--<link href="http://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/css/bootstrap.min.css"
        rel="stylesheet" type="text/css" />--%>
    <%--<script type="text/javascript" src="http://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/js/bootstrap.min.js"></script>--%>
    <%--<link href="http://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/css/bootstrap-multiselect.css"
        rel="stylesheet" type="text/css" />--%>
    <%--<script src="http://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/js/bootstrap-multiselect.js"
        type="text/javascript"></script>--%>

    <script src="../../../Assets/multiselect/JavaScript.js"></script>
    <script src="../../../Assets/multiselect/Multiselect1.js"></script>
    <link href="../../../Assets/multiselect/StyleSheet.css" rel="stylesheet" />
    <link href="../../../Assets/multiselect/StyleSheet2.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main" class="main">
        <div class="container-fluid">
            <div class="pagetitle" style="font-size: 20px; margin-left: 34px; font-weight: 300; color: #012970;">
                Employee Entry
            </div>
            <div class="container-fluid">
                <div class="row">
                    <div class="col-lg-7">
                        <div class="card">
                            <div class="card-title mx-4">
                                Employee Entry
                            </div>
                            <div class="card-body">
                                <div class="row">
                                    <div class="col-lg-3 col-md-3 col-sm-12">
                                        <label for="inputState" class="form-label">Employee ID</label>
                                        <asp:TextBox ID="txtEmpId" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-3 col-md-2 col-sm-12">
                                        <label for="inputState" class="form-label">Last Name</label>
                                        <asp:TextBox ID="txtlastname" runat="server" CssClass="form-control"></asp:TextBox>
<asp:RegularExpressionValidator ID="regtxtlastname" runat="server" ControlToValidate="txtlastname" ForeColor="Red" ErrorMessage="*3 Characters Required" ValidationExpression=".{3}.*"></asp:RegularExpressionValidator>
                                    </div>
                                    <div class="col-lg-3 col-md-2 col-sm-12">
                                        <label for="inputState" class="form-label">First Name</label>
                                        <asp:TextBox ID="txtfirstname" runat="server" CssClass="form-control"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="regexpressionid2" runat="server" ControlToValidate="txtfirstname" ForeColor="Red" ErrorMessage="3 Characters Required" ValidationExpression=".{3}.*"></asp:RegularExpressionValidator>
                                    </div>
                                    <div class="col-lg-3 col-md-2 col-sm-12">
                                        <label for="inputState" class="form-label">Middle Name</label>
                                        <asp:TextBox ID="txtmiddlename" runat="server" CssClass="form-control"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="regid3" runat="server" ControlToValidate="txtmiddlename" ForeColor="Red" ErrorMessage="*3 Characters Required" ValidationExpression=".{3}.*"></asp:RegularExpressionValidator>
                                    </div>
                                </div>
                                <div class="row ">
                                    <div class="col-lg-3 col-md-2 col-sm-12">
                                        <label for="inputState" class="form-label">Mother Name</label>
                                        <asp:TextBox ID="txtmothername" runat="server" CssClass="form-control"></asp:TextBox>
                                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtmothername" ForeColor="Red" ErrorMessage="*3 Characters Required" ValidationExpression=".{3}.*" Display="Dynamic"></asp:RegularExpressionValidator>
                                    </div>

                                    <div class="col-lg-3 col-md-3 col-sm-12">
                                        <label for="inputState" class="form-label">Gender</label>
                                        <asp:RadioButtonList ID="rad_gender" runat="server" CssClass="form-control" RepeatDirection="Horizontal">
                                            <asp:ListItem Text="Male" Value="1" />
                                            <asp:ListItem Text="Female" Value="0" />
                                        </asp:RadioButtonList>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-12">
                                        <label for="inputState" class="form-label">D.O.J</label>
                                        <asp:TextBox ID="txtDOJ" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>

                                    <div class="col-lg-3 col-md-3 col-sm-12">
                                        <label for="inputState" class="form-label">D.O.B</label>
                                        <asp:TextBox ID="txtdob" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>


                                </div>
                                <div class="row">
                                    <div class="col-lg-3">
                                        <label for="inputState" class="form-label">Annual Salary</label>
                                        <asp:TextBox ID="txtannualsal" runat="server" CssClass="form-control"> </asp:TextBox>
                                    </div>
                                    <div class="col-lg-3">
                                        <label for="inputState" class="form-label">Blood Group</label>
                                        <asp:DropDownList ID="ddlbloodgroup" runat="server" CssClass="form-select">
                                            <asp:ListItem Value="0">--Select--</asp:ListItem>

                                            <asp:ListItem Value="1">A+</asp:ListItem>
                                            <asp:ListItem Value="2">A-</asp:ListItem>
                                            <asp:ListItem Value="3">B+</asp:ListItem>
                                            <asp:ListItem Value="4">B-</asp:ListItem>
                                            <asp:ListItem Value="5">O+</asp:ListItem>
                                            <asp:ListItem Value="6">O-</asp:ListItem>
                                            <asp:ListItem Value="7">AB+</asp:ListItem>
                                            <asp:ListItem Value="8">AB-</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-lg-3">
                                        <label for="inputState" class="form-label">Mobile no</label>
                                        <asp:TextBox ID="txtmobno" runat="server" MaxLength="10" onkeypress="return OnlyNum(event)" CssClass="form-control"></asp:TextBox>

                                    </div>
                                    <div class="col-lg-3">
                                        <label for="inputState" class="form-label">Mobile no</label>
                                        <asp:TextBox ID="txtmobile" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>

                                </div>
                                <div class="row">

                                    <div class="col-lg-6">

                                        <label for="inputState" class="form-label">Email ID</label>
                                        <asp:TextBox ID="txtemail" TextMode="Email" runat="server" CssClass="form-control"></asp:TextBox>

                                    </div>
                                    <div class="col-lg-6">
                                        <label for="inputState" class="form-label">Address</label>
                                        <asp:TextBox ID="txtaddress" runat="server" CssClass="form-control"></asp:TextBox>
                                        <%--<textarea id="txtaddre" runat="server" class="form-control"></textarea>--%>
                                    </div>
                                </div>
                                <div class="row my-2">
                                    <div class="col-lg-3">
                                        <div class="row">
                                            <div class="col-lg-9">
                                                <label for="inputState" class="form-label">Department</label>
                                                <asp:DropDownList ID="ddldepart1" runat="server" CssClass="form-select"></asp:DropDownList>
                                            </div>
                                            <div class="col-lg-3">
                                                <asp:Button ID="btndep" runat="server" CssClass=" btn btn-primary" Style="height: 36px; margin-top: 20px; width: 33px;" />
                                            </div>

                                        </div>
                                    </div>

                                    <div class="col-lg-3">
                                        <div class="row">
                                            <div class="col-lg-9">
                                                <label for="inputState" class="form-label">Designation</label>
                                                <asp:DropDownList ID="ddlDesignation1" runat="server" CssClass="form-select" AutoPostBack="true">
                                                </asp:DropDownList>

                                            </div>
                                            <div class="col-lg-3">
                                                <asp:Button ID="btndesignation" runat="server" CssClass=" btn btn-primary justify-content-center " Style="height: 36px; margin-top: 20px; width: 33px;" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-lg-3">
                                        <div class="row">
                                            <div class="col-lg-9">
                                                <label for="inputState" class="form-label">Role</label>
                                                <asp:DropDownList ID="ddlRole" runat="server" CssClass="form-select" AutoPostBack="true"></asp:DropDownList>
                                            </div>
                                            <div class="col-lg-3">
                                                <asp:Button ID="btnRole" runat="server" CssClass="btn btn-primary justify-content-center" Style="height: 36px; margin-top: 20px; width: 33px;" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-lg-3">
                                        <label for="inputState" class="form-label">Category</label>
                                        <asp:DropDownList ID="ddlCategory" runat="server" CssClass="form-select" AutoPostBack="true">
                                            <asp:ListItem Value="0">--Select--</asp:ListItem>
                                            <asp:ListItem Value="1">Principle</asp:ListItem>
                                            <asp:ListItem Value="2">Staff</asp:ListItem>
                                            <asp:ListItem Value="3">Office</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class=" row my-4">
                                    <div class="col-lg-4">
                                        <label for="inputState" class="form-label">Group</label>
                                        <asp:ListBox ID="lstgroup" SelectionMode="Multiple" runat="server">
                                            <%--<asp:ListItem Text="Select All" Value="0"></asp:ListItem>--%>
                                            <asp:ListItem Text="FY MMS" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="SY MMS" Value="2">   </asp:ListItem>
                                        </asp:ListBox>
                                    </div> 
                                    <div class="col-lg-4">
                                        <label for="inputState" class="form-label">Module Name</label>
                                        <asp:ListBox runat="server" ID="lstmodule" SelectionMode="Multiple">
                                            <%--<asp:ListItem Text="Select All" Value="0"></asp:ListItem>--%>
                                            <asp:ListItem Text="Admission" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Master" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="staff Portal" Value="3"></asp:ListItem>
                                            <asp:ListItem Text="Student" Value="4"></asp:ListItem>
                                        </asp:ListBox>
                                    </div>
                                    <div class="col-lg-4">
                                        <label for="inputState" class="form-label">Form Select</label>
                                        <asp:ListBox runat="server" ID="lstform" SelectionMode="Multiple">
                                            <%--<asp:ListItem Text="Select All" Value="0"></asp:ListItem>--%>
                                            <asp:ListItem Text="Admission" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Master" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="staff Portal" Value="3"></asp:ListItem>
                                            <asp:ListItem Text="Student" Value="4"></asp:ListItem>
                                        </asp:ListBox>
                                    </div>
                                </div>
                                <div class="row my-5">
                                    
                                    <div class="col-lg-4">
                                        <asp:Button ID="btnmodify" runat="server" Text="Modify" CssClass="btn btn-primary form-control mx-auto" />
                                    </div>
                                    <div class="col-lg-4">
                                        <asp:Button ID="btnsave" runat="server" Text="Save" CssClass="btn btn-primary form-control mx-auto" />
                                    </div>
                                    <div class="col-lg-4">
                                        <asp:Button ID="btnclear" runat="server" Text="Clear" CssClass="btn  btn-primary form-control" />
                                    </div>
                                    
                                </div>



                            </div>
                            <div class="card-footer"></div>
                        </div>
                    </div>
                    <div class="col-lg-5">
                        <div class="card">
                            <div class="card-title">
                                Import Excel Department/Designation Wise 
                            </div>
                            <div class="card-body">
                                <div class="row">
                                    <div class="col-lg-6">
                                        <label for="inputState" class="form-label">Department</label>
                                        <asp:DropDownList runat="server" ID="ddldept2" CssClass="form-select">
                                            <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>

                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-lg-6">
                                        <label for="inputState" class="form-label">Designation</label>
                                        <asp:DropDownList ID="ddldesignation2" runat="server" CssClass="form-select" AutoPostBack="true">
                                            <asp:ListItem Text="--select--" Value="0"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-6">
                                        <label for="inputState" class="form-label">Role</label>
                                        <asp:DropDownList ID="ddlRole2" runat="server" CssClass="form-select"></asp:DropDownList>
                                    </div>
                                    <div class="col-lg-6">
                                        <label for="inputState" class="form-label ">Category</label>
                                        <asp:DropDownList ID="ddlcategory2" runat="server" CssClass="form-select"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="row my-4">
                                    <div class="col-lg-12">
                                        <div class="row">
                                            <%--<div class="col-lg-3"><label for="inputNumber" class="col-form-label">File Upload</label></div>--%>
                                            <div class="col-lg-12">
                                           Select Excel File   <input class="form-control" type="file" id="formFile"/>
                                            </div>
                                        </div>
                                                          
                                        
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-6">
                                        <asp:Button ID="btnupload" runat="server" Text="Upload" CssClass="btn btn-primary form-control" />
                                    </div>
                                    <div class="col-lg-6">
                                        <asp:Button ID="btngetexcel" runat="server" Text="Get Excel" CssClass="btn btn-primary form-control" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </div>
    <script>
        $(function () {
            $('[id*=lstgroup]').multiselect({
                includeSelectAllOption: true
            });
        });
        $(function () {
            $('[id*=lstform]').multiselect({
                includeSelectAllOption: true
            });
        });

        $(function () {
            $('[id*=lstmodule]').multiselect({
                includeSelectAllOption: true
            });
        });
        function OnlyNum(event) {
            var value = String.fromCharCode(event.which);
            var pattern = new RegExp(/[0-9]/i);
            return pattern.test(value);
        }

        $(document).ready(function () {
            $('[id*=lstmonth]').multiselect({
                buttonWidth: '100%',
            });
        });
    </script>


</asp:Content>

