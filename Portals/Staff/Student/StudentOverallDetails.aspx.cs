using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection;

public partial class Portals_Staff_Student_StudentOverallDetails : System.Web.UI.Page
{
    string ext = "";
    Class1 obj = new Class1();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string coursequery = "select course_id,del_flag,course_name from m_crs_course_tbl where del_flag='0'";
            DataTable dt1 = obj.fillDataTable(coursequery);
            ddlcourse.DataTextField = dt1.Columns["course_name"].ToString();
            ddlcourse.DataValueField = dt1.Columns["course_id"].ToString();
            ddlcourse.DataSource = dt1;
            ddlcourse.DataBind();
            ddlcourse.Items.Insert(0, new ListItem("--Select--", ""));
        }
    }
    protected void ddlcourse_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }
    protected void ddlselectFields_SelectedIndexChanged(object sender, EventArgs e)
    {
         
///        ddlselectFields.DataTextField=dt2
    }

    protected void lstreporttype_SelectedIndexChanged(object sender, EventArgs e)
    {
        string selectfields = "select 'stud_Category' as 'Fieldid','CATEGORY' as 'Text' union all select 'stud_Caste' as 'Fieldid','CASTE' as 'Text' union all select 'stud_SubCaste' as 'Fieldid','SUB-CASTE' as 'Text' union all select 'stud_Father_FName' as 'Fieldid','FATHER NAME' as 'Text' union all select 'stud_Father_TelNo' as 'Fieldid','FATHER PHONE NO' as 'Text' union all select 'stud_Mother_FName' as 'Fieldid','MOTHER NAME' as 'Text' union all  select 'stud_Mother_TelNo' as 'Fieldid','MOTHER PHONE NO' as 'Text' union all select 'stud_NativePhone' as 'Fieldid','NATIVE PHONE NO' as 'Text' union all select 'stud_Gaurd_FName' as 'Fieldid','GAURDIAN NAME' as 'Text' union all  select 'stud_Email' as 'Fieldid','STUDENT EMAIL' as 'Text' union all select 'stud_Gaurd_TelNo' as 'Fieldid','GAURDIAN PHONE NO' as 'Text' union all select 'stud_YearlyIncome' as 'Fieldid','YEARLY INCOME' as 'Text' union all select 'stud_aadhar' as 'Fieldid','AADHAR NO' as 'Text' union all  select 'stud_voterid' as 'Fieldid','VOTER ID NO' as 'Text' union all select 'dob1' as 'Fieldid','DOB' as 'Text' union all select 'stud_PermanentPhone' as 'Fieldid','STUDENT PHONE NO' as 'Text' union all select 'stud_PermanentAdd' as 'Fieldid','STUDENT ADDRESS' as 'Text'  union all select 'ID_No' as 'Fieldid','PRN NO' as 'Text' union all select 'stud_Earning' as 'Fieldid','EARNING' as 'Text' union all select 'stud_NonEarning' as 'Fieldid','NON-EARNING' as 'Text'";
        DataTable dt2 = obj.fillDataTable(selectfields);
        lstselectfields.DataTextField = dt2.Columns["Text"].ToString();
        lstselectfields.DataValueField = dt2.Columns["Fieldid"].ToString();
        lstselectfields.DataSource = dt2;
        lstselectfields.DataBind();
    }
    string test = "";
    protected void lstselectfields_SelectedIndexChanged(object sender, EventArgs e)
    {
       
     //  string[] items = (from string s in listBox1.SelectedItems select s).ToArray();
       foreach (ListItem item in lstselectfields.Items) 
       {
           //lstselectfields.SelectedItems.Cast<Object>().Select(x => lstselectfields.GetItemText(x)).ToArray();
           if (item.Selected == true) 
           {
               test=test+","+item.Value.ToString()+ " as [" +item+"]";               //string text = lstselectfields.GetItemText(lstselectfields.SelectedItem);

               //lstselectfields.SelectedItems.Cast<Object>().Select(x => lstselectfields.GetItemText(x)).ToArray();
           }
       }
        string ext = lstselectfields.SelectedItem.Value;
test=test + "," + ext;
      //  lstselectfields.Items.Insert(0, new ListItem("--select--", ""));
        
    }
    protected void btngetdata_Click(object sender, EventArgs e)
    {

        string grdquery = "select stud_id as [Student ID],  roll as [Roll No.], GENDER as Gender, stud_name as [Student Name], GROUP_TITLE as Course, stud_Category as Category " + test + " from ( select distinct a.stud_id, convert(varchar(11), stud_DOB, 103) as dob1,CASE WHEN c.remark LIKE '%,' THEN LEFT(c.remark, LEN(c.remark)-1) ELSE c.remark END as remark, CASE WHEN c.authorized_by LIKE '%,' THEN LEFT(c.authorized_by, LEN(c.authorized_by)-1 ) ELSE c.authorized_by END as authorized_by, case when ID_No is not null and ID_no like '%|%' then LEFT(ID_No, charindex('|', ID_No)-1) else ' ' end as ID_No, case when a.stud_Gender = 0 then 'Female' else 'Male' end as GENDER, isnull(a.stud_F_Name, '')+ ' ' + isnull(a.stud_m_Name, '')+ ' ' + isnull(a.stud_l_Name, '') as stud_name, b.Roll_no as roll, c.Recpt_no as rpt, c.Recpt_mode as MODE, sum(c.amount) AMOUNT,sum(d.Amount)- sum(c.Amount) as Balance, stud_SubCaste, stud_Caste, stud_Email, stud_Category, stud_NativePhone,  stud_PermanentPhone,  stud_PermanentAdd, stud_Earning, stud_NonEarning, stud_YearlyIncome, stud_F_Name, stud_m_Name, stud_l_Name, stud_Mother_FName, stud_Gaurd_TelNo, stud_Father_FName, stud_Father_TelNo, stud_Mother_TelNo, stud_Gaurd_FName, ( select group_title from m_crs_subjectgroup_tbl where b.group_id = Group_id) as GROUP_TITLE From m_std_personaldetails_tbl a, m_std_studentacademic_tbl b, m_FeeEntry c, m_FeeMaster d  where  a.stud_id = b.stud_id and b.stud_id = c.Stud_id and b.ayid = c.Ayid and c.Ayid = d.Ayid and b.group_id = d.Group_id  and c.ayid = (select max(AYID) from m_academic) and b.del_flag = c.del_flag and b.del_flag = 0 and b.subcourse_Id in (select subcourse_id from m_crs_subcourse_tbl where course_id = '" + ddlcourse.SelectedItem.Value + "') group by a.stud_id, a.stud_DOB, a.stud_Grno,  stud_Nationality,  stud_Religion,  stud_SubCaste, stud_Caste, stud_Email, stud_Category, stud_NativePhone,stud_PermanentPhone, stud_PermanentAdd, stud_Father_FName, stud_Gaurd_TelNo, stud_Father_TelNo, stud_Earning, stud_NonEarning, stud_YearlyIncome,stud_F_Name, stud_m_Name, stud_l_Name, stud_Mother_FName, stud_Mother_TelNo, stud_Gaurd_FName, stud_Gaurd_TelNo, b.ayid, a.stud_BloodGroup, convert(varchar(11), stud_DOB, 103), ID_No, c.Remark, b.group_id, c.Authorized_By, a.stud_Gender, a.stud_F_Name, a.stud_m_Name, a.stud_l_Name, b.Roll_no, c.Recpt_no, c.Recpt_mode) x order by  GROUP_TITLE,stud_name";
        DataTable dt2 = obj.fillDataTable(grdquery);
        grd.DataSource = dt2;
        grd.DataBind();
        

    }
    protected void btnexcel_Click(object sender, EventArgs e)
    {

    }
}