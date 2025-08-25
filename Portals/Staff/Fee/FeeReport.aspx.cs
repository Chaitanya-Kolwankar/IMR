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
        }
        catch (Exception h)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('" + h.Message + "','danger')", true);

        }
    }

    protected void btngtdata_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtfrmdate.Text.Trim() == "")
            { ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Select From date','danger')", true); }
            else if (txttodate.Text.Trim() == "")
            { ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Select To  Date','danger')", true); }
            else if (ddlcat.SelectedItem.ToString() == "--Select--")
            { ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Select the Category','danger')", true); }
            else
            {
                string fromdate = txtfrmdate.Text.ToString().Trim();
                string todate = txttodate.Text.ToString().Trim();
                string OtherCategory = ddlcat.SelectedValue.ToString();



                ddlcat.Enabled = false;
                string qry = "";
                if (OtherCategory == "OPEN")
                {
                    //  string qry1 = "SELECT distinct mfi.Install_id, a.stud_id,a.stud_F_Name + ' ' + ISNULL(a.stud_M_Name, '') + ' ' + a.stud_L_Name AS Name,c.Group_title,a.stud_Category,mfe.Pay_date AS paydate,mfe.Receipt_no, mfe.Struct_name AS Structure, mfe.Amount, mfe.Recpt_mode,mfe.Recpt_Chq_No,mfe.Recpt_Chq_dt AS Cheque_dt,mfi.Install_no AS Installments, mfe.Recpt_Bnk_Name AS Bank_details, SUBSTRING(d.Duration, 9, 4) + '-' + SUBSTRING(d.Duration, 21, 4) AS duration,mfi.Install_id,mfi.Stud_id,(select sum(fm.Amount) from m_FeeMaster fm)[Total],(select sum(fe.Amount) from m_FeeEntry fe where cast(right(fe.Install_id,2) as int)<=cast(right(mfi.Install_id,2 ) as int)) Paid FROM m_FeeInstallment fi , m_std_personaldetails_tbl a JOIN m_std_studentacademic_tbl b ON a.stud_id = b.stud_id JOIN m_crs_subjectgroup_tbl c ON c.group_id = b.group_id AND c.Subcourse_id = b.subcourse_Id JOIN m_academic d ON d.AYID = b.ayid JOIN m_FeeEntry mfe ON mfe.stud_id = b.stud_id AND b.ayid = mfe.Ayid JOIN m_FeeInstallment mfi ON mfi.stud_id = a.stud_id AND mfi.Install_id = mfe.Install_id and mfi.ayid = mfe.Ayid AND mfi.Stud_id = mfe.Stud_id  and mfi.group_id = b.group_id left join(select* from m_FeeMaster) mfm on mfm.Group_id = b.group_id and mfm.Category = 'OPEN' WHERE a.del_flag = 0 AND b.del_flag = 0 and mfe.Struct_id != 'Fine' AND c.del_flag = 0 AND mfe.del_flag = 0 and mfm.Category = 'OPEN' and mfm.Struct_id = mfe.Struct_id AND mfm.del_flag = 0 AND mfi.del_flag = 0 and mfm.ayid = mfe.Ayid AND mfe.Pay_date BETWEEN CONVERT(datetime,'" + fromdate + "', 120) AND CONVERT(datetime,'" + todate + "', 120) group by a.stud_id,a.stud_F_Name + ' ' + ISNULL(a.stud_M_Name, '') + ' ' + a.stud_L_Name ,c.Group_title,a.stud_Category,mfe.Pay_date ,mfe.Receipt_no, mfe.Struct_name, mfe.Amount, mfe.Recpt_mode,mfe.Recpt_Chq_No,mfe.Recpt_Chq_dt ,mfi.Install_no , mfe.Recpt_Bnk_Name,d.Duration,d.Duration,mfm.Amount,mfe.Amount,mfi.Install_id,mfi.Stud_id ORDER BY a.stud_id DESC;";

                    qry = "select *, Total-Paid[Balance] from (SELECT mfi.Install_id,a.stud_id,a.stud_F_Name + ' ' + ISNULL(a.stud_M_Name, '') + ' ' + a.stud_L_Name AS Name,c.Group_title,a.stud_Category,mfe.Pay_date AS paydate,mfe.Receipt_no,mfe.Struct_name AS Structure, mfe.Amount,mfe.Recpt_mode,mfe.Recpt_Chq_No,mfe.Recpt_Chq_dt AS Cheque_dt,mfi.Install_no AS Installments,mfe.Recpt_Bnk_Name AS Bank_details,SUBSTRING(d.Duration, 9, 4) + '-' + SUBSTRING(d.Duration, 21, 4) AS duration, (SELECT SUM(fm.Amount) FROM m_FeeMaster fm WHERE fm.Group_id = b.group_id AND fm.Category = 'OPEN' AND fm.Ayid = b.Ayid AND fm.del_flag = 0) AS Total,(SELECT SUM(fe.Amount) FROM m_FeeEntry fe WHERE fe.Struct_name!='Fine' and fe.Stud_id = mfi.Stud_id AND fe.Ayid = mfi.Ayid AND CAST(RIGHT(fe.Install_id, 2) AS INT) <= CAST(RIGHT(mfi.Install_id, 2) AS INT) AND fe.del_flag = 0) AS Paid FROM m_std_personaldetails_tbl a JOIN m_std_studentacademic_tbl b ON a.stud_id = b.stud_id JOIN m_crs_subjectgroup_tbl c ON c.group_id = b.group_id AND c.Subcourse_id = b.subcourse_Id JOIN m_academic d ON d.AYID = b.ayid JOIN m_FeeEntry mfe ON mfe.stud_id = b.stud_id AND b.ayid = mfe.Ayid JOIN m_FeeInstallment mfi ON mfi.stud_id = a.stud_id AND mfi.Install_id = mfe.Install_id AND mfi.Ayid = mfe.Ayid AND mfi.Stud_id = mfe.Stud_id  AND mfi.group_id = b.group_id LEFT JOIN m_FeeMaster mfm ON mfm.Group_id = b.group_id AND mfm.Category = 'OPEN' AND mfm.Struct_id = mfe.Struct_id AND mfm.Ayid = mfe.Ayid WHERE a.del_flag = 0 AND b.del_flag = 0 AND mfe.Fine_flag != '1' AND c.del_flag = 0 AND mfe.del_flag = 0 AND mfm.del_flag = 0 AND mfi.del_flag = 0 AND mfe.Pay_date BETWEEN CONVERT(datetime, '" + fromdate + "', 120) AND CONVERT(datetime, '" + todate + "', 120))tbl";



                }
                else if (OtherCategory != "OPEN")
                {
                    //string qry = "SELECT distinct mfi.Install_id, a.stud_id,a.stud_F_Name + ' ' + ISNULL(a.stud_M_Name, '') + ' ' + a.stud_L_Name AS Name,c.Group_title,a.stud_Category,mfe.Pay_date AS paydate,mfe.Receipt_no, mfe.Struct_name AS Structure, mfe.Amount, mfe.Recpt_mode,mfe.Recpt_Chq_No,mfe.Recpt_Chq_dt AS Cheque_dt,mfi.Install_no AS Installments, mfe.Recpt_Bnk_Name AS Bank_details, SUBSTRING(d.Duration, 9, 4) + '-' + SUBSTRING(d.Duration, 21, 4) AS duration,mfi.Install_id,mfi.Stud_id,(select sum(fm.Amount) from m_FeeMaster_Category fm where gender='FEMALE')[Total],(select sum(fe.Amount) from m_FeeEntry fe where cast(right(fe.Install_id,2) as int)<=cast(right(mfi.Install_id,2 ) as int)) Paid FROM m_FeeInstallment fi , m_std_personaldetails_tbl a JOIN m_std_studentacademic_tbl b ON a.stud_id = b.stud_id JOIN m_crs_subjectgroup_tbl c ON c.group_id = b.group_id AND c.Subcourse_id = b.subcourse_Id JOIN m_academic d ON d.AYID = b.ayid JOIN m_FeeEntry mfe ON mfe.stud_id = b.stud_id AND b.ayid = mfe.Ayid JOIN m_FeeInstallment mfi ON mfi.stud_id = a.stud_id AND mfi.Install_id = mfe.Install_id and mfi.ayid = mfe.Ayid AND mfi.Stud_id = mfe.Stud_id  and mfi.group_id = b.group_id left join(select* from m_FeeMaster) mfm on mfm.Group_id = b.group_id and mfm.Category = 'OPEN' WHERE a.del_flag = 0 AND b.del_flag = 0 and mfe.Struct_id != 'Fine' AND c.del_flag = 0 AND mfe.del_flag = 0 and mfm.Category != 'OPEN' and mfm.Struct_id = mfe.Struct_id AND mfm.del_flag = 0 AND mfi.del_flag = 0 and mfm.ayid = mfe.Ayid AND mfe.Pay_date BETWEEN CONVERT(datetime,'" + fromdate + "', 120) AND CONVERT(datetime,'" + todate + "', 120) group by a.stud_id,a.stud_F_Name + ' ' + ISNULL(a.stud_M_Name, '') + ' ' + a.stud_L_Name ,c.Group_title,a.stud_Category,mfe.Pay_date ,mfe.Receipt_no, mfe.Struct_name, mfe.Amount, mfe.Recpt_mode,mfe.Recpt_Chq_No,mfe.Recpt_Chq_dt ,mfi.Install_no , mfe.Recpt_Bnk_Name,d.Duration,d.Duration,mfm.Amount,mfe.Amount,mfi.Install_id,mfi.Stud_id ORDER BY a.stud_id DESC;";

                    qry = "select *, Total-Paid[Balance] from (SELECT mfi.Install_id,a.stud_id,a.stud_F_Name + ' ' + ISNULL(a.stud_M_Name, '') + ' ' + a.stud_L_Name AS Name,c.Group_title,a.stud_Category,mfe.Pay_date AS paydate,mfe.Receipt_no,mfe.Struct_name AS Structure, mfe.Amount,mfe.Recpt_mode,mfe.Recpt_Chq_No,mfe.Recpt_Chq_dt AS Cheque_dt,mfi.Install_no AS Installments,mfe.Recpt_Bnk_Name AS Bank_details,SUBSTRING(d.Duration, 9, 4) + '-' + SUBSTRING(d.Duration, 21, 4) AS duration, (SELECT SUM(fm.Amount) FROM m_FeeMaster fm WHERE fm.Group_id = b.group_id AND fm.Category = a.stud_Category and fm.Gender=a.stud_Gender AND fm.Ayid = b.Ayid AND fm.del_flag = 0) AS Total,(SELECT SUM(fe.Amount) FROM m_FeeEntry fe WHERE fe.Struct_name != 'Fine' and fe.Stud_id = mfi.Stud_id AND fe.Ayid = mfi.Ayid AND CAST(RIGHT(fe.Install_id, 2) AS INT) <= CAST(RIGHT(mfi.Install_id, 2) AS INT) AND fe.del_flag = 0) AS Paid FROM m_std_personaldetails_tbl a JOIN m_std_studentacademic_tbl b ON a.stud_id = b.stud_id JOIN m_crs_subjectgroup_tbl c ON c.group_id = b.group_id AND c.Subcourse_id = b.subcourse_Id JOIN m_academic d ON d.AYID = b.ayid JOIN m_FeeEntry mfe ON mfe.stud_id = b.stud_id AND b.ayid = mfe.Ayid JOIN m_FeeInstallment mfi ON mfi.stud_id = a.stud_id AND mfi.Install_id = mfe.Install_id AND mfi.Ayid = mfe.Ayid AND mfi.Stud_id = mfe.Stud_id  AND mfi.group_id = b.group_id LEFT JOIN m_FeeMaster mfm ON mfm.Group_id = b.group_id AND mfm.Category = a.stud_Category and mfm.Gender=a.stud_Gender AND mfm.Struct_id = mfe.Struct_id AND mfm.Ayid = mfe.Ayid WHERE a.del_flag = 0 AND b.del_flag = 0 AND mfe.Fine_flag != '1' and a.stud_Category !='OPEN' AND c.del_flag = 0 AND mfe.del_flag = 0 AND mfm.del_flag = 0 AND mfi.del_flag = 0 AND mfe.Pay_date BETWEEN CONVERT(datetime, '" + fromdate + "', 120) AND CONVERT(datetime, '" + todate + "', 120))tbl";
                }

                

                DataTable dt = cls.fillDataTable(qry);
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
                    ddlcat.SelectedIndex = 0;
                    btnexcel.Visible = false;
                    ddlcat.Enabled = true;
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('No payment for specified dates','danger')", true);

                }
            }
        }
        catch (Exception h)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('" + h.Message + "','danger')", true);

        }
    }


    protected void grd_DataBound(object sender, EventArgs e)
    {
        int[] mergeCols = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
        MergeRows(grd, mergeCols, 4);
    }

    private void MergeRows(GridView gridView, int[] cols, int keyColIndex)
    {
        for (int rowIndex = gridView.Rows.Count - 2; rowIndex >= 0; rowIndex--)
        {
            GridViewRow row = gridView.Rows[rowIndex];
            GridViewRow nextRow = gridView.Rows[rowIndex + 1];

            if (row.Cells[keyColIndex].Text == nextRow.Cells[keyColIndex].Text)
            {
                foreach (int colIndex in cols)
                {
                    if (row.Cells[colIndex].Text == nextRow.Cells[colIndex].Text)
                    {
                        if (nextRow.Cells[colIndex].RowSpan < 2)
                        {
                            row.Cells[colIndex].RowSpan = 2;
                        }
                        else
                        {
                            row.Cells[colIndex].RowSpan = nextRow.Cells[colIndex].RowSpan + 1;
                        }
                        nextRow.Cells[colIndex].Visible = false;
                    }
                }
            }
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
            ddlcat.ClearSelection();
            ddlcat.Enabled = true;
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


    protected void ddlcat_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlcat.SelectedItem.ToString() == "OPEN")
        {
            ddlcategory.Value = "OPEN";
        }
        else
        {
            ddlcategory.Value = "OBC";
        }
    }
}