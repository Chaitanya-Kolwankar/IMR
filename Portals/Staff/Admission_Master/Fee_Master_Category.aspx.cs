using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Portals_Staff_Admission_Master_Fee_Master_Category : System.Web.UI.Page
{
    Class1 cls = new Class1();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            dataonpageload();
        }
    }

    public void dataonpageload()
    {
        cls.SetdropdownForMember1(ddl_faculty, "m_crs_faculty", "faculty_name", "faculty_Id", "faculty_name <> ''   and del_flag=0");
    }

    protected void ddl_faculty_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_course.Items.Count > 0)
        {
            ddl_course.Items.Clear();
        }
        if (ddl_subcourse.Items.Count > 0)
        {
            ddl_subcourse.Items.Clear();
        }
        if (ddl_group.Items.Count > 0)
        {
            ddl_group.Items.Clear();
        }
        if (ddl_gender.Items.Count > 0)
        {
            ddl_gender.Items.Clear();
        }
        if (ddl_category.Items.Count > 0)
        {
            ddl_category.Items.Clear();
        }
        if (ddl_struct_type.Items.Count > 0)
        {
            ddl_struct_type.Items.Clear();
        }
        clear_grd();
        clear_grd_sub();

        cls.SetdropdownForMember1(ddl_course, "m_crs_course_tbl", "Course_name", "course_id", "Course_name <> '' And faculty_id='" + ddl_faculty.SelectedValue + "' and del_flag=0");
    }

    protected void ddl_course_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_subcourse.Items.Count > 0)
        {
            ddl_subcourse.Items.Clear();
        }
        if (ddl_group.Items.Count > 0)
        {
            ddl_group.Items.Clear();
        }
        if (ddl_gender.Items.Count > 0)
        {
            ddl_gender.Items.Clear();
        }
        if (ddl_category.Items.Count > 0)
        {
            ddl_category.Items.Clear();
        }
        if (ddl_struct_type.Items.Count > 0)
        {
            ddl_struct_type.Items.Clear();
        }
        clear_grd();
        clear_grd_sub();
        if (ddl_course.SelectedValue != "0")
        {
            cls.SetdropdownForMember1(ddl_subcourse, "m_crs_subcourse_tbl", "subcourse_name", "subcourse_id", "subcourse_name <> '' And course_id='" + ddl_course.SelectedValue + "' and del_flag=0");
            fill_subgrd();
        }
    }

    protected void ddl_subcourse_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_group.Items.Count > 0)
        {
            ddl_group.Items.Clear();
        }
        if (ddl_gender.Items.Count > 0)
        {
            ddl_gender.Items.Clear();
        }
        if (ddl_category.Items.Count > 0)
        {
            ddl_category.Items.Clear();
        }
        if (ddl_struct_type.Items.Count > 0)
        {
            ddl_struct_type.Items.Clear();
        }
        clear_grd();
        clear_grd_sub();
        if (ddl_subcourse.SelectedValue != "0")
        {
            cls.SetdropdownForMember1(ddl_group, "m_crs_subjectgroup_tbl", "Group_title", "Group_id", "subcourse_id='" + ddl_subcourse.SelectedValue + "'  and del_flag=0 ");
            fill_subgrd();
        }
    }

    protected void ddl_group_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_gender.Items.Count > 0)
        {
            ddl_gender.Items.Clear();
        }
        if (ddl_category.Items.Count > 0)
        {
            ddl_category.Items.Clear();
        }
        if (ddl_struct_type.Items.Count > 0)
        {
            ddl_struct_type.Items.Clear();
        }
        clear_grd();
        clear_grd_sub();
        if (ddl_struct_type.SelectedValue != "0")
        {
            ddl_gender.Items.Clear();
            ddl_gender.Items.Add(new ListItem("MALE", "MALE"));
            ddl_gender.Items.Add(new ListItem("FEMALE", "FEMALE"));
            ddl_gender.Items.Insert(0, new ListItem("--SELECT--", "0"));
            fill_subgrd();
        }
    }

    protected void ddl_gender_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_category.Items.Count > 0)
        {
            ddl_category.Items.Clear();
        }
        if (ddl_struct_type.Items.Count > 0)
        {
            ddl_struct_type.Items.Clear();
        }
        clear_grd();
        clear_grd_sub();
        if (ddl_gender.SelectedValue != "0")
        {
            cls.SetdropdownForMember1(ddl_category, "State_category_details", "distinct parent", "parent", "Main='Reserved Category' and Parent !='OPEN' and  del_flag=0");
            fill_subgrd();
        }
    }

    protected void ddl_category_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_struct_type.Items.Count > 0)
        {
            ddl_struct_type.Items.Clear();
        }
        clear_grd();
        clear_grd_sub();
        if (ddl_category.SelectedValue != "0")
        {
            cls.SetdropdownForMember1(ddl_struct_type, "m_struct_type", "Struct_type_name", "Struct_type_name", "del_flag=0 ");
            fill_subgrd();
        }

    }

    protected void ddl_struct_type_SelectedIndexChanged(object sender, EventArgs e)
    {
        clear_grd();
        clear_grd_sub();
        if (ddl_struct_type.SelectedValue != "0")
        {
            fill_grd();
            fill_subgrd();
        }
    }

    public void fill_grd()
    {
        string qry = "select  Struct_id,Struct_name,Amount,Rank,'' updt_flag from m_FeeMaster_category where group_id = '" + ddl_group.SelectedValue + "' and AYID = '" + Session["Year"].ToString() + "' and Struct_type='" + ddl_struct_type.SelectedValue + "' and category='" + ddl_category.SelectedValue + "' and gender='" + ddl_gender.SelectedValue + "' and del_flag=0 order by group_id";
        DataTable dt = cls.fillDataTable(qry);
        if (dt.Rows.Count > 0)
        {
            grd_fee.DataSource = dt;
            grd_fee.DataBind();
            ViewState["MainTable"] = dt;
            ViewState["CurrentTable"] = dt;
            for (int i = 0; i < grd_fee.Rows.Count; i++)
            {
                TextBox txt_struct = (TextBox)grd_fee.Rows[i].FindControl("txt_struct");
                TextBox txt_amount = (TextBox)grd_fee.Rows[i].FindControl("txt_amount");
                TextBox txt_rank = (TextBox)grd_fee.Rows[i].FindControl("txt_rank");
                LinkButton btn_remove = (LinkButton)grd_fee.Rows[i].FindControl("btn_remove");
                txt_struct.Enabled = false;
                txt_amount.Enabled = false;
                txt_rank.Enabled = false;
                btn_remove.Enabled = false;
                if (btn_remove.Enabled == false)
                {
                    btn_remove.CssClass = "btn btn-outline-secondary bg-secondary-light form-control";
                }
            }
        }
        else
        {
            ViewState["MainTable"] = null;
            DataTable dt1 = new DataTable();
            DataRow dr = null;
            dt1.Columns.Add(new DataColumn("Struct_id", typeof(string)));
            dt1.Columns.Add(new DataColumn("Struct_name", typeof(string)));
            dt1.Columns.Add(new DataColumn("Amount", typeof(string)));
            dt1.Columns.Add(new DataColumn("Rank", typeof(string)));
            dt1.Columns.Add(new DataColumn("updt_flag", typeof(string)));
            dr = dt1.NewRow();
            dr["Struct_id"] = string.Empty;
            dr["Struct_name"] = string.Empty;
            dr["Amount"] = string.Empty;
            dr["Rank"] = string.Empty;
            dr["updt_flag"] = string.Empty;
            dt1.Rows.Add(dr);
            //Store the DataTable in ViewState
            ViewState["CurrentTable"] = dt1;
            grd_fee.DataSource = dt1;
            grd_fee.DataBind();
        }
    }

    protected void btn_add_Click(object sender, EventArgs e)
    {
        int rowIndex = 0;
        DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
        if (ViewState["CurrentTable"] != null)
        {
            DataRow drCurrentRow = null;
            if (dtCurrentTable.Rows.Count > 0)
            {
                for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                {
                    //extract the TextBox values
                    Label updt = (Label)grd_fee.Rows[rowIndex].FindControl("updt_flag");
                    Label box = (Label)grd_fee.Rows[rowIndex].FindControl("struct_id");
                    TextBox box1 = (TextBox)grd_fee.Rows[rowIndex].FindControl("txt_struct");
                    TextBox box2 = (TextBox)grd_fee.Rows[rowIndex].FindControl("txt_amount");
                    TextBox box3 = (TextBox)grd_fee.Rows[rowIndex].FindControl("txt_rank");
                    drCurrentRow = dtCurrentTable.NewRow();
                    dtCurrentTable.Rows[i - 1]["Struct_id"] = box.Text;
                    dtCurrentTable.Rows[i - 1]["Struct_name"] = box1.Text;
                    dtCurrentTable.Rows[i - 1]["Amount"] = box2.Text;
                    dtCurrentTable.Rows[i - 1]["Rank"] = box3.Text;
                    dtCurrentTable.Rows[i - 1]["updt_flag"] = updt.Text;
                    rowIndex++;
                }
                dtCurrentTable.Rows.Add(drCurrentRow);
                ViewState["CurrentTable"] = dtCurrentTable;
                grd_fee.DataSource = dtCurrentTable;
                grd_fee.DataBind();
            }
        }
        SetPreviousData();
    }

    private void SetPreviousData()
    {
        try
        {
            int rowIndex = 0;
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Label box = (Label)grd_fee.Rows[rowIndex].FindControl("struct_id");
                        Label updt = (Label)grd_fee.Rows[rowIndex].FindControl("updt_flag");
                        TextBox box1 = (TextBox)grd_fee.Rows[rowIndex].FindControl("txt_struct");
                        TextBox box2 = (TextBox)grd_fee.Rows[rowIndex].FindControl("txt_amount");
                        TextBox box3 = (TextBox)grd_fee.Rows[rowIndex].FindControl("txt_rank");
                        box.Text = dt.Rows[i]["Struct_id"].ToString();
                        box1.Text = dt.Rows[i]["Struct_name"].ToString();
                        box2.Text = dt.Rows[i]["Amount"].ToString();
                        box3.Text = dt.Rows[i]["Rank"].ToString();
                        updt.Text = dt.Rows[i]["updt_flag"].ToString();
                        rowIndex++;
                    }
                }
                ViewState["CurrentTable"] = dt;

                if (ViewState["MainTable"] != null)
                {
                    DataTable dtchk = (DataTable)ViewState["MainTable"];
                    if (dtchk.Rows.Count > 0)
                    {
                        for (int j = 0; j < dtchk.Rows.Count; j++)
                        {
                            Label updt = (Label)grd_fee.Rows[j].FindControl("updt_flag");
                            TextBox box1 = (TextBox)grd_fee.Rows[j].FindControl("txt_struct");
                            TextBox box2 = (TextBox)grd_fee.Rows[j].FindControl("txt_amount");
                            TextBox box3 = (TextBox)grd_fee.Rows[j].FindControl("txt_rank");
                            LinkButton btn_remove = (LinkButton)grd_fee.Rows[j].FindControl("btn_remove");
                            if (updt.Text != "TRUE")
                            {
                                box1.Enabled = false;
                                box2.Enabled = false;
                                box3.Enabled = false;
                            }
                            btn_remove.Enabled = false;
                            if (btn_remove.Enabled == false)
                            {
                                btn_remove.CssClass = "btn btn-outline-secondary bg-secondary-light form-control";
                            }
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('" + ex.Message + "', { color: '#691710', background: '#f27d72', blur: 0.2, delay: 0 });", true);
        }
    }

    protected void btn_remove_Click(object sender, EventArgs e)
    {
        GridViewRow gvRow = (GridViewRow)(sender as Control).Parent.Parent;
        int rowID = gvRow.RowIndex;
        Label per_id = (Label)grd_fee.Rows[rowID].FindControl("struct_id");
        if (!per_id.Text.Contains("STR"))
        {
            DataTable dt = (DataTable)ViewState["CurrentTable"];
            if (dt.Rows.Count > 1)
            {
                dt.Rows.Remove(dt.Rows[rowID]);
                grd_fee.DataSource = dt;
                grd_fee.DataBind();
            }
            ViewState["CurrentTable"] = dt;
            SetPreviousData();
        }
    }

    protected void btn_save_Click(object sender, EventArgs e)
    {
        string qry = "";
        int qrytimes = 0;
        bool validate = true;
        if (ddl_faculty.SelectedValue == "0")
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Select Faculty !!', { color: '#a94442', background: '#f2dede', blur: 0.2, delay: 0 });", true);
        }
        else if (ddl_course.SelectedValue == "0")
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Select Course!!', { color: '#a94442', background: '#f2dede', blur: 0.2, delay: 0 });", true);
        }
        else if (ddl_subcourse.SelectedValue == "0")
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Select Subcourse !!', { color: '#a94442', background: '#f2dede', blur: 0.2, delay: 0 });", true);
        }
        else if (ddl_group.SelectedValue == "0")
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Select Group !!', { color: '#a94442', background: '#f2dede', blur: 0.2, delay: 0 });", true);
        }
        else if (ddl_gender.SelectedValue == "0")
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Select Gender !!', { color: '#a94442', background: '#f2dede', blur: 0.2, delay: 0 });", true);
        }
        else if (ddl_category.SelectedValue == "0")
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Select Category !!', { color: '#a94442', background: '#f2dede', blur: 0.2, delay: 0 });", true);

        }
        else if (ddl_struct_type.SelectedValue == "0")
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Select Structure Type !!', { color: '#a94442', background: '#f2dede', blur: 0.2, delay: 0 });", true);
        }
        else
        {
            for (int i = 0; i < grd_fee.Rows.Count; i++)
            {
                Label struct_id = (Label)grd_fee.Rows[i].FindControl("struct_id");
                TextBox txt_struct = (TextBox)grd_fee.Rows[i].FindControl("txt_struct");
                TextBox txt_amount = (TextBox)grd_fee.Rows[i].FindControl("txt_amount");
                TextBox txt_rank = (TextBox)grd_fee.Rows[i].FindControl("txt_rank");
                if (txt_struct.Text.Trim() == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter Structure Name !!', { color: '#a94442', background: '#f2dede', blur: 0.2, delay: 0 });", true);
                    txt_struct.Focus();
                    validate = false;
                    break;
                }
                else if (txt_amount.Text.Trim() == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter Amount !!', { color: '#a94442', background: '#f2dede', blur: 0.2, delay: 0 });", true);
                    txt_amount.Focus();
                    validate = false;
                    break;
                }
                else if (txt_rank.Text == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter Rank !!', { color: '#a94442', background: '#f2dede', blur: 0.2, delay: 0 });", true);
                    txt_rank.Focus();
                    validate = false;
                    break;
                }
                else
                {
                    if (txt_struct.Enabled == true && txt_amount.Enabled == true && txt_rank.Enabled == true)
                    {
                        if (struct_id.Text == "")
                        {
                            string gen_id = get_maxid(qrytimes);
                            qry = qry + "insert into m_FeeMaster_category (AYID,group_id,Struct_id,Struct_type,Struct_name,Amount,Rank,user_id,curr_dt,category,gender) values('" + Session["Year"].ToString() + "','" + ddl_group.SelectedValue + "','" + gen_id.Trim() + "','" + ddl_struct_type.SelectedValue + "','" + txt_struct.Text.Trim() + "'," + txt_amount.Text.Trim() + "," + txt_rank.Text.Trim() + ",'" + Session["emp_id"].ToString() + "',GETDATE(),'" + ddl_category.SelectedValue + "','" + ddl_gender.SelectedValue + "');";
                            qrytimes++;
                        }
                        else if (struct_id.Text.Contains("SFC"))
                        {
                            qry = qry + "UPDATE m_FeeMaster_category SET Struct_name='" + txt_struct.Text.Trim() + "',Amount='" + txt_amount.Text.Trim() + "',Rank='" + txt_rank.Text.Trim() + "' WHERE Struct_id='" + struct_id.Text.Trim() + "' and del_flag=0;";
                        }
                    }
                }
            }
            if (validate == true)
            {
                if (qry != "")
                {
                    if (cls.TranDMLqueries(qry) == true)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Saved Sucessfully', { color: '#3c763d', background: '#dff0d8', blur: 0.2, delay: 0 });", true);
                        fill_grd();
                        fill_subgrd();
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Something Went Wrong !!', { color: '#a94442', background: '#f2dede', blur: 0.2, delay: 0 });", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('No Changes Made !!', { color: '#a94442', background: '#f2dede', blur: 0.2, delay: 0 });", true);
                }

            }
        }
    }

    protected void btn_edit_Click(object sender, EventArgs e)
    {
        GridViewRow gvRow = (GridViewRow)(sender as Control).Parent.Parent;
        int rowID = gvRow.RowIndex;
        Label struct_id = (Label)grd_fee.Rows[rowID].FindControl("struct_id");
        string qry = "select * from m_FeeEntry where Struct_id='" + struct_id.Text + "' and del_flag=0;";
        DataTable dt = cls.fillDataTable(qry);
        if (dt.Rows.Count > 0)
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Updation Prohibited as Fee Structure Already Is In Use !!', { color: '#a94442', background: '#f2dede', blur: 0.2, delay: 0 });", true);
        }
        else
        {
            Label updt = (Label)grd_fee.Rows[rowID].FindControl("updt_flag");
            TextBox txt_struct = (TextBox)grd_fee.Rows[rowID].FindControl("txt_struct");
            TextBox txt_amount = (TextBox)grd_fee.Rows[rowID].FindControl("txt_amount");
            TextBox txt_rank = (TextBox)grd_fee.Rows[rowID].FindControl("txt_rank");
            updt.Text = "TRUE";
            txt_struct.Enabled = true;
            txt_amount.Enabled = true;
            txt_rank.Enabled = true;
        }
    }

    public string get_maxid(int qrytimes)
    {
        string qry = "Select dbo.Genrate_fees_perid(" + qrytimes + ",'FEEMASTERCATEGORY') as perticular_id";
        DataTable dt = cls.fillDataTable(qry);
        string perticular_id = dt.Rows[0]["perticular_id"].ToString();
        return perticular_id;
    }

    public void clear_grd()
    {
        grd_fee.DataSource = null;
        grd_fee.DataBind();
    }

    protected void btn_delete_Click(object sender, EventArgs e)
    {
        GridViewRow gvRow = (GridViewRow)(sender as Control).Parent.Parent;
        int rowID = gvRow.RowIndex;
        Label struct_id = (Label)grd_fee.Rows[rowID].FindControl("struct_id");
        if (struct_id.Text != "")
        {

            string qrychk = "select * from m_FeeEntry where Struct_id='" + struct_id.Text + "' and del_flag=0;";
            DataTable dt = cls.fillDataTable(qrychk);
            if (dt.Rows.Count > 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Deletion Prohibited  Fees Structure Is In Use   !!', { color: '#a94442', background: '#f2dede', blur: 0.2, delay: 0 });", true);
            }
            else
            {
                string confirmValue = "";
                confirmValue = Request.Form["confirm_value"];
                string[] CVA = confirmValue.Split(new Char[] { ',' });
                if (CVA[CVA.Length - 1] == "Yes")
                {
                    string qrydel = "update m_FeeMaster_category set del_flag=1 where Struct_id='" + struct_id.Text + "'";
                    bool chk = cls.DMLqueries(qrydel);
                    if (chk == true)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Deleted Sucessfully', { color: '#3c763d', background: '#dff0d8', blur: 0.2, delay: 0 });", true);
                        fill_grd();
                        fill_subgrd();
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Something Went Wrong !!', { color: '#a94442', background: '#f2dede', blur: 0.2, delay: 0 });", true);
                    }
                }
            }
        }
    }

    protected void btn_clear_Click(object sender, EventArgs e)
    {
        ddl_faculty.SelectedValue = "0";
        ddl_faculty_SelectedIndexChanged(this, EventArgs.Empty);
    }

    public void fill_subgrd()
    {
        string extra_qry = "";
        if (ddl_gender.SelectedValue != "" && ddl_gender.SelectedValue != "0")
        {
            extra_qry += "and a.gender ='" + ddl_gender.SelectedValue + "'";
        }
        if (ddl_category.SelectedValue != "" && ddl_category.SelectedValue != "0")
        {
            extra_qry += " and a.category ='" + ddl_category.SelectedValue + "'";
        }
        if (ddl_struct_type.SelectedValue != "" && ddl_category.SelectedValue != "0")
        {
            extra_qry += " and Struct_type !='" + ddl_struct_type.SelectedValue + "'";
        }
        string query = "select distinct a.group_id,b.Group_title,a.Struct_type,b.Subcourse_id,a.gender,a.category from m_FeeMaster_category a,m_crs_subjectgroup_tbl b where a.AYID='" + Session["Year"].ToString() + "' and b.Group_id=a.group_id " + extra_qry + " and b.del_flag=0 and a.del_flag=0 order by a.group_id,a.Struct_type";
        DataTable dt = cls.fillDataTable(query);
        if (query != "")
        {
            grd_subdata.DataSource = dt;
            grd_subdata.DataBind();
        }
    }

    public void clear_grd_sub()
    {
        grd_subdata.DataSource = null;
        grd_subdata.DataBind();
    }

    protected void sub_btn_edit_Click(object sender, EventArgs e)
    {
        GridViewRow gvRow = (GridViewRow)(sender as Control).Parent.Parent;
        int rowID = gvRow.RowIndex;
        Label grp_id = (Label)grd_subdata.Rows[rowID].FindControl("sub_grp_id");
        Label Struct_type = (Label)grd_subdata.Rows[rowID].FindControl("sub_struct_type");
        Label Subcourse_id = (Label)grd_subdata.Rows[rowID].FindControl("sub_Subcourse_id");
        Label gender = (Label)grd_subdata.Rows[rowID].FindControl("sub_gender");
        Label category = (Label)grd_subdata.Rows[rowID].FindControl("sub_category");
        string query = "select * from m_FeeEntry where Struct_id in (select Struct_id from m_FeeMaster_category where Group_id ='" + grp_id.Text.Trim() + "' and AYID='" + Session["Year"].ToString() + "' and category='" + ddl_category.SelectedValue + "' and gender='" + ddl_gender.SelectedValue + "' and del_flag=0)";
        DataTable dt = cls.fillDataTable(query);
        if (dt.Rows.Count > 0)
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Updation Prohibited As Fee Structure Already Is In Use !!', { color: '#a94442', background: '#f2dede', blur: 0.2, delay: 0 });", true);
        }
        else
        {
            ddl_subcourse.SelectedValue = Subcourse_id.Text.Trim();
            ddl_subcourse_SelectedIndexChanged(sender, e);
            ddl_group.SelectedValue = grp_id.Text.Trim();
            ddl_group_SelectedIndexChanged(sender, e);
            ddl_gender.SelectedValue = gender.Text.Trim();
            ddl_gender_SelectedIndexChanged(sender, e);
            ddl_category.SelectedValue = category.Text.Trim();
            ddl_category_SelectedIndexChanged(sender, e);
            ddl_struct_type.SelectedValue = Struct_type.Text.Trim();
            ddl_struct_type_SelectedIndexChanged(sender, e);
        }
    }

    protected void sub_btn_delete_Click(object sender, EventArgs e)
    {
        GridViewRow gvRow = (GridViewRow)(sender as Control).Parent.Parent;
        int rowID = gvRow.RowIndex;
        Label grp_id = (Label)grd_subdata.Rows[rowID].FindControl("sub_grp_id");
        Label Struct_type = (Label)grd_subdata.Rows[rowID].FindControl("sub_struct_type");
        //Label Subcourse_id = (Label)grd_subdata.Rows[rowID].FindControl("sub_Subcourse_id");
        Label gender = (Label)grd_subdata.Rows[rowID].FindControl("sub_gender");
        Label category = (Label)grd_subdata.Rows[rowID].FindControl("sub_category");
        string query = "select * from m_FeeEntry where Struct_id in (select Struct_id from m_FeeMaster_category where Group_id ='" + grp_id.Text.Trim() + "' and AYID='" + Session["Year"].ToString() + "'and category='" + ddl_category.SelectedValue + "' and gender='" + ddl_gender.SelectedValue + "' )";
        DataTable dt = cls.fillDataTable(query);
        if (dt.Rows.Count > 0)
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Deletion Prohibited  Fees Structure Is In Use   !!', { color: '#a94442', background: '#f2dede', blur: 0.2, delay: 0 });", true);
        }
        else
        {
            string confirmValue = "";
            confirmValue = Request.Form["confirm_value"];
            string[] CVA = confirmValue.Split(new Char[] { ',' });
            if (CVA[CVA.Length - 1] == "Yes")
            {
                string qrydel = "Update m_FeeMaster_category set del_flag=1 where group_id ='" + grp_id.Text.Trim() + "' and Struct_type='" + Struct_type.Text.Trim() + "'and category='" + category.Text.Trim() + "' and gender='" + gender.Text.Trim() + "' and AYID='" + Session["Year"].ToString() + "'";

                bool chk = cls.DMLqueries(qrydel);
                if (chk == true)
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Deleted Sucessfully', { color: '#3c763d', background: '#dff0d8', blur: 0.2, delay: 0 });", true);
                    fill_subgrd();
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Something Went Wrong !!', { color: '#a94442', background: '#f2dede', blur: 0.2, delay: 0 });", true);
                }
            }
        }
    }

    protected void btn_save_type_Click(object sender, EventArgs e)
    {
        if (txt_type_nm.Text.Trim() == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Enter Structure Type Name !!', { color: '#a94442', background: '#f2dede', blur: 0.2, delay: 0 });", true);
        }
        else
        {
            string qry = "insert into m_struct_type (Struct_type_name) values ('" + txt_type_nm.Text.Trim().ToUpper() + "')";
            string text = "Saved";
            if (btn_save_type.Text == "Update")
            {
                qry = "Update m_struct_type set Struct_type_name='" + txt_type_nm.Text.Trim().ToUpper() + "' where Struct_type_id=" + hidden_Id_type.Value.Trim() + "";
                text = "Updated";
            }
            if (cls.DMLqueries(qry))
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('" + text + " Sucessfully', { color: '#3c763d', background: '#dff0d8', blur: 0.2, delay: 0 });", true);
                fill_grd_type();
                if (ddl_struct_type.SelectedValue != "")
                {
                    cls.SetdropdownForMember1(ddl_struct_type, "m_struct_type", "Struct_type_name", "Struct_type_name", "del_flag=0 ");
                    ddl_struct_type_SelectedIndexChanged(sender, e);
                }
                txt_type_nm.Text = string.Empty;
                btn_save_type.Text = "Save";
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Something Went Wrong !!', { color: '#a94442', background: '#f2dede', blur: 0.2, delay: 0 });", true);
            }

        }
    }

    public void fill_grd_type()
    {
        string qry = "select * from m_struct_type where del_flag=0";
        DataTable dt = cls.fillDataTable(qry);
        grd_type.DataSource = dt;
        grd_type.DataBind();
    }

    protected void btn_struct_type_Click(object sender, EventArgs e)
    {
        fill_grd_type();
    }

    protected void type_delete_Click(object sender, EventArgs e)
    {
        GridViewRow gvRow = (GridViewRow)(sender as Control).Parent.Parent;
        int rowID = gvRow.RowIndex;
        Label type_name = (Label)grd_type.Rows[rowID].FindControl("type_name");
        Label Struct_type_id = (Label)grd_type.Rows[rowID].FindControl("Struct_type_id");
        string query = "select Struct_type from m_FeeMaster_category where del_flag=0 and Struct_type='" + type_name + "';";
        DataTable dt = cls.fillDataTable(query);
        if (dt.Rows.Count > 0)
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Updation Prohibited Structure Type Is In Use !!', { color: '#a94442', background: '#f2dede', blur: 0.2, delay: 0 });", true);
        }
        else
        {
            string confirmValue = Request.Form["confirm_value"];
            string[] CVA = confirmValue.Split(new Char[] { ',' });
            if (CVA[CVA.Length - 1] == "Yes")
            {
                string qrydel = "update m_struct_type set del_flag=1 where Struct_type_id=" + Struct_type_id.Text.Trim() + "";

                bool chk = cls.DMLqueries(qrydel);
                if (chk == true)
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Deleted Sucessfully', { color: '#3c763d', background: '#dff0d8', blur: 0.2, delay: 0 });", true);
                    fill_grd_type();
                    txt_type_nm.Text = "";
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Something Went Wrong !!', { color: '#a94442', background: '#f2dede', blur: 0.2, delay: 0 });", true);
                }
            }
        }
    }

    protected void tye_edit_Click(object sender, EventArgs e)
    {
        GridViewRow gvRow = (GridViewRow)(sender as Control).Parent.Parent;
        int rowID = gvRow.RowIndex;
        Label Struct_type_id = (Label)grd_type.Rows[rowID].FindControl("Struct_type_id");
        Label type_name = (Label)grd_type.Rows[rowID].FindControl("type_name");
        string query = "select Struct_type from m_FeeMaster_category where del_flag=0 and Struct_type='" + type_name + "';";
        DataTable dt = cls.fillDataTable(query);
        if (dt.Rows.Count > 0)
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "$.notify('Deletion Prohibited   Structure Type Is In Use   !!', { color: '#a94442', background: '#f2dede', blur: 0.2, delay: 0 });", true);
        }
        else
        {
            txt_type_nm.Text = type_name.Text.Trim();
            hidden_Id_type.Value = Struct_type_id.Text.Trim();
            btn_save_type.Text = "Update";
        }
    }
}