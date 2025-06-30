using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Text;
using System.IO;
using System.Linq;
using System.Collections.Generic;

public partial class Fee_Master : System.Web.UI.Page
{
    
    Class1 cls = new Class1();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                if (Convert.ToString(Session["Emp_id"]) == "")
                {
                    Response.Redirect("~/Portals/Staff/Login.aspx");
                }
                else
                {
                    //LoadDdlYear();
                    ddlFaculty();
                    //txtstruct.Enabled = false;
                    //txtamunt.Enabled = false;
                    //rankTxt.Enabled = false;
                    //lastdt.Enabled = false;
                    //save.Enabled = false;
                }
            }
            catch (Exception d)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify(' " + d.Message + "','danger')", true);
            }
        }
        //   GrdIn.HeaderRow.TableSection = TableRowSection.TableHeader;
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "func", "datepicker()", true);
    }
    //public void LoadDdlYear()
    //{
    //    DataTable dt = cls.fillDataTable("select * from m_academic order by ayid desc");
    //    ddlyearfee.DataSource = dt;
    //    ddlyearfee.DataTextField = "Duration";
    //    ddlyearfee.DataValueField = "AYID";
    //    ddlyearfee.DataBind();

    //    ddlyearfee.Items.Insert(0, "----SELECT----");
    //    ddlyearfee.SelectedIndex = 1;
    //    Session["Year"] = dt.Rows[0]["AYID"];
    //}
    public void ddlFaculty()
    {
        try
        {

            string facultyQuery = "select faculty_id,faculty_name from m_crs_faculty where del_flag=0";
            DataTable dt = new DataTable();
            dt = cls.fillDataTable(facultyQuery);
            ddl_Faculty.DataTextField = dt.Columns["faculty_name"].ToString();
            ddl_Faculty.DataValueField = dt.Columns["faculty_id"].ToString();
            ddl_Faculty.DataSource = dt;
            ddl_Faculty.DataBind();
            ddl_Faculty.Items.Insert(0, new ListItem("--Select--", "na"));
            // grid.HeaderRow.TableSection = TableRowSection.TableHeader;


        }
        catch (Exception d)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify(' " + d.Message + "','danger')", true);
            // grid.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }

    protected void ddl_Faculty_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            string queryFor = "select course_id,course_name from m_crs_course_tbl where del_flag='0' and faculty_id='" + ddl_Faculty.SelectedValue.ToString() + "'";
            DataTable dtcrs = new DataTable();
            dtcrs = cls.fillDataTable(queryFor);
            ddl_course.DataTextField = dtcrs.Columns["course_name"].ToString();
            ddl_course.DataValueField = dtcrs.Columns["course_id"].ToString();
            ddl_course.DataSource = dtcrs;
            ddl_course.DataBind();
            ddl_course.Items.Insert(0, new ListItem("--Select--", "na"));
            if (ddl_Faculty.SelectedIndex == 0)
            {
                ddl_course.Items.Clear();
                ddl_Subcourse.Items.Clear();
                dll_Group.Items.Clear();
                rankTxt.Text = "";
                rankTxt.Text = "";
            }
            
            grid.DataBind();
            grid.DataSource = null;
            txtstruct.Text = "";
            txtamunt.Text = "";
            lastdt.Text = "";
            //   grid.HeaderRow.TableSection = TableRowSection.TableHeader;

        }
        catch (Exception d)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify(' " + d.Message + "','danger')", true);
            //    grid.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }
    protected void ddl_course_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {


            string queryFor = "select subcourse_id,subcourse_name from m_crs_subcourse_tbl where course_id='" + ddl_course.SelectedValue.ToString() + "' and del_flag='0'";
            DataTable dtsubcrs = new DataTable();
            dtsubcrs = cls.fillDataTable(queryFor);
            if (dtsubcrs.Rows.Count > 0)
            {               
                ddl_Subcourse.DataTextField = dtsubcrs.Columns["subcourse_name"].ToString();
                ddl_Subcourse.DataValueField = dtsubcrs.Columns["subcourse_id"].ToString();
                ddl_Subcourse.DataSource = dtsubcrs;             
                ddl_Subcourse.DataBind();
                grid.DataSource = null;
                ddl_Subcourse.Items.Insert(0, new ListItem("--Select--", "na"));
            }
            else 
            {
                if (ddl_course.SelectedIndex == 0)
                {
                    grid.DataSource = null;
                    grid.DataBind();
                    dll_Group.Items.Clear();
                    ddl_Subcourse.Items.Clear();                   
                    txtstruct.Text = "";
                    txtamunt.Text = "";
                    rankTxt.Text = "";
                    lastdt.Text = "";
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('no subcourse assigned to this course.','danger')", true);
                    ddl_course.SelectedIndex = 0;
                }
            }
            
              
            
            //dll_Group.Items.Clear();
            //dll_Group_SelectedIndexChanged(this, EventArgs.Empty);
        }
        catch (Exception d)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify(' " + d.Message + "','danger')", true);
            //  grid.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }

    protected void ddl_Subcourse_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            string queryFor = "select Group_id,Group_title from m_crs_subjectgroup_tbl where Subcourse_id='" + ddl_Subcourse.SelectedValue.ToString() + "' and del_flag='0'";
            DataTable dtsubcrs = new DataTable();
            dtsubcrs = cls.fillDataTable(queryFor);
            if (dtsubcrs.Rows.Count > 0)
            {
                dll_Group.DataTextField = dtsubcrs.Columns["Group_title"].ToString();
                dll_Group.DataValueField = dtsubcrs.Columns["Group_id"].ToString();
                //dll_Group_SelectedIndexChanged(this, EventArgs.Empty);
                dll_Group.DataSource = dtsubcrs;
                dll_Group.DataBind();
                grid.DataSource = null;
                dll_Group.Items.Insert(0, new ListItem("--Select--", "na"));
                dll_Group_SelectedIndexChanged(this, EventArgs.Empty);
            }
            else
            {
                if (ddl_Subcourse.SelectedIndex == 0)
                {
                    dll_Group.Items.Clear();
                    grid.DataSource = null;
                    grid.DataBind();
                    txtamunt.Text = "";
                    txtstruct.Text = "";
                    rankTxt.Text = "";
                    lastdt.Text = "";
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('no Group assign to this subcourse.','danger')", true);
                    dll_Group.SelectedIndex = 0;
                }
            }
          
            //  grid.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch (Exception d)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify(' " + d.Message + "','danger')", true);
            //  grid.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }
    protected void dll_Group_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            loadgridview();
            // grid.HeaderRow.TableSection = TableRowSection.TableHeader;
            if (dll_Group.SelectedIndex==0) 
            {
                txtstruct.Text = "";
                txtamunt.Text = "";
                rankTxt.Text = "";
                lastdt.Text = "";

            
            }

        }
        catch (Exception d)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify(' " + d.Message + "','danger')", true);
            // grid.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }





    // insert and update function start

    protected void save_Click(object sender, EventArgs e)
    {
        try
        {
            string lastdate = lastdt.Text;
          
            if (ddl_Faculty.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify(' Select Faculty.','danger')", true);
              //  grid.HeaderRow.TableSection = TableRowSection.TableHeader;

            }

            else if (ddl_course.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify(' Select Course.','danger')", true);
                //grid.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            else if (ddl_Subcourse.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify(' Select Subcourse.','danger')", true);
                //grid.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            else if (dll_Group.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify(' Select Group.','danger')", true);
               // grid.HeaderRow.TableSection = TableRowSection.TableHeader;


            }
            else if (txtstruct.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify(' Add Structure.','danger')", true);
                //grid.HeaderRow.TableSection = TableRowSection.TableHeader;

            }

            else if (txtamunt.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify(' Add Amount.','danger')", true);
                //grid.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            
            else if (lastdt.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify(' Add Last Date of Payment.','danger')", true);
              //  grid.HeaderRow.TableSection = TableRowSection.TableHeader;


            }
            else
            {

                if (save.Text == "Add")
                {                   
            
                    string chkstruct = "select * from m_FeeMaster where Ayid = '"+ Session["Year"] + "' and Group_id = '" + dll_Group.SelectedValue.ToString() + "' and Struct_name = '"+ txtstruct.Text.Trim() + "' and del_flag = 0";
                    DataTable dtchkstruct = cls.fillDataTable(chkstruct);
                    if (dtchkstruct.Rows.Count > 0)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Structure  Name Must Be Unique','danger')", true);
                        txtstruct.Text = "";
                        txtamunt.Text = "";
                        rankTxt.Text = "";
                        lastdt.Text = "";
                     
                    }
                    else 
                    {

                        if (rankTxt.Text != "")
                        {
                            List<int> list = new List<int>();
                            //  List<int> intList = stringList.ConvertAll(int.Parse);
                            foreach (GridViewRow gvr in grid.Rows)
                            {
                                Label grdrank = (Label)gvr.FindControl("RankLbl");
                                if (grdrank.Text != "")
                                {
                                    list.Add(int.Parse(grdrank.Text));
                                }
                            }
                            string rankdup = rankTxt.Text;
                            bool isInList = list.IndexOf(int.Parse(rankdup)) != -1;
                            if (isInList)
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('This Rank is already Assigned.','danger')", true);
                                return;
                            }
                        }


                        string inserfeemaster = "insert into m_FeeMaster (Ayid,Group_id,Struct_name,Amount,LastDayOFPay,Rank,user_id,curr_dt,mod_dt,del_flag,del_dt) values('" + Session["Year"] + "','" + dll_Group.SelectedValue.ToString() + "','" + txtstruct.Text.Trim() + "','" + txtamunt.Text.Trim() + "',convert(datetime,'" + lastdt.Text.Trim() + "',103),NULLIF('" + rankTxt.Text.Trim() + "',''),'Admin',getdate(),'',0,'')";
                        if (cls.DMLqueries_string(inserfeemaster) == "True")
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify(' Fee Structure Added Successfully.','success')", true);
                            txtstruct.Text = "";
                            txtamunt.Text = "";
                            lastdt.Text = "";
                            rankTxt.Text = string.Empty;
                            loadgridview();
                            //grid.HeaderRow.TableSection = TableRowSection.TableHeader;
                        }
                        //else if (cls.DMLqueries_string(inserfeemaster).ToString().Contains("ClusteredIndex-20220411-134809"))
                        //{
                        //    grid.HeaderRow.TableSection = TableRowSection.TableHeader;

                        //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify(' Rank Must Be Unique ','danger')", true);
                        //}
                        else if (cls.DMLqueries_string(inserfeemaster).ToString().Contains("Idx_ayidGroupStruct"))
                        {
                            //grid.HeaderRow.TableSection = TableRowSection.TableHeader;
                            string msg = cls.DMLqueries_string(inserfeemaster).ToString();
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Structure  Name Must Be Unique','danger')", true);
                            // grid.HeaderRow.TableSection = TableRowSection.TableHeader;
                        }
                        else
                        {

                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Something went wrong','danger')", true);

                            //grid.HeaderRow.TableSection = TableRowSection.TableHeader; 
                        }

                    }

                }
                else if (save.Text == "Update")
                {
                   
                    string group_id = dll_Group.SelectedValue;
                    string structcheck = "select * from m_FeeMaster where Ayid='" + Session["Year"].ToString() + "' and Group_id='" + group_id + "' and del_flag=0 and Struct_name!='" + ViewState["oldstruct"].ToString() + "'and Struct_name = '" + txtstruct.Text.Trim() + "' ";
                    DataTable structchk = cls.fillDataTable(structcheck);
                    if (structchk.Rows.Count > 0)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify(' Structure Name Should Be Unique.','danger')", true);
                        return;
                    }
                    if (rankTxt.Text != "")
                    {
                        foreach (GridViewRow grd in grid.Rows)
                        {
                            Label grdrnkup = (Label)grd.FindControl("RankLbl");
                            if (grd.DataItemIndex.ToString() == ViewState["indeditbtn"].ToString())
                            {

                            }
                            else
                            {
                                if (rankTxt.Text.Trim() == grdrnkup.Text.Trim())
                                {

                                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Rank shoul be unique','danger')", true);
                                    return;
                                }

                            }

                        }
                    }
                    string updatefeemaster = "update m_FeeMaster set Rank=NULLIF('" + rankTxt.Text.Trim() + "','') , Ayid='" + Session["Year"].ToString() + "', Struct_name='" + txtstruct.Text.Trim() + "' ,Group_id='" + group_id + "',Amount='" + txtamunt.Text.Trim() + "',LastDayOfPay=Convert(datetime,'" + lastdate + "',103),mod_dt=GETDATE() where Ayid='" + Session["Year"] + "' and Group_id='" + Session["sess_grupidd"] + "' and Struct_name='" + Session["sessstructname"]
      + "' ";
                    if (cls.DMLqueries_string(updatefeemaster) == "True")
                    {
                        loadgridview();
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify(' Fee Structure Updated Successfully.','success')", true);
                        ddl_Faculty.Enabled = true;
                        ddl_course.Enabled = true;
                        ddl_Subcourse.Enabled = true;

                        dll_Group.Enabled = true;

                        save.Text = "Add";
                        //ddl_Faculty.SelectedIndex = 0;
                        //ddl_course.SelectedIndex = 0;
                        //ddl_Subcourse.SelectedIndex = 0;
                        //dll_Group.SelectedIndex = 0;
                        txtstruct.Text = "";
                        txtamunt.Text = "";
                        lastdt.Text = "";
                        rankTxt.Text = string.Empty;

                    }
                    else 
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Something went wrong','success')", true);

                    }
                    string rankdup = rankTxt.Text.Trim();                  
                    List<int> listb = new List<int>();
                    foreach (GridViewRow gvr2 in grid.Rows)
                    {
                        Label grdrnkup = (Label)gvr2.FindControl("RankLbl");
                        if (grdrnkup.Text != "")
                        {

                            listb.Add(int.Parse(grdrnkup.Text));

                        }
                    }
                    string rankdup2 = rankTxt.Text;
                    if (rankdup2!="")
                    {
                        bool isInList2 = listb.IndexOf(int.Parse(rankdup2)) != -1;
                        if (isInList2)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Rank Should be unique','danger')", true);
                            rankTxt.Text = "";
                            return;
                        }
                    }                                                        
                    
                    
                 
                }
           }
                
           
        }
        catch (Exception d)
        {
            //grid.HeaderRow.TableSection = TableRowSection.TableHeader;
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify(' " + d.Message + "','danger')", true);
        }
    }
    // insert and update function end

    // grid loading start
    public void loadgridview()
    {
        string gridquery = "select  e.faculty_name,e.faculty_id,d.course_name,d.course_id,c.subcourse_id,c.subcourse_name,b.Group_title,a.Group_id,a.Amount,a.Struct_name,convert(varchar,a.LastDayOfPay,103) as lstdate,a.Rank from m_FeeMaster a,                m_crs_subjectgroup_tbl as b,m_crs_subcourse_tbl as c,m_crs_course_tbl as d,m_crs_faculty as e where a.Group_id=b.Group_id and b.Subcourse_id=c.subcourse_id and d.course_id=c.course_id and e.faculty_id=d.faculty_id and a.group_id='" + dll_Group.SelectedValue + "'  and a.Ayid='" + Session["Year"] + "' and a.del_flag=0 order by  a.Struct_name asc";
        DataTable dtgridqury = cls.fillDataTable(gridquery);
        grid.DataSource = dtgridqury;
        grid.DataBind();
        // GrdIn.HeaderRow.TableSection = TableRowSection.TableHeader;
        if (dtgridqury.Rows.Count == 0 && dll_Group.SelectedIndex != 0)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Fee structure not defined for this group','danger')", true);
           // dll_Group.SelectedIndex = 0;
        }
    }
    // grid loading end

    //  checking dublication of records  at insertion time start
    private bool checkInsert()
    {
        bool rank = false;
        DataTable ds = new DataTable();
        ds = cls.fillDataTable("select * from   m_FeeMaster where   Struct_name ='" + txtstruct.Text.Trim() + "' or Rank='" + rankTxt.Text.Trim() + "'");
        //Convert(datetime,'" + lastdt.Text + "',103)
        if (ds.Rows.Count > 0)
        {
            return true;
        }
        return rank;
    }
    //  checking dublication of records insertion end

    //  checking dublication of records  at updation time star
    private bool checkUpdate()
    {
        bool rank = false;
        DataTable ds = new DataTable();
        ///Select * from  (select * from   m_FeeMaster where    Struct_name <> (select Struct_name from m_FeeMaster where Ayid='AYD0075' and Group_id='GRP031' and Struct_name='Tution Feees')) as a where  a.Struct_name='Tution Feees'
        ds = cls.fillDataTable("Select * from  (select * from   m_FeeMaster where    Struct_name <> (select Struct_name from m_FeeMaster where Ayid='" + Session["Year"] + "' and Group_id='" + dll_Group.SelectedValue + "' and Struct_name='" + txtstruct.Text.Trim() + "')) as a where  a.Struct_name='" + txtstruct.Text.Trim() + "'");
        //ds = cls.fillDataTable("select * from   m_FeeMaster where    Struct_name <> (select Struct_name from m_FeeMaster where Ayid='"+Session["Year"]+"' and Group_id='"+dll_Group.SelectedValue+"' and Struct_name='"+txtstruct.Text+"')");
        //ds = cls.fillDataTable("select * from   m_FeeMaster where   Struct_name ='" + txtstruct.Text + "'");
        //Convert(datetime,'" + lastdt.Text + "',103)
        if (ds.Rows.Count > 0)
        {
            return true;
        }
        return rank;
    }


    //  checking dublication of records updation end


    private bool checkRank()
    {
        bool rank = false;

        DataTable ds = new DataTable();
        ds = cls.fillDataTable("Select * from  (select * from   m_FeeMaster where    Rank <> (select Rank from m_FeeMaster where Ayid='" + Session["Year"] + "' and Group_id='" + dll_Group.SelectedValue + "' and Rank='" + rankTxt.Text + "')) as a where  a.Rank='" + rankTxt.Text + "'");
        //ds = cls.fillDataTable("select * from   m_FeeMaster where  Rank='" + rankTxt.Text + "'");
        //Convert(datetime,'" + lastdt.Text + "',103)
        if (ds.Rows.Count > 0)
        {
            return true;

        }

        return rank;


    }


    // grid Edit  start

    protected void grdbtnedit_Click(object sender, EventArgs e)
    {
        try
        {
            LinkButton btn = sender as LinkButton;
           
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            ViewState["indeditbtn"] = row.RowIndex;
            Label fac = (Label)row.FindControl("lblgrdfaculname") as Label;
            Label cour = (Label)row.FindControl("lblgrdCou") as Label;
            Label subcour = (Label)row.FindControl("lblgrdsubcou") as Label;
            Label grup = (Label)row.FindControl("lblgrdgroup") as Label;
            Label strucname = (Label)row.FindControl("lblgrdstruct") as Label;
            Session["sessstructname"] = strucname.Text;
            ViewState["oldstruct"] = ((Label)row.FindControl("lblgrdstruct") as Label).Text;
            Label amnt = (Label)row.FindControl("lblgrdamunt") as Label;
            Label lstpay = (Label)row.FindControl("lblgrdlstdatpay") as Label;
            //==========id=======
            Label lblfacid = (Label)row.FindControl("facid") as Label;
            Label lblcouid = (Label)row.FindControl("couid") as Label;
            Label lblsubcouid = (Label)row.FindControl("subcouid") as Label;
            Label lblgrpid = (Label)row.FindControl("grpid") as Label;
            Label lblRank = (Label)row.FindControl("RankLbl") as Label;
            Session["sess_grupidd"] = lblgrpid.Text;
            //Session["sess_year"] = ddlyearfee.SelectedValue.ToString();
            ddl_Faculty.Enabled = false;
            ddl_course.Enabled = false;
            ddl_Subcourse.Enabled = false;
            dll_Group.Enabled = false;
            ddl_Faculty.SelectedValue = ddl_Faculty.Items.FindByValue(lblfacid.Text).Value;
            ddl_Faculty_SelectedIndexChanged(this, EventArgs.Empty);
            ddl_course.SelectedValue = ddl_course.Items.FindByValue(lblcouid.Text).Value;
            ddl_course_SelectedIndexChanged(this, EventArgs.Empty);
            ddl_Subcourse.SelectedValue = ddl_Subcourse.Items.FindByValue(lblsubcouid.Text).Value;
            ddl_Subcourse_SelectedIndexChanged(this, EventArgs.Empty);
            dll_Group.SelectedValue = dll_Group.Items.FindByValue(lblgrpid.Text).Value;
            dll_Group_SelectedIndexChanged(this, EventArgs.Empty);
            txtstruct.Text = strucname.Text;
            txtamunt.Text = amnt.Text;
            lastdt.Text = lstpay.Text;
            rankTxt.Text = lblRank.Text;
            save.Text = "Update";
        }
        catch (Exception d)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify(' " + d.Message + "','danger')", true);
        }
    }

    // grid Edit  end


    // grid Delete start


    protected void grdbtndel_Click(object sender, EventArgs e)
    {
        try
        {
            LinkButton btndel = sender as LinkButton;
            // Button btndel = (Button)sender;
            GridViewRow row2 = (GridViewRow)btndel.NamingContainer;
            Label strucname2 = (Label)row2.FindControl("lblgrdstruct") as Label;
            Label lblfacid2 = (Label)row2.FindControl("facid") as Label;
            Label lblcouid2 = (Label)row2.FindControl("couid") as Label;
            Label lblsubcouid2 = (Label)row2.FindControl("subcouid") as Label;
            Label lblgrpid2 = (Label)row2.FindControl("grpid") as Label;
            Label lblrank = (Label)row2.FindControl("RankLbl") as Label;
            //Session["sessayid_del"] = ddlyearfee.SelectedValue.ToString();]
            string chkdel = "select * from m_std_studentacademic_tbl where stud_id in (select stud_id from m_FeeEntry where Struct_name='" + strucname2.Text + "' and Ayid='" + Session["Year"] + "' and del_flag=0) and del_flag=0 and group_id='" + lblgrpid2 + "'";
            cls.fillDataTable(chkdel);
            DataTable dtchk = new DataTable();
            dtchk = cls.fillDataTable(chkdel);
            if (dtchk.Rows.Count > 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Stucture Name Deletion restricted'danger')", true);

            }

            else
            {
                string del_query = "update m_FeeMaster set del_flag=1 where Ayid='" + Session["Year"] + "' and Group_id='" + lblgrpid2.Text.Trim() + "' and Struct_name='" + strucname2.Text.Trim()+"  '";
                if (cls.DMLqueries(del_query))
                {

                    ddl_Faculty.Enabled = true;
                    ddl_course.Enabled = true;
                    ddl_Subcourse.Enabled = true;
                    dll_Group.Enabled = true;
                    txtstruct.Text = string.Empty;
                    txtamunt.Text = string.Empty;
                    lastdt.Text = string.Empty;
                    rankTxt.Text = string.Empty;
                    //ddl_Faculty.SelectedIndex = 0;
                    //ddl_Subcourse.SelectedIndex = 0;
                    //dll_Group.SelectedIndex = 0;
                    //ddl_course.SelectedIndex = 0;
                    save.Text = "Add";
                    cls.DMLqueries(del_query);
                    loadgridview();
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Delete Successful','success')", true);
                }
                else { ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('something went wrong.','success')", true); }
            }

        }
        catch (Exception d)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify(' " + d.Message + "','danger')", true);
        }
    }

    // grid Delete end


    // cancel button start

    protected void btncancel_Click(object sender, EventArgs e)
    {
        try
        {

            save.Text = "Add";
            ddl_Faculty.SelectedIndex = 0;
            ddl_Subcourse.SelectedIndex = 0;
            ddl_course.SelectedIndex = 0;
            dll_Group.SelectedIndex = 0;
            ddl_Faculty.Enabled = true;
            ddl_course.Enabled = true;
            ddl_Subcourse.Enabled = true;
            dll_Group.Enabled = true;
            txtstruct.Text = "";
            txtamunt.Text = "";
            lastdt.Text = "";
            rankTxt.Text = string.Empty;
            grid.DataBind();
            grid.DataSource = null;
            ddlFaculty();
            ddl_Faculty.SelectedIndex = 0;
            //ddl_Faculty_SelectedIndexChanged(this, EventArgs.Empty);
            ddl_course.Items.Clear();
            ddl_Subcourse.Items.Clear();
            dll_Group.Items.Clear();
            //ddl_course.DataSource = null;
            //ddl_course.DataBind();
            //ddl_Subcourse.DataSource = null;
            //ddl_Subcourse.DataBind();
            //dll_Group.DataSource = null;
            //dll_Group.DataBind();
            

        }
        catch (Exception d)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify(' " + d.Message + "','danger')", true);
        }
    }


    // cancel button end




    // grid row data bound event start
    protected void grid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //check if the row is the header row
        if (e.Row.RowType == DataControlRowType.Header)
        {
            //add the thead and tbody section programatically
            e.Row.TableSection = TableRowSection.TableHeader;
        }
    }

    // grid row data bound event end
}