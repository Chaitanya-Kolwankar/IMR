using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MessagingToolkit.QRCode.Codec;
using MessagingToolkit.QRCode.Codec.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Data;
using System.Data.SqlClient;
using System.Security.Policy;
using System.Configuration;
using System.IO;
using System.Web.Services;
public partial class lib_barcode : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string str = Session["Accessprint"].ToString();
       // string str = "bit3535,bit3536";
        string[] str1;
        str1 = str.Split(',');
        int i = 0;
        for (int j = 0; j < str1.Length; j++)
        {
            if (j == 0) { lbl_barcode1.Text = str1[j]; Label1.Text = str1[j]; barcode(str1[j]); Div66.Visible = true; }
            else if (j == 1 && i <= str1.Length) { lbl_barcode2.Text = str1[j]; Label2.Text = str1[j]; barcode(str1[j]); Div68.Visible = true; }
            else if (j == 2 && i <= str1.Length) { lbl_barcode3.Text = str1[j]; Label3.Text = str1[j]; barcode(str1[j]); Div70.Visible = true; }
            else if (j == 3 && i <= str1.Length) { lbl_barcode4.Text = str1[j]; Label4.Text = str1[j]; barcode(str1[j]); Div72.Visible = true; }
            else if (j == 4 && i <= str1.Length) { lbl_barcode5.Text = str1[j]; Label5.Text = str1[j]; barcode(str1[j]); Div37.Visible = true; }
            else if (j == 5 && i <= str1.Length) { lbl_barcode6.Text = str1[j]; Label6.Text = str1[j]; barcode(str1[j]); Div38.Visible = true; }
            else if (j == 6 && i <= str1.Length) { lbl_barcode7.Text = str1[j]; Label7.Text = str1[j]; barcode(str1[j]); Div39.Visible = true; }
            else if (j == 7 && i <= str1.Length) { lbl_barcode8.Text = str1[j]; Label8.Text = str1[j]; barcode(str1[j]); Div40.Visible = true; }
            else if (j == 8 && i <= str1.Length) { lbl_barcode9.Text = str1[j]; Label9.Text = str1[j]; barcode(str1[j]); Div41.Visible = true; }
            else if (j == 9 && i <= str1.Length) { lbl_barcode10.Text = str1[j]; Label10.Text = str1[j]; barcode(str1[j]); Div42.Visible = true; }
            else if (j == 10 && i <= str1.Length) { lbl_barcode11.Text = str1[j]; Label11.Text = str1[j]; barcode(str1[j]); Div43.Visible = true; }
            else if (j == 11 && i <= str1.Length) { lbl_barcode12.Text = str1[j]; Label12.Text = str1[j]; barcode(str1[j]); Div44.Visible = true; }
            else if (j == 12 && i <= str1.Length) { lbl_barcode13.Text = str1[j]; Label13.Text = str1[j]; barcode(str1[j]); Div45.Visible = true; }
            else if (j == 13 && i <= str1.Length) { lbl_barcode14.Text = str1[j]; Label14.Text = str1[j]; barcode(str1[j]); Div46.Visible = true; }
            else if (j == 14 && i <= str1.Length) { lbl_barcode15.Text = str1[j]; Label15.Text = str1[j]; barcode(str1[j]); Div47.Visible = true; }
            else if (j == 15 && i <= str1.Length) { lbl_barcode16.Text = str1[j]; Label16.Text = str1[j]; barcode(str1[j]); Div48.Visible = true; }
            else if (j == 16 && i <= str1.Length) { lbl_barcode17.Text = str1[j]; Label17.Text = str1[j]; barcode(str1[j]); Div49.Visible = true; }
            else if (j == 17 && i <= str1.Length) { lbl_barcode18.Text = str1[j]; Label18.Text = str1[j]; barcode(str1[j]); Div50.Visible = true; }
            else if (j == 18 && i <= str1.Length) { lbl_barcode19.Text = str1[j]; Label19.Text = str1[j]; barcode(str1[j]); Div51.Visible = true; }
            else if (j == 19 && i <= str1.Length) { lbl_barcode20.Text = str1[j]; Label20.Text = str1[j]; barcode(str1[j]); Div52.Visible = true; }
            else if (j == 20 && i <= str1.Length) { lbl_barcode21.Text = str1[j]; Label21.Text = str1[j]; barcode(str1[j]); Div53.Visible = true; }
            else if (j == 21 && i <= str1.Length) { lbl_barcode22.Text = str1[j]; Label22.Text = str1[j]; barcode(str1[j]); Div54.Visible = true; }
            else if (j == 22 && i <= str1.Length) { lbl_barcode23.Text = str1[j]; Label23.Text = str1[j]; barcode(str1[j]); Div55.Visible = true; }
            else if (j == 23 && i <= str1.Length) { lbl_barcode24.Text = str1[j]; Label24.Text = str1[j]; barcode(str1[j]); Div56.Visible = true; }
            else if (j == 24 && i <= str1.Length) { lbl_barcode25.Text = str1[j]; Label25.Text = str1[j]; barcode(str1[j]); Div57.Visible = true; }
            else if (j == 25 && i <= str1.Length) { lbl_barcode26.Text = str1[j]; Label26.Text = str1[j]; barcode(str1[j]); Div58.Visible = true; }
            else if (j == 26 && i <= str1.Length) { lbl_barcode27.Text = str1[j]; Label27.Text = str1[j]; barcode(str1[j]); Div59.Visible = true; }
            else if (j == 27 && i <= str1.Length) { lbl_barcode28.Text = str1[j]; Label28.Text = str1[j]; barcode(str1[j]); Div60.Visible = true; }
            else if (j == 28 && i <= str1.Length) { lbl_barcode29.Text = str1[j]; Label29.Text = str1[j]; barcode(str1[j]); Div61.Visible = true; }
            else if (j == 29 && i <= str1.Length) { lbl_barcode30.Text = str1[j]; Label30.Text = str1[j]; barcode(str1[j]); Div62.Visible = true; }
            else if (j == 30 && i <= str1.Length) { lbl_barcode31.Text = str1[j]; Label31.Text = str1[j]; barcode(str1[j]); Div63.Visible = true; }
            else if (j == 31 && i <= str1.Length) { lbl_barcode32.Text = str1[j]; Label32.Text = str1[j]; barcode(str1[j]); Div64.Visible = true; }
            else if (j == 32 && i <= str1.Length) { lbl_barcode33.Text = str1[j]; Label33.Text = str1[j]; barcode(str1[j]); Div65.Visible = true; }
            else if (j == 33 && i <= str1.Length) { lbl_barcode34.Text = str1[j]; Label34.Text = str1[j]; barcode(str1[j]); Div67.Visible = true; }
            else if (j == 34 && i <= str1.Length) { lbl_barcode35.Text = str1[j]; Label35.Text = str1[j]; barcode(str1[j]); Div69.Visible = true; }
            else if (j == 35 && i <= str1.Length) { lbl_barcode36.Text = str1[j]; Label36.Text = str1[j]; barcode(str1[j]); Div71.Visible = true; }

            //else if (j == 32 && i <= str1.Length) { lbl_barcode32.Text = str1[j]; Label32.Text = str1[j]; barcode(str1[j]); Div63.Visible = true; }
        }
        
    }
    public void barcode(string id)
    {
        string barCode = id;
        System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
        using (Bitmap bitMap = new Bitmap(barCode.Length * 40, 80))
        {
            using (Graphics graphics = Graphics.FromImage(bitMap))
            {

                Font oFont = new Font("IDAutomationHC39M", 16);
                //Font oFont = new Font("IDAutomationHC39M", 16);
                PointF point = new PointF(2f, 2f);
                SolidBrush blackBrush = new SolidBrush(Color.Black);
                SolidBrush whiteBrush = new SolidBrush(Color.White);
                graphics.FillRectangle(whiteBrush, 0, 0, bitMap.Width, bitMap.Height);
                graphics.DrawString("*" + barCode + "*", oFont, blackBrush, point);
            }
            using (MemoryStream ms = new MemoryStream())
            {
                bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                byte[] byteImage = ms.ToArray();

                Convert.ToBase64String(byteImage);
                imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
            }
            //plBarCode2.Controls.Add(imgBarCode);

        }
    }
    public static byte[] ImageToByte2(System.Drawing.Image img)
    {
        byte[] byteArray = new byte[0];
        using (MemoryStream stream = new MemoryStream())
        {
            img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
            stream.Close();

            byteArray = stream.ToArray();
        }
        return byteArray;
    }

    //[WebMethod]
    //public static bool barcodejs(string id)
    //{
    //  // barcode(id);
    //   string barCode = id;
    //   System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
    //   using (Bitmap bitMap = new Bitmap(barCode.Length * 40, 80))
    //   {
    //       using (Graphics graphics = Graphics.FromImage(bitMap))
    //       {

    //           Font oFont = new Font("IDAutomationHC39M", 16);
    //           //Font oFont = new Font("IDAutomationHC39M", 16);
    //           PointF point = new PointF(2f, 2f);
    //           SolidBrush blackBrush = new SolidBrush(Color.Black);
    //           SolidBrush whiteBrush = new SolidBrush(Color.White);
    //           graphics.FillRectangle(whiteBrush, 0, 0, bitMap.Width, bitMap.Height);
    //           graphics.DrawString("*" + barCode + "*", oFont, blackBrush, point);
    //       }
    //       using (MemoryStream ms = new MemoryStream())
    //       {
    //           bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
    //           byte[] byteImage = ms.ToArray();

    //           Convert.ToBase64String(byteImage);
    //           imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
    //       }
    //       //plBarCode2.Controls.Add(imgBarCode);

    //   }
    //    return true;
    //}

}