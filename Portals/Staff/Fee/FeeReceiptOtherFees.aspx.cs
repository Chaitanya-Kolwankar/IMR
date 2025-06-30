using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class FeeReceiptOtherFees : System.Web.UI.Page
{
    Class1 c1 = new Class1();
    protected void Page_Load(object sender, EventArgs e)
    {
        string ss = (string)HttpContext.Current.Session["id"];

        if (ss.Contains("|") == true)
        {
            string[] arr = ss.Split('|');
            Session["id"] = arr[1].ToUpper().ToString();
            Session["Recpt_no"] = arr[0].ToUpper().ToString().Trim();
            Session["year"] = arr[2].ToUpper().ToString().Trim();
        }
        else
        {
            Session["id"] = "";
            Session["Recpt_no"] = "";
            Session["year"] = "";
        }
        string alias = "";
        if (Session["Recpt_no"].ToString().Contains("/"))
        {
            String[] recarr = Session["Recpt_no"].ToString().Split('/');
            alias = recarr[0].ToUpper().ToString();
        }

        if (!IsPostBack)
        {
            try
            {
                DataTable dtgroup = c1.fillDataTable("select  case when group_name like 'FY%' or group_name like 'SY%' then a.group_id when group_name = 'SE' and d.diploma_holder = 1 and d.acdid = (select MAX(ayid) from m_academic) then 'DSE'  else group_name end as group_name,a.group_id from d_adm_applicant d,(select distinct left(group_title, 3) as group_name, a.group_id, stud_id from m_std_studentacademic_tbl a, m_crs_subjectgroup_tbl g where stud_id = '" + Session["id"].ToString() + "' and a.ayid = '" + Session["year"].ToString() + "' and a.group_id = g.Group_id and a.del_flag = 0) a where d.stud_id = a.stud_id ");
                //DataTable dtgroup = c1.fillDataTable("select distinct case when left(group_title,3) like 'FY%' or  left(group_title,3) like 'SY%' then a.group_id when left(group_title,3)='SE' and d.diploma_holder=1 and d.acdid=(select MAX(ayid) from m_academic) then 'DSE'  else left(group_title,3) end as  group_name,a.group_id from m_std_studentacademic_tbl a,m_crs_subjectgroup_tbl g where stud_id='" + Session["id"].ToString() + "' and a.ayid='" + Session["year"].ToString() + "' and a.group_id=g.Group_id and a.del_flag=0");
                DataSet dsfil = c1.fillDataset("SELECT a.stud_id,isnull(p.stud_f_name,'')+' '+isnull(p.stud_m_name,'')+' '+isnull(p.stud_l_name,'') as Name,a.roll_no,sg.group_title,a.Division,(select substring(Duration,9,4)+'-'+substring(Duration,21,4)  from m_academic where ayid='" + Session["year"].ToString() + "') acdyear from m_std_personaldetails_tbl p,m_std_studentacademic_tbl a,m_crs_subjectgroup_tbl sg "
                   + " where p.stud_id=a.stud_id and a.stud_id='" + Session["id"].ToString() + "' and a.ayid='" + Session["year"].ToString() + "' and a.del_flag=0 and p.del_flag=0 and sg.group_id=a.group_id ;select Struct_name,CONVERT(decimal(18,2),Amount) as Amount from m_feeentry where stud_id='" + Session["id"].ToString() + "' and ayid='" + Session["year"].ToString() + "' and Recpt_no='" + Session["Recpt_no"].ToString() + "' and del_flag=0 and (Struct_name NOT like 'tu%' AND  Struct_name not like 'dev%') ;"
                   + " select sum(CONVERT(decimal(18,2),Amount)) as total_amt,convert(varchar(10),Pay_date,103) as paydate,Recpt_mode,Recpt_no,convert(varchar(10),Recpt_Chq_dt,103) as Recpt_Chq_dt,Recpt_Chq_No,Recpt_Bnk_Name,Recpt_Bnk_Branch ,case when (select MAX(Remark) from m_FeeEntry where stud_id='" + Session["id"].ToString() + "' and ayid='" + Session["year"].ToString() + "' and Recpt_no='" + Session["Recpt_no"].ToString() + "' and del_flag=0) is null then (select MAX(Remark) from m_FeeEntry where stud_id='" + Session["id"].ToString() + "' and ayid='" + Session["year"].ToString() + "' and del_flag=0) else (select MAX(Remark) from m_FeeEntry where stud_id='" + Session["id"].ToString() + "' and ayid='" + Session["year"].ToString() + "' and Recpt_no='" + Session["Recpt_no"].ToString() + "' and del_flag=0) end as Remark,case when (select MAX(Authorized_By) from m_FeeEntry where stud_id='" + Session["id"].ToString() + "' and ayid='" + Session["year"].ToString() + "' and Recpt_no='" + Session["Recpt_no"].ToString() + "' and del_flag=0) is null then (select MAX(Authorized_By) from m_FeeEntry where stud_id='" + Session["id"].ToString() + "' and ayid='" + Session["year"].ToString() + "' and del_flag=0) else (select MAX(Authorized_By) from m_FeeEntry where stud_id='" + Session["id"].ToString() + "' and ayid='" + Session["year"].ToString() + "' and Recpt_no='" + Session["Recpt_no"].ToString() + "' and del_flag=0) end as Authorized_By  from m_feeentry where stud_id='" + Session["id"].ToString() + "' and ayid='" + Session["year"].ToString() + "' and Recpt_no='" + Session["Recpt_no"].ToString() + "' and del_flag=0 and (Struct_name NOT like 'tu%' AND  Struct_name not like 'dev%')  group by Pay_date,Recpt_mode,Recpt_no,Recpt_Chq_dt,Recpt_Chq_No,Recpt_Bnk_Name,Recpt_Bnk_Branch ; "
                   + " select a.paidamt,b.actualamt,case when (a.paidamt>b.actualamt and c.refundamt=0) then (a.paidamt-b.actualamt) else '0' end as Refundamt,case when a.paidamt<b.actualamt then (b.actualamt-a.paidamt) else '0' end as Balanceamt from (select sum(CONVERT(decimal(18,2),Amount)) PaidAmt from m_feeentry where stud_id='" + Session["id"].ToString() + "' and ayid='" + Session["year"].ToString() + "' and (Struct_name NOT like 'tu%' AND  Struct_name not like 'dev%')  and del_flag=0) a ,(select sum(CONVERT(decimal(18,2),Amount)) actualamt from m_feemaster where ayid='" + Session["year"].ToString() + "' and group_id='" + dtgroup.Rows[0]["group_name"].ToString() + "') b,(select case when sum(CONVERT(decimal(18,2),Amount)) is null then 0 else sum(CONVERT(decimal(18,2),Amount)) end  as refundamt from m_feeentry where stud_id='" + Session["id"].ToString() + "' and ayid='" + Session["year"].ToString() + "' and del_flag=0) c ; select 'Total' as Text,sum(CONVERT(decimal(18,2),Amount)) as Value from m_feeentry where stud_id='" + Session["id"].ToString() + "' and ayid='" + Session["year"].ToString() + "' and Recpt_no='" + Session["Recpt_no"].ToString() + "' and del_flag=0 and (Struct_name NOT like 'tu%' AND  Struct_name not like 'dev%') ;");

                if (dsfil.Tables[0].Rows.Count > 0)
                {
                    //for(int i=0;i<dsfil.Tables[0].Rows.Count>0;i++)
                    //{
                    //    if(dsfil.Tables[0].Rows[i][""].ToString())
                    //}

                    string[] ayd_year = { "2018-2019", "2019-2020", "2020-2021", "2021-2022" };
                    if (ayd_year.Contains(dsfil.Tables[0].Rows[0]["acdyear"].ToString()))
                    {
                        lbl_header.InnerText = "Late Shri Vishnu Waman Thakur Charitable Trust's";
                    }

                    lblNo.Text = Session["id"].ToString() + "/" + Session["Recpt_no"].ToString();
                    if (dsfil.Tables[1].Rows.Count > 0)
                    {
                        DataRow dr = dsfil.Tables[1].NewRow();
                        dr["Struct_name"] = dsfil.Tables[4].Rows[0]["Text"].ToString();
                        dr["Amount"] = dsfil.Tables[4].Rows[0]["Value"].ToString();
                        dsfil.Tables[1].Rows.Add(dr);

                        GridView2.DataSource = dsfil.Tables[1];
                        GridView2.DataBind();
                    }

                    if (dsfil.Tables[2].Rows.Count > 0)
                    {
                        lbl_date.Text = dsfil.Tables[2].Rows[0]["paydate"].ToString();
                        //dsfil.Tables[2].Rows[0]["Recpt_mode"].ToString() + '/' + dsfil.Tables[2].Rows[0]["Recpt_Chq_No"].ToString() + '/' + dsfil.Tables[2].Rows[0]["Recpt_Bnk_Name"].ToString() + '(' + dsfil.Tables[2].Rows[0]["Recpt_Bnk_Branch"].ToString() + ')' + '/' + dsfil.Tables[2].Rows[0]["Recpt_Chq_dt"].ToString()
                    }

                    lblName.Text = dsfil.Tables[0].Rows[0]["Name"].ToString().ToUpper();
                    long total2 = Convert.ToInt32(dsfil.Tables[4].Rows[0]["Value"].ToString().Split('.')[0]);
                    lblamount.Text = ConvertNumbertoWords(total2) + " ONLY";
                    lblautho.Text = "";
                    if (dsfil.Tables[2].Rows.Count > 0)
                    {
                        lblmode.Text = dsfil.Tables[0].Rows[0]["group_title"].ToString() + " " + dsfil.Tables[0].Rows[0]["acdyear"].ToString();
                        lblremark.Visible = true;
                        if (dsfil.Tables[2].Rows[0]["Remark"].ToString() != "" && dsfil.Tables[2].Rows[0]["Authorized_By"].ToString()!="")
                        {
                            lblremark.Text = dsfil.Tables[2].Rows[0]["Remark"].ToString() + " : " + dsfil.Tables[2].Rows[0]["Authorized_By"].ToString();
                        }
                        else if (dsfil.Tables[2].Rows[0]["Remark"].ToString() != "")
                        {
                            lblremark.Text = dsfil.Tables[2].Rows[0]["Remark"].ToString();
                        }
                        else if (dsfil.Tables[2].Rows[0]["Authorized_By"].ToString() != "")
                        {
                            if (dsfil.Tables[2].Rows[0]["Authorized_By"].ToString() == "--Select--")
                            {
                                lblremark.Text = "";
                            }
                            else
                            {
                                lblremark.Text = dsfil.Tables[2].Rows[0]["Authorized_By"].ToString();
                            }
                        }
                        else
                        {
                            lblremark.Visible = false;
                            lblremark.Text = "";
                        }
                    }
                }

                DataTable dtpay = c1.fillDataTable("select distinct isnull(Recpt_mode,'')+' '+isnull(Recpt_Chq_No,'') Recpt_mode,isnull(Recpt_Bnk_Name,'') Recpt_Bnk_Name,isnull(Recpt_Bnk_Branch,'') Recpt_Bnk_Branch,convert(varchar(10),Recpt_Chq_dt,103) Recpt_Chq_dt,SUM(CAST(amount as int)) as Amount from m_FeeEntry where stud_id='" + Session["id"].ToString() + "' and ayid='" + Session["year"].ToString() + "' and del_flag=0 and recpt_no='" + Session["Recpt_no"].ToString() + "' and (Struct_name NOT like 'tu%' AND  Struct_name not like 'dev%')  group by Recpt_mode,Recpt_Bnk_Name,Recpt_Bnk_Branch,Recpt_Chq_dt,Recpt_Chq_No");

                if (dtpay.Rows.Count > 0)
                {
                    GridView1.DataSource = dtpay;
                    GridView1.DataBind();
                }

            }
            catch (Exception ex)
            {

            }
        }
    }

    public string ConvertNumbertoWords(long number)
    {
        if (number == 0) return "ZERO";
        if (number < 0) return "minus " + ConvertNumbertoWords(Math.Abs(number));
        string words = "";

        if ((number / 1000000) > 0)
        {
            words += ConvertNumbertoWords(number / 1000000) + " MILLION ";
            number %= 1000000;
        }

        if ((number / 100000) > 0)
        {
            words += ConvertNumbertoWords(number / 100000) + " LAKH ";
            number %= 100000;
        }
        if ((number / 1000) > 0)
        {
            words += ConvertNumbertoWords(number / 1000) + " THOUSAND ";
            number %= 1000;
        }
        if ((number / 100) > 0)
        {
            words += ConvertNumbertoWords(number / 100) + " HUNDRED ";
            number %= 100;
        }

        if (number > 0)
        {
            if (words != "") words += "AND ";
            string[] unitsMap = new[]   
        {  
            "ZERO", "ONE", "TWO", "THREE", "FOUR", "FIVE", "SIX", "SEVEN", "EIGHT", "NINE", "TEN", "ELEVEN", "TWELVE", "THIRTEEN", "FOURTEEN", "FIFTEEN", "SIXTEEN", "SEVENTEEN", "EIGHTEEN", "NINETEEN"  
        };
            string[] tensMap = new[]   
        {  
            "ZERO", "TEN", "TWENTY", "THIRTY", "FORTY", "FIFTY", "SIXTY", "SEVENTY", "EIGHTY", "NINETY"  
        };
            if (number < 20) words += unitsMap[number];
            else
            {
                words += tensMap[number / 10];
                if ((number % 10) > 0) words += " " + unitsMap[number % 10];
            }
        }
        return words;
    } 
}