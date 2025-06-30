
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Portals_Staff_Employee_EmployeeDetails : System.Web.UI.Page
{
    Class1 cls = new Class1();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {          
            btngetexcel.Visible = false;       
        }
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "func", "lstbx();", true);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "func", "notify()", true);
    }


    public void LSTCOL_LOAD()
    {
        try
        {
            string emp_personal_table_column = "select COLUMN_NAME from INFORMATION_SCHEMA.Columns where TABLE_NAME='EmployeePersonal' and COLUMN_NAME not in('emp_id','NAME','FATHER','SURNAME','del_flag','del_dt','emp_dept_id','emp_des_id')";
            DataTable dtcol = cls.fillDataTable(emp_personal_table_column);
            lstbxcol.DataTextField = dtcol.Columns["COLUMN_NAME"].ToString();
            lstbxcol.DataValueField = dtcol.Columns["COLUMN_NAME"].ToString();
            lstbxcol.DataSource = dtcol;
            lstbxcol.DataBind();
        }
        catch (Exception f)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('" + f.Message + "','success')", true);
        }

    }
    
    protected void btngetdata_Click(object sender, EventArgs e)
    {
        try
        {
            string chkitem = "";
            for (int i = 0; i < lstbxcol.Items.Count; i++)
            {
                if (lstbxcol.Items[i].Selected)
                {
                    if (chkitem == "")
                    {
                        chkitem = "" + lstbxcol.Items[i].Value + "";
                    }
                    else
                    {
                        chkitem = chkitem + "," + lstbxcol.Items[i].Value;
                    }
                }
            }
            if (chkitem == "")
            {
                string GRDQURY2 = "select emp_id as [Employee ID],Name AS [First Name],father as [Middle Name],surname as [Last Name],GENDER as Gender from EmployeePersonal where del_flag=0 ORDER BY [First Name],[Middle Name],[Last Name]";
                DataTable dtgrdqury2 = cls.fillDataTable(GRDQURY2);
                if (dtgrdqury2.Rows.Count > 0)
                {
                    dynamicgrd.DataSource = dtgrdqury2;
                    dynamicgrd.DataBind();
                    btngetexcel.Visible = true;
                }
                else
                {
                    dynamicgrd.DataSource = null;
                    dynamicgrd.DataBind();
                    btngetexcel.Visible = false;
                }
            }
            else
            {

                string GRDQURY = "select emp_id as [Employee ID],Name AS [First Name],father as [Middle Name],surname as [Last Name],GENDER as Gender," + chkitem + " from EmployeePersonal where del_flag=0 ORDER BY [First Name],[Middle Name],[Last Name]";
                DataTable dtgrdqury = cls.fillDataTable(GRDQURY);
                if (dtgrdqury.Rows.Count > 0)
                {
                    dynamicgrd.DataSource = dtgrdqury;
                    dynamicgrd.DataBind();
                    btngetexcel.Visible = true;

                }
                else
                {
                    dynamicgrd.DataSource = null;
                    dynamicgrd.DataBind();
                    btngetexcel.Visible = false;
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('no employee ','success')", true);
                }
            }
        }
        catch (Exception f) 
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('" + f.Message + "','success')", true);
        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
           server control at run time. */
    }
    protected void btngetexcel_Click(object sender, EventArgs e)
    {
        try
        {

            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Charset = "";
            string FileName = "Employee" + DateTime.Now + ".xls";
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            dynamicgrd.GridLines = GridLines.Both;
            dynamicgrd.HeaderStyle.Font.Bold = true;
            dynamicgrd.RenderControl(htmltextwrtter);
            string style = @"<style> td { mso-number-format:\@; } </style> ";
            Response.Write(style);
            Response.Write(strwritter.ToString());
            Response.End();

           

        }
        catch (Exception f)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('" + f.Message + "','success')", true);
        }

    }

    protected void dynamicgrd_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    protected void btnclear_Click(object sender, EventArgs e)
    {
        try
        {
            dynamicgrd.DataSource = null;
            dynamicgrd.DataBind();
            btngetexcel.Visible = false;

            for (int i = 0; i < lstbxcol.Items.Count; i++)
            {
                if (lstbxcol.Items[i].Selected)
                {
                    lstbxcol.Items[i].Selected = false;
                }

            }
        }
        catch (Exception f)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('"+f.Message+"','success')", true);
        }
    }
}