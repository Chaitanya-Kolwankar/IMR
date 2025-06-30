using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Web.Services;
public partial class StudentInformation : System.Web.UI.Page
{
    Class2 obj = new Class2();
    QueryClass qrycls = new QueryClass();
    DataSet ds = new DataSet();
    //string str;


    protected void Page_Load(object sender, EventArgs e)
    {
        grid_show.Visible = false;
        try
        {
            if (Convert.ToString(Session["emp_id"]) == "")
            {
                Response.Redirect("~/Portals/Staff/Login.aspx");
            }
            else
            {
                obj.chkPassword();
            }
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "func", "notify()", true);
        }
        catch (Exception w)
        {
            Response.Redirect("~/Portals/Staff/Login.aspx");
        }
    }

  [WebMethod]
    public static studentcancellation[]  searchsCanceltudent(string id)
    {
        classWebMethods webCls = new classWebMethods();

        return webCls.searchCancelstudent(id);
    }

  [WebMethod]
  public static bool CancelAdmission(string id, string ayid, string fyid, string remark)
  {
      classWebMethods webCls = new classWebMethods();

      return webCls.cancelAdmission(id, ayid, fyid, remark);
  }
    //============newly added
  [WebMethod]
  public static studentcancellation[] calcDeduction(string crsid, string totfees, string dayspast)
  {
      classWebMethods webCls = new classWebMethods();

      return webCls.calcDeduction(crsid, totfees, dayspast);
  }

  public override void VerifyRenderingInServerForm(Control control)
  {
      //donot remove (for excel report)
  }
    [WebMethod]
  public static STUDENTFEES[] StrudentFeeDetails(string stud_id, string year, string group_id)
  {
      classWebMethods webCls = new classWebMethods();
      return webCls.StrudentFeeDetails(stud_id, year, group_id);
  }
  protected void btn_report_Click(object sender, EventArgs e)
  {
      DataSet ds = new DataSet();

      //old qry
      //string qry = "select distinct a.stud_id,a.stud_f_name+' '+a.stud_M_Name+' '+a.stud_L_Name as name,convert(date,a.stud_dob,105) as DOB ,convert(date,b.cancel_date,105) as "
      //      + " cancelled_date,b.Amount,convert(date,c.Pay_date,105) as paydate from m_std_personaldetails_tbl a,m_std_cancellationdetails_tbl b,m_FeeEntry c"
      //      + " where a.stud_id=b.Stud_id and b.Stud_id=c.Stud_id and b.AYID=c.Ayid and b.Amount=c.Amount and b.AYID='" + Session["acdyear"].ToString() + "'";


      string qry = "select a.STUD_ID,NAME,GROUP_NAME,PAID,CATEGORY,case when convert(date,b.del_dt,105) is null or b.del_dt='' then convert(date,getdate(),105) else convert(date,b.del_dt,105) end as del_dt from Cancel_Rep a,m_std_personaldetails_tbl b where a.AYID='" + Session["Year"].ToString() + "' "
   +" and a.STUD_ID=b.Stud_id";
      ds = obj.fillDataset(qry);
      if (ds.Tables[0].Rows.Count > 0)
      {
          grid_show.Visible = true;
          GridView1.DataSource = ds;
          GridView1.DataBind();
          Response.ClearContent();

          //string date = ds.Tables[0].Rows[0]["DOB"].ToString();     
          //DateTime dt = DateTime.ParseExact(date, "dd/MM/yy", CultureInfo.InvariantCulture);


          Response.AddHeader("content-disposition", "attachment; filename= REPORT.xls");
          Response.ContentType = "application/excel";
          System.IO.StringWriter sw = new System.IO.StringWriter();
          HtmlTextWriter htw = new HtmlTextWriter(sw);
          GridView1.RenderControl(htw);
          Response.Write(sw.ToString());
          Response.End();
      }
      else
      {
          ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "alert('Data not found');", true);
      }
  }
  [WebMethod]
  public static bool InsertFeeEntry(string insert_query)
  {
      classWebMethods webCls = new classWebMethods();
      return webCls.InsertFeeEntry(insert_query);
  }
  
}