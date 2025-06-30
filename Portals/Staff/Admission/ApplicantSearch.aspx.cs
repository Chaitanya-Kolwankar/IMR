using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ApplicantSearch : System.Web.UI.Page
{
    Class1 obj = new Class1();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack )
        {
            try { 
            if(Convert.ToString(Session["Emp_id"])==""){
                Response.Redirect("~/Portals/Staff/Login.aspx");
            }
            }
            catch(Exception d){

                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('"+d.Message+"','danger')", true);
                
            }
            
        }

       

    }
    protected void btn_clear_Click(object sender, EventArgs e)
    {
        try
        {
            txt_form_no.Text = "";
            txtfirstname.Text = "";
            txtMiddlename.Text = "";
            txtLastName.Text = "";
            grid1.DataSource = null;
            grid1.DataBind();
        }
        catch (Exception d)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('" + d.Message + "','danger')", true);
        }
    }
    protected void btn_search_Click(object sender, EventArgs e)
    {
        try { 
        
        string formno = txt_form_no.Text;
        string firstname = txtfirstname.Text;
        string middlename = txtMiddlename.Text;
        string lastname = txtLastName.Text;


        if (string.IsNullOrEmpty(formno.Trim()) && string.IsNullOrEmpty(firstname.Trim()) && string.IsNullOrEmpty(middlename.Trim()) && string.IsNullOrEmpty(lastname.Trim()) )
        {
            
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify(' Atleast Enter One Field.','danger')", true);


        }
        else
        {
            
            string selquery1 = "select formno,UPPER(LEFT(f_name,1))+LOWER(SUBSTRING(f_name,2,LEN(f_name)))+' '+UPPER(LEFT(m_name,1))+LOWER(SUBSTRING(m_name,2,LEN(m_name)))+' '+UPPER(LEFT(l_name,1))+LOWER(SUBSTRING(l_name,2,LEN(l_name)))  as name,mo_name,passwd from adm_applicant_registration where formno Like '%"+formno+"%' and  f_name like '%"+firstname+"%' and m_name like '%"+middlename+"%' and l_name like '%"+lastname+"%' and del_flag='0'";

            DataTable dt = new DataTable();
            dt = obj.fillDataTable(selquery1);
            

            if (dt.Rows.Count == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify(' No Student Available With Given Info.','danger')", true);
            }
            else 
            {
                grid1.DataSource = dt;
                grid1.DataBind();
                grid1.HeaderRow.TableSection = TableRowSection.TableHeader;
            }

        }
    }
        catch (Exception d)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('"+d.Message+"','danger')", true);

            
         

        }
    }
    protected void grid1_RowDataBound(object sender, GridViewRowEventArgs e)
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