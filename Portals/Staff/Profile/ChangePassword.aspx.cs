using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    Class1 objupdate = new Class1();
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

            catch (Exception a) 
            {
                Console.WriteLine(a.Message);
                Response.Redirect("~/Portals/Staff/Login.aspx");      

            }
        
        
        }
    }
    protected void savebtn_Click(object sender, EventArgs e)
    {
        try { 
        
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
        string old = oldpwd.Text;
        string newpd = newpwd.Text;
        string conpd = conpwd.Text;
        string emp_id = Session["emp_id"].ToString();

        if (newpd == conpd)
        {

            string selct = "select password from web_tp_login where emp_id='" + emp_id + "'";
            DataTable dt = new DataTable();
            dt = objupdate.fillDataTable(selct);
            string old_password = dt.Rows[0]["password"].ToString();

            if (old_password == old)
            {
                if (old != newpd)
                {
                    SqlCommand cm = new SqlCommand("update web_tp_login set password= @new where password= @oldd and emp_id= @empid", con);
                    SqlParameter[] param = new SqlParameter[3];   

                    param[0] = new SqlParameter("@new", newpd);
                     cm.Parameters.Add(param[0]);
                    param[1] = new SqlParameter("@oldd", old);
                     cm.Parameters.Add(param[1]);
                     param[2] = new SqlParameter("@empid", emp_id);
                     cm.Parameters.Add(param[2]);

                     con.Open();
                     cm.ExecuteScalar();
                     con.Close();
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Password Updated Successfully.','success')", true);
                    oldpwd.Text = "";
                    newpwd.Text = "";
                    conpwd.Text = "";
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('New Password Cannot Be The Same as Your Old Password.','danger')", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Old Password is Incorrect.','danger')", true);
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Confirm Password is Not Same.','danger')", true);
        }
        }
        catch(Exception d)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('" + d.Message + "', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true); 
        
        

        }

     }
}