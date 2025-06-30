<%@ Page Language="C#" AutoEventWireup="true" CodeFile="leaveApplicationForm.aspx.cs" Inherits="Portals_Staff_Employee_leaveapplicationForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <br />
        <table id="table1" runat="server" style="width: 100%">
            <tr>
                <td>
                    <table style="text-align: center; width: 100%">
                        <tr>
                            <td style="font-size: 17px; font-weight: bold; font-family: Times New Roman; text-align: center">
                                <%--<img src="../../../Assets/img/vivalogo.png" alt="VIT" style="height:77px;width:75px" /></td>--%>
                            <img src="../../../Assets/img/imr2.jpg" alt="IMR" /></td>
                        </tr>

                    </table>
                    <br />
                    <br />
                    <center>
                        <p style="font-size: 15px; margin-bottom: 10px">
                            <u><strong>LEAVE APPLICATION</strong></u>
                    </center>
                    <br />
                    <table style="text-align: left; font-family: Times New Roman; width: 100%">
                        <tr style="text-align: center">
                        </tr>

                        <tr>
                            <td>1. &nbsp;Name&nbsp;:-&nbsp;<asp:Label ID="lbl_name" runat="server" Style="font-weight: bold; border-bottom: 1px solid black"></asp:Label></td>
                        </tr>
                    </table>
                    <table style="text-align: left; font-family: Times New Roman; width: 100%; margin-top: 8px">
                        <tr>
                            <td style="width: 50%">2. &nbsp;Designation&nbsp;:-&nbsp;<asp:Label ID="lbl_designation" runat="server" Style="font-weight: bold; border-bottom: 1px solid black"></asp:Label></td>
                            <td style="width: 50%">Department&nbsp;:-&nbsp;<asp:Label ID="lbl_department" runat="server" Style="font-weight: bold; border-bottom: 1px solid black"></asp:Label></td>
                        </tr>
                    </table>
                    <table style="text-align: left; font-family: Times New Roman; width: 100%; margin-top: 8px">
                        <tr>
                            <td style="width: 50%">3. &nbsp;Period of&nbsp;
                                <asp:Label ID="lbl_leavetype" runat="server" Style="font-weight: bold; border-bottom: 1px solid black"></asp:Label>
                                applied for &nbsp;
                                    <asp:Label ID="lbl_leavedays" runat="server" Style="font-weight: bold; border-bottom: 1px solid black"></asp:Label>
                                Day / Days from
                                    <asp:Label ID="lbl_fromdate" runat="server" Style="font-weight: bold; border-bottom: 1px solid black"></asp:Label>
                                To
                                    <asp:Label ID="lbl_todate" runat="server" Style="font-weight: bold; border-bottom: 1px solid black"></asp:Label>
                                with permission to
                                <asp:Label ID="lbl_leavedaystype" runat="server" Style="font-weight: bold; border-bottom: 1px solid black"></asp:Label>
                                of
                                <asp:Label ID="lbl_no_leavedaystype" runat="server" Style="font-weight: bold; border-bottom: 1px solid black"></asp:Label>
                                Day / Days.
                                    
                            </td>
                        </tr>
                    </table>
                    <table style="text-align: left; font-family: Times New Roman; width: 100%; margin-top: 8px">
                        <tr>
                            <td style="width: 50%">4. &nbsp;Reason&nbsp;:-&nbsp;
                                <asp:Label ID="lbl_reason" runat="server" Style="font-weight: bold; border-bottom: 1px solid black"></asp:Label></td>
                        </tr>
                    </table>
                    <table style="text-align: left; font-family: Times New Roman; width: 100%; margin-top: 8px">
                        <tr>
                            <td style="width: 50%">5. &nbsp;Whether Informed to Superior :-
                                <asp:Label ID="lbl_inform_to_superior" runat="server" Style="font-weight: bold; border-bottom: 1px solid black"></asp:Label></td>
                        </tr>
                    </table>
                    <table style="text-align: left; font-family: Times New Roman; width: 100%; margin-top: 8px">
                        <tr>
                            <td style="width: 50%">6. &nbsp;Whether he adjusted his duties before availing the leave&nbsp;:-&nbsp;
                                <asp:Label ID="lbl_alt_arr" runat="server" Style="font-weight: bold; border-bottom: 1px solid black"></asp:Label></td>
                        </tr>
                    </table>
                    <table style="text-align: left; font-family: Times New Roman; width: 100%; margin-top: 8px">
                        <tr>
                            <td style="width: 50%">7. &nbsp;Dates on which Extra Duty put in (CO Date)&nbsp;:&nbsp;
                                <asp:Label ID="lbl_extraduty" runat="server" Style="font-weight: bold; border-bottom: 1px solid black"></asp:Label><br />
                                &nbsp;(WITH THE SIGNATURE OF HIS/HER HOD)
                            </td>
                        </tr>
                    </table>
                    <table style="text-align: left; font-family: Times New Roman; width: 100%; margin-top: 8px">
                        <tr>
                            <td style="width: 50%">8. &nbsp;Whether HQ leave is needed&nbsp;:&nbsp;
                                <asp:Label ID="lbl_HQleave" runat="server" Style="font-weight: bold; border-bottom: 1px solid black"></asp:Label>
                                <br />
                                &nbsp; if YES,Then Leave Addresss&nbsp;:&nbsp;
                                <asp:Label ID="lbl_leaveaddress" runat="server" Style="font-weight: bold; border-bottom: 1px solid black"></asp:Label><br />
                                &nbsp; with Contact Number&nbsp;:&nbsp;
                                <asp:Label ID="lbl_contactno" runat="server" Style="font-weight: bold; border-bottom: 1px solid black"></asp:Label></td>
                        </tr>

                    </table>
                    <table style="text-align: left; font-family: Times New Roman; width: 100%; margin-top: 8px">
                        <tr>
                            <td style="width: 50%">9. &nbsp;Adjustment of Lectures / Practicals&nbsp;:&nbsp;<asp:Label ID="lbl_bal_leave" runat="server" Style="font-weight: bold; border-bottom: 1px solid black"></asp:Label></td>
                        </tr>
                    </table>
                    <table style="text-align: left; font-family: Times New Roman; width: 100%; margin-top: 8px;border-collapse: collapse;">
                        <thead style="font-size: 18px; font-weight: bold; border: 1px solid black; border-collapse: collapse;">
                            <tr>
                                <td style="font-size: 16px; border: 1px solid black; border-collapse: collapse; text-align: center">Adjusted with
                                </td>
                                <td style="font-size: 16px; border: 1px solid black; border-collapse: collapse; text-align: center">Div / Course / Date & Time of Lectures / Practicals
                                </td>
                                <td style="font-size: 16px; border: 1px solid black; border-collapse: collapse; text-align: center">Signature
                                </td>   
                            </tr>
                        </thead>
                        <tbody style="font-size: 16px; border: 1px solid black; border-collapse: collapse;">
                            <td style="font-size: 16px; border: 1px solid black; border-collapse: collapse;">&nbsp;<asp:Label ID="lbl_adjustwith" runat="server" Style="font-weight: bold; border-bottom: 1px solid black"></asp:Label>&nbsp;
                            </td>


                            <td style="font-size: 16px; border: 1px solid black; border-collapse: collapse;">&nbsp;<asp:Label ID="lbl_details" runat="server" Style="font-weight: bold; border-bottom: 1px solid black"></asp:Label>&nbsp;
                            </td>


                            <td style="font-size: 16px; border: 1px solid black; border-collapse: collapse;">
                                <asp:Label ID="lbl_signature" runat="server" Style="font-weight: bold; border-bottom: 1px solid black"></asp:Label>
                            </td>
                        </tbody>
                    </table>
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <table style="text-align: left; font-family: Times New Roman; width: 100%">
                        <tr>
                            <td style="width: 23%; text-align: center; font-weight: bold">
                                <div style="border-bottom: 1px solid black; margin-bottom: 10px"></div>
                                Signature of Applicant with date</td>

                            <td style="width: 53%"></td>

                            <td style="width: 23%; text-align: center; font-weight: bold">
                                <div style="border-bottom: 1px solid black; margin-bottom: 10px"></div>
                                <asp:Label ID="lbl_HOD" runat="server"></asp:Label><br />
                                Head of the Department
                            </td>
                        </tr>
                    </table>
                    <br />
                    <br />
                    <br />
                    <table style="text-align: left; font-family: Times New Roman; width: 100%">
                        <tr>
                            <td style="width: 23%; text-align: center; font-weight: bold">Sanctioned </td>

                            <td style="width: 53%"></td>

                            <td style="width: 23%; text-align: center; font-weight: bold">
                                <div style="border-bottom: 1px solid black; margin-bottom: 10px"></div>
                                Principal<br />
                                (<asp:Label ID="lbl_principal" runat="server" Style="font-weight: bold"></asp:Label>)</td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <br />
    </form>
</body>
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.js"></script>
<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.1/js/bootstrap.min.js"></script>
</html>
