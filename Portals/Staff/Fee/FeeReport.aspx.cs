using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Portals_Staff_Fee_FeeReport : System.Web.UI.Page
{
    Class1 cls = new Class1();
    SqlConnection con = new SqlConnection("Data Source=172.16.10.180; Initial Catalog=VIVAIMR; User Id = sa; password=passwd@12;");
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                if (Convert.ToString(Session["Emp_id"]) == "")
                {
                    Response.Redirect("~/Portals/Staff/Login.aspx");
                }
                else
                {
                    btnexcel.Visible = false;
                }
            }
            //grd.HeaderRow.TableSection = TableRowSection.TableHeader;
           // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "func", "notify()", true);
        }
        catch (Exception h) 
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('"+h.Message+"','danger')", true);

        }
    }

    protected void btngtdata_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtfrmdate.Text.Trim() == "")
            { ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Select From date','danger')", true); }
            else if (txttodate.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Select To  Date','danger')", true);

            }
            else
            {
                string sp_name = "sp_datewise_payment_report";



                using (SqlCommand cmd = new SqlCommand(sp_name, con))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@fromdate", txtfrmdate.Text.Trim());
                        cmd.Parameters.AddWithValue("@todate", txttodate.Text.Trim());
                        con.Open();
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            btnexcel.Visible = true;
                            grd.DataSource = dt;
                            grd.DataBind();
                            grd.HeaderRow.TableSection = TableRowSection.TableHeader;
                            Page.MaintainScrollPositionOnPostBack = false;
                        }
                        else
                        {
                            txtfrmdate.Text = "";
                            txttodate.Text = "";
                            btnexcel.Visible = false;

                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('No payment for specified dates,'danger')", true);
                        }


                    }



                }


            }
        }
        catch (Exception h)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('" + h.Message + "','danger')", true);

        }
    }

    protected void btnclear_Click(object sender, EventArgs e)
    {
        try
        {
            txtfrmdate.Text = "";
            txttodate.Text = "";
            grd.DataSource = null;
            grd.DataBind();
            btnexcel.Visible = false;
        }
        catch (Exception h) 
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('" + h.Message + "','danger')", true);
        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
           server control at run time. */
       

    }

    protected void btnexcel_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Charset = "";
            string FileName = "FeeReport" + DateTime.Now.ToString("dd/MM/yyyy") + ".xls";
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            grd.GridLines = GridLines.Both;
            grd.HeaderStyle.Font.Bold = true;
            grd.RenderControl(htmltextwrtter);
            string style = @"<style> td { mso-number-format:\@; } </style> ";
            Response.Write(style);
            Response.Write(strwritter.ToString());
            Response.End();
        }
        catch (Exception h)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('" + h.Message + "','danger')", true);
        }


    }

    
}