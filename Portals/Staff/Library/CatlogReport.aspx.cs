using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using System.Text;
using System.IO;
using Ionic.Zip;
using ICSharpCode.SharpZipLib.Zip;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Diagnostics;
public partial class CatlogReport : System.Web.UI.Page
{
    QueryClass qryCls = new QueryClass();
    attendLogClass logCls = new attendLogClass();
    Class1 cls1 = new Class1();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                string str = "select distinct  substring(SUBSTRING( ACCESSION_NO ,1,PATINDEX('%[0-9]%', ACCESSION_NO )), 1, (len(SUBSTRING( ACCESSION_NO ,1,PATINDEX('%[0-9]%', ACCESSION_NO ))) - 1)) prefix  from lib_book_MASTER where ( ACCESSION_NO is not null or  ACCESSION_NO <>'' ) and substring(SUBSTRING( ACCESSION_NO ,1,PATINDEX('%[0-9]%', ACCESSION_NO )), 1, (len(SUBSTRING( ACCESSION_NO ,1,PATINDEX('%[0-9]%', ACCESSION_NO ))) - 1)) <>''  order by 1";
                DataTable dt = cls1.fillDataTable(str);
                ddlloadprefix.DataSource = dt;
                ddlloadprefix.DataTextField = "prefix";
                ddlloadprefix.DataValueField = "prefix";
                ddlloadprefix.DataBind();
            }
            catch (Exception ex)
            {
                Response.Redirect("Login.aspx");
            }
        }
    }
  
    protected void btnGetData1_Click(object sender, EventArgs e)
    {
        string str = "select  ACCESSION_NO ,TITLE,AUTHOR ,	EDITION,	PUBLISHER,	CALLNO ,	ISBN ,	LANG ,	KEYWORD,	YEAR ,	NOOFPAGES,	SUBJ ,	REMARK ,	ACC_MATERIALS,	CATOGARY ,	ISSUE_TYPE ,	BOUND,	DONOR_ID ,		BILL_NO,	BILL_DT,	MRP,	DISCOUNT ,	Discount_type,	PRICE,	VENDOR ,	REG_DT  from lib_book_master where accession_no like '%" + ddlloadprefix.SelectedItem.Text.TrimEnd() + "%' and Left(accession_no,patindex('%[0-9]%',accession_no)-1)='" + ddlloadprefix.SelectedItem.Text.TrimEnd() + "' order by cast (replace(accession_no,'" + ddlloadprefix.SelectedItem.Text.TrimEnd() + "','') as int)";
        DataTable dt = cls1.fillDataTable(str);
        if (dt.Rows.Count > 0)
        {
            loader.Visible = true;
            id_grid.DataSource = dt;
            id_grid.DataBind();
            loader.Visible = false;
            //GridView gv = new GridView();
            //gv.DataSource = dt;
            //gv.DataBind();
            //Response.Clear();
            //Response.AddHeader("content-disposition", "attachment;filename=Count.xls");
            //Response.ContentType = "application/vnd.ms-excel";

            //StringWriter sw = new StringWriter();
            //HtmlTextWriter hw = new HtmlTextWriter(sw);
            //gv.RenderControl(hw);
            //Response.Output.Write(sw.ToString());


            //Response.End();
        }
    }
    protected void btnGetExcel_Click(object sender, EventArgs e)
    {
        //GridView gv = new GridView();
        //gv.DataSource = dt;
        //gv.DataBind();
        Response.Clear();
        Response.AddHeader("content-disposition", "attachment;filename=Count.xls");
        Response.ContentType = "application/vnd.ms-excel";

        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);

        id_grid.RenderControl(hw);
        Response.Output.Write(sw.ToString());


        Response.End();
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
           server control at run time. */
    }

    protected void btnCategoriesGetdata_Click(object sender, EventArgs e)
    {

        string str = "select ACCESSION_NO , TITLE,AUTHOR ,	EDITION,	PUBLISHER,	CALLNO ,	ISBN ,	LANG ,	KEYWORD,	YEAR ,	NOOFPAGES,	SUBJ ,	REMARK ,	ACC_MATERIALS,	CATOGARY ,	ISSUE_TYPE ,	BOUND,	DONOR_ID ,		BILL_NO,	BILL_DT,	MRP,	DISCOUNT ,	Discount_type,	PRICE,	VENDOR ,	REG_DT  from lib_book_master  where CATOGARY='" + DropDownList1.SelectedItem.Text + "' and del_flag='0'";
        DataTable dt = cls1.fillDataTable(str);
        if (dt.Rows.Count > 0)
        {
            loader.Visible = true;
            GridView1.DataSource = dt;
            GridView1.DataBind();
            loader.Visible = false;
            //GridView gv = new GridView();
            //gv.DataSource = dt;
            //gv.DataBind();
            //Response.Clear();
            //Response.AddHeader("content-disposition", "attachment;filename=Count.xls");
            //Response.ContentType = "application/vnd.ms-excel";

            //StringWriter sw = new StringWriter();
            //HtmlTextWriter hw = new HtmlTextWriter(sw);
            //gv.RenderControl(hw);
            //Response.Output.Write(sw.ToString());


            //Response.End();
        }
        else
        {
            GridView1.DataSource = null;
            GridView1.DataBind();
        }
    }
    protected void btnCategoriesGetexcel_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.AddHeader("content-disposition", "attachment;filename=Count.xls");
        Response.ContentType = "application/vnd.ms-excel";

        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);

        GridView1.RenderControl(hw);
        Response.Output.Write(sw.ToString());


        Response.End();
    }
    protected void btncountreport_Click(object sender, EventArgs e)
    {
 string str = "select distinct  substring(SUBSTRING( ACCESSION_NO ,1,PATINDEX('%[0-9]%', ACCESSION_NO )), 1, (len(SUBSTRING( ACCESSION_NO ,1,PATINDEX('%[0-9]%', ACCESSION_NO ))) - 1)) prefix  from lib_book_MASTER where ( ACCESSION_NO is not null or  ACCESSION_NO <>'' ) and substring(SUBSTRING( ACCESSION_NO ,1,PATINDEX('%[0-9]%', ACCESSION_NO )), 1, (len(SUBSTRING( ACCESSION_NO ,1,PATINDEX('%[0-9]%', ACCESSION_NO ))) - 1)) <>''  order by 1";
        DataTable dt = cls1.fillDataTable(str);
        if (dt.Rows.Count > 0)
        {
            GridView gv = new GridView();
            gv.DataSource = dt;
            gv.DataBind();
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename=Count.xls");
            Response.ContentType = "application/vnd.ms-excel";

            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            gv.RenderControl(hw);
            Response.Output.Write(sw.ToString());


            Response.End();
        }
    }

    protected void btnGetClear_Click(object sender, EventArgs e)
    {
        id_grid.DataSource = null;
        id_grid.DataBind();
    }

    protected void btn_clear_Click(object sender, EventArgs e)
    {
        GridView1.DataSource = null;
        GridView1.DataBind();
    }
}