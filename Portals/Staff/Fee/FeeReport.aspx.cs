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

                using (SqlCommand cmd = new SqlCommand(sp_name, cls.con))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@fromdate", txtfrmdate.Text.ToString().Trim());
                        cmd.Parameters.AddWithValue("@todate", txttodate.Text.ToString().Trim());
                        cls.con.Open();
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

                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('No payment for specified dates','danger')", true);

                        }
                    }
                }

                //string fromdate = txtfrmdate.Text.ToString().Trim();
                //string todate = txttodate.Text.ToString().Trim()


                //string qry = "select  stud_id,UPPER(Name) AS Name,UPPER(Group_title) AS Group_title,CONVERT(VARCHAR(max), paydate, 103)  as paydate,Receipt_no,UPPER(Structure) AS Structure,Amount,Recpt_mode, Recpt_Chq_No,CONVERT(VARCHAR(max), Cheque_dt, 103)  as Cheque_dt,Bank_details,stud_Category,duration from (select c.stud_id,c.stud_Category,c.ayid,(select substring(Duration, 9, 4) + '-' + substring(Duration, 21, 4) from m_academic where ayid = c.ayid) as duration,c.Name,c.group_id,e.Group_title,sum(coalesce(d.Amount, 0)) Amount,'OTHER FEES' as Structure,d.Receipt_no,convert(date, d.Pay_date) as paydate,d.Recpt_Bnk_Name + '(' + d.Recpt_Bnk_Branch + ')' as Bank_details,d.Recpt_Chq_No,convert(date, d.Recpt_Chq_dt) as Cheque_dt,d.Recpt_mode from (select b.stud_id, b.ayid, coalesce(a.stud_L_Name,'') +' ' + coalesce(a.stud_F_Name, '') + ' ' + coalesce(a.stud_M_Name, '') as Name,b.group_id ,a.stud_Category from m_std_personaldetails_tbl a inner join  m_std_studentacademic_tbl b on a.stud_id = b.stud_id and a.del_flag = 0 and b.del_flag = 0) c left join m_FeeEntry  d on c.stud_id = d.Stud_id and c.ayid = d.Ayid and d.del_flag = 0  and(d.Struct_name not like 'Tut%' and d.Struct_name not like 'Tui%'  and d.Struct_name not like 'Dev%') and d.Chq_status = 'Clear' inner join m_crs_subjectgroup_tbl e on e.Group_id = c.group_id and e.del_flag = 0 where d.Pay_date between convert(datetime, cast('"+ fromdate + "' as varchar), 105) and convert(datetime, cast('"+ todate + "' as varchar),105) group by c.stud_id,c.ayid,c.Name,c.group_id,d.Receipt_no,convert(date, d.Pay_date)  ,d.Recpt_Bnk_Name + '(' + d.Recpt_Bnk_Branch + ')' ,e.Group_title ,c.stud_Category,d.Recpt_Chq_No,convert(date, d.Recpt_Chq_dt),d.Recpt_mode union all select c.stud_id,c.stud_Category,c.ayid,(select substring(Duration, 9, 4) + '-' + substring(Duration, 21, 4) from m_academic where ayid = c.ayid) as duration,c.Name,c.group_id,e.Group_title,sum(coalesce(d.Amount, 0)) Amount,'TUTION FEES',d.Receipt_no,convert(date, d.Pay_date) as paydate,d.Recpt_Bnk_Name + '(' + d.Recpt_Bnk_Branch + ')' as Bank_details,d.Recpt_Chq_No,convert(date, d.Recpt_Chq_dt) as Cheque_dt,d.Recpt_mode from (select b.stud_id, b.ayid, coalesce(a.stud_L_Name,'') +' ' + coalesce(a.stud_F_Name, '') + ' ' + coalesce(a.stud_M_Name, '') as Name,b.group_id ,a.stud_Category from m_std_personaldetails_tbl a inner join  m_std_studentacademic_tbl b on a.stud_id = b.stud_id and a.del_flag = 0 and b.del_flag = 0) c left join m_FeeEntry  d on c.stud_id = d.Stud_id and c.ayid = d.Ayid and d.del_flag = 0 and(d.Struct_name  like 'Tut%' or d.Struct_name  like 'Tui%'  or d.Struct_name  like 'Dev%') and d.Chq_status = 'Clear' inner join m_crs_subjectgroup_tbl e on e.Group_id = c.group_id and e.del_flag = 0 where d.Pay_date between convert(datetime, '"+ fromdate + "', 105) and convert(datetime, '"+ todate + "',105) group by c.stud_id,c.ayid,c.Name,c.group_id,d.Receipt_no,convert(date, d.Pay_date)  ,d.Recpt_Bnk_Name + '(' + d.Recpt_Bnk_Branch + ')'  ,e.Group_title,c.stud_Category,d.Recpt_Chq_No,convert(date, d.Recpt_Chq_dt),d.Recpt_mode) g order by g.paydate end";


                //DataTable dt = cls.fillDataTable(qry);
                //if (dt.Rows.Count > 0)
                //{
                //    btnexcel.Visible = true;
                //    grd.DataSource = dt;
                //    grd.DataBind();
                //    grd.HeaderRow.TableSection = TableRowSection.TableHeader;
                //    Page.MaintainScrollPositionOnPostBack = false;
                //}

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