<%@ Page Title="" Language="C#" MasterPageFile="~/Portals/Staff/MasterPage.master" AutoEventWireup="true" CodeFile="leaveApplication.aspx.cs" Inherits="Portals_Staff_Employee_leaveApplication" %>

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
        .borderred {
            border-color: red;
        }

        .FixedHeader {
            position: sticky;
            font-weight: 100;
            top: 0;
            z-index: 1;
        }

        fieldset.scheduler-border {
            border: 1px groove #ddd !important;
            padding: 0 1.4em 1.4em 1.4em !important;
            margin: 0 0 1.5em 0 !important;
            -webkit-box-shadow: 0px 0px 0px 0px #000;
            box-shadow: 0px 0px 0px 0px #000;
        }

        legend.scheduler-border {
            width: inherit;
            border-bottom: none;
        }

        .multiselect-container {
            max-height: 160px;
            width: 100%;
            overflow: scroll;
        }

        .header-cont {
            width: 100%;
            position: fixed;
            top: 0px;
        }

        body {
            font-family: sans-serif;
            font-size: 10pt;
        }

        label {
            font-weight: 100;
        }

        .hover_row {
            background-color: #A1DCF2;
        }

        table {
            width: 100%;
            margin-left: -15px;
        }

        th, td {
            text-align: center;
            padding: 8px;
        }

        th {
            color: #012970;
        }

        .lbl_disabled {
            background-color: #e9ecef;
        }

        table, td, th {
            border: 1px solid #ddd;
            text-align: left;
        }

        .btn-success {
            border: none;
        }

        .editDisabled {
            border: none;
            background-color: lightgreen;
        }

        .deleteDisabled {
            border: none;
            background-color: lightcoral;
        }

        .deleteDisabled:hover {
                background-color: lightcoral;
            }

        .editDisabled:hover {
            background-color: lightgreen;
        }

        .custom-field {
            border: 1px groove #ddd;
            border-top: none;
            padding: 8px;
        }
        .custom-field h1 { 
            font: 16px normal; 
            margin: -16px -8px 0; 
        } 
        .custom-field h1 span { 
            float: left; 
        } 
        .custom-field h1:before { 
            border-top: 1px groove #ddd; 
            content: ' '; 
            float: left; 
            margin: 8px 2px 0 -1px; 
            width: 12px; 
        } 
        .custom-field h1:after { 
            border-top: 1px groove #ddd; 
            /*border-top: 1px groove #ddd !important;*/
            content: ' '; 
            display: block; 
            height: 24px; 
            left: 2px; 
            margin: 0 1px 0 0; 
            overflow: hidden; 
            position: relative; 
            top: 8px; 
        } 
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main" class="main">
        <div class="container-fluid">

            <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                    <div class="row">
                        <div class="col-lg-10" style="margin-left: 5px; color: #012970; margin-bottom: 10px;">
                            <span style="font-family: Verdana; font-size: 18pt"><strong>LEAVE APPLICATION FORM</strong></span>
                        </div>
                    </div>

                    <div class="card" style="border-color: #337ab7;">
                        <div class="card-body" style="background-color: none;">

                            <div class="row" style="padding: 0 5px;">
                                <div class="col-lg-12 col-sm-12 col-xs-12 custom-field" style="margin-top: 0px;">
                                    <%-- <fieldset class="scheduler-border">
                                        <legend class="scheduler-border" style="font-size: 20px;">BALANCE</legend>
                                        <div class="control-group">--%>
                                    <%--<div class="card-title" style="margin-bottom: 5px">BALANCE</div>--%>
                                    <%--<div class="container">--%>
                                    <h1>
                                     <span style="font-size: 22px;color: #012970;font-weight: 500;">BALANCE</span>
                                    </h1>

                                    <div class="row" style="padding: 10px;margin-top: 3px;">
                                        <div class="col-lg-2">
                                            <span>Casual Leave:</span>
                                            <asp:Label ID="lblCL" runat="server" Enabled="false" CssClass="form-control lbl_disabled"></asp:Label>
                                        </div>
                                        <div class="col-lg-2">
                                            <span>Medical Leave:</span>
                                            <asp:Label ID="lblML" runat="server" CssClass="form-control lbl_disabled"></asp:Label>
                                        </div>
                                        <div class="col-lg-2">
                                            <span>Earned Leave:</span>
                                            <asp:Label ID="lblEL" runat="server" CssClass="form-control lbl_disabled"></asp:Label>
                                        </div>
                                        <div class="col-lg-2">
                                            <span>Previous Medical Leave:</span>
                                            <asp:Label ID="lblPML" runat="server" CssClass="form-control lbl_disabled"></asp:Label>
                                        </div>
                                        <div class="col-lg-2">
                                            <span>Previous Earned Leave:</span>
                                            <asp:Label ID="lblPEL" runat="server" CssClass="form-control lbl_disabled"></asp:Label>
                                        </div>
                                        <div class="col-lg-2">
                                            <span>Tota Balance Leave:</span>
                                            <asp:Label ID="lblTBL" runat="server" CssClass="form-control lbl_disabled"></asp:Label>
                                        </div>
                                        <div class="col-lg-2" style="display: none">
                                            <span>Outdoor Duty:</span>
                                            <asp:Label ID="lblOUTD" Style="height: 30px" disabled="disabled" runat="server" CssClass="form-control lbl_disabled"></asp:Label>
                                        </div>
                                        <div class="col-lg-2" style="display: none">
                                            <span>Compensatory Leave:</span>
                                            <asp:Label ID="lblCOMPL" Style="height: 30px" disabled="disabled" runat="server" CssClass="form-control lbl_disabled"></asp:Label>
                                        </div>
                                    </div>

                                    </fieldset>
                                    <%--</div>--%>
                                    <%--</div>--%>
                                </div>
                            </div>

                        </div>

                        <div class="row" style="padding: 0 25px;">
                            <div class="col-lg-12 col-sm-12 col-xs-12 custom-field">
                                <%--<div class="card-title" style="margin-bottom: 10px;margin-left: 14px;">LEAVE TYPE, INFO</div>--%>
                                <h1>
                                     <span style="font-size: 22px;color: #012970;font-weight: 500;">LEAVE TYPE, INFO</span>
                                </h1>
                                <div class="container" style="margin: 10px 0px">

                                    <div class="row">
                                        <div class="col-lg-1">
                                            <asp:RadioButton runat="server" ID="rdbcl" Text="&nbsp; CL" GroupName="LeaveType" OnCheckedChanged="rdbcl_CheckedChanged" AutoPostBack="true" />
                                            <asp:TextBox ID="txtcl" runat="server" CssClass="form-control" MaxLength="4" onkeypress="return CheckNumericwithdot(event)" AutoComplete="off" OnTextChanged="txtcl_TextChanged" onpaste="return false" AutoPostBack="true"></asp:TextBox>
                                            <asp:RangeValidator ID="RangeValidator_CL" runat="server" ControlToValidate="txtcl" ForeColor="Red" ErrorMessage="You have no more Balance Leave left" MinimumValue="-100" Type="Double"></asp:RangeValidator>
                                        </div>
                                        <div class="col-lg-1" id="hq" runat="server">
                                            <asp:Label ID="lblhq" runat="server" Text="HQ"></asp:Label>
                                            <asp:DropDownList ID="ddlhq" CssClass="form-control" runat="server" Style="margin-top: 8px" OnSelectedIndexChanged="ddlhq_SelectedIndexChanged" AutoPostBack="true">
                                                <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                                                <asp:ListItem Value="YES" Text="YES"></asp:ListItem>
                                                <asp:ListItem Value="NO" Text="NO"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-lg-1">
                                            <asp:RadioButton runat="server" ID="rdbml" Text="&nbsp; ML" GroupName="LeaveType" OnCheckedChanged="rdbml_CheckedChanged" AutoPostBack="true" />
                                            <asp:TextBox ID="txtml" runat="server" CssClass="form-control" MaxLength="4" onkeypress="return CheckNumericwithdot(event)" AutoComplete="off" onpaste="return false" OnTextChanged="txtml_TextChanged" AutoPostBack="true"></asp:TextBox>
                                            <asp:RangeValidator ID="RangeValidator_ML" runat="server" ControlToValidate="txtml" ForeColor="Red" ErrorMessage="You have no more Balance Leave left" MinimumValue="-100" Type="Double"></asp:RangeValidator>
                                        </div>
                                        <div class="col-lg-1">
                                            <asp:RadioButton runat="server" ID="rdbel" Text="&nbsp; EL" GroupName="LeaveType" OnCheckedChanged="rdbel_CheckedChanged" AutoPostBack="true" />
                                            <asp:TextBox ID="txtel" runat="server" CssClass="form-control" MaxLength="4" onkeypress="return CheckNumericwithdot(event)" AutoComplete="off" onpaste="return false" OnTextChanged="txtel_TextChanged" AutoPostBack="true"></asp:TextBox>
                                            <asp:RangeValidator ID="RangeValidator_EL" runat="server" ControlToValidate="txtel" ForeColor="Red" ErrorMessage="You have no more Balance Leave left" MinimumValue="-100" Type="Double"></asp:RangeValidator>
                                        </div>
                                        <div class="col-lg-1">
                                            <asp:RadioButton runat="server" ID="rdboutd" Text="&nbsp; OD" GroupName="LeaveType" OnCheckedChanged="rdboutd_CheckedChanged" AutoPostBack="true" />
                                            <asp:TextBox ID="txtoutd" runat="server" CssClass="form-control" MaxLength="4" onkeypress="return CheckNumericwithdot(event)" AutoComplete="off" onpaste="return false"></asp:TextBox>
                                            <%--OnTextChanged="txtoutd_TextChanged" AutoPostBack="true"--%>
                                        </div>
                                        <div class="col-lg-1">
                                            <asp:RadioButton runat="server" ID="rdbcomp" Text="&nbsp; CO" GroupName="LeaveType" OnCheckedChanged="rdbcomp_CheckedChanged" AutoPostBack="true" />
                                            <asp:TextBox ID="txtcomp" runat="server" CssClass="form-control" MaxLength="4" onkeypress="return CheckNumericwithdot(event)" AutoComplete="off" onpaste="return false"></asp:TextBox>
                                            <%--OnTextChanged="txtcomp_TextChanged" AutoPostBack="true"--%>
                                        </div>
                                        <div class="col-lg-1" style="display: none">
                                            <asp:RadioButton runat="server" ID="rdbhalf" Text="&nbsp; Half Day" OnCheckedChanged="rdbhalf_CheckedChanged" GroupName="LeaveType" AutoPostBack="true" />
                                        </div>
                                        <div class="col-lg-1">
                                            <asp:RadioButton runat="server" ID="rdblwp" Text="&nbsp; LWP" GroupName="LeaveType" OnCheckedChanged="rdblwp_CheckedChanged" AutoPostBack="true" />
                                            <asp:TextBox ID="txtlwp" runat="server" CssClass="form-control" MaxLength="4" onkeypress="return CheckNumericwithdot(event)" AutoComplete="off" onpaste="return false"></asp:TextBox>
                                        </div>
                                        <div class="col-lg-2">
                                            <asp:RadioButton runat="server" ID="rdbmaternity" Text="MATERNITY" GroupName="LeaveType" OnCheckedChanged="rdbmaternity_CheckedChanged" AutoPostBack="true" />
                                            <asp:TextBox ID="txtmaternity" runat="server" CssClass="form-control" MaxLength="4" onkeypress="return CheckNumericwithdot(event)" AutoComplete="off" onpaste="return false"></asp:TextBox>
                                        </div>
                                        <div class="col-lg-1">
                                            <asp:RadioButton runat="server" ID="rdbvacation" Text="VACATION" GroupName="LeaveType" OnCheckedChanged="rdbvacation_CheckedChanged" AutoPostBack="true" />
                                        </div>
                                        <div class="col-lg-2">
                                            <asp:RadioButton runat="server" ID="rdb_latecomingearlygoing" Text="LATE COMING/EARLY GOING" GroupName="LeaveType" Enabled="false" />
                                        </div>
                                    </div>

                                    <%-- </ContentTemplate>
                                        </asp:UpdatePanel>--%>
                                    <br />
                                    <asp:UpdatePanel ID="UpdatePanel5" runat="server" style="margin-top: -50px;">
                                        <ContentTemplate>

                                            <div class="row">
                                                <div class="col-lg-2">
                                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                        <ContentTemplate>
                                                            <div class="form-group">
                                                                <span>CO-ORDINATOR:</span><br />
                                                                <label style="color: red; margin-bottom: 0px;">&nbsp;</label>
                                                                <asp:ListBox ID="ddl_hod" class="multistyle" runat="server" SelectionMode="Multiple"></asp:ListBox>
                                                            </div>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </div>
                                                <div class="col-lg-2">
                                                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                        <ContentTemplate>
                                                            <div class="form-group">
                                                                <span>PRINCIPAL:</span>
                                                                <label style="color: red; margin-bottom: 0px;">*</label>
                                                                <asp:ListBox ID="ddl_principal" class="multistyle" runat="server" SelectionMode="Multiple"></asp:ListBox>
                                                            </div>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </div>
                                                <div class="col-lg-2" style="display: none">
                                                    <asp:RadioButton runat="server" ID="rdb_hq" Text="&nbsp; HQ" GroupName="LeaveType" OnCheckedChanged="rdb_hq_CheckedChanged" AutoPostBack="true" Visible="false" />
                                                </div>
                                                <div class="col-lg-2">
                                                    <div class="form-group">
                                                        <asp:Label ID="lbl_inform_to_superrior" runat="server" Text="Inform to Superior :">
                                                        </asp:Label><label style="color: red; margin-bottom: 0px;">*</label>
                                                        <asp:DropDownList ID="ddl_inform_to_superrior" CssClass="form-control" runat="server">
                                                            <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                                                            <asp:ListItem Value="Advance" Text="Advance"></asp:ListItem>
                                                            <asp:ListItem Value="In Time" Text="In Time"></asp:ListItem>
                                                            <asp:ListItem Value="After Joining Back" Text="After Joining Back"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="col-lg-2">
                                                    <div class="form-group">
                                                        <asp:Label ID="lbl_leave_days_type" runat="server" Text="Leave Days Type :"></asp:Label>
                                                        <label style="color: red; margin-bottom: 0px;">*</label>
                                                        <asp:DropDownList ID="ddl_leave_days_type" CssClass="form-control" OnSelectedIndexChanged="ddl_leave_days_type_SelectedIndexChanged" runat="server" AutoPostBack="true">
                                                            <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                                                            <asp:ListItem Value="NA" Text="NA"></asp:ListItem>
                                                            <asp:ListItem Value="Prefix" Text="Prefix"></asp:ListItem>
                                                            <asp:ListItem Value="Suffix" Text="Suffix"></asp:ListItem>
                                                            <asp:ListItem Value="Both" Text="Both"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="col-lg-2">
                                                    <span>No. of Leave Days :</span>
                                                    <asp:TextBox runat="server" CssClass="form-control" ID="txtleavedaysno" AutoComplete="off" MaxLength="4" onkeypress="return CheckNumeric(event)" onpaste="return false"></asp:TextBox>

                                                </div>
                                            </div>

                                            <br />

                                            <div class="row" >
                                                <div class="col-lg-2">
                                                    <div class="form-group">
                                                        <asp:Label ID="lbl_adjust_alternative" runat="server" Text="Adjusting Alternative :"></asp:Label>
                                                        <label style="color: red; margin-bottom: 0px;">*</label>
                                                        <asp:DropDownList ID="ddl_adjust_alternative" CssClass="form-control" OnSelectedIndexChanged="ddl_adjust_alternative_SelectedIndexChanged" AutoPostBack="true" runat="server">
                                                            <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                                                            <asp:ListItem Value="yes" Text="Yes"></asp:ListItem>
                                                            <asp:ListItem Value="no" Text="No"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="col-lg-3">
                                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                        <ContentTemplate>
                                                            <div class="form-group">
                                                                <span>Alternative Arrangement:</span>
                                                                <asp:ListBox ID="ddl_emp_name" class="multistyle" runat="server" SelectionMode="Multiple"></asp:ListBox>
                                                            </div>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </div>
                                            </div>

                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <%--</fieldset>--%>
                                </div>
                            </div>
                        </div>

                        <div class="row" style="padding: 15px 20px;margin-top:5px">
                            <div class="col-lg-4">
                                <div class="row">
                                    <div class="col-lg-6 col-xs-12">
                                        <span>Name:</span>
                                        <asp:TextBox ID="lblname" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-6 col-xs-12">
                                        <span>Designation:</span>
                                        <asp:TextBox ID="lbldesig" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-3 col-xs-12">
                                <div class="form-group">
                                    <asp:Label ID="Label3" runat="server" Text="Leave From(Date) <i>(dd-mmm-yyyy)</i>: "></asp:Label>
                                    <label style="color: red; margin-bottom: 0px;">*</label>
                                    <asp:TextBox runat="server" CssClass="form-control" ID="fdate" AutoComplete="off" onpaste="return false">  </asp:TextBox>
                                </div>
                            </div>
                            <div class="col-lg-3 col-xs-12">
                                <div class="form-group">
                                    <asp:Label ID="Label1" runat="server" Text="Leave Till(Date) <i>(dd-mmm-yyyy)</i>: "></asp:Label>
                                    <label style="color: red; margin-bottom: 0px;">*</label>
                                    <asp:TextBox runat="server" CssClass="form-control" ID="tdate" AutoComplete="off" onpaste="return false">  </asp:TextBox>
                                </div>
                            </div>
                            <div class="col-lg-2">
                                <span>No. of Days :</span>
                                <label style="color: red; margin-bottom: 0px;">*</label>
                                <asp:HiddenField ID="hiddays" runat="server" />
                                <asp:Label ID="txtdays" runat="server" CssClass="form-control"></asp:Label>
                            </div>
                        </div>

                        <div class="row" style="padding: 10px 20px;">
                            <div class="col-lg-2">
                                <span>Address:</span>
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox runat="server" CssClass="form-control" ID="txtadd" TextMode="MultiLine" AutoComplete="off" onpaste="return false"></asp:TextBox>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-lg-2">
                                <span>Contact:</span>
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox runat="server" CssClass="form-control" ID="txt_contact" AutoComplete="off" MaxLength="10" onkeypress="return CheckNumeric(event)" onpaste="return false"></asp:TextBox>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-lg-2">
                                <span>Reason For Leave/ (COMP/Extra Duty) details:</span>
                                <label style="color: red; margin-bottom: 0px;">*</label>
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox runat="server" CssClass="form-control" ID="txtres" AutoComplete="off" TextMode="MultiLine" MaxLength="100" onpaste="return false"></asp:TextBox>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-lg-2">
                                <span padding-bottom: 15px">Attach ML/OD/CO Certificate(.pdf):</span><br />
                                <br />
                                <asp:FileUpload ID="FileUpload1" runat="server" accept=".pdf" />
                                <label id="lblmedapplication" style="color: red; font-style: italic;"></label>
                            </div>
                            <div class="col-lg-3">
                                <span>Div / Course / Date & Time of Lectures / Practicals / Adjusment details:</span>
                                <label style="color: red; margin-bottom: 0px;">*</label>
                                <asp:TextBox runat="server" CssClass="form-control" ID="txtdetails" AutoComplete="off" TextMode="MultiLine" MaxLength="150" onpaste="return false"></asp:TextBox>
                            </div>
                        </div>


                          <%--Button Save&Clear--%>
                    <%--<div class="row">
                        <div class="col-lg-4"></div>
                        <div class="col-lg-2">
                            <asp:Button ID="Button1" runat="server" CssClass="btn btn-block btn-success" Text="Save" OnClick="btn_Save_Click"></asp:Button>
                        </div>
                        <div class="col-lg-2">
                            <asp:Button ID="Button2" runat="server" CssClass=" btn btn-block btn-danger" Text="Clear" OnClick="btn_Clear_Click"></asp:Button>
                        </div>
                        <div class="col-lg-2">
                            <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" ReadOnly="true" Visible="false"></asp:TextBox>
                        </div>
                    </div>--%>

                    <br />
                    <%--Grid Row--%>
                    <%--<div class="row">
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <div class="container-fluid">
                                <div class="container" style="overflow-y: auto; overflow-x: auto; max-height: 500px;" runat="server" id="Div1">
                                    <asp:GridView ID="GridView1" runat="server" HeaderStyle-CssClass="FixedHeader" HeaderStyle-BackColor="#9599a3" BorderColor="#000" Font-Size="12pt" Width="100%" AutoGenerateColumns="false" Style="text-align: center" OnRowCommand="grd_load_RowCommand" OnRowDeleting="grd_load_RowDeleting" OnRowDataBound="grd_load_RowDataBound">
                                        <Columns>
                                            <asp:TemplateField HeaderText="SR.NO">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblsrno" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField ItemStyle-Width="30px" HeaderText="ID" ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_srno" runat="server" Text='<%#Eval("srno")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField ItemStyle-Width="30px" HeaderText="ID" ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_empid" runat="server" Text='<%#Eval("emp_id")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Application Date">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_applc_dt" runat="server" Text='<%#Eval("curr_dt","{0:dd-MMM-yyyy}")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Inform to Superior">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_inform_to_superior" runat="server" Text='<%#Eval("inform_to_superior")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Leave Days Type">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_leave_days_type" runat="server" Text='<%#Eval("leave_days_type")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="No. of Leave Days Type">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_leave_days_type_no" runat="server" Text='<%#Eval("leave_days_type_no")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Leave Type">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_Ltype" runat="server" Text='<%#Eval("leaveType")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Leave From">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_Lfrom" runat="server" Text='<%#Eval("f1","{0:dd-MMM-yyyy}")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Leave Till">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_Lto" runat="server" Text='<%#Eval("t1","{0:dd-MMM-yyyy}")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="No. of Days">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_Ldays" runat="server" Text='<%#Eval("leaveDays")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Address & Telephone No.">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_Ladd" runat="server" Text='<%#Eval("leaveadd")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Contact No">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_contactno" runat="server" Text='<%#Eval("contactno")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="CL" visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_cl" runat="server" Text='<%#Eval("CL")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="CO" visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_co" runat="server" Text='<%#Eval("CO")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="ML" visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_ml" runat="server" Text='<%#Eval("ML")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="EL" visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_el" runat="server" Text='<%#Eval("EL")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="OUTD" visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_outd" runat="server" Text='<%#Eval("OUTD")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="LWP" visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_lwp" runat="server" Text='<%#Eval("LWP")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="MATERNITY" visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_maternity" runat="server" Text='<%#Eval("MATERNITY")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="halfday" visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_halfday" runat="server" Text='<%#Eval("halfday")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="vacation" visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_vacation" runat="server" Text='<%#Eval("vacation")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="HQ" visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_hq" runat="server" Text='<%#Eval("HQ")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Alternative Arrangement ID" visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_locumID" runat="server" Text='<%#Eval("locumID")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Alternative Arrangement">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_locumname" runat="server" Text='<%#Eval("locumName")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Reason for Leave">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_resleave" runat="server" Text='<%#Eval("resleave")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Div/Course/Date & Time of Lectures/Practicals">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_details" runat="server" Text='<%#Eval("details")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Remark" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_remark" runat="server" Text='<%#Eval("remark")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="PAID / UNPAID">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_paid_unpaid" runat="server" Text='<%#Eval("PAID/UNPAID")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="HOD Status">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_A_hod" runat="server" Text='<%#Eval("approved_hod")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="HOD Reason">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_A_hod_reason" runat="server" Text='<%#Eval("approved_reason_HOD")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="PRINCIPAL Status">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_A_principle" runat="server" Text='<%#Eval("approved_principle")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="PRINCIPAL Reason">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_A_principle_reason" runat="server" Text='<%#Eval("approved_reason_PRINCIPLE")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="ayid" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblayid" runat="server" Text='<%#Eval("AYID")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="HOD ID" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_hodID" runat="server" Text='<%#Eval("HOD_ID")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="PRINCIPAL ID" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_principalID" runat="server" Text='<%#Eval("PRINCIPAL_ID")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Certificate">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkbtn_view" runat="server" Text="View" CssClass="btn btn-success btn-block" CommandName="view" CommandArgument='<%# Container.DataItemIndex %>'></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                           
                                            <asp:TemplateField HeaderText="Delete">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkbtn_delete" runat="server" Text="Delete" CssClass="btn btn-danger btn-block" CommandName="delete" CommandArgument='<%# Container.DataItemIndex %>'></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            
                                            <asp:TemplateField HeaderText="Select">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkbtn_edit" runat="server" Text="Edit" CssClass="btn btn-success btn-block" CommandName="select" CommandArgument='<%# Container.DataItemIndex %>'></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Print">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkbtn_print" runat="server" Text="Print" CssClass="btn btn-success btn-block" CommandName="print" CommandArgument='<%# Container.DataItemIndex %>'></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </div>--%>

                    </div>

                    <%--Button Save&Clear--%>
                    <div class="row">
                        <div class="col-lg-4"></div>
                        <div class="col-lg-2">
                            
                            <asp:Button ID="btn_Save" runat="server" CssClass="btn btn-block btn-success" Text="Save" OnClick="btn_Save_Click"></asp:Button>
                            
                        </div>
                        <div class="col-lg-2">
                            <asp:Button ID="btn_Clear" runat="server" CssClass=" btn btn-block btn-danger" Text="Clear" OnClick="btn_Clear_Click"></asp:Button>
                        </div>
                        <div class="col-lg-2">
                            <asp:TextBox ID="txt_sr" runat="server" CssClass="form-control" ReadOnly="true" Visible="false"></asp:TextBox>
                        </div>
                    </div>

                    <br />
                    <div class="card">
                        <div class="card-body">

                       
                    <%--Grid Row--%>
                   <div class="row">
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <div class="container-fluid">
                                <div class="container-fluid" style="overflow-y: auto; overflow-x: auto; max-height: 500px; margin:0;" runat="server" id="grid">
                                    <asp:GridView ID="grd_load" runat="server" HeaderStyle-CssClass="FixedHeader" Width="100%" AutoGenerateColumns="false" Style="text-align: center" OnRowCommand="grd_load_RowCommand" OnRowDeleting="grd_load_RowDeleting" OnRowDataBound="grd_load_RowDataBound">
                                        <Columns>
                                            <asp:TemplateField HeaderText="SR.NO">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblsrno" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField ItemStyle-Width="30px" HeaderText="ID" visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_srno" runat="server" Text='<%#Eval("srno")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField ItemStyle-Width="30px" HeaderText="ID" visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_empid" runat="server" Text='<%#Eval("emp_id")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Application Date">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_applc_dt" runat="server" Text='<%#Eval("curr_dt","{0:dd-MMM-yyyy}")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Inform to Superior">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_inform_to_superior" runat="server" Text='<%#Eval("inform_to_superior")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Leave Days Type">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_leave_days_type" runat="server" Text='<%#Eval("leave_days_type")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="No. of Leave Days Type">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_leave_days_type_no" runat="server" Text='<%#Eval("leave_days_type_no")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Leave Type">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_Ltype" runat="server" Text='<%#Eval("leaveType")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Leave From">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_Lfrom" runat="server" Text='<%#Eval("f1","{0:dd-MMM-yyyy}")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Leave Till">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_Lto" runat="server" Text='<%#Eval("t1","{0:dd-MMM-yyyy}")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="No. of Days">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_Ldays" runat="server" Text='<%#Eval("leaveDays")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Address & Telephone No.">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_Ladd" runat="server" Text='<%#Eval("leaveadd")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Contact No">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_contactno" runat="server" Text='<%#Eval("contactno")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="CL" visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_cl" runat="server" Text='<%#Eval("CL")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="CO" visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_co" runat="server" Text='<%#Eval("CO")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="ML" visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_ml" runat="server" Text='<%#Eval("ML")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="EL" visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_el" runat="server" Text='<%#Eval("EL")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="OUTD" visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_outd" runat="server" Text='<%#Eval("OUTD")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="LWP" visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_lwp" runat="server" Text='<%#Eval("LWP")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="MATERNITY" visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_maternity" runat="server" Text='<%#Eval("MATERNITY")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="halfday" visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_halfday" runat="server" Text='<%#Eval("halfday")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="vacation" visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_vacation" runat="server" Text='<%#Eval("vacation")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="HQ" visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_hq" runat="server" Text='<%#Eval("HQ")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Alternative Arrangement ID" visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_locumID" runat="server" Text='<%#Eval("locumID")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Alternative Arrangement">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_locumname" runat="server" Text='<%#Eval("locumName")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Reason for Leave">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_resleave" runat="server" Text='<%#Eval("resleave")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Div/Course/Date & Time of Lectures/Practicals">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_details" runat="server" Text='<%#Eval("details")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Remark" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_remark" runat="server" Text='<%#Eval("remark")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="PAID / UNPAID">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_paid_unpaid" runat="server" Text='<%#Eval("PAID/UNPAID")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="HOD Status">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_A_hod" runat="server" Text='<%#Eval("approved_hod")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="HOD Reason">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_A_hod_reason" runat="server" Text='<%#Eval("approved_reason_HOD")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="DIRECTOR Status">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_A_principle" runat="server" Text='<%#Eval("approved_principle")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="DIRECTOR Reason">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_A_principle_reason" runat="server" Text='<%#Eval("approved_reason_PRINCIPLE")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="ayid" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblayid" runat="server" Text='<%#Eval("AYID")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="HOD ID" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_hodID" runat="server" Text='<%#Eval("HOD_ID")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="DIRECTOR ID" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_principalID" runat="server" Text='<%#Eval("PRINCIPAL_ID")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Certificate">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkbtn_view" runat="server" Text="View" CssClass="btn btn-success btn-block" CommandName="view" CommandArgument='<%# Container.DataItemIndex %>'></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                           
                                            <asp:TemplateField HeaderText="Delete">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkbtn_delete" runat="server" Text="Delete" CssClass="btn btn-danger btn-block" CommandName="delete" CommandArgument='<%# Container.DataItemIndex %>'></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                          
                                            <asp:TemplateField HeaderText="Select">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkbtn_edit" runat="server" Text="Edit" CssClass="btn btn-success btn-block" CommandName="select" CommandArgument='<%# Container.DataItemIndex %>'></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Print">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkbtn_print" runat="server" Text="Print" CssClass="btn btn-success btn-block" CommandName="print" CommandArgument='<%# Container.DataItemIndex %>'></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </div>
                             </div>
                    </div>
                    <br />
                </div>
            </div>

        </div>
    </div>


    <script>
        $(document).ready(function () {

            jQuery('[id*=fdate]').datetimepicker(
                {
                    changeMonth: false,
                    changeYear: false,
                    timepicker: false,
                    format: 'd-M-Y',
                    viewMode: "months",
                    minViewMode: "months"
                    //endDate: "+0m"
                });

            jQuery('[id*=tdate]').datetimepicker(
                {

                    changeMonth: false,
                    changeYear: false,
                    timepicker: false,
                    format: 'd-M-Y',
                    viewMode: "months",
                    minViewMode: "months"
                    //endDate: "+0m"                  
                });

        });

        function date() {
            jQuery('[id*=fdate]').datetimepicker(
                {
                    changeMonth: false,
                    changeYear: false,
                    timepicker: false,
                    format: 'd-M-Y',
                    viewMode: "months",
                    minViewMode: "months"
                });

            jQuery('[id*=tdate]').datetimepicker(
                {

                    changeMonth: false,
                    changeYear: false,
                    timepicker: false,
                    format: 'd-M-Y',
                    viewMode: "months",
                    minViewMode: "months"

                });
        }

        //setting mindate for tdate
        $('[id*=fdate]').change(function () {
            $('[id*=tdate]').prop("disabled", "disabled");

            if ($('[id*=fdate]').val() != "") {
                $('[id*=tdate]').removeAttr("disabled");
            }

            $('[id*=tdate]').val("");
            document.getElementById("<%=txtdays.ClientID%>").innerText = "";
            document.getElementById("<%=hiddays.ClientID%>").innerText = "";


            $('[id*=fdate]').datetimepicker({
                defaultDate: new Date(),
                //minDate: new Date(),              

            });


            $('[id*=tdate]').datetimepicker({
                defaultDate: new Date(),
                minDate: new Date($('[id*=fdate]').val()),


            });

        });

        $('[id*=fdate]').on('input', function () {

            $('[id*=fdate]').val("");
        })
        //setting mindate for tdate

        function changeTextarea(str) {
            document.getElementById('<%=tdate.ClientID%>').value = str;
            if (days == NaN) {
                document.getElementById("<%=txtdays.ClientID%>").innerText = "";
                document.getElementById("<%=hiddays.ClientID%>").innerText = "";
            }

        }

        function daysdiff(date1, date2) {
            //Get 1 day in milliseconds
            var one_day = 1000 * 60 * 60 * 24;

            // Convert both dates to milliseconds
            var date1_ms = date1.getTime();
            var date2_ms = date2.getTime();

            // Calculate the difference in milliseconds
            var difference_ms = date2_ms - date1_ms;

            // Convert back to days and return
            return Math.round(difference_ms / one_day);


        };

        $('[id*=tdate]').change(function () {

            var days = daysdiff(new Date($('[id*=fdate]').val()), new Date($('[id*=tdate]').val()));
            $('#<%= txtdays.ClientID %>')[0].innerHTML = (days + 1);

            document.getElementById("<%=hiddays.ClientID %>").value = (days + 1);
        });

    </script>

    <script type="text/javascript">
        loadmulti();
        function loadmulti() {
            $('[id*=ddl_emp_name]').multiselect({
                includeSelectAllOption: true
            });
        }
    </script>

    <script>
        ddl_hod_multi();
        function ddl_hod_multi() {
            $('[id*=ddl_hod]').multiselect({
                includeSelectAllOption: true
            });
        }
    </script>

    <script>
        ddl_principal_multi();
        function ddl_principal_multi() {
            $('[id*=ddl_principal]').multiselect({
                includeSelectAllOption: true
            });

        }

        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {
            ddl_hod_multi();
            ddl_principal_multi();
            loadmulti();
            //$('[id*=fdate]').val("");
        });

        //--------------------------------------------------------

        //$('[id*=txtcl]').change(function () {

        //    var txtcl = $('[id*=txtcl]').val();
        //    var lblcl = $('[id*=lblCL]').text();

        //    if (txtcl > lblcl) {
        //        //$('[id*=btn_save]').attr('disabled', 'disabled');
        //        $('#ContentPlaceHolder1_btn_Save').attr('disabled', 'disabled');
        //    }
        //});


       //------------------------------------------------------------
    </script>
    <script>
        function CheckNumeric(e) {

            if (window.event) // IE
            {
                if ((e.keyCode < 48 || e.keyCode > 57) & e.keyCode != 8) {
                    event.returnValue = false;
                    return false;

                }
            }
            else { // Fire Fox
                if ((e.which < 48 || e.which > 57) & e.which != 8) {
                    e.preventDefault();
                    return false;

                }
            }
        }

        function CheckNumericwithdot(e) {

            if (window.event) // IE
            {
                if ((e.keyCode < 48 || e.keyCode > 57) & e.keyCode != 8 & e.keyCode != 46) {
                    event.returnValue = false;
                    return false;

                }
            }
            else { // Fire Fox
                if ((e.which < 48 || e.which > 57) & e.which != 8 & e.keyCode != 46) {
                    e.preventDefault();
                    return false;

                }
            }
        }

        function NOWORDS(e) {
            isIE = document.all ? 1 : 0
            keyEntry = !isIE ? e.which : event.keyCode;
            if ((keyEntry == '9'))
                return true;
            else {
                return false;
            }
        }

    </script>

</asp:Content>

