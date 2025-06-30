using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Portals_Staff_Pre_Admission_AdmissionURL : System.Web.UI.Page
{
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
                    link_load();                    
                }                
            }
            catch (Exception ex)
            {
                Response.Redirect("~/Portals/Staff/Login.aspx");
            }
        }
    }
    private void link_load()
    {
        string str = "select * from admission_url";
        DataSet ds1 = cls.fillDataset(str);
        String gg = ds1.Tables[0].Rows[0][1].ToString();
        grd.DataSource = ds1;
        grd.DataBind();
        DataTable dt = ds1.Tables[0];
        foreach (DataRow row in dt.Rows)
        {            
            int hh = dt.Rows.IndexOf(row);          
            GridViewRow gvr1 = (GridViewRow)grd.Rows[hh];
            string str2 = ds1.Tables[0].Rows[hh][2].ToString();
            if (str2.Contains("True"))
            {
                CheckBox chk = gvr1.FindControl("check") as CheckBox;
                chk.Checked = true;
            }
            else
            {
                CheckBox chk = gvr1.FindControl("check") as CheckBox;
                chk.Checked =false;
            }
            
        }
    }
    protected void check_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            CheckBox btn = (CheckBox)sender;
            GridViewRow GridView1 = (GridViewRow)btn.NamingContainer;
            string id = (GridView1.FindControl("lbllink") as Label).Text;
            if (btn.Checked)
            {
                string str1 = "update admission_url set open_flag=1 where link='" + id + "'";
                cls.DMLqueries(str1);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Link Open Successfully','success')", true);               
            }
            else
            {
                string str1 = "update admission_url set open_flag=0 where link='" + id + "'";
                cls.DMLqueries(str1);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Link Close Successfully','danger')", true);
            }
        }
        catch (Exception d)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('"+d.Message+"','danger')", true);
        }
    }  
  
}
