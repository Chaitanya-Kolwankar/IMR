<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="_Default" MasterPageFile="~/Portals/Staff/MasterPage.master" UnobtrusiveValidationMode="none" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="notify-master/js/notify.js"></script>
    <link href="notify-master/css/notify.css" rel="stylesheet" />
    <!DOCTYPE html>
    <html lang="en">
    <head>
        <meta charset="UTF-8" />
        <meta name="viewport" content="width=device-width, initial-scale=1.0" />
        <title>Toggle Password Visibility</title>
        <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.3.0/font/bootstrap-icons.css" />
        <link rel="stylesheet" href="css/style.css" />
    </head>
    </html>
    <style>
        #show_pwd1, #show_pwd2, #show_pwd3 {
            cursor: pointer;
            margin-right: 1px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main" class="main">
        <div class="container-fluid">
            <div class="pagetitle " style="font-size: 32px; margin-left: 34px; font-weight: 300; color: #012970;">
            Update Password
            </div>
        <div class="container-fluid ">
            <%--<div class="card">--%>
                
            
                <%--<asp:UpdatePanel ID="updatepnl" runat="server">
            <ContentTemplate>--%>
                <%--<div class="container-fluid">--%>
                    <div class="row">
                        <div class="col-md-4">
                            <div class="card">
                                <div class="card-title mx-4" style="font-size: 21px">Change Password </div>
                                <div class="card-body">
                                    <div class="container">
                                    <asp:UpdatePanel ID="updatepnl" runat="server">
                                        <ContentTemplate>
                                            Old Password
                                    <div class="input-group has-validation">
                                        <asp:TextBox ID="oldpwd" CssClass="form-control" runat="server" TextMode="Password" onkeypress="return restrictspace(event,this);" oncopy="return false" onpaste="return false" MaxLength="15" CausesValidation="true">   </asp:TextBox>
                                        <span class="input-group-text" id="togglePassword"><i class="bi bi-eye-fill" onclick="toggle();" id="I1"></i></span>
                                        <%--<span><i class="bi bi-eye-slash" onclick="toggle();" id="togglePassword"></i></span>--%>
                                        <br />

                                    </div>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red" ControlToValidate="oldpwd" Font-Size="Smaller" BorderColor="Red" ErrorMessage="Enter Old Password " SetFocusOnError="true"></asp:RequiredFieldValidator>
                                            <br />
                                            New Password
                                    <div class="input-group has-validation">
                                        <asp:TextBox ID="newpwd" CssClass="form-control" runat="server" TextMode="Password" onkeypress="return restrictspace(event,this);" oncopy="return false" onpaste="return false" MaxLength="10"></asp:TextBox>
                                        <span class="input-group-text" id="Span1"><i class="bi bi-eye-fill" onclick="toggle1();" id="togglePassword1"></i></span>
                                        <br />

                                    </div>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" SetFocusOnError="true" ForeColor="red" ErrorMessage="Enter New Password" ControlToValidate="newpwd" Font-Size="Smaller"></asp:RequiredFieldValidator>
                                            <br />
                                            Confirm Password
                                    <div class="input-group has-validation">
                                        <asp:TextBox ID="conpwd" CssClass="form-control" runat="server" TextMode="Password" onkeypress="return restrictspace(event,this);" oncopy="return false" onpaste="return false" MaxLength="10"></asp:TextBox>
                                        <span class="input-group-text" id="Span2"><i class="bi bi-eye-fill" onclick="toggle2();" id="togglePassword2"></i></span>
                                        <br />

                                    </div>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" SetFocusOnError="true" ForeColor="red" ControlToValidate="conpwd" ErrorMessage="Enter Confirm Password" Font-Size="Smaller"></asp:RequiredFieldValidator>
                                            <br />
                                            <asp:Button ID="savebtn" CssClass="form-control btn-primary" Style="color: white; font-size: larger" OnClick="savebtn_Click" runat="server" Text="Update" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                        </div>
                                    <br />
                                </div>
                            </div>
                        </div>

                    </div>
                <%--</div>--%>
                <%--</ContentTemplate>
        </asp:UpdatePanel>--%>
            </div>
        </div></div>
    <%--</div>--%>
    <script type="text/javascript">
        function toggle(x) {
            var togglePassword = document.querySelector("#togglePassword");
            var password = document.querySelector("#ContentPlaceHolder1_oldpwd");
            {
                var type = password.getAttribute("type") === "password" ? "text" : "password";
                password.setAttribute("type", type);
                x.classList.toggle("bi-eye-slash-fill");
            }
        }

        function toggle1(y) {
            var togglePassword1 = document.querySelector("#togglePassword1");
            var password1 = document.querySelector("#ContentPlaceHolder1_newpwd");
            {
                var type1 = password1.getAttribute("type") === "password" ? "text" : "password";
                password1.setAttribute("type", type1);
                y.classList.toggle("bi-eye-slash-fill");
            }
        }

        function toggle2(z) {
            var togglePassword2 = document.querySelector("#togglePassword2");
            var password2 = document.querySelector("#ContentPlaceHolder1_conpwd");
            {
                var type2 = password2.getAttribute("type") === "password" ? "text" : "password";
                password2.setAttribute("type", type2);
                z.classList.toggle("bi-eye-slash-fill");
            }
        }

        function restrictspace(m, n) {
            if (window.event) {
                var spce = window.event.keyCode;
            }
            else if (m) {
                var spce = m.which;
            }
            else { return true; }
            if (spce != 32 && spce != 39)
                return true;
            else {
                return false;
            }
        }
        function notify(msg, type) {
            $.notify(msg, { type: type, animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.2, delay: 0 });
        }
    </script>
</asp:Content>
