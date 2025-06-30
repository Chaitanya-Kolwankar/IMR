<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">

    <meta charset="utf-8" />
    <meta content="width=device-width, initial-scale=1.0" name="viewport" />

    <title>IMR STAFF PORTAL</title>
    <meta content="" name="description" />
    <meta content="" name="keywords" />

    <!-- Favicons -->
    <link href="../assets/img/logo.jpg" rel="icon" />
    <link href="../assets/img/logo.jpg" rel="apple-touch-icon" />

    <!-- Google Fonts -->
    <link href="https://fonts.gstatic.com" rel="preconnect" />
    <link href="https://fonts.googleapis.com/css?family=Open+Sans:300,300i,400,400i,600,600i,700,700i|Nunito:300,300i,400,400i,600,600i,700,700i|Poppins:300,300i,400,400i,500,500i,600,600i,700,700i" rel="stylesheet" />

    <!-- Vendor CSS Files -->
    <link href="../../assets/vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../../assets/vendor/bootstrap-icons/bootstrap-icons.css" rel="stylesheet" />
    <link href="../../assets/vendor/boxicons/css/boxicons.min.css" rel="stylesheet" />
    <link href="../../assets/vendor/quill/quill.snow.css" rel="stylesheet" />
    <link href="../../assets/vendor/quill/quill.bubble.css" rel="stylesheet" />
    <link href="../../assets/vendor/remixicon/remixicon.css" rel="stylesheet" />
    <link href="../../assets/vendor/simple-datatables/style.css" rel="stylesheet" />

    <!-- Template Main CSS File -->
    <link href="../../assets/css/style.css" rel="stylesheet" />
   
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
                      <asp:TextBox runat="server" MaxLength="20" type="password" name="password" class="form-control" id="txtPassword" oncopy="return false" oncut="return paste"   required/>
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
  <script src="../../assets/vendor/apexcharts/apexcharts.min.js"></script>
  <script src="../../assets/vendor/bootstrap/js/bootstrap.bundle.min.js"></script>
  <script src="../../assets/vendor/chart.js/chart.min.js"></script>
  <script src="../../assets/vendor/echarts/echarts.min.js"></script>
  <script src="../../assets/vendor/quill/quill.min.js"></script>
  <script src="../../assets/vendor/simple-datatables/simple-datatables.js"></script>
  <script src="../../assets/vendor/tinymce/tinymce.min.js"></script>
  <script src="../../assets/vendor/php-email-form/validate.js"></script>
                 
  <!-- Template Main JS File -->
  <script src="../../assets/js/main.js"></script>

</body>

    <script>
        function alphaandnum(event) {
            var val = String.fromCharCode(event.which);
            var pattern = new RegExp(/^[A-Za-z0-9\s]+$/);
            return pattern.test(val);
        }
    </script>
</html>
