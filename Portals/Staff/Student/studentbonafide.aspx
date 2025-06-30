<%@ Page Title="" Language="C#" MasterPageFile="~/Portals/Staff/MasterPage.master" EnableEventValidation="true" AutoEventWireup="true" CodeFile="studentbonafide.aspx.cs" Inherits="Portals_Staff_Student_studentbonafide" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../../../Assets/css/style.css" rel="stylesheet" />
    <link href="../../../Assets/css/jquery.datetimepicker.css" rel="stylesheet" />

    <script src="../../../Assets/js/jquery.datetimepicker.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main" class="main">
        <div class="modal fade" id="alertmodal">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="btn-close" data-bs-dismiss="modal"></button>
                    </div>
                    <div class="modal-body">
                        
                        <div class="container-fluid">
                            <div class="row">
                                 <asp:UpdatePanel runat="server"
><ContentTemplate>
                               <p > Bonafide already generated &nbsp;
                                  <asp:Label runat="server" ID="mdl_srncount" ></asp:Label>   times. Do you want to Continue?"</p>
                                </ContentTemplate></asp:UpdatePanel>
                            </div>
                            <div class="row"><div class="col-lg-2">

                                             </div>
                                <div class="col-lg-4">
                                    <asp:Button runat="server" Text="Yes" ID="btnyes" OnClick="btnyes_Click" CssClass="form-control btn btn-primary" />
                                </div>
                                <div class="col-lg-4">
                                    <asp:Button runat="server" Text="No" ID="btnno" CssClass="form-control btn btn-primary" OnClick="btnno_Click"/>
                                </div> 
                                <div class="col-lg-2">

                                             </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
        <div class="container-fluid">
            <div class="pagetitle" style="font-size: 32px; margin-left: 34px; font-weight: 300; color: #012970;">
                Student

            </div>
            <div class="container-fluid">
                <div class="card">
                    <div class="card-title mx-4">Bonafide</div>
                    <div class="card-body">
                        <div class="container-fluid">

                            <asp:CheckBox ID="chk_srno" runat="server" Text="Search By Sr no. " TextAlign="Left" AutoPostBack="true" OnCheckedChanged="chk_srno_CheckedChanged" />


                            <br />
                            <br />
                            <div class="row">
                                <div class="col-lg-2">
                                    <label for="inputState" class="form-label">Student ID </label>

                                    <asp:TextBox ID="txt_studID" CssClass="form-control" MaxLength="8" autocomplete="off" onkeypress="return num(event)" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-lg-2" id="col_srtxtid" runat="server" style="display: none;">
                                    <label for="inputState" class="form-label">Sr no. </label>
                                    <asp:TextBox ID="txtsrn" onkeypress="return num(event)" autocomplete="off" MaxLength="2" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-lg-1">
                                    <asp:Button ID="btn_getdata" CssClass="btn btn-primary form-control" runat="server" Text="Get Data" OnClick="btn_getdata_Click" Style="margin-top: 31px" />
                                </div>
                                <div class="col-lg-6" id="col_btnprei" runat="server">
                                    <%--<asp:Button runat="server" ID="btn_reprnt" Text="Reprint" CssClass="btn btn-primary" OnClick="btn_reprnt_Click" Style="margin-top: 30px" />--%>
                                </div>
                                <div class="col-lg-1" style="text-align: end">
                                    <asp:Button ID="btn_clear" CssClass="btn btn-primary form-control" runat="server" Text="Clear" OnClick="btn_clear_Click"  />
                                </div>

                            </div>
                            <div class="row">
                            </div>
                            <br />

                            <div class="row" runat="server" id="row_visible">
                                <div class="col-lg-2">
                                    <label for="inputState" class="form-label">Name </label>
                                    <asp:TextBox ID="txtname" autocomplete="off" runat="server" onkeypress="return aplha(event)" oncopy="return false" onpaste="return false" oncut="return false" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-lg-2">
                                    <label for="inputState" class="form-label">Gender</label>
                                    <br />
                                    <div class="form-control" id="gen" runat="server" style="height: 40px;">
                                        <asp:UpdatePanel ID="jdhns" runat="server">
                                            <ContentTemplate>
                                                <asp:RadioButton ID="rad_gender" runat="server" Text="Male" TabIndex="5" AutoPostBack="true" OnCheckedChanged="rad_gender_CheckedChanged" CssClass="" />&nbsp &nbsp
                                                <asp:RadioButton ID="rad_female" runat="server" Text="Female" AutoPostBack="true" OnCheckedChanged="rad_female_CheckedChanged" TabIndex="6" CssClass="" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>

                                    </div>
                                </div>
                                <div class="col-lg-2">
                                    <label for="inputState" class="form-label">Date of Birth</label>
                                    <asp:TextBox ID="dob" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-lg-2">
                                    <label for="inputState" class="form-label">SubCourse</label>
                                    <asp:TextBox ID="txt_subcou" autocomplete="off" runat="server" oncopy="return false" onpaste="return false" oncut="return false" onkeypress="return aplha(event)" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-lg-2">
                                    <label for="inputState" class="form-label">Academic Year</label>
                                    <asp:TextBox ID="txt_ayd" autocomplete="off" runat="server" oncopy="return false" onpaste="return false" oncut="return false" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-lg-2" style="margin-top: 31px">
                                    <asp:Button ID="getbonafide" Text="Get Bonafide" OnClick="getbonafide_Click" runat="server" 
                                        CssClass="btn btn-primary form-control" />
                                </div>
                            </div>
                            <div class="container">
                                <div class="col-lg-4">
                                </div>

                                <div class="col-lg-4">
                                </div>

                            </div>


                        </div>

                    </div>
                </div>
            </div>
        </div>
                </ContentTemplate>
        </asp:UpdatePanel>
    </div>

    <script>
        <%--function Confirm(count_of_sr) {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Bonafide already generated " + count_of_sr+ " times. Do you want to Continue?", )) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
          
            document.forms[0].appendChild(confirm_value);
        }--%>

        function aplha(event) {
            var value = String.fromCharCode(event.which);
            var pattern = new RegExp(/[a-zA-Z ']/i);
            return pattern.test(value);
        }
        function num(event) {
            var value = String.fromCharCode(event.which);
            var pattern = new RegExp(/[0-9]/i);
            return pattern.test(value);
        }

        function address_exp(event) {
            var value = String.fromCharCode(event.which);
            var pattern = new RegExp(/[a-zA-Z0-9 (),./ &'-]/i);
            return pattern.test(value);
        }

        datepic();
        function datepic() {
            $('[id*=]').datetimepicker(
                {
                    changeMonth: false,
                    changeYear: false,
                    timepicker: false,
                    format: 'd/M/Y',


                    //viewMode: "months",
                    //minViewMode: "months",
                    //maxDate: 0
                    //maxDate: new Date(2004, 0, 1)
                    //endDate: "+0m"
                });
        }
        function notify(msg, type) {
            $.notify(msg, { type: type, animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.2, delay: 0 });
        }


    </script>


</asp:Content>

