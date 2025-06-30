<%@ Page Title="" Language="C#" MasterPageFile="~/Portals/Staff/MasterPage.master" AutoEventWireup="true" CodeFile="EmployeeDetails.aspx.cs" Inherits="Portals_Staff_Employee_EmployeeDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">


    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.12.9/dist/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.js"></script>

    <script src="../../../Assets/notify-master/js/notify.js"></script>
    <link href="../../../Assets/notify-master/css/notify.css" rel="stylesheet" />

    <link href="../../../Assets/multiselect/css/bootstrap-multiselect.css" rel="stylesheet" />
    <script src="../../../Assets/multiselect/js/bootstrap-multiselect.js"></script>
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">

    <style>
        .multiselect {
            width:100%;
            margin-top: 5px;
            border: 1px solid #ced4da;
        }

        .multiselect-container {
            height: 350px;
            width: 100%;
            overflow:scroll;
        }
        .btn-group{
            width:100%;
        }

        table, td, th {
            border: 1px solid #ddd;
            text-align: left;
        }

        table {
            border-collapse: collapse;
            width: 100%;
        }

        th, td {
            padding: 8px;
        }

        th {
            color: white;
            font-weight:100;
        }

        .FixedHeader {
            position: sticky;
            font-weight:100 ;
            top: 0;
        }

        .redcolor {
            color: red;
        }

        .chkbxx {
            height: 50px;
            width: 40px;
        }

        .caps {
            text-transform: capitalize;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="main" id="main">
        <div class="container-fluid">
            <div class="pagetitle " style="font-size: 32px; margin-left: 34px; font-weight: 300; color: #012970;">
                Employee 
            </div>
            <div class="container-fluid">
                <div class="card">
                    <div class="card-title mx-4" style="margin-bottom: 0px">
                        <%--Employee Entry--%>
                                         Employee Details

                    </div>
                    <div class="card-body">
                        <div class="container-fluid">
                            <div class="row">
                                <div class="col-lg-3">
                                    <asp:Label runat="server" class="form-label">Details Fields</asp:Label>
                                    <asp:ListBox ID="lstbxcol" CssClass="form-control" SelectionMode="Multiple" runat="server" Width="100%">
                                        <asp:ListItem Text="Mother" Value="MOTHER"></asp:ListItem>
                                        <asp:ListItem Text="Date of Birth" Value="format(DOB,'dd/MM/yyyy') as [Date of Birth] "></asp:ListItem>
                                        <asp:ListItem Text="Date of Joining" Value="format(DOJ,'dd/MM/yyyy') as [Date of Joining]"></asp:ListItem>
                                        <asp:ListItem Text-="Blood Group" Value="BLOOD_GROUP as [Blood Group]"></asp:ListItem>
                                        <asp:ListItem Text="Maritial Status" Value="MARITIAL_STATUS as [Maritial Status]"></asp:ListItem>
                                        <asp:ListItem Text="Nationality" Value="NATIONALITY as [Nationality]"></asp:ListItem>
                                        <asp:ListItem Text="Handicapped" Value="Handicapped as [Handicapped]"></asp:ListItem>
                                        <asp:ListItem Text="Category" Value="CATEGORY as [Category] "></asp:ListItem>
                                        <asp:ListItem Text="Caste" Value="CASTE as [Caste]"></asp:ListItem>
                                        <asp:ListItem Text="Mobile no.1" Value="MOBILE1 as [Mobile no.]"></asp:ListItem>
                                        <asp:ListItem Text="Mobile no.2" Value="MOBILE2  as [Alternate Mobile no.]"></asp:ListItem>
                                        <asp:ListItem Text="Email ID" Value="EMAIL_ADDRESS as [Email ID]"></asp:ListItem>
                                        <asp:ListItem Text="Pf no." Value="[PF.NO] as [PF no.]"></asp:ListItem>
                                        <asp:ListItem Text="Pan Card no." Value="[PAN.NO] as [Pan Card no.] "></asp:ListItem>
                                        <asp:ListItem Value="[DRIV.LICS.NO] as [Driving lic No.]" Text="Driving lic No."></asp:ListItem>
                                        <asp:ListItem Text="Ration Card No." Value="[RATION.CARD.NO] as [Ration Card No.]"></asp:ListItem>
                                        <asp:ListItem Text="Passport No." Value="[PASSPORT.NO] as [Passport No.]"></asp:ListItem>
                                        <asp:ListItem Text="Current Address" Value="CURRENT_ADDRESS as [Current Address]"></asp:ListItem>
                                        <asp:ListItem Text="Current State" Value="CURRENT_STATE as [Current State]"></asp:ListItem>
                                        <asp:ListItem Text="Current Pin" Value="CURRENT_PIN as [Current Pin code]"></asp:ListItem>
                                        <asp:ListItem Text="Native Address" Value="NATIVE_ADDRESS as [Native Address]"></asp:ListItem>
                                        <asp:ListItem Text="Native State" Value="NATIVE_STATE as [Native State]"></asp:ListItem>
                                        <asp:ListItem Text="Native Pin" Value="NATIVE_PIN as [Native Pin]"></asp:ListItem>
                                        <asp:ListItem Text="Date of Leaving" Value="format(DOL,'dd/MM/yyyy') as [Date of Leaving]"></asp:ListItem>
                                        <asp:ListItem Text="Religion" Value="RELIGION as [Religion]"></asp:ListItem>
                                        <asp:ListItem Text="Salary" Value="CURRENT_SALARY as [Salary]"></asp:ListItem>
                                        <asp:ListItem Text="Department Name" Value="CURRENT_DEPARTMENT_NAME as [Department Name]"></asp:ListItem>
                                        <asp:ListItem Text="Designation Name" Value="CURRENT_DESIGNATION as [Designation Name]"></asp:ListItem>
                                    </asp:ListBox>


                                </div>

                                <div class="col-lg-1" style="margin-top:25PX">
                                    <asp:Button ID="btngetdata" runat="server" Text="Get Data" OnClick="btngetdata_Click" CssClass="form-control btn btn-primary" />
                                </div>

                                <div class="col-lg-1" style="margin-top: 25PX">
                                    <asp:Button ID="btnclear" runat="server" Text="Clear" CssClass="form-control btn btn-primary" OnClick="btnclear_Click" />
                                </div>
                               
                                <div class="col-lg-2" style="margin-top: 25px">
                                    <asp:Button ID="btngetexcel" runat="server" CssClass="btn btn-primary" OnClick="btngetexcel_Click" Text="Get Excel" />
                                </div>
                            </div>
                        </div>
                        <div>
                            <br />
                            <div id="divGridViewScroll" style="width: 100%; height: 600px; overflow-x: auto">

                                <asp:GridView runat="server" AutoGenerateColumns="true" OnRowDataBound="dynamicgrd_RowDataBound" ID="dynamicgrd" HeaderStyle-CssClass="FixedHeader" HeaderStyle-BackColor="#1a62ff
">
                                    <Columns>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>










    </div>



    <script>
        function notify(msg, type) {
            $.notify(msg, { type: type, animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.2, delay: 0 });
        }
        lstbx();
        function lstbx() {
            $(function () {
                $('[id*=lstbxcol]').multiselect({
                    includeSelectAllOption: true

                });
            });
        }
    </script>
</asp:Content>

