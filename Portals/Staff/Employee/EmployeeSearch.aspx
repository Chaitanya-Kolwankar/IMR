<%@ Page Title="" Language="C#" MasterPageFile="~/Portals/Staff/MasterPage.master" AutoEventWireup="true" CodeFile="EmployeeSearch.aspx.cs" Inherits="Portals_Staff_Employee_EmployeeSearch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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

        .pascal {
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
            Employee 
            </div>
            <div class="container-fluid">
            <div class="card">
                <div class="card-title mx-4">Search Employee ID / Password</div>
                
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="card-body">                          
                            <div class="container-fluid">
                                <div class="row">
                                    <div class="col-lg-2">
                                        <label for="inputState" class="form-label">First Name</label>
                                        <asp:TextBox ID="txtfirstname" runat="server" MaxLength="25" CssClass="form-control" onkeyPress="return singleQuote(event)" onkeydown="return (event.keyCode!=13);"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="fnameregexp" runat="server" ControlToValidate="txtfirstname" ErrorMessage=" Enter Min 3 Character" ForeColor="Red" ValidationExpression=".{3}.*" Display="Dynamic">
                                        </asp:RegularExpressionValidator>
                                    </div>
                                    <div class="col-lg-2">
                                        
                                            <label for="inputState" class="form-label">Middle Name</label>

                                       <asp:TextBox ID="txtmiddlename" runat="server" MaxLength="25" CssClass="form-control"  onkeyPress="return singleQuote(event)"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="mnameregexp" runat="server" ControlToValidate="txtmiddlename" ErrorMessage="Enter Min 3 Character" ForeColor="Red" ValidationExpression=".{3}.*" Display="Dynamic"></asp:RegularExpressionValidator>
                                        
                                    </div>
                                    <div class="col-lg-2">
                                        <div class="">
                                            <label for="inputState" class="form-label">Last Name</label>
                                            <asp:TextBox ID="txtlastname" runat="server" MaxLength="25" onkeyPress="return singleQuote(event)" onkeydown="return (event.keyCode!=13);" CssClass="form-control"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="lnameexp" runat="server" ControlToValidate="txtlastname" ErrorMessage=" Enter 3  Min Character" ForeColor="Red"
                                                ValidationExpression=".{3}.*" Display="Dynamic">

                                            </asp:RegularExpressionValidator>
                                        </div>
                                    </div>
                                    <div class="col-lg-4">
                                        <div class="row" style="padding-top: 31px;">
                                            <div class="col-lg-6">
                                                <asp:Button ID="btn_search" runat="server" CssClass=" form-control text-center btn btn-primary" Text="Search" OnClick="btn_search_Click" />
                                            </div>
                                            <div class="col-lg-6">
                                                <asp:Button ID="btnclear" CausesValidation="false" runat="server" class="form-control btn  btn-primary" Text="Clear" OnClick="btnclear_Click" />
                                            </div>
                                        </div>
                                    </div>                                                                        
                                </div>
                                <br />                                
                                <div style="width: 100%; max-height: 400px; overflow: auto">
                                    <div>
                                        <asp:GridView ID="grd_data2" runat="server" HeaderStyle-BackColor="White" HeaderStyle-CssClass="FixedHeader" Style="max-height: 400px; overflow: auto" AutoGenerateColumns="False" OnRowDataBound="grd_data2_RowDataBound2" OnRowCommand="grd_data2_RowCommand1">
                                            <Columns>
                                                <asp:BoundField DataField="emp_id" HeaderText="Employee ID" HeaderStyle-Height="30px" />
                                                <asp:BoundField DataField="Employee" HeaderText="Employee Name" />                                            
                                                <asp:BoundField DataField="username" HeaderText="Username" />
                                                <asp:BoundField DataField="password" HeaderText="Password" />                                       
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Button ID="test" runat="server" ControlStyle-CssClass="fkk btn btn-danger " ButtonType="Button" Text="Delete" CommandName="buttonfieldid" OnClientClick="Confirm(this.id)" CommandArgument='<%# Container.DataItemIndex %>' CausesValidation="false" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>                                    
                                        </asp:GridView>
                                    </div>
                                </div>                               
                                <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                                    <div class="vertical-alignment-helper">
                                        <div class="modal-dialog vertical-align-center">
                                            <div class="modal-content">
                                                <div class="modal-header">
                                                    <button type="button" class="close" data-dismiss="modal">
                                                        <span aria-hidden="true">&times;</span><span class="sr-only">Close</span>
                                                    </button>
                                                    <h4 class="modal-title" id="myModalLabel">Details</h4>
                                                </div>
                                                <div class="modal-body">
                                                    <asp:GridView ID="gdv" runat="server" AutoGenerateColumns="false" class="table table-responsive table-bordered table-striped" Style="width: 97%; margin-left: 25px">
                                                        <Columns>
                                                            <asp:BoundField DataField="doc" HeaderText="Document Name" />
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <a href='<%# Eval("path") %>' target="_blank">View</a>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </div>
                                                <div class="modal-footer">
                                                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>                                                    
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
                </div>
        </div>
    </div>
    <script>

        





        //==========IMPORTANT===================
        function Confirm(id) {
            //var msg
            var confirm_value = document.createElement("INPUT");
            if (document.getElementById(id).value == "Delete") {
                msg = "are you sure you want delete ?"
            }
            else {
                msg = "Are you sure you want recover ?"
            }
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm(msg)) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }


        function singleQuote(event) {
            var value = String.fromCharCode(event.which);
            var pattern = new RegExp(/^[A-Za-z\/\s\']+$/);
            return pattern.test(value);
        }

        //function recover_function() 
        //{
        //    if (confirm("are you sure you want to recover the employee's data ?") == true)
        //    {
        //        recover
        //    }

        //}


    </script>
</asp:Content>

