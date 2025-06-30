using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Text;
using System.Net;
/// <summary>
/// Summary description for Class1
/// </summary>
public class Class2
{
    SqlCommand cmd = new SqlCommand();
    SqlDataAdapter da;
    DataSet ds = new DataSet();
    DataTable dt = new DataTable();
    public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);

    public Class2()
    {

    }

    public void Conn()
    {
        if (con.State == ConnectionState.Open)
        {
            con.Close();
            con.Open();
        }
        else
        {
            con.Open();
        }

    }
    public DataSet checkLogin(String username, String password)
    {
        //conn.Close();
        //conn.Open();
        string str = "select password,emp_id,l.role_id,r.form_name,case when l.role_id in ('5','4') then group_ids else (SELECT STUFF((SELECT ',' + group_id from m_crs_subjectgroup_tbl FOR XML PATH('')),1,1,'')) end as group_ids,l.col1,l.col2 from dbo.web_tp_login l,dbo.web_tp_roletype r where r.role_id=l.role_id and username='" + username + "' and l.del_flag=0;";
        DataSet ds_new = fillDataset(str);

        if (ds_new.Tables[0].Rows.Count > 0)
        {
            if (ds_new.Tables[0].Rows[0]["password"].ToString() == password)
            {

                str = "";
                str = "select emp_id,NAME,FATHER,SURNAME,MOTHER,DOB,DOJ,BLOOD_GROUP,GENDER,MARITIAL_STATUS,CASTE,MOBILE1,MOBILE2,EMAIL_ADDRESS,CURRENT_ADDRESS,CURRENT_STATE,CURRENT_PIN,CURRENT_DEPARTMENT_NAME,CURRENT_DESIGNATION,CATEGORY,EMAIL_ADDRESS,[PAN.NO]AS PAN_NO,PHOTO,emp_sign ";
                str += " from EmployeePersonal where emp_id='" + ds_new.Tables[0].Rows[0][1].ToString() + "'";
                ds = fillDataset(str);
                ds.Tables[0].Columns.Add("form_id");
                ds.Tables[0].Columns.Add("form_name");
                ds.Tables[0].Columns.Add("Group_name");
                ds.Tables[0].Columns.Add("col2");
                //ds.Tables[1].Columns.Add("msg");
                if (ds_new.Tables[0].Rows[0]["role_id"].ToString() != "")
                {
                    ds.Tables[0].Rows[0]["form_id"] = ds_new.Tables[0].Rows[0]["role_id"].ToString();
                }
                if (ds_new.Tables[0].Rows[0]["group_ids"].ToString() != "")
                {
                    ds.Tables[0].Rows[0]["Group_name"] = ds_new.Tables[0].Rows[0]["group_ids"].ToString();
                }
                if (ds_new.Tables[0].Rows[0]["form_name"].ToString() != "")
                {
                    ds.Tables[0].Rows[0]["form_name"] = ds_new.Tables[0].Rows[0]["form_name"].ToString();
                }
                if (ds_new.Tables[0].Rows[0]["col2"].ToString() != "")
                {
                    ds.Tables[0].Rows[0]["col2"] = ds_new.Tables[0].Rows[0]["col2"].ToString();
                }

                ds.Tables.Add("Table1");
                ds.Tables[1].Columns.Add("msg");
                DataRow workRow = ds.Tables[1].NewRow();
                workRow["msg"] = "";
                ds.Tables[1].Rows.Add(workRow);

            }
            else
            {
                ds.Tables.Add("Table1");
                ds.Tables[1].Columns.Add("msg");
                DataRow workRow = ds.Tables[1].NewRow();
                workRow["msg"] = "Invalid Password";
                ds.Tables[1].Rows.Add(workRow);
            }
        }
        else
        {
            ds.Tables.Add("Table1");
            ds.Tables[1].Columns.Add("msg");
            DataRow workRow = ds.Tables[1].NewRow();
            workRow["msg"] = "Invalid Staff ID";
            ds.Tables[1].Rows.Add(workRow);
        }

        //JavaScriptSerializer javaser = new JavaScriptSerializer();
        //List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        //Dictionary<string, object> row;
        //foreach (DataRow dr in ds.Tables[0].Rows)
        //{
        //    row = new Dictionary<string, object>();
        //    foreach (DataColumn col in ds.Tables[0].Columns)
        //    {
        //        row.Add(col.ColumnName, dr[col]);
        //    }
        //    rows.Add(row);
        //}
        //conn.Close();
        //return javaser.Serialize(rows);
        return ds;

    }
    public void con_close()
    {
        con.Close();
    }
    public DataSet fill_dataset(string query)
    {
        cmd = new SqlCommand();
        cmd.CommandText = query;
        cmd.CommandType = CommandType.Text;
        cmd.CommandTimeout = 1000000000;
        cmd.Connection = con;
        Conn();
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();

        da.Fill(ds);

        con.Close();
        return ds;
    }
    public bool insert_data_app(string query)
    {
        cmd = new SqlCommand();
        cmd.CommandText = query;
        cmd.CommandType = CommandType.Text;
        cmd.Connection = con;
        if (con.State == ConnectionState.Open)
        {
            con.Close();
            con.Open();
        }
        else
        {
            con.Open();
        }
        if (cmd.ExecuteNonQuery() > 0)
        {
            con.Close();
            return true;

        }
        else
        {
            con.Close();
            return false;

        }



    }

    public bool DMLqueries(string query)
    {
        try
        {
            cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            cmd.CommandTimeout = 100000000;
            if (con.State == ConnectionState.Open)
            {
                con.Close();
                con.Open();
            }
            else
            {
                con.Open();
            }
            if (cmd.ExecuteNonQuery() > 0)
            {
                con.Close();
                return true;

            }
            else
            {
                con.Close();
                return false;

            }
        }
        catch (Exception ex1)
        {
            return false;
        }

    }

    public int DMLquerries_1(string qry)
    {
        cmd = new SqlCommand(qry, con);
        cmd.CommandType = CommandType.Text;
        Conn();
        int i;

        i = cmd.ExecuteNonQuery();
        return i;

    }

    public DataSet fillDataset(string query)
    {
        cmd = new SqlCommand();
        cmd.CommandText = query;
        cmd.CommandType = CommandType.Text;
        cmd.Connection = con;
        Conn();
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();

        da.Fill(ds);

        con.Close();
        return ds;
    }

    public DataTable fillDataTable(string query)
    {
        cmd = new SqlCommand();
        cmd.CommandText = query;
        cmd.CommandType = CommandType.Text;
        cmd.Connection = con;
        cmd.CommandTimeout = 1200000;
        Conn();
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();

        da.Fill(ds);

        con.Close();
        return ds.Tables[0];
    }

    public SqlDataReader RetriveQuery(String strQuery)
    {
        try
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
                con.Open();
            }
            else
            {
                con.Open();
            }
            cmd.Connection = con;
            cmd.CommandText = strQuery;
            cmd.CommandType = CommandType.Text;
            con.Close();

            con.Open();
            SqlDataReader rd;
            rd = cmd.ExecuteReader();



            return rd;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public bool DMLqueries3(string query)
    {
        try
        {
            cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            if (con.State == ConnectionState.Open)
            {
                con.Close();
                con.Open();
            }
            else
            {
                con.Open();
            }
            if (cmd.ExecuteNonQuery() > 0)
            {
                con.Close();
                return true;

            }
            else
            {
                con.Close();
                return false;

            }
        }
        catch (Exception ex1)
        {
            return false;
        }

    }

    public string getClientIp()
    {
        string ipaddress="";
        try
        {
            IPHostEntry ipEntry = Dns.GetHostEntry(GetCompCode());
            IPAddress[] addr = ipEntry.AddressList;
            ipaddress = addr[2].ToString();
            ipaddress += "," + addr[2].ToString();
        }
        catch (Exception ex2)
        {
 
        }
        return ipaddress;
    }
    

    public static string GetCompCode()  // Get Computer Name
    {
        string strHostName = "";
        try
        {
            strHostName = Dns.GetHostName();
        }
        catch (Exception ex1)
        {
 
        }
        return strHostName;
    }

    //public DataSet fill_dataset(string s1)
    //{
    //    throw new NotImplementedException();
    //}

    //public bool DMLquerries(string str)
    //{
    //    throw new NotImplementedException();
    //}

    public void chkPassword()
    {       
        try
        {
            if (Convert.ToString(HttpContext.Current.ApplicationInstance.Session["username"]) != "")
            {
                if (Convert.ToString(HttpContext.Current.ApplicationInstance.Session["password"]) != "")
                {
                    if (Convert.ToString(HttpContext.Current.ApplicationInstance.Session["username"]) == Convert.ToString(HttpContext.Current.ApplicationInstance.Session["password"]))
                    {
                        HttpContext.Current.ApplicationInstance.Session["passwordchanged"] = "false";
                        HttpContext.Current.Response.Redirect("../Profile/ChangePassword.aspx", false);
                    }
                    else
                    {
                        HttpContext.Current.ApplicationInstance.Session["passwordchanged"] = "true";
                    }
                }
                else
                {
                    HttpContext.Current.Response.Redirect("Login.aspx");
                }
            }
            else
            {
                HttpContext.Current.Response.Redirect("Login.aspx");
            }
        }
        catch (Exception ex)
        {
            HttpContext.Current.Response.Redirect("Login.aspx");
        }
    }

    public bool insertRollno(string qry)
    {
        // string Query;

        try
        {
            //if(group==true)
            //{
            //    Query = "update m_std_studentacademic_tbl set Roll_No='" + Roll_no + "',mod_dt=getdate() where Stud_id='" + stud_id + "'and subcourse_Id='" + subcourse_id + "'and group_Id='" +group_id+ "'";
            //}
            //else
            //{
            //    Query = "update m_std_studentacademic_tbl set Roll_No='" + Roll_no + "',mod_dt=getdate() where Stud_id='" + stud_id + "'and subcourse_Id='" + subcourse_id + "'";
            //}

            con.Open();
            cmd = new SqlCommand(qry, con);
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 100000;
            if (cmd.ExecuteNonQuery() > 0)
            {
                con.Close();
                return true;

            }
            else
            {
                con.Close();
                return false;

            }

        }
        catch
        {
            return false;
        }


    }

    public object selstudentcount(TextBox tb1, TextBox tb, string subcourse_id, string group_id, string ayid, Boolean group)
    {
        string Query;
        try
        {
            if (group == true)
            {
                Query = "select count(*) as stu,max(cast(roll_no as int)) as mx from m_std_studentacademic_tbl where  ayid='" + ayid + "' and group_id='" + group_id + "' and DEL_FLAG<>1";
            }
            else
            {
                Query = "select count(*) as stu,max(cast(roll_no as int)) as mx from m_std_studentacademic_tbl where ayid='" + ayid + "' and group_id is null and DEL_FLAG<>1";
            }

            con.Open();
            cmd.CommandText = Query;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            da = new SqlDataAdapter();
            ds = new DataSet();
            da.SelectCommand = cmd;
            da.Fill(ds);
            tb.Text = ds.Tables[0].Rows[0]["stu"].ToString();
            tb1.Text = ds.Tables[0].Rows[0]["mx"].ToString();
            con.Close();

        }
        catch (Exception ex)
        {

        }
        return 0;
    }

    //for hallticket
    public object SetComboBoxForMember_hall(DropDownList ddl, string TABLE_NAME, string DATA_COLUMN, string VALUE_COLUMN, string CONDITION)
    {
        string Query;

        try
        {
            if (VALUE_COLUMN.Length > 0)
            {
                VALUE_COLUMN = "," + VALUE_COLUMN;
            }
            if (string.IsNullOrEmpty(CONDITION))
            {
                Query = "SELECT " + DATA_COLUMN + VALUE_COLUMN + " FROM " + TABLE_NAME;
            }
            else
            {
                Query = "SELECT " + DATA_COLUMN + VALUE_COLUMN + " FROM " + TABLE_NAME + " where " + CONDITION;
            }

            con.Open();
            cmd.CommandText = Query;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            da = new SqlDataAdapter();
            ds = new DataSet();
            da.SelectCommand = cmd;
            da.Fill(ds);
            con.Close();
            DataRow drr = ds.Tables[0].NewRow();
            drr[0] = "--SELECT--";
            ds.Tables[0].Rows.InsertAt(drr, 0);
            ddl.DataSource = ds.Tables[0];

            ddl.DataTextField = ds.Tables[0].Columns[0].ColumnName;
            ddl.DataValueField = ds.Tables[0].Columns[1].ColumnName;
            ddl.DataBind();
            ddl.SelectedIndex = 0;

        }
        catch (Exception ex)
        {

        }
        return 0;

    }


    public DataTable getStudList(string subcourse_id, string group_id, string ayid, Boolean null_null, Boolean checkgroup)
    {
        string strselect = "";
        try
        {

            if (null_null == false)
            {
                if (checkgroup == false)
                {
                    strselect = "select acd.stud_id,case when (spd.stud_l_name is null or spd.stud_l_name='') then  spd.stud_f_name+' '+spd.stud_m_name else spd.stud_f_name+' '+spd.stud_m_name+' '+spd.stud_l_name end  as Student_Name,acd.division,acd.lib_card_no,acd.Roll_no,case  when spd.stud_gender=0 then 'Female' else 'Male' end as gender,spd.stud_Grno from  m_std_studentacademic_tbl acd ";
                    strselect = strselect + "  ,m_std_personaldetails_tbl spd where acd.group_id is null and  acd.ayid='" + ayid + "' and ";
                    //strselect = strselect & "  ,m_std_personaldetails_tbl spd where acd.subcourse_id='" & strsubCourseId & "' and acd.group_id is null and spd.stud_gender='" & Val(strGender) & "'and  acd.ayid='" & ACDID & "' and "
                    strselect = strselect + "  acd.stud_id=SPD.stud_id ";
                    strselect = strselect + "  order by  cast(Roll_no as int),spd.stud_l_name,spd.stud_f_name,spd.stud_m_name asc ";
                    //change :29-6-15
                    //strselect = strselect & " order by case when isnumeric(substring(acd.Roll_no,0,2))<>1 then cast(substring(acd.Roll_no,3,len(acd.Roll_no)) as int)else cast(acd.Roll_no as int)end ,spd.stud_l_name,spd.stud_f_name,spd.stud_m_name asc"

                }
                else if (checkgroup == true)
                {
                    strselect = "select acd.stud_id,case when (spd.stud_l_name is null or spd.stud_l_name='') then  spd.stud_f_name+' '+spd.stud_m_name else spd.stud_f_name+' '+spd.stud_m_name+' '+spd.stud_l_name end  as Student_Name,acd.division,acd.lib_card_no,acd.Roll_no,case  when spd.stud_gender=0 then 'Female' else 'Male' end as gender,spd.stud_Grno from  m_std_studentacademic_tbl acd ";
                    strselect = strselect + "  ,m_std_personaldetails_tbl spd where acd.group_id='" + group_id + "'  and  acd.ayid='" + ayid + "' and ";
                    strselect = strselect + "  acd.stud_id=SPD.stud_id AND acd.DEL_FLAG<>1 ";
                    // strselect = strselect & "  acd.stud_id=SPD.stud_id and Division is not null and Lib_card_no is not null  and spd.stud_gender='" & Val(strGender) & "' AND acd.DEL_FLAG<>1 "
                    strselect = strselect + "  order by cast(Roll_no as int),spd.stud_l_name,spd.stud_f_name,spd.stud_m_name asc ";
                    //change :29-6-15
                    //strselect = strselect & " order by case when isnumeric(substring(acd.Roll_no,0,2))<>1 then cast(substring(acd.Roll_no,3,len(acd.Roll_no)) as int)else cast(acd.Roll_no as int)end ,spd.stud_l_name,spd.stud_f_name,spd.stud_m_name asc"

                }
            }
            else if (null_null == true)
            {
                if (checkgroup == false)
                {
                    strselect = "select acd.stud_id,case when (spd.stud_l_name is null or spd.stud_l_name='') then  spd.stud_f_name+' '+spd.stud_m_name else spd.stud_f_name+' '+spd.stud_m_name+' '+spd.stud_l_name end  as Student_Name,case  when spd.stud_gender=0 then 'Female' else 'Male' end as gender,spd.stud_Grno from  m_std_studentacademic_tbl acd ";
                    //strselect = strselect & " ,m_std_personaldetails_tbl spd where acd.subcourse_id='" & strsubCourseId & "' and acd.group_id is null and acd.stud_id=SPD.stud_id and Division is null and Lib_card_no is null  and spd.stud_gender='" & Val(strGender) & "' and  acd.ayid='" & ACDID & "' AND acd.DEL_FLAG<>1  "
                    strselect = strselect + " ,m_std_personaldetails_tbl spd where acd.subcourse_id='" + subcourse_id + "' and acd.group_id is null and acd.stud_id=SPD.stud_id and  acd.ayid='" + ayid + "' AND acd.DEL_FLAG<>1  ";
                    strselect = strselect + " order by cast(Roll_no as int),spd.stud_l_name,spd.stud_f_name,spd.stud_m_name asc ";
                    //change :29-6-15
                    //strselect = strselect & " order by case when isnumeric(substring(acd.Roll_no,0,2))<>1 then cast(substring(acd.Roll_no,3,len(acd.Roll_no)) as int)else cast(acd.Roll_no as int)end ,spd.stud_l_name,spd.stud_f_name,spd.stud_m_name asc"

                }
                else if (checkgroup == true)
                {
                    strselect = "select acd.stud_id,case when (spd.stud_l_name is null or spd.stud_l_name='') then  spd.stud_f_name+' '+spd.stud_m_name else spd.stud_f_name+' '+spd.stud_m_name+' '+spd.stud_l_name end  as Student_Name,case  when spd.stud_gender=0 then 'Female' else 'Male' end as gender,spd.stud_Grno from  m_std_studentacademic_tbl acd ";
                    strselect = strselect + " ,m_std_personaldetails_tbl spd where acd.group_id='" + group_id + "' and acd.subcourse_id='" + subcourse_id + "' and acd.stud_id=SPD.stud_id and  acd.ayid='" + ayid + "' AND acd.DEL_FLAG<>1  ";
                    //strselect = strselect & " ,m_std_personaldetails_tbl spd where acd.group_id='" & group_id & "' and acd.subcourse_id='" & strsubCourseId & "' and acd.stud_id=SPD.stud_id and Division is null and Lib_card_no is null  and spd.stud_gender='" & Val(strGender) & "' and  acd.ayid='" & ACDID & "' AND acd.DEL_FLAG<>1  "
                    strselect = strselect + " order by cast(Roll_no as int),spd.stud_l_name,spd.stud_f_name,spd.stud_m_name asc ";
                    //change :29-6-15
                    //strselect = strselect & " order by case when isnumeric(substring(acd.Roll_no,0,2))<>1 then cast(substring(acd.Roll_no,3,len(acd.Roll_no)) as int)else cast(acd.Roll_no as int)end ,spd.stud_l_name,spd.stud_f_name,spd.stud_m_name asc"

                }
            }

            con.Open();
            cmd.CommandText = strselect;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            da = new SqlDataAdapter();
            ds = new DataSet();
            dt = new DataTable();
            da.SelectCommand = cmd;
            da.Fill(dt);
            con.Close();


        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public DataTable getStudList_new(string subcourse_id, string group_id, string ayid, Boolean null_null, Boolean checkgroup)
    {
        string strselect = "";
        try
        {

            if (null_null == false)
            {
                if (checkgroup == false)
                {
                    strselect = "select acd.stud_id,spd.stud_f_name+' '+spd.stud_m_name+' '+spd.stud_l_name as Student_Name,acd.division,acd.lib_card_no,acd.Roll_no,case  when spd.stud_gender=0 then 'Female' else 'Male' end as gender,spd.stud_Grno from  m_std_studentacademic_tbl acd ";
                    strselect = strselect + "  ,m_std_personaldetails_tbl spd where acd.subcourse_id='" + subcourse_id + "'  and acd.group_id is null and  acd.ayid='" + HttpContext.Current.Session["acdyear"].ToString() + "' and ";
                    //strselect = strselect & "  ,m_std_personaldetails_tbl spd where acd.subcourse_id='" & strsubCourseId & "' and acd.group_id is null and spd.stud_gender='" & Val(strGender) & "'and  acd.ayid='" & ACDID & "' and "
                    strselect = strselect + "  acd.stud_id=SPD.stud_id ";
                    strselect = strselect + "  order by  cast(Roll_no as int),spd.stud_l_name,spd.stud_f_name,spd.stud_m_name asc ";
                    //change :29-6-15
                    //strselect = strselect & " order by case when isnumeric(substring(acd.Roll_no,0,2))<>1 then cast(substring(acd.Roll_no,3,len(acd.Roll_no)) as int)else cast(acd.Roll_no as int)end ,spd.stud_l_name,spd.stud_f_name,spd.stud_m_name asc"

                }
                else if (checkgroup == true)
                {
                    strselect = "select acd.stud_id,spd.stud_f_name+' '+spd.stud_m_name+' '+spd.stud_l_name as Student_Name,acd.division,acd.lib_card_no,acd.Roll_no,case  when spd.stud_gender=0 then 'Female' else 'Male' end as gender,spd.stud_Grno from  m_std_studentacademic_tbl acd ";
                    strselect = strselect + "  ,m_std_personaldetails_tbl spd where acd.group_id='" + group_id + "' and acd.subcourse_id='" + subcourse_id + "'  and  acd.ayid='" + HttpContext.Current.Session["acdyear"].ToString() + "' and ";
                    strselect = strselect + "  acd.stud_id=SPD.stud_id AND acd.DEL_FLAG<>1 ";
                    // strselect = strselect & "  acd.stud_id=SPD.stud_id and Division is not null and Lib_card_no is not null  and spd.stud_gender='" & Val(strGender) & "' AND acd.DEL_FLAG<>1 "
                    strselect = strselect + "  order by cast(Roll_no as int),spd.stud_l_name,spd.stud_f_name,spd.stud_m_name asc ";
                    //change :29-6-15
                    //strselect = strselect & " order by case when isnumeric(substring(acd.Roll_no,0,2))<>1 then cast(substring(acd.Roll_no,3,len(acd.Roll_no)) as int)else cast(acd.Roll_no as int)end ,spd.stud_l_name,spd.stud_f_name,spd.stud_m_name asc"

                }
            }
            else if (null_null == true)
            {
                if (checkgroup == false)
                {
                    strselect = "select acd.stud_id,spd.stud_f_name+' '+spd.stud_m_name+' '+spd.stud_l_name as Student_Name,case  when spd.stud_gender=0 then 'Female' else 'Male' end as gender,spd.stud_Grno from  m_std_studentacademic_tbl acd ";
                    //strselect = strselect & " ,m_std_personaldetails_tbl spd where acd.subcourse_id='" & strsubCourseId & "' and acd.group_id is null and acd.stud_id=SPD.stud_id and Division is null and Lib_card_no is null  and spd.stud_gender='" & Val(strGender) & "' and  acd.ayid='" & ACDID & "' AND acd.DEL_FLAG<>1  "
                    strselect = strselect + " ,m_std_personaldetails_tbl spd where acd.subcourse_id='" + subcourse_id + "'  and acd.group_id is null and acd.stud_id=SPD.stud_id and  acd.ayid='" + HttpContext.Current.Session["acdyear"].ToString() + "' AND acd.DEL_FLAG<>1  ";
                    strselect = strselect + " order by cast(Roll_no as int),spd.stud_l_name,spd.stud_f_name,spd.stud_m_name asc ";
                    //change :29-6-15
                    //strselect = strselect & " order by case when isnumeric(substring(acd.Roll_no,0,2))<>1 then cast(substring(acd.Roll_no,3,len(acd.Roll_no)) as int)else cast(acd.Roll_no as int)end ,spd.stud_l_name,spd.stud_f_name,spd.stud_m_name asc"

                }
                else if (checkgroup == true)
                {
                    strselect = "select acd.stud_id,spd.stud_f_name+' '+spd.stud_m_name+' '+spd.stud_l_name as Student_Name,case  when spd.stud_gender=0 then 'Female' else 'Male' end as gender,spd.stud_Grno from  m_std_studentacademic_tbl acd ";
                    strselect = strselect + " ,m_std_personaldetails_tbl spd where acd.group_id='" + group_id + "' and acd.subcourse_id='" + subcourse_id + "'  and acd.stud_id=SPD.stud_id and  acd.ayid='" + HttpContext.Current.Session["acdyear"].ToString() + "' AND acd.DEL_FLAG<>1  ";
                    //strselect = strselect & " ,m_std_personaldetails_tbl spd where acd.group_id='" & group_id & "' and acd.subcourse_id='" & strsubCourseId & "' and acd.stud_id=SPD.stud_id and Division is null and Lib_card_no is null  and spd.stud_gender='" & Val(strGender) & "' and  acd.ayid='" & ACDID & "' AND acd.DEL_FLAG<>1  "
                    strselect = strselect + " order by cast(Roll_no as int),spd.stud_l_name,spd.stud_f_name,spd.stud_m_name asc ";
                    //change :29-6-15
                    //strselect = strselect & " order by case when isnumeric(substring(acd.Roll_no,0,2))<>1 then cast(substring(acd.Roll_no,3,len(acd.Roll_no)) as int)else cast(acd.Roll_no as int)end ,spd.stud_l_name,spd.stud_f_name,spd.stud_m_name asc"

                }
            }

            con.Open();
            cmd.CommandText = strselect;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            da = new SqlDataAdapter();
            ds = new DataSet();
            dt = new DataTable();
            da.SelectCommand = cmd;
            da.Fill(dt);
            con.Close();


        }
        catch (Exception ex)
        {
            ex.ToString();
        }
        return dt;
    }

    public object SetComboBoxForMember(DropDownList ddl, string TABLE_NAME, string DATA_COLUMN, string VALUE_COLUMN, string CONDITION)
    {
        string Query;

        try
        {
            if (VALUE_COLUMN.Length > 0)
            {
                VALUE_COLUMN = "," + VALUE_COLUMN;
            }
            if (string.IsNullOrEmpty(CONDITION))
            {
                Query = "SELECT " + DATA_COLUMN + VALUE_COLUMN + " FROM " + TABLE_NAME;
            }
            else
            {
                Query = "SELECT " + DATA_COLUMN + VALUE_COLUMN + " FROM " + TABLE_NAME + " where " + CONDITION;
            }

            con.Open();
            cmd.CommandText = Query;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            da = new SqlDataAdapter();
            ds = new DataSet();
            da.SelectCommand = cmd;
            da.Fill(ds);
            con.Close();
            DataRow drr = ds.Tables[0].NewRow();
            drr[0] = "--SELECT--";
            ds.Tables[0].Rows.InsertAt(drr, 0);
            ddl.DataSource = ds.Tables[0];

            ddl.DataTextField = ds.Tables[0].Columns[0].ColumnName;
            ddl.DataValueField = ds.Tables[0].Columns[1].ColumnName;
            ddl.DataBind();
            ddl.SelectedIndex = 0;

        }
        catch (Exception ex)
        {

        }
        return 0;

    }

    //shweta
    public string DMLqueriesstud_id(string query)
    {
        string studuid1 = "";
        try
        {

            cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            if (con.State == ConnectionState.Open)
            {
                con.Close();
                con.Open();
            }
            else
            {
                con.Open();
            }
            if (cmd.ExecuteScalar() != "")
            {
                studuid1 = cmd.ExecuteScalar().ToString();
                con.Close();

                return studuid1;

            }
            else
            {
                con.Close();
                return studuid1;

            }
        }
        catch (Exception ex1)
        {
            return studuid1;
        }

    }


    //For Academic Year
    public string Auto_ID(string TABLE_NAME, string DATA_COLUMN, string Prefix)
    {
        //prefix should be 3 characters//
        string ID = "";
        int count = 0;
        string a;
        try
        {
            if (TABLE_NAME == "cre_exam")
            {
                ds = fillDataset("select max(convert(int,substring(exam_code,5,4))) FROM  cre_exam where exam_code like 'REXM%'");
            }
            else
            {
                ds = fillDataset("select max(convert(int,substring(" + DATA_COLUMN + ",4,6))) from " + TABLE_NAME + "");
            }

            if (ds.Tables[0].Rows[0][0].ToString() == "")
            {
                ID = Prefix + 1;
            }
            else
            {
                a = ds.Tables[0].Rows[0][0].ToString();


                int aa = int.Parse(a);

                count = aa + 1;
                ID = Prefix + count;

            }
        }
        catch (Exception ex)
        {
            //error
        }
        return ID;
    }
    public object SetdropdownForMember(DropDownList ddl, string TABLE_NAME, string DATA_COLUMN, string VALUE_COLUMN, string CONDITION)
    {
        string Query;
        try
        {

            if (VALUE_COLUMN.Length > 0)
            {
                VALUE_COLUMN = "," + VALUE_COLUMN;
            }
            if (string.IsNullOrEmpty(CONDITION))
            {
                Query = "SELECT " + DATA_COLUMN + VALUE_COLUMN + " FROM " + TABLE_NAME;
            }
            else
            {
                //=============
                Query = "SELECT " + DATA_COLUMN + VALUE_COLUMN + " FROM " + TABLE_NAME + " where " + CONDITION;
                // Query = "SELECT " + DATA_COLUMN + VALUE_COLUMN + " FROM " + TABLE_NAME + " where " + DATA_COLUMN + " not like 'M%' and " + CONDITION;
            }
            //Conn();
            //cmd = new SqlCommand(Query,con);
            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            //DataSet ds = new DataSet();
            //da.Fill(ds);
            //con_close();
            ds = fillDataset(Query);

            DataRow drr = ds.Tables[0].NewRow();
            drr[0] = "--SELECT--";
            ds.Tables[0].Rows.InsertAt(drr, 0);
            ddl.DataSource = ds.Tables[0];
            ddl.DataTextField = ds.Tables[0].Columns[0].ColumnName;
            ddl.DataValueField = ds.Tables[0].Columns[1].ColumnName;
            // ddl.Items.Clear();
            ddl.DataSource = null;
            ddl.DataBind();
            ddl.DataSource = ds.Tables[0];
            ddl.DataBind();
            // con.Close();
            //ddl.SelectedIndex = 0;

        }
        catch (Exception ex)
        {
            return null;
        }
        return 0;
    }

    //-------Subject_master
    public void validate_numbers(TextBox txt, Label remark)
    {
        string Str = txt.Text.Trim().ToString();
        double Num;
        bool isNum = double.TryParse(Str, out Num);
        if (!isNum)
        {
            remark.Visible = true;
            txt.Text = "";
        }
        else
        {
            remark.Visible = false;
        }
    }

    public bool check(Control control)
    {
        //only for combobox which name start with cmb and textbox start with txt
        string msg = control.ID.Substring(3);
        if (msg.Contains("_"))
        {
            msg.Replace("_", " ");
        }
        if (control.GetType() == typeof(DropDownList))
        {
            DropDownList cmb = (DropDownList)control;
            if (cmb.SelectedIndex == 0)
            {

                //( "Select Proper " + msg, "Error");
                return true;
            }
        }
        else if (control.GetType() == typeof(TextBox))
        {
            if (control.ID == "")
            {
                //"Enter " + msg, "Information"
                return true;
            }
        }
        return false;
    }

    public void err_cls(string ex,string emp)
    {
        string Path = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
        System.IO.FileInfo Info = new System.IO.FileInfo(Path);
        string pageName = Info.Name;
        string qry, qrychk;
        qrychk = "Select * from  error_log where exception='" + ex.Replace("'","''") + "' ";
        DataSet dschk = fill_dataset(qrychk);
        if (dschk.Tables[0].Rows.Count > 0)
        {
            qry = "update error_log set ondate=getdate(),url='" + pageName + "' where exception='" + ex.Replace("'", "''") + "' ";
        }
        else
        {
            qry = "insert into error_log values('" + ex.Replace("'", "''") + "',getdate(),'" + pageName + "','" + emp + "',null,null,null)";
        }
        DMLquerries(qry);
    }

    public bool DMLCMDquerries(SqlCommand command)
    {
        // for insert Update delete
        con.Open();
        cmd = command;
        cmd.CommandType = CommandType.Text;
        int i;
        cmd.CommandTimeout = 10800;
        cmd.Connection = con;
        i = cmd.ExecuteNonQuery();
        if (i > 0)
        {
            con.Close();
            //con.Dispose();
            return true;
        }
        else
        {
            con.Close();
            //con.Dispose();
            return false;
        }
    }
    public bool DMLquerries(string qry)
    {
        // for insert Update delete
        Conn();
        cmd = new SqlCommand(qry, con);
        cmd.CommandType = CommandType.Text;
        int i;
        cmd.CommandTimeout = 10800;
        i = cmd.ExecuteNonQuery();
        if (i > 0)
        {
            con.Close();
           // con.Dispose();
            return true;
        }
        else
        {
            con.Close();
//con.Dispose();
            return false;
        }
    }
    public DataSet get_Credit_Sub_ID(string subject_ID, string ayid)
    {
        //returns list of credit _ID
        DataSet dss = new DataSet();
        string str = "select count(*) from dbo.cre_credit_tbl where subject_id='" + subject_ID + "' and del_flag=0 and ayid='" + ayid + "' select credit_sub_id from cre_credit_tbl where subject_id='" + subject_ID + "' and ayid='" + ayid + "' and del_flag=0";
        dss = fillDataset(str);
        return dss;
    }
    public Boolean ExecuteDataBaseQuery(string strQuery)
    {
        try
        {
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = strQuery;
            cmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception ex)
        {
            ex.ToString();
            con.Close();
            return false;
        }
    }
    public DataSet fillgrid(string branch_id, string value, string ayid, string group_id, string exam_code, string subject_id)
    {
        DataSet dt = new DataSet();
        string str = "";

        str = str + " select a.stud_id as Stud_ID,isnull(Roll_no,'') as Roll_no, isnull(b.stud_L_Name,'')+'  '+isnull(b.stud_F_Name,'')+'  '+isnull(b.stud_M_Name,'') as Student_Name";
        str = str + " from dbo.m_std_studentacademic_tbl a left join dbo.m_std_personaldetails_tbl b on a.stud_id=b.stud_id ";
        str = str + " left join dbo.m_crs_subcourse_tbl c on c.subcourse_id=a.subcourse_id ";
        str = str + " left join dbo.m_crs_course_tbl d on d.course_id=c.course_id ";
        str = str + " where a.ayid='" + ayid + "' and d.course_id='" + branch_id + "' and c.semester like '%" + value + "%' and group_id='" + group_id + "' and a.stud_id";
        str = str + " NOT IN (SELECT stud_id FROM cre_marks_tbl where exam_code='" + exam_code + "'and subject_id='" + subject_id + "' and del_flag=0) and b.del_flag=0 order by Case When IsNumeric(roll_no) = 1 then ";
        str = str + " Right(Replicate('0',21) + roll_no, 20) When IsNumeric(roll_no) = 0 then Left(roll_no + Replicate('',21), 20) Else roll_no end";

        str = str + " select a.stud_id as Stud_ID,isnull(Roll_no,'') as Roll_no, isnull(b.stud_L_Name,'')+'  '+isnull(b.stud_F_Name,'')+'  '+isnull(b.stud_M_Name,'') as Student_Name";
        str = str + " from dbo.m_std_studentacademic_tbl a left join dbo.m_std_personaldetails_tbl b on a.stud_id=b.stud_id ";
        str = str + " left join dbo.m_crs_subcourse_tbl c on c.subcourse_id=a.subcourse_id ";
        str = str + " left join dbo.m_crs_course_tbl d on d.course_id=c.course_id ";
        str = str + " where a.ayid='" + ayid + "' and d.course_id='" + branch_id + "' and c.semester like '%" + value + "%' and group_id='" + group_id + "' and a.stud_id";
        str = str + " IN (SELECT stud_id FROM cre_marks_tbl where exam_code='" + exam_code + "'and subject_id='" + subject_id + "' and del_flag=0) and b.del_flag=0 order by Case When IsNumeric(roll_no) = 1 then Right(Replicate('0',21) + roll_no, 20) When IsNumeric(roll_no) = 0 then Left(roll_no + Replicate('',21), 20) Else roll_no end";
        dt = fillDataset(str);
        return dt;
    }
    public String[] get_GradeForDeg(int m_obt, int outOf, int passMrk)
    {
        //String[] arr = new String[4];
        //if (m_obt != null && outOf != null)
        //{
        //    decimal per = (decimal)(m_obt * 100) / outOf;
        //    decimal percent = Math.Round(per, 2);//Pratima---For %
        //    if (percent < 50)
        //    {
        //        arr[0] = "F";
        //        arr[1] = "0";
        //        arr[2] = "Fail";
        //        arr[3] = Convert.ToString(percent);
        //    }
        //    else if (percent >= 50 && percent < 55)
        //    {
        //        arr[0] = "E";
        //        arr[1] = "5";
        //        arr[2] = "Satisfactory";
        //        arr[3] = Convert.ToString(percent);
        //    }
        //    else if (percent >= 55 && percent < 60)
        //    {
        //        arr[0] = "D";
        //        arr[1] = "6";
        //        arr[2] = "Fair";
        //        arr[3] = Convert.ToString(percent);
        //    }
        //    else if (percent >= 60 && percent < 65)
        //    {
        //        arr[0] = "C";
        //        arr[1] = "7";
        //        arr[2] = "Good";
        //        arr[3] = Convert.ToString(percent);
        //    }
        //    else if (percent >= 65 && percent < 70)
        //    {
        //        arr[0] = "B";
        //        arr[1] = "8";
        //        arr[2] = "Very Good";
        //        arr[3] = Convert.ToString(percent);
        //    }
        //    else if (percent >= 70 && percent < 75)
        //    {
        //        arr[0] = "A";
        //        arr[1] = "9";
        //        arr[2] = "Excellent";
        //        arr[3] = Convert.ToString(percent);
        //    }
        //    else
        //    {
        //        arr[0] = "O";
        //        arr[1] = "10";
        //        arr[2] = "Outstanding";
        //        arr[3] = Convert.ToString(percent);
        //    }
        //}
        //return arr;
        String[] arr = new String[4];
        if (m_obt != null && outOf != null)
        {
            decimal per = (decimal)(m_obt * 100) / outOf;
            decimal percent = Math.Round(per, 2);//Pratima---For %
            if (percent < 45)
            {
                arr[0] = "F";
                arr[1] = "0";
                arr[2] = "Fail";
                arr[3] = Convert.ToString(percent);
            }
            else if (percent >= 45 && percent < 50)
            {
                arr[0] = "P";
                arr[1] = "4";
                arr[2] = "Pass";
                arr[3] = Convert.ToString(percent);
            }
            else if (percent >= 50 && percent < 55)
            {
                arr[0] = "E";
                arr[1] = "5";
                arr[2] = "Satisfactory";
                arr[3] = Convert.ToString(percent);
            }
            else if (percent >= 55 && percent < 60)
            {
                arr[0] = "D";
                arr[1] = "6";
                arr[2] = "Fair";
                arr[3] = Convert.ToString(percent);
            }
            else if (percent >= 60 && percent < 65)
            {
                arr[0] = "C";
                arr[1] = "7";
                arr[2] = "Good";
                arr[3] = Convert.ToString(percent);
            }
            else if (percent >= 65 && percent < 70)
            {
                arr[0] = "B";
                arr[1] = "8";
                arr[2] = "Very Good";
                arr[3] = Convert.ToString(percent);
            }
            else if (percent >= 70 && percent < 75)
            {
                arr[0] = "A";
                arr[1] = "9";
                arr[2] = "Excellent";
                arr[3] = Convert.ToString(percent);
            }
            else
            {
                arr[0] = "O";
                arr[1] = "10";
                arr[2] = "Outstanding";
                arr[3] = Convert.ToString(percent);
            }
        }
        return arr;
    }

    public string Add_GraceMrks(string grace_mrk, string original_mrk)
    {
        string total = "";
        if (original_mrk == "")
        {
            original_mrk = "0";
        }

        int h1 = Convert.ToInt32(original_mrk), h1_grace = 0;

        String temp = Convert.ToString(grace_mrk);

        if ((temp.Contains("#")) || (temp.Contains("*")) || (temp.Contains(",")) || (temp.Contains("^")) || (temp.Contains("@")))//|| (temp.Contains("!")))
        {
            if ((temp.Contains(",")))
            {
                int f1 = 0, f2 = 0;
                string[] s = temp.Split(',');
                bool forGrStar = true, forRes = true, forGrHash = true, for42flag = true;

                for (int i = 0; i < s.Length; i++)
                {
                    if ((temp.Contains("#")) && forGrHash == true)
                    {
                        s[i] = s[i].Remove(s[i].Length - 1).Trim().ToString();
                        f1 = Convert.ToInt32(s[i]);
                        forGrHash = false;
                        //0, s[i].LastIndexOf('#')));
                    }
                    else if ((temp.Contains("^")) && forRes == true)
                    {
                        s[i] = s[i].Remove(s[i].Length - 1).Trim().ToString();
                        f1 = Convert.ToInt32(s[i]);
                        forRes = false;
                        //, temp.LastIndexOf('#')));
                    }
                    else if ((temp.Contains("*")) && forGrStar == true)
                    {
                        s[i] = s[i].Remove(s[i].Length - 1).Trim().ToString();
                        //if (Convert.ToInt32(s[i]) <= h1_t)
                        //{
                        f1 = Convert.ToInt32(s[i]);
                        forGrStar = false;
                        //, s[i].LastIndexOf('*')));
                        //h1_t = h1_t - Convert.ToInt32(f1);
                        //}
                        //else
                        //{
                        //   // MessageBox.Show("Can't enter marks more than " + h1_t);
                        //    return total = "";
                        //}
                    }
                    else if ((temp.Contains("@")) && for42flag == true)
                    {
                        s[i] = s[i].Remove(s[i].Length - 1).Trim().ToString();
                        f1 = Convert.ToInt32(s[i]);
                        for42flag = false;
                        //, temp.LastIndexOf('#')));
                    }
                    h1_grace = f1 + f2;
                    f1 = f2;
                    f2 = h1_grace;
                }
            }
            else
            {
                if ((temp.Contains("#")))
                {
                    temp = temp.Remove(temp.Length - 1).Trim().ToString();
                    h1_grace = Convert.ToInt32(temp);
                    //, temp.LastIndexOf('#')));
                }
                else if ((temp.Contains("^")))
                {
                    temp = temp.Remove(temp.Length - 1).Trim().ToString();
                    h1_grace = Convert.ToInt32(temp);
                    //, temp.LastIndexOf('#')));
                }
                else if ((temp.Contains("*")))
                {
                    temp = temp.Remove(temp.Length - 1).Trim().ToString();
                    h1_grace = Convert.ToInt32(temp);
                }
                else if ((temp.Contains("@")))
                {
                    temp = temp.Remove(temp.Length - 1).Trim().ToString();
                    h1_grace = Convert.ToInt32(temp);

                }

            }
        }
        else
        {
            h1_grace = 0;
        }

        total = Convert.ToString(h1 + h1_grace); //////----------------------------already


        return total;
    }
    public int addResolution(int mrkObt, int passMrk, int resol)
    {
        if (mrkObt.ToString() == "" || mrkObt.ToString() == null)
        {
            mrkObt = 0;
            Convert.ToInt32(mrkObt);
        }

        if (passMrk.ToString() == "" || passMrk.ToString() == null)
        {
            passMrk = 0;
            Convert.ToInt32(passMrk);
        }

        if (resol.ToString() == "" || resol.ToString() == null)
        {
            resol = 0;
            Convert.ToInt32(resol);
        }

        int i = passMrk - resol;
        if (mrkObt >= i && mrkObt < passMrk)
        {
            return passMrk;
        }
        else
        {
            return mrkObt;
        }
    }

    public string Total_Grade(string SGPI1, int re)
    {
        string Grade;
        if (Convert.ToDouble(SGPI1) >= 7 && re == 1)
        {
            Grade = "O";
        }
        else if (Convert.ToDouble(SGPI1) >= 6 && Convert.ToDouble(SGPI1) <= 6.99 && re == 1)
        {
            Grade = "A";
        }
        else if (Convert.ToDouble(SGPI1) >= 5 && Convert.ToDouble(SGPI1) <= 5.99 && re == 1)
        {
            Grade = "B";
        }
        else if (Convert.ToDouble(SGPI1) >= 4 && Convert.ToDouble(SGPI1) <= 4.99 && re == 1)
        {
            Grade = "C";
        }
        else if (Convert.ToDouble(SGPI1) >= 3 && Convert.ToDouble(SGPI1) <= 3.99 && re == 1)
        {
            Grade = "D";
        }
        else if (Convert.ToDouble(SGPI1) >= 2 && Convert.ToDouble(SGPI1) <= 2.99 && re == 1)
        {
            Grade = "E";
        }
        else
        {
            Grade = "F";
        }
        return Grade;
    }

   

    public int getPtsFrmGrade(String grade)
    {
        int points = 11;
        switch (grade)
        {
            case "F":
                return points = 0;

            case "P":
                return points = 4;

            case "E":
                return points = 5;

            case "D":
                return points = 6;

            case "C":
                return points = 7;

            case "B":
                return points = 8;

            case "A":
                return points = 9;

            case "O":
                return points = 10;

        }
        return points;
    }
    public bool addOverallGraceNew(DataTable dtMarks, int grcMrk, DataTable dt42, string quota, DataTable dtAb) // ================== 21Nov OLD
    {
        int ktCnt = 0;

        if (dt42.Rows.Count > 0)
        {
            ktCnt = Convert.ToInt32(dt42.Rows[0][0]);
        }

        dtMarks.Columns.Add("h1Total");
        dtMarks.Columns.Add("h2Total");
        //bool GrcFlag = true, afterGrc = false;
        string query = "", remark = "";
        int blankMrk = 0;
        int Grc1Per = grcMrk;
        int quotaGrc = 0;
        if (quota != "" && quota == "LD")
            quotaGrc = 20;
        ///////////////////////////////==============================For Adding * Grace=======================================

        if (ktCnt == 1)
        {
            bool Grace = false;
            bool quotaFlag = false;
            bool atGrace = false;

            for (int i = 0; i < dtMarks.Rows.Count; i++)
            {
                bool abFlag = false;
                string sub_ID = dtMarks.Rows[i]["subject_id"].ToString();
                //if (sub_ID == "SUB298")
                //{ 
                //}
                if (dtAb.Rows.Count > 0)
                {
                    for (int x = 0; x < dtAb.Rows.Count; x++)
                    {
                        if (sub_ID == dtAb.Rows[x]["subject_id"].ToString())
                        {
                            abFlag = true;
                            break;
                        }
                    }
                }

                bool h1Blnk = false, h2Blnk = false;
                int TotPercent = 0, h1Copy = 0, H1outOf = 0, H2outOf = 0;
                int dtGrcH1 = Convert.ToInt32(dtMarks.Rows[i]["h1_grace42"]);
                //---------------------------------------------@@@@@@@@@@    H1    @@@@@@@@@@@@--------------------------------------------------------
                if (!string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[i]["h1"]).Trim()) && !string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[i]["h1_out"])))
                {
                    if (Convert.ToString(dtMarks.Rows[i]["h1"]).Contains("+"))
                    {
                        dtMarks.Rows[i]["h1"] = Convert.ToString(dtMarks.Rows[i]["h1"]).Substring(0, Convert.ToString(dtMarks.Rows[i]["h1"]).IndexOf('+'));
                    }

                    if (Convert.ToString(dtMarks.Rows[i]["h1"]) == "Ab")
                    {
                        abFlag = true;
                        dtMarks.Rows[i]["remark"] = "UnSuccessful";
                    }
                    else
                    {
                        int h1 = Convert.ToInt32(dtMarks.Rows[i]["h1"]), h1Pass = Convert.ToInt32(dtMarks.Rows[i]["h1_pass"]), h1Res = Convert.ToInt32(dtMarks.Rows[i]["h1_resolution"]);
                        H1outOf = Convert.ToInt32(dtMarks.Rows[i]["h1_out"]);
                        if (h1 >= h1Pass)
                        {
                            h1Copy = h1;
                            dtMarks.Rows[i]["h1Total"] = Convert.ToString(h1);
                            dtMarks.Rows[i]["h1_grace"] = "";
                            dtMarks.Rows[i]["remark"] = "Successful";
                        }
                        else
                        {
                            bool res = false;
                            if (h1Res != 0)
                            {
                                h1 = addResolution(h1, h1Pass, h1Res);
                                if (h1 >= h1Pass)
                                {
                                    dtMarks.Rows[i]["h1Total"] = Convert.ToString(h1);
                                    dtMarks.Rows[i]["h1_grace"] = (h1Pass - Convert.ToInt32(dtMarks.Rows[i]["h1"])) + "^";
                                    dtMarks.Rows[i]["remark"] = "Successful";
                                    res = true;
                                }
                            }
                            if (res == false && abFlag == false)
                            {
                                //------------------------@ before *--------------------
                                int h1New;
                                if (dtGrcH1 <= grcMrk)
                                    h1New = h1 + dtGrcH1;
                                else
                                    h1New = h1;

                                if (h1New >= h1Pass && atGrace == false)
                                {
                                    atGrace = true;
                                    dtMarks.Rows[i]["h1Total"] = Convert.ToString(h1Pass);
                                    dtGrcH1 = h1Pass - (h1);
                                    grcMrk = grcMrk - dtGrcH1;
                                    dtMarks.Rows[i]["h1_grace"] = Convert.ToString(dtGrcH1) + "@";
                                    dtMarks.Rows[i]["remark"] = "Successful";
                                    Grace = true;
                                }
                                else if (Grace == false)
                                {


                                    //------------------------@ before *----------------------

                                    int cmpr = 0;
                                    decimal d1 = Convert.ToDecimal(dtMarks.Rows[i]["h1_out"]) / 10;

                                    if (Convert.ToString(d1).Contains("."))
                                    {
                                        cmpr = rndNum(d1);
                                    }
                                    else
                                    {
                                        cmpr = Convert.ToInt32(dtMarks.Rows[i]["h1_out"]) / 10;
                                    }



                                    if (Convert.ToInt32(cmpr) < Grc1Per)
                                    {
                                        //grcMrk = Convert.ToInt32(dtMarks.Rows[i]["h1_out"]) / 10;
                                        grcMrk = cmpr;
                                    }
                                    else
                                    {
                                        grcMrk = Grc1Per;
                                    }

                                    //int h1New;
                                    h1New = h1 + grcMrk;
                                    if (h1New >= h1Pass && Grace == false)
                                    {
                                        dtMarks.Rows[i]["h1Total"] = Convert.ToString(h1Pass);
                                        grcMrk = h1Pass - (h1);
                                        dtMarks.Rows[i]["h1_grace"] = Convert.ToString(grcMrk) + "*";
                                        dtMarks.Rows[i]["remark"] = "Successful";
                                        Grace = true;
                                    }
                                    else if (quotaGrc != 0 && quota == "LD" && quotaFlag == false)
                                    {
                                        h1New = h1 + quotaGrc;
                                        if (h1New >= h1Pass)
                                        {
                                            quotaFlag = true;
                                            dtMarks.Rows[i]["h1Total"] = Convert.ToString(h1Pass);
                                            quotaGrc = h1Pass - (h1);
                                            dtMarks.Rows[i]["h1_grace"] = Convert.ToString(quotaGrc) + "*";
                                            dtMarks.Rows[i]["remark"] = "Successful";
                                        }
                                        else
                                        {
                                            dtMarks.Rows[i]["h1Total"] = Convert.ToString(h1);
                                            dtMarks.Rows[i]["h1_grace"] = "";
                                            dtMarks.Rows[i]["remark"] = "UnSuccessful";
                                            quotaFlag = true;
                                        }
                                    }
                                    else
                                    {
                                        dtMarks.Rows[i]["h1Total"] = Convert.ToString(h1);
                                        dtMarks.Rows[i]["h1_grace"] = "";
                                        dtMarks.Rows[i]["remark"] = "UnSuccessful";
                                        Grace = true;
                                    }
                                }
                            }
                        }
                    }
                }
                else if (string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[i]["h1_out"])))
                {
                    h1Blnk = true;
                }

                int dtGrcH2 = Convert.ToInt32(dtMarks.Rows[i]["h2_grace42"]);
                //-------------------------------------------------------@@@@@@@@@@   H2   @@@@@@@@@@-------------------------------------------------
                if (!string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[i]["h2"]).Trim()) && !string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[i]["h2_out"])))
                {
                    bool over50Flag = false;

                    if (Convert.ToString(dtMarks.Rows[i]["h2"]).Contains("+"))
                    {
                        dtMarks.Rows[i]["h2"] = Convert.ToString(dtMarks.Rows[i]["h2"]).Substring(0, Convert.ToString(dtMarks.Rows[i]["h2"]).IndexOf('+'));
                    }

                    if (Convert.ToString(dtMarks.Rows[i]["h2"]) == "Ab")
                    {
                        dtMarks.Rows[i]["remark"] = "UnSuccessful";
                    }
                    else
                    {
                        int h2 = Convert.ToInt32(dtMarks.Rows[i]["h2"]), h2Pass = Convert.ToInt32(dtMarks.Rows[i]["h2_pass"]), h2Res = Convert.ToInt32(dtMarks.Rows[i]["h2_resolution"]);
                        H2outOf = Convert.ToInt32(dtMarks.Rows[i]["h2_out"]);

                        if (h2 >= h2Pass)
                        {
                            dtMarks.Rows[i]["h2Total"] = Convert.ToString(h2);
                            dtMarks.Rows[i]["h2_grace"] = "";

                            if (string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[i]["h1_out"])) || Convert.ToString(dtMarks.Rows[i]["remark"]) == "Successful")
                                dtMarks.Rows[i]["remark"] = "Successful";
                        }
                        else
                        {
                            bool res = false;
                            if (h2Res != 0)
                            {
                                h2 = addResolution(h2, h2Pass, h2Res);
                                if (h2 > h2Pass)
                                {
                                    res = true;
                                    dtMarks.Rows[i]["h1Total"] = Convert.ToString(h2);
                                    dtMarks.Rows[i]["h2_grace"] = (h2Pass - Convert.ToInt32(dtMarks.Rows[i]["h2"])) + "^";
                                    if (string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[i]["h1_out"])) || Convert.ToString(dtMarks.Rows[i]["remark"]) == "Successful")
                                        dtMarks.Rows[i]["remark"] = "Successful";
                                }
                            }

                            if (res == false && abFlag == false)
                            {
                                /*
                                if (H1outOf != 0)
                                {
                                    TotPercent = ((h1Copy + h2) * 100) / (H1outOf + H2outOf);
                                    if (TotPercent >= 50)
                                    {
                                        dtMarks.Rows[i]["h2Total"] = Convert.ToString(h2);
                                        dtMarks.Rows[i]["h2_grace"] = "";
                                        dtMarks.Rows[i]["remark"] = "Successful";
                                        over50Flag = true;
                                    }
                                }
                                */
                                //========================H2 @ before *===============
                                int h1New;
                                if (dtGrcH2 <= grcMrk)
                                    h1New = h2 + dtGrcH2;
                                else
                                    h1New = h2;

                                if (h1New >= h2Pass && atGrace == false && over50Flag == false)
                                {
                                    atGrace = true;
                                    dtMarks.Rows[i]["h2Total"] = Convert.ToString(h2Pass);
                                    dtGrcH2 = h2Pass - (h2);
                                    grcMrk = grcMrk - dtGrcH2;
                                    dtMarks.Rows[i]["h2_grace"] = Convert.ToString(dtGrcH2) + "@";
                                    if (string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[i]["h1_out"])) || Convert.ToString(dtMarks.Rows[i]["remark"]) == "Successful")
                                        dtMarks.Rows[i]["remark"] = "Successful";
                                    Grace = true;
                                }
                                else if (Grace == false)
                                {
                                    //========================H2 @ before *===============

                                    if (over50Flag == false && Grace == false)
                                    {
                                        if ((Convert.ToInt32(dtMarks.Rows[i]["h2_out"]) / 10) < Grc1Per)
                                        {
                                            grcMrk = Convert.ToInt32(dtMarks.Rows[i]["h2_out"]) / 10;
                                        }


                                        //int h1New;
                                        h1New = h2 + grcMrk;
                                        Grace = true;
                                        if (h1New >= h2Pass)
                                        {
                                            dtMarks.Rows[i]["h2Total"] = Convert.ToString(h2Pass);
                                            grcMrk = h2Pass - (h2);
                                            dtMarks.Rows[i]["h2_grace"] = Convert.ToString(grcMrk) + "*";
                                            if (string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[i]["h1_out"])) || Convert.ToString(dtMarks.Rows[i]["remark"]) == "Successful")
                                                dtMarks.Rows[i]["remark"] = "Successful";
                                        }
                                        else if (quotaGrc != 0 && quota == "LD" && quotaFlag == false)
                                        {
                                            h1New = h2 + quotaGrc;
                                            quotaFlag = true;
                                            if (h1New >= h2Pass)
                                            {
                                                dtMarks.Rows[i]["h2Total"] = Convert.ToString(h2Pass);
                                                quotaGrc = h2Pass - (h2);
                                                dtMarks.Rows[i]["h2_grace"] = Convert.ToString(quotaGrc) + "*";
                                                if (string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[i]["h1_out"])) || Convert.ToString(dtMarks.Rows[i]["remark"]) == "Successful")
                                                    dtMarks.Rows[i]["remark"] = "Successful";
                                            }
                                            else
                                            {
                                                dtMarks.Rows[i]["h2Total"] = Convert.ToString(h2);
                                                dtMarks.Rows[i]["h2_grace"] = "";
                                                dtMarks.Rows[i]["remark"] = "UnSuccessful";
                                            }
                                        }
                                        else
                                        {
                                            dtMarks.Rows[i]["h2Total"] = Convert.ToString(h2);
                                            dtMarks.Rows[i]["h2_grace"] = "";
                                            dtMarks.Rows[i]["remark"] = "UnSuccessful";
                                        }
                                    }
                                    else if (over50Flag == false && Grace == true)
                                    {
                                        dtMarks.Rows[i]["h2Total"] = Convert.ToString(h2);
                                        dtMarks.Rows[i]["h2_grace"] = "";
                                        dtMarks.Rows[i]["remark"] = "UnSuccessful";
                                    }
                                }
                            }

                        }
                    }

                }
                else if (string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[i]["h2_out"])))
                {
                    if (h1Blnk == true)
                    {
                        blankMrk++;
                    }
                }
                if (blankMrk == dtMarks.Rows.Count)
                {
                    return false;
                }
                query += "update cre_marks_tbl set h1_grace='" + dtMarks.Rows[i]["h1_grace"] + "',h2_grace='" + dtMarks.Rows[i]["h2_grace"] + "',mod_date=getDate(),remark='" + dtMarks.Rows[i]["remark"] + "' where stud_id='" + dtMarks.Rows[i]["stud_id"] + "' and subject_id='" + dtMarks.Rows[i]["subject_id"] + "'and credit_sub_id='" + dtMarks.Rows[i]["credit_sub_id"] + "' and exam_code='" + dtMarks.Rows[i]["exam_code"] + "' and del_flag=0 ";


            }
        }

        //
        //////////////////////////////================================For adding Dyslexia Grace===============================
        //
        if (ktCnt > 1 && quotaGrc != 0 && quota == "LD")
        {
            bool GrcFlag = true, afterGrc = false;
            bool FailGrc = false, addGrace = false;



            for (int i = 0; i < dtMarks.Rows.Count; i++)
            {
                bool abFlag = false;
                string sub_ID = dtMarks.Rows[i]["subject_id"].ToString();

                if (dtAb.Rows.Count > 0)
                {
                    for (int x = 0; x < dtAb.Rows.Count; x++)
                    {
                        if (sub_ID == dtAb.Rows[x]["subject_id"].ToString())
                        {
                            abFlag = true;
                            break;
                        }
                    }
                }

                bool h1Blnk = false, h2Blnk = false, over50Flag = false;
                int TotPercent = 0, h1Copy = 0, H1outOf = 0, H2outOf = 0;
                //----------------------------------------------------@@@@@@@@   H1   @@@@@@@@@@------------------------------------------------------------
                int dtGrcH1 = Convert.ToInt32(dtMarks.Rows[i]["h1_grace42"]);
                if (!string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[i]["h1"]).Trim()) && !string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[i]["h1_out"])))
                {
                    if (Convert.ToString(dtMarks.Rows[i]["h1"]).Contains("+"))
                    {
                        dtMarks.Rows[i]["h1"] = Convert.ToString(dtMarks.Rows[i]["h1"]).Substring(0, Convert.ToString(dtMarks.Rows[i]["h1"]).IndexOf('+'));
                    }

                    if (Convert.ToString(dtMarks.Rows[i]["h1"]) == "Ab")
                    {
                        dtMarks.Rows[i]["remark"] = "UnSuccessful";
                        FailGrc = true;
                        if (FailGrc == true && addGrace == true)
                        {
                            query = "";
                            for (int j = 0; j < i; j++)
                            {
                                if (!string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[j]["h1_grace"])) && Convert.ToString(dtMarks.Rows[j]["h1_grace"]).Contains("*"))
                                {
                                    dtMarks.Rows[j]["h1_grace"] = "";
                                    dtMarks.Rows[j]["h1Total"] = dtMarks.Rows[j]["h1"];
                                    dtMarks.Rows[j]["remark"] = "UnSuccessful";
                                }
                                if (!string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[j]["h2_grace"])) && Convert.ToString(dtMarks.Rows[j]["h2_grace"]).Contains("*"))
                                {
                                    dtMarks.Rows[j]["h2_grace"] = "";
                                    dtMarks.Rows[j]["h2Total"] = dtMarks.Rows[j]["h2"];
                                    dtMarks.Rows[j]["remark"] = "UnSuccessful";
                                }
                                query += "update cre_marks_tbl set h1_grace='" + dtMarks.Rows[j]["h1_grace"] + "',h2_grace='" + dtMarks.Rows[j]["h2_grace"] + "',mod_date=getDate(),remark='" + dtMarks.Rows[j]["remark"] + "' where stud_id='" + dtMarks.Rows[j]["stud_id"] + "' and subject_id='" + dtMarks.Rows[j]["subject_id"] + "'and credit_sub_id='" + dtMarks.Rows[j]["credit_sub_id"] + "' and exam_code='" + dtMarks.Rows[j]["exam_code"] + "' and del_flag=0 ";
                            }

                            dtMarks.Rows[i]["h1Total"] = dtMarks.Rows[i]["h1"];
                            dtMarks.Rows[i]["h1_grace"] = "";
                            dtMarks.Rows[i]["remark"] = "UnSuccessful";
                        }
                    }
                    else
                    {
                        int h1 = Convert.ToInt32(dtMarks.Rows[i]["h1"]), h1Pass = Convert.ToInt32(dtMarks.Rows[i]["h1_pass"]), h1Res = Convert.ToInt32(dtMarks.Rows[i]["h1_resolution"]);
                        H1outOf = Convert.ToInt32(dtMarks.Rows[i]["h1_out"]);
                        if (h1 >= h1Pass)
                        {
                            h1Copy = h1;
                            dtMarks.Rows[i]["h1Total"] = Convert.ToString(h1);
                            dtMarks.Rows[i]["h1_grace"] = "";
                            dtMarks.Rows[i]["remark"] = "Successful";
                        }
                        else
                        {
                            bool res = false;
                            if (h1Res != 0)
                            {
                                h1 = addResolution(h1, h1Pass, h1Res);
                                if (h1 >= h1Pass)
                                {
                                    h1Copy = h1;
                                    dtMarks.Rows[i]["h1Total"] = Convert.ToString(h1);
                                    dtMarks.Rows[i]["h1_grace"] = (h1Pass - Convert.ToInt32(dtMarks.Rows[i]["h1"])) + "^";
                                    dtMarks.Rows[i]["remark"] = "Successful";
                                    res = true;
                                }
                            }

                            if (res == false && abFlag == false)
                            {
                                if (quotaGrc > 0 && FailGrc == false)
                                {
                                    int h1New;
                                    h1New = h1 + quotaGrc;

                                    if (h1New >= h1Pass)
                                    {
                                        addGrace = true;
                                        dtMarks.Rows[i]["h1Total"] = Convert.ToString(h1Pass);
                                        dtGrcH1 = h1Pass - (h1);
                                        quotaGrc = quotaGrc - dtGrcH1;
                                        dtMarks.Rows[i]["h1_grace"] = Convert.ToString(dtGrcH1) + "*";
                                        dtMarks.Rows[i]["remark"] = "Successful";
                                    }
                                    else
                                    {
                                        FailGrc = true;
                                        dtMarks.Rows[i]["h1Total"] = Convert.ToString(h1);
                                        dtMarks.Rows[i]["h1_grace"] = "";
                                        dtMarks.Rows[i]["remark"] = "UnSuccessful";
                                    }
                                }
                                else
                                {
                                    FailGrc = true;
                                    dtMarks.Rows[i]["h1Total"] = Convert.ToString(h1);
                                    dtMarks.Rows[i]["h1_grace"] = "";
                                    dtMarks.Rows[i]["remark"] = "UnSuccessful";
                                }

                                if (FailGrc == true && addGrace == true)
                                {
                                    query = "";
                                    for (int j = 0; j < i; j++)
                                    {
                                        if (!string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[j]["h1_grace"])) && Convert.ToString(dtMarks.Rows[j]["h1_grace"]).Contains("*"))
                                        {
                                            dtMarks.Rows[j]["h1_grace"] = "";
                                            dtMarks.Rows[j]["h1Total"] = dtMarks.Rows[j]["h1"];
                                            dtMarks.Rows[j]["remark"] = "UnSuccessful";
                                        }
                                        if (!string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[j]["h2_grace"])) && Convert.ToString(dtMarks.Rows[j]["h2_grace"]).Contains("*"))
                                        {
                                            dtMarks.Rows[j]["h2_grace"] = "";
                                            dtMarks.Rows[j]["h2Total"] = dtMarks.Rows[j]["h2"];
                                            dtMarks.Rows[j]["remark"] = "UnSuccessful";
                                        }
                                        query += "update cre_marks_tbl set h1_grace='" + dtMarks.Rows[j]["h1_grace"] + "',h2_grace='" + dtMarks.Rows[j]["h2_grace"] + "',mod_date=getDate(),remark='" + dtMarks.Rows[j]["remark"] + "' where stud_id='" + dtMarks.Rows[j]["stud_id"] + "' and subject_id='" + dtMarks.Rows[j]["subject_id"] + "'and credit_sub_id='" + dtMarks.Rows[j]["credit_sub_id"] + "' and exam_code='" + dtMarks.Rows[j]["exam_code"] + "' and del_flag=0 ";
                                    }

                                    dtMarks.Rows[i]["h1Total"] = Convert.ToString(h1);
                                    dtMarks.Rows[i]["h1_grace"] = "";
                                    dtMarks.Rows[i]["remark"] = "UnSuccessful";
                                }
                            }
                        }
                    }
                }
                else if (string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[i]["h1_out"])))
                {
                    h1Blnk = true;
                }
                //----------------------------------------------------------@@@@@@@@@@    H2    @@@@@@@@@@@@-----------------------------------------------------

                int dtGrcH2 = Convert.ToInt32(dtMarks.Rows[i]["h2_grace42"]);
                if (!string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[i]["h2"]).Trim()) && !string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[i]["h2_out"])))
                {

                    if (Convert.ToString(dtMarks.Rows[i]["h2"]).Contains("+"))
                    {
                        dtMarks.Rows[i]["h2"] = Convert.ToString(dtMarks.Rows[i]["h2"]).Substring(0, Convert.ToString(dtMarks.Rows[i]["h2"]).IndexOf('+'));
                    }

                    if (Convert.ToString(dtMarks.Rows[i]["h2"]) == "Ab")
                    {
                        dtMarks.Rows[i]["remark"] = "UnSuccessful";
                        FailGrc = true;
                        if (FailGrc == true && addGrace == true)
                        {
                            query = "";
                            for (int j = 0; j < i; j++)
                            {
                                if (!string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[j]["h1_grace"])) && Convert.ToString(dtMarks.Rows[j]["h1_grace"]).Contains("*"))
                                {
                                    dtMarks.Rows[j]["h1_grace"] = "";
                                    dtMarks.Rows[j]["h1Total"] = dtMarks.Rows[j]["h1"];
                                    dtMarks.Rows[j]["remark"] = "UnSuccessful";
                                }
                                if (!string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[j]["h2_grace"])) && Convert.ToString(dtMarks.Rows[j]["h2_grace"]).Contains("*"))
                                {
                                    dtMarks.Rows[j]["h2_grace"] = "";
                                    dtMarks.Rows[j]["h2Total"] = dtMarks.Rows[j]["h2"];
                                    dtMarks.Rows[j]["remark"] = "UnSuccessful";
                                }
                                query += "update cre_marks_tbl set h1_grace='" + dtMarks.Rows[j]["h1_grace"] + "',h2_grace='" + dtMarks.Rows[j]["h2_grace"] + "',mod_date=getDate(),remark='" + dtMarks.Rows[j]["remark"] + "' where stud_id='" + dtMarks.Rows[j]["stud_id"] + "' and subject_id='" + dtMarks.Rows[j]["subject_id"] + "'and credit_sub_id='" + dtMarks.Rows[j]["credit_sub_id"] + "' and exam_code='" + dtMarks.Rows[j]["exam_code"] + "' and del_flag=0 ";
                            }
                            dtMarks.Rows[i]["h2_grace"] = "";
                            dtMarks.Rows[i]["h2Total"] = dtMarks.Rows[i]["h2"];
                            dtMarks.Rows[i]["remark"] = "UnSuccessful";
                        }
                    }
                    else
                    {
                        int h2 = Convert.ToInt32(dtMarks.Rows[i]["h2"]), h2Pass = Convert.ToInt32(dtMarks.Rows[i]["h2_pass"]), h2Res = Convert.ToInt32(dtMarks.Rows[i]["h2_resolution"]);
                        H2outOf = Convert.ToInt32(dtMarks.Rows[i]["h2_out"]);

                        if (h2 >= h2Pass)
                        {
                            dtMarks.Rows[i]["h2Total"] = Convert.ToString(h2);
                            dtMarks.Rows[i]["h2_grace"] = "";
                            if (string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[i]["h1_out"])) || dtMarks.Rows[i]["remark"].ToString() == "Successful")
                                dtMarks.Rows[i]["remark"] = "Successful";
                        }
                        else
                        {
                            bool res = false;
                            if (h2Res != 0)
                            {
                                h2 = addResolution(h2, h2Pass, h2Res);
                                if (h2 >= h2Pass)
                                {
                                    res = true;
                                    dtMarks.Rows[i]["h2Total"] = Convert.ToString(h2);
                                    dtMarks.Rows[i]["h2_grace"] = (h2Pass - Convert.ToInt32(dtMarks.Rows[i]["h2"])) + "^";
                                    if (string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[i]["h1_out"])) || dtMarks.Rows[i]["remark"].ToString() == "Successful")
                                        dtMarks.Rows[i]["remark"] = "Successful";
                                }
                            }

                            if (res == false && abFlag == false)
                            {
                                /*if (H1outOf != 0)
                                {
                                    TotPercent = ((h1Copy + h2) * 100) / (H1outOf + H2outOf);
                                    if (TotPercent >= 50)
                                    {
                                        dtMarks.Rows[i]["h2Total"] = Convert.ToString(h2);
                                        dtMarks.Rows[i]["h2_grace"] = "";
                                        dtMarks.Rows[i]["remark"] = "Successful";
                                        over50Flag = true;
                                    }
                                }
                                 */
                                if (over50Flag == false)
                                {
                                    if (quotaGrc > 0 && FailGrc == false)
                                    {
                                        int h1New;
                                        h1New = h2 + quotaGrc;

                                        if (h1New >= h2Pass)
                                        {
                                            addGrace = true;
                                            dtMarks.Rows[i]["h2Total"] = Convert.ToString(h2Pass);
                                            dtGrcH2 = h2Pass - (h2);
                                            quotaGrc = quotaGrc - dtGrcH2;
                                            dtMarks.Rows[i]["h2_grace"] = Convert.ToString(dtGrcH2) + "*";
                                            if (string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[i]["h1_out"])) || Convert.ToString(dtMarks.Rows[i]["remark"]) == "Successful")
                                                dtMarks.Rows[i]["remark"] = "Successful";
                                        }
                                        else
                                        {
                                            FailGrc = true;
                                            dtMarks.Rows[i]["h2Total"] = Convert.ToString(h2);
                                            dtMarks.Rows[i]["h2_grace"] = "";
                                            dtMarks.Rows[i]["remark"] = "UnSuccessful";
                                        }
                                    }
                                    else
                                    {
                                        FailGrc = true;
                                        dtMarks.Rows[i]["h2Total"] = Convert.ToString(h2);
                                        dtMarks.Rows[i]["h2_grace"] = "";
                                        dtMarks.Rows[i]["remark"] = "UnSuccessful";
                                    }

                                    if (FailGrc == true && addGrace == true)
                                    {
                                        query = "";
                                        for (int j = 0; j < i; j++)
                                        {
                                            if (!string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[j]["h1_grace"])) && Convert.ToString(dtMarks.Rows[j]["h1_grace"]).Contains("*"))
                                            {
                                                dtMarks.Rows[j]["h1_grace"] = "";
                                                dtMarks.Rows[j]["h1Total"] = dtMarks.Rows[j]["h1"];
                                                dtMarks.Rows[j]["remark"] = "UnSuccessful";
                                            }
                                            if (!string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[j]["h2_grace"])) && Convert.ToString(dtMarks.Rows[j]["h2_grace"]).Contains("*"))
                                            {
                                                dtMarks.Rows[j]["h2_grace"] = "";
                                                dtMarks.Rows[j]["h2Total"] = dtMarks.Rows[j]["h2"];
                                                dtMarks.Rows[j]["remark"] = "UnSuccessful";
                                            }
                                            query += "update cre_marks_tbl set h1_grace='" + dtMarks.Rows[j]["h1_grace"] + "',h2_grace='" + dtMarks.Rows[j]["h2_grace"] + "',mod_date=getDate(),remark='" + dtMarks.Rows[j]["remark"] + "' where stud_id='" + dtMarks.Rows[j]["stud_id"] + "' and subject_id='" + dtMarks.Rows[j]["subject_id"] + "'and credit_sub_id='" + dtMarks.Rows[j]["credit_sub_id"] + "' and exam_code='" + dtMarks.Rows[j]["exam_code"] + "' and del_flag=0 ";
                                        }
                                        dtMarks.Rows[i]["h2_grace"] = "";
                                        dtMarks.Rows[i]["h2Total"] = dtMarks.Rows[i]["h2"];
                                        dtMarks.Rows[i]["remark"] = "UnSuccessful";
                                    }
                                }

                            }
                        }
                    }

                }
                else if (string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[i]["h2_out"])))
                {
                    if (h1Blnk == true)
                    {
                        blankMrk++;
                    }
                }
                if (blankMrk == dtMarks.Rows.Count)
                {
                    return false;
                }
                query += "update cre_marks_tbl set h1_grace='" + dtMarks.Rows[i]["h1_grace"] + "',h2_grace='" + dtMarks.Rows[i]["h2_grace"] + "',mod_date=getDate(),remark='" + dtMarks.Rows[i]["remark"] + "' where stud_id='" + dtMarks.Rows[i]["stud_id"] + "' and subject_id='" + dtMarks.Rows[i]["subject_id"] + "'and credit_sub_id='" + dtMarks.Rows[i]["credit_sub_id"] + "' and exam_code='" + dtMarks.Rows[i]["exam_code"] + "' and del_flag=0 ";
            }
        }







        //
        ///////////////////////////////==============================For adding @ Grace==========================================================
        //

        if (ktCnt > 1 && quota != "LD")
        {
            bool GrcFlag = true, afterGrc = false;
            bool FailGrc = false, addGrace = false;
            for (int i = 0; i < dtMarks.Rows.Count; i++)
            {
                bool abFlag = false;
                string sub_ID = dtMarks.Rows[i]["subject_id"].ToString();

                if (dtAb.Rows.Count > 0)
                {
                    for (int x = 0; x < dtAb.Rows.Count; x++)
                    {
                        if (sub_ID == dtAb.Rows[x]["subject_id"].ToString())
                        {
                            abFlag = true;
                            break;
                        }
                    }
                }

                bool h1Blnk = false, h2Blnk = false, over50Flag = false;
                int TotPercent = 0, h1Copy = 0, H1outOf = 0, H2outOf = 0;
                //----------------------------------------------------@@@@@@@@   H1   @@@@@@@@@@------------------------------------------------------------
                int dtGrcH1 = Convert.ToInt32(dtMarks.Rows[i]["h1_grace42"]);
                if (!string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[i]["h1"]).Trim()) && !string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[i]["h1_out"])))
                {
                    if (Convert.ToString(dtMarks.Rows[i]["h1"]).Contains("+"))
                    {
                        dtMarks.Rows[i]["h1"] = Convert.ToString(dtMarks.Rows[i]["h1"]).Substring(0, Convert.ToString(dtMarks.Rows[i]["h1"]).IndexOf('+'));
                    }

                    if (Convert.ToString(dtMarks.Rows[i]["h1"]) == "Ab")
                    {
                        dtMarks.Rows[i]["remark"] = "UnSuccessful";
                        FailGrc = true;
                        if (FailGrc == true && addGrace == true)
                        {
                            query = "";
                            for (int j = 0; j < i; j++)
                            {
                                if (!string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[j]["h1_grace"])) && Convert.ToString(dtMarks.Rows[j]["h1_grace"]).Contains("@"))
                                {
                                    dtMarks.Rows[j]["h1_grace"] = "";
                                    dtMarks.Rows[j]["h1Total"] = dtMarks.Rows[j]["h1"];
                                    dtMarks.Rows[j]["remark"] = "UnSuccessful";
                                }
                                if (!string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[j]["h2_grace"])) && Convert.ToString(dtMarks.Rows[j]["h2_grace"]).Contains("@"))
                                {
                                    dtMarks.Rows[j]["h2_grace"] = "";
                                    dtMarks.Rows[j]["h2Total"] = dtMarks.Rows[j]["h2"];
                                    dtMarks.Rows[j]["remark"] = "UnSuccessful";
                                }
                                query += "update cre_marks_tbl set h1_grace='" + dtMarks.Rows[j]["h1_grace"] + "',h2_grace='" + dtMarks.Rows[j]["h2_grace"] + "',mod_date=getDate(),remark='" + dtMarks.Rows[j]["remark"] + "' where stud_id='" + dtMarks.Rows[j]["stud_id"] + "' and subject_id='" + dtMarks.Rows[j]["subject_id"] + "'and credit_sub_id='" + dtMarks.Rows[j]["credit_sub_id"] + "' and exam_code='" + dtMarks.Rows[j]["exam_code"] + "' and del_flag=0 ";
                            }

                            dtMarks.Rows[i]["h1Total"] = dtMarks.Rows[i]["h1"];
                            dtMarks.Rows[i]["h1_grace"] = "";
                            dtMarks.Rows[i]["remark"] = "UnSuccessful";
                        }
                    }
                    else
                    {
                        int h1 = Convert.ToInt32(dtMarks.Rows[i]["h1"]), h1Pass = Convert.ToInt32(dtMarks.Rows[i]["h1_pass"]), h1Res = Convert.ToInt32(dtMarks.Rows[i]["h1_resolution"]);
                        H1outOf = Convert.ToInt32(dtMarks.Rows[i]["h1_out"]);
                        if (h1 >= h1Pass)
                        {
                            h1Copy = h1;
                            dtMarks.Rows[i]["h1Total"] = Convert.ToString(h1);
                            dtMarks.Rows[i]["h1_grace"] = "";
                            dtMarks.Rows[i]["remark"] = "Successful";
                        }
                        else
                        {
                            bool res = false;
                            if (h1Res != 0)
                            {
                                h1 = addResolution(h1, h1Pass, h1Res);
                                if (h1 >= h1Pass)
                                {
                                    dtMarks.Rows[i]["h1Total"] = Convert.ToString(h1);
                                    dtMarks.Rows[i]["h1_grace"] = (h1Pass - Convert.ToInt32(dtMarks.Rows[i]["h1"])) + "^";
                                    dtMarks.Rows[i]["remark"] = "Successful";
                                    res = true;
                                }
                            }

                            if (res == false && abFlag == false)
                            {
                                if (grcMrk > 0 && FailGrc == false)
                                {
                                    int h1New;
                                    if (dtGrcH1 <= grcMrk)
                                        h1New = h1 + dtGrcH1;
                                    else
                                        h1New = h1;

                                    if (h1New >= h1Pass)
                                    {
                                        addGrace = true;
                                        dtMarks.Rows[i]["h1Total"] = Convert.ToString(h1Pass);
                                        dtGrcH1 = h1Pass - (h1);
                                        grcMrk = grcMrk - dtGrcH1;
                                        dtMarks.Rows[i]["h1_grace"] = Convert.ToString(dtGrcH1) + "@";
                                        dtMarks.Rows[i]["remark"] = "Successful";
                                    }
                                    else
                                    {
                                        FailGrc = true;
                                        dtMarks.Rows[i]["h1Total"] = Convert.ToString(h1);
                                        dtMarks.Rows[i]["h1_grace"] = "";
                                        dtMarks.Rows[i]["remark"] = "UnSuccessful";
                                    }
                                }
                                else
                                {
                                    FailGrc = true;
                                    dtMarks.Rows[i]["h1Total"] = Convert.ToString(h1);
                                    dtMarks.Rows[i]["h1_grace"] = "";
                                    dtMarks.Rows[i]["remark"] = "UnSuccessful";
                                }

                                if (FailGrc == true && addGrace == true)
                                {
                                    query = "";
                                    for (int j = 0; j < i; j++)
                                    {
                                        if (!string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[j]["h1_grace"])) && Convert.ToString(dtMarks.Rows[j]["h1_grace"]).Contains("@"))
                                        {
                                            dtMarks.Rows[j]["h1_grace"] = "";
                                            dtMarks.Rows[j]["h1Total"] = dtMarks.Rows[j]["h1"];
                                            dtMarks.Rows[j]["remark"] = "UnSuccessful";
                                        }
                                        if (!string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[j]["h2_grace"])) && Convert.ToString(dtMarks.Rows[j]["h2_grace"]).Contains("@"))
                                        {
                                            dtMarks.Rows[j]["h2_grace"] = "";
                                            dtMarks.Rows[j]["h2Total"] = dtMarks.Rows[j]["h2"];
                                            dtMarks.Rows[j]["remark"] = "UnSuccessful";
                                        }
                                        query += "update cre_marks_tbl set h1_grace='" + dtMarks.Rows[j]["h1_grace"] + "',h2_grace='" + dtMarks.Rows[j]["h2_grace"] + "',mod_date=getDate(),remark='" + dtMarks.Rows[j]["remark"] + "' where stud_id='" + dtMarks.Rows[j]["stud_id"] + "' and subject_id='" + dtMarks.Rows[j]["subject_id"] + "'and credit_sub_id='" + dtMarks.Rows[j]["credit_sub_id"] + "' and exam_code='" + dtMarks.Rows[j]["exam_code"] + "' and del_flag=0 ";
                                    }

                                    dtMarks.Rows[i]["h1Total"] = Convert.ToString(h1);
                                    dtMarks.Rows[i]["h1_grace"] = "";
                                    dtMarks.Rows[i]["remark"] = "UnSuccessful";
                                }
                            }
                        }
                    }
                }
                else if (string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[i]["h1_out"])))
                {
                    h1Blnk = true;
                }
                //----------------------------------------------------------@@@@@@@@@@    H2    @@@@@@@@@@@@-----------------------------------------------------

                int dtGrcH2 = Convert.ToInt32(dtMarks.Rows[i]["h2_grace42"]);
                if (!string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[i]["h2"]).Trim()) && !string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[i]["h2_out"])))
                {
                    if (Convert.ToString(dtMarks.Rows[i]["h2"]).Contains("+"))
                    {
                        dtMarks.Rows[i]["h2"] = Convert.ToString(dtMarks.Rows[i]["h2"]).Substring(0, Convert.ToString(dtMarks.Rows[i]["h2"]).IndexOf('+'));
                    }

                    if (Convert.ToString(dtMarks.Rows[i]["h2"]) == "Ab")
                    {
                        dtMarks.Rows[i]["remark"] = "UnSuccessful";
                        FailGrc = true;
                        if (FailGrc == true && addGrace == true)
                        {
                            query = "";
                            for (int j = 0; j < i; j++)
                            {
                                if (!string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[j]["h1_grace"])) && Convert.ToString(dtMarks.Rows[j]["h1_grace"]).Contains("@"))
                                {
                                    dtMarks.Rows[j]["h1_grace"] = "";
                                    dtMarks.Rows[j]["h1Total"] = dtMarks.Rows[j]["h1"];
                                    dtMarks.Rows[j]["remark"] = "UnSuccessful";
                                }
                                if (!string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[j]["h2_grace"])) && Convert.ToString(dtMarks.Rows[j]["h2_grace"]).Contains("@"))
                                {
                                    dtMarks.Rows[j]["h2_grace"] = "";
                                    dtMarks.Rows[j]["h2Total"] = dtMarks.Rows[j]["h2"];
                                    dtMarks.Rows[j]["remark"] = "UnSuccessful";
                                }

                                query += "update cre_marks_tbl set h1_grace='" + dtMarks.Rows[j]["h1_grace"] + "',h2_grace='" + dtMarks.Rows[j]["h2_grace"] + "',mod_date=getDate(),remark='" + dtMarks.Rows[j]["remark"] + "' where stud_id='" + dtMarks.Rows[j]["stud_id"] + "' and subject_id='" + dtMarks.Rows[j]["subject_id"] + "'and credit_sub_id='" + dtMarks.Rows[j]["credit_sub_id"] + "' and exam_code='" + dtMarks.Rows[j]["exam_code"] + "' and del_flag=0 ";
                            }
                            dtMarks.Rows[i]["h2_grace"] = "";
                            dtMarks.Rows[i]["h2Total"] = dtMarks.Rows[i]["h2"];
                            dtMarks.Rows[i]["remark"] = "UnSuccessful";
                        }
                    }
                    else
                    {
                        int h2 = Convert.ToInt32(dtMarks.Rows[i]["h2"]), h2Pass = Convert.ToInt32(dtMarks.Rows[i]["h2_pass"]), h2Res = Convert.ToInt32(dtMarks.Rows[i]["h2_resolution"]);
                        H2outOf = Convert.ToInt32(dtMarks.Rows[i]["h2_out"]);

                        if (h2 >= h2Pass)
                        {
                            dtMarks.Rows[i]["h2Total"] = Convert.ToString(h2);
                            dtMarks.Rows[i]["h2_grace"] = "";
                            if (string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[i]["h1_out"])) || dtMarks.Rows[i]["remark"].ToString() == "Successful")
                                dtMarks.Rows[i]["remark"] = "Successful";
                        }
                        else
                        {
                            bool res = false;
                            if (h2Res != 0)
                            {
                                h2 = addResolution(h2, h2Pass, h2Res);
                                if (h2 >= h2Pass)
                                {
                                    res = true;
                                    dtMarks.Rows[i]["h2Total"] = Convert.ToString(h2);
                                    dtMarks.Rows[i]["h2_grace"] = (h2Pass - Convert.ToInt32(dtMarks.Rows[i]["h2"])) + "^";
                                    if (string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[i]["h1_out"])) || dtMarks.Rows[i]["remark"].ToString() == "Successful")
                                        dtMarks.Rows[i]["remark"] = "Successful";
                                }
                            }

                            if (res == false && abFlag == false)
                            {
                                /*if (H1outOf != 0)
                                {
                                    TotPercent = ((h1Copy + h2) * 100) / (H1outOf + H2outOf);
                                    if (TotPercent >= 50)
                                    {
                                        dtMarks.Rows[i]["h2Total"] = Convert.ToString(h2);
                                        dtMarks.Rows[i]["h2_grace"] = "";
                                        dtMarks.Rows[i]["remark"] = "Successful";
                                        over50Flag = true;
                                    }
                                }
                                 */
                                if (over50Flag == false)
                                {
                                    if (grcMrk > 0 && FailGrc == false)
                                    {
                                        int h1New;
                                        if (dtGrcH2 <= grcMrk)
                                            h1New = h2 + h2Res + dtGrcH2;
                                        else
                                            h1New = h2;

                                        if (h1New >= h2Pass)
                                        {
                                            addGrace = true;
                                            dtMarks.Rows[i]["h2Total"] = Convert.ToString(h2Pass);
                                            dtGrcH2 = h2Pass - (h2);
                                            grcMrk = grcMrk - dtGrcH2;
                                            dtMarks.Rows[i]["h2_grace"] = Convert.ToString(dtGrcH2) + "@";
                                            if (string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[i]["h1_out"])) || Convert.ToString(dtMarks.Rows[i]["remark"]) == "Successful")
                                                dtMarks.Rows[i]["remark"] = "Successful";
                                        }
                                        else
                                        {
                                            FailGrc = true;
                                            dtMarks.Rows[i]["h2Total"] = Convert.ToString(h2);
                                            dtMarks.Rows[i]["h2_grace"] = "";
                                            dtMarks.Rows[i]["remark"] = "UnSuccessful";
                                        }
                                    }
                                    else
                                    {
                                        FailGrc = true;
                                        dtMarks.Rows[i]["h2Total"] = Convert.ToString(h2);
                                        dtMarks.Rows[i]["h2_grace"] = "";
                                        dtMarks.Rows[i]["remark"] = "UnSuccessful";
                                    }

                                    if (FailGrc == true && addGrace == true)
                                    {
                                        query = "";
                                        for (int j = 0; j < i; j++)
                                        {
                                            if (!string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[j]["h1_grace"])) && Convert.ToString(dtMarks.Rows[j]["h1_grace"]).Contains("@"))
                                            {
                                                dtMarks.Rows[j]["h1_grace"] = "";
                                                dtMarks.Rows[j]["h1Total"] = dtMarks.Rows[j]["h1"];
                                                dtMarks.Rows[j]["remark"] = "UnSuccessful";
                                            }
                                            if (!string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[j]["h2_grace"])) && Convert.ToString(dtMarks.Rows[j]["h2_grace"]).Contains("@"))
                                            {
                                                dtMarks.Rows[j]["h2_grace"] = "";
                                                dtMarks.Rows[j]["h2Total"] = dtMarks.Rows[j]["h2"];
                                                dtMarks.Rows[j]["remark"] = "UnSuccessful";
                                            }
                                            query += "update cre_marks_tbl set h1_grace='" + dtMarks.Rows[j]["h1_grace"] + "',h2_grace='" + dtMarks.Rows[j]["h2_grace"] + "',mod_date=getDate(),remark='" + dtMarks.Rows[j]["remark"] + "' where stud_id='" + dtMarks.Rows[j]["stud_id"] + "' and subject_id='" + dtMarks.Rows[j]["subject_id"] + "'and credit_sub_id='" + dtMarks.Rows[j]["credit_sub_id"] + "' and exam_code='" + dtMarks.Rows[j]["exam_code"] + "' and del_flag=0 ";
                                        }
                                        dtMarks.Rows[i]["h2_grace"] = "";
                                        dtMarks.Rows[i]["h2Total"] = dtMarks.Rows[i]["h2"];
                                        dtMarks.Rows[i]["remark"] = "UnSuccessful";
                                    }
                                }

                            }
                        }
                    }

                }
                else if (string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[i]["h2_out"])))
                {
                    if (h1Blnk == true)
                    {
                        blankMrk++;
                    }
                }
                if (blankMrk == dtMarks.Rows.Count)
                {
                    return false;
                }
                query += "update cre_marks_tbl set h1_grace='" + dtMarks.Rows[i]["h1_grace"] + "',h2_grace='" + dtMarks.Rows[i]["h2_grace"] + "',mod_date=getDate(),remark='" + dtMarks.Rows[i]["remark"] + "' where stud_id='" + dtMarks.Rows[i]["stud_id"] + "' and subject_id='" + dtMarks.Rows[i]["subject_id"] + "'and credit_sub_id='" + dtMarks.Rows[i]["credit_sub_id"] + "' and exam_code='" + dtMarks.Rows[i]["exam_code"] + "' and del_flag=0 ";
            }
        }

        //
        ///////////////////////////////==============================For adding RESOLUTION ==========================================================
        //

        if (ktCnt == 0)
        {
            bool FailGrc = false;
            for (int i = 0; i < dtMarks.Rows.Count; i++)
            {
                bool h1Blnk = false, h2Blnk = false;
                int TotPercent = 0, h1Copy = 0, H1outOf = 0, H2outOf = 0;
                //------------------------------------------------@@@@@@@@@@    H1   @@@@@@@@@@@-----------------------------------------------
                if (!string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[i]["h1"]).Trim()) && !string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[i]["h1_out"])))
                {

                    if (Convert.ToString(dtMarks.Rows[i]["h1"]).Contains("+"))
                    {
                        dtMarks.Rows[i]["h1"] = Convert.ToString(dtMarks.Rows[i]["h1"]).Substring(0, Convert.ToString(dtMarks.Rows[i]["h1"]).IndexOf('+'));
                    }

                    if (Convert.ToString(dtMarks.Rows[i]["h1"]) == "Ab")
                    {
                        dtMarks.Rows[i]["remark"] = "UnSuccessful";
                    }
                    else
                    {
                        int h1 = Convert.ToInt32(dtMarks.Rows[i]["h1"]), h1Pass = Convert.ToInt32(dtMarks.Rows[i]["h1_pass"]), h1Res = Convert.ToInt32(dtMarks.Rows[i]["h1_resolution"]);
                        H1outOf = Convert.ToInt32(dtMarks.Rows[i]["h1_out"]);

                        if (h1 >= h1Pass)
                        {
                            h1Copy = h1;
                            dtMarks.Rows[i]["h1Total"] = Convert.ToString(h1);
                            dtMarks.Rows[i]["h1_grace"] = "";
                            dtMarks.Rows[i]["remark"] = "Successful";
                        }
                        else
                        {
                            bool res = false;
                            if (h1Res != 0)
                            {
                                h1 = addResolution(h1, h1Pass, h1Res);
                                if (h1 >= h1Pass)
                                {
                                    res = true;
                                    h1Copy = h1;
                                    dtMarks.Rows[i]["h1Total"] = Convert.ToString(h1);
                                    dtMarks.Rows[i]["h1_grace"] = (h1Pass - Convert.ToInt32(dtMarks.Rows[i]["h1"])) + "^";
                                    dtMarks.Rows[i]["remark"] = "Successful";
                                }
                            }

                            if (res == false)
                            {
                                dtMarks.Rows[i]["h1Total"] = Convert.ToString(h1);
                                dtMarks.Rows[i]["h1_grace"] = "";
                                dtMarks.Rows[i]["remark"] = "UnSuccessful";
                            }
                        }
                    }
                }
                else if (string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[i]["h1_out"])))
                {
                    h1Blnk = true;
                }

                //-------------------------------------------------------@@@@@@@@@@@    h2   @@@@@@@@@@-----------------------------------------------
                if (!string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[i]["h2"]).Trim()) && !string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[i]["h2_out"])))
                {
                    bool over50Flag = false;


                    if (Convert.ToString(dtMarks.Rows[i]["h2"]).Contains("+"))
                    {
                        dtMarks.Rows[i]["h2"] = Convert.ToString(dtMarks.Rows[i]["h2"]).Substring(0, Convert.ToString(dtMarks.Rows[i]["h2"]).IndexOf('+'));
                    }

                    if (Convert.ToString(dtMarks.Rows[i]["h2"]) == "Ab")
                    {
                        dtMarks.Rows[i]["remark"] = "UnSuccessful";
                    }
                    else
                    {
                        int h2 = Convert.ToInt32(dtMarks.Rows[i]["h2"]), h2Pass = Convert.ToInt32(dtMarks.Rows[i]["h2_pass"]), h2Res = Convert.ToInt32(dtMarks.Rows[i]["h2_resolution"]);
                        H2outOf = Convert.ToInt32(dtMarks.Rows[i]["h2_out"]);

                        if (h2 >= h2Pass)
                        {
                            dtMarks.Rows[i]["h2Total"] = Convert.ToString(h2);
                            dtMarks.Rows[i]["h2_grace"] = "";
                            if (string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[i]["h1_out"])) || Convert.ToString(dtMarks.Rows[i]["remark"]) == "Successful")
                                dtMarks.Rows[i]["remark"] = "Successful";
                        }
                        else
                        {
                            bool res = false;
                            if (h2Res != 0)
                            {
                                h2 = addResolution(h2, h2Pass, h2Res);
                                if (h2 >= h2Pass)
                                {
                                    res = true;
                                    dtMarks.Rows[i]["h2Total"] = Convert.ToString(h2);
                                    dtMarks.Rows[i]["h2_grace"] = (h2Pass - Convert.ToInt32(dtMarks.Rows[i]["h2"])) + "^";
                                    if (string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[i]["h1_out"])) || Convert.ToString(dtMarks.Rows[i]["remark"]) == "Successful")
                                        dtMarks.Rows[i]["remark"] = "Successful";

                                }
                            }
                            if (res == false)
                            {
                                /* if (H1outOf != 0)
                                 {
                                     TotPercent = ((h1Copy + h2) * 100) / (H1outOf + H2outOf);
                                     if (TotPercent >= 50)
                                     {
                                         dtMarks.Rows[i]["h2Total"] = Convert.ToString(h2);
                                         dtMarks.Rows[i]["h2_grace"] = "";
                                         dtMarks.Rows[i]["remark"] = "Successful";
                                         over50Flag = true;
                                     }
                                 }
                                 */

                                if (over50Flag == false)
                                {
                                    dtMarks.Rows[i]["h2Total"] = Convert.ToString(h2);
                                    dtMarks.Rows[i]["h2_grace"] = "";
                                    dtMarks.Rows[i]["remark"] = "UnSuccessful";
                                }
                            }
                        }
                    }
                }
                else if (!string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[i]["h2_out"])))
                {
                    if (h1Blnk == true)
                    {
                        blankMrk++;
                    }
                }


                if (blankMrk == dtMarks.Rows.Count)
                {
                    return false;
                }
                query += "update cre_marks_tbl set h1_grace='" + dtMarks.Rows[i]["h1_grace"] + "',h2_grace='" + dtMarks.Rows[i]["h2_grace"] + "',mod_date=getDate(),remark='" + dtMarks.Rows[i]["remark"] + "' where stud_id='" + dtMarks.Rows[i]["stud_id"] + "' and subject_id='" + dtMarks.Rows[i]["subject_id"] + "'and credit_sub_id='" + dtMarks.Rows[i]["credit_sub_id"] + "' and exam_code='" + dtMarks.Rows[i]["exam_code"] + "' and del_flag=0 ";

            }
        }
        //================================Updating Grace=======================
        if (DMLquerries(query))
            return true;
        else
            return false;
    }

    public string NumbersToWords(int inputNumber)
    {
        int inputNo = inputNumber;

        if (inputNo == 0)
            return "Zero";

        int[] numbers = new int[4];
        int first = 0;
        int u, h, t;
        System.Text.StringBuilder sb = new System.Text.StringBuilder();

        if (inputNo < 0)
        {
            sb.Append("Minus ");
            inputNo = -inputNo;
        }

        string[] words0 = {"" ,"One ", "Two ", "Three ", "Four ",
            "Five " ,"Six ", "Seven ", "Eight ", "Nine "};
        string[] words1 = {"Ten ", "Eleven ", "Twelve ", "Thirteen ", "Fourteen ",
            "Fifteen ","Sixteen ","Seventeen ","Eighteen ", "Nineteen "};
        string[] words2 = {"Twenty ", "Thirty ", "Forty ", "Fifty ", "Sixty ",
            "Seventy ","Eighty ", "Ninety "};
        string[] words3 = { "Thousand ", "Lakh ", "Crore " };

        numbers[0] = inputNo % 1000; // units
        numbers[1] = inputNo / 1000;
        numbers[2] = inputNo / 100000;
        numbers[1] = numbers[1] - 100 * numbers[2]; // thousands
        numbers[3] = inputNo / 10000000; // crores
        numbers[2] = numbers[2] - 100 * numbers[3]; // lakhs

        for (int i = 3; i > 0; i--)
        {
            if (numbers[i] != 0)
            {
                first = i;
                break;
            }
        }
        for (int i = first; i >= 0; i--)
        {
            if (numbers[i] == 0) continue;
            u = numbers[i] % 10; // ones
            t = numbers[i] / 10;
            h = numbers[i] / 100; // hundreds
            t = t - 10 * h; // tens
            if (h > 0) sb.Append(words0[h] + "Hundred ");
            if (u > 0 || t > 0)
            {
                if (h > 0 || i == 0) sb.Append("");
                if (t == 0)
                    sb.Append(words0[u]);
                else if (t == 1)
                    sb.Append(words1[u]);
                else
                    sb.Append(words2[t - 2] + words0[u]);
            }
            if (i != 0) sb.Append(words3[i - 1]);
        }
        string sb_final = sb.ToString().TrimEnd();
        return sb + "Only.";
    }
    //public bool addOverallGraceNew(DataTable dtMarks, int grcMrk, DataTable dt42, string quota, DataTable dtAb)
    //{
    //    if (dtMarks.Rows[0]["stud_id"].ToString() == "16734032")
    //    {

    //    }
    //    int ktCnt = 0;

    //    if (dt42.Rows.Count > 0)
    //    {
    //        ktCnt = Convert.ToInt32(dt42.Rows[0][0]);
    //    }

    //    dtMarks.Columns.Add("h1Total");
    //    dtMarks.Columns.Add("h2Total");
    //    //bool GrcFlag = true, afterGrc = false;
    //    string query = "", remark = "";
    //    int blankMrk = 0;
    //    int Grc1Per = grcMrk;
    //    int quotaGrc = 0;
    //    if (quota != "" && quota == "LD")
    //        quotaGrc = 20;
    //    ///////////////////////////////==============================For Adding * Grace=======================================

    //    if (ktCnt == 1)
    //    {
    //        bool Grace = false;
    //        bool quotaFlag = false;
    //        bool atGrace = false;

    //        for (int i = 0; i < dtMarks.Rows.Count; i++)
    //        {

    //            bool abFlag = false;
    //            string sub_ID = dtMarks.Rows[i]["subject_id"].ToString();

    //            if (dtAb.Rows.Count > 0)
    //            {
    //                for (int x = 0; x < dtAb.Rows.Count; x++)
    //                {
    //                    if (sub_ID == dtAb.Rows[x]["subject_id"].ToString())
    //                    {
    //                        abFlag = true;
    //                        break;
    //                    }
    //                }
    //            }

    //            bool h1Blnk = false, h2Blnk = false;
    //            int TotPercent = 0, h1Copy = 0, H1outOf = 0, H2outOf = 0;
    //            int dtGrcH1 = Convert.ToInt32(dtMarks.Rows[i]["h1_grace42"]);
    //            //---------------------------------------------@@@@@@@@@@    H1    @@@@@@@@@@@@--------------------------------------------------------
    //            if (!string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[i]["h1"]).Trim()) && !string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[i]["h1_out"])))
    //            {
    //                if (Convert.ToString(dtMarks.Rows[i]["h1"]).Contains("+"))
    //                {
    //                    dtMarks.Rows[i]["h1"] = Convert.ToString(dtMarks.Rows[i]["h1"]).Substring(0, Convert.ToString(dtMarks.Rows[i]["h1"]).IndexOf('+'));
    //                }

    //                if (Convert.ToString(dtMarks.Rows[i]["h1"]) == "Ab")
    //                {
    //                    abFlag = true;
    //                    dtMarks.Rows[i]["remark"] = "UnSuccessful";
    //                }
    //                else
    //                {
    //                    int h1 = Convert.ToInt32(dtMarks.Rows[i]["h1"]), h1Pass = Convert.ToInt32(dtMarks.Rows[i]["h1_pass"]), h1Res = Convert.ToInt32(dtMarks.Rows[i]["h1_resolution"]);
    //                    H1outOf = Convert.ToInt32(dtMarks.Rows[i]["h1_out"]);
    //                    if (h1 >= h1Pass)
    //                    {
    //                        h1Copy = h1;
    //                        dtMarks.Rows[i]["h1Total"] = Convert.ToString(h1);
    //                        dtMarks.Rows[i]["h1_grace"] = "";
    //                        dtMarks.Rows[i]["remark"] = "Successful";
    //                    }
    //                    else
    //                    {
    //                        bool res = false;
    //                        if (h1Res != 0)
    //                        {
    //                            h1 = addResolution(h1, h1Pass, h1Res);
    //                            if (h1 >= h1Pass)
    //                            {
    //                                dtMarks.Rows[i]["h1Total"] = Convert.ToString(h1);
    //                                dtMarks.Rows[i]["h1_grace"] = (h1Pass - Convert.ToInt32(dtMarks.Rows[i]["h1"])) + "^";
    //                                dtMarks.Rows[i]["remark"] = "Successful";
    //                                res = true;
    //                            }
    //                        }
    //                        if (res == false && abFlag == false)
    //                        {
    //                            //------------------------@ before *--------------------
    //                            int h1New;
    //                            if (dtGrcH1 <= grcMrk)
    //                                h1New = h1 + dtGrcH1;
    //                            else
    //                                h1New = h1;

    //                            if (h1New >= h1Pass && atGrace == false)
    //                            {
    //                                atGrace = true;
    //                                dtMarks.Rows[i]["h1Total"] = Convert.ToString(h1Pass);
    //                                dtGrcH1 = h1Pass - (h1);
    //                                grcMrk = grcMrk - dtGrcH1;
    //                                dtMarks.Rows[i]["h1_grace"] = Convert.ToString(dtGrcH1) + "@";
    //                                dtMarks.Rows[i]["remark"] = "Successful";
    //                                Grace = true;
    //                            }
    //                            else if (Grace == false)
    //                            {
    //                                //------------------------@ before *----------------------


    //                                int a = rndNum((Convert.ToDecimal(dtMarks.Rows[i]["h1_out"]) / 10));
    //                                //int b = rndNum(Convert.ToDecimal(3));
    //                                if (a < Grc1Per)
    //                                {
    //                                    grcMrk = a;
    //                                }

    //                                //int h1New;
    //                                h1New = h1 + grcMrk;
    //                                if (h1New >= h1Pass && Grace == false)
    //                                {
    //                                    dtMarks.Rows[i]["h1Total"] = Convert.ToString(h1Pass);
    //                                    grcMrk = h1Pass - (h1);
    //                                    dtMarks.Rows[i]["h1_grace"] = Convert.ToString(grcMrk) + "*";
    //                                    dtMarks.Rows[i]["remark"] = "Successful";
    //                                    Grace = true;
    //                                }
    //                                else if (quotaGrc != 0 && quota == "LD" && quotaFlag == false)
    //                                {
    //                                    h1New = h1 + quotaGrc;
    //                                    if (h1New >= h1Pass)
    //                                    {
    //                                        quotaFlag = true;
    //                                        dtMarks.Rows[i]["h1Total"] = Convert.ToString(h1Pass);
    //                                        quotaGrc = h1Pass - (h1);
    //                                        dtMarks.Rows[i]["h1_grace"] = Convert.ToString(quotaGrc) + "*";
    //                                        dtMarks.Rows[i]["remark"] = "Successful";
    //                                    }
    //                                    else
    //                                    {
    //                                        dtMarks.Rows[i]["h1Total"] = Convert.ToString(h1);
    //                                        dtMarks.Rows[i]["h1_grace"] = "";
    //                                        dtMarks.Rows[i]["remark"] = "UnSuccessful";
    //                                        quotaFlag = true;
    //                                    }
    //                                }
    //                                else
    //                                {
    //                                    dtMarks.Rows[i]["h1Total"] = Convert.ToString(h1);
    //                                    dtMarks.Rows[i]["h1_grace"] = "";
    //                                    dtMarks.Rows[i]["remark"] = "UnSuccessful";
    //                                    Grace = true;
    //                                }
    //                            }
    //                        }
    //                    }
    //                }
    //            }
    //            else if (string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[i]["h1_out"])))
    //            {
    //                h1Blnk = true;
    //            }

    //            int dtGrcH2 = Convert.ToInt32(dtMarks.Rows[i]["h2_grace42"]);
    //            //-------------------------------------------------------@@@@@@@@@@   H2   @@@@@@@@@@-------------------------------------------------
    //            if (!string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[i]["h2"]).Trim()) && !string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[i]["h2_out"])))
    //            {
    //                bool over50Flag = false;

    //                if (Convert.ToString(dtMarks.Rows[i]["h2"]).Contains("+"))
    //                {
    //                    dtMarks.Rows[i]["h2"] = Convert.ToString(dtMarks.Rows[i]["h2"]).Substring(0, Convert.ToString(dtMarks.Rows[i]["h2"]).IndexOf('+'));
    //                }

    //                if (Convert.ToString(dtMarks.Rows[i]["h2"]) == "Ab")
    //                {
    //                    dtMarks.Rows[i]["remark"] = "UnSuccessful";
    //                }
    //                else
    //                {
    //                    int h2 = Convert.ToInt32(dtMarks.Rows[i]["h2"]), h2Pass = Convert.ToInt32(dtMarks.Rows[i]["h2_pass"]), h2Res = Convert.ToInt32(dtMarks.Rows[i]["h2_resolution"]);
    //                    H2outOf = Convert.ToInt32(dtMarks.Rows[i]["h2_out"]);

    //                    if (h2 >= h2Pass)
    //                    {
    //                        dtMarks.Rows[i]["h2Total"] = Convert.ToString(h2);
    //                        dtMarks.Rows[i]["h2_grace"] = "";

    //                        if (string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[i]["h1_out"])) || Convert.ToString(dtMarks.Rows[i]["remark"]) == "Successful")
    //                            dtMarks.Rows[i]["remark"] = "Successful";
    //                    }
    //                    else
    //                    {
    //                        bool res = false;
    //                        if (h2Res != 0)
    //                        {
    //                            h2 = addResolution(h2, h2Pass, h2Res);
    //                            if (h2 > h2Pass)
    //                            {
    //                                res = true;
    //                                dtMarks.Rows[i]["h1Total"] = Convert.ToString(h2);
    //                                dtMarks.Rows[i]["h2_grace"] = (h2Pass - Convert.ToInt32(dtMarks.Rows[i]["h2"])) + "^";
    //                                if (string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[i]["h1_out"])) || Convert.ToString(dtMarks.Rows[i]["remark"]) == "Successful")
    //                                    dtMarks.Rows[i]["remark"] = "Successful";
    //                            }
    //                        }

    //                        if (res == false && abFlag == false)
    //                        {

    //                            //---- new add 14-1-16 for !
    //                            //if (H1outOf != 0)
    //                            //{
    //                            //    TotPercent = ((h1Copy + h2) * 100) / (H1outOf + H2outOf);
    //                            //    if (TotPercent >= 50)
    //                            //    {
    //                            //        dtMarks.Rows[i]["h2Total"] = Convert.ToString(h2);
    //                            //        dtGrcH2 = h2Pass - (h2);
    //                            //        dtMarks.Rows[i]["h2_grace"] = Convert.ToString(dtGrcH2) + "!";
    //                            //        dtMarks.Rows[i]["remark"] = "Successful";
    //                            //        over50Flag = true;
    //                            //    }
    //                            //}
    //                            //-------------
    //                            //========================H2 @ before *===============
    //                            int h1New;
    //                            if (dtGrcH2 <= grcMrk)
    //                                h1New = h2 + dtGrcH2;
    //                            else
    //                                h1New = h2;

    //                            if (h1New >= h2Pass && atGrace == false && over50Flag == false)
    //                            {
    //                                atGrace = true;
    //                                dtMarks.Rows[i]["h2Total"] = Convert.ToString(h2Pass);
    //                                dtGrcH2 = h2Pass - (h2);
    //                                grcMrk = grcMrk - dtGrcH2;
    //                                dtMarks.Rows[i]["h2_grace"] = Convert.ToString(dtGrcH2) + "@";
    //                                if (string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[i]["h1_out"])) || Convert.ToString(dtMarks.Rows[i]["remark"]) == "Successful")
    //                                    dtMarks.Rows[i]["remark"] = "Successful";
    //                                Grace = true;
    //                            }
    //                            else if (Grace == false)
    //                            {
    //                                //========================H2 @ before *===============

    //                                if (over50Flag == false && Grace == false)
    //                                {
    //                                    if ((Convert.ToInt32(dtMarks.Rows[i]["h2_out"]) / 10) < Grc1Per)
    //                                    {
    //                                        grcMrk = Convert.ToInt32(dtMarks.Rows[i]["h2_out"]) / 10;
    //                                    }

    //                                    //int h1New;
    //                                    h1New = h2 + grcMrk;
    //                                    Grace = true;
    //                                    if (h1New >= h2Pass)
    //                                    {
    //                                        dtMarks.Rows[i]["h2Total"] = Convert.ToString(h2Pass);
    //                                        grcMrk = h2Pass - (h2);
    //                                        dtMarks.Rows[i]["h2_grace"] = Convert.ToString(grcMrk) + "*";
    //                                        if (string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[i]["h1_out"])) || Convert.ToString(dtMarks.Rows[i]["remark"]) == "Successful")
    //                                            dtMarks.Rows[i]["remark"] = "Successful";
    //                                    }
    //                                    else if (quotaGrc != 0 && quota == "LD" && quotaFlag == false)
    //                                    {
    //                                        h1New = h2 + quotaGrc;
    //                                        quotaFlag = true;
    //                                        if (h1New >= h2Pass)
    //                                        {
    //                                            dtMarks.Rows[i]["h2Total"] = Convert.ToString(h2Pass);
    //                                            quotaGrc = h2Pass - (h2);
    //                                            dtMarks.Rows[i]["h2_grace"] = Convert.ToString(quotaGrc) + "*";
    //                                            if (string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[i]["h1_out"])) || Convert.ToString(dtMarks.Rows[i]["remark"]) == "Successful")
    //                                                dtMarks.Rows[i]["remark"] = "Successful";
    //                                        }
    //                                        else
    //                                        {
    //                                            dtMarks.Rows[i]["h2Total"] = Convert.ToString(h2);
    //                                            dtMarks.Rows[i]["h2_grace"] = "";
    //                                            dtMarks.Rows[i]["remark"] = "UnSuccessful";
    //                                        }
    //                                    }
    //                                    else
    //                                    {
    //                                        dtMarks.Rows[i]["h2Total"] = Convert.ToString(h2);
    //                                        dtMarks.Rows[i]["h2_grace"] = "";
    //                                        dtMarks.Rows[i]["remark"] = "UnSuccessful";
    //                                    }
    //                                }
    //                                else if (over50Flag == false && Grace == true)
    //                                {
    //                                    dtMarks.Rows[i]["h2Total"] = Convert.ToString(h2);
    //                                    dtMarks.Rows[i]["h2_grace"] = "";
    //                                    dtMarks.Rows[i]["remark"] = "UnSuccessful";
    //                                }
    //                            }
    //                        }

    //                    }
    //                }

    //            }
    //            else if (string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[i]["h2_out"])))
    //            {
    //                if (h1Blnk == true)
    //                {
    //                    blankMrk++;
    //                }
    //            }
    //            if (blankMrk == dtMarks.Rows.Count)
    //            {
    //                return false;
    //            }
    //            query += "update cre_marks_tbl set h1_grace='" + dtMarks.Rows[i]["h1_grace"] + "',h2_grace='" + dtMarks.Rows[i]["h2_grace"] + "',mod_date=getDate(),remark='" + dtMarks.Rows[i]["remark"] + "' where stud_id='" + dtMarks.Rows[i]["stud_id"] + "' and subject_id='" + dtMarks.Rows[i]["subject_id"] + "'and credit_sub_id='" + dtMarks.Rows[i]["credit_sub_id"] + "' and exam_code='" + dtMarks.Rows[i]["exam_code"] + "' and del_flag=0 ";


    //        }
    //    }

    //    //
    //    //////////////////////////////================================For adding Dyslexia Grace===============================
    //    //
    //    if (ktCnt > 1 && quotaGrc != 0 && quota == "LD")
    //    {
    //        bool GrcFlag = true, afterGrc = false;
    //        bool FailGrc = false, addGrace = false;



    //        for (int i = 0; i < dtMarks.Rows.Count; i++)
    //        {
    //            bool abFlag = false;
    //            string sub_ID = dtMarks.Rows[i]["subject_id"].ToString();

    //            if (dtAb.Rows.Count > 0)
    //            {
    //                for (int x = 0; x < dtAb.Rows.Count; x++)
    //                {
    //                    if (sub_ID == dtAb.Rows[x]["subject_id"].ToString())
    //                    {
    //                        abFlag = true;
    //                        break;
    //                    }
    //                }
    //            }

    //            bool h1Blnk = false, h2Blnk = false, over50Flag = false;
    //            int TotPercent = 0, h1Copy = 0, H1outOf = 0, H2outOf = 0;
    //            //----------------------------------------------------@@@@@@@@   H1   @@@@@@@@@@------------------------------------------------------------
    //            int dtGrcH1 = Convert.ToInt32(dtMarks.Rows[i]["h1_grace42"]);
    //            if (!string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[i]["h1"]).Trim()) && !string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[i]["h1_out"])))
    //            {
    //                if (Convert.ToString(dtMarks.Rows[i]["h1"]).Contains("+"))
    //                {
    //                    dtMarks.Rows[i]["h1"] = Convert.ToString(dtMarks.Rows[i]["h1"]).Substring(0, Convert.ToString(dtMarks.Rows[i]["h1"]).IndexOf('+'));
    //                }

    //                if (Convert.ToString(dtMarks.Rows[i]["h1"]) == "Ab")
    //                {
    //                    dtMarks.Rows[i]["remark"] = "UnSuccessful";
    //                    FailGrc = true;
    //                    if (FailGrc == true && addGrace == true)
    //                    {
    //                        query = "";
    //                        for (int j = 0; j < i; j++)
    //                        {
    //                            if (!string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[j]["h1_grace"])) && Convert.ToString(dtMarks.Rows[j]["h1_grace"]).Contains("*"))
    //                            {
    //                                dtMarks.Rows[j]["h1_grace"] = "";
    //                                dtMarks.Rows[j]["h1Total"] = dtMarks.Rows[j]["h1"];
    //                                dtMarks.Rows[j]["remark"] = "UnSuccessful";
    //                            }
    //                            if (!string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[j]["h2_grace"])) && Convert.ToString(dtMarks.Rows[j]["h2_grace"]).Contains("*"))
    //                            {
    //                                dtMarks.Rows[j]["h2_grace"] = "";
    //                                dtMarks.Rows[j]["h2Total"] = dtMarks.Rows[j]["h2"];
    //                                dtMarks.Rows[j]["remark"] = "UnSuccessful";
    //                            }
    //                            query += "update cre_marks_tbl set h1_grace='" + dtMarks.Rows[j]["h1_grace"] + "',h2_grace='" + dtMarks.Rows[j]["h2_grace"] + "',mod_date=getDate(),remark='" + dtMarks.Rows[j]["remark"] + "' where stud_id='" + dtMarks.Rows[j]["stud_id"] + "' and subject_id='" + dtMarks.Rows[j]["subject_id"] + "'and credit_sub_id='" + dtMarks.Rows[j]["credit_sub_id"] + "' and exam_code='" + dtMarks.Rows[j]["exam_code"] + "' and del_flag=0 ";
    //                        }

    //                        dtMarks.Rows[i]["h1Total"] = dtMarks.Rows[i]["h1"];
    //                        dtMarks.Rows[i]["h1_grace"] = "";
    //                        dtMarks.Rows[i]["remark"] = "UnSuccessful";
    //                    }
    //                }
    //                else
    //                {
    //                    int h1 = Convert.ToInt32(dtMarks.Rows[i]["h1"]), h1Pass = Convert.ToInt32(dtMarks.Rows[i]["h1_pass"]), h1Res = Convert.ToInt32(dtMarks.Rows[i]["h1_resolution"]);
    //                    H1outOf = Convert.ToInt32(dtMarks.Rows[i]["h1_out"]);
    //                    if (h1 >= h1Pass)
    //                    {
    //                        h1Copy = h1;
    //                        dtMarks.Rows[i]["h1Total"] = Convert.ToString(h1);
    //                        dtMarks.Rows[i]["h1_grace"] = "";
    //                        dtMarks.Rows[i]["remark"] = "Successful";
    //                    }
    //                    else
    //                    {
    //                        bool res = false;
    //                        if (h1Res != 0)
    //                        {
    //                            h1 = addResolution(h1, h1Pass, h1Res);
    //                            if (h1 >= h1Pass)
    //                            {
    //                                h1Copy = h1;
    //                                dtMarks.Rows[i]["h1Total"] = Convert.ToString(h1);
    //                                dtMarks.Rows[i]["h1_grace"] = (h1Pass - Convert.ToInt32(dtMarks.Rows[i]["h1"])) + "^";
    //                                dtMarks.Rows[i]["remark"] = "Successful";
    //                                res = true;
    //                            }
    //                        }

    //                        if (res == false && abFlag == false)
    //                        {
    //                            if (quotaGrc > 0 && FailGrc == false)
    //                            {
    //                                int h1New;
    //                                h1New = h1 + quotaGrc;

    //                                if (h1New >= h1Pass)
    //                                {
    //                                    addGrace = true;
    //                                    dtMarks.Rows[i]["h1Total"] = Convert.ToString(h1Pass);
    //                                    dtGrcH1 = h1Pass - (h1);
    //                                    quotaGrc = quotaGrc - dtGrcH1;
    //                                    dtMarks.Rows[i]["h1_grace"] = Convert.ToString(dtGrcH1) + "*";
    //                                    dtMarks.Rows[i]["remark"] = "Successful";
    //                                }
    //                                else
    //                                {
    //                                    FailGrc = true;
    //                                    dtMarks.Rows[i]["h1Total"] = Convert.ToString(h1);
    //                                    dtMarks.Rows[i]["h1_grace"] = "";
    //                                    dtMarks.Rows[i]["remark"] = "UnSuccessful";
    //                                }
    //                            }
    //                            else
    //                            {
    //                                FailGrc = true;
    //                                dtMarks.Rows[i]["h1Total"] = Convert.ToString(h1);
    //                                dtMarks.Rows[i]["h1_grace"] = "";
    //                                dtMarks.Rows[i]["remark"] = "UnSuccessful";
    //                            }

    //                            if (FailGrc == true && addGrace == true)
    //                            {
    //                                query = "";
    //                                for (int j = 0; j < i; j++)
    //                                {
    //                                    if (!string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[j]["h1_grace"])) && Convert.ToString(dtMarks.Rows[j]["h1_grace"]).Contains("*"))
    //                                    {
    //                                        dtMarks.Rows[j]["h1_grace"] = "";
    //                                        dtMarks.Rows[j]["h1Total"] = dtMarks.Rows[j]["h1"];
    //                                        dtMarks.Rows[j]["remark"] = "UnSuccessful";
    //                                    }
    //                                    if (!string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[j]["h2_grace"])) && Convert.ToString(dtMarks.Rows[j]["h2_grace"]).Contains("*"))
    //                                    {
    //                                        dtMarks.Rows[j]["h2_grace"] = "";
    //                                        dtMarks.Rows[j]["h2Total"] = dtMarks.Rows[j]["h2"];
    //                                        dtMarks.Rows[j]["remark"] = "UnSuccessful";
    //                                    }
    //                                    query += "update cre_marks_tbl set h1_grace='" + dtMarks.Rows[j]["h1_grace"] + "',h2_grace='" + dtMarks.Rows[j]["h2_grace"] + "',mod_date=getDate(),remark='" + dtMarks.Rows[j]["remark"] + "' where stud_id='" + dtMarks.Rows[j]["stud_id"] + "' and subject_id='" + dtMarks.Rows[j]["subject_id"] + "'and credit_sub_id='" + dtMarks.Rows[j]["credit_sub_id"] + "' and exam_code='" + dtMarks.Rows[j]["exam_code"] + "' and del_flag=0 ";
    //                                }

    //                                dtMarks.Rows[i]["h1Total"] = Convert.ToString(h1);
    //                                dtMarks.Rows[i]["h1_grace"] = "";
    //                                dtMarks.Rows[i]["remark"] = "UnSuccessful";
    //                            }
    //                        }
    //                    }
    //                }
    //            }
    //            else if (string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[i]["h1_out"])))
    //            {
    //                h1Blnk = true;
    //            }
    //            //----------------------------------------------------------@@@@@@@@@@    H2    @@@@@@@@@@@@-----------------------------------------------------

    //            int dtGrcH2 = Convert.ToInt32(dtMarks.Rows[i]["h2_grace42"]);
    //            if (!string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[i]["h2"]).Trim()) && !string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[i]["h2_out"])))
    //            {

    //                if (Convert.ToString(dtMarks.Rows[i]["h2"]).Contains("+"))
    //                {
    //                    dtMarks.Rows[i]["h2"] = Convert.ToString(dtMarks.Rows[i]["h2"]).Substring(0, Convert.ToString(dtMarks.Rows[i]["h2"]).IndexOf('+'));
    //                }

    //                if (Convert.ToString(dtMarks.Rows[i]["h2"]) == "Ab")
    //                {
    //                    dtMarks.Rows[i]["remark"] = "UnSuccessful";
    //                    FailGrc = true;
    //                    if (FailGrc == true && addGrace == true)
    //                    {
    //                        query = "";
    //                        for (int j = 0; j < i; j++)
    //                        {
    //                            if (!string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[j]["h1_grace"])) && Convert.ToString(dtMarks.Rows[j]["h1_grace"]).Contains("*"))
    //                            {
    //                                dtMarks.Rows[j]["h1_grace"] = "";
    //                                dtMarks.Rows[j]["h1Total"] = dtMarks.Rows[j]["h1"];
    //                                dtMarks.Rows[j]["remark"] = "UnSuccessful";
    //                            }
    //                            if (!string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[j]["h2_grace"])) && Convert.ToString(dtMarks.Rows[j]["h2_grace"]).Contains("*"))
    //                            {
    //                                dtMarks.Rows[j]["h2_grace"] = "";
    //                                dtMarks.Rows[j]["h2Total"] = dtMarks.Rows[j]["h2"];
    //                                dtMarks.Rows[j]["remark"] = "UnSuccessful";
    //                            }
    //                            query += "update cre_marks_tbl set h1_grace='" + dtMarks.Rows[j]["h1_grace"] + "',h2_grace='" + dtMarks.Rows[j]["h2_grace"] + "',mod_date=getDate(),remark='" + dtMarks.Rows[j]["remark"] + "' where stud_id='" + dtMarks.Rows[j]["stud_id"] + "' and subject_id='" + dtMarks.Rows[j]["subject_id"] + "'and credit_sub_id='" + dtMarks.Rows[j]["credit_sub_id"] + "' and exam_code='" + dtMarks.Rows[j]["exam_code"] + "' and del_flag=0 ";
    //                        }
    //                        dtMarks.Rows[i]["h2_grace"] = "";
    //                        dtMarks.Rows[i]["h2Total"] = dtMarks.Rows[i]["h2"];
    //                        dtMarks.Rows[i]["remark"] = "UnSuccessful";
    //                    }
    //                }
    //                else
    //                {
    //                    int h2 = Convert.ToInt32(dtMarks.Rows[i]["h2"]), h2Pass = Convert.ToInt32(dtMarks.Rows[i]["h2_pass"]), h2Res = Convert.ToInt32(dtMarks.Rows[i]["h2_resolution"]);
    //                    H2outOf = Convert.ToInt32(dtMarks.Rows[i]["h2_out"]);

    //                    if (h2 >= h2Pass)
    //                    {
    //                        dtMarks.Rows[i]["h2Total"] = Convert.ToString(h2);
    //                        dtMarks.Rows[i]["h2_grace"] = "";
    //                        if (string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[i]["h1_out"])) || dtMarks.Rows[i]["remark"].ToString() == "Successful")
    //                            dtMarks.Rows[i]["remark"] = "Successful";
    //                    }
    //                    else
    //                    {
    //                        bool res = false;
    //                        if (h2Res != 0)
    //                        {
    //                            h2 = addResolution(h2, h2Pass, h2Res);
    //                            if (h2 >= h2Pass)
    //                            {
    //                                res = true;
    //                                dtMarks.Rows[i]["h2Total"] = Convert.ToString(h2);
    //                                dtMarks.Rows[i]["h2_grace"] = (h2Pass - Convert.ToInt32(dtMarks.Rows[i]["h2"])) + "^";
    //                                if (string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[i]["h1_out"])) || dtMarks.Rows[i]["remark"].ToString() == "Successful")
    //                                    dtMarks.Rows[i]["remark"] = "Successful";
    //                            }
    //                        }

    //                        if (res == false && abFlag == false)
    //                        {
    //                            if (H1outOf != 0)
    //                            {
    //                                TotPercent = ((h1Copy + h2) * 100) / (H1outOf + H2outOf);
    //                                if (TotPercent >= 50)
    //                                {
    //                                    dtMarks.Rows[i]["h2Total"] = Convert.ToString(h2);
    //                                    dtMarks.Rows[i]["h2_grace"] = "";
    //                                    dtMarks.Rows[i]["remark"] = "Successful";
    //                                    over50Flag = true;
    //                                }
    //                            }
    //                            if (over50Flag == false)
    //                            {
    //                                if (quotaGrc > 0 && FailGrc == false)
    //                                {
    //                                    int h1New;
    //                                    h1New = h2 + quotaGrc;

    //                                    if (h1New >= h2Pass)
    //                                    {
    //                                        addGrace = true;
    //                                        dtMarks.Rows[i]["h2Total"] = Convert.ToString(h2Pass);
    //                                        dtGrcH2 = h2Pass - (h2);
    //                                        quotaGrc = quotaGrc - dtGrcH2;
    //                                        dtMarks.Rows[i]["h2_grace"] = Convert.ToString(dtGrcH2) + "*";
    //                                        if (string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[i]["h1_out"])) || Convert.ToString(dtMarks.Rows[i]["remark"]) == "Successful")
    //                                            dtMarks.Rows[i]["remark"] = "Successful";
    //                                    }
    //                                    else
    //                                    {
    //                                        FailGrc = true;
    //                                        dtMarks.Rows[i]["h2Total"] = Convert.ToString(h2);
    //                                        dtMarks.Rows[i]["h2_grace"] = "";
    //                                        dtMarks.Rows[i]["remark"] = "UnSuccessful";
    //                                    }
    //                                }
    //                                else
    //                                {
    //                                    FailGrc = true;
    //                                    dtMarks.Rows[i]["h2Total"] = Convert.ToString(h2);
    //                                    dtMarks.Rows[i]["h2_grace"] = "";
    //                                    dtMarks.Rows[i]["remark"] = "UnSuccessful";
    //                                }

    //                                if (FailGrc == true && addGrace == true)
    //                                {
    //                                    query = "";
    //                                    for (int j = 0; j < i; j++)
    //                                    {
    //                                        if (!string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[j]["h1_grace"])) && Convert.ToString(dtMarks.Rows[j]["h1_grace"]).Contains("*"))
    //                                        {
    //                                            dtMarks.Rows[j]["h1_grace"] = "";
    //                                            dtMarks.Rows[j]["h1Total"] = dtMarks.Rows[j]["h1"];
    //                                            dtMarks.Rows[j]["remark"] = "UnSuccessful";
    //                                        }
    //                                        if (!string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[j]["h2_grace"])) && Convert.ToString(dtMarks.Rows[j]["h2_grace"]).Contains("*"))
    //                                        {
    //                                            dtMarks.Rows[j]["h2_grace"] = "";
    //                                            dtMarks.Rows[j]["h2Total"] = dtMarks.Rows[j]["h2"];
    //                                            dtMarks.Rows[j]["remark"] = "UnSuccessful";
    //                                        }
    //                                        query += "update cre_marks_tbl set h1_grace='" + dtMarks.Rows[j]["h1_grace"] + "',h2_grace='" + dtMarks.Rows[j]["h2_grace"] + "',mod_date=getDate(),remark='" + dtMarks.Rows[j]["remark"] + "' where stud_id='" + dtMarks.Rows[j]["stud_id"] + "' and subject_id='" + dtMarks.Rows[j]["subject_id"] + "'and credit_sub_id='" + dtMarks.Rows[j]["credit_sub_id"] + "' and exam_code='" + dtMarks.Rows[j]["exam_code"] + "' and del_flag=0 ";
    //                                    }
    //                                    dtMarks.Rows[i]["h2_grace"] = "";
    //                                    dtMarks.Rows[i]["h2Total"] = dtMarks.Rows[i]["h2"];
    //                                    dtMarks.Rows[i]["remark"] = "UnSuccessful";
    //                                }
    //                            }

    //                        }
    //                    }
    //                }

    //            }
    //            else if (string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[i]["h2_out"])))
    //            {
    //                if (h1Blnk == true)
    //                {
    //                    blankMrk++;
    //                }
    //            }
    //            if (blankMrk == dtMarks.Rows.Count)
    //            {
    //                return false;
    //            }
    //            query += "update cre_marks_tbl set h1_grace='" + dtMarks.Rows[i]["h1_grace"] + "',h2_grace='" + dtMarks.Rows[i]["h2_grace"] + "',mod_date=getDate(),remark='" + dtMarks.Rows[i]["remark"] + "' where stud_id='" + dtMarks.Rows[i]["stud_id"] + "' and subject_id='" + dtMarks.Rows[i]["subject_id"] + "'and credit_sub_id='" + dtMarks.Rows[i]["credit_sub_id"] + "' and exam_code='" + dtMarks.Rows[i]["exam_code"] + "' and del_flag=0 ";
    //        }
    //    }







    //    //
    //    ///////////////////////////////==============================For adding @ Grace==========================================================
    //    //

    //    if (ktCnt > 1 && quota != "LD")
    //    {
    //        bool GrcFlag = true, afterGrc = false;
    //        bool FailGrc = false, addGrace = false;
    //        for (int i = 0; i < dtMarks.Rows.Count; i++)
    //        {
    //            //if (dtMarks.Rows[i]["stud_id"].ToString() == "16734032")
    //            //{

    //            //}
    //            bool abFlag = false;
    //            string sub_ID = dtMarks.Rows[i]["subject_id"].ToString();

    //            if (dtAb.Rows.Count > 0)
    //            {
    //                for (int x = 0; x < dtAb.Rows.Count; x++)
    //                {
    //                    if (sub_ID == dtAb.Rows[x]["subject_id"].ToString())
    //                    {
    //                        abFlag = true;
    //                        break;
    //                    }
    //                }
    //            }

    //            bool h1Blnk = false, h2Blnk = false, over50Flag = false;
    //            int TotPercent = 0, h1Copy = 0, H1outOf = 0, H2outOf = 0;
    //            //----------------------------------------------------@@@@@@@@   H1   @@@@@@@@@@------------------------------------------------------------
    //            int dtGrcH1 = Convert.ToInt32(dtMarks.Rows[i]["h1_grace42"]);
    //            if (!string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[i]["h1"]).Trim()) && !string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[i]["h1_out"])))
    //            {
    //                if (Convert.ToString(dtMarks.Rows[i]["h1"]).Contains("+"))
    //                {
    //                    dtMarks.Rows[i]["h1"] = Convert.ToString(dtMarks.Rows[i]["h1"]).Substring(0, Convert.ToString(dtMarks.Rows[i]["h1"]).IndexOf('+'));
    //                }

    //                if (Convert.ToString(dtMarks.Rows[i]["h1"]) == "Ab")
    //                {
    //                    dtMarks.Rows[i]["remark"] = "UnSuccessful";
    //                    FailGrc = true;
    //                    if (FailGrc == true && addGrace == true)
    //                    {
    //                        query = "";
    //                        for (int j = 0; j < i; j++)
    //                        {
    //                            if (!string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[j]["h1_grace"])) && Convert.ToString(dtMarks.Rows[j]["h1_grace"]).Contains("@"))
    //                            {
    //                                dtMarks.Rows[j]["h1_grace"] = "";
    //                                dtMarks.Rows[j]["h1Total"] = dtMarks.Rows[j]["h1"];
    //                                dtMarks.Rows[j]["remark"] = "UnSuccessful";
    //                            }
    //                            if (!string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[j]["h2_grace"])) && Convert.ToString(dtMarks.Rows[j]["h2_grace"]).Contains("@"))
    //                            {
    //                                dtMarks.Rows[j]["h2_grace"] = "";
    //                                dtMarks.Rows[j]["h2Total"] = dtMarks.Rows[j]["h2"];
    //                                dtMarks.Rows[j]["remark"] = "UnSuccessful";
    //                            }
    //                            query += "update cre_marks_tbl set h1_grace='" + dtMarks.Rows[j]["h1_grace"] + "',h2_grace='" + dtMarks.Rows[j]["h2_grace"] + "',mod_date=getDate(),remark='" + dtMarks.Rows[j]["remark"] + "' where stud_id='" + dtMarks.Rows[j]["stud_id"] + "' and subject_id='" + dtMarks.Rows[j]["subject_id"] + "'and credit_sub_id='" + dtMarks.Rows[j]["credit_sub_id"] + "' and exam_code='" + dtMarks.Rows[j]["exam_code"] + "' and del_flag=0 ";
    //                        }

    //                        dtMarks.Rows[i]["h1Total"] = dtMarks.Rows[i]["h1"];
    //                        dtMarks.Rows[i]["h1_grace"] = "";
    //                        dtMarks.Rows[i]["remark"] = "UnSuccessful";
    //                    }
    //                }
    //                else
    //                {
    //                    int h1 = Convert.ToInt32(dtMarks.Rows[i]["h1"]), h1Pass = Convert.ToInt32(dtMarks.Rows[i]["h1_pass"]), h1Res = Convert.ToInt32(dtMarks.Rows[i]["h1_resolution"]);
    //                    H1outOf = Convert.ToInt32(dtMarks.Rows[i]["h1_out"]);
    //                    if (h1 >= h1Pass)
    //                    {
    //                        h1Copy = h1;
    //                        dtMarks.Rows[i]["h1Total"] = Convert.ToString(h1);
    //                        dtMarks.Rows[i]["h1_grace"] = "";
    //                        dtMarks.Rows[i]["remark"] = "Successful";
    //                    }
    //                    else
    //                    {
    //                        bool res = false;
    //                        if (h1Res != 0)
    //                        {
    //                            h1 = addResolution(h1, h1Pass, h1Res);
    //                            if (h1 >= h1Pass)
    //                            {
    //                                dtMarks.Rows[i]["h1Total"] = Convert.ToString(h1);
    //                                dtMarks.Rows[i]["h1_grace"] = (h1Pass - Convert.ToInt32(dtMarks.Rows[i]["h1"])) + "^";
    //                                dtMarks.Rows[i]["remark"] = "Successful";
    //                                res = true;
    //                            }
    //                        }

    //                        if (res == false && abFlag == false)
    //                        {
    //                            if (grcMrk > 0 && FailGrc == false)
    //                            {
    //                                int h1New;
    //                                if (dtGrcH1 <= grcMrk)
    //                                    h1New = h1 + dtGrcH1;
    //                                else
    //                                    h1New = h1;

    //                                if (h1New >= h1Pass)
    //                                {
    //                                    addGrace = true;
    //                                    dtMarks.Rows[i]["h1Total"] = Convert.ToString(h1Pass);
    //                                    dtGrcH1 = h1Pass - (h1);
    //                                    grcMrk = grcMrk - dtGrcH1;
    //                                    dtMarks.Rows[i]["h1_grace"] = Convert.ToString(dtGrcH1) + "@";
    //                                    dtMarks.Rows[i]["remark"] = "Successful";
    //                                }
    //                                else
    //                                {
    //                                    FailGrc = true;
    //                                    dtMarks.Rows[i]["h1Total"] = Convert.ToString(h1);
    //                                    dtMarks.Rows[i]["h1_grace"] = "";
    //                                    dtMarks.Rows[i]["remark"] = "UnSuccessful";
    //                                }
    //                            }
    //                            else
    //                            {
    //                                FailGrc = true;
    //                                dtMarks.Rows[i]["h1Total"] = Convert.ToString(h1);
    //                                dtMarks.Rows[i]["h1_grace"] = "";
    //                                dtMarks.Rows[i]["remark"] = "UnSuccessful";
    //                            }

    //                            if (FailGrc == true && addGrace == true)
    //                            {
    //                                query = "";
    //                                for (int j = 0; j < i; j++)
    //                                {
    //                                    if (!string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[j]["h1_grace"])) && Convert.ToString(dtMarks.Rows[j]["h1_grace"]).Contains("@"))
    //                                    {
    //                                        dtMarks.Rows[j]["h1_grace"] = "";
    //                                        dtMarks.Rows[j]["h1Total"] = dtMarks.Rows[j]["h1"];
    //                                        dtMarks.Rows[j]["remark"] = "UnSuccessful";
    //                                    }
    //                                    if (!string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[j]["h2_grace"])) && Convert.ToString(dtMarks.Rows[j]["h2_grace"]).Contains("@"))
    //                                    {
    //                                        dtMarks.Rows[j]["h2_grace"] = "";
    //                                        dtMarks.Rows[j]["h2Total"] = dtMarks.Rows[j]["h2"];
    //                                        dtMarks.Rows[j]["remark"] = "UnSuccessful";
    //                                    }
    //                                    query += "update cre_marks_tbl set h1_grace='" + dtMarks.Rows[j]["h1_grace"] + "',h2_grace='" + dtMarks.Rows[j]["h2_grace"] + "',mod_date=getDate(),remark='" + dtMarks.Rows[j]["remark"] + "' where stud_id='" + dtMarks.Rows[j]["stud_id"] + "' and subject_id='" + dtMarks.Rows[j]["subject_id"] + "'and credit_sub_id='" + dtMarks.Rows[j]["credit_sub_id"] + "' and exam_code='" + dtMarks.Rows[j]["exam_code"] + "' and del_flag=0 ";
    //                                }

    //                                dtMarks.Rows[i]["h1Total"] = Convert.ToString(h1);
    //                                dtMarks.Rows[i]["h1_grace"] = "";
    //                                dtMarks.Rows[i]["remark"] = "UnSuccessful";
    //                            }
    //                        }
    //                    }
    //                }
    //            }
    //            else if (string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[i]["h1_out"])))
    //            {
    //                h1Blnk = true;
    //            }
    //            //----------------------------------------------------------@@@@@@@@@@    H2    @@@@@@@@@@@@-----------------------------------------------------

    //            int dtGrcH2 = Convert.ToInt32(dtMarks.Rows[i]["h2_grace42"]);
    //            if (!string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[i]["h2"]).Trim()) && !string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[i]["h2_out"])))
    //            {
    //                if (Convert.ToString(dtMarks.Rows[i]["h2"]).Contains("+"))
    //                {
    //                    dtMarks.Rows[i]["h2"] = Convert.ToString(dtMarks.Rows[i]["h2"]).Substring(0, Convert.ToString(dtMarks.Rows[i]["h2"]).IndexOf('+'));
    //                }

    //                if (Convert.ToString(dtMarks.Rows[i]["h2"]) == "Ab")
    //                {
    //                    dtMarks.Rows[i]["remark"] = "UnSuccessful";
    //                    FailGrc = true;
    //                    if (FailGrc == true && addGrace == true)
    //                    {
    //                        query = "";
    //                        for (int j = 0; j < i; j++)
    //                        {
    //                            if (!string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[j]["h1_grace"])) && Convert.ToString(dtMarks.Rows[j]["h1_grace"]).Contains("@"))
    //                            {
    //                                dtMarks.Rows[j]["h1_grace"] = "";
    //                                dtMarks.Rows[j]["h1Total"] = dtMarks.Rows[j]["h1"];
    //                                dtMarks.Rows[j]["remark"] = "UnSuccessful";
    //                            }
    //                            if (!string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[j]["h2_grace"])) && Convert.ToString(dtMarks.Rows[j]["h2_grace"]).Contains("@"))
    //                            {
    //                                dtMarks.Rows[j]["h2_grace"] = "";
    //                                dtMarks.Rows[j]["h2Total"] = dtMarks.Rows[j]["h2"];
    //                                dtMarks.Rows[j]["remark"] = "UnSuccessful";
    //                            }

    //                            query += "update cre_marks_tbl set h1_grace='" + dtMarks.Rows[j]["h1_grace"] + "',h2_grace='" + dtMarks.Rows[j]["h2_grace"] + "',mod_date=getDate(),remark='" + dtMarks.Rows[j]["remark"] + "' where stud_id='" + dtMarks.Rows[j]["stud_id"] + "' and subject_id='" + dtMarks.Rows[j]["subject_id"] + "'and credit_sub_id='" + dtMarks.Rows[j]["credit_sub_id"] + "' and exam_code='" + dtMarks.Rows[j]["exam_code"] + "' and del_flag=0 ";
    //                        }
    //                        dtMarks.Rows[i]["h2_grace"] = "";
    //                        dtMarks.Rows[i]["h2Total"] = dtMarks.Rows[i]["h2"];
    //                        dtMarks.Rows[i]["remark"] = "UnSuccessful";
    //                    }
    //                }
    //                else
    //                {
    //                    int h2 = Convert.ToInt32(dtMarks.Rows[i]["h2"]), h2Pass = Convert.ToInt32(dtMarks.Rows[i]["h2_pass"]), h2Res = Convert.ToInt32(dtMarks.Rows[i]["h2_resolution"]);
    //                    H2outOf = Convert.ToInt32(dtMarks.Rows[i]["h2_out"]);

    //                    if (h2 >= h2Pass)
    //                    {
    //                        dtMarks.Rows[i]["h2Total"] = Convert.ToString(h2);
    //                        dtMarks.Rows[i]["h2_grace"] = "";
    //                        if (string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[i]["h1_out"])) || dtMarks.Rows[i]["remark"].ToString() == "Successful")
    //                            dtMarks.Rows[i]["remark"] = "Successful";
    //                    }
    //                    else
    //                    {
    //                        bool res = false;
    //                        if (h2Res != 0)
    //                        {
    //                            h2 = addResolution(h2, h2Pass, h2Res);
    //                            if (h2 >= h2Pass)
    //                            {
    //                                res = true;
    //                                dtMarks.Rows[i]["h2Total"] = Convert.ToString(h2);
    //                                dtMarks.Rows[i]["h2_grace"] = (h2Pass - Convert.ToInt32(dtMarks.Rows[i]["h2"])) + "^";
    //                                if (string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[i]["h1_out"])) || dtMarks.Rows[i]["remark"].ToString() == "Successful")
    //                                    dtMarks.Rows[i]["remark"] = "Successful";
    //                            }
    //                        }

    //                        if (res == false && abFlag == false)
    //                        {
    //                            if (H1outOf != 0)
    //                            {
    //                                TotPercent = ((h1Copy + h2) * 100) / (H1outOf + H2outOf);
    //                                if (TotPercent >= 50)
    //                                {
    //                                    dtMarks.Rows[i]["h2Total"] = Convert.ToString(h2);
    //                                    dtMarks.Rows[i]["h2_grace"] = "";
    //                                    dtMarks.Rows[i]["remark"] = "Successful";
    //                                    over50Flag = true;
    //                                }
    //                            }
    //                            if (over50Flag == false)
    //                            {
    //                                if (grcMrk > 0 && FailGrc == false)
    //                                {
    //                                    int h1New;
    //                                    if (dtGrcH2 <= grcMrk)
    //                                        h1New = h2 + h2Res + dtGrcH2;
    //                                    else
    //                                        h1New = h2;

    //                                    if (h1New >= h2Pass)
    //                                    {
    //                                        addGrace = true;
    //                                        dtMarks.Rows[i]["h2Total"] = Convert.ToString(h2Pass);
    //                                        dtGrcH2 = h2Pass - (h2);
    //                                        grcMrk = grcMrk - dtGrcH2;
    //                                        dtMarks.Rows[i]["h2_grace"] = Convert.ToString(dtGrcH2) + "@";
    //                                        if (string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[i]["h1_out"])) || Convert.ToString(dtMarks.Rows[i]["remark"]) == "Successful")
    //                                            dtMarks.Rows[i]["remark"] = "Successful";
    //                                    }
    //                                    else
    //                                    {
    //                                        FailGrc = true;
    //                                        dtMarks.Rows[i]["h2Total"] = Convert.ToString(h2);
    //                                        dtMarks.Rows[i]["h2_grace"] = "";
    //                                        dtMarks.Rows[i]["remark"] = "UnSuccessful";
    //                                    }
    //                                }
    //                                else
    //                                {
    //                                    FailGrc = true;
    //                                    dtMarks.Rows[i]["h2Total"] = Convert.ToString(h2);
    //                                    dtMarks.Rows[i]["h2_grace"] = "";
    //                                    dtMarks.Rows[i]["remark"] = "UnSuccessful";
    //                                }

    //                                if (FailGrc == true && addGrace == true)
    //                                {
    //                                    query = "";
    //                                    for (int j = 0; j < i; j++)
    //                                    {
    //                                        if (!string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[j]["h1_grace"])) && Convert.ToString(dtMarks.Rows[j]["h1_grace"]).Contains("@"))
    //                                        {
    //                                            dtMarks.Rows[j]["h1_grace"] = "";
    //                                            dtMarks.Rows[j]["h1Total"] = dtMarks.Rows[j]["h1"];
    //                                            dtMarks.Rows[j]["remark"] = "UnSuccessful";
    //                                        }
    //                                        if (!string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[j]["h2_grace"])) && Convert.ToString(dtMarks.Rows[j]["h2_grace"]).Contains("@"))
    //                                        {
    //                                            dtMarks.Rows[j]["h2_grace"] = "";
    //                                            dtMarks.Rows[j]["h2Total"] = dtMarks.Rows[j]["h2"];
    //                                            dtMarks.Rows[j]["remark"] = "UnSuccessful";
    //                                        }
    //                                        query += "update cre_marks_tbl set h1_grace='" + dtMarks.Rows[j]["h1_grace"] + "',h2_grace='" + dtMarks.Rows[j]["h2_grace"] + "',mod_date=getDate(),remark='" + dtMarks.Rows[j]["remark"] + "' where stud_id='" + dtMarks.Rows[j]["stud_id"] + "' and subject_id='" + dtMarks.Rows[j]["subject_id"] + "'and credit_sub_id='" + dtMarks.Rows[j]["credit_sub_id"] + "' and exam_code='" + dtMarks.Rows[j]["exam_code"] + "' and del_flag=0 ";
    //                                    }
    //                                    dtMarks.Rows[i]["h2_grace"] = "";
    //                                    dtMarks.Rows[i]["h2Total"] = dtMarks.Rows[i]["h2"];
    //                                    dtMarks.Rows[i]["remark"] = "UnSuccessful";
    //                                }
    //                            }

    //                        }
    //                    }
    //                }

    //            }
    //            else if (string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[i]["h2_out"])))
    //            {
    //                if (h1Blnk == true)
    //                {
    //                    blankMrk++;
    //                }
    //            }
    //            if (blankMrk == dtMarks.Rows.Count)
    //            {
    //                return false;
    //            }
    //            query += "update cre_marks_tbl set h1_grace='" + dtMarks.Rows[i]["h1_grace"] + "',h2_grace='" + dtMarks.Rows[i]["h2_grace"] + "',mod_date=getDate(),remark='" + dtMarks.Rows[i]["remark"] + "' where stud_id='" + dtMarks.Rows[i]["stud_id"] + "' and subject_id='" + dtMarks.Rows[i]["subject_id"] + "'and credit_sub_id='" + dtMarks.Rows[i]["credit_sub_id"] + "' and exam_code='" + dtMarks.Rows[i]["exam_code"] + "' and del_flag=0 ";
    //        }
    //    }

    //    //
    //    ///////////////////////////////==============================For adding RESOLUTION ==========================================================
    //    //

    //    if (ktCnt == 0)
    //    {
    //        bool FailGrc = false;
    //        for (int i = 0; i < dtMarks.Rows.Count; i++)
    //        {
    //            bool h1Blnk = false, h2Blnk = false;
    //            int TotPercent = 0, h1Copy = 0, H1outOf = 0, H2outOf = 0;
    //            //------------------------------------------------@@@@@@@@@@    H1   @@@@@@@@@@@-----------------------------------------------
    //            if (!string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[i]["h1"]).Trim()) && !string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[i]["h1_out"])))
    //            {

    //                if (Convert.ToString(dtMarks.Rows[i]["h1"]).Contains("+"))
    //                {
    //                    dtMarks.Rows[i]["h1"] = Convert.ToString(dtMarks.Rows[i]["h1"]).Substring(0, Convert.ToString(dtMarks.Rows[i]["h1"]).IndexOf('+'));
    //                }

    //                if (Convert.ToString(dtMarks.Rows[i]["h1"]) == "Ab")
    //                {
    //                    dtMarks.Rows[i]["remark"] = "UnSuccessful";
    //                }
    //                else
    //                {
    //                    int h1 = Convert.ToInt32(dtMarks.Rows[i]["h1"]), h1Pass = Convert.ToInt32(dtMarks.Rows[i]["h1_pass"]), h1Res = Convert.ToInt32(dtMarks.Rows[i]["h1_resolution"]);
    //                    H1outOf = Convert.ToInt32(dtMarks.Rows[i]["h1_out"]);

    //                    if (h1 >= h1Pass)
    //                    {
    //                        h1Copy = h1;
    //                        dtMarks.Rows[i]["h1Total"] = Convert.ToString(h1);
    //                        dtMarks.Rows[i]["h1_grace"] = "";
    //                        dtMarks.Rows[i]["remark"] = "Successful";
    //                    }
    //                    else
    //                    {
    //                        bool res = false;
    //                        if (h1Res != 0)
    //                        {
    //                            h1 = addResolution(h1, h1Pass, h1Res);
    //                            if (h1 >= h1Pass)
    //                            {
    //                                res = true;
    //                                h1Copy = h1;
    //                                dtMarks.Rows[i]["h1Total"] = Convert.ToString(h1);
    //                                dtMarks.Rows[i]["h1_grace"] = (h1Pass - Convert.ToInt32(dtMarks.Rows[i]["h1"])) + "^";
    //                                dtMarks.Rows[i]["remark"] = "Successful";
    //                            }
    //                        }

    //                        if (res == false)
    //                        {
    //                            dtMarks.Rows[i]["h1Total"] = Convert.ToString(h1);
    //                            dtMarks.Rows[i]["h1_grace"] = "";
    //                            dtMarks.Rows[i]["remark"] = "UnSuccessful";
    //                        }
    //                    }
    //                }
    //            }
    //            else if (string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[i]["h1_out"])))
    //            {
    //                h1Blnk = true;
    //            }

    //            //-------------------------------------------------------@@@@@@@@@@@    h2   @@@@@@@@@@-----------------------------------------------
    //            if (!string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[i]["h2"]).Trim()) && !string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[i]["h2_out"])))
    //            {
    //                bool over50Flag = false;


    //                if (Convert.ToString(dtMarks.Rows[i]["h2"]).Contains("+"))
    //                {
    //                    dtMarks.Rows[i]["h2"] = Convert.ToString(dtMarks.Rows[i]["h2"]).Substring(0, Convert.ToString(dtMarks.Rows[i]["h2"]).IndexOf('+'));
    //                }

    //                if (Convert.ToString(dtMarks.Rows[i]["h2"]) == "Ab")
    //                {
    //                    dtMarks.Rows[i]["remark"] = "UnSuccessful";
    //                }
    //                else
    //                {
    //                    int h2 = Convert.ToInt32(dtMarks.Rows[i]["h2"]), h2Pass = Convert.ToInt32(dtMarks.Rows[i]["h2_pass"]), h2Res = Convert.ToInt32(dtMarks.Rows[i]["h2_resolution"]);
    //                    H2outOf = Convert.ToInt32(dtMarks.Rows[i]["h2_out"]);

    //                    if (h2 >= h2Pass)
    //                    {
    //                        dtMarks.Rows[i]["h2Total"] = Convert.ToString(h2);
    //                        dtMarks.Rows[i]["h2_grace"] = "";
    //                        if (string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[i]["h1_out"])) || Convert.ToString(dtMarks.Rows[i]["remark"]) == "Successful")
    //                            dtMarks.Rows[i]["remark"] = "Successful";
    //                    }
    //                    else
    //                    {
    //                        bool res = false;
    //                        if (h2Res != 0)
    //                        {
    //                            h2 = addResolution(h2, h2Pass, h2Res);
    //                            if (h2 >= h2Pass)
    //                            {
    //                                res = true;
    //                                dtMarks.Rows[i]["h2Total"] = Convert.ToString(h2);
    //                                dtMarks.Rows[i]["h2_grace"] = (h2Pass - Convert.ToInt32(dtMarks.Rows[i]["h2"])) + "^";
    //                                if (string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[i]["h1_out"])) || Convert.ToString(dtMarks.Rows[i]["remark"]) == "Successful")
    //                                    dtMarks.Rows[i]["remark"] = "Successful";

    //                            }
    //                        }
    //                        if (res == false)
    //                        {
    //                            if (H1outOf != 0)
    //                            {
    //                                TotPercent = ((h1Copy + h2) * 100) / (H1outOf + H2outOf);
    //                                if (TotPercent >= 50)
    //                                {
    //                                    dtMarks.Rows[i]["h2Total"] = Convert.ToString(h2);
    //                                    dtMarks.Rows[i]["h2_grace"] = "";
    //                                    dtMarks.Rows[i]["remark"] = "Successful";
    //                                    over50Flag = true;
    //                                }
    //                            }

    //                            if (over50Flag == false)
    //                            {
    //                                dtMarks.Rows[i]["h2Total"] = Convert.ToString(h2);
    //                                dtMarks.Rows[i]["h2_grace"] = "";
    //                                dtMarks.Rows[i]["remark"] = "UnSuccessful";
    //                            }
    //                        }
    //                    }
    //                }
    //            }
    //            else if (!string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[i]["h2_out"])))
    //            {
    //                if (h1Blnk == true)
    //                {
    //                    blankMrk++;
    //                }
    //            }


    //            if (blankMrk == dtMarks.Rows.Count)
    //            {
    //                return false;
    //            }
    //            query += "update cre_marks_tbl set h1_grace='" + dtMarks.Rows[i]["h1_grace"] + "',h2_grace='" + dtMarks.Rows[i]["h2_grace"] + "',mod_date=getDate(),remark='" + dtMarks.Rows[i]["remark"] + "' where stud_id='" + dtMarks.Rows[i]["stud_id"] + "' and subject_id='" + dtMarks.Rows[i]["subject_id"] + "'and credit_sub_id='" + dtMarks.Rows[i]["credit_sub_id"] + "' and exam_code='" + dtMarks.Rows[i]["exam_code"] + "' and del_flag=0 ";

    //        }
    //    }
    //    //================================Updating Grace=======================
    //    if (DMLqueries(query))
    //        return true;
    //    else
    //        return false;
    //}

    public int rndNum(decimal no)
    {

        decimal d2 = Convert.ToDecimal(no);
        int s1 = 0;
        if (d2.ToString().Contains("."))
        {
            string a = d2.ToString().Substring(d2.ToString().IndexOf('.') + 1);
            int a1 = Convert.ToInt32(d2.ToString().Substring(0, d2.ToString().IndexOf('.')));
            string b = "";

            if (a.Length == 1 && a != "0")
            {
                if (Convert.ToInt32(a) >= 5)
                {
                    s1 = a1 + 1;
                }
            }
        }
        if (s1 == 0)
        {
            s1 = Convert.ToInt32(d2);
        }

        return s1;
    }

    //public bool OverallResolution(DataTable dtMarks, int grcMrk, DataTable dt42, string quota, DataTable dtAb)
    //{
    //    int blankMrk = 0;
    //    string query = "";
    //    dtMarks.Columns.Add("h1Total");
    //    dtMarks.Columns.Add("h2Total");

    //    ////////for LD  4 jan 2016////////////////////////////////////               
    //    int h1New = 0;
    //    int ktCnt = 0;
    //    if (dt42.Rows.Count > 0)
    //    {
    //        ktCnt = Convert.ToInt32(dt42.Rows[0][0]);
    //    }
    //    int quotaGrc = 0;
    //    if (quota != "" && quota == "LD")
    //        quotaGrc = 20;
    //    /////////////////////////////////////////////

    //    for (int i = 0; i < dtMarks.Rows.Count; i++)
    //    {
    //        bool h1Blnk = false, h2Blnk = false;
    //        int TotPercent = 0, h1Copy = 0, H1outOf = 0, H2outOf = 0;
    //        //------------------------------------------------@@@@@@@@@@    H1   @@@@@@@@@@@-----------------------------------------------
    //        if (!string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[i]["h1"]).Trim()) && !string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[i]["h1_out"])))
    //        {
    //            if (Convert.ToString(dtMarks.Rows[i]["h1"]).Contains("+"))
    //            {
    //                dtMarks.Rows[i]["h1"] = Convert.ToString(dtMarks.Rows[i]["h1"]).Substring(0, Convert.ToString(dtMarks.Rows[i]["h1"]).IndexOf('+'));
    //            }

    //            if (Convert.ToString(dtMarks.Rows[i]["h1"]) == "Ab")
    //            {
    //                dtMarks.Rows[i]["remark"] = "UnSuccessful";
    //            }
    //            else
    //            {
    //                int h1 = Convert.ToInt32(dtMarks.Rows[i]["h1"]), h1Pass = Convert.ToInt32(dtMarks.Rows[i]["h1_pass"]), h1Res = Convert.ToInt32(dtMarks.Rows[i]["h1_resolution"]);
    //                H1outOf = Convert.ToInt32(dtMarks.Rows[i]["h1_out"]);

    //                if (h1 >= h1Pass)
    //                {
    //                    h1Copy = h1;
    //                    dtMarks.Rows[i]["h1Total"] = Convert.ToString(h1);
    //                    dtMarks.Rows[i]["h1_grace"] = "";
    //                    dtMarks.Rows[i]["remark"] = "Successful";
    //                }
    //                else
    //                {
    //                    bool res = false;
    //                    if (h1Res != 0)
    //                    {
    //                        h1 = addResolution(h1, h1Pass, h1Res);
    //                        if (h1 >= h1Pass)
    //                        {
    //                            res = true;
    //                            dtMarks.Rows[i]["h1Total"] = Convert.ToString(h1);
    //                            dtMarks.Rows[i]["h1_grace"] = (h1Pass - Convert.ToInt32(dtMarks.Rows[i]["h1"])) + "^";
    //                            dtMarks.Rows[i]["remark"] = "Successful";
    //                        }
    //                    }

    //                    if (res == false)
    //                    {
    //                        //---------------for ld  4jan2016---------------------------------
    //                        if (ktCnt == 1)
    //                        {
    //                            bool quotaFlag = false;
    //                            if (quotaGrc != 0 && quota == "LD" && quotaFlag == false)
    //                            {
    //                                h1New = h1 + quotaGrc;
    //                                if (h1New >= h1Pass)
    //                                {
    //                                    quotaFlag = true;
    //                                    dtMarks.Rows[i]["h1Total"] = Convert.ToString(h1Pass);
    //                                    quotaGrc = h1Pass - (h1);
    //                                    dtMarks.Rows[i]["h1_grace"] = Convert.ToString(quotaGrc) + "*";
    //                                    dtMarks.Rows[i]["remark"] = "Successful";
    //                                }
    //                                else
    //                                {
    //                                    dtMarks.Rows[i]["h1Total"] = Convert.ToString(h1);
    //                                    dtMarks.Rows[i]["h1_grace"] = "";
    //                                    dtMarks.Rows[i]["remark"] = "UnSuccessful";
    //                                    quotaFlag = true;
    //                                }

    //                            }

    //                            else
    //                            {
    //                                dtMarks.Rows[i]["h1Total"] = Convert.ToString(h1);
    //                                dtMarks.Rows[i]["h1_grace"] = "";
    //                                dtMarks.Rows[i]["remark"] = "UnSuccessful";
    //                            }
    //                        }
    //                        else
    //                        {
    //                            dtMarks.Rows[i]["h1Total"] = Convert.ToString(h1);
    //                            dtMarks.Rows[i]["h1_grace"] = "";
    //                            dtMarks.Rows[i]["remark"] = "UnSuccessful";
    //                        }
    //                        //-----------------------------orignal
    //                        //dtMarks.Rows[i]["h1Total"] = Convert.ToString(h1);
    //                        //dtMarks.Rows[i]["h1_grace"] = "";
    //                        //dtMarks.Rows[i]["remark"] = "UnSuccessful";
    //                    }
    //                }
    //            }
    //        }
    //        else if (string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[i]["h1_out"])))
    //        {
    //            h1Blnk = true;
    //        }

    //        //-------------------------------------------------------@@@@@@@@@@@    h2   @@@@@@@@@@-----------------------------------------------
    //        if (!string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[i]["h2"]).Trim()) && !string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[i]["h2_out"])))
    //        {
    //            bool over50Flag = false;

    //            if (Convert.ToString(dtMarks.Rows[i]["h2"]).Contains("+"))
    //            {
    //                dtMarks.Rows[i]["h2"] = Convert.ToString(dtMarks.Rows[i]["h2"]).Substring(0, Convert.ToString(dtMarks.Rows[i]["h2"]).IndexOf('+'));
    //            }

    //            if (Convert.ToString(dtMarks.Rows[i]["h2"]) == "Ab")
    //            {
    //                dtMarks.Rows[i]["remark"] = "UnSuccessful";
    //            }
    //            else
    //            {
    //                int h2 = Convert.ToInt32(dtMarks.Rows[i]["h2"]), h2Pass = Convert.ToInt32(dtMarks.Rows[i]["h2_pass"]), h2Res = Convert.ToInt32(dtMarks.Rows[i]["h2_resolution"]);
    //                H2outOf = Convert.ToInt32(dtMarks.Rows[i]["h2_out"]);

    //                if (h2 >= h2Pass)
    //                {
    //                    dtMarks.Rows[i]["h2Total"] = Convert.ToString(h2);
    //                    dtMarks.Rows[i]["h2_grace"] = "";
    //                    if (string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[i]["h1_out"])) || Convert.ToString(dtMarks.Rows[i]["remark"]) == "Successful")
    //                        dtMarks.Rows[i]["remark"] = "Successful";
    //                }
    //                else
    //                {
    //                    bool res = false;
    //                    if (h2Res != 0)
    //                    {
    //                        h2 = addResolution(h2, h2Pass, h2Res);
    //                        if (h2 >= h2Pass)
    //                        {
    //                            res = true;
    //                            dtMarks.Rows[i]["h2Total"] = Convert.ToString(h2);
    //                            dtMarks.Rows[i]["h2_grace"] = (h2Pass - Convert.ToInt32(dtMarks.Rows[i]["h2"])) + "^";
    //                            if (string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[i]["h1_out"])) || Convert.ToString(dtMarks.Rows[i]["remark"]) == "Successful")
    //                                dtMarks.Rows[i]["remark"] = "Successful";

    //                        }
    //                    }
    //                    if (res == false)
    //                    {
    //                        if (H1outOf != 0)
    //                        {
    //                            TotPercent = ((h1Copy + h2) * 100) / (H1outOf + H2outOf);
    //                            if (TotPercent >= 50)
    //                            {
    //                                dtMarks.Rows[i]["h2Total"] = Convert.ToString(h2);
    //                                dtMarks.Rows[i]["h2_grace"] = "";
    //                                dtMarks.Rows[i]["remark"] = "Successful";
    //                                over50Flag = true;
    //                            }
    //                        }

    //                        if (over50Flag == false)
    //                        {
    //                            dtMarks.Rows[i]["h2Total"] = Convert.ToString(h2);
    //                            dtMarks.Rows[i]["h2_grace"] = "";
    //                            dtMarks.Rows[i]["remark"] = "UnSuccessful";
    //                        }

    //                        //for ld-  4 jan 2016------------------------------
    //                        if (ktCnt == 1)
    //                        {
    //                            bool quotaFlag = false;
    //                            if (quotaGrc != 0 && quota == "LD" && quotaFlag == false)
    //                            {
    //                                h1New = h2 + quotaGrc;
    //                                quotaFlag = true;
    //                                if (h1New >= h2Pass)
    //                                {
    //                                    dtMarks.Rows[i]["h2Total"] = Convert.ToString(h2Pass);
    //                                    quotaGrc = h2Pass - (h2);
    //                                    dtMarks.Rows[i]["h2_grace"] = Convert.ToString(quotaGrc) + "*";
    //                                    if (string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[i]["h1_out"])) || Convert.ToString(dtMarks.Rows[i]["remark"]) == "Successful")
    //                                        dtMarks.Rows[i]["remark"] = "Successful";
    //                                }
    //                                else
    //                                {
    //                                    dtMarks.Rows[i]["h2Total"] = Convert.ToString(h2);
    //                                    dtMarks.Rows[i]["h2_grace"] = "";
    //                                    dtMarks.Rows[i]["remark"] = "UnSuccessful";
    //                                }
    //                            }
    //                        }
    //                        //--------new add 14-1-16 for !
    //                        //else if (over50Flag == true)
    //                        //{
    //                        //    dtMarks.Rows[i]["h2Total"] = Convert.ToString(h2);
    //                        //    dtMarks.Rows[i]["h2_grace"] = "";
    //                        //    dtMarks.Rows[i]["remark"] = "Successful";
    //                        //}
    //                        //    //--------
    //                        //else
    //                        //{
    //                        //    dtMarks.Rows[i]["h2Total"] = Convert.ToString(h2);
    //                        //    dtMarks.Rows[i]["h2_grace"] = "";
    //                        //    dtMarks.Rows[i]["remark"] = "UnSuccessful";

    //                        //}
    //                        //  -------//---------------------------------------------------------------







    //                    }
    //                }
    //            }
    //        }
    //        else if (!string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[i]["h2_out"])))
    //        {
    //            if (h1Blnk == true)
    //            {
    //                blankMrk++;
    //            }
    //        }


    //        if (blankMrk == dtMarks.Rows.Count)
    //        {
    //            return false;
    //        }
    //        query += "update cre_marks_tbl set h1_grace='" + dtMarks.Rows[i]["h1_grace"] + "',h2_grace='" + dtMarks.Rows[i]["h2_grace"] + "',mod_date=getDate(),remark='" + dtMarks.Rows[i]["remark"] + "' where stud_id='" + dtMarks.Rows[i]["stud_id"] + "' and subject_id='" + dtMarks.Rows[i]["subject_id"] + "'and credit_sub_id='" + dtMarks.Rows[i]["credit_sub_id"] + "' and exam_code='" + dtMarks.Rows[i]["exam_code"] + "' and del_flag=0 ";

    //    }

    //    //================================Updating Grace=======================
    //    if (DMLqueries(query))
    //        return true;
    //    else
    //        return false;
    //}

    public bool OverallResolution(DataTable dtMarks, int grcMrk, DataTable dt42, string quota, DataTable dtAb)
    {
        //bool FailGrc = false;
        int blankMrk = 0;
        string query = "";
        dtMarks.Columns.Add("h1Total");
        dtMarks.Columns.Add("h2Total");

        for (int i = 0; i < dtMarks.Rows.Count; i++)
        {
            bool h1Blnk = false, h2Blnk = false;
            int TotPercent = 0, h1Copy = 0, H1outOf = 0, H2outOf = 0;
            //------------------------------------------------@@@@@@@@@@    H1   @@@@@@@@@@@-----------------------------------------------
            if (!string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[i]["h1"]).Trim()) && !string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[i]["h1_out"])))
            {
                if (Convert.ToString(dtMarks.Rows[i]["h1"]).Contains("+"))
                {
                    dtMarks.Rows[i]["h1"] = Convert.ToString(dtMarks.Rows[i]["h1"]).Substring(0, Convert.ToString(dtMarks.Rows[i]["h1"]).IndexOf('+'));
                }

                if (Convert.ToString(dtMarks.Rows[i]["h1"]) == "Ab")
                {
                    dtMarks.Rows[i]["remark"] = "UnSuccessful";
                }
                else
                {
                    int h1 = Convert.ToInt32(dtMarks.Rows[i]["h1"]), h1Pass = Convert.ToInt32(dtMarks.Rows[i]["h1_pass"]), h1Res = Convert.ToInt32(dtMarks.Rows[i]["h1_resolution"]);
                    H1outOf = Convert.ToInt32(dtMarks.Rows[i]["h1_out"]);

                    if (h1 >= h1Pass)
                    {
                        h1Copy = h1;
                        dtMarks.Rows[i]["h1Total"] = Convert.ToString(h1);
                        dtMarks.Rows[i]["h1_grace"] = "";
                        dtMarks.Rows[i]["remark"] = "Successful";
                    }
                    else
                    {
                        bool res = false;
                        if (h1Res != 0)
                        {
                            h1 = addResolution(h1, h1Pass, h1Res);
                            if (h1 >= h1Pass)
                            {
                                res = true;
                                dtMarks.Rows[i]["h1Total"] = Convert.ToString(h1);
                                dtMarks.Rows[i]["h1_grace"] = (h1Pass - Convert.ToInt32(dtMarks.Rows[i]["h1"])) + "^";
                                dtMarks.Rows[i]["remark"] = "Successful";
                            }
                        }

                        if (res == false)
                        {
                            dtMarks.Rows[i]["h1Total"] = Convert.ToString(h1);
                            dtMarks.Rows[i]["h1_grace"] = "";
                            dtMarks.Rows[i]["remark"] = "UnSuccessful";
                        }
                    }
                }
            }
            else if (string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[i]["h1_out"])))
            {
                h1Blnk = true;
            }

            //-------------------------------------------------------@@@@@@@@@@@    h2   @@@@@@@@@@-----------------------------------------------
            if (!string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[i]["h2"]).Trim()) && !string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[i]["h2_out"])))
            {
                bool over50Flag = false;

                if (Convert.ToString(dtMarks.Rows[i]["h2"]).Contains("+"))
                {
                    dtMarks.Rows[i]["h2"] = Convert.ToString(dtMarks.Rows[i]["h2"]).Substring(0, Convert.ToString(dtMarks.Rows[i]["h2"]).IndexOf('+'));
                }

                if (Convert.ToString(dtMarks.Rows[i]["h2"]) == "Ab")
                {
                    dtMarks.Rows[i]["remark"] = "UnSuccessful";
                }
                else
                {
                    int h2 = Convert.ToInt32(dtMarks.Rows[i]["h2"]), h2Pass = Convert.ToInt32(dtMarks.Rows[i]["h2_pass"]), h2Res = Convert.ToInt32(dtMarks.Rows[i]["h2_resolution"]);
                    H2outOf = Convert.ToInt32(dtMarks.Rows[i]["h2_out"]);

                    if (h2 >= h2Pass)
                    {
                        dtMarks.Rows[i]["h2Total"] = Convert.ToString(h2);
                        dtMarks.Rows[i]["h2_grace"] = "";
                        if (string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[i]["h1_out"])) || Convert.ToString(dtMarks.Rows[i]["remark"]) == "Successful")
                            dtMarks.Rows[i]["remark"] = "Successful";
                    }
                    else
                    {
                        bool res = false;
                        if (h2Res != 0)
                        {
                            h2 = addResolution(h2, h2Pass, h2Res);
                            if (h2 >= h2Pass)
                            {
                                res = true;
                                dtMarks.Rows[i]["h2Total"] = Convert.ToString(h2);
                                dtMarks.Rows[i]["h2_grace"] = (h2Pass - Convert.ToInt32(dtMarks.Rows[i]["h2"])) + "^";
                                if (string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[i]["h1_out"])) || Convert.ToString(dtMarks.Rows[i]["remark"]) == "Successful")
                                    dtMarks.Rows[i]["remark"] = "Successful";

                            }
                        }
                        if (res == false)
                        {
                            if (H1outOf != 0)
                            {
                                TotPercent = ((h1Copy + h2) * 100) / (H1outOf + H2outOf);
                                if (TotPercent >= 50)
                                {
                                    dtMarks.Rows[i]["h2Total"] = Convert.ToString(h2);
                                    dtMarks.Rows[i]["h2_grace"] = "";
                                    dtMarks.Rows[i]["remark"] = "Successful";
                                    over50Flag = true;
                                }
                            }

                            if (over50Flag == false)
                            {
                                dtMarks.Rows[i]["h2Total"] = Convert.ToString(h2);
                                dtMarks.Rows[i]["h2_grace"] = "";
                                dtMarks.Rows[i]["remark"] = "UnSuccessful";
                            }
                        }
                    }
                }
            }
            else if (!string.IsNullOrEmpty(Convert.ToString(dtMarks.Rows[i]["h2_out"])))
            {
                if (h1Blnk == true)
                {
                    blankMrk++;
                }
            }


            if (blankMrk == dtMarks.Rows.Count)
            {
                return false;
            }
            query += "update cre_marks_tbl set h1_grace='" + dtMarks.Rows[i]["h1_grace"] + "',h2_grace='" + dtMarks.Rows[i]["h2_grace"] + "',mod_date=getDate(),remark='" + dtMarks.Rows[i]["remark"] + "' where stud_id='" + dtMarks.Rows[i]["stud_id"] + "' and subject_id='" + dtMarks.Rows[i]["subject_id"] + "'and credit_sub_id='" + dtMarks.Rows[i]["credit_sub_id"] + "' and exam_code='" + dtMarks.Rows[i]["exam_code"] + "' and del_flag=0 ";

        }

        //================================Updating Grace=======================
        if (DMLquerries(query))
            return true;
        else
            return false;
    }


    //-------LIBRARY-----//
    public bool DMLqueries_newspaper(string query, SqlConnection connect)
    {
        try
        {
            cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = connect;
            SqlConnection con = connect;
            if (con.State == ConnectionState.Open)
            {
                con.Close();
                con.Open();
            }
            else
            {
                con.Open();
            }
            if (cmd.ExecuteNonQuery() > 0)
            {
                con.Close();
                return true;

            }
            else
            {
                con.Close();
                return false;

            }
        }
        catch (Exception ex1)
        {
            return false;
        }

    }
}