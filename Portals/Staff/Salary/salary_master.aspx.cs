using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class salary_master : System.Web.UI.Page
{
    QueryClass qryCls = new QueryClass();
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
            }
            catch (Exception ex)
            {
                Response.Redirect("~/Portals/Staff/Login.aspx");
            }
        }
    }
    [WebMethod]
    public static salarydetails getdetails(empsalary obj)
    {
        string msg="";
        return new classWebMethods().empdetails(obj,msg);
    }

    [WebMethod]
    public static salarydetails savesalary(empsalary obj)
    {
        string msg = new classWebMethods().savesalary(obj);
        if (msg == "saved")
        {
            return new classWebMethods().empdetails(obj, msg);
        }
        else
        {
            return new classWebMethods().nodata();
        }
    }

    [WebMethod]
    public static salarydetails deleteuser(empsalary obj)
    {
        string msg = new classWebMethods().deleteuser(obj);
        if (msg == "deleted")
        {
            return new classWebMethods().empdetails(obj, msg);
        }
        else
        {
            return new classWebMethods().nodata();
        }
    }

    [WebMethod]
    public static salarydetails deletesalary(empsalary obj)
    {
        string msg = new classWebMethods().deletesalary(obj);
        if (msg == "deleted")
        {
            return new classWebMethods().empdetails(obj, msg);
        }
        else
        {
            return new classWebMethods().nodata();
        }
    }

    [WebMethod]
    public static salarydetails updatesalary(empsalary obj)
    {
        string msg = new classWebMethods().updatesalary(obj);
        if (msg == "updated")
        {
            return new classWebMethods().empdetails(obj, msg);
        }
        else
        {
            return new classWebMethods().nodata();
        }
    }
}