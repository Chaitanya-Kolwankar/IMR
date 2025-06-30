<%@ Page Title="" Language="C#" MasterPageFile="~/Portals/Staff/MasterPage.master" AutoEventWireup="true" CodeFile="studenttransfercertificate.aspx.cs" Inherits="Portals_Staff_Student_studenttransfercertificate" %>

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

        .FixedHeader {
            position: sticky;
            font-weight: bold;
            top: 0;
        }

        .redcolor {
            color: red;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="main" id="main">
        <div class="modal fade" id="alertmodal">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="btn-close" data-bs-dismiss="modal"></button>
                    </div>
                    <div class="modal-body">

                        <div class="container-fluid">
                            <div class="row">

                                <p>
                                    are you sure to continue for tc?"
                                </p>

                            </div>
                            <div class="row">
                                <div class="col-lg-2">
                                </div>
                                <div class="col-lg-4">
                                    <asp:Button runat="server" Text="Yes" ID="btnyes" OnClick="btnyes_Click" CssClass="form-control btn btn-primary" />
                                </div>
                                <div class="col-lg-4">
                                    <asp:Button runat="server" Text="No" ID="btnno" CssClass="form-control btn btn-primary" />
                                </div>
                                <div class="col-lg-2">
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>

        <!-- Button trigger modal -->
        <%--<button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#staticBackdrop">
  Launch static backdrop modal
</button>--%>

        <!-- Modal -->
        <div class="modal fade" id="staticBackdrop" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
            <div class="modal-dialog modal-lg">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="staticBackdropLabel">College Address</h5>
                        <button type="button" onclick="myFunction()" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body">
                        <div class="container-fluid">
                            <div class="row">
                                <div class="col-lg-3">
                                    College Name
                    <asp:TextBox ID="mdl_txt_colg_name" CssClass="form-control" onkeyPress="return address_exp(event)" MaxLength="30" autocomplete="off" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-lg-3">
                                    College Address
                    <asp:TextBox ID="mdl_txt_col_address" CssClass="form-control" MaxLength="49"  onkeyPress="return address_exp(event)" autocomplete="off" runat="server">
                    </asp:TextBox>
                                </div>
                                <div class="col-lg-3">
                                    College PinCode
                    <asp:TextBox ID="mdl_txt_col_pin" CssClass="form-control" onkeyPress="return num(event)" MaxLength="6" autocomplete="off" runat="server">
                    </asp:TextBox>
                                </div>
                                <div class="col-lg-3" style="margin-top: 22px">
                                    <asp:UpdatePanel runat="server">
                                        <ContentTemplate>


                                            <asp:Button runat="server" ID="modal_btnsearch" OnClick="modal_btnsearch_Click" Text="Search" CssClass="btn btn-primary form-control" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                            <br />
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>


                                    <div class="row">
                                        <asp:GridView runat="server" ID="grdaddress" AutoGenerateColumns="false" OnRowCommand="grdaddress_RowCommand">
                                            <Columns>
                                                <asp:TemplateField HeaderText="College Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="grd_lbl_colg_name" runat="server" Text='<%#Eval("college_name") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="College Address">
                                                    <ItemTemplate>
                                                        <asp:Label ID="grd_lbl_clgaddres" runat="server" Text='<%#Eval("college_add") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="College Pincode">
                                                    <ItemTemplate>
                                                        <asp:Label ID="grd_lbl_colg_Pin" runat="server" Text='<%#Eval("college_pincode") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:ButtonField ButtonType="button" runat="server" Text="Select" ControlStyle-CssClass="btn btn-primary" CommandName="rowselect" HeaderText="Select" />

                                            </Columns>
                                        </asp:GridView>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" onclick="myFunction()" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>

                </div>
            </div>
        </div>
    </div>
        <%-- ------------------------------------- --%>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="card-title mx-4" style="font-size: 21px">Student TransferCertificate </div>
            <div class="card">
                <div class="card-body">
                    <div class="container-fluid">

                        <br />

                        <div class="row">

                            <div class="col-lg-2">
                                <label for="inputState" class="form-label">
                                    Student ID
                                </label>
                                <asp:TextBox runat="server" ID="txtstud_id" CssClass="form-control" autocomplete="off" MaxLength="8" onkeypress="return num(event)"></asp:TextBox>
                            </div>
                            <div class="col-lg-2">
                                <asp:Button runat="server" ID="btnsearch" Text="Search" Style="margin-top: 31px" CssClass="btn btn-primary" OnClick="btnsearch_Click" />
                            </div>
                        </div>
                        <br />

                        <div class="row">
                            <div class="col-lg-2">
                                <label for="inputState" class="form-label">
                                    First Name
                                </label>
                                <asp:TextBox ID="txtstud_fname" runat="server" CssClass="form-control">
                                </asp:TextBox>
                            </div>
                            <div class="col-lg-2">
                                <label for="inputState" class="form-label">
                                    Middle Name
                                </label>
                                <asp:TextBox ID="txt_Mname" runat="server" CssClass="form-control">
                                </asp:TextBox>
                            </div>
                            <div class="col-lg-2">
                                <label for="inputState" class="form-label">
                                    last Name
                                </label>
                                <asp:TextBox ID="txt_LstName" runat="server" CssClass="form-control">
                                </asp:TextBox>
                            </div>
                            <div class="col-lg-2">
                                <label for="inputState" class="form-label">
                                    D.O.B
                                </label>
                                <asp:TextBox ID="TXT_DOB" runat="server" CssClass="form-control">
                                </asp:TextBox>
                            </div>
                            <%--       <div class="col-lg-2">
                                    <label for="inputState" class="form-label">Gender<span style="color: #ff3333; font-weight: 800">*</span></label>
                                    <br />
                                    <div class="form-control" id="gen" runat="server" style="height: 40px;">
                                        <asp:RadioButton ID="rad_gender" runat="server" Text="Male" CssClass="" />&nbsp &nbsp
                                                <asp:RadioButton ID="rad_female" runat="server" Text="Female" TabIndex="6" CssClass="" />
                                    </div>
                                </div>--%>
                            <div class="col-lg-2">
                                <label for="inputState" class="form-label">
                                    Course
                                </label>
                                <asp:TextBox ID="txt_cou" runat="server" autocomplete="off" onkeyPress="return alphaandnum(event)" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-lg-2">
                                <label for="inputState" class="form-label">
                                    SubCourse 
                                </label>
                                <asp:TextBox ID="txt_sub" runat="server" autocomplete="off" onkeyPress="return alphaandnum(event)" CssClass="form-control">
                                </asp:TextBox>
                            </div>
                        </div>
                        <br />

                        <div class="row">
                            <div class="col-lg-2">
                                <label for="inputState" class="form-label">
                                    First term (from)
                                </label>
                                <asp:DropDownList ID="ddlfirsttrm_from" runat="server" CssClass="form-select">
                                    <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="Jan" Value="Jan"></asp:ListItem>
                                    <asp:ListItem Text="Feb" Value="Feb"></asp:ListItem>
                                    <asp:ListItem Text="Mar" Value="Mar"></asp:ListItem>
                                    <asp:ListItem Text="Apr" Value="Apr"></asp:ListItem>
                                    <asp:ListItem Text="May" Value="May"></asp:ListItem>
                                    <asp:ListItem Text="Jun" Value="Jun"></asp:ListItem>
                                    <asp:ListItem Text="Jul" Value="Jul"></asp:ListItem>
                                    <asp:ListItem Text="Aug" Value="Aug"></asp:ListItem>
                                    <asp:ListItem Text="Sept" Value="Sept"></asp:ListItem>
                                    <asp:ListItem Text="Oct" Value="Oct"></asp:ListItem>
                                    <asp:ListItem Text="Nov" Value="Nov"></asp:ListItem>
                                    <asp:ListItem Text="Dec" Value="Dec"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="col-lg-2">
                                <label for="inputState" class="form-label">
                                    First term (To)
                                </label>
                                <asp:DropDownList ID="ddlfirstterm_to" runat="server" CssClass="form-select">
                                    <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="Jan" Value="Jan"></asp:ListItem>
                                    <asp:ListItem Text="Feb" Value="Feb"></asp:ListItem>
                                    <asp:ListItem Text="Mar" Value="Mar"></asp:ListItem>
                                    <asp:ListItem Text="Apr" Value="Apr"></asp:ListItem>
                                    <asp:ListItem Text="May" Value="May"></asp:ListItem>
                                    <asp:ListItem Text="Jun" Value="Jun"></asp:ListItem>
                                    <asp:ListItem Text="Jul" Value="Jul"></asp:ListItem>
                                    <asp:ListItem Text="Aug" Value="Aug"></asp:ListItem>
                                    <asp:ListItem Text="Sep" Value="Sep">t</asp:ListItem>
                                    <asp:ListItem Text="Oct" Value="Oct"></asp:ListItem>
                                    <asp:ListItem Text="Nov" Value="Nov"></asp:ListItem>
                                    <asp:ListItem Text="Dec" Value="Dec"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="col-lg-2">
                                <label for="inputState" class="form-label">
                                    Second term (From)
                                </label>
                                <asp:DropDownList ID="ddlsecond_frm" runat="server" CssClass="form-select">
                                    <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="Jan" Value="Jan"></asp:ListItem>
                                    <asp:ListItem Text="Feb" Value="Feb"></asp:ListItem>
                                    <asp:ListItem Text="Mar" Value="Mar"></asp:ListItem>
                                    <asp:ListItem Text="Apr" Value="Apr"></asp:ListItem>
                                    <asp:ListItem Text="May" Value="May"></asp:ListItem>
                                    <asp:ListItem Text="Jun" Value="Jun"></asp:ListItem>
                                    <asp:ListItem Text="Jul" Value="Jul"></asp:ListItem>
                                    <asp:ListItem Text="Aug" Value="Aug"></asp:ListItem>
                                    <asp:ListItem Text="Sep" Value="Sep">t</asp:ListItem>
                                    <asp:ListItem Text="Oct" Value="Oct"></asp:ListItem>
                                    <asp:ListItem Text="Nov" Value="Nov"></asp:ListItem>
                                    <asp:ListItem Text="Dec" Value="Dec"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="col-lg-2">
                                <label for="inputState" class="form-label">
                                    Second term (To)
                                </label>
                                <asp:DropDownList ID="ddlsecnd_to" runat="server" CssClass="form-select">
                                    <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="Jan" Value="Jan"></asp:ListItem>
                                    <asp:ListItem Text="Feb" Value="Feb"></asp:ListItem>
                                    <asp:ListItem Text="Mar" Value="Mar"></asp:ListItem>
                                    <asp:ListItem Text="Apr" Value="Apr"></asp:ListItem>
                                    <asp:ListItem Text="May" Value="May"></asp:ListItem>
                                    <asp:ListItem Text="Jun" Value="Jun"></asp:ListItem>
                                    <asp:ListItem Text="Jul" Value="Jul"></asp:ListItem>
                                    <asp:ListItem Text="Aug" Value="Aug"></asp:ListItem>
                                    <asp:ListItem Text="Sept" Value="Sept"></asp:ListItem>
                                    <asp:ListItem Text="Oct" Value="Oct"></asp:ListItem>
                                    <asp:ListItem Text="Nov" Value="Nov"></asp:ListItem>
                                    <asp:ListItem Text="Dec" Value="Dec"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="col-lg-2">
                                <label for="inputState" class="form-label">
                                    Examination Year 
                                </label>
                                <asp:DropDownList ID="ddl_exm_yr" runat="server" CssClass="form-select">
                                    <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="col-lg-2">
                                <label for="inputState" class="form-label">
                                    Transfered Course
                                </label>
                                <asp:TextBox ID="txt_tranfercourse" runat="server" onkeyPress="return alphaandnum(event)" autocomplete="off" MaxLength="40" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-lg-4">
                                <label for="inputState" class="form-label">College Name </label>
                                <asp:TextBox runat="server" MaxLength="40" ID="clgadd" CssClass="form-control" autocomplete="off" onkeyPress="return address_exp(event)"></asp:TextBox>
                            </div>
                             <div class="col-lg-5">
                                 <label for="inputState" class="form-label">
                                    College Address 
                                </label>
                                <asp:TextBox ID="clgadd2" runat="server" MaxLength="40" autocomplete="off" onkeyPress="return address_exp(event)" CssClass="form-control">
                                </asp:TextBox>
                            </div>
                             <div class="col-lg-2">
                                  <label for="inputState" class="form-label">
                                    College Pincode 
                                </label>
                                <asp:TextBox ID="clgadd3" runat="server" onkeyPress="return num(event)" autocomplete="off" MaxLength="6" CssClass="form-control">
                                </asp:TextBox>
                            </div>
                              <div class="col-lg-1" style="margin-top:31px">
                                <asp:LinkButton runat="server" ID="lnk_coladd" CssClass="btn btn-primary" data-bs-toggle="modal" data-bs-target="#staticBackdrop"><i class="bi bi-search" style=""></i></asp:LinkButton>
                            </div>
                        </div><br />

                        <div class="row">

                            <div class="col-lg-2">
                                <label for="inputState" class="form-label">
                                    Remark
                                </label>
                                <asp:TextBox ID="txt_remark" runat="server" autocomplete="off" onkeyPress="return alpha(event)" MaxLength="20" CssClass="form-control">
                                </asp:TextBox>
                            </div>
                            <div class="col-lg-2">
                                <label for="inputState" class="form-label">
                                    Voluntary Subject
                                </label>
                                <asp:TextBox ID="txt_voluntary_grup" autocomplete="off" MaxLength="25" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>                       
                            <div class="col-lg-2">
                                <label for="inputState" class="form-label">
                                    Is Passed or Failed
                                </label>
                                <asp:DropDownList ID="ddl_is_pas_fail" runat="server" CssClass="form-select">

                                    <asp:ListItem Text="--select--" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="Passed" Value="Passed"></asp:ListItem>
                                    <asp:ListItem Text="Failed" Value="Failed"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                                 <div class="col-lg-2">
                                <label for="inputState" class="form-label">
                                    Prn No.
                                </label>
                                <asp:TextBox runat="server" ID="txt_prn" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-lg-2">
                                <asp:Button runat="server" CssClass="btn btn-primary" ID="btn_gettc" OnClick="btn_gettc_Click" OnClientClick="targetMeBlank();" Style="margin-top: 32px" Text="Get Transference Certificate" />
                            </div>

                        </div>
                        <br />
                        <div class="row">


                       
                            
                          
                        </div>
                        <div class="row">
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </div>
    <script>
        function notify(msg, type) {
            $.notify(msg, { type: type, animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.2, delay: 0 });
        }
        function num(event) {
            var value = String.fromCharCode(event.which);
            var pattern = new RegExp(/[0-9]/i);
            return pattern.test(value);
        }
        function alphaandnum(event) {
            var val = String.fromCharCode(event.which);
            var pattern = new RegExp(/^[A-Za-z0-9()-\s]+$/);
            return pattern.test(val);
        }
        function alpha(event) {
            var val = String.fromCharCode(event.which);
            var pattern = new RegExp(/^[A-Za-z \s]+$/);
            return pattern.test(val);
        }
        function address_exp(event) {
            var value = String.fromCharCode(event.which);
            var pattern = new RegExp(/[a-zA-Z0-9 (),./ &'-]/i);
            return pattern.test(value);
        }
        function myFunction() {
            var valhh = document.getElementById('<%=mdl_txt_colg_name.ClientID%>').value;
              document.getElementById('<%=mdl_txt_colg_name.ClientID%>').value = '';
            document.getElementById('<%=mdl_txt_col_address.ClientID%>').value = '';
            document.getElementById('<%=mdl_txt_col_pin.ClientID%>').value = '';

          }

    </script>


</asp:Content>

