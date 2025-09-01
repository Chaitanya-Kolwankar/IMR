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
                    course();
                }
            }
        }
        catch (Exception h)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('" + h.Message + "','danger')", true);

        }
    }


    public void course()
    {
        DataTable dtcou = cls.fillDataTable("select course_id,course_name from m_crs_course_tbl where del_flag=0");
        ddlcourse.DataTextField = dtcou.Columns["course_name"].ToString();
        ddlcourse.DataValueField = dtcou.Columns["course_id"].ToString();
        ddlcourse.DataSource = dtcou;
        ddlcourse.DataBind();
        ddlcourse.Items.Insert(0, new ListItem("--Select--", "NA"));
        //DropDownList chkddl=(DropDownList)ContentPlaceHolder1.FindControl();


        if (ddlcourse.SelectedIndex == 0)
        {
            grd.DataSource = null;
            grd.DataBind();
            //ddlfrmgrp.Items.Clear();
        }
    }


    public void course_selectedindexchanged()
    {
        DataTable dtsubcou = cls.fillDataTable("select subcourse_id,subcourse_name from m_crs_subcourse_tbl where course_id='" + ddlcourse.SelectedValue.ToString() + "' and del_flag=0");
        if (dtsubcou.Rows.Count > 0)
        {
            ddlsubcou.DataTextField = dtsubcou.Columns["subcourse_name"].ToString();
            ddlsubcou.DataValueField = dtsubcou.Columns["subcourse_id"].ToString();
            ddlsubcou.DataSource = dtsubcou;
            ddlsubcou.DataBind();
            ddlsubcou.Items.Insert(0, new ListItem("--Select--", "NA"));
            rdb_detl.Checked = true;
        }
        else
        {
            if (ddlcourse.SelectedIndex == 0)
            {
                grd.DataSource = null;
                grd.DataBind();
                //ddlfrmgrp.Items.Clear();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('no Subcourse to this course.','danger')", true);

                ddlsubcou.Items.Clear();
            }
        }
    }



    protected void ddlcourse_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            course_selectedindexchanged();
            if (ddlcourse.SelectedIndex == 0)
            {
                ddlsubcou.Items.Clear();
                ddlcat.Items.Clear();
                rdb_detl.Checked = true;
                grd.DataSource = null;
                grd.DataBind();
            }
        }
        catch (Exception d)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('" + d.Message + "','danger')", true);
        }
    }



    protected void rdb_detl_CheckedChanged(object sender, EventArgs e)
    {

    }


    protected void rdb_sumar_CheckedChanged(object sender, EventArgs e)
    {

    }


    public void ddL_category_selection()
    {
        DataTable dtcat = cls.fillDataTable("SELECT distinct parent FROM State_category_details where Main='Reserved Category' and Parent !='OPEN' and  del_flag=0");
        if (dtcat.Rows.Count > 0)
        {
            ddlcat.DataTextField = dtcat.Columns["parent"].ToString();
            ddlcat.DataValueField = dtcat.Columns["parent"].ToString();
            ddlcat.DataSource = dtcat;
            ddlcat.DataBind();
            ddlcat.Items.Insert(0, new ListItem("--Select--", "NA"));
            ddlcat.Items.Insert(1, new ListItem("OPEN", "OPEN"));
            rdb_detl.Checked = true;
            ddlcat.Enabled = true;
        }
        else
        {
            if (ddlcat.SelectedIndex == 0)
            {
                grd.DataSource = null;
                grd.DataBind();
                //ddlfrmgrp.Items.Clear();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('no Subcourse to this course.','danger')", true);

                ddlcat.Items.Clear();
            }
        }
    }


    protected void ddlsubcou_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ddL_category_selection();
            if (ddlsubcou.SelectedIndex == 0)
            {
                grd.DataSource = null;
                grd.DataBind();
            }
            //DataTable dtfrmgroup = cls.fillDataTable("SELECT Group_id,Group_title FROM m_crs_subjectgroup_tbl WHERE Subcourse_id='"+ddlsubcou.SelectedValue.ToString()+"' and del_flag=0");
            //ddlfrmgrp.DataTextField = dtfrmgroup.Columns["Group_title"].ToString();
            //ddlfrmgrp.DataValueField = dtfrmgroup.Columns["Group_id"].ToString();
            //ddlfrmgrp.DataSource = dtfrmgroup;
            //ddlfrmgrp.DataBind();
            //ddlfrmgrp.Items.Insert(0, new ListItem("--Select--", "NA"));
        }
        catch (Exception d)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('" + d.Message + "','danger')", true);

        }

    }




    protected void btngtdata_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlcourse.SelectedValue.ToString().Trim() == "NA")
            { ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Select Course','danger')", true); }
            else if (ddlsubcou.Text.Trim() == "NA")
            { ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Select Subcourse','danger')", true); }
            else if (ddlcat.SelectedItem.ToString() == "--Select--")
            { ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('Select the Category','danger')", true); }
            else
            {
                string fromdate = ddlcourse.Text.ToString().Trim();
                string todate = ddlsubcou.Text.ToString().Trim();
                string OtherCategory = ddlcat.SelectedValue.ToString();



                ddlcat.Enabled = false;



                string qry = "";
                if (rdb_detl.Checked == true)
                {
                    if (OtherCategory == "OPEN")
                    {
                        // qry = "select mfe.Install_id[Install ID],mfe.Stud_id[Student Id],(mspd.stud_F_Name+' '+mspd.stud_M_Name+' '+mspd.stud_L_Name) [Name],mcst.Group_title[Group Title],mspd.stud_Category[Category],case when mspd.stud_Gender='0' then 'Female' when mspd.stud_Gender='1' then 'Male' else 'Other' end as Gender,mfe.Pay_date[Pay Date],mfe.Receipt_no[Receipt No],mfe.Struct_name[Struct Name],mfe.Amount,mfe.Recpt_mode[Payment Mode],mfe.Recpt_Chq_No[Cheque No],mfe.Recpt_Chq_dt AS Cheque_dt,mfe.Recpt_Bnk_Name [Bank Name],mfe.Chq_status[Status],SUBSTRING(ma.Duration, 9, 4) + '-' + SUBSTRING(ma.Duration, 21, 4) AS duration from m_FeeEntry mfe, m_std_personaldetails_tbl mspd,m_crs_subjectgroup_tbl mcst, m_std_studentacademic_tbl msst,m_academic ma, m_crs_course_tbl mcct,m_crs_subcourse_tbl mcsc where mspd.stud_id = mfe.Stud_id and mcst.Group_id = msst.group_id and msst.stud_id = mfe.Stud_id and mcct.course_id = mcsc.course_id and mcst.Subcourse_id = mcsc.subcourse_id and ma.AYID = msst.ayid and mfe.del_flag = 0 and mspd.del_flag = 0 and mcst.del_flag = 0 and msst.del_flag = 0 and mcct.del_flag = 0 and mfe.Fine_flag != 1 and mcst.Subcourse_id = '" + ddlsubcou.SelectedValue + "' and mcct.course_id = '" + ddlcourse.SelectedValue + "' and mspd.stud_Category='" + ddlcat.SelectedValue + "'";

                        qry = "select * from (select(SELECT  mfi.Install_no FROM m_FeeInstallment mfi WHERE mfi.Install_id = mfe.Install_id and mfi.Stud_id = mfe.Stud_id and mfi.Del_flag = 0 and mfi.ayid = msst.ayid) AS[Install No], mfe.Stud_id[Stud ID], (mspd.stud_F_Name + ' ' + mspd.stud_M_Name + ' ' + mspd.stud_L_Name)[Name], mcst.Group_title[Group Title], mspd.stud_Category[Category],case when mspd.stud_Gender = '0' then 'Female' when mspd.stud_Gender = '1' then 'Male' else 'Other' end as Gender,Replace(convert(varchar(11), mfe.Pay_date, 106), ' ', '-') as [Pay Date],mfe.Receipt_no,mfe.Struct_name[Struct Name],mfe.Amount,mfe.Recpt_mode[Pay Mode],mfe.Recpt_Chq_No,mfe.Recpt_Chq_dt AS Cheque_dt,mfe.Recpt_Bnk_Name AS Bank_details,mfe.Chq_status,SUBSTRING(ma.Duration, 9, 4) + '-' + SUBSTRING(ma.Duration, 21, 4) AS Duration, mfm.Amount[StructAmount] from m_FeeMaster mfm, m_FeeEntry mfe, m_std_personaldetails_tbl mspd,m_crs_subjectgroup_tbl mcst, m_std_studentacademic_tbl msst,m_academic ma, m_crs_course_tbl mcct,m_crs_subcourse_tbl mcsc where mfm.Struct_id = mfe.Struct_id and mfm.ayid = msst.ayid and mfm.Gender = 'NON' and mfm.Group_id = mcst.Group_id and mspd.stud_id = mfe.Stud_id and mcst.Group_id = msst.group_id and msst.stud_id = mfe.Stud_id and mcct.course_id = mcsc.course_id and mcst.Subcourse_id= mcsc.subcourse_id and ma.AYID = msst.ayid and mfe.del_flag = 0 and mspd.del_flag = 0 and mcst.del_flag = 0 and msst.del_flag = 0 and mcct.del_flag = 0 and mfm.del_flag = 0 and mfe.Fine_flag = 0 and mcst.Subcourse_id = '" + ddlsubcou.SelectedValue + "' and mcct.course_id = '" + ddlcourse.SelectedValue + "' and mspd.stud_Category = 'OPEN')as tbl";
                    }
                    else if (OtherCategory != "OPEN")
                    {
                        //qry = "select mfe.Install_id[Install ID],mfe.Stud_id[Student Id],(mspd.stud_F_Name + ' ' + mspd.stud_M_Name + ' ' + mspd.stud_L_Name)[Name],mcst.Group_title[Group Title],mspd.stud_Category[Category],case when mspd.stud_Gender = '0' then 'Female' when mspd.stud_Gender = '1' then 'Male' else 'Other' end as Gender,mfe.Pay_date[Pay Date],mfe.Receipt_no[Receipt No],mfe.Struct_name[Struct Name],mfe.Amount,mfe.Recpt_mode[Payment Mode],mfe.Recpt_Chq_No[Cheque No],mfe.Recpt_Chq_dt AS Cheque_dt,mfe.Recpt_Bnk_Name [Bank Name],mfe.Chq_status[Status],SUBSTRING(ma.Duration, 9, 4) + '-' + SUBSTRING(ma.Duration, 21, 4) AS duration from m_FeeEntry mfe, m_std_personaldetails_tbl mspd, m_crs_subjectgroup_tbl mcst, m_std_studentacademic_tbl msst, m_academic ma, m_crs_course_tbl mcct, m_crs_subcourse_tbl mcsc where mspd.stud_id = mfe.Stud_id and mcst.Group_id = msst.group_id and msst.stud_id = mfe.Stud_id and mcct.course_id = mcsc.course_id and mcst.Subcourse_id = mcsc.subcourse_id and ma.AYID = msst.ayid and mfe.del_flag = 0 and mspd.del_flag = 0 and mcst.del_flag = 0 and msst.del_flag = 0 and mcct.del_flag = 0 and mfe.Fine_flag != 1 and mcst.Subcourse_id = '" + ddlsubcou.SelectedValue + "' and mcct.course_id = '" + ddlcourse.SelectedValue + "' and mspd.stud_Category = '" + ddlcat.SelectedValue + "'";

                        qry = "select * from (select(SELECT  mfi.Install_no FROM m_FeeInstallment mfi WHERE mfi.Install_id = mfe.Install_id and mfi.Stud_id = mfe.Stud_id and mfi.Del_flag = 0 and mfi.Ayid = msst.ayid) AS[Install No], mfe.Stud_id[Stud ID], (mspd.stud_F_Name + ' ' + mspd.stud_M_Name + ' ' + mspd.stud_L_Name)[Name], mcst.Group_title[Group Title], mspd.stud_Category[Category],case when mspd.stud_Gender = '0' then 'Female' when mspd.stud_Gender = '1' then 'Male' else 'Other' end as Gender,Replace(convert(varchar(11), mfe.Pay_date, 106), ' ', '-') as [Pay Date],mfe.Receipt_no,mfe.Struct_name[Struct Name],mfe.Amount,mfe.Recpt_mode[Pay Mode],mfe.Recpt_Chq_No,mfe.Recpt_Chq_dt AS Cheque_dt,mfe.Recpt_Bnk_Name AS Bank_details,mfe.Chq_status,SUBSTRING(ma.Duration, 9, 4) + '-' + SUBSTRING(ma.Duration, 21, 4) AS Duration, mfm.Amount[StructAmount] from m_FeeMaster_Category mfm, m_FeeEntry mfe, m_std_personaldetails_tbl mspd,m_crs_subjectgroup_tbl mcst, m_std_studentacademic_tbl msst,m_academic ma, m_crs_course_tbl mcct,m_crs_subcourse_tbl mcsc where mfm.Category = mspd.stud_Category and mfm.Ayid = msst.ayid and mfm.Struct_id = mfe.Struct_id and mfm.Gender =case when mspd.stud_Gender = '0' then 'Female' when mspd.stud_Gender = '1' then 'Male'  end and mfm.Group_id = mcst.Group_id and mspd.stud_id = mfe.Stud_id and mcst.Group_id = msst.group_id and msst.stud_id = mfe.Stud_id and mcct.course_id = mcsc.course_id and mcst.Subcourse_id = mcsc.subcourse_id and ma.AYID = msst.ayid and mfe.del_flag = 0 and mspd.del_flag = 0 and mcst.del_flag = 0 and msst.del_flag = 0 and mcct.del_flag = 0 and mfm.del_flag = 0 and mfe.Fine_flag = 0 and mcst.Subcourse_id = '" + ddlsubcou.SelectedValue + "' and mcct.course_id = '" + ddlcourse.SelectedValue + "' and mspd.stud_Category = '"+ OtherCategory + "')as tbl";

                    }
                }
                else
                {
                    if (OtherCategory == "OPEN")
                    {
                        //qry = "select mfe.Install_id[Install ID],mfe.Stud_id[Student Id],(mspd.stud_F_Name + ' ' + mspd.stud_M_Name + ' ' + mspd.stud_L_Name)[Name],mcst.Group_title[Group Title],mspd.stud_Category[Category],case when mspd.stud_Gender = '0' then 'Female' when mspd.stud_Gender = '1' then 'Male' else 'Other' end as Gender,mfe.Amount,mfe.Recpt_mode[Payment Mode],SUBSTRING(ma.Duration, 9, 4) + '-' + SUBSTRING(ma.Duration, 21, 4) AS duration from m_FeeEntry mfe, m_std_personaldetails_tbl mspd, m_crs_subjectgroup_tbl mcst, m_std_studentacademic_tbl msst, m_academic ma, m_crs_course_tbl mcct, m_crs_subcourse_tbl mcsc where mspd.stud_id = mfe.Stud_id and mcst.Group_id = msst.group_id and msst.stud_id = mfe.Stud_id and mcct.course_id = mcsc.course_id and mcst.Subcourse_id = mcsc.subcourse_id and ma.AYID = msst.ayid and mfe.del_flag = 0 and mspd.del_flag = 0 and mcst.del_flag = 0 and msst.del_flag = 0 and mcct.del_flag = 0 and mfe.Fine_flag != 1 and mcst.Subcourse_id = '" + ddlsubcou.SelectedValue+"' and mcct.course_id = '"+ddlcourse.SelectedValue+"' and mspd.stud_Category = '" + ddlcat.SelectedValue + "'";

                        qry = "select string_agg([Install No],' | ') [Install No],[Student Id],[Name],[Group Title],[Category],[Gender],SUM([Amount]) [Amount],duration, [Total Fees] from (select (SELECT  string_agg(mfi.Install_no,'|') FROM m_FeeInstallment mfi WHERE mfi.Install_id = mfe.Install_id and mfi.Stud_id=mfe.Stud_id and ayid=msst.ayid and del_flag=0) AS [Install No],mfe.Stud_id[Student Id],(mspd.stud_F_Name + ' ' + mspd.stud_M_Name + ' ' + mspd.stud_L_Name)[Name],mcst.Group_title[Group Title],mspd.stud_Category[Category],case when mspd.stud_Gender = '0' then 'Female' when mspd.stud_Gender = '1' then 'Male' else 'Other' end as Gender,SUM(mfe.Amount)[Amount],SUBSTRING(ma.Duration, 9, 4) + '-' + SUBSTRING(ma.Duration, 21, 4) AS duration,(select SUM(Amount) from m_FeeMaster fem where fem.Ayid=msst.ayid and fem.Group_id=msst.group_id and fem.Gender='NON' and fem.Category=mspd.stud_Category and fem.del_flag=0) [Total Fees] from m_FeeEntry mfe, m_std_personaldetails_tbl mspd, m_crs_subjectgroup_tbl mcst, m_std_studentacademic_tbl msst, m_academic ma, m_crs_course_tbl mcct, m_crs_subcourse_tbl mcsc where mspd.stud_id = mfe.Stud_id and mcst.Group_id = msst.group_id and msst.stud_id = mfe.Stud_id and mcct.course_id = mcsc.course_id and mcst.Subcourse_id = mcsc.subcourse_id and ma.AYID = msst.ayid and mfe.del_flag = 0 and mspd.del_flag = 0 and mcst.del_flag = 0 and msst.del_flag = 0 and mcct.del_flag = 0 and mfe.Fine_flag != 1 and mcst.Subcourse_id = '" + ddlsubcou.SelectedValue + "' and mcct.course_id = '" + ddlcourse.SelectedValue + "' and mspd.stud_Category = 'OPEN' group by mfe.Stud_id, mspd.stud_F_Name, mspd.stud_M_Name, mspd.stud_L_Name, mcst.Group_title, mspd.stud_Category, mspd.stud_Gender,ma.Duration,mfe.Install_id,msst.ayid,msst.group_id)tbl group by [Student Id],[Name],[Group Title],[Category],[Gender],duration,[Total Fees]";

                    }
                    else if (OtherCategory != "OPEN")
                    {
                        //qry = "select mfe.Install_id[Install ID],mfe.Stud_id[Student Id],(mspd.stud_F_Name + ' ' + mspd.stud_M_Name + ' ' + mspd.stud_L_Name)[Name],mcst.Group_title[Group Title],mspd.stud_Category[Category],case when mspd.stud_Gender = '0' then 'Female' when mspd.stud_Gender = '1' then 'Male' else 'Other' end as Gender,mfe.Amount,mfe.Recpt_mode[Payment Mode],SUBSTRING(ma.Duration, 9, 4) + '-' + SUBSTRING(ma.Duration, 21, 4) AS duration from m_FeeEntry mfe, m_std_personaldetails_tbl mspd, m_crs_subjectgroup_tbl mcst, m_std_studentacademic_tbl msst, m_academic ma, m_crs_course_tbl mcct, m_crs_subcourse_tbl mcsc where mspd.stud_id = mfe.Stud_id and mcst.Group_id = msst.group_id and msst.stud_id = mfe.Stud_id and mcct.course_id = mcsc.course_id and mcst.Subcourse_id = mcsc.subcourse_id and ma.AYID = msst.ayid and mfe.del_flag = 0 and mspd.del_flag = 0 and mcst.del_flag = 0 and msst.del_flag = 0 and mcct.del_flag = 0 and mfe.Fine_flag != 1 and mcst.Subcourse_id = '" + ddlsubcou.SelectedValue + "' and mcct.course_id = '" + ddlcourse.SelectedValue + "' and mspd.stud_Category = '" + ddlcat.SelectedValue + "'";

                        qry = "select string_agg([Install No],' | ') [Install No],[Student Id],[Name],[Group Title],[Category],[Gender],Duration,SUM([Amount]) [Amount], [Total Fees] from (select (SELECT  string_agg(mfi.Install_no,'|') FROM m_FeeInstallment mfi WHERE mfi.Install_id = mfe.Install_id and mfi.Stud_id=mfe.Stud_id and ayid=msst.ayid and del_flag=0) AS [Install No],mfe.Stud_id[Student Id],(mspd.stud_F_Name + ' ' + mspd.stud_M_Name + ' ' + mspd.stud_L_Name)[Name],mcst.Group_title[Group Title],mspd.stud_Category[Category],case when mspd.stud_Gender = '0' then 'Female' when mspd.stud_Gender = '1' then 'Male' else 'Other' end as Gender,SUM(mfe.Amount)[Amount],SUBSTRING(ma.Duration, 9, 4) + '-' + SUBSTRING(ma.Duration, 21, 4) AS Duration,(select SUM(Amount) from m_FeeMaster_Category fem where fem.Ayid=msst.ayid and fem.Group_id=msst.group_id and fem.Gender=case when mspd.stud_Gender = '0' then 'FEMALE' when mspd.stud_Gender = '1' then 'Male' end  and fem.Category=mspd.stud_Category and fem.del_flag=0) [Total Fees] from m_FeeEntry mfe, m_std_personaldetails_tbl mspd, m_crs_subjectgroup_tbl mcst, m_std_studentacademic_tbl msst, m_academic ma, m_crs_course_tbl mcct, m_crs_subcourse_tbl mcsc where mspd.stud_id = mfe.Stud_id and mcst.Group_id = msst.group_id and msst.stud_id = mfe.Stud_id and mcct.course_id = mcsc.course_id and mcst.Subcourse_id = mcsc.subcourse_id and ma.AYID = msst.ayid and mfe.del_flag = 0 and mspd.del_flag = 0 and mcst.del_flag = 0 and msst.del_flag = 0 and mcct.del_flag = 0 and mfe.Fine_flag != 1 and mcst.Subcourse_id = '" + ddlsubcou.SelectedValue + "' and mcct.course_id = '" + ddlcourse.SelectedValue + "' and mspd.stud_Category = '"+ OtherCategory + "' group by mspd.stud_F_Name, mspd.stud_M_Name, mspd.stud_L_Name, mcst.Group_title,mfe.Stud_id, mspd.stud_Category,mspd.stud_Gender,ma.Duration,mfe.Install_id,msst.ayid,msst.group_id)tbl group by [Student Id],[Name],[Group Title],[Category],[Gender],duration,[Total Fees]";
                    }
                }

                DataTable dt = cls.fillDataTable(qry);
                if (dt.Rows.Count > 0)
                {
                    btnexcel.Visible = true;
                    grd.DataSource = dt;
                    grd.DataBind();
                }
                else
                {
                    ddlcourse.SelectedIndex = 0;
                    ddlsubcou.SelectedIndex = 0;
                    ddlcat.SelectedIndex = 0;
                    btnexcel.Visible = false;
                    ddlcat.Enabled = true;
                    grd.DataSource = null;
                    grd.DataBind();
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('No payment are specified','danger')", true);

                }
            }
        }
        catch (Exception h)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "func", "notify('" + h.Message + "','danger')", true);

        }
    }


    //protected void grd_DataBound(object sender, EventArgs e)
    //{
    //    int[] mergeCols = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14,15 };
    //    MergeRows(grd, mergeCols, 7);
    //}

    //private void MergeRows(GridView gridView, int[] cols, int keyColIndex)
    //{
    //    for (int rowIndex = gridView.Rows.Count - 2; rowIndex >= 0; rowIndex--)
    //    {
    //        GridViewRow row = gridView.Rows[rowIndex];
    //        GridViewRow nextRow = gridView.Rows[rowIndex + 1];

    //        if (row.Cells[keyColIndex].Text == nextRow.Cells[keyColIndex].Text)
    //        {
    //            foreach (int colIndex in cols)
    //            {
    //                if (row.Cells[colIndex].Text == nextRow.Cells[colIndex].Text)
    //                {
    //                    if (nextRow.Cells[colIndex].RowSpan < 2)
    //                    {
    //                        row.Cells[colIndex].RowSpan = 2;
    //                    }
    //                    else
    //                    {
    //                        row.Cells[colIndex].RowSpan = nextRow.Cells[colIndex].RowSpan + 1;
    //                    }
    //                    nextRow.Cells[colIndex].Visible = false;
    //                }
    //            }
    //        }
    //    }
    //}




    protected void btnclear_Click(object sender, EventArgs e)
    {
        try
        {
            ddlcourse.ClearSelection();
            ddlsubcou.ClearSelection();
            ddlcat.Items.Clear();
            ddlsubcou.Items.Clear();
            grd.DataSource = null;
            grd.DataBind();
            btnexcel.Visible = false;
            ddlcat.ClearSelection();
            ddlcat.Enabled = true;
            rdb_detl.Checked = false;
            rdb_sumar.Checked = false;

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
        //if (ddlcat.SelectedItem.ToString() == "OPEN")
        //{
        //    ddlcategory.Value = "OPEN";
        //}
        //else
        //{
        //    ddlcategory.Value = "OBC";
        //}
    }
}