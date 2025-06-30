using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class search_student_informatiom : System.Web.UI.Page
{
    Class1 obj = new Class1();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {

            
            
                if (Convert.ToString(Session["Emp_id"]) == "")
                {
                    Response.Redirect("~/Portals/Staff/Login.aspx");
                }
                                                                                                    
        }
        //grid1.HeaderRow.TableSection = TableRowSection.TableHeader;

    }
    protected void btnsearch_Click(object sender, EventArgs e)
    {

        try { 
        
        string studid = txtstudid.Text;
        string firstname = txtfirstname.Text;
        string lastname = txtlastname.Text;
        string middlename = txtmiddlname.Text;
        string ext = "";
        if (string.IsNullOrEmpty(studid.Trim()) && string.IsNullOrEmpty(middlename.Trim()) && string.IsNullOrEmpty(firstname.Trim()) && string.IsNullOrEmpty(lastname.Trim()))
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Atleast Enter One Field.','danger')", true);

        }
        else
        {
            if ((studid.Trim()) != "")
            {
                ext = " and a.stud_id = '" + studid.Trim() + "' ";
            }
            else
            {
                if (firstname != "" || lastname != "" || middlename != "" )
                {
                    ext = " and p.stud_F_Name Like '%" + firstname.Trim() + "%'   and p.stud_L_Name Like '%" + lastname.Trim() + "%' and p.stud_M_Name Like '%" + middlename.Trim() + "%'";
                }
            }
            string query1 = "select * from (select p.stud_id,UPPER(LEFT(p.stud_F_Name,1))+LOWER(SUBSTRING(p.stud_F_Name,2,LEN(p.stud_F_Name))) +' '+ UPPER(LEFT(p.stud_M_Name,1))+LOWER(SUBSTRING(p.stud_M_Name,2,LEN(p.stud_M_Name))) +' '+UPPER(LEFT(p.stud_L_Name,1))+LOWER(SUBSTRING(p.stud_L_Name,2,LEN(p.stud_L_Name))) AS stud_name,a.roll_no,b.password,g.group_title,g.Group_id,ROW_NUMBER()OVER(PARTITION BY a.stud_id ORDER BY a.ayid desc) abc  from dbo.m_std_personaldetails_tbl as p,dbo.m_std_studentacademic_tbl as a,m_crs_subjectgroup_tbl as g,www_login as b where p.stud_id=a.stud_id and a.stud_id=b.stud_id  and a.group_id=g.Group_id   and p.del_flag=0 " + ext + ") a  where abc=1 ";

            DataTable dt = new DataTable();
            dt = obj.fillDataTable(query1);
            if (dt.Rows.Count == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Student Not Found.','danger')", true);
                grid1.DataSource = null;
                grid1.DataBind();


            }
            else
            {

                grid1.DataSource = dt;
                grid1.DataBind();
                grid1.HeaderRow.TableSection = TableRowSection.TableHeader;


            }

        }
    }

catch(Exception d)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('"+d.Message+"','danger')", true);

 
        }

    }
    protected void btnclear_Click(object sender, EventArgs e)
    {
        try
        {
            txtfirstname.Text = "";
            txtlastname.Text = "";
            txtstudid.Text = "";
            txtmiddlname.Text = "";
            grid1.DataSource = null;
            grid1.DataBind();
        }
        catch(Exception d)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('" + d.Message + "','danger')", true);
        }
    }
    protected void grid1_RowCommand1(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            string lblparentcrd = lbl_Parent.Text;
            if (e.CommandName == "btnclick")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow gvrow = grid1.Rows[index];
                Label txtTotal = (Label)grid1.Rows[index].FindControl("gridlblStudid");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myModal", "<script>$('#myModal').modal('show');</script>", false);

                string query2 = "select stud_id,UPPER(LEFT(stud_F_Name,1))+LOWER(SUBSTRING(stud_F_Name,2,LEN(stud_F_Name)))+' '+UPPER(LEFT(stud_M_Name,1))+LOWER(SUBSTRING(stud_M_Name,2,LEN(stud_M_Name)))+' '+UPPER(LEFT(stud_L_Name,1))+LOWER(SUBSTRING(stud_L_Name,2,LEN(stud_L_Name))) as studentname ,convert(varchar,stud_DOB,103) as dat, stud_Father_TelNo,UPPER(LEFT(stud_PermanentAdd,1))+LOWER(SUBSTRING(stud_PermanentAdd,2,LEN(stud_PermanentAdd))) as addres from m_std_personaldetails_tbl where stud_id='" + txtTotal.Text + "'";
                DataTable dt = new DataTable();
                dt = obj.fillDataTable(query2);
                addressID.Text = ": " + dt.Rows[0]["addres"].ToString().ToLower();
                lbl_studID_crd.Text = ": " + dt.Rows[0]["stud_id"].ToString();
                lblname.Text = ": " + dt.Rows[0]["studentname"].ToString();
                if (dt.Rows[0]["stud_Father_TelNo"].ToString() == "")
                {
                    lbl_Parent.Text = ": " + "NA";
                }
                else
                {
                    lbl_Parent.Text = ": " + dt.Rows[0]["stud_Father_TelNo"].ToString();
                }
                lbldobcrd.Text = ": " + dt.Rows[0]["dat"].ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myModal", "<script>$('#myModal').modal('show');</script>", false);
                grid1.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
        catch(Exception d)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('" + d.Message + "','danger')", true);
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
        catch (Exception d)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('" + d.Message + "','danger')", true);
        }
    }
}