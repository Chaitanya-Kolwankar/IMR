using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class salary_monthly_entry : System.Web.UI.Page
{
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
    public static salarydetails getdept()
    {
        return new classWebMethods().getdept();
    }

    [WebMethod]
    public static salarydetails getmonthly(empsalary obj)
    {
        string msg = "";
        return new classWebMethods().getmonthly(obj,msg);
    }

    [WebMethod]
    public static string savemonthly(salarydetails obj)
    {
        return new classWebMethods().savemonthly(obj);
    }

    [WebMethod]
    public static string deletemonthly(empsalary obj)
    {
        return new classWebMethods().deletemonthly(obj);
    }
}