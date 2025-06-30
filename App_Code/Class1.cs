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
public class Class1
{
    SqlCommand cmd = new SqlCommand();
    SqlDataAdapter da;
    DataSet ds = new DataSet();

    public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);

    public Class1()
    {

    }
    //common Function 
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

    public bool DMLqueries(string query)
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
    public string DMLqueries_string(string query)
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
                return "True";

            }
            else
            {
                con.Close();
                return "False";

            }
        }
        catch (Exception ex1)
        {
            return ex1.Message;
        }

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
        Conn();
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();

        da.Fill(ds);

        con.Close();
        return ds.Tables[0];
    }
    //End Common function


    // Insert Log function Login.aspx 
    public void insertLog(string empid, string ipAddrs, string machineName, bool isLogin)
    {
        try
        {
            string insqry = "";
            if (isLogin)
            {
                insqry = "insert into dbo.web_tp_loginlog values('" + empid + "','" + ipAddrs + "','" + machineName + "',getDate(),null)";
            }
            else
            {
                insqry = "insert into dbo.web_tp_loginlog values('" + empid + "','" + ipAddrs + "','" + machineName + "',null,getDate())";
            }
            DMLqueries(insqry);
        }
        catch (Exception ex2)
        {

        }
    }
    
     //End Insert Log


    //Start ClientIP Function Login.aspx
    public string getClientIp()
    {
        string ipaddress = "";
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

    //End ClientIP function


    //GetCompleteCode Login.aspx


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
    // End GetCompleteCode


    //Start CheckLogin 
    public DataSet checkLogin(String username, String password)
    {
       
        string str = "select password,emp_id,l.role_id,r.form_name,case when l.role_id in ('5','4') then group_ids else (SELECT STUFF((SELECT ',' + group_id from m_crs_subjectgroup_tbl FOR XML PATH('')),1,1,'')) end as group_ids,l.col1,l.col2 from dbo.web_tp_login l,dbo.web_tp_roletype r where r.role_id=l.role_id and username='" + username + "' and l.del_flag=0;";
        DataSet ds_new = fillDataset(str);

        if (ds_new.Tables[0].Rows.Count > 0)
        {
            if (ds_new.Tables[0].Rows[0]["password"].ToString() == password)
            {

                str = "";
                str = "select emp_id,NAME,FATHER,SURNAME,MOTHER,DOB,DOJ,BLOOD_GROUP,GENDER,MARITIAL_STATUS,CASTE,MOBILE1,MOBILE2,EMAIL_ADDRESS,CURRENT_ADDRESS,CURRENT_STATE,CURRENT_PIN,CURRENT_DEPARTMENT_NAME,CURRENT_DESIGNATION,CATEGORY,EMAIL_ADDRESS,[PAN.NO]AS PAN_NO,PHOTO ";
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

        return ds;

    }
    //Start CheckLogin 



    // Start err_cls
    public void err_cls(string ex, string emp)
    {
        string Path = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
        System.IO.FileInfo Info = new System.IO.FileInfo(Path);
        string pageName = Info.Name;
        string qry, qrychk;
        qrychk = "Select * from  error_log where exception='" + ex.Replace("'", "''") + "' ";
        DataSet dschk = fillDataset(qrychk);
        if (dschk.Tables[0].Rows.Count > 0)
        {
            qry = "update error_log set ondate=getdate(),url='" + pageName + "' where exception='" + ex.Replace("'", "''") + "' ";
        }
        else
        {
            qry = "insert into error_log values('" + ex.Replace("'", "''") + "',getdate(),'" + pageName + "','" + emp + "',null,null,null)";
        }
        DMLqueries(qry);
    }

    //End err_cls


    // academic year


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
    // acdemic year


    //harsh
    public bool CancelAdmission(string stud_id,string ayid,string fyid,string remark ) 
    {
                bool retVal = false;
        string constr = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand("m_cancel_admission", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@student_id", SqlDbType.VarChar).Value = stud_id;
                cmd.Parameters.Add("@ayid", SqlDbType.VarChar).Value = ayid;
                cmd.Parameters.Add("@fyid", SqlDbType.VarChar).Value = fyid;
                cmd.Parameters.Add("@remark", SqlDbType.VarChar).Value = remark;
                cmd.Connection = con;
                con.Open();
                string message = Convert.ToString(cmd.ExecuteScalar());
                con.Close();

                if (message == "True")
                {
                    retVal = true;
                }
                else //error
                {
                    retVal = false;
                }
            }
     
        }
        return retVal;
    }

    /// <summary>
    /// ///for new student admissionconfirm.aspx
    /// </summary>
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
    public DataSet get_Credit_Sub_ID(string subject_ID, string ayid)
    {
        //returns list of credit _ID
        DataSet dss = new DataSet();
        string str = "select count(*) from dbo.cre_credit_tbl where subject_id='" + subject_ID + "' and del_flag=0 and ayid='" + ayid + "' select credit_sub_id from cre_credit_tbl where subject_id='" + subject_ID + "' and ayid='" + ayid + "' and del_flag=0";
        dss = fillDataset(str);
        return dss;
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
    ////////// for admissionconfirm///////////////////////////////////

        












}