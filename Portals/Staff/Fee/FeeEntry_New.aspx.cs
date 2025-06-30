using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.IO;

public partial class FeeEntry_New : System.Web.UI.Page
{
    Class1 cls1 = new Class1();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                if (Convert.ToString(Session["emp_id"]) == "")
                {
                    

                        Response.Redirect("~/Portals/Staff/Login.aspx");
                    
                }
                else
                {
                    cls1.chkPassword();

                    string ss = (string)HttpContext.Current.Session["id"];
                    if (ss != null)
                    {
                        string[] arr = ss.Split('|');
                        Session["id"] = arr[0].ToUpper().ToString().Trim();
                        txt_studid.Value = Session["id"].ToString();
                        searchstudentfee(Session["id"].ToString(), Session["emp_id"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("~/Portals/Staff/Login.aspx");
            }
        }
    }

    [WebMethod]
    public static studentmodify[] searchstudentfee(string stud_id, string empid)
    {
        classWebMethods webCls = new classWebMethods();
        return webCls.searchstudentfee(stud_id, empid);
    }

    [WebMethod]
    public static STUDENTFEES[] getstudentfee(string stud_id, string group_id, string caste, string year)
    {
        classWebMethods webCls = new classWebMethods();
        return webCls.getstudentfee(stud_id, group_id, caste, year);
    }

    [WebMethod]
    public static STUDENTFEES[] getdropstudentfee(string stud_id, string group_id, string caste, string year, string dropyear)
    {
        classWebMethods webCls = new classWebMethods();
        return webCls.getdropstudentfee(stud_id, group_id, caste, year, dropyear);
    }

    [WebMethod]
    public static STUDENTFEES[] StrudentFeeDetails(string stud_id, string year, string group_id)
    {
        classWebMethods webCls = new classWebMethods();
        return webCls.StrudentFeeDetails(stud_id, year, group_id);
    }

    [WebMethod]
    public static STUDENTFEES[] getreceiptno(string year, string type)
    {
        classWebMethods webCls = new classWebMethods();
        return webCls.getreceiptno(year, type);
    }

    [WebMethod]
    public static bool receipt_type(string stud_id, string year, string recipt_no)
    {
        classWebMethods webCls = new classWebMethods();
        return webCls.receipt_type(stud_id, year, recipt_no);
    }

    [WebMethod]
    public static STUDENTFEES[] getFeeDetails(string stud_id, string year, string recipt_no,string caste)
    {
        classWebMethods webCls = new classWebMethods();
        return webCls.getFeeDetails(stud_id, year, recipt_no, caste);
    }

    [WebMethod]
    public static bool saveData(string qry)
    {
        classWebMethods webCls = new classWebMethods();
        return webCls.saveData(qry);
    }

    [WebMethod]
    public static List<ListItem> getayidadm()
    {
        classWebMethods webCls = new classWebMethods();
        QueryClass qryCls = new QueryClass();
        return webCls.getayidadm();
    }

    [System.Web.Services.WebMethod(enableSession: true)]
    public static void Setsession(string id)
    {
        HttpContext.Current.Session["id"] = id;
    }

    [WebMethod]
    public static List<ListItem> fillremark()
    {
        classWebMethods webCls = new classWebMethods();
        QueryClass qryCls = new QueryClass();
        return webCls.fillremark();
    }

    
}