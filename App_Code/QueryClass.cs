using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Text;
using System.Collections.Generic;
using Microsoft.SqlServer.Server;

/// <summary>
/// Summary description for QueryClass
/// </summary>
public class QueryClass
{
    Class1 cls = new Class1();
    //SqlCommand cmd1 = new SqlCommand();
    //SqlDataAdapter da1;
    //DataSet dss = new DataSet();
    SqlCommand cmd = new SqlCommand();
    SqlDataAdapter da;
    DataSet ds;
    DataTable dt;

    public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);


	public QueryClass()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable getgraphdate(string p1, string p2, string p3, string p4, string strdate, string enddate)
    {
        throw new NotImplementedException();
    }

    public DataTable getgraph1()
    {
        throw new NotImplementedException();
    }

    public DataTable getgraph()
    {
        throw new NotImplementedException();
    }

    public DataSet gridneft(string group_id, DropDownList ddl)
    {
        String qry = "";
        // qry = "select distinct  p.Form_no, isnull(L_name,'') + ' ' + isnull(F_Name,'') + ' ' + isnull(M_Name ,'') as std_name from d_adm_applicant as p,OLA_FY_ADM_courseSelection as b where b.group_id='" + group_id + "' and b.status='paid'  and p.form_no=b.formno and  p.Del_Flag=b.del_flag";
        //qry = "select a.form_id,upper(isnull(b.f_name,'')+' '+isnull(b.m_name,'')+' '+isnull(b.l_name,'')) as names,(select Group_title from m_crs_subjectgroup_tbl where Group_id='" + group_id + "' ) as Group_title"
        //+ " from neft_doc a,adm_applicant_entry_FY b where a.form_id=b.formno ";
        qry = "select a.form_id+replace(c.group_id,'GRP','') as formno_grp,a.form_id,upper(isnull(b.f_name,'')+' '+isnull(b.m_name,'')+' '+isnull(b.l_name,'')) as names,c.Group_title"
 + " from neft_doc a,adm_applicant_entry_FY b,m_crs_subjectgroup_tbl c where a.form_id=b.formno and a.group_id=c.Group_id and c.Group_id='" + group_id + "' and a.del_flag=0";
        DataSet dss = cls.fillDataset(qry);
        return dss;
    }

    public DataSet gridoffline(string group_id, DropDownList ddl)
    {
        String qry = "";
        // qry = "select distinct  p.Form_no, isnull(L_name,'') + ' ' + isnull(F_Name,'') + ' ' + isnull(M_Name ,'') as std_name from d_adm_applicant as p,OLA_FY_ADM_courseSelection as b where b.group_id='" + group_id + "' and b.status='paid'  and p.form_no=b.formno and  p.Del_Flag=b.del_flag";
        //qry = "select a.form_id,upper(isnull(b.f_name,'')+' '+isnull(b.m_name,'')+' '+isnull(b.l_name,'')) as names,(select Group_title from m_crs_subjectgroup_tbl where Group_id='" + group_id + "' ) as Group_title"
        //+ " from neft_doc a,adm_applicant_entry_FY b where a.form_id=b.formno ";
        qry = "select a.form_id+replace(c.group_id,'GRP','') as formno_grp,a.form_id,upper(isnull(b.f_name,'')+' '+isnull(b.m_name,'')+' '+isnull(b.l_name,'')) as names,c.Group_title"
 + " from stud_offline_receipt a,adm_applicant_entry_FY b,m_crs_subjectgroup_tbl c where a.form_id=b.formno and a.group_id=c.Group_id and c.Group_id='" + group_id + "' and a.del_flag=0";
        DataSet dss = cls.fillDataset(qry);
        return dss;
    }

    public DataTable fillroles(string  ddl)
    {
        string qry1 = "select role_name,form_name from web_tp_roletype where role_id='1' and del_flag=0";

        DataTable dt1 = cls.fillDataTable(qry1);
        return dt1;
  
    }

    //aishwarya changes for doc verify
    public void faculty(string grpIDs, DropDownList ddl)
    {
        string finalGrp = splitGrp(grpIDs);
        String qry = "select TOP 4 faculty_id,faculty_name from m_crs_faculty";
        DataSet dss = cls.fillDataset(qry);
        ddl.DataSource = dss.Tables[0];
        ddl.DataTextField = "faculty_name";
        ddl.DataValueField = "faculty_id";
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("-- Select --", "0"));
    }

    //staff
    public DataSet gridverify(string group_id, DropDownList ddl)
    {
        String qry = "";
        // qry = "select distinct  p.Form_no, isnull(L_name,'') + ' ' + isnull(F_Name,'') + ' ' + isnull(M_Name ,'') as std_name from d_adm_applicant as p,OLA_FY_ADM_courseSelection as b where b.group_id='" + group_id + "' and b.status='paid'  and p.form_no=b.formno and  p.Del_Flag=b.del_flag";
        qry = " select distinct  p.Form_no, isnull(L_name,'') + ' ' + isnull(F_Name,'') + ' ' + isnull(M_Name ,'') as std_name,p.Category,p.Caste from d_adm_applicant as p,OLA_FY_ADM_courseSelection as b where b.formno=p.Form_no and p.ACDID='" + HttpContext.Current.Session["acdyear"] + "' and b.status='paid' and b.group_id='" + HttpContext.Current.Session["Group_id"] + "' and  b.del_flag=0 and b.del_flag= p.Del_Flag and p.Is_Inhouse='" + HttpContext.Current.Session["flag"] + "'  and p.Form_no not in (select form_no from Documents_approval where ayid=p.ACDID and staff_status='approved' and group_id=b.group_id and del_flag=0 )";
        DataSet dss = cls.fillDataset(qry);
        return dss;
    }
    //Admin
    public DataSet gridverify_new(string group_id, DropDownList ddl)
    {
        String qry = "";
        // qry = "select distinct  p.Form_no, isnull(L_name,'') + ' ' + isnull(F_Name,'') + ' ' + isnull(M_Name ,'') as std_name from d_adm_applicant as p,OLA_FY_ADM_courseSelection as b where b.group_id='" + group_id + "' and b.status='paid'  and p.form_no=b.formno and  p.Del_Flag=b.del_flag";
        qry = " select distinct  p.Form_no, isnull(L_name,'') + ' ' + isnull(F_Name,'') + ' ' + isnull(M_Name ,'') as std_name,p.Category,p.Caste from d_adm_applicant as p,OLA_FY_ADM_courseSelection as b where b.formno=p.Form_no and p.ACDID='" + HttpContext.Current.Session["acdyear"] + "' and b.status='paid' and b.group_id='" + HttpContext.Current.Session["Group_id"] + "' and  b.del_flag=0 and b.del_flag= p.Del_Flag and p.Is_Inhouse='" + HttpContext.Current.Session["flag"] + "'  and p.Form_no in (select form_no from Documents_approval where ayid=p.ACDID and staff_status='approved' and group_id=b.group_id and del_flag=0) and  p.Form_no not in (select form_no from Documents_approval where ayid=p.ACDID and Admin_status='approved' and group_id=b.group_id and del_flag=0)";
        DataSet dss = cls.fillDataset(qry);
        return dss;
    }


    public void getayid(DropDownList ddl)
    {
        String qry = "select Duration , AYID from dbo.m_academic ORDER BY ayid DESC";
        DataSet dss = cls.fillDataset(qry);
        ddl.DataSource = dss.Tables[0];
        ddl.DataTextField = "Duration";
        ddl.DataValueField = "AYID";
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("-- Select --", "0"));
    }

    public void getfaculty(string grpIDs, DropDownList ddl)
    {
        string finalGrp = splitGrp(grpIDs);
        String qry = "select * from dbo.m_crs_faculty where faculty_id in (select faculty_id from m_crs_course_tbl where course_id in (select course_id from m_crs_subcourse_tbl where subcourse_id in (select subcourse_id from m_crs_subjectgroup_tbl where Group_id in(" + finalGrp + ") and del_flag=0)))";
        DataSet dss = cls.fillDataset(qry);
        ddl.DataSource = dss.Tables[0];
        ddl.DataTextField = "faculty_name";
        ddl.DataValueField = "faculty_id";
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("-- Select --", "0"));
    }

    public void getcourse(string grpIDs,string facultyID, DropDownList ddl)
    {
        string finalGrp = splitGrp(grpIDs);
        String qry = "select * from m_crs_course_tbl where course_id in (select course_id from m_crs_subcourse_tbl where subcourse_id in (select subcourse_id from m_crs_subjectgroup_tbl where Group_id in(" + finalGrp + ") and faculty_id='" + facultyID + "' ) and del_flag=0)";
        DataSet dss = cls.fillDataset(qry);
        ddl.DataSource = dss.Tables[0];
        ddl.DataTextField = "course_name";
        ddl.DataValueField = "course_id";
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("-- Select --", "0"));
    }

    public void getcourse_doc( string facultyID, DropDownList ddl)
    {        
        String qry = "select * from m_crs_course_tbl where course_id in (select course_id from m_crs_subcourse_tbl where subcourse_id in (select subcourse_id from m_crs_subjectgroup_tbl where  faculty_id='" + facultyID + "' ) and del_flag=0)";
        DataSet dss = cls.fillDataset(qry);
        ddl.DataSource = dss.Tables[0];
        ddl.DataTextField = "course_name";
        ddl.DataValueField = "course_id";
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("-- Select --", "0"));
    }

    public void getsubcourse_doc( string courseID, DropDownList ddl)
    {             
        String qry = "select * from m_crs_subcourse_tbl where course_id='" + courseID + "' and del_flag=0";
        DataSet dss = cls.fillDataset(qry);
        ddl.DataSource = dss.Tables[0];
        ddl.DataTextField = "subcourse_name";
        ddl.DataValueField = "subcourse_id";
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("-- Select --", "0"));
    }


    //for stud forms ROHIT and query-------------------------------------------------------------------------------------------------------------
    public void getcourse_new(string grpIDs, DropDownList ddl)
    {
        string finalGrp = splitGrp(grpIDs);
        String qry = "select course_name,course_id from m_Crs_course_tbl where course_name like 'BA%'";
        DataSet dss = cls.fillDataset(qry);
        ddl.DataSource = dss.Tables[0];
        ddl.DataTextField = "course_name";
        ddl.DataValueField = "course_id";
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("-- Select --", "0"));
    }

    public void getsubcourse_qry(string grpIDs, DropDownList ddl)
    {

        String qry = "select Subcourse_id,Group_id,Group_title from m_crs_subjectgroup_tbl where Subcourse_id in (select subcourse_id from m_crs_subcourse_tbl where course_id='" + grpIDs + "' )";
        DataSet dss = cls.fillDataset(qry);
        ddl.DataSource = dss.Tables[0];
        ddl.DataTextField = "Group_title";
        ddl.DataValueField = "Subcourse_id";
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("-- Select --", "0"));
    }

    public void getgroup_qry(string grpIDs, DropDownList ddl)
    {

        //String qry = "select Group_title,Group_id from m_crs_subjectgroup_tbl where Group_id='" + grpIDs + "'";
        String qry = "select Group_title,Group_id from m_crs_subjectgroup_tbl where subcourse_id='" + grpIDs + "'";
        DataSet dss = cls.fillDataset(qry);
        ddl.DataSource = dss.Tables[0];
        ddl.DataTextField = "Group_title";
        ddl.DataValueField = "Group_id";
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("-- Select --", "0"));
    }

    //------------------------------------------------------------------------------------------------------------------------------------------------


    public void getsubcourse(string grpIDs,string courseID, DropDownList ddl)
    {
        string finalGrp = splitGrp(grpIDs);
        //String qry = "select * from m_crs_subcourse_tbl where subcourse_id in (select subcourse_id from m_crs_subjectgroup_tbl where Group_id in(" + finalGrp + ") and course_id='"+courseID+"')";
        String qry = "select * from m_crs_subcourse_tbl where course_id='" + courseID + "' and del_flag=0";
        DataSet dss = cls.fillDataset(qry);
        ddl.DataSource = dss.Tables[0];
        ddl.DataTextField = "subcourse_name";
        ddl.DataValueField = "subcourse_id";
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("-- Select --", "0"));
    }
    public void role(DropDownList ddlsubCategory)
    {
        String qry = "select distinct stud_Category from m_std_personaldetails_tbl where stud_Category is not null";
        DataSet dss = cls.fillDataset(qry);
        ddlsubCategory.DataSource = dss.Tables[0];
        ddlsubCategory.DataValueField = "stud_Category";
        ddlsubCategory.DataBind();
        ddlsubCategory.Items.Insert(0, new ListItem("--select--", "0"));
        //throw new NotImplementedException();
    }

    public void getgroup(string grpIDs,string subID, DropDownList ddl)
    {
        string finalGrp = splitGrp(grpIDs);
        // String qry = "select * from m_crs_subjectgroup_tbl where Group_id in(" + finalGrp + ") and subcourse_id='"+subID+"'";
        String qry = "select * from m_crs_subjectgroup_tbl where Group_id in(" + finalGrp + ") and subcourse_id='" + subID + "' and del_flag=0";
        DataSet dss = cls.fillDataset(qry);
        ddl.DataSource = dss.Tables[0];
        ddl.DataTextField = "Group_title";
        ddl.DataValueField = "Group_id";
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("-- Select --", "0"));
    }


    public DataSet getdata(string year,string grp_title,bool flag)
    {
        String qry = "";
        if (flag == true)
        {
          //  qry = "SELECT distinct p.stud_id , isnull(stud_L_Name,'') + ' ' + isnull(stud_F_Name,'') + ' ' + isnull(stud_M_Name ,'')+' '+isnull(stud_Mother_FName ,'') as [Student Name], (case when roll_no like '%[A-Z]%' then LEFT(roll_no ,PATINDEX('%[0-9]%',roll_no )-1) else '' end),(select top(1) Univ_Enrol_no from OLA_FY_adm_CourseSelection where stud_id=p.stud_id and group_id=g.Group_id and del_flag=0) as univ_no,(select top(1) Exact_percentage from m_std_pervrecord_tbl where exam like 'H.S.C%' and stud_id=p.stud_id ) as hsc_percent , CONVERT(INT,SUBSTRING(roll_no ,PATINDEX('%[0-9]%',roll_no ),LEN(roll_no ))) as [Roll_No],case when stud_gender=0 then 'Female' else 'Male' end as Gender , stud_Category  as [Category] ,Group_title FROM dbo.m_std_studentacademic_tbl as s RIGHT JOIN dbo.m_crs_subjectgroup_tbl  as g ON s.group_id = g.Group_id right join dbo.m_std_personaldetails_tbl as p on p.stud_id = s.stud_id where s.ayid ='" + year + "'and g.group_id ='" + grp_title + "'and s.del_flag=0  ORDER BY (case when roll_no like '%[A-Z]%' then LEFT(roll_no ,PATINDEX('%[0-9]%',roll_no )-1) else '' end), CONVERT(INT,SUBSTRING(roll_no ,PATINDEX('%[0-9]%',roll_no ),LEN(roll_no )))";
            qry = "SELECT distinct p.stud_id , isnull(stud_L_Name,'') + ' ' + isnull(stud_F_Name,'') + ' ' + isnull(stud_M_Name ,'')+' '+isnull(stud_Mother_FName ,'') as [Student Name], (case when roll_no like '%[A-Z]%' then "
           + " LEFT(roll_no ,PATINDEX('%[0-9]%',roll_no )-1) else '' end),(select top(1) Univ_Enrol_no from OLA_FY_adm_CourseSelection where stud_id=p.stud_id and group_id=g.Group_id and del_flag=0) as"
  + " univ_no,(select top(1) Exact_percentage from m_std_pervrecord_tbl where exam like 'H.S.C%' and stud_id=p.stud_id ) as hsc_percent ,"

+ " (select sum(cast(Amount as float)) from m_FeeEntry where Stud_id=p.stud_id and ayid='" + year + "'  and Chq_status='Clear') as paid,"

+ " ((select sum(cast(Amount as float)) from m_FeeMaster where group_id='" + grp_title + "' and Ayid='" + year + "') - (select sum(cast(Amount as float)) from m_FeeEntry where Stud_id=p.stud_id and ayid='" + year + "'  and Chq_status='Clear')) as bal,"
           + " CONVERT(INT,SUBSTRING(roll_no ,PATINDEX('%[0-9]%',roll_no ),"
   + " LEN(roll_no ))) as [Roll_No],case when stud_gender=0 then 'Female' else 'Male' end as Gender , stud_Category  as [Category] ,Group_title FROM dbo.m_std_studentacademic_tbl as s RIGHT "
  + " JOIN dbo.m_crs_subjectgroup_tbl  as g ON s.group_id = g.Group_id right join dbo.m_std_personaldetails_tbl as p on p.stud_id = s.stud_id where s.ayid ='" + year + "'and "
   + " g.group_id ='" + grp_title + "'and s.del_flag=0  ORDER BY (case when roll_no like '%[A-Z]%' then LEFT(roll_no ,PATINDEX('%[0-9]%',roll_no )-1) else '' end), "
          + " CONVERT(INT,SUBSTRING(roll_no ,PATINDEX('%[0-9]%',roll_no ),LEN(roll_no )))";
        }
        else
        {
            qry = "SELECT distinct p.stud_id , isnull(stud_L_Name,'') + ' ' + isnull(stud_F_Name,'') + ' ' + isnull(stud_M_Name ,'') as [Student Name], (case when roll_no like '%[A-Z]%' then "
            +" LEFT(roll_no ,PATINDEX('%[0-9]%',roll_no )-1) else '' end),(select top(1) Univ_Enrol_no from OLA_FY_adm_CourseSelection where stud_id=p.stud_id and group_id=g.Group_id and del_flag=0) as"
   +" univ_no,(select top(1) Exact_percentage from m_std_pervrecord_tbl where exam like 'H.S.C%' and stud_id=p.stud_id ) as hsc_percent ,"

 + " (select sum(cast(Amount as float)) from m_FeeEntry where Stud_id=p.stud_id and ayid='" + year + "'  and Chq_status='Clear') as paid,"

+ " ((select sum(cast(Amount as float)) from m_FeeMaster where group_id='" + grp_title + "' and Ayid='" + year + "') - (select sum(cast(Amount as float)) from m_FeeEntry where Stud_id=p.stud_id and ayid='" + year + "' and Chq_status='Clear')) as bal,"
            +" CONVERT(INT,SUBSTRING(roll_no ,PATINDEX('%[0-9]%',roll_no ),"
    +" LEN(roll_no ))) as [Roll_No],case when stud_gender=0 then 'Female' else 'Male' end as Gender , stud_Category  as [Category] ,Group_title FROM dbo.m_std_studentacademic_tbl as s RIGHT "
   +" JOIN dbo.m_crs_subjectgroup_tbl  as g ON s.group_id = g.Group_id right join dbo.m_std_personaldetails_tbl as p on p.stud_id = s.stud_id where s.ayid ='" + year + "'and "
    +" g.group_id ='" + grp_title + "'and s.del_flag=0  ORDER BY (case when roll_no like '%[A-Z]%' then LEFT(roll_no ,PATINDEX('%[0-9]%',roll_no )-1) else '' end), "
           +" CONVERT(INT,SUBSTRING(roll_no ,PATINDEX('%[0-9]%',roll_no ),LEN(roll_no )))";
        }
        DataSet dss = cls.fillDataset(qry);
        return dss;
    }

    //===============Add siddhesh for exam dropdown
    public void getexam(string sem, string branch, string ayid, DropDownList ddl)
    {
        //string exam = splitGrp(ddlyearexcel);
        String qry = "select distinct ex.exam_date, ty.exam_code from dbo.cre_tygroup_exam as ty, dbo.cre_exam as ex where ty.exam_code=ex.exam_code and ty.sem_id='" + sem + "' and ty.ayid='" + ayid + "' and ty.branch_id='" + branch + "' and ty.del_flag=0";
        DataSet dss = cls.fillDataset(qry);
        ddl.DataSource = dss.Tables[0];
        ddl.DataTextField = "exam_date";
        ddl.DataValueField = "exam_code";
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("--Select--", "0"));

    }

    public DataTable getdataExcel(string year, string grp_title)
    {
        //  String qry = "SELECT distinct p.stud_id as [STUDENT ID] , CONVERT(INT,SUBSTRING(roll_no , PATINDEX('%[0-9]%',roll_no ),LEN(roll_no ))) as [Roll No] , isnull(stud_L_Name,'') + ' ' + isnull(stud_F_Name,'') + ' ' +  isnull(stud_M_Name ,'') as [Student Name],p.stud_Category as CASTE ,acd.sem1_cg as [SEM-1 CG],acd.sem1_credit as [SEM-1 CE],acd.sem2_cg as [SEM-2 CG],acd.sem2_credit as [SEM-2 CE],acd.sem3_cg as [SEM-3 CG],acd.sem3_credit as [SEM-3 CE], acd.sem4_cg as [SEM-4 CG],acd.sem4_credit as [SEM-4 CE] FROM dbo.m_std_studentacademic_tbl as s RIGHT JOIN dbo.m_crs_subjectgroup_tbl  as g ON s.group_id = g.Group_id right join dbo.m_std_personaldetails_tbl as p on p.stud_id = s.stud_id  left join  cre_marks_tbl as marktable on s.stud_id=marktable.stud_id left join cre_stud_academic as acd on acd.stud_id=marktable.stud_id where s.ayid ='" + year + "'and g.group_id ='" + grp_title + "' ORDER BY  CONVERT(INT,SUBSTRING(roll_no ,PATINDEX('%[0-9]%',roll_no ),LEN(roll_no )))";
        String qry = "SELECT distinct p.stud_id as [STUDENT ID] , CONVERT(INT,SUBSTRING(roll_no , PATINDEX('%[0-9]%',roll_no ),LEN(roll_no ))) as [Roll No] , isnull(stud_L_Name,'') + ' ' + isnull(stud_F_Name,'') + ' ' +  isnull(stud_M_Name ,'') as [Student Name],p.stud_Category as CASTE ,acd.sem1_cg as[SEM-1 CG],acd.sem1_credit as [SEM-1 CE], case when sem1_cg <> '' then convert(varchar(50),(CAST(sem1_cg as float))/(CAST(sem1_credit as float))) else 'null'  end as [SEM-1 SGPA], acd.sem2_cg as [SEM-2 CG],acd.sem2_credit as [SEM-2 CE], case when sem2_cg <> '' then convert(varchar(50),(CAST(sem2_cg as float))/(CAST(sem2_credit as float))) else 'null'  end as [SEM-2 SGPA], acd.sem3_cg as [SEM-3 CG],acd.sem3_credit as [SEM-3 CE], case when sem3_cg <> '' then convert(varchar(50),(CAST(sem3_cg as float))/(CAST(sem3_credit as float))) else 'null'  end as [SEM-3 SGPA],acd.sem4_cg as [SEM-4 CG],acd.sem4_credit as [SEM-4 CE], case when sem4_cg <> '' then convert(varchar(50),(CAST(sem4_cg as float))/(CAST(sem4_credit as float))) else 'null'  end as [SEM-4 SGPA] FROM dbo.m_std_studentacademic_tbl as s RIGHT JOIN dbo.m_crs_subjectgroup_tbl  as g ON s.group_id = g.Group_id right join dbo.m_std_personaldetails_tbl as p on p.stud_id = s.stud_id  left join  cre_marks_tbl as marktable on s.stud_id=marktable.stud_id left join cre_stud_academic as acd on acd.stud_id=marktable.stud_id where s.ayid ='" + year + "'and g.group_id ='" + grp_title + "' ORDER BY  CONVERT(INT,SUBSTRING(roll_no ,PATINDEX('%[0-9]%',roll_no ),LEN(roll_no )))";
        DataTable dt = cls.fillDataTable(qry);
        return dt;
    }

    public DataTable minayid(string id)
    {
        String qry = "select min(s.ayid) as year,min(cs.group_title)as GroupTitle,MIN(s.Subcourse_id)as subcourse from  m_std_studentacademic_tbl  as s,m_crs_subjectgroup_tbl as cs  where stud_id='" + id + "' and s.subcourse_id in( select subcourse_id from m_crs_subjectgroup_tbl ) and cs.subcourse_id=s.Subcourse_id ";
        DataTable dt = cls.fillDataTable(qry);
        return dt;
    }

    public DataTable checkexam(string id, string semid)
    {
        //  String qry = " select distinct e.exam_date+' '+case atkt_exam when 1 then case when m.exam_code like 'E%' then '(A.T.K.T)' else '(Reval A.T.K.T)' end when 2 then case when m.exam_code like 'E%' then '(Additional)' else '(Reval Additional)' end  else  case  when m.exam_code like 'E%' then '(Regular)' else '(Reval Regular)' end  end as LastExam,m.exam_code,m.sem_id from cre_marks_tbl as m left join cre_exam as e on e.exam_code=m.exam_code where  stud_id='" + id + "'  order by m.sem_id"; //and m.exam_code not like 'R%'
        String qry = "select count(distinct exam_code) as examattempt from cre_marks_tbl where stud_id='" + id + "' and sem_id='" + semid + "' and exam_code not like 'R%'";
        DataTable dt = cls.fillDataTable(qry);
        return dt;
    }
    public struct subject
    {

        public string credit, credit1, credit2, resolution1, resolution2, credit_id, subject_id, ayid, h3_type, exam_code, stud_name, stud_id, exam_name;
        public string h1_type, h1_out, h1_pass, h2_type, h2_out, h2_pass, overall_per;
        public string query, query2, query3, query1, str;
        public string condition, group_id;
        public string value, branch_id, subject_name, semester_name, subject_code, sem_id;
        public int id;
    }
    public DataTable maxexam(string id, string semid)
    {

        // String qry = "select distinct e.exam_date+' '+case atkt_exam when 1 then case when m.exam_code like 'E%' then '(A.T.K.T)' else '(Reval A.T.K.T)' end when 2 then case when m.exam_code like 'E%' then '(Additional)' else '(Reval Additional)' end  else  case  when m.exam_code like 'E%' then '(Regular)' else '(Reval Regular)' end  end as LastExam,m.exam_code,sc.sem1_theory ,sc.sem1_other,sc.sem2_theory,sc.sem2_other,sc.sem3_theory,sc.sem3_other,sc.sem4_theory,sc.sem4_other from cre_stud_academic as sc, cre_marks_tbl as m left join cre_exam as e on e.exam_code=m.exam_code where  sc.stud_id=m.stud_id and m.curr_date in  (select max(curr_date) from cre_marks_tbl where  stud_id='" + id + "'  and sem_id='" + semid + "')";
        String qry = "select  distinct e.exam_date+' '+case atkt_exam when 1 then case when m.exam_code like 'E%' then '(A.T.K.T)' else '(Reval A.T.K.T)' end when 2 then case when m.exam_code like 'E%' then '(Additional)' else '(Reval Additional)' end  else  case  when m.exam_code like 'E%' then '(Regular)' else '(Reval Regular)' end  end as LastExam,m.exam_code,(select MAX(remark) from cre_marks_tbl where  stud_id='" + id + "'  and sem_id='" + semid + "' and  exam_code in(select exam_code from cre_marks_tbl where curr_date in(select max(curr_date) from  cre_marks_tbl where  stud_id='" + id + "'  and sem_id='" + semid + "'))) as Remark from cre_marks_tbl as m ,cre_exam as e where stud_id='" + id + "' and sem_id='" + semid + "' and  m.exam_code in(select exam_code from cre_marks_tbl where curr_date in(select max(curr_date) from  cre_marks_tbl where  stud_id='" + id + "'  and sem_id='" + semid + "')) and e.exam_code=m.exam_code group by e.exam_date,atkt_exam,m.exam_code,(m.remark)";

        DataTable dt = cls.fillDataTable(qry);
        return dt;
    }

    //===============Add Siddhesh for Excel
    public DataTable studdata(string year, string exam)
    {
        string qry = "select c.stud_id as [STUDENT ID] ,CONVERT(INT,SUBSTRING(m.Roll_no , PATINDEX('%[0-9]%',roll_no ),LEN(m.Roll_no ))) as [Roll No] , isnull(l_name,'') + ' ' + isnull(F_Name,'') + ' ' +  isnull(M_Name ,'') as [Student Name], c.cast as[Caste],case when stud_type=1 then 'Student' else 'ExStudent' END as[Student Type], sem1_cg as [Sem-1 CG], sem1_ce as [Sem-1 CE], sem1_sgpa as [Sem-1 SGPA], isnull(sem1_month,'') + ' ' +  isnull(sem1_year ,'') as [Sem-1 Last Exam], sem2_cg as [Sem-2 CG], sem2_ce as [Sem-2 CE], sem2_sgpa as [Sem-2 SGPA], isnull(sem2_month,'') + ' ' +  isnull(sem2_year ,'') as [Sem-2 Last Exam], sem3_cg as [Sem-3 CG], sem3_ce as[Sem-3 CE], sem3_sgpa as[Sem-3 SGPA], isnull(sem3_month,'') + ' ' +  isnull(sem3_year ,'') as [Sem-3 Last Exam], sem4_cg as[Sem-4 CG], sem4_ce as[Sem-4 CE], sem4_sgpa as[Sem-4 SGPA], isnull(sem4_month,'') + ' ' +  isnull(sem4_year ,'') as [Sem-4 Last Exam] from dbo.cre_college_form as c, dbo.m_std_studentacademic_tbl as m where c.stud_id=m.stud_id and c.exam_code='" + exam + "' and m.ayid='" + year + "' and c.del_flag=0 ORDER BY LEN(m.Roll_no ),m.Roll_no Asc";
        DataTable dt = cls.fillDataTable(qry);
        return dt;
    }
    public DataTable confirmdata(string year)
    {
        string qry = "select m.stud_id as [Student Id], CONVERT(INT,SUBSTRING(roll_no , PATINDEX('%[0-9]%',roll_no ),LEN(m.roll_no ))) as [Roll No] ,isnull(co.L_Name,'') + ' ' + isnull(co.F_Name,'') + ' ' +  isnull(co.M_Name ,'') as [Student Name], s.group_title as [Course], e.exam_date as[Exam],c.sem_id as [Sem], SUM(ty.form_fees + ty.exam_fees + ty.marksheet_fees) as[Fees], isnull(ty.late_fees,'') as [Late Fees] from dbo.cre_confirm as c,dbo.cre_college_form as co, dbo.m_std_studentacademic_tbl as m, dbo.m_crs_subjectgroup_tbl as s, dbo.cre_tygroup_exam as ty, dbo.cre_exam as e where c.group_id=s.group_id and m.group_id=s.group_id and co.exam_code=e.exam_code and co.stud_id=m.stud_id and c.exam_code=e.exam_code and ty.exam_code=c.exam_code and m.ayid='" + year + "' and c.del_flag=0 group by m.stud_id, m.roll_no, co.l_name, co.f_name, co.m_name, Group_title,e.exam_date, c.sem_id,ty.form_fees, ty.exam_fees , ty.marksheet_fees, ty.late_fees ORDER BY LEN(m.roll_no ),m.Roll_no,m.stud_id, co.l_name, co.f_name, co.m_name, Group_title,e.exam_date, c.sem_id,ty.form_fees, ty.exam_fees , ty.marksheet_fees, ty.late_fees asc";
        DataTable dt = cls.fillDataTable(qry);
        return dt;
    }

    public string splitGrp(string grp)
    {
        string[] grpId=grp.Split(',');
        string finalString = "";
        for (int i = 0; i < grpId.Length; i++)
        {
            if (i == 0)
            {
                finalString = "'" + grpId[i].ToString() + "'";
            }
            else
            {
                finalString += ",'" + grpId[i].ToString() + "'";
            }
        }
            return finalString;
    }

    public bool insertNotice(string filename, string strFileType, Byte[] size, string groupid, string title, string emp_id, string description, string ayid)
    {
        bool value = false;
        string qry = "";
        string str = "select col1 from web_tp_login where emp_id='" + emp_id + "' and del_flag=0";
        DataSet dss = cls.fillDataset(str);

        if (!string.IsNullOrEmpty(dss.Tables[0].Rows[0][0].ToString()))
        {
            string userdata = dss.Tables[0].Rows[0][0].ToString() + "," + emp_id + "," + cls.getClientIp();
           // qry = "Insert Into Assignments(FileName,FileType,FileData,group_id,del_flag,curr_dt,topic,user_id,description,ayid) Values('" + filename + "','" + strFileType + "',@DATA,'" + groupid + "',0,getdate(),'" + title + "','" + userdata + "','" + description + "','" + ayid + "')";
            qry = "Insert Into Assignments(FileName,FileType,FileData,group_id,del_flag,curr_dt,topic,user_id,description,ayid) Values('" + filename + "','" + strFileType + "',@DATA,'" + groupid + "',0,getdate(),'" + title + "','" + emp_id + "','" + description + "','" + ayid + "')";//,NULL
        
        }
        else
        {
            string userdata = emp_id + "," + cls.getClientIp();
           // qry = "Insert Into Assignments(FileName,FileType,FileData,group_id,del_flag,curr_dt,topic,user_id,description,ayid) Values('" + filename + "','" + strFileType + "',@DATA,'" + groupid + "',0,getdate(),'" + title + "','" + userdata + "','" + description + "','" + ayid + "')";
            qry = "Insert Into Assignments(FileName,FileType,FileData,group_id,del_flag,curr_dt,topic,user_id,description,ayid) Values('" + filename + "','" + strFileType + "',@DATA,'" + groupid + "',0,getdate(),'" + title + "','" + emp_id + "','" + description + "','" + ayid + "')";//,NULL
        
        }
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = qry;
        cmd.Parameters.AddWithValue("@DATA", size);
        cmd.Connection = cls.con;
        cls.con.Open();
        int i = cmd.ExecuteNonQuery();
        cls.con.Close();

        if (i > 0)
        {
            value = true;
        }
        return value;
    }

    public bool insertNotice(string groupid, string title,string emp_id, string description,string ayid)
    {
        bool value = false;
        string qry = "";
        string str = "select col1 from web_tp_login where emp_id='" + emp_id + "' and del_flag=0";
        DataSet dss = cls.fillDataset(str);
        if (!string.IsNullOrEmpty(dss.Tables[0].Rows[0][0].ToString()))
        {
            
            string userdata = dss.Tables[0].Rows[0][0].ToString() + "," + emp_id + "," + cls.getClientIp();
            //changes by karishma
           // qry = "Insert Into Assignments(group_id,del_flag,curr_dt,topic,user_id,description,ayid) Values( '" + groupid + "',0,getdate(),'" + title + "','" + userdata + "','" + description + "','" + ayid + "')";
            qry = "Insert Into Assignments(group_id,del_flag,curr_dt,topic,user_id,description,ayid) Values( '" + groupid + "',0,getdate(),'" + title + "','" + userdata   + "','" + description + "','" + ayid + "')";
        
        }
        else
        {
            string userdata = emp_id + "," + cls.getClientIp();
         //   qry = "Insert Into Assignments(group_id,del_flag,curr_dt,topic,user_id,description,ayid) Values( '" + groupid + "',0,getdate(),'" + title + "','" + userdata + "','" + description + "','" + ayid + "')";

            qry = "Insert Into Assignments(group_id,del_flag,curr_dt,topic,user_id,description,ayid) Values( '" + groupid + "',0,getdate(),'" + title + "','" + userdata + "','" + description + "','" + ayid + "')";
        
        }
       
        return value = cls.DMLqueries(qry);
    }

    public void loadNoticedata(GridView gv, string emp_id)
    {
        String qryload = "select a.Id,a.FileName,a.FileType,a.curr_dt,a.topic,a.description, m_crs_subjectgroup_tbl.Group_title from Assignments as a  inner join m_crs_subjectgroup_tbl  On a.Group_id=m_crs_subjectgroup_tbl.Group_id where a.user_id like'%" + emp_id + "%'order by a.curr_dt desc";
        DataSet dss = cls.fillDataset(qryload);
        gv.DataSource = dss;
        gv.DataBind();
    }

    public bool delete_notice(string sr_no)
    {
        bool i = false;
        String qry = "delete from Assignments where id='" + sr_no + "'";
        return i = cls.DMLqueries(qry);

    }

    public void getRoles(DropDownList ddl)
    {
        string qry = "select role_name,role_id from web_tp_roletype where del_flag=0";
        DataSet dss_roles = cls.fillDataset(qry);
        if (dss_roles.Tables[0].Rows.Count > 0)
        {
            ddl.Items.Clear();
            ddl.Items.Add(new ListItem("--SELECT--", "0"));
            for (int i = 0; i < dss_roles.Tables[0].Rows.Count; i++)
            {
                ddl.Items.Add(new ListItem(dss_roles.Tables[0].Rows[i]["role_name"].ToString(), dss_roles.Tables[0].Rows[i]["role_id"].ToString()));
            }
            ddl.SelectedIndex = 0;
        }
    }

    public void getRoleGroups(string subcourse, HtmlSelect lst)
    {
        string group_query = "select Group_title,Group_id from dbo.m_crs_subjectgroup_tbl where Subcourse_id='" + subcourse + "' and del_flag=0";

        DataSet ds_grp = cls.fillDataset(group_query);
        if (ds_grp.Tables[0].Rows.Count > 0)
        {
            

            lst.DataSource = ds_grp.Tables[0];
            lst.DataTextField = "Group_title";

            lst.DataValueField = "Group_id";
            lst.DataBind();

        }
    }

    public void getRoleSubcourse(string course_id, DropDownList ddl)
    {
        string group_query = " select subcourse_name,subcourse_id from  dbo.m_crs_subcourse_tbl where course_id='" + course_id + "' and del_flag=0";

        DataSet ds_grp = cls.fillDataset(group_query);
        if (ds_grp.Tables[0].Rows.Count > 0)
        {
            ddl.Items.Clear();
            ddl.Items.Add(new ListItem("--SELECT--", "0"));
            for (int i = 0; i < ds_grp.Tables[0].Rows.Count; i++)
            {
                ddl.Items.Add(new ListItem(ds_grp.Tables[0].Rows[i]["subcourse_name"].ToString(), ds_grp.Tables[0].Rows[i]["subcourse_id"].ToString()));
            }
            ddl.SelectedIndex = 0;
        }
        else
        {
        }

    }

    public void getRoleSubcourse1(String course_id,HtmlSelect lst)
    {
        string sub_course = "select Group_title,Group_id from dbo.m_crs_subjectgroup_tbl where  del_flag=0 and Subcourse_id in (select subcourse_id from  dbo.m_crs_subcourse_tbl where course_id in ('" + course_id + "')  and del_flag=0)";
        DataSet ds_course = cls.fillDataset(sub_course);
        if (ds_course.Tables[0].Rows.Count > 0)
        {

            lst.DataSource = ds_course.Tables[0];
            lst.DataTextField = "Group_title";
            lst.DataValueField = "Group_id";
            lst.DataBind();

        }
        else
        {
        }
    }

    public void LoadRoleGv(string dep,string des, GridView gv)
    {
        string designation = "Select emp_id as [Emp_id],NAME +' '+FATHER+' '+SURNAME as [Name],CURRENT_DEPARTMENT_NAME as [Department],CURRENT_DESIGNATION as [Designation] from EmployeePersonal where emp_dept_id='" + dep + "'and CURRENT_DESIGNATION='" + des + "'and EmployeePersonal.emp_id NOT IN (SELECT web_tp_login.emp_id FROM web_tp_login) order by EmployeePersonal.NAME ;";
        DataSet ds_desfilter = cls.fillDataset(designation);
        if (ds_desfilter.Tables[0].Rows.Count > 0)
        {
            gv.DataSource = ds_desfilter.Tables[0];
            gv.DataBind();
        }
        else
        {
            if (gv.Rows.Count > 0)
            {
                gv.DataSource = null;
                gv.DataBind();
            }
        }
    }

    public DataSet LoadRoleemployee(string dep)
    {
        string DesignationQry = "select distinct CURRENT_DESIGNATION from EmployeePersonal where emp_dept_id='" + dep + "'; Select emp_id as [Emp_id],NAME +' '+FATHER+' '+SURNAME as [Name],CURRENT_DEPARTMENT_NAME as [Department],CURRENT_DESIGNATION as [Designation] from EmployeePersonal where emp_dept_id='" + dep + "'and EmployeePersonal.emp_id NOT IN (SELECT web_tp_login.emp_id FROM web_tp_login) order by EmployeePersonal.NAME;";

        DataSet dsLog = cls.fillDataset(DesignationQry);
        return dsLog;
    }

    public DataSet SearchRole(string name,string m_name,string l_name)
    {
        string SearchQry = " select emp_id as [Emp_id],NAME +' '+FATHER+' '+SURNAME as [Name],CURRENT_DEPARTMENT_NAME as [Department],CURRENT_DESIGNATION as [Designation]  from dbo.EmployeePersonal where NAME like '%" + name + "%' and FATHER like '%" + m_name + "%' and SURNAME like '%" + l_name + "%' and emp_id not in (select emp_id from web_tp_login where del_flag=0)";
        DataSet ds1 = cls.fillDataset(SearchQry);
        return ds1;
    }
    public bool InserRole(string role_name,string formname)
    {

        bool i=false;
        string insQry = "insert into dbo.web_tp_roletype values ('" + role_name+ "','" + formname + "','','',1,getDate(),0)";

        return i = cls.DMLqueries(insQry);

    }

    public void LoadRoleSubjectgrp(HtmlSelect ls, HtmlSelect  lse)
    {
        string qry = "select distinct Group_title,Group_id from dbo.m_crs_subjectgroup_tbl where  del_flag=0 order by Group_title";

        DataSet dss_subject_grp = cls.fillDataset(qry);
        if (dss_subject_grp.Tables[0].Rows.Count > 0)
        {


            ls.DataSource = dss_subject_grp.Tables[0];
            ls.DataTextField = "Group_title";

            ls.DataValueField = "Group_id";
            ls.DataBind();

            lse.DataSource = dss_subject_grp.Tables[0];
            lse.DataTextField = "Group_title";

            lse.DataValueField = "Group_id";
            lse.DataBind();

        }
        else
        {
        }

    }

    public void loadSubjects(ListBox ls, string GrpID)
    {
        string qry = "select distinct sg.Subject_id,s.Subject_Name from dbo.d_crs_subjectgroup_tbl sg,dbo.m_crs_subject_tbl s  where sg.Subject_Id=s.Subject_Id and Group_id in '(" + GrpID + ")' and s.del_flag=0 and sg.del_flag=0";

        DataSet dss_subject = cls.fillDataset(qry);
        if (dss_subject.Tables[0].Rows.Count > 0)
        {
            ls.DataSource = dss_subject.Tables[0];
            ls.DataTextField = "Subject_Name";
            ls.DataValueField = "Subject_id";
            ls.DataBind();
        }
        else
        {
            ls.DataSource = null;
            ls.DataBind();
        }
    }

    public DataSet getRoleCourse()
    {
        String qry1 = " select course_name,course_id from dbo.m_crs_course_tbl  where del_flag=0;";
        DataSet dss = cls.fillDataset(qry1);
        return dss;

    }

    public void load_teachers(string emp_id, DropDownList ddl)
    {
        string qry = "Select distinct a.emp_id as [Emp_id],upper(NAME +' '+FATHER+' '+SURNAME) as [Name] from EmployeePersonal as a,web_tp_access as b where a.emp_id=b.emp_id and  group_id in (" + emp_id + ") and a.emp_id IN (SELECT web_tp_login.emp_id FROM web_tp_login) order by NAME ";
        DataSet dss = cls.fillDataset(qry);
        ddl.DataSource = dss.Tables[0];
        ddl.DataTextField = "Name";
        ddl.DataValueField = "emp_id";
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("-- Select --", "0"));
    }

    public DataSet fillLogin()
    {
        string qry = "select distinct CURRENT_DEPARTMENT_NAME,emp_dept_id from dbo.EmployeePersonal where CURRENT_DEPARTMENT_NAME <> '' order by CURRENT_DEPARTMENT_NAME;select distinct CURRENT_DESIGNATION,emp_des_id from dbo.EmployeePersonal where CURRENT_DESIGNATION <> '' order by CURRENT_DESIGNATION ";
       DataSet dss= cls.fillDataset(qry);
       return dss;
    }

    public DataSet fillRole()
    {
        string qry = "select * from dbo.web_tp_roletype where is_active=1 and del_flag=0";
        DataSet dss = cls.fillDataset(qry);
        return dss;
    }

    public DataSet GetstudInfo(string id)
    {
       String str = "select stud_id,stud_F_Name +' '+ stud_M_Name +' '+ stud_L_Name AS stud_name,stud_PermanentPhone,stud_Email,stud_Father_TelNo,stud_DOB,stud_PermanentAdd from dbo.m_std_personaldetails_tbl where stud_id='" + id + "' and del_flag='0'";
        DataSet ds = cls.fillDataset(str);
        return ds;
    }
    
    public bool insertLogin(GridView gv_assign_roles,string role,string group,string category)
    {
        string qryInsert = ""; bool val = false;
        for (int i = 0; i < gv_assign_roles.Rows.Count; i++)
        {

            CheckBox chk = (CheckBox)gv_assign_roles.Rows[i].Cells[4].FindControl("chk_select");
            //  String id = gv_assign_roles.Rows[i].Cells[2].Text;

            if (chk.Checked)
            {
                String emp_id = gv_assign_roles.Rows[i].Cells[1].Text;
                Label lbl_id = (Label)gv_assign_roles.Rows[i].Cells[1].FindControl("Emp_id");

                String emp_name = gv_assign_roles.Rows[i].Cells[2].Text;
                Label lbl_name = (Label)gv_assign_roles.Rows[i].Cells[2].FindControl("Name");

                String name = lbl_name.Text;
                string fnl_name = "";
                String id = lbl_id.Text;
               // if(name.Contains("'")==true )
               // {
               //fnl_name =name.Replace ("'","''");
               // }
               // else
               // {
               //     fnl_name =name;
               // }
                qryInsert += "Insert into web_tp_login Values('" + lbl_id.Text   + "','" + role + "','" + lbl_id.Text + "','" + lbl_id.Text + "','" + group + "','"+category+"','','',getdate(),0);";
            }

        }


        if (qryInsert != "")
        {

            if (cls.DMLqueries(qryInsert))
            {
                 val = true;

            }
            else
            {
                //not saved
                val = false;

            }
        }
        else
        {
            val = false;
        }
        return val;
    }


    //For Academic Year

    public DataTable getAcademic()
    {
        string SearchQry = "select *,'' As IsNew from m_academic";
        DataSet ds1 = cls.fillDataset(SearchQry);
        return ds1.Tables[0];

    }

    public DataTable getFinancial()
    {
        string SearchQry = "select *,'' As IsNew_fin from m_financial";
        DataSet ds1 = cls.fillDataset(SearchQry);
        return ds1.Tables[0];

    }

    //
    public DataSet getPRNdata(string year, string grp_title)
    {
        String qry = "SELECT distinct p.stud_id , isnull(stud_L_Name,'') + ' ' + isnull(stud_F_Name,'') + ' ' + isnull(stud_M_Name ,'') as [Student Name], LEFT(roll_no ,PATINDEX('%[0-9]%',roll_no )-1), CONVERT(INT,SUBSTRING(roll_no ,PATINDEX('%[0-9]%',roll_no ),LEN(roll_no ))) as [Roll_No] , stud_Category  as [Category] ,Group_title FROM dbo.m_std_studentacademic_tbl as s RIGHT JOIN dbo.m_crs_subjectgroup_tbl  as g ON s.group_id = g.Group_id right join dbo.m_std_personaldetails_tbl as p on p.stud_id = s.stud_id where s.ayid ='" + year + "'and g.group_id ='" + grp_title + "'and s.del_flag=0 and s.id_no is null ORDER BY LEFT(roll_no ,PATINDEX('%[0-9]%',roll_no )-1), CONVERT(INT,SUBSTRING(roll_no ,PATINDEX('%[0-9]%',roll_no ),LEN(roll_no )))";
        DataSet dss = cls.fillDataset(qry);
        return dss;
    }

    public bool updatePRN(string prn, string stud_id)
    {
        String qry = "update m_std_studentacademic_tbl set ID_No='" + prn + "' where stud_id='" + stud_id + "'";
        bool result = cls.DMLqueries(qry);
        return result;
    }


    public void get_crs_trans(DropDownList ddl)
    {
        string str = "select distinct case b.course_id when 'CRS001' then subcourse_name when 'CRS003' then subcourse_name when 'CRS007' then subcourse_name else Group_title end as 'Course' from m_crs_subjectgroup_tbl a join m_crs_subcourse_tbl b on a.Subcourse_id=b.subcourse_id join m_crs_course_tbl c on b.course_id=c.course_id";
        DataSet dss = cls.fillDataset(str);
        ddl.DataSource = dss.Tables[0];
        ddl.DataTextField = "Course";
        //ddl.DataValueField = "course_id";
        ddl.DataBind();
    }

    public void get_year_trans(DropDownList ddl)
    {
        string str = "select substring(Duration,9,4) as year from m_academic union all select substring(Duration,21,4) from m_academic where IsCurrent=1";
        DataSet dss = cls.fillDataset(str);
        ddl.DataSource = dss.Tables[0];
        ddl.DataTextField = "year";
        //ddl.DataValueField = "course_id";
        ddl.DataBind();
    }


    public bool retrieveStudInfo(TextBox txt_stud_id, TextBox txt_first_name, TextBox txt_middle_name, TextBox txt_last_name, GridView grid_stud, string empid)
    {
        bool val = false;
        //str = "select stud_id,stud_F_Name +' '+ stud_M_Name +' '+stud_L_Name AS stud_name,stud_DOB,stud_PermanentAdd from dbo.m_std_personaldetails_tbl where del_flag=0";
     //   string str = "select p.stud_id,p.stud_F_Name +' '+ p.stud_M_Name +' '+p.stud_L_Name AS stud_name,a.roll_no,g.group_title from dbo.m_std_personaldetails_tbl as p,dbo.m_std_studentacademic_tbl as a,m_crs_subjectgroup_tbl as g where p.stud_id=a.stud_id and a.group_id=g.Group_id and a.ayid in(select max(ayid) from dbo.m_academic )  and p.del_flag='0'";

        //string str = "select p.stud_id,p.stud_F_Name +' '+ p.stud_M_Name +' '+p.stud_L_Name AS stud_name,a.roll_no,g.group_title from dbo.m_std_personaldetails_tbl as p,dbo.m_std_studentacademic_tbl as a,m_crs_subjectgroup_tbl as g where p.stud_id=a.stud_id and a.group_id=g.Group_id and a.ayid in(select max(ayid) from dbo.m_academic )  and p.del_flag='0'";
        string str="";
        int flag = 0;
        if (txt_stud_id.Text != "")
        {
            flag = 1;
           // str += "and p.stud_id='" + txt_stud_id.Text + "'";
            str = "declare @group_id varchar(50); set @group_id=(select Group_id from m_std_studentacademic_tbl e where e.ayid in(select max(ayid) from dbo.m_std_studentacademic_tbl where Stud_id='" + txt_stud_id.Text + "' )and e.Stud_id='" + txt_stud_id.Text + "' and e.del_flag=0) "
            +"select p.stud_id,p.stud_F_Name +' '+ p.stud_M_Name +' '+p.stud_L_Name AS stud_name,a.roll_no,g.group_title from dbo.m_std_personaldetails_tbl as p,dbo.m_std_studentacademic_tbl as a,m_crs_subjectgroup_tbl as g ,"
            +"(select group_ids  from web_tp_login where '1' =  dbo.fun_QueryCSVColumn (group_ids,',',@group_id ,'contains')and emp_id='"+empid +"') emp "
            + "where emp.group_ids is not null and p.stud_id=a.stud_id and a.group_id=g.Group_id and a.ayid in(select max(ayid) from dbo.m_std_studentacademic_tbl where Stud_id='" + txt_stud_id.Text + "')  and p.del_flag='0' and p.stud_id='" + txt_stud_id.Text + "'";
        }
        else if (txt_first_name.Text != "" && txt_last_name.Text != "" && txt_middle_name.Text!="")
        {            flag = 1;
            //str += "and stud_F_Name like '" + txt_first_name.Text + "%' and stud_L_Name like '" + txt_last_name.Text + "%'";
        str = "select * from (select p.stud_id,p.stud_F_Name +' '+ p.stud_M_Name +' '+p.stud_L_Name AS stud_name,a.roll_no,g.group_title,g.Group_id,ROW_NUMBER()OVER(PARTITION BY a.stud_id ORDER BY a.ayid desc) RN  from dbo.m_std_personaldetails_tbl as p,dbo.m_std_studentacademic_tbl as a,m_crs_subjectgroup_tbl as g where p.stud_id=a.stud_id and a.group_id=g.Group_id  and p.del_flag='0'and stud_F_Name like '" + txt_first_name.Text.Replace("'", "''") + "%' and stud_L_Name like '" + txt_last_name.Text.Replace("'", "''") + "%' and stud_m_Name like '" + txt_middle_name.Text.Replace("'", "''") + "%' ) a"
           + " where  RN=1"; //1=(select 1  from web_tp_login where '1' =  dbo.fun_QueryCSVColumn (group_ids,',',a.Group_id ,'contains')and emp_id='" + empid + "')  and
        
        }
        else if (txt_first_name.Text != "" && txt_last_name.Text != "" )
        {
            flag = 1;
            //str += "and stud_F_Name like '" + txt_first_name.Text + "%' and stud_L_Name like '" + txt_last_name.Text + "%'";
            str = "select * from (select p.stud_id,p.stud_F_Name +' '+ p.stud_M_Name +' '+p.stud_L_Name AS stud_name,a.roll_no,g.group_title,g.Group_id,ROW_NUMBER()OVER(PARTITION BY a.stud_id ORDER BY a.ayid desc) RN  from dbo.m_std_personaldetails_tbl as p,dbo.m_std_studentacademic_tbl as a,m_crs_subjectgroup_tbl as g where p.stud_id=a.stud_id and a.group_id=g.Group_id  and p.del_flag='0'and stud_F_Name like '" + txt_first_name.Text.Replace("'", "''") + "%' and stud_L_Name like '" + txt_last_name.Text.Replace("'", "''") + "%'  ) a"
               + " where  RN=1"; //1=(select 1  from web_tp_login where '1' =  dbo.fun_QueryCSVColumn (group_ids,',',a.Group_id ,'contains')and emp_id='" + empid + "')  and

        }
        else if (txt_first_name.Text != "" && txt_middle_name.Text != "")
        {
            flag = 1;
            //str += "and stud_F_Name like '" + txt_first_name.Text + "%' and stud_L_Name like '" + txt_last_name.Text + "%'";
            str = "select * from (select p.stud_id,p.stud_F_Name +' '+ p.stud_M_Name +' '+p.stud_L_Name AS stud_name,a.roll_no,g.group_title,g.Group_id,ROW_NUMBER()OVER(PARTITION BY a.stud_id ORDER BY a.ayid desc) RN  from dbo.m_std_personaldetails_tbl as p,dbo.m_std_studentacademic_tbl as a,m_crs_subjectgroup_tbl as g where p.stud_id=a.stud_id and a.group_id=g.Group_id  and p.del_flag='0'and stud_F_Name like '" + txt_first_name.Text.Replace("'", "''") + "%' and stud_m_Name like '" + txt_middle_name.Text.Replace("'", "''") + "%' ) a"
               + " where RN=1";//1=(select 1  from web_tp_login where '1' =  dbo.fun_QueryCSVColumn (group_ids,',',a.Group_id ,'contains')and emp_id='" + empid + "')  and 

        }
        else if (txt_first_name.Text != "")
        {
            flag = 1;
            //str += "and stud_F_Name like '" + txt_first_name.Text + "%'";
            str = "select * from (select p.stud_id,p.stud_F_Name +' '+ p.stud_M_Name +' '+p.stud_L_Name AS stud_name,a.roll_no,g.group_title,g.Group_id,ROW_NUMBER()OVER(PARTITION BY a.stud_id ORDER BY a.ayid desc) RN  from dbo.m_std_personaldetails_tbl as p,dbo.m_std_studentacademic_tbl as a,m_crs_subjectgroup_tbl as g where p.stud_id=a.stud_id and a.group_id=g.Group_id  and p.del_flag='0'and stud_F_Name like '" + txt_first_name.Text.Replace("'", "''") + "%') a"
                + " where  RN=1"; //1=(select 1  from web_tp_login where '1' =  dbo.fun_QueryCSVColumn (group_ids,',',a.Group_id ,'contains')and emp_id='" + empid + "') and
        }
        else if (txt_last_name.Text != "")
        {
            flag = 1;
            //str += "and stud_L_Name like '" + txt_last_name.Text + "%'";

            str = "select * from (select p.stud_id,p.stud_F_Name +' '+ p.stud_M_Name +' '+p.stud_L_Name AS stud_name,a.roll_no,g.group_title,g.Group_id,ROW_NUMBER()OVER(PARTITION BY a.stud_id ORDER BY a.ayid desc) RN  from dbo.m_std_personaldetails_tbl as p,dbo.m_std_studentacademic_tbl as a,m_crs_subjectgroup_tbl as g where p.stud_id=a.stud_id and a.group_id=g.Group_id  and p.del_flag='0'and stud_L_Name like '" + txt_last_name.Text.Replace("'", "''") + "%') a"
               + " where  RN=1";//1=(select 1  from web_tp_login where '1' =  dbo.fun_QueryCSVColumn (group_ids,',',a.Group_id ,'contains')and emp_id='" + empid + "') and
        }
        else if (txt_middle_name.Text != "")
        {
            flag = 1;

            str = "select * from (select p.stud_id,p.stud_F_Name +' '+ p.stud_M_Name +' '+p.stud_L_Name AS stud_name,a.roll_no,g.group_title,g.Group_id,ROW_NUMBER()OVER(PARTITION BY a.stud_id ORDER BY a.ayid desc) RN  from dbo.m_std_personaldetails_tbl as p,dbo.m_std_studentacademic_tbl as a,m_crs_subjectgroup_tbl as g where p.stud_id=a.stud_id and a.group_id=g.Group_id  and p.del_flag='0' and stud_m_Name like '" + txt_middle_name.Text.Replace("'", "''") + "%' ) a"
               + " where RN=1";//1=(select 1  from web_tp_login where '1' =  dbo.fun_QueryCSVColumn (group_ids,',',a.Group_id ,'contains')and emp_id='" + empid + "') and 
        }
        else
        {
            flag=0;
        }
        if (flag == 1)
        {
            DataSet ds = cls.fillDataset(str);
            if (ds.Tables[0].Rows.Count > 0)
            {
                grid_stud.DataSource = ds.Tables[0];
                grid_stud.DataBind();
                ds.Tables[0].Clear();
                txt_first_name.Text = "";
                txt_last_name.Text = "";
                txt_stud_id.Text = "";
                val = true;
            }
            else
            {
                val = false;
            }
        }
        else
        {
            val = false;
        }
        return val;
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

    public object selstudentcount(TextBox tb1,TextBox tb, string subcourse_id, string group_id, string ayid, Boolean group)
    {
        string Query;
        try
        {
            if (group == true)
            {
                Query = "select count(*) as stu,max(cast(roll_no as int)) as mx from m_std_studentacademic_tbl where subcourse_id='" + subcourse_id + "' and ayid='" + ayid + "' and group_id='" + group_id + "' and DEL_FLAG<>1";
            }
            else
            {
                Query = "select count(*) as stu,max(cast(roll_no as int)) as mx from m_std_studentacademic_tbl where subcourse_id='" + subcourse_id + "' and ayid='" + ayid + "' and group_id is null and ayid='' and DEL_FLAG<>1";
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

    public DataTable getStudList(string subcourse_id, string group_id, string ayid, Boolean null_null, Boolean checkgroup)
    {
        string strselect = "";
        try
        {

            if (null_null == false)
            {
                if (checkgroup == false)
                {
                    strselect = "select acd.stud_id,isnull(spd.stud_f_name,'')+' '+isnull(spd.stud_m_name,'')+' '+isnull(spd.stud_l_name,'') as Student_Name,acd.division,acd.lib_card_no,acd.Roll_no,case  when spd.stud_gender=0 then 'Female' else 'Male' end as gender,spd.stud_Grno from  m_std_studentacademic_tbl acd ";
                    strselect = strselect + "  ,m_std_personaldetails_tbl spd where acd.subcourse_id='" + subcourse_id + "' and acd.group_id is null and  acd.ayid='" + ayid + "' and ";
                    //strselect = strselect & "  ,m_std_personaldetails_tbl spd where acd.subcourse_id='" & strsubCourseId & "' and acd.group_id is null and spd.stud_gender='" & Val(strGender) & "'and  acd.ayid='" & ACDID & "' and "
                    strselect = strselect + "  acd.stud_id=SPD.stud_id";
                    strselect = strselect + "  order by   spd.stud_l_name,spd.stud_f_name,spd.stud_m_name asc ";
                    //change :29-6-15
                    //strselect = strselect & " order by case when isnumeric(substring(acd.Roll_no,0,2))<>1 then cast(substring(acd.Roll_no,3,len(acd.Roll_no)) as int)else cast(acd.Roll_no as int)end ,spd.stud_l_name,spd.stud_f_name,spd.stud_m_name asc"

                }
                else if (checkgroup == true)
                {
                    strselect = "select acd.stud_id,isnull(spd.stud_f_name,'')+' '+isnull(spd.stud_m_name,'')+' '+isnull(spd.stud_l_name,'') as Student_Name,acd.division,acd.lib_card_no,acd.Roll_no,case  when spd.stud_gender=0 then 'Female' else 'Male' end as gender,spd.stud_Grno from  m_std_studentacademic_tbl acd ";
                    strselect = strselect + "  ,m_std_personaldetails_tbl spd where acd.group_id='" + group_id + "' and acd.subcourse_id='" + subcourse_id + "' and  acd.ayid='" + ayid + "' and ";
                    strselect = strselect + "  acd.stud_id=SPD.stud_id AND acd.DEL_FLAG<>1 ";
                    // strselect = strselect & "  acd.stud_id=SPD.stud_id and Division is not null and Lib_card_no is not null  and spd.stud_gender='" & Val(strGender) & "' AND acd.DEL_FLAG<>1 "
                    strselect = strselect + "  order by spd.stud_l_name,spd.stud_f_name,spd.stud_m_name asc ";
                    //change :29-6-15
                    //strselect = strselect & " order by case when isnumeric(substring(acd.Roll_no,0,2))<>1 then cast(substring(acd.Roll_no,3,len(acd.Roll_no)) as int)else cast(acd.Roll_no as int)end ,spd.stud_l_name,spd.stud_f_name,spd.stud_m_name asc"

                }
            }
            else if (null_null == true)
            {
                if (checkgroup == false)
                {
                    strselect = "select acd.stud_id,isnull(spd.stud_f_name,'')+' '+isnull(spd.stud_m_name,'')+' '+isnull(spd.stud_l_name,'') as Student_Name,case  when spd.stud_gender=0 then 'Female' else 'Male' end as gender,spd.stud_Grno from  m_std_studentacademic_tbl acd ";
                    //strselect = strselect & " ,m_std_personaldetails_tbl spd where acd.subcourse_id='" & strsubCourseId & "' and acd.group_id is null and acd.stud_id=SPD.stud_id and Division is null and Lib_card_no is null  and spd.stud_gender='" & Val(strGender) & "' and  acd.ayid='" & ACDID & "' AND acd.DEL_FLAG<>1  "
                    strselect = strselect + " ,m_std_personaldetails_tbl spd where acd.subcourse_id='" + subcourse_id + "' and acd.group_id is null and acd.stud_id=SPD.stud_id and  acd.ayid='" + ayid + "' AND acd.DEL_FLAG<>1  ";
                    strselect = strselect + " order by spd.stud_l_name,spd.stud_f_name,spd.stud_m_name asc ";
                    //change :29-6-15
                    //strselect = strselect & " order by case when isnumeric(substring(acd.Roll_no,0,2))<>1 then cast(substring(acd.Roll_no,3,len(acd.Roll_no)) as int)else cast(acd.Roll_no as int)end ,spd.stud_l_name,spd.stud_f_name,spd.stud_m_name asc"

                }
                else if (checkgroup == true)
                {
                    strselect = "select acd.stud_id,isnull(spd.stud_f_name,'')+' '+isnull(spd.stud_m_name,'')+' '+isnull(spd.stud_l_name,'') as Student_Name,case  when spd.stud_gender=0 then 'Female' else 'Male' end as gender,spd.stud_Grno from  m_std_studentacademic_tbl acd ";
                    strselect = strselect + " ,m_std_personaldetails_tbl spd where acd.group_id='" + group_id + "' and acd.subcourse_id='" + subcourse_id + "' and acd.stud_id=SPD.stud_id and  acd.ayid='" + ayid + "' AND acd.DEL_FLAG<>1  ";
                    //strselect = strselect & " ,m_std_personaldetails_tbl spd where acd.group_id='" & group_id & "' and acd.subcourse_id='" & strsubCourseId & "' and acd.stud_id=SPD.stud_id and Division is null and Lib_card_no is null  and spd.stud_gender='" & Val(strGender) & "' and  acd.ayid='" & ACDID & "' AND acd.DEL_FLAG<>1  "
                    strselect = strselect + " order by spd.stud_l_name,spd.stud_f_name,spd.stud_m_name asc ";
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

    public void insertLog(string empid,string ipAddrs,string machineName,bool isLogin)
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
             cls.DMLqueries(insqry);
        }
        catch (Exception ex2)
        {
 
        }
    }

    public DataSet SearchEditRole(string name, string empid)
    {
      //  string SearchQry = " select emp_id as [Emp_id],emp_name as [Full Name],username as [Username],group_ids as[Groups]  from dbo.web_tp_login where emp_name like '%" + name + "%'and emp_id like '%" + empid + "%'";
        string SearchQry = "select l.emp_id as [Emp_id],NAME +' '+FATHER+' '+SURNAME as [Full Name],username as [Username],group_ids as[Groups]  from dbo.web_tp_login l inner join EmployeePersonal e on l.emp_id=e.emp_id  where NAME +' '+FATHER+' '+SURNAME  like  '%" + name + "%' and l.emp_id like '%"+empid +"%'";
        
        DataSet ds1 = cls.fillDataset(SearchQry);
        return ds1;
    }

    public bool updateLogin(string empid, string group)
    {
        bool val = false;
        string qryInsert = "update web_tp_login set group_ids='" + group + "'where emp_id='" + empid + "'";


        if (cls.DMLqueries(qryInsert))
        {
            //saved

            val = true;

        }
        else
        {
            //not saved
            val = false;

        }

        return val;
    }

    public bool checkDuplicatesRolename(string rolename)
    {
        string qry = "select * from dbo.web_tp_roletype where role_name='" + rolename + "' and is_active=1 and del_flag=0";
        DataSet dss = cls.fillDataset(qry);
        if (dss.Tables.Count > 0)
        {
            if (dss.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
        else
        {
            return false;
        }
    }

    public bool Inserform(string formname, string model)
    {

        bool i = false;

        string insQry = "insert into dbo.Register_Form values('" + formname.ToString().Trim() + "', '" + model.ToString() + "' , Null, Null, Null, 0, getdate(), getdate())";
        return i = cls.DMLqueries(insQry);

    }

    public bool UpdtRole(string role_name, string formname)
    {

        bool i = false;
        string updQry = "update dbo.web_tp_roletype set form_name='" + formname + "' where role_name='" + role_name + "'";

        return i = cls.DMLqueries(updQry);

    }

    public DataTable getgraphall(string p1, string p2, string p3, string p4, string date)
    {
        throw new NotImplementedException();
    }
   //add admission shweta
    public void getsubcourseadm(DropDownList ddl)
    {

       String qry = "select subcourse_name,subcourse_id from m_crs_subcourse_tbl where del_flag=0";
       
        DataSet dss = cls.fillDataset(qry);
        ddl.DataSource = dss.Tables[0];
        ddl.DataTextField = "subcourse_name";
        ddl.DataValueField = "subcourse_id";
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("-- Select --", "0"));
    }

    public void getgroupadm(DropDownList ddl)
    {

        //String qry = "select subcourse_name,subcourse_id from m_crs_subcourse_tbl where del_flag=0";
        string qry = "select group_id as subcourse_id,Group_title as subcourse_name  from m_crs_subjectgroup_tbl where Group_title not like '%2016%' and Group_title not like '%2017%' and Group_title not like '%2018%' and Group_title not like '%OLD%' and Group_title not like '%2015%' and  del_flag=0 and subcourse_id in (select subcourse_id from m_crs_subcourse_tbl where del_flag=0) order by Group_title";
        DataSet dss = cls.fillDataset(qry);
        ddl.DataSource = dss.Tables[0];
        ddl.DataTextField = "subcourse_name";
        ddl.DataValueField = "subcourse_id";
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("-- Select --", "0"));
    }

    public bool checkDuplicatesformname(string formname)
    {
        string qry = "select * from dbo.Register_Form where Form_Name='" + formname + "'  and [Del Flag]=0";
        DataSet dss = cls.fillDataset(qry);
        if (dss.Tables.Count > 0)
        {
            if (dss.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
        else
        {
            return false;
        }
    }

    public bool updRole(string role_id, string role_name, string formname)
    {

        bool i = false;
        string insQry = "update web_tp_roletype set form_name='" + formname + "' ,role_name='" + role_name + "' where role_id='" + role_id + "' ";

        return i = cls.DMLqueries(insQry);

    }
    public bool delRole(string role_id)
    {

        bool i = false;
        string insQry = "update web_tp_roletype set is_active=0 where role_id='" + role_id + "' ";

        return i = cls.DMLqueries(insQry);

    }
    public bool checkDuplicatesRolenameid(string roleid, string rolename)
    {
        string qry = "select * from dbo.web_tp_roletype where role_name='" + rolename + "'  and role_id!='" + roleid + "' and is_active=1 and del_flag=0";
        DataSet dss = cls.fillDataset(qry);
        if (dss.Tables.Count > 0)
        {
            if (dss.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
        else
        {
            return false;
        }
    }
    public DataSet studentdetails(string year, string faculty, string course, string subcourse, string group, bool flag)
    {
        String qry = "";
        if (flag == true)
        {
            qry = "select (a.Form_no+SUBSTRING(b.group_id,4,3))as Form_no,a.stud_id,(ISNULL(a.F_name,'')+' '+ISNULL(a.M_name,'')+' '+ISNULL(a.L_name,'')+' '+ ISNULL(a.Mo_name,'++')) as Name,f.Group_title from d_adm_applicant as a, OLA_FY_adm_CourseSelection as b ,m_crs_course_tbl as c,m_crs_subcourse_tbl as d,m_crs_subjectgroup_tbl as f ,m_crs_faculty as e where f.Subcourse_id=d.subcourse_id and c.course_id=d.course_id and e.faculty_id='" + faculty + "' and c.course_id='" + course + "' and d.subcourse_id='" + subcourse + "' and f.Group_id='" + group + "'and a.Form_no=b.formno and b.group_id=f.Group_id and a.ACDID='" + year + "' order by Form_no";
        }
        else
        {
            qry = "select (a.Form_no+SUBSTRING(b.group_id,4,3))as Form_no,a.stud_id,(ISNULL(a.F_name,'')+' '+ISNULL(a.M_name,'')+' '+ISNULL(a.L_name,'')) as Name,f.Group_title from d_adm_applicant as a, OLA_FY_adm_CourseSelection as b ,m_crs_course_tbl as c,m_crs_subcourse_tbl as d,m_crs_subjectgroup_tbl as f ,m_crs_faculty as e where f.Subcourse_id=d.subcourse_id and c.course_id=d.course_id and e.faculty_id='" + faculty + "' and c.course_id='" + course + "' and d.subcourse_id='" + subcourse + "' and f.Group_id='" + group + "'and a.Form_no=b.formno and b.group_id=f.Group_id and a.ACDID='" + year + "' order by Form_no";
        }
        DataSet dss = cls.fillDataset(qry);
        return dss;
    }

    public DataSet studentdetailsgroup(string year, bool flag)
    {
        String qry = "";
        if (flag == true)
        {
            qry = "select (a.Form_no+SUBSTRING(b.group_id,4,3))as Form_no,a.stud_id,(ISNULL(a.F_name,'')+' '+ISNULL(a.M_name,'')+' '+ISNULL(a.L_name,'')+' '+ ISNULL(a.Mo_name,'++')) as Name,f.Group_title from d_adm_applicant as a, OLA_FY_adm_CourseSelection as b ,m_crs_course_tbl as c,m_crs_subcourse_tbl as d,m_crs_subjectgroup_tbl as f ,m_crs_faculty as e where f.Subcourse_id=d.subcourse_id and c.course_id=d.course_id and  a.Form_no=b.formno and b.group_id=f.Group_id and a.ACDID='" + year + "' order by f.Group_title";
        }
        else
        {
            qry = "select (a.Form_no+SUBSTRING(b.group_id,4,3))as Form_no,a.stud_id,(ISNULL(a.F_name,'')+' '+ISNULL(a.M_name,'')+' '+ISNULL(a.L_name,'')) as Name,f.Group_title from d_adm_applicant as a, OLA_FY_adm_CourseSelection as b ,m_crs_course_tbl as c,m_crs_subcourse_tbl as d,m_crs_subjectgroup_tbl as f ,m_crs_faculty as e where f.Subcourse_id=d.subcourse_id and c.course_id=d.course_id and  a.Form_no=b.formno and b.group_id=f.Group_id and a.ACDID='" + year + "' order by f.Group_title";
        }
        DataSet dss = cls.fillDataset(qry);
        return dss;
    }

}

public class attendLogClass
{
    QueryClass qryObj = new QueryClass();
    Class1 cls = new Class1();

    public void getcourse(string grpIDs, DropDownList ddl)
    {
        string finalGrp = qryObj.splitGrp(grpIDs);
        String qry = "select * from m_crs_course_tbl where course_id in (select course_id from m_crs_subcourse_tbl where subcourse_id in (select subcourse_id from m_crs_subjectgroup_tbl where Group_id in (" + finalGrp + ")))";
        DataSet dss = cls.fillDataset(qry);
        ddl.DataSource = dss.Tables[0];
        ddl.DataTextField = "course_name";
        ddl.DataValueField = "course_id";
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("--select--", "0"));
    }

    public void get_Subcourse(string grpIDs, DropDownList ddl)
    {
        string finalGrp = qryObj.splitGrp(grpIDs);
        String qry = "select subcourse_id,subcourse_name from m_crs_subcourse_tbl where subcourse_id in (select subcourse_id from m_crs_subjectgroup_tbl where Group_id in (" + finalGrp + "))";
        DataSet dss = cls.fillDataset(qry);
        ddl.DataSource = dss.Tables[0];
        ddl.DataTextField = "subcourse_name";
        ddl.DataValueField = "subcourse_id";
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("--select--", "0"));
    }

    public void get_Subcourse_fee_rep(string cat,string grpIDs, DropDownList ddl)
    {
        string finalGrp = qryObj.splitGrp(grpIDs);
        String qry = "";
        if (cat != "")
        {
            qry = "select subcourse_id,subcourse_name from m_crs_subcourse_tbl where subcourse_id in (select subcourse_id from m_crs_subjectgroup_tbl where Group_id in (" + finalGrp + ")) and subcourse_name like '"+cat+"%'";
        }
        else
        {
            qry = "select subcourse_id,subcourse_name from m_crs_subcourse_tbl where subcourse_id in (select subcourse_id from m_crs_subjectgroup_tbl where Group_id in (" + finalGrp + ")) and subcourse_name not like 'F%' and subcourse_name not like 'S%' and subcourse_name not like 'T%' and subcourse_name not like 'M%'";
        }
        DataSet dss = cls.fillDataset(qry);
        ddl.DataSource = dss.Tables[0];
        ddl.DataTextField = "subcourse_name";
        ddl.DataValueField = "subcourse_id";
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("--select--", "0"));
    }
    
    public void getsubcourse(string grpIDs, DropDownList ddl)
    {
        string finalGrp = qryObj.splitGrp(grpIDs);
        String qry = "select sub.Group_id,sub.Group_title,msub.course_id,sub.Subcourse_id from m_crs_subjectgroup_tbl as sub,m_crs_subcourse_tbl as msub   where sub.Group_id  in (" + finalGrp + ") and sub.Group_title not like '%20%' and msub.subcourse_id=sub.Subcourse_id";
        //String qry = "select sub.Group_id,sub.Group_title,msub.course_id,sub.Subcourse_id from m_crs_subjectgroup_tbl as sub,m_crs_subcourse_tbl as msub   where sub.Group_id  in (select distinct group_id from  web_tp_access where emp_id='" + grpIDs + "' and ayid=(select max(ayid) from m_academic)) and msub.subcourse_id=sub.Subcourse_id";

        DataSet dss = cls.fillDataset(qry);
        string sub = dss.Tables[0].Rows[0]["Subcourse_id"].ToString();
        ddl.DataSource = dss.Tables[0];
        ddl.DataTextField = "Group_title";
        ddl.DataValueField = "Group_id";
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("--select--", "0"));
    }
    public void setSubGrp(string grpIDs, DropDownList ddl,string empid)
    {
        string finalGrp = qryObj.splitGrp(grpIDs);
        String qry = "select distinct a.group_id,s.Group_title from dbo.web_tp_access a,dbo.m_crs_subjectgroup_tbl s where a.group_id= s.Group_id and a.del_flag=0 and emp_id='" + empid + "' and a.ayid=(select max(ayid) from m_academic)";
        DataSet dss = cls.fillDataset(qry);
        ddl.DataSource = dss.Tables[0];
        ddl.DataTextField = "Group_title";
        ddl.DataValueField = "Group_id";
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("--select--", "0"));
    }

    public void LoadRoleSubjects(ListBox ls, string grpIDs, string subCrs)
    {
        string finalGrp = qryObj.splitGrp(grpIDs);
        string qry = "select s.Subject_Id,s.Subject_Name from dbo.d_crs_subjectgroup_tbl sg, dbo.m_crs_subject_tbl s where sg.Subject_id=s.Subject_Id and s.del_flag=0 and Group_id in (" + finalGrp + ") order by Subject_Name";
        if (subCrs != "")
        {
            qry = "select Subject_Id,Subject_Name from dbo.m_crs_subject_tbl where SubCourse_Id='" + subCrs + "' and del_flag=0 order by Subject_Name";
        }
        DataSet dss_subject_grp = cls.fillDataset(qry);
        if (dss_subject_grp.Tables[0].Rows.Count > 0)
        {
            //for (int i = 0; i < dss_subject_grp.Tables[0].Rows.Count; i++)
            //{
            //    ListItem item = new ListItem();
            //    item.Text = dss_subject_grp.Tables[0].Rows[i]["Subject_Name"].ToString();
            //    item.Value = dss_subject_grp.Tables[0].Rows[i]["Subject_Id"].ToString();
            //    ls.Items.Add(item);
            //}
            ls.DataSource = dss_subject_grp.Tables[0];
            ls.DataTextField = "Subject_Name";
            ls.DataValueField = "Subject_Id";
            ls.DataBind();
        }
        else
        {
            ls.DataSource = null;
            ls.DataBind();
        }
    }


    
}

//salary statement
public class salary
{
    public string empid { get; set; }
    public string empname { get; set; }
    public string totaldays { get; set; }
    public string presentdays { get; set; }
    public string totalpay { get; set; }
    public string payband { get; set; }
    public string convegnce { get; set; }
    public string basic { get; set; }
    public string hra { get; set; }
    public string otherall { get; set; }
    public string total { get; set; }
    public string netotal { get; set; }
    public string allownce { get; set; }
    public string doj { get; set; }
    public string msg { get; set; }
    public string designation { get; set; }
    public string total_days { get; set; }
    public string PresentDay { get; set; }
    public string Pay_band { get; set; }
    public string total_pay { get; set; }
    public string Basic { get; set; }
    public string HRA { get; set; }
    public string Conveyance { get; set; }
    public string other_all { get; set; }
    public string basictot { get; set; }
    public string lastmntbal { get; set; }
    public string lastmnttot { get; set; }
    public string PT { get; set; }
    public string TDS { get; set; }
    public string lastmntded { get; set; }
    public string tot_deduc { get; set; }
    public string NET { get; set; }
    public string bankacc_no { get; set; }
    public string type { get; set; }
    public string da { get; set; }
    public string cla { get; set; }
    public string nofhours { get; set; }
    public string rateperhr { get; set; }
    public string roleid { get; set; }
    public string rank { get; set; }

    public string exist_basic { get; set; }
    public string agp { get; set; }
    public string incr_basc { get; set; }
    public string new_basic { get; set; }
    public string dp_agp { get; set; }

    public string annual_sal { get; set; }
    public string total2 { get; set; }
    public string ta { get; set; }
    public string others { get; set; }
    public string others2 { get; set; }
    public string gross_sal { get; set; }
    public string arrears { get; set; }
    public string tot_sal { get; set; }
    public string pf_an { get; set; }
    public string pf_ded { get; set; }
    public string pt { get; set; }
    public string tds { get; set; }
    public string tot_ded { get; set; }
    public string net_sal { get; set; }
    public string pf_contr { get; set; }
    public string tot_contr { get; set; }
    public string tot_salary { get; set; }
    public string remarks { get; set; }
    public string present_days { get; set; }
}


public class accessClass 
{
    public string empid { get; set; }
    public string ayid { get; set; }
    public string groupid { get; set; }
    public string divBatch { get; set; }
    public string subid { get; set; }
    public string semid { get; set; }
    public string dmlType { get; set; }
}

public class employee
{

    public string department { get; set; }
    public string bloodgrp { get; set; }
    public string msg { get; set; }
    public string fname { get; set; }
    public string mname { get; set; }
    public string lname { get; set; }
    public string mothername { get; set; }
    public string salary { get; set; }
    public string emailid { get; set; }
    public string deptid { get; set; }
    public string desigid { get; set; }
    public string mobileno { get; set; }
    public string empid { get; set; }
    public string mobile2 { get; set; }
    public string gender { get; set; }
    public string dob { get; set; }
    public string dojoin { get; set; }
    public string address { get; set; }
    public string bloodgroup { get; set; }
    public string marrst { get; set; }
    public string category { get; set; }
    public string caste { get; set; }
    public string phone { get; set; }
    public string pfno { get; set; }
    public string ration { get; set; }
    public string election { get; set; }
    public string driving { get; set; }
    public string panno { get; set; }
    public string religion { get; set; }
    public string desig { get; set; }
    public string nativadd { get; set; }
    public string nativst { get; set; }
    public string state { get; set; }
    public string pincode { get; set; }
    public string degree { get; set; }
    public string eclass { get; set; }
    public string educnt { get; set; }
    public string course { get; set; }
    public string aadharno { get; set; }
    public string bank_accno { get; set; }
    public string branch { get; set; }
    public string council { get; set; }
    public string validity { get; set; }
    public string semcount { get; set; }
    public string PAPER { get; set; }
    public string SEMINAR { get; set; }
    public string logincat { get; set; }
    public string role { get; set; }
    public string grouplist { get; set; }
    public string form_name { get; set; }
    public string form_id { get; set; }
    public string module { get; set; }
}

//public class reservation

//    public class reservation
//{

//    public string totall { get; set; }
//    public string tot_in { get; set; }
//    public string tot_out { get; set; }

//    public string per_open { get; set; }
//    public string per_st { get; set; }
//    public string per_sc { get; set; }
//    public string per_vg { get; set; }
//    public string per_ntb { get; set; }
//    public string per_ntc { get; set; }
//    public string per_ntd { get; set; }
//    public string per_obc { get; set; }


//    //minimum cutoff
//    public string INcutOPEN { get; set; }
//    public string INcutSC  { get; set; }
//     public string INcutST { get; set; }
//      public string INcutVJDT { get; set; }
//     public string  INcutNTb { get; set; }
//      public string INcutNTc { get; set; }
//      public string INcutNTd { get; set; }
//      public string  INcutOBC { get; set; }
//      public string INcutsebc { get; set; }
            
//     public string outcutOPEN { get; set; }
//     public string outcutSC  { get; set; }
//     public string outcutST { get; set; }
//      public string outcutVJDT { get; set; }
//      public string outcutNTb { get; set; }
//      public string outcutNTc { get; set; }
//      public string outcutNTd { get; set; }
//      public string outcutOBC { get; set; }
//      public string outcutsebc { get; set; }

//    //maximum cutoff
//      public string INcutOPENmax { get; set; }
//      public string INcutSCmax { get; set; }
//      public string INcutSTmax { get; set; }
//      public string INcutVJDTmax { get; set; }
//      public string INcutNTbmax { get; set; }
//      public string INcutNTcmax { get; set; }
//      public string INcutNTdmax { get; set; }
//      public string INcutOBCmax { get; set; }
//      public string INcutsebcmax { get; set; }

//      public string outcutOPENmax { get; set; }
//      public string outcutSCmax { get; set; }
//      public string outcutSTmax { get; set; }
//      public string outcutVJDTmax { get; set; }
//      public string outcutNTbmax { get; set; }
//      public string outcutNTcmax { get; set; }
//      public string outcutNTdmax { get; set; }
//      public string outcutOBCmax { get; set; }
//      public string outcutsebcmax { get; set; }
    
//    public string mgmt { get; set; }
//    public string remain { get; set; }
//    public string open { get; set; }
//    public string sc { get; set; }
//    public string st { get; set; }
//    public string vjdt { get; set; }
//    public string ntb { get; set; }
//    public string ntc { get; set; }
//    public string ntd { get; set; }
//    public string obc { get; set; }
//    public string sebc { get; set; }

//    public string msg { get; set; }

//    public string in_open { get; set; }
//    public string in_sc { get; set; }
//    public string in_st { get; set; }
//    public string in_vjdt { get; set; }
//    public string in_ntb { get; set; }
//    public string in_ntc { get; set; }
//    public string in_ntd { get; set; }
//    public string in_obc { get; set; }
//    public string in_sebc { get; set; }

//    public string out_open { get; set; }
//    public string out_sc { get; set; }
//    public string out_st { get; set; }
//    public string out_vjdt { get; set; }
//    public string out_ntb { get; set; }
//    public string out_ntc { get; set; }
//    public string out_ntd { get; set; }
//    public string out_obc { get; set; }
//    public string out_sebc { get; set; }

//    public string intake { get; set; }
//    public string group { get; set; }
//    public string grp_id { get; set; }

//}

    public class reservation
    {

        public string totall { get; set; }
        public string tot_in { get; set; }
        public string tot_out { get; set; }

        public string per_open { get; set; }
        public string per_st { get; set; }
        public string per_sc { get; set; }
        public string per_vg { get; set; }
        public string per_ntb { get; set; }
        public string per_ntc { get; set; }
        public string per_ntd { get; set; }
        public string per_obc { get; set; }


        //minimum cutoff
        public string INcutOPEN { get; set; }
        public string INcutSC { get; set; }
        public string INcutST { get; set; }
        public string INcutVJDT { get; set; }
        public string INcutNTb { get; set; }
        public string INcutNTc { get; set; }
        public string INcutNTd { get; set; }
        public string INcutOBC { get; set; }
        public string INcutsebc { get; set; }
        public string INcutsbc { get; set; }

        public string outcutOPEN { get; set; }
        public string outcutSC { get; set; }
        public string outcutST { get; set; }
        public string outcutVJDT { get; set; }
        public string outcutNTb { get; set; }
        public string outcutNTc { get; set; }
        public string outcutNTd { get; set; }
        public string outcutOBC { get; set; }
        public string outcutsebc { get; set; }
        public string outcutsbc { get; set; }

        //maximum cutoff
        public string INcutOPENmax { get; set; }
        public string INcutSCmax { get; set; }
        public string INcutSTmax { get; set; }
        public string INcutVJDTmax { get; set; }
        public string INcutNTbmax { get; set; }
        public string INcutNTcmax { get; set; }
        public string INcutNTdmax { get; set; }
        public string INcutOBCmax { get; set; }
        public string INcutsebcmax { get; set; }
        public string INcutsbcmax { get; set; }

        public string outcutOPENmax { get; set; }
        public string outcutSCmax { get; set; }
        public string outcutSTmax { get; set; }
        public string outcutVJDTmax { get; set; }
        public string outcutNTbmax { get; set; }
        public string outcutNTcmax { get; set; }
        public string outcutNTdmax { get; set; }
        public string outcutOBCmax { get; set; }
        public string outcutsebcmax { get; set; }
        public string outcutsbcmax { get; set; }

        public string mgmt { get; set; }
        public string remain { get; set; }
        public string open { get; set; }
        public string sc { get; set; }
        public string st { get; set; }
        public string vjdt { get; set; }
        public string ntb { get; set; }
        public string ntc { get; set; }
        public string ntd { get; set; }
        public string obc { get; set; }
        public string sebc { get; set; }
        public string sbc { get; set; }

        public string msg { get; set; }

        public string in_open { get; set; }
        public string in_sc { get; set; }
        public string in_st { get; set; }
        public string in_vjdt { get; set; }
        public string in_ntb { get; set; }
        public string in_ntc { get; set; }
        public string in_ntd { get; set; }
        public string in_obc { get; set; }
        public string in_sebc { get; set; }
        public string in_sbc { get; set; }

        public string out_open { get; set; }
        public string out_sc { get; set; }
        public string out_st { get; set; }
        public string out_vjdt { get; set; }
        public string out_ntb { get; set; }
        public string out_ntc { get; set; }
        public string out_ntd { get; set; }
        public string out_obc { get; set; }
        public string out_sebc { get; set; }
        public string out_sbc { get; set; }

        public string intake { get; set; }
        public string group { get; set; }
        public string grp_id { get; set; }

    }

public class studentDetailClass
{
    public string rollno { get; set; }
    public string studid { get; set; }
    public string name { get; set; }
    public string div { get; set; }
    public string batch { get; set; }
}

public class LogDetailClass
{
    public string logid { get; set; }
    public string empid { get; set; }
    public string empname { get; set; }
    public string subid { get; set; }
    public string subname { get; set; }
    public string divBatchid { get; set; }
    public string logtype { get; set; }
    public string grpid { get; set; }
    public string grpname { get; set; }
    public string semid { get; set; }
    public string ayid { get; set; }
    public string remark { get; set; }
    public string strtime { get; set; }
    public string endtime { get; set; }
    public string endtime1 { get; set; }

    public studArrayClassEdit[] studarray { get; set; }
}


public class overallbill
{
    public string staff_id { get; set; }
    public string emp_name { get; set; }
    public string emp_acc { get; set; }
    public string ans { get; set; }
    public string billno { get; set; }
    public string jun_sup { get; set; }
    public string sen_sup { get; set; }
    public string chief_con { get; set; }

    public string paper_set { get; set; }
    public string asses { get; set; }
    public string reval { get; set; }
    public string trans { get; set; }
    public string moderation { get; set; }
    public string inter { get; set; }
    public string practs { get; set; }
    public string proof { get; set; }
    public string totall { get; set; }
    public string msg { get; set; }
}

public class logClass
{
    public string empid { get; set; }
    public string subid { get; set; }
    public string divBatch { get; set; }
    public string ayid { get; set; }
    public string groupid { get; set; }
    public string semid { get; set; }
    public string logType { get; set; }
    public string dmlType { get; set; }
    public string remarkEmp { get; set; }
    public studArrayClass[] studarray { get; set; }
    public string strTime { get; set; }
    public string endTime { get; set; }
    public string logidParam { get; set; }
}

//public class studlog
//{
//    public bool isPresent { get; set; }
//    public string studid { get; set; }
//    public string remark { get; set; }
//}

public class logCollection : List<studArrayClass>, IEnumerable<SqlDataRecord>
{
    IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
    {
        SqlDataRecord sqlRow = new SqlDataRecord(
              new SqlMetaData("isPresent", SqlDbType.Bit),
              new SqlMetaData("studid", SqlDbType.VarChar, 15),
              new SqlMetaData("remark", SqlDbType.VarChar, 500));
        
        foreach (studArrayClass log in this)
        {
            sqlRow.SetBoolean(0, log.isPresent);
            sqlRow.SetString(1, log.studid);
            if (log.remark == null)
            {
               // string remark="";
                sqlRow.SetString(2, "");
            }
            else
            {
            sqlRow.SetString(2, log.remark);
            }
            yield return sqlRow;
        }
    }
}

public class studArrayClass
{
    public bool isPresent { get; set; }
    public string studid { get; set; }
    public string remark { get; set; }
}

public class studArrayClassEdit
{
    public bool isPresent { get; set; }
    public string studid { get; set; }
    public string remark { get; set; }
    public string studName { get; set; }
    public string rollno { get; set; }
}
    //new add


public class studentDetailfee
{
    public string AYID { get; set; }

    public string Roll_no { get; set; }
    public string stud_id { get; set; }
    public string Student_Name { get; set; }
    public string Gender { get; set; }
    public string stud_Category { get; set; }
    public string CourseFees { get; set; }
    public string subcourse_name { get; set; }
    public string FeesPaid { get; set; }
    public string Group_title { get; set; }
    public string FeesBal { get; set; }
    public string Remark { get; set; }
    public string Authorized_By { get; set; }
   public string Recpt_mode { get; set; }
    public string Amount { get; set; }
    public string Chq_status { get; set; }
    public string Recpt_Chq_No { get; set; }
    public string Recpt_Bnk_Name { get; set; }
    public string Recpt_Bnk_Branch { get; set; }
    public string Recpt_Chq_dt { get; set; }

    
}
public class studentDetailfee_transac
{
    public string AYID { get; set; }

    public string stud_id { get; set; }
    public string Recpt_mode { get; set; }
    public string Amount { get; set; }
    public string Chq_status { get; set; }
    public string Recpt_Chq_No { get; set; }
    public string Recpt_Bnk_Name { get; set; }
    public string Recpt_Bnk_Branch { get; set; }
    public string Recpt_Chq_dt { get; set; }
}
//shweta professional_exp
public class empexperirnce
{
    public string empid { get; set; }
    public string emp_previous_organization { get; set; }
    public string emp_previous_designation { get; set; }
    public string emp_previous_job_dept { get; set; }
    public int emp_previous_salary { get; set; }
    public string emp_previous_job_from { get; set; }
    public string emp_previous_job_to { get; set; }
    public string status { get; set; }
    public string Period { get; set; }
}
public class logreport
{
    public string log_id { get; set; }
    public string subject_name { get; set; }
    public string log_type { get; set; }
    public string Group_title { get; set; }
    public string div_batch_id { get; set; }
    public string start_time { get; set; }
    public string end_time { get; set; }
    public string remark { get; set; }


}
//define eligibility prtima

public class EligibilityClass
{
    public string studid { get; set; }
    public string name { get; set; }
    public string sem1_cg { get; set; }
    public string sem1_ce { get; set; }
    public string sem1_sgpi { get; set; }
    public string sem2_cg { get; set; }
    public string sem2_ce { get; set; }
    public string sem2_sgpi { get; set; }
    public string sem3_cg { get; set; }
    public string sem3_ce { get; set; }
    public string sem3_sgpi { get; set; }
    public string sem4_cg { get; set; }
    public string sem4_ce { get; set; }
    public string sem4_sgpi { get; set; }
    public string sem5_cg { get; set; }
    public string sem5_ce { get; set; }
    public string sem5_sgpi { get; set; }
    public string sem6_cg { get; set; }
    public string sem6_ce { get; set; }
    public string sem6_sgpi { get; set; }
    public string sem1_KT { get; set; }
    public string sem2_KT { get; set; }
    public string sem3_KT { get; set; }
    public string sem4_KT { get; set; }
    public string sem5_KT { get; set; }
    public string sem6_KT { get; set; }
    public string Status { get; set; }
    public string formfilled { get; set; }
    public string exist { get; set; }
    public string type { get; set; }
    public string roll_no { get; set; }
    public string prn_no { get; set; }
    public string sem1_total { get; set; }
    public string sem2_total { get; set; }
    public string sem3_total { get; set; }
    public string sem4_total { get; set; }
    public string sem1_grade { get; set; }
    public string sem2_grade { get; set; }
    public string sem3_grade { get; set; }
    public string sem4_grade { get; set; }
    //public string eligible { get; set; }
}

//Eligibility form
//public class Modal_class
//{
//    public string Name { get; set; }
//    public string ayid { get; set; }
//    public string duration { get; set; }
//    public string subcourse { get; set; }
//    public string course { get; set; }
//    public string group_title { get; set; }
//    public string grp_id { get; set; }
//    public string sub_crs_id { get; set; }
//    public string roll_no { get; set; }
//    public string msg { get; set; }

//}

//karishma block and partpay
public class BlockStudent
{
    public string Roll_no { get; set; }
    public string stud_id { get; set; }
    public string NAME { get; set; }
    public string Group_title { get; set; }
    public string isblocked { get; set; }
    public string reason { get; set; }
    public string block_dt { get; set; }
    public string emp_id { get; set; }

    public string department { get; set; }

}

public class PartPaymentStudent
{
    public string isinhouse { get; set; }
    public string file_ex { get; set; }
    public string Roll_no { get; set; }
    public string stud_id { get; set; }
    public string NAME { get; set; }
    public string Group_title { get; set; }
    public string group_id { get; set; }
    public string Formno { get; set; }
    public string gender { get; set; }
    public string isallowed { get; set; }
    public string allow_amt { get; set; }
    public string remark { get; set; }

    public string empname { get; set; }
    public string empid { get; set; }

    public string curr_dt { get; set; }
    public string stud_Category { get; set; }

    public string stud_Caste { get; set; }
    public string admissionstatus { get; set; }
    public string freeship_Date { get; set; }
    public string admission_date { get; set; }

}



//shweta ADMISSION CONFIRM
//new add for feeentry
public class STUDENTFEES
{
    public string authcaste { get; set; }
public string     narryear{ get; set; }
public string paymode{ get; set; }

public string chqstatus { get; set; }
public int flagchk { get; set; }

public string refdet { get; set; }
    public string structype { get; set; }
    public string CRSAMOUNT { get; set; }
    public string STUDENTID { get; set; }
    public string STRUCTURE { get; set; }
    public string YEAR { get; set; }
    public string ayid { get; set; }
    public string AMOUNT { get; set; }
    public string PAID { get; set; }
    public string DIFFERNCE { get; set; }
    public string REFUND { get; set; }
    public string REFUNDED { get; set; }
    public string PAYDATE { get; set; }
    public string AUTHORIZEDBY { get; set; }
    public string RECIPTMODE { get; set; }
    public string curr_dt { get; set; }
    public string task { get; set; }
    public string type { get; set; }
    public string Recpt_Chq_dt { get; set; }
    public string Recpt_Chq_No { get; set; }
    public string Recpt_Bnk_Name { get; set; }
    public string Recpt_Bnk_Branch { get; set; }

    public int STATUS12 { get; set; }
    public int REMARK12 { get; set; }

    public string REMARK { get; set; }
    public string RECIPTNO { get; set; }
    public string STATUS { get; set; }
    public string message { get; set; }
    public string feecount { get; set; }
    public string Course_tot_fees { get; set; }
    public string course_fee_paid { get; set; }
}


public class admission
{
    public string Recpt_Bnk_Name2 { get; set; }
    public string Recpt_Bnk_Branch2 { get; set; }

    public string Recpt_Chq_No2 { get; set; }
    public string Recpt_Chq_dt2 { get; set; }
    public string name { get; set; }
    public string formid { get; set; }
    public string lname { get; set; }
    public string fname { get; set; }
    public string mname { get; set; }
    public string dob { get; set; }
    public string ddlfaculty { get; set; }
    public string ddlcourse { get; set; }
    public string ddlsubcourse { get; set; }
    public string ddlgroup { get; set; }
    public string ddlfacultyname { get; set; }
    public string ddlcoursename { get; set; }
    public string ddlsubcoursename { get; set; }
    public string ddlgroupname { get; set; }
    public string ddloldgroupname { get; set; }
    public string stud_id { get; set; }
    public string oldstud_id { get; set; }
    public int Course_tot_fees { get; set; }
    public int course_fee_paid { get; set; }

    public int Course_fee_Bal { get; set; }
    public string Pay_date { get; set; }
    public string category { get; set; }
    public int amount { get; set; }
    public string messege { get; set; }
    public string intakemessege { get; set; }
    public string chkMeritListDate { get; set; }
    public string fyid { get; set; }
    public string receiptno { get; set; }
    public int feecount { get; set; }

    public string reciptmode1 { get; set; }
    public string Amount1 { get; set; }
    public string Chq_status1 { get; set; }
    public string Recpt_Chq_No1 { get; set; }
    public string Recpt_Bnk_Name1 { get; set; }
    public string Recpt_Bnk_Branch1 { get; set; }
    public string Recpt_Chq_dt1 { get; set; }
    public string card_no { get; set; }

    public string Remark1 { get; set; }
    public string Authorized_By1 { get; set; }

    public string AYID1 { get; set; }
    public string type1 { get; set; }
    public string user_id1 { get; set; }

    //FEES
    public string Struct_name { get; set; }
}
//shweta ADMISSION CONFIRM
//public class studentmodify
//{
//    public string Duration { get; set; }

//    public string updateqry { get; set; }

//    public string updatewwqry { get; set; }
//    public string scholarship_name { get; set; }
//    public string member_of_ncc { get; set; }
//    public string propose_scholarship { get; set; }
//    public string extra_activity { get; set; }
//    public string If_PHYSICALALLY_RESERVED { get; set; }
//    public string Course { get; set; }
//    public string Courseid { get; set; }

//    public string Class { get; set; }

//    public string img { get; set; }
//    public string stud_Grno { get; set; }
//    public string stud_F_name { get; set; }
//    public string stud_M_name { get; set; }
//    public string stud_L_name { get; set; }
//    public string name { get; set; }
//    public string stud_Birthplace { get; set; }
//    public string bank_Acc { get; set; }
//    public string ifsc_no { get; set; }
//    public string stud_DomiciledIn { get; set; }
//    public string stud_Email { get; set; }
//    public string stud_PermanentAdd { get; set; }
//    public string stud_PermanentPhone { get; set; }
//    public string stud_PermanentPincode { get; set; }
//    public string stud_NativeAdd { get; set; }
//    public string stud_NativePhone { get; set; }
//    public string stud_NativePincode { get; set; }
//    public string stud_Earning { get; set; }
//    public string stud_NonEarning { get; set; }
//    public string stud_othercriteria { get; set; }
//    public int stud_NoOfFamilyMembers { get; set; }
//    public int stud_YearlyIncome { get; set; }

//    public string stud_Father_Occupation { get; set; }
//    public string stud_Father_BusinessServiceAdd { get; set; }
//    public string stud_Father_TelNo { get; set; }
//    public string stud_Father_FName { get; set; }
//    public string messege { get; set; }
//    public string stud_Father_MName { get; set; }
//    public string stud_Father_LName { get; set; }
//    public string stud_Father_ResidentAdd { get; set; }
//    public string stud_Mother_BusinessServiceAdd { get; set; }
//    public string stud_Mother_Occupation { get; set; }
//    public string stud_Mother_TelNo { get; set; }
//    public string stud_Mother_FName { get; set; }
//    public string stud_Mother_MName { get; set; }
//    public string stud_Mother_LName { get; set; }
//    public string stud_Mother_ResidentAdd { get; set; }
//    public string stud_Gaurd_FName { get; set; }
//    public string stud_Gaurd_MName { get; set; }
//    public string stud_Gaurd_LName { get; set; }
//    public string stud_Gaurd_Add { get; set; }
//    public string stud_Gaurd_TelNo { get; set; }
//    public string stud_State { get; set; }
//    public string stud_District { get; set; }
//    public string stud_Taluka { get; set; }
//    public string stud_Gender { get; set; }
//    public string stud_BloodGroup { get; set; }
//    public string stud_MotherTounge { get; set; }
//    public string stud_Nationality { get; set; }

//    public string stud_NativeState { get; set; }

//    public string stud_NativeCity { get; set; }

//    public string stud_PermanentState { get; set; }

//    public string stud_PermanentCity { get; set; }
//    public string stud_Category { get; set; }
//    public string stud_Caste { get; set; }
//    public string stud_SubCaste { get; set; }
//    public string stud_MartialStatus { get; set; }
//    public string stud_Religion { get; set; }
//    public string stud_DOB { get; set; }
//    public string stud_mobileno { get; set; }


//    public string stud_id { get; set; }
//    public string fyid { get; set; }
//    public string Max_ACDID { get; set; }
//    public string Max_ACDID_Duration { get; set; }
//    public string transfermessege { get; set; }
//    public string year { get; set; }
//    public string year1 { get; set; }
//    public string from_Subcourse_id { get; set; }
//    public string Group_Id { get; set; }
//    public string Group_Name { get; set; }
//    public string Group_title { get; set; }
//    public string nextgroup { get; set; }
//    public string Div { get; set; }
//    public string Roll_no { get; set; }
//    public string Marks_Obtained { get; set; }
//    public string Out_Of_Mks { get; set; }
//    public string Remark { get; set; }
//    public string To_Subcourse_id { get; set; }
//    public string To_Subcourse_name { get; set; }

//    public bool bolupdate { get; set; }
//    public string castmessege { get; set; }
//    public int castflag { get; set; }



//    public int Course_tot_fees { get; set; }
//    public int course_fee_paid { get; set; }

//    public int Course_fee_Bal { get; set; }
//    public string Pay_date { get; set; }
//    public string category { get; set; }
//    public int amount { get; set; }

//    public int feecount { get; set; }

//    public int allow_amt { get; set; }
//    public string allow_amt1 { get; set; }
//    public bool allow_freeship { get; set; }


//    public string stud_aadhar { get; set; }
//    public string stud_voterid { get; set; }
//    public string stud_Father_aadhar { get; set; }
//    public string stud_Father_voterid { get; set; }
//    public string stud_Mother_aadhar { get; set; }
//    public string stud_Mother_voterid { get; set; }
//    public string stud_Gaurd_aadhar { get; set; }
//    public string stud_Guard_voterid { get; set; }
//}

//sukant 
public class studentmodify
{
    public string Duration { get; set; }

    public string updateqry { get; set; }

    public string updatewwqry { get; set; }
    public string scholarship_name { get; set; }
    public string member_of_ncc { get; set; }
    public string propose_scholarship { get; set; }
    public string extra_activity { get; set; }
    public string If_PHYSICALALLY_RESERVED { get; set; }
    public string Course { get; set; }
    public string Courseid { get; set; }

    public string Class { get; set; }

    public string img { get; set; }
    public string stud_Grno { get; set; }
    public string stud_F_name { get; set; }
    public string stud_M_name { get; set; }
    public string stud_L_name { get; set; }
    public string name { get; set; }
    public string stud_Birthplace { get; set; }
    public string bank_Acc { get; set; }
    public string ifsc_no { get; set; }
    public string stud_DomiciledIn { get; set; }
    public string stud_Email { get; set; }
    public string stud_PermanentAdd { get; set; }
    public string stud_PermanentPhone { get; set; }
    public string stud_PermanentPincode { get; set; }
    public string stud_NativeAdd { get; set; }
    public string stud_NativePhone { get; set; }
    public string stud_NativePincode { get; set; }
    public string stud_Earning { get; set; }
    public string stud_NonEarning { get; set; }
    public string stud_othercriteria { get; set; }
    public int stud_NoOfFamilyMembers { get; set; }
    public int stud_YearlyIncome { get; set; }

    public string stud_Father_Occupation { get; set; }
    public string stud_Father_BusinessServiceAdd { get; set; }
    public string stud_Father_TelNo { get; set; }
    public string stud_Father_FName { get; set; }
    public string messege { get; set; }
    public string stud_Father_MName { get; set; }
    public string stud_Father_LName { get; set; }
    public string stud_Father_ResidentAdd { get; set; }
    public string stud_Mother_BusinessServiceAdd { get; set; }
    public string stud_Mother_Occupation { get; set; }
    public string stud_Mother_TelNo { get; set; }
    public string stud_Mother_FName { get; set; }
    public string stud_Mother_MName { get; set; }
    public string stud_Mother_LName { get; set; }
    public string stud_Mother_ResidentAdd { get; set; }
    public string stud_Gaurd_FName { get; set; }
    public string stud_Gaurd_MName { get; set; }
    public string stud_Gaurd_LName { get; set; }
    public string stud_Gaurd_Add { get; set; }
    public string stud_Gaurd_TelNo { get; set; }
    public string stud_State { get; set; }
    public string stud_District { get; set; }
    public string stud_Taluka { get; set; }
    public string stud_Gender { get; set; }
    public string stud_BloodGroup { get; set; }
    public string stud_MotherTounge { get; set; }
    public string stud_Nationality { get; set; }

    public string stud_NativeState { get; set; }

    public string stud_NativeCity { get; set; }

    public string stud_PermanentState { get; set; }

    public string stud_PermanentCity { get; set; }
    public string stud_Category { get; set; }
    public string stud_Caste { get; set; }
    public string stud_SubCaste { get; set; }
    public string stud_MartialStatus { get; set; }
    public string stud_Religion { get; set; }
    public string stud_DOB { get; set; }
    public string stud_mobileno { get; set; }


    public string stud_id { get; set; }
    public string fyid { get; set; }
    public string Max_ACDID { get; set; }
    public string Max_ACDID_Duration { get; set; }
    public string transfermessege { get; set; }
    public string year { get; set; }
    public string year1 { get; set; }
    public string from_Subcourse_id { get; set; }
    public string Group_Id { get; set; }
    public string Group_Name { get; set; }
    public string Group_title { get; set; }
    public string nextgroup { get; set; }
    public string Div { get; set; }
    public string Roll_no { get; set; }
    public string Marks_Obtained { get; set; }
    public string Out_Of_Mks { get; set; }
    public string Remark { get; set; }
    public string To_Subcourse_id { get; set; }
    public string To_Subcourse_name { get; set; }

    public bool bolupdate { get; set; }
    public string castmessege { get; set; }
    public int castflag { get; set; }



    public int Course_tot_fees { get; set; }
    public int course_fee_paid { get; set; }

    public int Course_fee_Bal { get; set; }
    public string Pay_date { get; set; }
    public string category { get; set; }
    public int amount { get; set; }

    public int feecount { get; set; }

    public int allow_amt { get; set; }
    public string allow_amt1 { get; set; }
    public bool allow_freeship { get; set; }


    public string stud_aadhar { get; set; }
    public string stud_voterid { get; set; }
    public string stud_Father_aadhar { get; set; }
    public string stud_Father_voterid { get; set; }
    public string stud_Mother_aadhar { get; set; }
    public string stud_Mother_voterid { get; set; }
    public string stud_Gaurd_aadhar { get; set; }
    public string stud_Guard_voterid { get; set; }
}


public class roll_col
{
    public string phone_no { get; set; }
    public string prn { get; set; }
    public string std_email { get; set; }
    public string id { get; set; }
    public string name { get; set; }
    public string mother_name { get; set; }
    public string univ_no { get; set; }
    public string roll_no { get; set; }
    public string amt_paid { get; set; }
    public string appli_no { get; set; }
    public string bal_amt { get; set; }
    public string gender { get; set; }
    public string category { get; set; }
    public string hsc_per { get; set; }
    public string msg { get; set; }
}

public class castewise_rpt
{
    public string course { get; set; }
    public string fees { get; set; }
    public string totaladmission { get; set; }
    public string scg { get; set; }
    public string scb { get; set; }
    public string stg { get; set; }
    public string stb { get; set; }
    public string dtg { get; set; }
    public string dtb { get; set; }
    public string ntg { get; set; }
    public string ntb { get; set; }
    public string obcg { get; set; }
    public string obcb { get; set; }
    public string sbcg { get; set; }
    public string sbcb { get; set; }
    public string tg { get; set; }
    public string tb { get; set; }
    public string total { get; set; }
    public string grossfees { get; set; }
    public string subcourse { get; set; }

}

public class dynamicShowPanel
{

    public string field_type { get; set; }

    public string value { get; set; }

    public string field_display { get; set; }

}

//fees_entry


public enum Enum_GenDtls
{
    State = 101,
    City = 102,
    Taluka = 103,
    District = 104,
    Cast = 105,
    SubCast = 106,
    Religion = 107,
    Mothertounge = 108,
    Nationality = 109,
    Prev_Acd_Record = 110,
    Category = 111,
    Board = 112,
    SrNo = 113,
    Document = 114,
    Exam = 115,
    Bank_Name = 116,
    Branch_Name = 117,
    Degree_Name = 118
}

public class fee_report_gen
{
    public string id { get; set; }
    public string paydate { get; set; }
    public string Name { get; set; }
    public string ayid { get; set; }
    public string course_id { get; set; }
    public string grp_id { get; set; }
    public string sub_crs_id { get; set; }
    public string roll_no { get; set; }
    public string category { get; set; }
    public string part_pay { get; set; }
    public string amnt_paid { get; set; }
    public string balance { get; set; }
    public string crs_fee { get; set; }
    public string refund_amt { get; set; }
    public string installment { get; set; }
    public string remark { get; set; }
    public string status { get; set; }
    public string gender { get; set; }
    public string group_title { get; set; }
    public string colname { get; set; }
    public string colvalue { get; set; }
    public string totalparticulars { get; set; }
    public string totalfeespay { get; set; }
    public string totalcoursefees { get; set; }
    public string totalbal { get; set; }
    public string totalrefund { get; set; }


    public string stud_id { get; set; }
    public string Recpt_mode { get; set; }
    public string Amount { get; set; }
    public string Chq_status { get; set; }
    public string Recpt_Chq_No { get; set; }
    public string Recpt_Bnk_Name { get; set; }
    public string Recpt_Bnk_Branch { get; set; }
}

public class bank_details
{
    public string id { get; set; }
    public string Name { get; set; }
    public string grp_title { get; set; }
    public string amnt { get; set; }
    public string dd_dt { get; set; }
    public string type { get; set; }
    public string dd_no { get; set; }
    public string bnk_name { get; set; }
    public string bnk_branch { get; set; }
    public string bnk_user_id { get; set; }
}

public class studcountbank
{

    public string StudentCount { get; set; }

    public string amount { get; set; }


}

public class admissionfeereport
{
    public string stud_id { get; set; }

    public string Name { get; set; }
    public string Group_title { get; set; }
    public string amount { get; set; }
    public string remark { get; set; }
    public string Authorized_By { get; set; }
    public string Admission_Date { get; set; }


}

public class freeshipReport
{
    public string id { get; set; }
    public string Name { get; set; }
    public string grp_title { get; set; }
    public string amnt { get; set; }
    public string adm_dt { get; set; }
    public string free_dt { get; set; }
    public string category { get; set; }
    public string status { get; set; }
    public string msg { get; set; }
    public string ayid { get; set; }
    public string Remark { get; set; }
    public string givenRmk { get; set; }
    public string rollno { get; set; }
    public string Course_tot_fees { get; set; }
    public string Tot_fees_paid { get; set; }
    public string Tot_fee_balance { get; set; }
    public string Authorized_By { get; set; }
    public string attendance { get; set; }
}
public class ClsReport
{
    public string Date { get; set; }
    public string branch { get; set; }
    public string Time { get; set; }
    public string LogType { get; set; }
    public string Remark { get; set; }
    public string Count { get; set; }
    public string subject_name { get; set; }
}


public class course_name
{
    public string coursename { get; set; }
    public string stats { get; set; }


}


//libraryissuereturn

public class studentDetailbook
{
    public string member_id { get; set; }
    public string curr_date { get; set; }
    public string count { get; set; }

    public string AYID { get; set; }

    public string Roll_no { get; set; }
    public string stud_id { get; set; }
    public string student_name { get; set; }
    public string Division { get; set; }

    public string stud_PermanantAdd { get; set; }
    public string stud_PermanantPhone { get; set; }
    public string stud_NativePhone { get; set; }
    public string subcourse_id { get; set; }
    public string subcourse_name { get; set; }
    public string Group_title { get; set; }

    public string stud_img { get; set; }

    public string stud_sign { get; set; }

    public string accession_no { get; set; }
    public string book_title { get; set; }
    public string book_type { get; set; }
    public string Author { get; set; }

    public string Publisher { get; set; }

    public string price_of_book { get; set; }

    public string SrNo { get; set; }
    public string member_type { get; set; }
    public string member_name { get; set; }


    public string accession_name { get; set; }
    public string accession_type { get; set; }
    public string issue_date { get; set; }
    public string return_date_given { get; set; }

    public string return_date { get; set; }

    public string issue_return { get; set; }

    public string total_fine { get; set; }

    //  public string if_lost { get; set; }

    public string fine_taken { get; set; }
    public string fine_discount { get; set; }
    public string user_id { get; set; }

    public string H_R { get; set; }

    public string lab { get; set; }

    // libraryEmployee

    public string emp_name { get; set; }
    public string Department_name { get; set; }
    public string Designation_Title { get; set; }
    public string emp_sign { get; set; }
    public string emp_photo { get; set; }
    public string emp_mobile1 { get; set; }
    public string emp_mobile2 { get; set; }
    public string emp_address_curr { get; set; }

    //cd
    public string cd_accession_no { get; set; }
    public string cd_name { get; set; }
    public string cd_content_type { get; set; }
    public string general_name { get; set; }


    //transaction_rpt
    public string accession_id_trans { get; set; }
    public string TITLE_trans { get; set; }
    public string accession_type_trans { get; set; }
    public string issue_date_trans { get; set; }
    public string return_date_trans { get; set; }
    public string H_R_trans { get; set; }


}

//billing
//public class Modal_class
//{
//    public string ratess { get; set; }
//    public string Name { get; set; }
//    public string ayid { get; set; }
//    public string duration { get; set; }
//    public string subcourse { get; set; }
//    public string course { get; set; }
//    public string group_title { get; set; }
//    public string grp_id { get; set; }
//    public string sub_crs_id { get; set; }
//    public string roll_no { get; set; }
//    public string msg { get; set; }
//    public string billno { get; set; }

//    public string chief { get; set; }
//    public string jun { get; set; }
//    public string sen { get; set; }
//    public string papese { get; set; }
//    public string assis { get; set; }
//    public string mode { get; set; }
//    public string inter { get; set; }
//    public string prac { get; set; }
//    public string oth { get; set; }
//}


public class Modal_class
{
    public string curr_ayd { get; set; }
    public string trans { get; set; }
    public string cheif_jn { get; set; }
    public string subj { get; set; }
    public string ratess { get; set; }
    public string count { get; set; }
    public string Name { get; set; }
    public string ayid { get; set; }
    public string duration { get; set; }
    public string subcourse { get; set; }
    public string course { get; set; }
    public string group_title { get; set; }
    public string grp_id { get; set; }
    public string sub_crs_id { get; set; }
    public string roll_no { get; set; }
    public string msg { get; set; }
    public string billno { get; set; }
    public string subjectname { get; set; }
    public string subjectid { get; set; }
    public string chief { get; set; }
    public string jun { get; set; }
    public string sen { get; set; }
    public string papese { get; set; }
    public string assis { get; set; }
    public string mode { get; set; }
    public string inter { get; set; }
    public string prac { get; set; }

    public string answer { get; set; }

    public string rev { get; set; }

    public string prof { get; set; }
    public string oth { get; set; }
    //non teaching
    public string under_st { get; set; }
    public string dis_cl { get; set; }
    public string bell_m { get; set; }
    public string water_m { get; set; }
    public string lab_ass { get; set; }
    public string lab_att { get; set; }
    public string preparr { get; set; }

    public string mcq_qu { get; set; }
    public string upload_qu { get; set; }
}

public class AssessmentBilling
{
    public string exam { get; set; }
    public string course { get; set; }
    public string group { get; set; }
    public string sjdates { get; set; }
    public string sjdays { get; set; }
    public string subjectid { get; set; }
    public string group_id { get; set; }
    public string emp_id { get; set; }
    public string bnk_acc { get; set; }
    public string senior_sup_on_dt { get; set; }
    public string junior_sup_on_dt { get; set; }
    public string senior_sup_days { get; set; }
    public string junior_sup_days { get; set; }
    public string subject { get; set; }
    public string sem { get; set; }
    public string msg { get; set; }
    public string tot_stud { get; set; }
    public string rate { get; set; }
    public string net_tot { get; set; }
    public string curr_dt { get; set; }
    public string mod_dt { get; set; }
    public string status { get; set; }
    public string bill_no { get; set; }
}

//library Guest

public class ClsGuest
{
    public string id { get; set; }
    public string guest_name { get; set; }
    public string guest_add { get; set; }
    public string guest_pn_no { get; set; }
    public string stud_id { get; set; }
    public string TYPE { get; set; }
    public string remark { get; set; }

}
public class caste_details
{
    public string group { get; set; }
    public string category { get; set; }
    public string gender { get; set; }
    public string count { get; set; }
}

public class part_pay_details
{
    public string stud_id { get; set; }
    public string name { get; set; }
    public string allow_amt { get; set; }
    public string remark { get; set; }
    public string allow_dt { get; set; }
    public string fees_paid { get; set; }
    public string caste { get; set; }
    public string reason { get; set; }

}


public class StudPhoto
{
    public string msg { get; set; }
    public string photo { get; set; }
    public string sign { get; set; }
}
public class attendanceDT
{
    public string day { get; set; }
    public string date { get; set; }
    public string year { get; set; }
    public string month { get; set; }
    public string strTime { get; set; }
    public string endTime { get; set; }
    public string isPresent { get; set; }
    public string absentcnt { get; set; }
    public string subject { get; set; }
    public string partialcnt { get; set; }
}
public class ClsBankreport
{
    public string data { get; set; }
}


public class exec_dataset
{
    public string roll_stud { get; set; }
    public string det_stud { get; set; }
    public string gender { get; set; }
    public string caste_sub { get; set; }
    public string place_birth { get; set; }
    public string dob { get; set; }
    public string marr_un { get; set; }
    public string per_add { get; set; }
    public string gurd_det { get; set; }
    public string school_clg { get; set; }
    public string doa { get; set; }
    public string fee_paid { get; set; }
    public string result { get; set; }
    public string eli_no { get; set; }
    public string leav { get; set; }
    public string tc_dt { get; set; }
    public string remark { get; set; }
    public string board_name { get; set; }
    public string sub_crs { get; set; }

}


public class bonafide
{
    public string count_issued { get; set; }
    public string stud_id { get; set; }
    public string name { get; set; }
    public string gender { get; set; }
    public string dob_wrds { get; set; }
    public string stud_dob { get; set; }
    public string ayid { get; set; }
    public string subcourse_Id { get; set; }
    public string subcourse_name { get; set; }
    public string sr_no { get; set; }
    public string issue_dt { get; set; }
    public string remark { get; set; }
    public string curr_dur { get; set; }
    public string dob_wd { get; set; }
}

public class studentcancellation
{

    public string stud_name { get; set; }
    public string Descritption { get; set; }
    public string group_id { get; set; }
    public string ayid { get; set; }
    public string fyid { get; set; }


    public string subcourse_name { get; set; }
    public string Course_id { get; set; }
    public string course_name { get; set; }
    public string faculty_name { get; set; }
    public string group_title { get; set; }
    public string course_tot_fees { get; set; }
    public string course_fee_paid { get; set; }
    public string admission_date { get; set; }
    public string feesstatus { get; set; }
    public string Deduction_percentage { get; set; }
    public string refund_fees { get; set; }
    public string subcourse_id { get; set; }
    public string amount { get; set; }



}


public class trans_cert
{
    public string prn_no { get; set; }
    public string fname { get; set; }
    public string mname { get; set; }
    public string lname { get; set; }
    public string grp_id { get; set; }
    public string faculty { get; set; }
    public string fac_data { get; set; }
    public string frm_acc { get; set; }
    public string month { get; set; }
    public string acc_year { get; set; }
    public string year { get; set; }
    public string pass { get; set; }
    public string head { get; set; }
    public string add1 { get; set; }
    public string add2 { get; set; }
    public string add3 { get; set; }
    public string remark { get; set; }
    public string stud_id { get; set; }
    public string flag { get; set; }
    public string tc_no { get; set; }
    public string full_name { get; set; }
    public string date { get; set; }
    public string gender { get; set; }
    public string nationality { get; set; }
    public string caste { get; set; }
    public string dob { get; set; }
}

//Issuereturnreport
public class Issuereturnreport
{
    public string SrNo { get; set; }
    public string StudentId { get; set; }
    public string StudentName { get; set; }
    public string Accssionno { get; set; }
    public string Booktitle { get; set; }
    public string Type { get; set; }
    public string empId { get; set; }
    public string empName { get; set; }
    public string empAccessionno { get; set; }
    public string empBooktitle { get; set; }
    public string empType { get; set; }
}

public class overallbill_nontech
{
    public string staff_id { get; set; }
    public string emp_name { get; set; }
    public string emp_acc { get; set; }
    public string under_std { get; set; }
    public string billno { get; set; }
    public string lab_as { get; set; }
    public string lab_at { get; set; }
    public string dis_cl { get; set; }

    public string water_m { get; set; }
    public string bell_m { get; set; }
    public string prep { get; set; }
    public string Total_Bill { get; set; }
    public string msg { get; set; }
}

//-------thesis---

public class thesis
{
    public string th_title { get; set; }
    public string th_researcher { get; set; }
    public string th_guide { get; set; }
    public string th_lang { get; set; }
    public string th_keyword { get; set; }
    public string th_year { get; set; }
    public string th_nopage { get; set; }
    public string th_callno { get; set; }
    public string th_subject { get; set; }
    public string th_remark { get; set; }
    public string th_acc_material { get; set; }
    public string th_category { get; set; }
    public string th_issue_type { get; set; }
    public string th_donor { get; set; }
    public string th_accno { get; set; }
    public string th_regdt { get; set; }
    public string th_clgname { get; set; }
}

//-------------

//For Image Upload
public class book_master
{
    public string id { get; set; }
    public string title { get; set; }
}
//bookseearch
public class booksearch
{
    public string bookid { get; set; }
    public string booktitle { get; set; }
    public string bookauthor { get; set; }
    public string bookedition { get; set; }
    public string authors { get; set; }
    public string bookpublisher { get; set; }
    public string bookcallno { get; set; }
    public string bookisbn { get; set; }
    public string booklanguage { get; set; }
    public string bookkeywords { get; set; }
    public string bookyear { get; set; }
    public string booknoofpages { get; set; }
    public string booksubject { get; set; }
    public string bookremark { get; set; }
    public string bookaccompaning { get; set; }
    public string bookcatogary { get; set; }
    public string booktype { get; set; }
    public string bookbound { get; set; }
    public string bookdonor { get; set; }

    public string bookaccessionno { get; set; }
    public string bookbillno { get; set; }
    public string bookbilldate { get; set; }
    public string bookmrp { get; set; }
    public string bookdiscount { get; set; }
    public string bookprice { get; set; }
    public string bookvendor { get; set; }
    public string bookregdate { get; set; }

}

public class bookmasternew
{
    public string cd_id { get; set; }
    public string Auth_cd_id { get; set; }
    public string cd_name { get; set; }
    public string cd_crs_id { get; set; }
    public string cd_crs_name { get; set; }
    public string cd_TITLE { get; set; }
    public string cd_AUTHOR { get; set; }
    public string cd_ISBN { get; set; }
    public string cd_LANG { get; set; }
    public string cd_ISSUE_TYPE { get; set; }
    public string cd_KEYWORD { get; set; }
    public string cd_PUBLISHER { get; set; }
    public string cd_YEAR { get; set; }
    public string cd_DURATION { get; set; }
    public string cd_DEPARTMENT { get; set; }
    public string cd_ACC_MATERIALS { get; set; }
    public string cd_SUBJ { get; set; }
    public string cd_REMARK { get; set; }
    public string cd_ACCESSION_NO { get; set; }
    public string cd_BILL_NO { get; set; }
    public string cd_BILL_DT { get; set; }
    public string cd_MRP { get; set; }
    public string cd_DISCOUNT { get; set; }
    public string cd_PRICE { get; set; }
    public string cd_VENDOR { get; set; }
    public string cd_REG_DT { get; set; }
    public string cd_DONOR_ID { get; set; }
    public string cd_msg { get; set; }
    public string CALLNO { get; set; }
    public string bookedition { get; set; }
    public string bookcallno { get; set; }
    public string booknoofpages { get; set; }
    public string bookcatogary { get; set; }
    public string bookbound { get; set; }

    public string dis_type { get; set; }
    public string prefix { get; set; }
    public string cd_PURCHASE_DT { get; set; }
    public string cd_ORDER_NO { get; set; }


}
public class MAP
{
    public string ID { get; set; }
    public string TITLE { get; set; }
    public string AUTHOR { get; set; }
    public string ISBN { get; set; }
    public string LANG { get; set; }
    public string ISSUE_TYPE { get; set; }
    public string KEYWORD { get; set; }
    public string PUBLISHER { get; set; }
    public string YEAR { get; set; }
    public string CALLNO { get; set; }
    public string DEPARTMENT { get; set; }
    public string ACC_MATERIALS { get; set; }
    public string SUBJ { get; set; }
    public string REMARK { get; set; }
    public string ACCESSION_NO { get; set; }
    public string BILL_NO { get; set; }
    public string BILL_DT { get; set; }
    public string MRP { get; set; }
    public string DISCOUNT { get; set; }
    public string PRICE { get; set; }
    public string VENDOR { get; set; }
    public string REG_DT { get; set; }
    public string DONOR_ID { get; set; }
    public string prefix { get; set; }


}
public class lib_report
{
    public string prefix { get; set; }
    public string count { get; set; }
    public string TITLE { get; set; }
    public string AUTHOR { get; set; }
    public string ISBN { get; set; }
    public string LANG { get; set; }
    public string ISSUE_TYPE { get; set; }
    public string KEYWORD { get; set; }
    public string PUBLISHER { get; set; }
    public string YEAR { get; set; }
    public string CALLNO { get; set; }
    public string DEPARTMENT { get; set; }
    public string ACC_MATERIALS { get; set; }
    public string SUBJ { get; set; }
    public string REMARK { get; set; }
    public string ACCESSION_NO { get; set; }
    public string BILL_NO { get; set; }
    public string BILL_DT { get; set; }
    public string MRP { get; set; }
    public string DISCOUNT { get; set; }
    public string PRICE { get; set; }
    public string VENDOR { get; set; }
    public string REG_DT { get; set; }
    public string DONOR_ID { get; set; }
    public string issued { get; set; }
    public string available { get; set; }
    public string cnt { get; set; }
    public string withdraw { get; set; }

}

public class Noc
{
    public string stud_id { get; set; }
    public string sr_no { get; set; }
    public string name { get; set; }
    public string grp_title { get; set; }
    public string iss_dt { get; set; }
    public string con_noc { get; set; }
    public string prn_no { get; set; }
    public string letter_no { get; set; }
    public string case_no { get; set; }
    public string letter_dt { get; set; }
    public string ayid { get; set; }
    public string case_dt { get; set; }
    public string i { get; set; }
    public string gender { get; set; }
    public string gender1 { get; set; }
    public string letter_date { get; set; }
    public string result { get; set; }
    public string exm_dt { get; set; }
    public string enrol { get; set; }
    public string roll_no { get; set; }
    public string fname { get; set; }public string mname { get; set; }public string lname { get; set; }
    public string group { get; set; }
}
public class newspapermaster_class
{
    public string ins_val { get; set; }
    public string id { get; set; }
    public string name { get; set; }
    public string news_lang { get; set; }
    public string news_type { get; set; }
    public string amount { get; set; }
    public string vendor { get; set; }
    public string qty { get; set; }
}

public class PeriodicPrefix
{
    public string serid { get; set; }
    public string title { get; set; }
    public string msg { get; set; }

}


public class periodical
{
    public string id { get; set; }
    public string ddltype { get; set; }
    public string ddlstartdt { get; set; }
    public string ddlenddt { get; set; }
    public string ddlfrequency { get; set; }
    public string ddllanguage { get; set; }
    public string ddldepartment { get; set; }
    public string txtvendor { get; set; }
    public string txtprefix { get; set; }
    public string txtprice { get; set; }
    public string Sstartdate { get; set; }
    public string Senddate { get; set; }

    public string AccessionNo { get; set; }
    public string VolumeNo { get; set; }
    public string IssueNo { get; set; }
    public string ISSNNo { get; set; }
    public string Publisher { get; set; }

    public string PublisherStartDate { get; set; }
    public string PublisherEndDate { get; set; }
    public string Remarks { get; set; }

    public string ContentPage { get; set; }

    public string img { get; set; }

    public string AcompaningMaterial { get; set; }
    public string RegisterDate { get; set; }
    public string Price { get; set; }
}

public class Periodic
{
    public string serid { get; set; }
    public string title { get; set; }
    public string msg { get; set; }

}


public class Periodiccal
{
    public string prefix { get; set; }
    public string Serial_Name { get; set; }
    public string Typee { get; set; }
    public string Department { get; set; }
    public string Vendor { get; set; }
    public string AccessionNo { get; set; }
    public string Volume_no { get; set; }
    public string Issue_No { get; set; }
    public string ISSN_no { get; set; }
    public string Publication_start_dt { get; set; }
    public string Publication_end_dt { get; set; }
    public string Publisher { get; set; }
    public string Remark { get; set; }
    public string contentPage { get; set; }
    public string AcompMaterial { get; set; }
    public string Reg_dt { get; set; }
    public string Ind_Price { get; set; }
}

public class Departmentwise
{
    public string prefix { get; set; }
    public string Serial_Name { get; set; }
    public string Typee { get; set; }
    public string Department { get; set; }
    public string Vendor { get; set; }
    public string AccessionNo { get; set; }
    public string Volume_no { get; set; }
    public string Issue_No { get; set; }
    public string ISSN_no { get; set; }
    public string Publication_start_dt { get; set; }
    public string Publication_end_dt { get; set; }
    public string Publisher { get; set; }
    public string Remark { get; set; }
    public string contentPage { get; set; }
    public string AcompMaterial { get; set; }
    public string Reg_dt { get; set; }
    public string Ind_Price { get; set; }
}

//--block result
public class BlockRes
{
    public string studid { get; set; }
    public string name { get; set; }
    public string Rollno { get; set; }
    public string class1 { get; set; }
    public string status { get; set; }
    public string group_id { get; set; }
    public string msg { get; set; }
    public string blkstatus { get; set; }
    public string emp_id { get; set; }
    public string exam_code { get; set; }
    public string Semester { get; set; }
    public string exm_name { get; set; }
}
public class exam_report
{
    public string stud_id { get; set; }
    public string NAME { get; set; }
    public string subcrs_id { get; set; }
    public string prn { get; set; }

    public string s1_ce { get; set; }
    public string s1_cg { get; set; }

    public string s2_ce { get; set; }
    public string s2_cg { get; set; }

    public string s3_ce { get; set; }
    public string s3_cg { get; set; }

    public string s4_ce { get; set; }
    public string s4_cg { get; set; }
}

//-----URL
public class URLClass
{
    public string formno { get; set; }
    public string name { get; set; }
    public string amount { get; set; }
    public string course { get; set; }
    public string mobno { get; set; }
    public string msg { get; set; }
    public string Category { get; set; }
    public string state { get; set; }
}


public class shortfeerpt
{
    public string id { get; set; }
    public string name { get; set; }
    public string rollno { get; set; }
    public string gender { get; set; }
    public string category { get; set; }
    public string coursefee { get; set; }
    public string group { get; set; }
    public string paid { get; set; }
    public string balance { get; set; }
    public string cash { get; set; }
    public string cheque { get; set; }
    public string refund { get; set; }
    public string remark { get; set; }
    public string authorized { get; set; }
    public string msg { get; set; }
    public string DD { get; set; }
}


public class overalldt
{
    public string id { get; set; }
    public string dob { get; set; }
    public string name { get; set; }
    public string PRN { get; set; }
    public string rollno { get; set; }
    public string gender { get; set; }
    public string category { get; set; }
    public string caste { get; set; }
    public string subcaste { get; set; }
    public string division { get; set; }
    public string cash { get; set; }
    public string cheque { get; set; }
    public string refund { get; set; }
    public string remark { get; set; }
    public string coursefee { get; set; }
    public string group { get; set; }
    public string authorized { get; set; }
    public string msg { get; set; }
    public string studphone { get; set; }
    public string studadd { get; set; }
    public string FatherName { get; set; }
    public string FatherPhoneNo { get; set; }
    public string MotherName { get; set; }
    public string MotherPhoneNo { get; set; }
    public string NativePhoneNo { get; set; }
    public string GauridanName { get; set; }
    public string GauridanPhoneNo { get; set; }
    public string YearlyIncome { get; set; }
    public string AadharNo { get; set; }
    public string VoterIdNo { get; set; }
    public string earning { get; set; }
    public string nonearning { get; set; }
    public string email { get; set; }

    public string balance { get; set; }
    public string mode { get; set; }
    public string rcpt { get; set; }
    public string amt { get; set; }


}

public class ExamStatus
{
    public string msg { get; set; }
    public string exam_code { get; set; }
    public string is_current { get; set; }
    public string is_lock { get; set; }
    public string exam_date { get; set; }
}


public class Resolution
{
    public string cre_credit { get; set; }
    public string h1_type { get; set; }
    public string h1_pass { get; set; }
    public string h1_out { get; set; }
    public string h1_res { get; set; }

    public string h2_type { get; set; }
    public string h2_pass { get; set; }
    public string h2_out { get; set; }
    public string h2_res { get; set; }
    public string date_val { get; set; }
    public string msg { get; set; }
}
public class assignexam
{
    public string stud_id { get; set; }
    public string roll_no { get; set; }
    public string name { get; set; }
    public string msg { get; set; }
    public string sub_id { get; set; }
    public string credit_id { get; set; }
}

public class reexam
{
    public string column { get; set; }
    public string seatno { get; set; }
    public string rollno { get; set; }
    public string name { get; set; }
    public string ktcount { get; set; }
    public string msg { get; set; }
    public string id { get; set; }
    public string header { get; set; }
    public string srno { get; set; }
    public string marks { get; set; }
    public string subid { get; set; }
    public string atktcnt { get; set; }

}

public class seatno
{
    public string stud_id { get; set; }
    public string stud_quota { get; set; }
    public string stud_rollno { get; set; }
    public string stud_seatno { get; set; }
    public string msg { get; set; }
    public string stud_name { get; set; }
    public string type { get; set; }

}
public class marksentry
{
    public string stud_id { get; set; }
    public string srno { get; set; }
    public string seatno { get; set; }
    public string name { get; set; }
    public string h1mrks { get; set; }
    public string h2mrks { get; set; }
    public string msg { get; set; }
    public string headcnt { get; set; }
}

public class Gazette
{
    public int subcnt { get; set; }
    public int headcnt { get; set; }
    public string msg { get; set; }
    public string subid { get; set; }
    public string subname { get; set; }
    public string subcode { get; set; }
    public string max { get; set; }
    public string min { get; set; }
    public string marksobt { get; set; }
    public string outof { get; set; }
    public string grade { get; set; }
    public string credit { get; set; }
    public string GPC { get; set; }
    public string studid { get; set; }
    public string studname { get; set; }
    public string seatno { get; set; }
    public string total { get; set; }
    public string sgpi { get; set; }
    public string result { get; set; }
    public string totgrade { get; set; }
    public string sem1 { get; set; }
    public string sem2 { get; set; }
    public string sem3 { get; set; }
    public string sem4 { get; set; }
    public string sem5 { get; set; }
    public string sem6 { get; set; }
    public string sem7 { get; set; }
    public string sem8 { get; set; }
    public string sem9 { get; set; }
    public string sem10 { get; set; }
    public int semcount { get; set; }
    public string h1type { get; set; }
    public string h2type { get; set; }
    public string h1out { get; set; }
    public string h2out { get; set; }
    public string h1pass { get; set; }
    public string h2pass { get; set; }
    public string h1_mrkout { get; set; }
    public string h2_mrkout { get; set; }
    public string h1_obt { get; set; }
    public string h2_obt { get; set; }
    public string totalcdt { get; set; }
    public string totalgrd { get; set; }
    public string totalmrk { get; set; }
    public string h1m { get; set; }
    public string h2m { get; set; }
}
//--------------------------------dept &desg
public class deptdes
{
    public string msg { get; set; }
    public string prefix { get; set; }
    public string deptname { get; set; }
    public string desname { get; set; }
    public string deptid { get; set; }
    public string desid { get; set; }
}

public class RoleSave
{
    public string msg { get; set; }
    public string rolename { get; set; }
    public string formname { get; set; }
    public string roleid { get; set; }

}
public class Employee
{
    public string photo { get; set; }
    public string sign { get; set; }
    public int countemp { get; set; }
    public string empid { get; set; }
    public string fname { get; set; }
    public string lname { get; set; }
    public string mname { get; set; }
    public string mothname { get; set; }
    public string dob { get; set; }
    public string doj { get; set; }
    public string gender { get; set; }
    public string bldgrp { get; set; }
    public string cat { get; set; }
    public string national { get; set; }
    public string marital { get; set; }
    public string email { get; set; }
    public string caste { get; set; }
    public string subcaste { get; set; }
    public string aadhar { get; set; }
    public string address1 { get; set; }
    public string city1 { get; set; }
    public string state1 { get; set; }
    public string pincode1 { get; set; }
    public string phoneno1 { get; set; }
    public string telno1 { get; set; }
    public string address2 { get; set; }
    public string city2 { get; set; }
    public string state2 { get; set; }
    public string pincode2 { get; set; }
    public string phoneno2 { get; set; }
    public string telno2 { get; set; }
    public string depart { get; set; }
    public string desig { get; set; }
    public string salary { get; set; }
    public string msg { get; set; }
    public string handicap { get; set; }
    public string pfno { get; set; }
    public string panno { get; set; }

    public string boardname { get; set; }
    public string colgname { get; set; }
    public string degname { get; set; }
    public string degtype { get; set; }
    public string subject { get; set; }
    public string mop { get; set; }
    public string yop { get; set; }
    public string obtmk { get; set; }
    public string totmrk { get; set; }
    public string class1 { get; set; }
    public string pursuing { get; set; }
    public string jobtype { get; set; }

    public string todt { get; set; }
    public string delflag { get; set; }
    public string deptid { get; set; }
    public string desid { get; set; }

    public string accntno { get; set; }
    public string acntype { get; set; }
    public string bnkname { get; set; }
    public string branch { get; set; }
    public string isalary { get; set; }

    public string comp { get; set; }
    public string prvsal { get; set; }
    public string jfdate { get; set; }
    public string jtdate { get; set; }

    public string logincat { get; set; }
    public string role { get; set; }
    public string grouplist { get; set; }
    public string form_name { get; set; }
    public string form_id { get; set; }
}

public class stud_doc_data
{
    public string form_id { get; set; }
    public string name { get; set; }
    public string category { get; set; }
    public string phone { get; set; }
    public string status { get; set; }
}


public class Merit_data
{
    public string Category { get; set; }
    public string formno { get; set; }
    public string studentname { get; set; }
    public string Percentage { get; set; }
    public string inhouse { get; set; }
    public string msg { get; set; }
    public string stud_id { get; set; }
    public string Group_title { get; set; }
    public string pre_faculty { get; set; }
    public string Exam { get; set; }
    public string Mks_Obtained { get; set; }
    public string Mks_Outof { get; set; }
    public string Year { get; set; }
    public string MONTH { get; set; }
    public string firstAttempt { get; set; }
    public string Caste { get; set; }
    public string comp_subjects { get; set; }
    public string compulsory_subject_marks { get; set; }
    public string Board_name { get; set; }
    public string State_board { get; set; }
    public string Other_criteria { get; set; }
    public string subcourse_name { get; set; }
    public string subjects { get; set; }
    public string diploma_holder { get; set; }
    public string Gender { get; set; }
    public string S_Exam { get; set; }
    public string S_Mks_Obtained { get; set; }
    public string S_Mks_OutOf { get; set; }
    public string S_Month { get; set; }
    public string S_Year { get; set; }
    public string Phy_handicap { get; set; }
    public string merit_dt { get; set; }
    public string ACDID { get; set; }
    public string user_id { get; set; }
    public string CURR_DT { get; set; }
    public string group_id { get; set; }
    public string subcourse_id { get; set; }
    public string course_id { get; set; }
    public string faculty_id { get; set; }
    public string course_name { get; set; }
    public string faculty_name { get; set; }
    public string submit_dt { get; set; }





}

public class storemaster
{
    public int dept_id { get; set; }
    public string dept_name { get; set; }
    public string deptreturn { get; set; }
    public int vendor_id { get; set; }
    public string vendor_name { get; set; }
    public string vendor_emailid { get; set; }
    public string vendor_mobileno { get; set; }
    public string vendor_location { get; set; }
    public string vendor_inuse { get; set; }
    public string vendor_address { get; set; }
    public string mat_id { get; set; }
    public string mat_name { get; set; }
    public string mat_rackno { get; set; }


}

//inventory rohit--------------------------------------------------------------------------------------------
public class stationary_mat
{
    public string particulars { get; set; }
    public string issue_dt { get; set; }
    public string dept_name { get; set; }
    public string regis_no { get; set; }
    public string rcvd_qty { get; set; }
    public string tot_qty { get; set; }
    public string issue_td { get; set; }
    public string on_dt { get; set; }
    public string closing_dt { get; set; }
}

public class material_mast
{
    public string id { get; set; }
    public string matr_name { get; set; }
    public string vendor_name { get; set; }
    public string brand { get; set; }
    public string bill_no { get; set; }
    public string tot_rate { get; set; }
    public string discount { get; set; }
    public string final_rate { get; set; }
    public string dept_appl { get; set; }
    public string purch_order_dt { get; set; }
    public string qty_order { get; set; }
    public string qty_rcvd { get; set; }
    public string challan_no { get; set; }
    public string bill_no_dt { get; set; }
    public string pay_mode { get; set; }
    public string pay_dt { get; set; }
    public string msg { get; set; }

    public string matr_name2 { get; set; }
    public string matr_id2 { get; set; }

    public string vendor_name2 { get; set; }
    public string vendor_idd2 { get; set; }
}


public class stationary_master_entry
{
    public string id { get; set; }
    public string part_name { get; set; }
    public string issue_dt { get; set; }
    public string dpt_name { get; set; }
    public string regis_no { get; set; }
    public string rcvd_qty { get; set; }
    public string tot_qty { get; set; }
    public string issue_qty { get; set; }
    public string mnth_on { get; set; }
    public string mnth_closing { get; set; }
    public string msg { get; set; }

    public string matr_name { get; set; }
    public string matr_id { get; set; }

    public string vendor_name { get; set; }
    public string vendor_idd { get; set; }

    public string depart_name { get; set; }
    public string dept_idd { get; set; }
}
public class materials_vendors
{
    public string matr_name { get; set; }
    public string matr_id { get; set; }

    public string vendor_name { get; set; }
    public string vendor_idd { get; set; }

    public string depart_name { get; set; }
    public string dept_idd { get; set; }
}
//-------------------------------------------------------------------------------------


public class course
{
    public string course_id { get; set; }
    public string course_name { get; set; }
    public string fac_id { get; set; }
    public string fac_name { get; set; }
    public string pattern { get; set; }
    public string subcourse_id { get; set; }
    public string subcourse_name { get; set; }
    public string group_id { get; set; }
    public string group_name { get; set; }
    public string course_type { get; set; }
    public string adm_flg { get; set; }
    public string description { get; set; }
    //public string inhouse_outside { get; set; }

    public string inhouse { get; set; }
    public string outsider { get; set; }
}

public class subject
{
    public string course_id { get; set; }
    public string course_name { get; set; }
    public string fac_id { get; set; }
    public string fac_name { get; set; }
    public string subcourse_id { get; set; }
    public string subcourse_name { get; set; }
    public string semester { get; set; }
    public string subject_name { get; set; }
    public string subject_id { get; set; }
    public string is_comp { get; set; }
}
public class junior_stud_trans
{
    public string stud_id { get; set; }
    public string studentname { get; set; }
    public string rollno { get; set; }
    public string grno { get; set; }
    public string chkflag { get; set; }
    public string msg { get; set; }
}

public class grp_mapping
{
    public string group_id { get; set; }
    public string group_title { get; set; }
    public string returndata { get; set; }
}
public class stud_tarnsfer
{
    public string stud_id { get; set; }
    public string group_name { get; set; }
    public string group_id { get; set; }
    public string Name { get; set; }
    public string message { get; set; }
    public string Transfer { get; set; }
}

//aishwarya admission crieteraia and freeship scholar ship
public class saveData_freeship_scholarship
{
    public string msg { get; set; }
}
public class saveData_admission_criteria
{
    public string msg { get; set; }
}
public class UpdateData_freeship_scholarship
{
    public string msg { get; set; }
}

public class UpdateData_admission_criteria
{
    public string msg { get; set; }
}
public class fill_freeship_grid
{
    public string Sub_course { get; set; }
    public string Category { get; set; }
    public string Fees { get; set; }
    public string msg { get; set; }
    public string flag { get; set; }
    public string group_id { get; set; }
    public string group_name { get; set; }
}
public class fill_admission_criteria_grid
{
    public string faculty { get; set; }
    public string course { get; set; }
    public string Sub_course { get; set; }
    public string subcourse_name { get; set; }
    public string Eligibilty_id { get; set; }
    public string Eligibilty_name { get; set; }
    public string compulsory_subjects { get; set; }
    public string previous_faculty { get; set; }
    public string diploma { get; set; }
    public string firstAttempt { get; set; }
    public string previous_class { get; set; }
    public string min_percentage_gen { get; set; }
    public string min_percentage_res { get; set; }
    public string msg { get; set; }
}

//siddhi _intake _08-04-2021
public class intake_capacity
{
    public string title { get; set; }
    public string intake_form { get; set; }
    public string id { get; set; }
}


//ssiddhi_22-04-2021
public class state
{
    public string Type { get; set; }
    public string sub_Type { get; set; }
    public string Board { get; set; }
    public int id { get; set; }
}

public class fill_hsc_data
{
    public string stud_id { get; set; }
    public string hsc_seat_no { get; set; }
    public string stud_F_Name { get; set; }
    public string stud_M_Name { get; set; }
    public string stud_L_Name { get; set; }
    public string stud_mo_name { get; set; }
    public string stud_DOB { get; set; }
    public string Previouse_College { get; set; }
    public string stud_Father_TelNo { get; set; }
    public string stud_Mother_TelNo { get; set; }
    public string hsc_obtained { get; set; }
    public string hsc_outof { get; set; }
}
public class saveData_hsc_data_update
{
    public string stud_id { get; set; }
    public string hsc_seat_no { get; set; }
    public string stud_F_Name { get; set; }
    public string stud_M_Name { get; set; }
    public string stud_L_Name { get; set; }
    public string stud_mo_name { get; set; }
    public string stud_DOB { get; set; }
    public string Previouse_College { get; set; }
    public string stud_Father_TelNo { get; set; }
    public string stud_Mother_TelNo { get; set; }
    public string hsc_obtained { get; set; }
    public string hsc_outof { get; set; }
    public string msg { get; set; }
}

public class fee_det_stud
{
    public string id { get; set; }
    public string name { get; set; }
    public string roll { get; set; }
    public string grp_title { get; set; }
    public string amt_paid1 { get; set; }
    public string amt_bal1 { get; set; }
    public string remark { get; set; }

    public string amt_paid2 { get; set; }
    public string amt_bal2 { get; set; }

    public string amt_paid3 { get; set; }
    public string amt_bal3 { get; set; }

    public string amt_paid4 { get; set; }
    public string amt_bal4 { get; set; }

    public string amt_paid5 { get; set; }
    public string amt_bal5 { get; set; }
}
//-----  studentformetails
public class studentformdet
{
    public formheader[] formh { get; set; }
    public formfields[] formf { get; set; }

}
public class singlestudent
{
    public string formno { get; set; }
    public string stud_id { get; set; }
    public string name { get; set; }
    public string group_title { get; set; }
    public string phone { get; set; }

}
public class formfields
{
    public string stud_id { get; set; }
    public string stud_name { get; set; }
    public string form_no { get; set; }
    public string group_title { get; set; }
    public string Mo_name { get; set; }
    public string Gender { get; set; }
    public string Category { get; set; }
    public string Caste { get; set; }
    public string Sub_Caste { get; set; }
    public string DOB { get; set; }
    public string Address { get; set; }
    public string pincode { get; set; }
    public string state { get; set; }
    public string Phone_No { get; set; }
    public string Mob_No { get; set; }
    public string Email_id { get; set; }
    public string birth_place { get; set; }
    public string Father_contact_No { get; set; }
    public string Mother_contact_No { get; set; }
    public string aadharcard_no { get; set; }
    public string applicant_type { get; set; }
}

public class formheader
{
    public string header { get; set; }

}

//----billing new rohit
public class bill_working
{
    public string id { get; set; }
    public string course_bill { get; set; }
    public string msg { get; set; }
}

public class bill_fields
{
    public string id { get; set; }
    public string name { get; set; }
    public string date { get; set; }
    public string billno { get; set; }

    public string sen_sup { get; set; }
    public string jun_sup { get; set; }
    public string chef_con { get; set; }
    public string join_chef { get; set; }
    public string paper_set { get; set; }
    public string asses { get; set; }
    public string reval { get; set; }
    public string trans { get; set; }
    public string moder { get; set; }
    public string inter { get; set; }
    public string practs { get; set; }
    public string proff_corr { get; set; }
    public string ans { get; set; }
    public string mcq { get; set; }
    public string upload_que { get; set; }

    public string acc_no { get; set; }
    public string total { get; set; }

}
public class billingsearch
{
    public string sem { get; set; }
    public string bill_no { get; set; }
    public string group { get; set; }
    public string exam { get; set; }
    public string bill_dt { get; set; }
}

//-------------------------Salary--------------------
public class salarydetails
{
    public empsalary[] emp_salary { get; set; }
}
public class empsalary
{
    public string diff { get; set; }
    public string emp_id { get; set; }
    public string emp_name { get; set; }
    public string department { get; set; }
    public string designation { get; set; }
    public string qualification { get; set; }
    public string acno { get; set; }
    public string scale { get; set; }
    public string joining { get; set; }
    public string birthdate { get; set; }
    public string retirement { get; set; }
    public string month { get; set; }
    public string year { get; set; }
    public string status { get; set; }
    public string emp_type { get; set; }
    public string process { get; set; }
    public string user_id { get; set; }
    public string applicable { get; set; }
    public string delete { get; set; }
    public string id { get; set; }
    public string basic { get; set; }
    public string agp { get; set; }
    public string total { get; set; }
    public string da { get; set; }
    public string hra { get; set; }
    public string ta { get; set; }
    public string oth_sp_allow { get; set; }
    public string gross_salary { get; set; }
    public string arrears { get; set; }
    public string total_salary { get; set; }
    public string pf_no { get; set; }
    public string pf_emp { get; set; }
    public string pf_trust { get; set; }
    public string pt { get; set; }
    public string tds { get; set; }
    public string oth_deduct { get; set; }
    public string total_deduct { get; set; }
    public string net_salary { get; set; }
    public string total_pf { get; set; }
    public string total_salary_emp { get; set; }
    public string remark { get; set; }
}

///////---------certification-------------------
public class certification
{
    public string course_id { get; set; }
    public string course_code { get; set; }
    public string course_name { get; set; }
    public string course_duration { get; set; }
    public string status_flag { get; set; }
    public string course_fees { get; set; }
    public string stud_id { get; set; }
    public string Name { get; set; }
    public string roll_no { get; set; }
    public string phone_no { get; set; }
    public string stud_Email { get; set; }
    public string subcourse_name { get; set; }
    public string transaction_id { get; set; }
    public string postingmer_txn { get; set; }
    public string amount { get; set; }
    public string bank_name { get; set; }
    public string paid_date { get; set; }
    public string mop { get; set; }
    public string pay_status { get; set; }

}

//access
public class masterpage
{
    public string emp_id { get; set; }
    public string module_name { get; set; }
    public string form_name { get; set; }
    public string module_temp { get; set; }

}