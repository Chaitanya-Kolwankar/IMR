using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Portals_Staff_Admission_ApplicantReport : System.Web.UI.Page
{
    Class1 cls = new Class1();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            btn_excl.Visible = false;
        }
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "func", "lstbx();", true);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "func", "notify()", true);
    }

    protected void BTN_GETDATA_Click(object sender, EventArgs e)
    {
        string chked_lstboox = "";
        for (int i = 0; i < lstbx_detail.Items.Count; i++)
        {
            if (lstbx_detail.Items[i].Selected)
            {
                if (chked_lstboox == "")
                {
                    chked_lstboox = "" + lstbx_detail.Items[i].Value + "";
                }
                else
                {
                    chked_lstboox = chked_lstboox + "," + lstbx_detail.Items[i].Value;

                }

            }

        }
        if (chked_lstboox == "")
        {
            string grdqry = "select Form_no as[Form No.],stud_id as [Student ID],F_name as [First Name],M_name as [Middle Name],L_name as [Last Name],case cast(GENDER as int) when 0 then 'FEMALE' when 1 then 'MALE' else Gender end as Gender,CASE WHEN Marital_status=0 THEN 'Unmarried' when Marital_status=1 then 'Married' else '' end as [Marital Status]  from d_adm_applicant where ACDID='" + Session["Year"].ToString() + "' and Del_Flag=0 order by [First Name],[Middle Name],[Last Name]";
            DataTable dtgrdqry = cls.fillDataTable(grdqry);
            if (dtgrdqry.Rows.Count > 0)
            {
                Grid_app.DataSource = dtgrdqry;
                Grid_app.DataBind();
                btn_excl.Visible = true;

            }
            else
            {
                Grid_app.DataSource = null;
                Grid_app.DataBind();
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('No Applicant  applied yet','success')", true);
                btn_excl.Visible = false;


            }
        }
        else
        {
            string grdqry1 = "select Form_no as[Form No.],stud_id as [Student ID],F_name as [First Name],M_name as [Middle Name],L_name as [Last Name],case cast(GENDER as int) when 0 then 'FEMALE' when 1 then 'MALE' else Gender end as Gender,CASE WHEN Marital_status=0 THEN 'Unmarried' when Marital_status=1 then 'Married' else '' end as [Marital Status] ," + chked_lstboox + " from d_adm_applicant where ACDID='" + Session["Year"].ToString() + "' order by [First Name],[Middle Name],[Last Name]";
            DataTable dtgrd2 = cls.fillDataTable(grdqry1);
            if (dtgrd2.Rows.Count > 0)
            {
                Grid_app.DataSource = dtgrd2;
                Grid_app.DataBind();
                btn_excl.Visible = true;
            }
            else
            {
                Grid_app.DataSource = null;
                Grid_app.DataBind();
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('No Applicant  applied yet','success')", true);
                btn_excl.Visible = false;
            }


        }

    }

    protected void Grid_app_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    protected void btn_Clear_Click(object sender, EventArgs e)
    {
        btn_excl.Visible = false;
        Grid_app.DataSource = null;
        Grid_app.DataBind();
        for (int i = 0; i < lstbx_detail.Items.Count; i++)
        {
            if (lstbx_detail.Items[i].Selected)
            {
                lstbx_detail.Items[i].Selected = false;
            }

        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
           server control at run time. */
    }

    protected void btn_excl_Click(object sender, EventArgs e)
    {

        Response.Clear();
        Response.Buffer = true;
        Response.ClearContent();
        Response.ClearHeaders();
        Response.Charset = "";
        string FileName = "APPLICANT" + DateTime.Now + ".xls";
        StringWriter strwritter = new StringWriter();
        HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
        Grid_app.GridLines = GridLines.Both;
        Grid_app.HeaderStyle.Font.Bold = true;
        Grid_app.RenderControl(htmltextwrtter);
        string style = @"<style> td { mso-number-format:\@; } </style> ";
        Response.Write(style);
        Response.Write(strwritter.ToString());
        Response.End();

    }
}