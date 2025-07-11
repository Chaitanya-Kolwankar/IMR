<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta charset="utf-8" />
    <meta content="width=device-width, initial-scale=1.0" name="viewport" />

    <title>IMR College</title>
    <meta content="" name="description" />
    <meta content="" name="keywords" />

    <!-- Favicons -->
    <link href="<%= ResolveUrl("~/Assets/img/vivalogo.png") %>" rel="icon" />
    <link href="<%= ResolveUrl("~/Assets/img/vivalogo.png") %>" rel="apple-touch-icon" />

    <!-- Google Fonts -->
    <link href="https://fonts.gstatic.com" rel="preconnect" />
    <link href="https://fonts.googleapis.com/css?family=Open+Sans:300,300i,400,400i,600,600i,700,700i|Nunito:300,300i,400,400i,600,600i,700,700i|Poppins:300,300i,400,400i,500,500i,600,600i,700,700i" rel="stylesheet" />

    <%--Jquery--%>
    <script src="<%= ResolveUrl("~/Assets/notify-master/js/jquery-1.11.0.js") %>"></script>

    <!-- Vendor CSS Files -->
    <link href="<%= ResolveUrl("~/Assets/vendor/bootstrap/css/bootstrap.min.css") %>" rel="stylesheet" />
    <link href="<%= ResolveUrl("~/Assets/vendor/bootstrap-icons/bootstrap-icons.css") %>" rel="stylesheet" />
    <link href="<%= ResolveUrl("~/Assets/vendor/boxicons/css/boxicons.min.css") %>" rel="stylesheet" />
    <link href="<%= ResolveUrl("~/Assets/vendor/quill/quill.snow.css") %>" rel="stylesheet" />
    <link href="<%= ResolveUrl("~/Assets/vendor/quill/quill.bubble.css") %>" rel="stylesheet" />
    <link href="<%= ResolveUrl("~/Assets/vendor/remixicon/remixicon.css") %>" rel="stylesheet" />
    <link href="<%= ResolveUrl("~/Assets/vendor/simple-datatables/style.css") %>" rel="stylesheet" />


    <!-- Template Main CSS File -->
    <link href="<%= ResolveUrl("~/Assets/css/style.css") %>" rel="stylesheet" />


    <!-- datepicker -->
    <script src="<%= ResolveUrl("~/Assets/js/jquery.datetimepicker.js") %>"></script>
    <link href="<%= ResolveUrl("~/Assets/css/jquery.datetimepicker.css") %>" rel="stylesheet" />
    <%--<script src="../../Assets/js/datepicker/daterangepicker.js"></script>--%>




    <!-- Notify -->
    <link href="<%= ResolveUrl("~/Assets/notify-master/css/notify.css") %>" rel="stylesheet" />
    <script src="<%= ResolveUrl("~/Assets/notify-master/js/notify.js") %>"></script>


    <!-- =======================================================
  * Template Name: NiceAdmin - v2.2.2
  * Template URL: https://bootstrapmade.com/nice-admin-bootstrap-admin-html-template/
  * Author: BootstrapMade.com
  * License: https://bootstrapmade.com/license/
  ======================================================== -->


    <%--font links --%>
    <link rel="preconnect" href="https://fonts.googleapis.com"/>
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin=""/>
    <link href="https://fonts.googleapis.com/css2?family=Archivo&family=Baloo+Bhai+2&family=Cabin&family=Roboto+Slab&display=swap" rel="stylesheet"/>
    <%--font links--%>

    <%--Datatable --%>
    <link href="<%= ResolveUrl("~/Assets/datatable/DataTable.css") %>" rel="stylesheet" />
    <script src="<%= ResolveUrl("~/Assets/datatable/DataTable.js") %>"></script>
    <%--Datatable --%>

    <style>
     body {

         background-image:url("../../assets/img/bckimgimr.jpg ");
           background-repeat: no-repeat;
           background-size:cover;
            /*background:rgba(0,0,0,0.7)*/
  
  
     }
   

 </style> 
</head>
<body>

  
    <div class="container">

      <section class="section register min-vh-100 d-flex flex-column align-items-center justify-content-center py-1">
          

        <div class="container">
          <div class="row justify-content-center">
            <div class="col-lg-4 col-md-6 d-flex flex-column align-items-center justify-content-center" style="background-color:white;border-radius:10px">
                <div class="d-flex justify-content-center">
                    
                  <span class="d-none d-lg-block">
                      <br />
                      <img src="../../assets/img/mu.png" alt="" style="max-height:100PX !IMPORTANT ;"/></span>
               
                
              </div><!-- End Logo -->
              <div class="d-flex justify-content-center">
                  <%--<span class="d-none d-lg-block"><img src="assets/img/logo.jpg" alt="" style="max-height:50PX !IMPORTANT"/></span>--%>
                <a href="#" class="logo d-flex align-items-center w-auto">
                  
                  <span class="d-none d-lg-block">College IMR </span>
                </a>
              </div><!-- End Logo -->

              <%--<div class="card mb-3">--%>

                <div class="card-body">

                  <div class="">
                    <h5 class="card-title text-center pb-0 fs-4">Login to Your Account</h5>
                    
                  </div>
                    <%--<p class="text-center small">Enter your username & password to login</p>--%>

                  <form id="Form1" runat="server" class="row g-3 needs-validation" novalidate>

                    <div class="col-12">
                      <label for="yourUsername" class="form-label">Username</label>
                      <div class="input-group has-validation">
                        <%--<span class="input-group-text" id="inputGroupPrepend">@</span>--%>
                        <asp:TextBox runat="server" type="text" name="username" MaxLength="8" autocomplete="off" class="form-control" id="txtUserName" style="text-transform:uppercase;" onkeyPress="return alphaandnum(event)" required   oncopy="return false" 
                                                                oncut="return false"/>
                        <div class="invalid-feedback">Please enter your username.</div>
                      </div>
                    </div>

                    <div class="col-12">
                      <label for="yourPassword" class="form-label">Password</label>
                      <asp:TextBox runat="server" MaxLength="20" type="password" name="password" class="form-control" id="txtPassword" oncopy="return false" oncut="return paste" required/>
                      <div class="invalid-feedback">Please enter your password!</div>
                    </div>
                        <div class="col-12">
                <asp:Label id="lblerror" ForeColor="Red" Visible="false" runat="server"></asp:Label>
              </div>

                  <%--  <div class="col-12">
                      <div class="form-check">
                        <input class="form-check-input" type="checkbox" name="remember" value="true" id="rememberMe">
                        <label class="form-check-label" for="rememberMe">Remember me</label>
                      </div>
                    </div>--%>
                    <div class="col-12">
                      <asp:Button runat="server" ID="btnLogin" class="btn btn-primary w-100"  OnClick="btnLogin_Click"   Text="Submit"/>
                    </div>
                        <div class="credits container" style="text-align:center;">
                <!-- All the links in the footer should remain intact. -->
                <!-- You can delete the links only if you purchased the pro version. -->
                <!-- Licensing information: https://bootstrapmade.com/license/ -->
                <!-- Purchase the pro version with working PHP/AJAX contact form: https://bootstrapmade.com/nice-admin-bootstrap-admin-html-template/ -->
                
              </div>
                   <%-- <div class="col-12">
                      <p class="small mb-0">Don't have account? <a href="pages-register.html">Create an account</a></p>
                    </div>--%>
                  </form>

                </div>
              </div>

            

            </div>
          </div>
        
    
      </section>

    </div>
  

  <a href="#" class="back-to-top d-flex align-items-center justify-content-center"><i class="bi bi-arrow-up-short"></i></a>

   <!-- Vendor JS Files -->
    <script src="<%= ResolveUrl("~/Assets/vendor/apexcharts/apexcharts.min.js") %>"></script>
    <script src="<%= ResolveUrl("~/Assets/vendor/bootstrap/js/bootstrap.bundle.min.js") %>"></script>
    <script src="<%= ResolveUrl("~/Assets/vendor/chart.js/chart.min.js") %>"></script>
    <script src="<%= ResolveUrl("~/Assets/vendor/echarts/echarts.min.js") %>"></script>
    <script src="<%= ResolveUrl("~/Assets/vendor/quill/quill.min.js") %>"></script>
    <script src="<%= ResolveUrl("~/Assets/vendor/simple-datatables/simple-datatables.js") %>"></script>
    <script src="<%= ResolveUrl("~/Assets/vendor/tinymce/tinymce.min.js") %>"></script>
    <script src="<%= ResolveUrl("~/Assets/vendor/php-email-form/validate.js") %>"></script>

    <!-- Template Main JS File -->
    <script src="<%= ResolveUrl("~/Assets/js/main.js") %>"></script>

</body>

    <script>
        function alphaandnum(event) {
            var val = String.fromCharCode(event.which);
            var pattern = new RegExp(/^[A-Za-z0-9\s]+$/);
            return pattern.test(val);
        }
    </script>
</html>
