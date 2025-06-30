<%@ Page Title="" Language="C#" MasterPageFile="~/Portals/Staff/MasterPage.master" AutoEventWireup="true" CodeFile="EditProfile.aspx.cs" Inherits="EditProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="../../../Assets/js/jquery.datetimepicker.js"></script>
    <link href="../../Assets/css/jquery.datetimepicker.css" rel="stylesheet" />
    <style>
        input {
            text-transform: uppercase;
        }
        .redcolor {
        color:red;
        }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main" class="main">
        <div class="container-fluid">
           
            <div class="pagetitle " style="font-size: 32px; margin-left: 34px; font-weight: 300; color: #012970;">
                Edit Profile
            </div>
            <div class="container-fluid">
            
                        <div class="row">
                            <div class="col-lg-6">
                                <div class="card">
                                    <div class="card-title mx-4">Basic Details</div>
                                    <div class="card-body">

                                        <div class="container">
                                            <div class="row">
                                                <div class="col-lg-3 col-md-3 col-sm-12">
                                                    <label for="inputState" class="form-label">Title</label>
                                                    <asp:DropDownList ID="txt_title" class="form-select" runat="server">
                                                        <asp:ListItem Value="">--Select--</asp:ListItem>
                                                        <asp:ListItem>Mr.</asp:ListItem>
                                                        <asp:ListItem>Mrs.</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="col-lg-3 col-md-3 col-sm-12">
                                                    <label for="inputState" class="form-label">Last Name </label>
                                                    <asp:TextBox runat="server" MaxLength="20" onkeyPress="return singleQuote(event)" CssClass="form-control input" ID="txt_LName" oncopy="return false"
onpaste="return false"
oncut="return false"  ></asp:TextBox>
                                                </div>
                                                <div class="col-lg-3 col-md-3 col-sm-12">
                                                    <label for="inputState" class="form-label">First Name <span class="redcolor" >*</span></label>
                                                    <asp:TextBox runat="server" MaxLength="20" onkeyPress="return singleQuote(event)" ID="txt_FName" CssClass="form-control input"  oncopy="return false"
onpaste="return false"
oncut="return false"></asp:TextBox>
                                                </div>
                                                <div class="col-lg-3 col-md-3 col-sm-12">
                                                    <label for="inputState" class="form-label">Middle Name <span class="redcolor" >*</span></label>
                                                    <asp:TextBox runat="server" MaxLength="20" onkeyPress="return singleQuote(event)" ID="txt_MName" CssClass="form-control input"  oncopy="return false"
onpaste="return false"
oncut="return false"></asp:TextBox>
                                                </div>
                                                <br />
                                                <div class="col-lg-3 col-md-3 col-sm-12 my-4">
                                                    <label for="inputState" class="form-label">Mother Name <span class="redcolor" >*</span></label>
                                                    <asp:TextBox runat="server" MaxLength="20" ID="txt_MotherName" onkeyPress="return singleQuote(event)" CssClass="form-control input"  oncopy="return false"
onpaste="return false"
oncut="return false"></asp:TextBox>
                                                </div>
                                                <div class="col-lg-3 col-md-3 col-sm-12 my-4">
                                                    
                                                            <label for="inputState" class="form-label">D.O.B <span class="redcolor" >*</span></label>
                                                    <asp:UpdatePanel ID="basbj" runat="server" >
                                                        <ContentTemplate>

                                                            <asp:TextBox runat="server" ID="txt_dob" CssClass="form-control" ReadOnly="true"  oncopy="return false"
onpaste="return false"
oncut="return false" ><input disabled="disabled" class="datepicker" /> </asp:TextBox>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>


                                                </div>
                                                <div class="col-lg-6 col-md-6 col-sm-12 my-4">
                                                    <label for="inputState" class="form-label">
                                                        Email ID:
                                                    </label>
                                                    <asp:TextBox runat="server" ID="txt_email" TextMode="Email" MaxLength="99" CssClass="form-control" style="text-transform:lowercase"  oncopy="return false"
onpaste="return false"
oncut="return false"></asp:TextBox>
                                                </div>
                                                <div class="col-lg-6 col-md-6 col-sm-6">
                                                    <label for="inputState" class="form-label">Gender<span class="redcolor" >*</span></label>
                                                    <asp:RadioButtonList ID="rad_gender" runat="server" CssClass="form-control" RepeatDirection="Horizontal">
                                                        <asp:ListItem Text="Male" Value="1" />
                                                        <asp:ListItem Text="Female" Value="0" />
                                                    </asp:RadioButtonList>
                                                </div>
                                                <div class="col-lg-6 col-md-6 col-sm-6">
                                                    <label for="inputState" class="form-label">Marital Status</label>
                                                    <asp:RadioButtonList ID="rad_marital" runat="server" CssClass="form-control" RepeatDirection="Horizontal">
                                                        <asp:ListItem Text="Married" Value="1" />
                                                        <asp:ListItem Text="Unmarried" Value="0" />
                                                    </asp:RadioButtonList>
                                                </div>
                                            </div>
                                        </div>


                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-6">
                                <div class="card">
                                    <div class="card-title mx-4">Other Details</div>
                                    <div class="card-body">

                                        <div class="container">
                                            <div class="row">
                                                <div class="col-lg-3 col-md-2 col-sm-6">
                                                    <label for="inputState" class="form-label">D.O.J <span class="redcolor" >*</span></label>
                                                    <asp:UpdatePanel runat="server"  >
                                                        <ContentTemplate>
                                                            
                                                            <asp:TextBox runat="server" ID="txt_doj" CssClass="form-control"  oncopy="return false"
onpaste="return false"
oncut="return false" ReadOnly="true" ></asp:TextBox>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>



                                                </div>
                                                <div class="col-lg-3 col-md-2 col-sm-6">
                                                    <label for="inputState" class="form-label">Mobile No1 <span class="redcolor" >*</span></label>
                                                    <asp:TextBox runat="server" ID="txt_mobile2" MaxLength="10" onKeyPress="return OnlyNum1(event)"  oncopy="return false"
onpaste="return false"
oncut="return false" CssClass="form-control"></asp:TextBox>

                                                    <asp:RegularExpressionValidator ID="regmob" runat="server" ControlToValidate="txt_mobile2" Display="Dynamic" ForeColor="Red" ErrorMessage="Invalid Mobile no." ValidationExpression=".{10}.*"></asp:RegularExpressionValidator>
                                                </div>
                                                <div class="col-lg-3 col-md-2 col-sm-6">
                                                    <label for="inputState" class="form-label">Mobile No2</label>
                                                    <asp:TextBox runat="server" ID="txt_mobile1" MaxLength="10" onKeyPress="return OnlyNum1(event)" CssClass="form-control"  oncopy="return false"
onpaste="return false"
oncut="return false"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="regmob2" runat="server" ControlToValidate="txt_mobile1" Display="Dynamic" ForeColor="Red" ErrorMessage="Invalid Mobile no." ValidationExpression=".{10}.*"></asp:RegularExpressionValidator>
                                                </div>
                                                <div class="col-lg-3 col-md-2 col-sm-6">
                                                    <label for="inputState" class="form-label">Department <span class="redcolor" >*</span></label>
                                                    <asp:DropDownList ID="ddl_department" CssClass="form-select" runat="server" OnSelectedIndexChanged="ddl_department_SelectedIndexChanged">
                                                 
                                                        <asp:ListItem Value="DEP00034">VIVA SOFTWARE SOLUTION</asp:ListItem>
                                                        <asp:ListItem Value="DEP00035">LIBRARY</asp:ListItem>
                                                        <asp:ListItem Value="DEP00036">IMR</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <br />
                                            <div class="row">
                                                <div class="col-lg-4 col-md-2 col-sm-6">
                                                    <label for="inputState" class="form-label">Designation <span class="redcolor" >*</span></label>
                                                    <asp:DropDownList ID="ddl_designation" CssClass="form-select" runat="server">
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="col-lg-4 col-md-2 col-sm-6 ">
                                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server"  >
                                                        <ContentTemplate>
                                                   <%-- <label for="inputState" class="form-label">Category</label>
                                                    <asp:DropDownList ID="ddl_category" CssClass="form-select" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_category_SelectedIndexChanged">
                                                    </asp:DropDownList>--%>
                                                            <label for="inputState" class="form-label">Aadhaar No <span class="redcolor" >*</span></label>
                                                    <asp:TextBox runat="server" ID="txt_aadhar" MaxLength="12" CssClass="form-control onlynum"  oncopy="return false"
onpaste="return false"
oncut="return false" onkeypress="return OnlyNum1(event)"></asp:TextBox>
                                                                                                   <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txt_aadhar" ErrorMessage=" Aadhaar Card No Must Be Of 12 Digit" Display="Dynamic" ValidationExpression=".{12}.*" ForeColor="Red"></asp:RegularExpressionValidator>
                                                            </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                </div>
                                                <div class="col-lg-4 col-md-2 col-sm-6">
                                                    <label for="inputState" class="form-label">PAN No <span class="redcolor" >*</span> </label>
                                                    <asp:TextBox runat="server" ID="txt_pan" MaxLength="10" CssClass="form-control input"  oncopy="return false"
onpaste="return false"
oncut="return false" onkeypress="return pan(event)"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValida" runat="server" ControlToValidate="txt_pan" ErrorMessage="Invalid Pan Card no." Display="Dynamic" ValidationExpression=".{10}.*" ForeColor="Red"></asp:RegularExpressionValidator>
                                                </div>
                                            </div>
                                            <br />
                                            <div class="row">
                                                <div class="col-lg-3 col-md-2 col-sm-6">
                                                    <asp:UpdatePanel ID="upadhar" runat="server">
                                                        <ContentTemplate>
                                                             <label for="inputState" class="form-label">Category</label>
                                                    <asp:DropDownList ID="ddl_category" CssClass="form-select" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_category_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                            
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                    
                                                </div>
                                                <div class="col-lg-3 col-md-2 col-sm-6">
                                                    <label for="inputState" class="form-label">Caste</label>
                                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server"  >
                                                        <ContentTemplate>
                                                    <asp:DropDownList ID="ddl_caste" CssClass="form-select" runat="server">
                                                    </asp:DropDownList>
                                                            </ContentTemplate></asp:UpdatePanel>
                                                </div>
                                                <div class="col-lg-3 col-md-2 col-sm-6 ">
                                                    
                                                    <label for="inputState" class="form-label">Religion</label>
                                                    <asp:DropDownList ID="ddl_religion" CssClass="form-select" runat="server">
                                                    </asp:DropDownList>
                                                   <%-- <label for="inputState" class="form-label">Blood Group</label>
                                                    <asp:DropDownList ID="ddl_bloodg" CssClass="form-select" runat="server">
                                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                        <asp:ListItem Value="1">A+</asp:ListItem>
                                                        <asp:ListItem Value="2">A-</asp:ListItem>
                                                        <asp:ListItem Value="3">B+</asp:ListItem>
                                                        <asp:ListItem Value="4">B-</asp:ListItem>
                                                        <asp:ListItem Value="5">O+</asp:ListItem>
                                                        <asp:ListItem Value="6">O-</asp:ListItem>
                                                        <asp:ListItem Value="7">AB+</asp:ListItem>
                                                        <asp:ListItem Value="8">AB-</asp:ListItem>
                                                    </asp:DropDownList>--%>
                                                </div>
                                                <div class="col-lg-3 col-md-2 col-sm-6">
                                                     <label for="inputState" class="form-label">Blood Group</label>
                                                    <asp:DropDownList ID="ddl_bloodg" CssClass="form-select" runat="server">
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
                                            </div>
                                        </div>



                                    </div>
                                </div>
                            </div>

                        </div>
            </div>
            <div class="container-fluid">
            <div class="row">
                <div class="col-lg-6">
                    <div class="card">
                        <div class="card-title mx-4">Current Address</div>
                        <div class="card-body">

                            <div class="container">
                                <div class="row">
                                    <div class="col-lg-12 col-md-12 col-sm-12">
                                        <label for="inputState" class="form-label">Address<span class="redcolor" >*</span> </label>
                                        <asp:TextBox runat="server" ID="txt_add1" CssClass="form-control" MaxLength="150" AutoPostBack="true"  oncopy="return false"
onpaste="return false"
oncut="return false" onkeypress="return adres(event)"></asp:TextBox>

                                    </div>
                                    <div class="col-lg-4 col-md-4 col-sm-4">
                                        <label for="inputState" class="form-label">State<span class="redcolor" >*</span>  </label>
                                        <asp:DropDownList ID="ddl_state" CssClass="form-select" runat="server">
                                            <asp:ListItem Value="0">--select--</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-lg-4 col-md-4 col-sm-4">
                                        <label for="inputState" class="form-label">City<span class="redcolor" >*</span> </label>
                                        <asp:TextBox runat="server" MaxLength="20" onKeyPress="return alphabet(event)" ID="txt_city" CssClass="form-control"  oncopy="return false"
onpaste="return false"
oncut="return false"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-4 col-md-4 col-sm-4">
                                        <label for="inputState" class="form-label">Pin Code<span class="redcolor" >*</span>   </label>
                                        <asp:TextBox runat="server" ID="txt_pin" MaxLength="6" CssClass="form-control onlynum"  oncopy="return false"
onpaste="return false"
oncut="return false" onkeypress="return OnlyNum1(event)"></asp:TextBox>
                                        <asp:RegularExpressionValidator runat="server" ID="regpin" ControlToValidate="txt_pin" ValidationExpression=".{6}.*" Display="Dynamic" ForeColor="Red" ErrorMessage=" Pincode Must Be Of 6 Digit"></asp:RegularExpressionValidator>
                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
                <div class="col-lg-6">


                    <div class="card">
                        
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" >
                        <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="chk_same" />
                            </Triggers>    
                            <ContentTemplate>
                                
                                <div class="card-title mx-4">
                                    Permanent Address 
                                                     <span style="color: black; margin-left: 20px;">Same As Current Address</span>

                                    <asp:CheckBox ID="chk_same" runat="server" AutoPostBack="true" Text="" OnCheckedChanged="CheckBox2_CheckedChanged" />


                                </div>
                                <div class="card-body">
                                    <div class="container" id="test">

                                        <div class="row">
                                            <div class="col-lg-12 col-md-12 col-sm-12">
                                                <label for="inputState" class="form-label">Address </label>

                                                <asp:TextBox runat="server" ID="txt_padd1" MaxLength="249" CssClass="form-control" onkeypress="return adres(event)"  oncopy="return false"
onpaste="return false"
oncut="return false"></asp:TextBox>
                                            </div>
                                            <div class="col-lg-4 col-md-4 col-sm-4">
                                                <label for="inputState" class="form-label">State</label>

                                                <asp:DropDownList ID="ddl_pstate" CssClass="form-select" runat="server">
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-lg-4 col-md-4 col-sm-4">
                                                <label for="inputState" class="form-label">City</label>

                                                <asp:TextBox runat="server" ID="txt_pcity" MaxLength="20" onKeyPress="return alphabet(event) "  oncopy="return false"
onpaste="return false"
oncut="return false" CssClass="form-control"></asp:TextBox>
                                            </div>
                                            <div class="col-lg-4 col-md-4 col-sm-4">
                                                <label for="inputState" class="form-label">Pin Code</label>

                                                <asp:TextBox runat="server" ID="txt_ppin" MaxLength="6" CssClass="form-control onlynum"  oncopy="return false"
onpaste="return false"
oncut="return false" onkeypress="return OnlyNum1(event)"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="regpermanne" runat="server" ControlToValidate="txt_ppin" ErrorMessage=" Pincode Must Be Of 6 Digit" Display="Dynamic" ValidationExpression=".{6}.*" ForeColor="Red"></asp:RegularExpressionValidator>
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
        </div>
        

        <div class="container">
            <div class="row">

                <div class="col">
                </div>
                <div class="col-lg-6">
                    <asp:updatepanel runat="server">
                        <ContentTemplate>
                    <asp:Button runat="server" ID="txt_submit" CssClass="form-control btn btn-primary" Text="Update" Style="width: 50%; margin-left: 150px" OnClick="submit_Click" />
                            </ContentTemplate>
                        
                    </asp:updatepanel>
                </div>
                <div class="col">
                </div>


            </div>
        </div>
        <br />
        <%--</div>--%>
        <%--    </ContentTemplate>
        </asp:UpdatePanel>--%>
        <%--</div>--%>
    </div>
    <script type="text/javascript">


        //function singleQuote(event) {
        //    var value = String.fromCharCode(event.which);
        //    var pattern = new RegExp(/^[A-Za-z\/\s\']+$/);
        //    return pattern.test(value);
        //}

        function pan(event) {
            var value = String.fromCharCode(event.which);
            var pattern = new RegExp(/^[A-Za-z 0-9]+$/);
            return pattern.test(value);
        }




        function alphabet(event) {
            var value = String.fromCharCode(event.which);
            var pattern = new RegExp(/^[A-Za-z\/\s\']+$/);
            return pattern.test(value);
        }
       
        function singleQuote(event) {
            var value = String.fromCharCode(event.which);
            var pattern = new RegExp(/^[A-Za-z\s\']+$/);
            return pattern.test(value);
        }

        function adres(event) {
            var value = String.fromCharCode(event.which);
            var pattern = new RegExp(/^[A-Za-z 0-9'\.\-\s\,\(\)\/]+$/);
            return pattern.test(value);
        }






        function OnlyNum1(event) {
            var value = String.fromCharCode(event.which);
            var pattern = new RegExp(/[0-9]/i);
            return pattern.test(value);
        }



        $(function () {
            $('.onlynum').keydown(function (e) {
                var key = e.keyCode;
                if ((key >= 65 && key <= 90)) {
                    e.preventDefault();
                }
            });
        });
        //$(document).ready(function () {
        //    jQuery('[id*=txt_dob]').datetimepicker(
        //            {
        //                changeMonth: false,
        //                changeYear: false,
        //                timepicker: false,
        //                format: 'd/m/Y',
        //                viewMode: "months",
        //                minViewMode: "months",
        //                maxDate: 0
        //                //endDate: "+0m"
        //            });
        //});
        //$(document).ready(function () {
        //    jQuery('[id*=txt_doj]').datetimepicker(
        //            {
        //                changeMonth: false,
        //                changeYear: false,
        //                timepicker: false,
        //                format: 'd/m/Y',
        //                viewMode: "months",
        //                minViewMode: "months",
        //                maxDate: 0

      //  ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "func", "datepic()", true);

        //                //endDate: "+0m"
        //            });
        //});
        datepic();
        function datepic() {
            $('[id*=txt_dob]').datetimepicker(
                        {
                            changeMonth: false,
                            changeYear: false,
                            timepicker: false,
                            format: 'd/m/Y',
                            viewMode: "months",
                            minViewMode: "months",
                            //maxDate: 0
                            maxDate :new Date(2004, 0, 1) 
                            //endDate: "+0m"
                        });

            $('[id*=txt_doj]').datetimepicker(
                        {
                            changeMonth: false,
                            changeYear: false,
                            timepicker: false,
                            format: 'd/m/Y',
                            viewMode: "months",
                            minViewMode: "months",
                            maxDate: 0


                            //endDate: "+0m"
                        });


        }
        //$(document).ready(function () {
        //    jQuery('[id*=txt_doj]').datepicker(
        //        {
        //            minDate: -20, maxDate: "+1M +10D"
        //        });
        //});
        function notify(msg, type) {
            $.notify(msg, { type: type, animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.2, delay: 0 });
        }

    </script>
</asp:Content>

