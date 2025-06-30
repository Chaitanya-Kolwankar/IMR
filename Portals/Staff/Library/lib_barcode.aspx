<%@ Page Language="C#" AutoEventWireup="true" CodeFile="lib_barcode.aspx.cs" Inherits="lib_barcode" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

   <%-- <link href="vendors/bootstrap/dist/css/bootstrap.min.css" rel="stylesheet" />--%>
    <link href="../../../Assets/vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
 <%--   <script src="http://code.jquery.com/jquery-latest.min.js"></script>
    <script src="http://code.jquery.com/jquery-migrate-1.2.1.js"></script>--%>
   <%-- <script src="vendors/bootstrap/dist/js/bootstrap.js"></script>--%>

    <script src="../../../Assets/js/jquery_latest.js"></script>
    <script src="../../../Assets/js/jquery_migrate.js"></script>

    <script src="../../../Assets/vendor/bootstrap/js/bootstrap.js"></script>
    <%--<script src="js/jquery-min.js"></script>--%>
    <script src="../../../Assets/notify-master/js/notify.js"></script>
    <link href="../../../Assets/notify-master/css/notify.css" rel="stylesheet" />
   <%-- <script src="js/jquery.qrcode.min.js"></script>
    <script src="js/jquery-barcode.js"></script>--%>
    <script src="../../../Assets/js/jquery.qrcode.min.js"></script>
    <script src="../../../Assets/js/jquery-barcode.js"></script>
    <title></title>
        <style>
      
        .column {
  float: left;
  width: 25%;
}
    </style>
</head>
<body>
    <form id="Form1" runat="server">

<%--         <h2>Result:</h2>
        <img src="" id="image">--%>

        <div class="upperFont">
            <div class="row" style="margin-top:10px;">
                <div class="column" >
                    <%--<asp:PlaceHolder ID="plBarCode1" runat="server" />--%>
                    <center>
                        <div id="Div66" style="border:solid 1px;padding-top:5px" runat="server" visible="false">
                    <asp:Label ID="lbl_barcode1" runat="server" Style="display: none"></asp:Label>
                    <div id="Div1" runat="server"  ></div>
                   
                    
                                            <asp:Label ID="Label1" runat="server" Font-Size="Large"></asp:Label>
                            </div>
                    </center>
                    <%--<br />
                                         <asp:Image ID="qr_code1"  CssClass="image"  Width="120px" Height="50px" runat="server" />--%>
                </div>
                                    <div class="column" >

<center>                    <%--<asp:PlaceHolder ID="plBarCode1" runat="server" />--%>
                        <div id="Div68" style="border:solid 1px;padding-top:5px" visible="false" runat="server">

                    <asp:Label ID="lbl_barcode2" runat="server" Style="display: none"></asp:Label>
                                        <div id="Div2" runat="server"  ></div>

                    
                                                                                       <asp:Label ID="Label2" runat="server" Font-Size="Large"></asp:Label>

</div>    
    </center>

                    <%--<br />
                                         <asp:Image ID="qr_code1"  CssClass="image"  Width="120px" Height="50px" runat="server" />--%>
                </div>
                                  <div class="column" >

                    <%--<asp:PlaceHolder ID="plBarCode1" runat="server" />--%>
                      <center>
                        <div id="Div70" style="border:solid 1px;padding-top:5px" visible="false" runat="server">

                    <asp:Label ID="lbl_barcode3" runat="server" Style="display: none"></asp:Label>
                                       <div id="Div3" runat="server"  ></div>

                                                            
                    <asp:Label ID="Label3" runat="server" Font-Size="Large"></asp:Label>
                            </div>
                          </center>

                    <%--<br />
                                         <asp:Image ID="qr_code1"  CssClass="image"  Width="120px" Height="50px" runat="server" />--%>
                </div>
                <div class="column" >

                    <%--<asp:PlaceHolder ID="plBarCode1" runat="server" />--%>
                         <center>
                        <div id="Div72" style="border:solid 1px;padding-top:5px" visible="false" runat="server">

                    <asp:Label ID="lbl_barcode4" runat="server" Style="display: none"></asp:Label>
                                    <div id="Div4" runat="server"  ></div>

                    
                    <asp:Label ID="Label4" runat="server" Font-Size="Large"></asp:Label></div>
                             </center>

                    <%--<br />
                                         <asp:Image ID="qr_code1"  CssClass="image"  Width="120px" Height="50px" runat="server" />--%>
                </div>
            
            </div>
           <br />
            <div class="row">
                                     
                                <div class="column" >
                    <%--<asp:PlaceHolder ID="plBarCode1" runat="server" />--%>
                    <center>
                        <div id="Div37" style="border:solid 1px;padding-top:5px" visible="false" runat="server">

                    <asp:Label ID="lbl_barcode5" runat="server" Style="display: none"></asp:Label>
                    <div id="Div5"  ></div>
                                                          
                    <asp:Label ID="Label5" runat="server" Font-Size="Large"></asp:Label>
                            </div>
                        </center>

                    <%--<br />
                                         <asp:Image ID="qr_code1"  CssClass="image"  Width="120px" Height="50px" runat="server" />--%>
                </div>
                                  <div class="column" >
                    <%--<asp:PlaceHolder ID="plBarCode1" runat="server" />--%>
                      <center>
                        <div id="Div38" style="border:solid 1px;padding-top:5px" visible="false" runat="server">

                    <asp:Label ID="lbl_barcode6" runat="server" Style="display: none"></asp:Label>
                    <div id="Div6"  ></div>
                    
                    <asp:Label ID="Label6" runat="server" Font-Size="Large"></asp:Label></div>
                          </center>

                    <%--<br />
                                         <asp:Image ID="qr_code1"  CssClass="image"  Width="120px" Height="50px" runat="server" />--%>
                </div>
                               <div class="column" >
                    <%--<asp:PlaceHolder ID="plBarCode1" runat="server" />--%>
                           <center>
                        <div id="Div39" style="border:solid 1px;padding-top:5px" visible="false" runat="server">

                    <asp:Label ID="lbl_barcode7" runat="server" Style="display: none"></asp:Label>
                    <div id="Div7"  ></div>
                    
                    <asp:Label ID="Label7" runat="server" Font-Size="Large"></asp:Label></div>
                               </center>

                    <%--<br />
                                         <asp:Image ID="qr_code1"  CssClass="image"  Width="120px" Height="50px" runat="server" />--%>
                </div>
                                  <div class="column" >
                    <%--<asp:PlaceHolder ID="plBarCode1" runat="server" />--%>
                      <center>
                        <div id="Div40" style="border:solid 1px;padding-top:5px" visible="false" runat="server">

                    <asp:Label ID="lbl_barcode8" runat="server" Style="display: none"></asp:Label>
                    <div id="Div8"  ></div>
                    
                    <asp:Label ID="Label8" runat="server" Font-Size="Large"></asp:Label></div>
                          </center>

                    <%--<br />
                                         <asp:Image ID="qr_code1"  CssClass="image"  Width="120px" Height="50px" runat="server" />--%>
                </div>
         
            </div>
           <br />
            <div class="row">
                        
                                <div class="column" >
                    <%--<asp:PlaceHolder ID="plBarCode1" runat="server" />--%>
                    <center>
                        <div id="Div41" style="border:solid 1px;padding-top:5px" visible="false" runat="server">

                    <asp:Label ID="lbl_barcode9" runat="server" Style="display: none"></asp:Label>
                    <div id="Div9"  ></div>
                    
                    <asp:Label ID="Label9" runat="server" Font-Size="Large"></asp:Label></div>
                        </center>

                    <%--<br />
                                         <asp:Image ID="qr_code1"  CssClass="image"  Width="120px" Height="50px" runat="server" />--%>
                </div>
                       <div class="column" >
                    <%--<asp:PlaceHolder ID="plBarCode1" runat="server" />--%>
                      <center>
                        <div id="Div42" style="border:solid 1px;padding-top:5px" visible="false" runat="server">

                    <asp:Label ID="lbl_barcode10" runat="server" Style="display: none"></asp:Label>
                    <div id="Div10"  ></div>
                    
                    <asp:Label ID="Label10" runat="server" Font-Size="Large"></asp:Label>
                            </div>                         </center>

                    <%--<br />
                                         <asp:Image ID="qr_code1"  CssClass="image"  Width="120px" Height="50px" runat="server" />--%>
                </div>
                                     <div class="column" >
                    <%--<asp:PlaceHolder ID="plBarCode1" runat="server" />--%>
                         <center>
                        <div id="Div43" style="border:solid 1px;padding-top:5px" visible="false" runat="server">

                    <asp:Label ID="lbl_barcode11" runat="server" Style="display: none"></asp:Label>
                    <div id="Div11"  ></div>
                    
                    <asp:Label ID="Label11" runat="server" Font-Size="Large"></asp:Label></div>
                             </center>

                    <%--<br />
                                         <asp:Image ID="qr_code1"  CssClass="image"  Width="120px" Height="50px" runat="server" />--%>
                </div>
                                  <div class="column" >
                    <%--<asp:PlaceHolder ID="plBarCode1" runat="server" />--%>
                      <center>
                        <div id="Div44" style="border:solid 1px;padding-top:5px" visible="false" runat="server">

                    <asp:Label ID="lbl_barcode12" runat="server" Style="display: none"></asp:Label>
                    <div id="Div12"  ></div>
                    
                    <asp:Label ID="Label12" runat="server" Font-Size="Large"></asp:Label>
                            </div>
                          </center>

                    <%--<br />
                                         <asp:Image ID="qr_code1"  CssClass="image"  Width="120px" Height="50px" runat="server" />--%>
                </div>
                </div>
            <br />
            
            <div class="row">
                                <div class="column" >
                    <%--<asp:PlaceHolder ID="plBarCode1" runat="server" />--%>
                    <center>
                        <div id="Div45" style="border:solid 1px;padding-top:5px" visible="false" runat="server">

                    <asp:Label ID="lbl_barcode13" runat="server" Style="display: none"></asp:Label>
                    <div id="Div13"  ></div>
                    
                    <asp:Label ID="Label13" runat="server" Font-Size="Large"></asp:Label>
                            </div>
                        </center>

                    <%--<br />
                                         <asp:Image ID="qr_code1"  CssClass="image"  Width="120px" Height="50px" runat="server" />--%>
                </div>
                                      <div class="column" >
                    <%--<asp:PlaceHolder ID="plBarCode1" runat="server" />--%>
                          <center>
                        <div id="Div46" style="border:solid 1px;padding-top:5px" visible="false" runat="server">

                    <asp:Label ID="lbl_barcode14" runat="server" Style="display: none"></asp:Label>
                    <div id="Div14"  ></div>
                    
                    <asp:Label ID="Label14" runat="server" Font-Size="Large"></asp:Label></div>
                              </center>

                    <%--<br />
                                         <asp:Image ID="qr_code1"  CssClass="image"  Width="120px" Height="50px" runat="server" />--%>
                </div>
                                       <div class="column" >
                    <%--<asp:PlaceHolder ID="plBarCode1" runat="server" />--%>
                           <center>
                        <div id="Div47" style="border:solid 1px;padding-top:5px" visible="false" runat="server">

                    <asp:Label ID="lbl_barcode15" runat="server" Style="display: none"></asp:Label>
                    <div id="Div15"  ></div>
                    
                    <asp:Label ID="Label15" runat="server" Font-Size="Large"></asp:Label></div>
                               </center>

                    <%--<br />
                                         <asp:Image ID="qr_code1"  CssClass="image"  Width="120px" Height="50px" runat="server" />--%>
                </div>
                    <div class="column" >
                    <%--<asp:PlaceHolder ID="plBarCode1" runat="server" />--%>
                        <center>
                        <div id="Div48" style="border:solid 1px;padding-top:5px" visible="false" runat="server">

                    <asp:Label ID="lbl_barcode16" runat="server" Style="display: none"></asp:Label>
                    <div id="Div16"  ></div>
                    
                    <asp:Label ID="Label16" runat="server" Font-Size="Large"></asp:Label></div>
                            </center>

                    <%--<br />
                                         <asp:Image ID="qr_code1"  CssClass="image"  Width="120px" Height="50px" runat="server" />--%>
                </div>
                   
            </div>
          <br />
            <div class="row">
                                
                                <div class="column" >
                    <%--<asp:PlaceHolder ID="plBarCode1" runat="server" />--%>
                    <center>
                        <div id="Div49" style="border:solid 1px;padding-top:5px" visible="false" runat="server">

                    <asp:Label ID="lbl_barcode17" runat="server" Style="display: none"></asp:Label>
                    <div id="Div17"  ></div>
                    
                    <asp:Label ID="Label17" runat="server" Font-Size="Large"></asp:Label></div>
                        </center>

                    <%--<br />
                                         <asp:Image ID="qr_code1"  CssClass="image"  Width="120px" Height="50px" runat="server" />--%>
                </div>
                                     <div class="column" >
                    <%--<asp:PlaceHolder ID="plBarCode1" runat="server" />--%>
                         <center>
                        <div id="Div50" style="border:solid 1px;padding-top:5px" visible="false" runat="server">

                    <asp:Label ID="lbl_barcode18" runat="server" Style="display: none"></asp:Label>
                    <div id="Div18"  ></div>
                    
                    <asp:Label ID="Label18" runat="server" Font-Size="Large"></asp:Label></div>
                             </center>

                    <%--<br />
                                         <asp:Image ID="qr_code1"  CssClass="image"  Width="120px" Height="50px" runat="server" />--%>
                </div>
                       <div class="column" >
                    <%--<asp:PlaceHolder ID="plBarCode1" runat="server" />--%>
                      <center>
                        <div id="Div51" style="border:solid 1px;padding-top:5px" visible="false" runat="server">

                    <asp:Label ID="lbl_barcode19" runat="server" Style="display: none"></asp:Label>
                    <div id="Div19"  ></div>
                    
                    <asp:Label ID="Label19" runat="server" Font-Size="Large"></asp:Label></div>
                          </center>

                    <%--<br />
                                         <asp:Image ID="qr_code1"  CssClass="image"  Width="120px" Height="50px" runat="server" />--%>
                </div>
                                        <div class="column" >
                    <%--<asp:PlaceHolder ID="plBarCode1" runat="server" />--%>
                            <center>
                        <div id="Div52" style="border:solid 1px;padding-top:5px" visible="false" runat="server">

                    <asp:Label ID="lbl_barcode20" runat="server" Style="display: none"></asp:Label>
                    <div id="Div20"  ></div>
                    
                    <asp:Label ID="Label20" runat="server" Font-Size="Large"></asp:Label></div>

                                </center>
                    <%--<br />
                                         <asp:Image ID="qr_code1"  CssClass="image"  Width="120px" Height="50px" runat="server" />--%>
                </div>
                
            </div>
            <br />
            <div class="row">
                           
                                <div class="column" >
                    <%--<asp:PlaceHolder ID="plBarCode1" runat="server" />--%>
                    <center>
                        <div id="Div53" style="border:solid 1px;padding-top:5px" visible="false" runat="server">

                    <asp:Label ID="lbl_barcode21" runat="server" Style="display: none"></asp:Label>
                    <div id="Div21"  ></div>
                    
                    <asp:Label ID="Label21" runat="server" Font-Size="Large"></asp:Label>
                            </div>
                        </center>

                    <%--<br />
                                         <asp:Image ID="qr_code1"  CssClass="image"  Width="120px" Height="50px" runat="server" />--%>
                </div>
                   <div class="column" >
                    <%--<asp:PlaceHolder ID="plBarCode1" runat="server" />--%>
                      <center>
                        <div id="Div54" style="border:solid 1px;padding-top:5px" visible="false" runat="server">

                    <asp:Label ID="lbl_barcode22" runat="server" Style="display: none"></asp:Label>
                    <div id="Div22"></div>
                    
                    <asp:Label ID="Label22" runat="server" Font-Size="Large"></asp:Label>
                            </div>
                          </center>

                    <%--<br />
                                         <asp:Image ID="qr_code1"  CssClass="image"  Width="120px" Height="50px" runat="server" />--%>
                </div>
                                  <div class="column" >
                    <%--<asp:PlaceHolder ID="plBarCode1" runat="server" />--%>
                      <center>
                        <div id="Div55" style="border:solid 1px;padding-top:5px" visible="false" runat="server">

                    <asp:Label ID="lbl_barcode23" runat="server" Style="display: none"></asp:Label>
                    <div id="Div23"></div>
                    
                    <asp:Label ID="Label23" runat="server" Font-Size="Large"></asp:Label></div>
                          </center>

                    <%--<br />
                                         <asp:Image ID="qr_code1"  CssClass="image"  Width="120px" Height="50px" runat="server" />--%>
                </div>
                                                <div class="column" >
                    <%--<asp:PlaceHolder ID="plBarCode1" runat="server" />--%>
                                    <center>
                        <div id="Div56" style="border:solid 1px;padding-top:5px" visible="false" runat="server">

                    <asp:Label ID="lbl_barcode24" runat="server" Style="display: none"></asp:Label>
                    <div id="Div24"></div>
                    
                    <asp:Label ID="Label24" runat="server" Font-Size="Large"></asp:Label>

                            </div>
                                        </center>

                    <%--<br />
                                         <asp:Image ID="qr_code1"  CssClass="image"  Width="120px" Height="50px" runat="server" />--%>
                </div>
                </div>
            <br />
        
            <div class="row">
                                <div class="column" >
                    <%--<asp:PlaceHolder ID="plBarCode1" runat="server" />--%>
                    <center>
                        <div id="Div57" style="border:solid 1px;padding-top:5px" visible="false" runat="server">

                    <asp:Label ID="lbl_barcode25" runat="server" Style="display: none"></asp:Label>
                    <div id="Div25"  ></div>
                    
                    <asp:Label ID="Label25" runat="server" Font-Size="Large"></asp:Label></div>
                        </center>

                    <%--<br />
                                         <asp:Image ID="qr_code1"  CssClass="image"  Width="120px" Height="50px" runat="server" />--%>
                </div>
                                   <div class="column" >
                    <%--<asp:PlaceHolder ID="plBarCode1" runat="server" />--%>
                       <center>
                        <div id="Div58" style="border:solid 1px;padding-top:5px" visible="false" runat="server">

                    <asp:Label ID="lbl_barcode26" runat="server" Style="display: none"></asp:Label>
                    <div id="Div26"  ></div>
                    
                    <asp:Label ID="Label26" runat="server" Font-Size="Large"></asp:Label></div>
                           </center >

                    <%--<br />
                                         <asp:Image ID="qr_code1"  CssClass="image"  Width="120px" Height="50px" runat="server" />--%>
                </div>
                                     <div class="column" >
                    <%--<asp:PlaceHolder ID="plBarCode1" runat="server" />--%>
                         <center>
                        <div id="Div59" style="border:solid 1px;padding-top:5px" visible="false" runat="server">

                    <asp:Label ID="lbl_barcode27" runat="server" Style="display: none"></asp:Label>
                    <div id="Div27"></div>
                    
                    <asp:Label ID="Label27" runat="server" Font-Size="Large"></asp:Label></div>
                             </center>

                    <%--<br />
                                         <asp:Image ID="qr_code1"  CssClass="image"  Width="120px" Height="50px" runat="server" />--%>
                </div>
                 <div class="column" >
                    <%--<asp:PlaceHolder ID="plBarCode1" runat="server" />--%>
                       <center>
                        <div id="Div60" style="border:solid 1px;padding-top:5px" visible="false" runat="server">

                    <asp:Label ID="lbl_barcode28" runat="server" Style="display: none"></asp:Label>
                    <div id="Div28"  ></div>
                    
                    <asp:Label ID="Label28" runat="server" Font-Size="Large"></asp:Label></div>
                           </center>

                    <%--<br />
                                         <asp:Image ID="qr_code1"  CssClass="image"  Width="120px" Height="50px" runat="server" />--%>
                </div>
                
            </div>
           <br />
            <div class="row">
                                  
                                <div class="column" >
                    <%--<asp:PlaceHolder ID="plBarCode1" runat="server" />--%>
                    <center>
                        <div id="Div61" style="border:solid 1px;padding-top:5px" visible="false" runat="server">

                    <asp:Label ID="lbl_barcode29" runat="server" Style="display: none"></asp:Label>
                    <div id="Div29"  ></div>
                    
                    <asp:Label ID="Label29" runat="server" Font-Size="Large"></asp:Label></div>
                        </center>

                    <%--<br />
                                         <asp:Image ID="qr_code1"  CssClass="image"  Width="120px" Height="50px" runat="server" />--%>
                </div>
                                     <div class="column" >
                    <%--<asp:PlaceHolder ID="plBarCode1" runat="server" />--%>
                         <center>
                        <div id="Div62" style="border:solid 1px;padding-top:5px" visible="false" runat="server">

                    <asp:Label ID="lbl_barcode30" runat="server" Style="display: none"></asp:Label>
                    <div id="Div30"  ></div>
                    
                    <asp:Label ID="Label30" runat="server" Font-Size="Large"></asp:Label></div>
                             </center>

                    <%--<br />
                                         <asp:Image ID="qr_code1"  CssClass="image"  Width="120px" Height="50px" runat="server" />--%>
                </div>
                 <div class="column" >
                    <%--<asp:PlaceHolder ID="plBarCode1" runat="server" />--%>
                             <center>
                        <div id="Div63" style="border:solid 1px;padding-top:5px" visible="false" runat="server">

                    <asp:Label ID="lbl_barcode31" runat="server" Style="display: none"></asp:Label>
                    <div id="Div31"  ></div>
                    
                    <asp:Label ID="Label31" runat="server" Font-Size="Large"></asp:Label></div>
                                 </center>

                    <%--<br />
                                         <asp:Image ID="qr_code1"  CssClass="image"  Width="120px" Height="50px" runat="server" />--%>
                </div>

                                <div class="column" >
                    <%--<asp:PlaceHolder ID="plBarCode1" runat="server" />--%>
                    <center>
                        <div id="Div64" style="border:solid 1px;padding-top:5px" visible="false" runat="server">

                    <asp:Label ID="lbl_barcode32" runat="server" Style="display: none"></asp:Label>
                    <div id="Div32"  ></div>
                    
                    <asp:Label ID="Label32" runat="server" Font-Size="Large"></asp:Label></div>
                        </center>

                    <%--<br />
                                         <asp:Image ID="qr_code1"  CssClass="image"  Width="120px" Height="50px" runat="server" />--%>
                   <%-- <svg></svg>--%>
                </div></div>
             <br />
            <div class="row">
                                  
                                <div class="column" >
                    <%--<asp:PlaceHolder ID="plBarCode1" runat="server" />--%>
                    <center>
                        <div id="Div65" style="border:solid 1px;padding-top:5px" visible="false" runat="server">

                    <asp:Label ID="lbl_barcode33" runat="server" Style="display: none"></asp:Label>
                    <div id="Div33"  ></div>
                    
                    <asp:Label ID="Label33" runat="server" Font-Size="Large"></asp:Label></div>
                        </center>

                    <%--<br />
                                         <asp:Image ID="qr_code1"  CssClass="image"  Width="120px" Height="50px" runat="server" />--%>
                </div>
                                     <div class="column" >
                    <%--<asp:PlaceHolder ID="plBarCode1" runat="server" />--%>
                         <center>
                        <div id="Div67" style="border:solid 1px;padding-top:5px" visible="false" runat="server">

                    <asp:Label ID="lbl_barcode34" runat="server" Style="display: none"></asp:Label>
                    <div id="Div34"  ></div>
                    
                    <asp:Label ID="Label34" runat="server" Font-Size="Large"></asp:Label></div>
                             </center>

                    <%--<br />
                                         <asp:Image ID="qr_code1"  CssClass="image"  Width="120px" Height="50px" runat="server" />--%>
                </div>
                 <div class="column" >
                    <%--<asp:PlaceHolder ID="plBarCode1" runat="server" />--%>
                             <center>
                        <div id="Div69" style="border:solid 1px;padding-top:5px" visible="false" runat="server">

                    <asp:Label ID="lbl_barcode35" runat="server" Style="display: none"></asp:Label>
                    <div id="Div35"  ></div>
                    
                    <asp:Label ID="Label35" runat="server" Font-Size="Large"></asp:Label></div>
                                 </center>

                    <%--<br />
                                         <asp:Image ID="qr_code1"  CssClass="image"  Width="120px" Height="50px" runat="server" />--%>
                </div>

                                <div class="column" >
                    <%--<asp:PlaceHolder ID="plBarCode1" runat="server" />--%>
                    <center>
                        <div id="Div71" style="border:solid 1px;padding-top:5px" visible="false" runat="server">

                    <asp:Label ID="lbl_barcode36" runat="server" Style="display: none"></asp:Label>
                    <div id="Div36"  ></div>
                    
                    <asp:Label ID="Label36" runat="server" Font-Size="Large"></asp:Label></div>
                        </center>

                    <%--<br />
                                         <asp:Image ID="qr_code1"  CssClass="image"  Width="120px" Height="50px" runat="server" />--%>
                   <%-- <svg></svg>--%>
                </div></div>
                        
                    
            </div>
          

      <%--  <div style="page-break-after: always"></div>--%>
    </form>
</body>
<script src="../../../Assets/vendor/bootstrap/js/shafeen_barcode.js"></script>
<%--<script src="js/shafeen_barcode.js"></script>--%>
    <%--<script>
        $(document).ready(function () {

            window.print();

        });
</script>--%>
<script type="text/javascript">
    
      var accession = '<%=Session["Accessprint"] %>'
   // var accession = "bit3535,bit3536";
         var val = accession.split(",");
        //var val = "bit3535";
        for (var i = 1; i <= val.length; i++) {
            //$.ajax({
            //    type: "POST",
            //    url: 'lib_barcode.aspx/barcodejs',
            //    data: '{id:"'+val[i]+'"}',
            //    contentType: "application/json; charset=utf-8",
            //    dataType: "json",
            //    success: function (msg) {


                    //$.ajax({
                    //    type: "POST",
                    //    url: "lib_barcode.aspx/barcodejs",
                    //    data: '{id:"' + val[i]+ '"}',
                    //    contentType: "application/json; charset=utf-8",
                    //    success: function (r) {
                    //$("#lbl_barcode" + i + "").val(val[i]);
                    //$("#Label" + i + "").val(val[i]);
                    $("#Div" + i + "").barcode($("#lbl_barcode" + i + "").text(), "code39");
                  //  $("[id*='Div" + i + "']").trigger('click');
            //    },
            //    error: function (e) {
            //       // $("#divResult").html("Something Wrong.");
            //    }
            //});
          
        
        }

        //$("#bctarget2").barcode($("#lbl_barcode").text(), "code39");

</script>
<script>
    $(document).ready(function () {
        // var stud_data = "Student Id:" + $("#lbl_stud_id").text() + "\n Name:" + $("#lblName").text() + "\n Class:" + $('#lblCourse').text();

        // $("#bcTarget").barcode($("#lblstud_id").text(), "codabar");




        window.print();

    });
</script>
</html>
