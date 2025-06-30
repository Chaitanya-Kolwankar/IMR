<%@ Page Title="" Language="C#" MasterPageFile="~/Portals/Staff/MasterPage.master" AutoEventWireup="true" CodeFile="ViewProfile.aspx.cs" Inherits="ViewProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .label {
            font-weight: 600;
            color: rgba(1, 41, 112, 0.6);
        }

        .pascal {
            text-transform: capitalize;
        }
    </style>
     <script src="/assets/notify-master/js/notify.js"></script>
    <link href="/assets/notify-master/css/notify.css" rel="stylesheet" />
    <script>

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">



    <!-- Modal -->
    <div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <%-- <h5 class="modal-title" id="exampleModalLabel">Modal title</h5>--%>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">

                    <div class="row text-center">
                        <div class="col-6">
                            <div class="card">
                                <div class=" card-body">
                                    <asp:Image runat="server" ID="photo"  Height="150px" Width="200px" Style="" ImageUrl="~/Assets/img/user.png"  />


                                </div>


                                <asp:FileUpload runat="server"  onchange="ShowImagePreview(this);" ID="photoUpload" accept=".png,.jpg,.jpeg,.gif" style="margin-bottom: 64px;"/>
                              <%--  <asp:RegularExpressionValidator runat="server" ControlToValidate="photoUpload" class="mt-3" ID="photoValid" ErrorMessage="only jpg,jpeg and png are allowed" ValidationExpression="^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))+(.jpg|.jpeg|.png)$"></asp:RegularExpressionValidator>--%>
                              <%--  <asp:RegularExpressionValidator ID="regexValidator" runat="server"
     ControlToValidate="photoUpload"
     ErrorMessage="Only JPEG images are allowed" ForeColor="Red"
     ValidationExpression="(.*\.([Jj][Pp][Gg])|.*\.([Jj][Pp][Ee][Gg])$)">
</asp:RegularExpressionValidator>
                       --%>
                                <asp:Label Text=""  runat="server" ID="txt1" />

                            </div>

                        </div>
                        <div class="col-6">
                            <div class="card">
                                <div class="card-body  ">
                                    <asp:Image runat="server"  ID="Sign" Height="150px" Width="200px" Style=""   ImageUrl="~/Assets/img/sign.jpg"/>

                                </div>


                                <asp:FileUpload runat="server" onchange="ShowImagePreview1(this);" ID="signUpload" />
                                <asp:RegularExpressionValidator runat="server" ControlToValidate="signUpload" class="mt-3" ID="RegularExpressionValidator1" ErrorMessage="only jpg,jpeg and png are allowed" ValidationExpression="^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))+(.jpg|.jpeg|.png)$"></asp:RegularExpressionValidator>
                                <asp:Label Text="" runat="server" ID="txt2" />
                            </div>

                        </div>

                    </div>


                </div>
                <div class="modal-footer">
                    <%-- <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>--%>

                    <asp:Button Text="Save" ID="save" Enabled="true" class="btn btn-primary" OnClick="Unnamed_Click" runat="server" />
                </div>
            </div>
        </div>
    </div>



    <div id="main" class="main">
        <div class="container-fluid">
            <div class="pagetitle " style="font-size: 32px; margin-left: 34px; font-weight: 300; color: #012970;">
                View Profile
            </div>
            <div class="container-fluid">

                <section class="section">

                    <div class="row">
                        <div class="col-lg-4">
                            <div class="card"  style="height: 492px;">
                                <div class="card-body profile-card pt-4 d-flex flex-column align-items-center">

                                    <div class="d-flex mt-5">
                                        <div class="">
                                            <div class="d-flex " style="justify-content:center">
                                                <asp:Image ID="profileImage" runat="server" class=" rounded-circle" Style="width: 200px; height: 180px"   ImageUrl="~/user.png"/>

                                                <asp:LinkButton runat="server" ID="btnUpload" data-bs-toggle="modal" data-bs-target="#exampleModal">
                                                <img src="https://img.icons8.com/windows/25/000000/edit--v1.png"/> 

                                                </asp:LinkButton>
                                            </div>
                                            <div class="mt-4">
                                                <asp:Image ID="signImage" runat="server" class="rounded" Style="width: 200px; height: 60px"  ImageUrl="~/sign.jpg" />
                                            </div>
                                        </div>

                                        <div>
                                        </div>
                                    </div>
                                    <asp:FileUpload runat="server" ClientIDMode="Static" ID="picUpload" Style="display: none" />
                                    

                                    <h4>
                                        <asp:Label runat="server" ID="fullname" Style="text-transform: capitalize"></asp:Label>
                                    </h4>
                                    <asp:Label runat="server" ID="Lbldesignation" class="pascal"></asp:Label>
                                    <div class="social-links mt-2">
                                        <a href="#" class="twitter"><i class="bi bi-twitter"></i></a>
                                        <a href="#" class="facebook"><i class="bi bi-facebook"></i></a>
                                        <a href="#" class="instagram"><i class="bi bi-instagram"></i></a>
                                        <a href="#" class="linkedin"><i class="bi bi-linkedin"></i></a>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-8">
                            <div class="card">
                                <div class="card-body">
                                    <div class="container-fluid">
                                        <h5 class="card-title">Basic Details
                                        </h5>
                                    </div>
                                    <div class="container-fluid">
                                        <div class="row">
                                            <div class="col-lg-3 col-md-4 col-sm-6 col-xs-6  label  ">Full Name</div>
                                            <asp:Label runat="server" class="col-lg-9 col-sm-6 col-md-8 col-xs-6 pascal" ID="fname"></asp:Label>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-3 col-md-4 label ">Date Of Birth</div>
                                            <asp:Label runat="server" class="col-lg-9 col-md-8" ID="dob"></asp:Label>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-3 col-md-4 label ">Gender</div>
                                            <asp:Label runat="server" class="col-lg-9 col-md-8" ID="lblgen"></asp:Label>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-3 col-md-4 label ">Martial Status</div>
                                            <asp:Label runat="server" class="col-lg-9 col-md-8" ID="lblmartial"></asp:Label>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-3 col-md-4 label ">Address</div>
                                            <asp:Label runat="server" class="col-lg-9 col-md-8 pascal" ID="address"></asp:Label>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="container-fluid">
                                        <h5 class="card-title">Other Details                                  
                                        </h5>
                                    </div>
                                    <div class="container-fluid">
                                        <div class="row">
                                            <div class="col-lg-3 col-md-4 label ">Date of Joining</div>
                                            <asp:Label runat="server" class="col-lg-9 col-md-8" ID="doj"></asp:Label>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-3 col-md-4 label ">Category</div>
                                            <asp:Label runat="server" class="col-lg-9 col-md-8 pascal" ID="category"></asp:Label>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-3 col-md-4">
                                                <asp:Label runat="server" ID="caste1" class="label">Caste</asp:Label>
                                            </div>
                                            <asp:Label runat="server" class="col-lg-9 col-md-8 pascal " ID="caste"></asp:Label>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-3 col-md-4 label ">Mobile No</div>
                                            <asp:Label runat="server" class="col-lg-9 col-md-8" ID="mobileno"></asp:Label>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-3 col-md-4 label ">Email ID</div>
                                            <asp:Label runat="server" class="col-lg-9 col-md-8 pascal" ID="email"></asp:Label>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-3 col-md-4 label ">Blood Group</div>
                                            <asp:Label runat="server" class="col-lg-9 col-md-8" ID="bloodgroup"></asp:Label>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-3 col-md-4" runat="server" id="divId">
                                                <asp:Label ID="lbldept" runat="server" class="label">Department</asp:Label>
                                            </div>
                                            <asp:Label runat="server" class="col-lg-9 col-md-8 pascal" ID="department"></asp:Label>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-3 col-md-4" runat="server">
                                                <asp:Label runat="server" ID="Lbldes" Class="label">Designation</asp:Label>
                                            </div>
                                            <asp:Label runat="server" class="col-lg-9 col-md-8 pascal" ID="designation"></asp:Label>
                                        </div>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>

                    <%--<div class="row">

                        <div class="col-lg-12" style="justify-items: anchor-center;">                        <div class="col-lg-4">
                            <div class="card">
                                <div class="card-body profile-card pt-4 d-flex flex-column align-items-center">

                                    <div class="d-flex mt-5">
                                        <div class="">
                                            <div class="d-flex justify-content-center">
                                                <asp:Image ID="profileImage" runat="server" class=" rounded-circle" Style="width: 200px;height: 150px;"   ImageUrl="~/user.png"/>

                                                <asp:LinkButton runat="server" ID="btnUpload" data-bs-toggle="modal" data-bs-target="#exampleModal">
                                                <img src="https://img.icons8.com/windows/25/000000/edit--v1.png"/> 

                                                </asp:LinkButton>
                                            </div>
                                            <div class="mt-4">
                                                <asp:Image ID="signImage" runat="server" class="rounded" Style="width: 225px; height: 60px"  ImageUrl="~/sign.jpg" />
                                            </div>
                                        </div>

                                        <div>
                                        </div>
                                    </div>
                                    <asp:FileUpload runat="server" ClientIDMode="Static" ID="picUpload" Style="display: none" />
                                    

                                    <h4>
                                        <asp:Label runat="server" ID="fullname" Style="text-transform: capitalize"></asp:Label>
                                    </h4>
                                    <asp:Label runat="server" ID="Lbldesignation" class="pascal"></asp:Label>
                                    <div class="social-links mt-2">
                                        <a href="#" class="twitter"><i class="bi bi-twitter"></i></a>
                                        <a href="#" class="facebook"><i class="bi bi-facebook"></i></a>
                                        <a href="#" class="instagram"><i class="bi bi-instagram"></i></a>
                                        <a href="#" class="linkedin"><i class="bi bi-linkedin"></i></a>
                                    </div>
                                </div>
                            </div>
                        </div>
                            <div class="col-lg-8">
                            <div class="card">
                                <div class="card-body">
                                    <div class="container-fluid">
                                        <h5 class="card-title">Basic Details
                                        </h5>
                                    </div>
                                    <div class="container-fluid">
                                        <div class="row">
                                            <div class="col-lg-3 col-md-4 col-sm-6 col-xs-6  label  ">Full Name</div>
                                            <asp:Label runat="server" class="col-lg-9 col-sm-6 col-md-8 col-xs-6 pascal" ID="fname"></asp:Label>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-3 col-md-4 label ">Date Of Birth</div>
                                            <asp:Label runat="server" class="col-lg-9 col-md-8" ID="dob"></asp:Label>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-3 col-md-4 label ">Gender</div>
                                            <asp:Label runat="server" class="col-lg-9 col-md-8" ID="lblgen"></asp:Label>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-3 col-md-4 label ">Martial Status</div>
                                            <asp:Label runat="server" class="col-lg-9 col-md-8" ID="lblmartial"></asp:Label>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-3 col-md-4 label ">Address</div>
                                            <asp:Label runat="server" class="col-lg-9 col-md-8 pascal" ID="address"></asp:Label>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="container-fluid">
                                        <h5 class="card-title">Other Details                                  
                                        </h5>
                                    </div>
                                    <div class="container-fluid">
                                        <div class="row">
                                            <div class="col-lg-3 col-md-4 label ">Date of Joining</div>
                                            <asp:Label runat="server" class="col-lg-9 col-md-8" ID="doj"></asp:Label>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-3 col-md-4 label ">Category</div>
                                            <asp:Label runat="server" class="col-lg-9 col-md-8 pascal" ID="category"></asp:Label>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-3 col-md-4">
                                                <asp:Label runat="server" ID="caste1" class="label">Caste</asp:Label>
                                            </div>
                                            <asp:Label runat="server" class="col-lg-9 col-md-8 pascal " ID="caste"></asp:Label>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-3 col-md-4 label ">Mobile No</div>
                                            <asp:Label runat="server" class="col-lg-9 col-md-8" ID="mobileno"></asp:Label>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-3 col-md-4 label ">Email ID</div>
                                            <asp:Label runat="server" class="col-lg-9 col-md-8 pascal" ID="email"></asp:Label>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-3 col-md-4 label ">Blood Group</div>
                                            <asp:Label runat="server" class="col-lg-9 col-md-8" ID="bloodgroup"></asp:Label>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-3 col-md-4" runat="server" id="divId">
                                                <asp:Label ID="lbldept" runat="server" class="label">Department</asp:Label>
                                            </div>
                                            <asp:Label runat="server" class="col-lg-9 col-md-8 pascal" ID="department"></asp:Label>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-3 col-md-4" runat="server">
                                                <asp:Label runat="server" ID="Lbldes" Class="label">Designation</asp:Label>
                                            </div>
                                            <asp:Label runat="server" class="col-lg-9 col-md-8 pascal" ID="designation"></asp:Label>
                                        </div>
                                    </div>
                                </div>

                            </div>
                                </div>
                        </div>
                    </div>--%>
                </section>
            </div>
        </div>
    </div>


    <script>


        function ShowImagePreview(input) {                                                  // to show image before saving
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#<%=photo.ClientID%>').prop('src', e.target.result)
                        .width(200)
                        .height(150);
                };
                reader.readAsDataURL(input.files[0]);
                }
            }
            function ShowImagePreview1(input) {                                                 // to show image before saving
                if (input.files && input.files[0]) {
                    var reader = new FileReader();
                    reader.onload = function (e) {
                        $('#<%=Sign.ClientID%>').prop('src', e.target.result)
                        .width(200)
                        .height(150);
                    };
                    reader.readAsDataURL(input.files[0]);
                    }
            }
        function notify(msg, type) {
            $.notify(msg, { type: type, animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.2, delay: 0 });
        }
                //$(document).ready(function () {
                //    alert("js is working");
                //});



                //function setValidation1() {

                //    var maxFileSize = 200000;
                //    var fileUpload = $('#signUpload');

                //    if (fileUpload.val() == '') {
                //        return false;
                //    }
                //    else {
                //        if (fileUpload[0].files[0].size < maxFileSize) {

                //            $('#save').prop('disabled', false);
                //            $('#Label1').text("");

                //            return true;

                //        }
                //        else {
                //            alert("file size is too big");
                //            $('#Label1').text("please select image less than 100kb size");
                //            $('#save').prop('disabled', true);
                //            return false;
                //        }
                //    }
                //}

                //function openfileDialog() {
                //  $("#picUpload").click();

                //}
                //function uploadImage() {
                //$('#ContentPlaceHolder1_btnUpload').click()

                //}
                //$("#picUpload").on('change', function () {

                //    console.log('new file uploaded')

                //});
    </script>

</asp:Content>

