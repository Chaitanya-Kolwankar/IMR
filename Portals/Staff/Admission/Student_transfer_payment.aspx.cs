using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.IO;

public partial class Student_transfer_payment : System.Web.UI.Page
{
    QueryClass qryCls = new QueryClass();
    Class1 cls = new Class1();
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
                    cls.chkPassword();
                    //qryCls.getayid(ddl_year);
                   // qryCls.getayid(ddlyear);
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("~/Portals/Staff/Login.aspx");
            }

        }
    }

    [WebMethod]
    public static stud_tarnsfer[] load_data(string ayid, string stud_id)
    {
        classWebMethods cls = new classWebMethods();
        return cls.load_data(ayid,stud_id);
    }
    [WebMethod]
    public static stud_tarnsfer[] save_data(string ayid, string stud_id,string group_id,string mode,string emp_id)
    {
        classWebMethods cls = new classWebMethods();
        return cls.save_data(ayid, stud_id,group_id,mode,emp_id);
    }
    [WebMethod]
    public static string check_seats(string ayid, string group_id)
    {
        classWebMethods cls = new classWebMethods();
        return cls.check_seats(ayid, group_id);
    }
    [System.Web.Services.WebMethod(enableSession: true)]
    public static void Setsession(string id)
    {
        HttpContext.Current.Session["id"] = id;

    }

    protected void btn_refresh_Click(object sender, EventArgs e)
    {
        Response.Redirect(Request.RawUrl);
    }
}
