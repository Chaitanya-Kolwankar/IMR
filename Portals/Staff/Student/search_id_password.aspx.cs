using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class Student_search_id_password : System.Web.UI.Page
{

    Class1 sfrom = new Class1();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {
            try
            {
                if (Convert.ToString(Session["Emp_id"]) == "")
                {
                    Response.Redirect("~/Portals/Staff/Login.aspx");
                }
            }
            catch (Exception r) { Response.Redirect("~/Portals/Staff/Login.aspx"); }
        
        }

    }
    protected void button1_Click(object sender, EventArgs e)
    {
        try
        {
            string stud_id = txtstudentid.Text;
            string firstn = txtfname.Text;
            string middlen = txtmname.Text;
            string lastn = txtlname.Text;

            if (stud_id == "" && firstn == "" && middlen == "" && lastn == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('atleast enter one field.', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert(' Please enter atleast onefield')", true);

            }
            else
            {

                // string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;

                string query = "SELECT dbo.m_std_personaldetails_tbl.stud_id as 'Student ID' , m_std_personaldetails_tbl.stud_F_Name as 'First Name', m_std_personaldetails_tbl.stud_M_Name as 'Middle Name', m_std_personaldetails_tbl.stud_L_Name as 'Last Name', www_login.password as Password FROM dbo.m_std_personaldetails_tbl full outer JOIN dbo.www_login ON  dbo.m_std_personaldetails_tbl.stud_id = dbo.www_login.stud_id WHERE  dbo.m_std_personaldetails_tbl.stud_id like'%" + stud_id + "%' and stud_F_Name like'%" + firstn + "%' and stud_M_Name like'%" + middlen + "%' and stud_L_Name like'%" + lastn + "%' and  dbo.m_std_personaldetails_tbl.del_flag='0' and dbo.www_login.del_flag = '0'";

                DataTable t1 = new DataTable();

                t1 = sfrom.fillDataTable(query);

                if (t1.Rows.Count > 0)
                {
                    GridView1.DataSource = t1;
                    GridView1.DataBind();

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('Student not found.', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No Student Found')", true);

                }

            }
        }
        catch(Exception d)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('" + d.Message + "', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true); 
        }
    }
    protected void button2_Click(object sender, EventArgs e)
    {
        try
        {
            txtstudentid.Text = "";
            txtfname.Text = "";
            txtmname.Text = "";
            txtlname.Text = "";

            GridView1.DataSource = null;
            GridView1.DataBind();
        }
        catch (Exception d)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "$.notify('" + d.Message + "', { type: 'danger', animation: true, animationType: 'drop', align: 'center', verticalAlign: 'top', blur: 0.0, delay: 0 });", true);
        }
    }
}