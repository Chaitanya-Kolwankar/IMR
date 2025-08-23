using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Portals_Staff_Admission_ProvisionalFeeReceipt : System.Web.UI.Page
{
    Class1 cls = new Class1();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Convert.ToString(Session["Prov_studID"]) != "")
            {
                try
                {
                    string stud_id = Session["Prov_studID"].ToString();
                    string recpt_no = Session["Prov_receipt"].ToString();
                    string ayid = Session["Prov_ayid"].ToString();
                    string struct_type = Session["Prov_structname"].ToString();

                    DataSet ds = cls.fillDataset("select Formno,CONVERT(VARCHAR, Pay_date, 103) AS [Pay_date],Recpt_mode,Recpt_Bnk_Name,Struct_name,Amount from admProvFees where formno='"+ stud_id + "' and Receipt_no='"+ recpt_no + "' and del_flag=0 and Struct_name = '"+ struct_type + "'; select SUM(Amount) as TotalAmount from admProvFees where formno='"+ stud_id + "' and Ayid='"+ ayid + "' and Receipt_no='"+ recpt_no + "' and del_flag=0 and Struct_name='"+ struct_type + "';select F_name+' '+m_name+' '+l_name  [Name],a.Form_no,a.Category,b.Receipt_no,b.Struct_name,b.Pay_date,d.Group_title [Group] from d_adm_applicant a, admProvFees b,OLA_FY_adm_CourseSelection c,m_crs_subjectgroup_tbl d where a.Form_no=b.formno and a.Form_no=c.formno and c.group_id=d.Group_id and a.Del_Flag=0 and b.del_flag=0 and c.del_flag=0 and d.del_flag=0 and a.form_no='"+ stud_id+"'");

                    ds.Tables[0].TableName = "FeeInfo";
                    ds.Tables[1].TableName = "TotalFee";
                    ds.Tables[2].TableName = "StdInfo";
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables["FeeInfo"].Rows.Count == 0 || ds.Tables["TotalFee"].Rows.Count == 0 || ds.Tables["StdInfo"].Rows.Count == 0)
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "$.notify('Something Went Wrong !!!', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0 })", true);
                            return;
                        }
                        else
                        {
                            lblNo.Text = recpt_no;
                            lbl_date.Text = ds.Tables["FeeInfo"].Rows[0]["Pay_date"].ToString();
                            lblName.Text = ds.Tables["StdInfo"].Rows[0]["Name"].ToString().ToUpper();
                            lbl_stud_id.Text = stud_id;
                            lbl_bank_name.Text= ds.Tables["FeeInfo"].Rows[0]["Recpt_Bnk_Name"].ToString().ToUpper();
                            amt_no.Text = ds.Tables["TotalFee"].Rows[0]["TotalAmount"].ToString();
                            lbl_payment_mode.Text = ds.Tables["FeeInfo"].Rows[0]["Recpt_mode"].ToString().ToUpper();
                            lbl_feetype.Text = "Provisional";
                            long number = long.Parse(ds.Tables["TotalFee"].Rows[0]["TotalAmount"].ToString());
                            lblamount.Text = ConvertNumberToWords(number) + " Rupees Only";
                            lblcourse.Text = ds.Tables["StdInfo"].Rows[0]["Group"].ToString().ToUpper();
                            lblcategory.Text = ds.Tables["StdInfo"].Rows[0]["Category"].ToString();
                            gridstructre.DataSource = ds.Tables["FeeInfo"];
                            gridstructre.DataBind();

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

    public string ConvertNumberToWords(long number)
    {

        if (number == 0)
            return "Zero Rupees Only";

        if (number < 0)
            return "Minus " + ConvertNumberToWords(Math.Abs(number));

        string words = "";

        if ((number / 10000000) > 0)
        {
            words += ConvertNumberToWords(number / 10000000) + " Crore ";
            number %= 10000000;
        }

        if ((number / 100000) > 0)
        {
            words += ConvertNumberToWords(number / 100000) + " Lakh ";
            number %= 100000;
        }

        if ((number / 1000) > 0)
        {
            words += ConvertNumberToWords(number / 1000) + " Thousand ";
            number %= 1000;
        }

        if ((number / 100) > 0)
        {
            words += ConvertNumberToWords(number / 100) + " Hundred ";
            number %= 100;
        }

        if (number > 0)
        {
            if (words != "")
                words += "and ";

            string[] unitsMap = new[]
            {
            "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine",
            "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen",
            "Sixteen", "Seventeen", "Eighteen", "Nineteen"
        };

            string[] tensMap = new[]
            {
            "Zero", "Ten", "Twenty", "Thirty", "Forty", "Fifty",
            "Sixty", "Seventy", "Eighty", "Ninety"
        };

            if (number < 20)
            {
                words += unitsMap[number];
            }
            else
            {
                words += tensMap[number / 10];
                if ((number % 10) > 0)
                    words += " " + unitsMap[number % 10];
            }
        }

        return words.Trim();
    }
}