using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;

public partial class FeeReceiptMergeFees : System.Web.UI.Page
{
    Class1 cls = new Class1();
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        string stud_id = "", year = "", recpt_no = "";

        //stud_id = Request.QueryString["id"];
        //recpt_no = Request.QueryString["recpt"];
        //year = Request.QueryString["ayid"];
        if (!IsPostBack)
        {
            try
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables.Contains("Error") == true)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "$.notify('" + ds.Tables["Error"].Rows[0][0].ToString() + "', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0 })", true);
                    }
                    else
                    {
                        string engg = "";
                        if (ds.Tables["Group"].Rows[0]["Group_id"].ToString() != "GRP042")
                        {
                            engg = " Engineering ";
                        }

                        lblNo.Text = ds.Tables["Name"].Rows[0]["stud_id"].ToString() + "/" + ds.Tables["Name"].Rows[0]["Receipt_no"].ToString();
                        lbl_date.Text = ds.Tables["Structure"].Rows[0]["Date"].ToString();
                        lblName.Text = ds.Tables["Name"].Rows[0]["name"].ToString().ToUpper();
                        string inwords = ds.Tables["Calculated"].Rows[0]["Inwords"].ToString();

                        TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
                        lblamount.Text = textInfo.ToTitleCase(inwords.ToLower());
                        lblcourse.Text = ds.Tables["Group"].Rows[0]["Group_title"].ToString().ToUpper() + engg + " " + ds.Tables["Group"].Rows[0]["Year"].ToString().ToUpper();
                        lblcategory.Text = ds.Tables["Name"].Rows[0]["stud_category"].ToString();
                        //gridstructre.DataSource = ds.Tables["Structure"];
                        //gridstructre.DataBind();
                        //gridpayment.DataSource = ds.Tables["Payment"];
                        //gridpayment.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "$.notify('" + ex.ToString() + "', { color: '#fff', background: '#D44950', blur: 0.2, delay: 0 })", true);
            }
        }
        //if (stud_id != "" && year != "" && recpt_no != "" && stud_id != null && year != null && recpt_no != null)
        //{
           
        //}
        //else
        //{
        //    Response.Redirect("login.aspx", true);
        //}
    }
}