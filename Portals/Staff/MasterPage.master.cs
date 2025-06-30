using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    Class1 cls = new Class1();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                photos.Src = "../../Staff/Staff_Photo/" + Session["emp_id"].ToString() + ".jpg";
                DataTable dt = cls.fillDataTable("select * from m_academic order by ayid desc");
                ddlyear.DataSource = dt;
                ddlyear.DataTextField = "Duration";
                ddlyear.DataValueField = "AYID";
                ddlyear.DataBind();
                if (Session["Year"].ToString() == "")
                {
                    ddlyear.SelectedValue = cls.fillDataTable("select ayid from m_academic where iscurrent=1").Rows[0][0].ToString();
                    Session["Year"] = cls.fillDataTable("select ayid from m_academic where iscurrent=1").Rows[0][0].ToString();
                }
                else
                {
                    ddlyear.SelectedValue = Session["Year"].ToString();
                }
            }
            catch (Exception ex) {
                Response.Redirect("~/Portals/Staff/Login.aspx");
               
            }
        }
    }
    protected void ddlyear_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["Year"] = ddlyear.SelectedValue.ToString();
        ddlyear.SelectedValue = Session["Year"].ToString();
        Response.Redirect(HttpContext.Current.Request.Url.ToString(), true);
    }
}
