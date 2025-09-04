using iTextSharp.tool.xml.css;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Portals_Staff_Fee_Installment_Receipt : System.Web.UI.Page
{
    Class1 cls= new Class1();
    protected void Page_Load(object sender, EventArgs e)
    {


        if (!IsPostBack)
        {
            if (Convert.ToString(Session["install_stud_id"]) != "")
            {
                try
                {
                    string install_stud_id = Session["install_stud_id"].ToString();
                    string instll_group_id = Session["instll_group_id"].ToString();
                    string install_ayid = Session["install_ayid"].ToString();

                    DataSet ds = cls.fillDataset("DECLARE @stud_id VARCHAR(10)='" + install_stud_id + "', @ayid VARCHAR(10)='" + install_ayid + "', @groupid VARCHAR(10)='" + instll_group_id + "';SELECT ISNULL(p.stud_F_Name, '') + ' ' + ISNULL(p.stud_M_Name, '') + ' ' + ISNULL(p.stud_L_Name, '') AS [Name],p.stud_Category, g.Group_title AS [Group],a.Roll_no FROM m_std_studentacademic_tbl a INNER JOIN m_std_personaldetails_tbl p ON a.stud_id = p.stud_id INNER JOIN m_crs_subjectgroup_tbl g ON a.group_id = g.Group_id WHERE a.stud_id = @stud_id AND a.AYID=@ayid and a.del_flag = 0 AND g.del_flag = 0 ORDER BY a.ayid;select Install_id,Install_no,CONVERT(varchar, Due_date, 103)[Due_date],Install_Amount,balance_Amount from m_FeeInstallment where Stud_id=@stud_id and Ayid=@ayid  and Group_id=@groupid and Del_flag=0 order by Install_no;");
                    ds.Tables[0].TableName = "StdInfo";
                    ds.Tables[1].TableName = "Install";
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables["Install"].Rows.Count == 0 || ds.Tables["StdInfo"].Rows.Count == 0)
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "$.notify('Something Went Wrong !!!', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0 })", true);
                            return;
                        }
                        else
                        {
                            lbl_date.Text = DateTime.Now.ToString("dd-MM-yyyy").Replace("-","/");
                            lblName.Text = ds.Tables["StdInfo"].Rows[0]["Name"].ToString().ToUpper();
                            lbl_stud_id.Text = install_stud_id;
                            lbl_rollno.Text = ds.Tables["StdInfo"].Rows[0]["Roll_no"].ToString();
                            lblcourse.Text = ds.Tables["StdInfo"].Rows[0]["Group"].ToString().ToUpper();
                            lblcategory.Text = ds.Tables["StdInfo"].Rows[0]["stud_category"].ToString();
                            grd_install.DataSource = ds.Tables["Install"];
                            grd_install.DataBind();
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "print", "window.print();", true);
                        }
                    }
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "$.notify('" + ex.ToString() + "', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0 })", true);
                }
            }
        }
    }
    public string getnum(int num)
    {
        switch (num)
        {
            case 1: return "ONE";
            case 2: return "TWO";
            case 3: return "THREE";
            case 4: return "FOUR";
            case 5: return "FIVE";
            case 6: return "SIX";
            case 7: return "SEVEN";
            case 8: return "EIGHT";
            case 9: return "NINE";
            case 10: return "TEN";
            default: return "INVALID";
        }
    }
}