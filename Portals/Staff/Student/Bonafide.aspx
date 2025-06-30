<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Bonafide.aspx.cs" Inherits="Portals_Staff_Student_Bonafide" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .ptable {
            justify-items: center;
            width: 80%;
            margin: auto;
        }

        .ctable {
            justify-items: center;
            width: 100%;
            margin: auto;
        }
        body {
            font-family:'Constantia';
            font-size: 22px;
            text-align:justify;
            margin-right:45PX;
            margin-left:45PX;
           
        }
        p {
           
           /* letter-spacing:1px;*/
            line-height:1.7
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">

        <%--    <table id="parent" runat="server" class="">
            <tr>
                <td>--%>
     <%--   <table id="fisrttable" runat="server" style="width: 100%">
            <tr>
                <td>--%>
                    <center>
                        <img src="../../../MANAGEMENT-AND-RESEARCH.jpg" style="width: 100%" />

                        <hr />
                        <h2 style="text-decoration: underline; text-align: center">BONAFIDE CERTIFICATE</h2>
                    </center>
                    <table id="main_tbl" runat="server" class="ctable">
                        <tr>
                            <td>
                                <span style="font-weight:bold">No. </span><span>
                                <asp:Label ID="no" runat="server" Style=" font-family:'Times New Roman';width:100%">                   
                                </asp:Label></span>
                            </td>
                        <%--    <td style="width: 30%"></td>--%>
                            <td style="text-align:end"><span><span style="font-weight:bold">Date:-</span> 
                                <asp:Label ID="date" runat="server" Style="font-family:'Times New Roman' ">   
                                </asp:Label>
                                </span>
                            </td>
                        
                         </tr>


                    </table>
        <br />
        <p> &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp This is to certify that <%--Master / Miss--%><span  id="mas_mis" runat="server"></span>
                    <asp:Label ID="master_miss" runat="server" Style=" text-transform: capitalize ;font-weight:bold"></asp:Label>
                <span id="is_was" runat="server"></span> a bonafide student of this college, studying in <asp:Label ID="FY_SY" runat="server" Style="text-transform: capitalize; font-family:'Times New Roman';font-weight:bold"></asp:Label>
                             
                          
                  in the academic year
                    <asp:Label runat="server" ID="acd_year" Style=" font-weight: bold;font-family:'Times New Roman'"></asp:Label>.<br />
                             <span runat="server" id="his_her"></span> date of birth is
                    <asp:Label ID="dob" runat="server" Style=" font-weight: bold;font-family:'Times New Roman'"></asp:Label>
                                
                            (in words)&nbsp;&nbsp<asp:Label runat="server" ID="inwotds" Style=" font-weight: bold"></asp:Label>
                                as recorded in the Institute  General Register. 
         <br />
            <br />
                         &nbsp&nbsp&nbsp &nbsp&nbsp &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp  <span id="his_her2" runat="server"></span> bears a good  moral Character.
           </p>
                          
                   <br />
                     
                                <p style="font-weight: bold; text-align:end">PRINCIPAL</p>


        <%--</td>



            </tr>
        </table>
        --%>
    </form>
    <script type="text/javascript">
       
    </script>
</body>
</html>
