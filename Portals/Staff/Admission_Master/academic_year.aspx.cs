using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;

public partial class Portals_Staff_Admission_academic_year : System.Web.UI.Page
{
    Class1 cls = new Class1();


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Convert.ToString(Session["Emp_id"]) == "")
            {
                Response.Redirect("~/Portals/Staff/Login.aspx");
            }
            else
            {
                page_load_data();
            }

        }
        GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;

        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "func", "datepic()", true);

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {



            string chk_same_date = "select * from m_academic where Duration='" + txtfrom.Value.ToString() + "-" + txtto.Value.ToString() + "';";
            DataTable dt = cls.fillDataTable(chk_same_date);
            if (dt.Rows.Count > 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Academic Year Already Exist.','danger')", true);
            }
            else
            {

                string formyear = txtfrom.Value;
                string toyear = txtto.Value;

                if (formyear != "" && toyear != "")
                {
                    if (txtfrom.Value.ToString() != txtto.Value.ToString())
                    {
                        string autoid = cls.Auto_ID("m_academic", "AYID", "AYD00");
                        bool chkfire = cls.DMLqueries("insert into m_academic values('" + autoid + "','" + txtfrom.Value.ToString() + "-" + txtto.Value.ToString() + "','',0)");
                        if (chkfire)
                        {
                            page_load_data();
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Academic Year Added Successfully.','success')", true);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Some Problem Occured','danger')", true);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Dates Can't Be Same','danger')", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Kindly Select From And To Year','danger')", true);
                }
            }
        }
        catch (Exception d)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('" + d.Message + "','danger')", true);

        }



    }

    public void page_load_data()
    {

        string query = "select AYID,Duration,IsCurrent from m_academic order by AYID desc";
        DataTable t1 = new DataTable();
        t1 = cls.fillDataTable(query);
        if (t1.Rows.Count > 0)
        {
            GridView1.DataSource = t1;
            GridView1.DataBind();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "func", "datepic()", true);
        }
        else
        {

            //  ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No data Found')", true);

        }

    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowIndex == 0)
                    e.Row.Style.Add("height", "50px");
                Label lblgender = (Label)e.Row.FindControl("IsCurrent");
                CheckBox chk_is_cuurent = (CheckBox)e.Row.FindControl("chk_IsCurrent");
                if (lblgender.Text == "False")
                {
                    chk_is_cuurent.Checked = false;
                }
                else
                {
                    chk_is_cuurent.Checked = true;
                }

            }
        }
        catch (Exception d)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('" + d.Message + "','danger')", true);
        }

        //check if the row is the header row
        if (e.Row.RowType == DataControlRowType.Header)
        {
            //add the thead and tbody section programatically
            e.Row.TableSection = TableRowSection.TableHeader;
        }
    }
    protected void chk_IsCurrent_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            foreach (GridViewRow gvrw in GridView1.Rows)
            {
                Label lblayid = (Label)gvrw.FindControl("grdlblayid");
                CheckBox chkched = (CheckBox)gvrw.FindControl("chk_IsCurrent");
                if (chkched.Checked)
                {

                    string iscurrent = "update m_academic set IsCurrent='1' where AYID='" + lblayid.Text + "'";
                    bool chequery = cls.DMLqueries(iscurrent);
                    if (chequery)
                    {
                        page_load_data();

                     

                    }
                }

                else
                {
                    string iscurrent = "update m_academic set IsCurrent='0' where AYID='" + lblayid.Text + "'";
                    bool chequery = cls.DMLqueries(iscurrent);
                    if (chequery)
                    {
                        page_load_data();

                    }
                }
            }
            //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('" + d.Message + "','danger')", true);
            Session["Year"] = "";
            Response.Redirect(HttpContext.Current.Request.Url.ToString(), true);
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('" + cls.fillDataTable("select Duration from  m_academic where IsCurrent=1").Rows[0]["Duration"].ToString() + " set as Current Year','success')", true);
            


        }
        catch (Exception d)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('" + d.Message + "','danger')", true);
        }
    }

}