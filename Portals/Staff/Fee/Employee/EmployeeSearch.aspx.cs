using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Portals_Staff_Employee_EmployeeSearch : System.Web.UI.Page
{
    Class1 obj = new Class1();
    
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
                    //                    LoadDocGrid();
                }
            }
            catch (Exception d)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('" + d.Message + "','danger')", true);
            }
        }
    }

    protected void btn_search_Click(object sender, EventArgs e)
    {
        try
        {
            string firstname, middlename, lastname;
            firstname = txtfirstname.Text;
            middlename = txtmiddlename.Text;
            lastname = txtlastname.Text;


            if (String.IsNullOrEmpty(firstname.Trim()) && String.IsNullOrEmpty(middlename.Trim()) && String.IsNullOrEmpty(lastname.Trim()))
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Atleast Enter One Field','danger')", true);


            }
            else
            {
                dataload();
            }
        }
        catch(Exception d)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('" + d.Message + "','danger')", true);
        }
    }
   

    public void dataload()
    {
         string firstname, middlename, lastname;
         firstname = txtfirstname.Text;
         middlename = txtmiddlename.Text;
         lastname = txtlastname.Text;
         string sel = "select a.emp_id,b.emp_id,a.del_flag,b.del_flag, UPPER(LEFT(a.emp_fname,1))+LOWER(SUBSTRING(a.emp_fname,2,LEN(a.emp_fname)))+' '+UPPER(LEFT(a.emp_mname,1))+LOWER(SUBSTRING(a.emp_mname,2,LEN(a.emp_mname)))+' '+UPPER(LEFT(a.emp_lname,1))+LOWER(SUBSTRING(a.emp_lname,2,LEN(a.emp_lname))) AS Employee , b.emp_id,b.username,b.password from m_employee_personal as a,web_tp_login as b where a.emp_id=b.emp_id and a.emp_fname like '%" + firstname + "%' and  a.emp_mname like '%" + middlename + "%' and a.emp_lname like '%" + lastname + "%'";
        DataTable dt = new DataTable();
        dt = obj.fillDataTable(sel);
        grd_data2.DataSource = dt;
        grd_data2.DataBind();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            string delflag = dt.Rows[i][3].ToString();
            GridViewRow grr = grd_data2.Rows[i];
            if (delflag == "True")
            {
                Button myHyperLink = grr.FindControl("test") as Button;
                myHyperLink.Text = "Recover";
                myHyperLink.CommandName = "Recover";   /// id.Commandname ="recover"      
            }
            else
            {
                Button myHyperLink = grr.FindControl("test") as Button;
                myHyperLink.Text = "Delete";
            }
        }
        if (dt.Rows.Count == 0)
        {

            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('No Employee Available With Given Info','danger')", true);
 
        }
    }
    protected void btnclear_Click(object sender, EventArgs e)
    {
        try
        {
            txtfirstname.Text = "";
            txtlastname.Text = "";
            txtmiddlename.Text = "";
            grd_data2.DataSource = null;
            grd_data2.DataBind();
        }
    catch(Exception d)
        {

            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('" + d.Message + "','danger')", true); 
        }
    }
    protected void grd_data2_RowCommand1(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue.Contains("Yes"))
            {
                if (e.CommandName == "buttonfieldid")
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    string empid = grd_data2.Rows[index].Cells[0].Text;
                    GridViewRow grd = grd_data2.Rows[index];
                    string update1 = "UPDATE m_employee_personal set del_flag='1' where emp_id='" + empid + "';update web_tp_login set del_flag='1' where emp_id='" + empid + "'";

                    // grd_data2.DataSource = null;
                    //  grd_data2.DataBind();
                    if (obj.DMLqueries(update1) == true)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify(' Employee Deleted','danger')", true);

                        // string btndelet = grd_data2.Rows[index].Cells[3].Text;
                        //btndelet = "delete";
                        // Button btntext = grd_data2.FindControl("test") as Button;
                        // btntext.Text = "recover";
                        //ScriptManager.RegisterStartupScript(Page, GetType(), "Confirm", "<script>Confirm(id)</script>", false);

                    }
                }
                dataload();
            }
            else
            {
            }

            if (e.CommandName == "Recover")
            {
                int indexx = Convert.ToInt32(e.CommandArgument);
                string empidd = grd_data2.Rows[indexx].Cells[0].Text;
                GridViewRow grdi = grd_data2.Rows[indexx];
                string update2 = "UPDATE m_employee_personal set del_flag='0' where emp_id='" + empidd + "';update web_tp_login set del_flag='0' where emp_id='" + empidd + "'";
                if (obj.DMLqueries(update2) == true)
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify(' Employee Recovered','danger')", true);

                    dataload();
                }
            }
        }
        catch(Exception d)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('"+d.Message+"','danger')", true);

        }
    }

    protected void grd_data2_RowDataBound2(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowIndex == 0)
                    e.Row.Style.Add("height", "50px");
            }
        }
        catch(Exception d)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('" + d.Message + "','danger')", true);
        }
    }

}