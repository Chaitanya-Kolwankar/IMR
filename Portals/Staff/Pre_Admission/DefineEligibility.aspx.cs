using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Portals_Staff_Pre_Admission_DefineEligibility : System.Web.UI.Page
{
    Class1 cls = new Class1();
    protected void Page_Load(object sender, EventArgs e)
    {
        DataOnPageLoad();   
    }
    public void DataOnPageLoad() {
        DataTable dt = cls.fillDataTable("select * from m_academic order by ayid desc");
        ddltoyear.DataSource = dt;
        ddltoyear.DataTextField = "Duration";
        ddltoyear.DataValueField = "AYID";
        ddltoyear.DataBind();
        ddltoyear.Items.Insert(0, new ListItem("--Select--", "na"));
    }
}