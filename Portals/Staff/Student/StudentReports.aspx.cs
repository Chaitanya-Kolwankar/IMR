using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Portals_Staff_Student_StudentReports : System.Web.UI.Page
{
    Class1 cls = new Class1();
    protected void Page_Load(object sender, EventArgs e)
    {

      
        if (!IsPostBack)
        {
            btngetexcel.Visible = false;
        }
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "func", "lstbx();", true);
    }

    protected void btngetdata_Click(object sender, EventArgs e)
    {
        string chked_lstboox = "";
        for (int i = 0; i < lsbx_stdfidls.Items.Count; i++)
        {
            if (lsbx_stdfidls.Items[i].Selected)
            {
                if (chked_lstboox == "")
                {
                    chked_lstboox = "" + lsbx_stdfidls.Items[i].Value + "";
                }
                else
                {
                    chked_lstboox = chked_lstboox + "," + lsbx_stdfidls.Items[i].Value;

                }

            }
        }
        if (chked_lstboox == "")
        {
            string grdqury = "select   a.stud_id as [Student ID],CONCAT(stud_L_Name,' ',stud_F_Name,' ',stud_M_Name) as [Student Name],g.Group_title as [Course Name], case when  p.stud_MartialStatus='0' then 'Unmarried' when p.stud_MartialStatus='1' then 'Married' else stud_MartialStatus end as [Marital Status], case when stud_Gender='1' then 'Male' when stud_Gender='0' then 'Female' else isnull(stud_Gender,'') end as[Gender], SUBSTRING(Remark,1,12)as [Adhaar No],adm.ty_Institute_name as [University Name Of Graduation],adm.ty_course as [Graduation Course],convert (varchar,adm.Curr_dt,105 )as[ Admission Date],convert(varchar,stud_DOB,105) as [Date Of Birth],adm.Board_name as [University Name] from m_std_studentacademic_tbl as a,m_std_personaldetails_tbl as p,m_crs_subjectgroup_tbl as g,d_adm_applicant as adm where adm.stud_id=a.stud_id and p.stud_id=adm.stud_id  and a.ayid='" + Session["Year"] +"' and a.Group_id=g.Group_id and a.subcourse_Id=g.Subcourse_id and a.stud_id=p.stud_id and a.group_id=g.Group_id and a.del_flag=0 and p.del_flag=0 order by [Course Name]";
            DataTable dt = cls.fillDataTable(grdqury);
            if (dt.Rows.Count > 0)
            {
                btngetexcel.Visible = true;
                grdrep.DataSource = dt;
                grdrep.DataBind();
            }
            else
            {
                btngetexcel.Visible = false;
            }
        }
        else
        {
            //string grdqury1 = "select a.stud_id as [Student ID],p.stud_F_Name as [First Name],p.stud_M_Name as [Middle Name],p.stud_L_Name as [Last Name],g.Group_title as [Course Name]," + chked_lstboox + ",CASE WHEN stud_MartialStatus=0 THEN 'Unmarried' when stud_MartialStatus=1 then 'Married' else '' end as [Marital Status]  from m_std_studentacademic_tbl as a,m_std_personaldetails_tbl as p,m_crs_subjectgroup_tbl as g where a.ayid='" + Session["Year"].ToString() + "' and a.stud_id=p.stud_id and a.group_id=g.Group_id and a.del_flag=0 and p.del_flag=0 order by [First Name],[Middle Name],[Last Name] asc";

            string grdqury1 = "select   a.stud_id as [Student ID],CONCAT(stud_L_Name,' ',stud_F_Name,' ',stud_M_Name) as [Student Name],g.Group_title as [Course Name],case when  p.stud_MartialStatus='0' then 'Unmarried' when p.stud_MartialStatus='1' then 'Married' else stud_MartialStatus end as [Marital Status], case when stud_Gender='1' then 'Male' when stud_Gender='0' then 'Female' else isnull(stud_Gender,'') end as[Gender], SUBSTRING(Remark,1,12)as [Adhaar No],adm.ty_Institute_name as [University Name Of Graduation],adm.ty_course as [Graduation Course],convert (varchar,adm.Curr_dt,105 )as[ Admission Date],convert(varchar,stud_DOB,105) as [Date Of Birth],adm.Board_name as [University Name]," + chked_lstboox+" from m_std_studentacademic_tbl as a,m_std_personaldetails_tbl as p,m_crs_subjectgroup_tbl as g,d_adm_applicant as adm where adm.stud_id=a.stud_id and p.stud_id=adm.stud_id  and a.ayid='" + Session["Year"] + "' and a.Group_id=g.Group_id and a.subcourse_Id=g.Subcourse_id and a.stud_id=p.stud_id and a.group_id=g.Group_id and a.del_flag=0 and p.del_flag=0 order by [Course Name] ";

            //string grdqury1 = "select a.stud_id as [Student ID],p.stud_L_Name as [Last Name],p.stud_F_Name as [First Name],p.stud_M_Name as [Middle Name],g.Group_title as [Course Name]," + chked_lstboox + ",stud_MartialStatus,p.stud_Gender  from m_std_studentacademic_tbl as a,m_std_personaldetails_tbl as p,m_crs_subjectgroup_tbl as g where a.ayid='" + Session["Year"].ToString() + "' and a.stud_id=p.stud_id and a.group_id=g.Group_id and a.del_flag=0 and p.del_flag=0 order by [First Name],[Middle Name],[Last Name] asc";
            DataTable dt2 = cls.fillDataTable(grdqury1);
            if (dt2.Rows.Count > 0)
            {
                grdrep.DataSource = dt2;
                grdrep.DataBind();
                btngetexcel.Visible = true;
            }
            else {
                btngetexcel.Visible = false;          
            }
        }
    }

    protected void btngetexcel_Click(object sender, EventArgs e)
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
        grdrep.GridLines = GridLines.Both;
        grdrep.HeaderStyle.Font.Bold = true;
        grdrep.RenderControl(htmltextwrtter);
        string style = @"<style> td { mso-number-format:\@; } </style> ";
        Response.Write(style);
        Response.Write(strwritter.ToString());
        Response.End();
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
           server control at run time. */
    }

    protected void btnclr_Click(object sender, EventArgs e)
    {
        btngetexcel.Visible = false;
        grdrep.DataSource = null;
        grdrep.DataBind();
        for (int i = 0; i < lsbx_stdfidls.Items.Count; i++)
        {
            if (lsbx_stdfidls.Items[i].Selected)
            {
                lsbx_stdfidls.Items[i].Selected = false;
            }

        }
    }

    protected void Unnamed_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
}