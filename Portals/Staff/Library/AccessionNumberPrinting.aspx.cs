using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MessagingToolkit.QRCode.Codec;
using MessagingToolkit.QRCode.Codec.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Security.Policy;
using System.IO;
using System.Text;


public partial class AccessionNumberPrinting : System.Web.UI.Page
{
    Class1 cls = new Class1();
    string val = "";
    protected void Page_Load(object sender, EventArgs e)
    {
      //  Session["GridDataset"] = "";

  
      
    }
    public void LoadPrefix(string str)
    {
        DataSet ds = new DataSet();
        String qry = "";
        if (str == "BOOK")
     {
         qry = "select distinct   substring(SUBSTRING( ACCESSION_NO ,1,case when PATINDEX('%[0-9]%', ACCESSION_NO )='0' then '1' else PATINDEX('%[0-9]%', ACCESSION_NO ) end ), 1,(len(SUBSTRING( ACCESSION_NO ,1,case when PATINDEX('%[0-9]%', ACCESSION_NO )='0' then '1' else PATINDEX('%[0-9]%', ACCESSION_NO ) end )) - 1)) prefix  from lib_book_MASTER where ( ACCESSION_NO is not null or  ACCESSION_NO <>'' ) and substring(SUBSTRING( ACCESSION_NO ,1,case when PATINDEX('%[0-9]%', ACCESSION_NO )='0' then '1' else PATINDEX('%[0-9]%',ACCESSION_NO ) end ), 1,(len(SUBSTRING( ACCESSION_NO ,1,case when PATINDEX('%[0-9]%', ACCESSION_NO )='0' then '1' else PATINDEX('%[0-9]%',ACCESSION_NO ) end )) - 1)) <>''  order by 1";
        
     }
     else if(str=="CD")
     {
         qry = "select distinct  substring(SUBSTRING( ACCESSION_NO ,1,case when PATINDEX('%[0-9]%', ACCESSION_NO )='0' then '1' else PATINDEX('%[0-9]%', ACCESSION_NO ) end ), 1,(len(SUBSTRING( ACCESSION_NO ,1,case when PATINDEX('%[0-9]%', ACCESSION_NO )='0' then '1' else PATINDEX('%[0-9]%', ACCESSION_NO ) end )) - 1)) prefix  from lib_CD_MASTER where ( ACCESSION_NO is not null or  ACCESSION_NO <>'' ) and  substring(SUBSTRING( ACCESSION_NO ,1,case when PATINDEX('%[0-9]%', ACCESSION_NO )='0' then '1' else PATINDEX('%[0-9]%',ACCESSION_NO ) end ), 1,(len(SUBSTRING( ACCESSION_NO ,1,case when PATINDEX('%[0-9]%', ACCESSION_NO )='0' then '1' else PATINDEX('%[0-9]%',ACCESSION_NO ) end )) - 1)) <>''  order by 1";

     }
     //else if (str == "SERIAl") {
     //    qry = "select distinct  substring(SUBSTRING( ACCESSION_NO ,1,PATINDEX('%[0-9]%', ACCESSION_NO )), 1, (len(SUBSTRING( ACCESSION_NO ,1,PATINDEX('%[0-9]%', ACCESSION_NO ))) - 1)) prefix  from lib_book_MASTER where ( ACCESSION_NO is not null or  ACCESSION_NO <>'' ) and substring(SUBSTRING( ACCESSION_NO ,1,PATINDEX('%[0-9]%', ACCESSION_NO )), 1, (len(SUBSTRING( ACCESSION_NO ,1,PATINDEX('%[0-9]%', ACCESSION_NO ))) - 1)) <>''  order by 1";
     //}


        SqlConnection con = new SqlConnection();

        con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);

        //if (ddl_connect.Text.StartsWith("Viva Engg"))
        //{
        //    con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect_engg"].ConnectionString);
        //}
        //else if (ddl_connect.Text.StartsWith("MCA")) { con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect_mca"].ConnectionString); }
        //else if (ddl_connect.Text.StartsWith("pharmacy")) { con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect_pha"].ConnectionString); }
        //else if (ddl_connect.Text.StartsWith("Viva IMR")) { con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString); }
        //else if (ddl_connect.Text.StartsWith("Viva IMS")) { con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect_ims"].ConnectionString); }

        SqlDataAdapter da = new SqlDataAdapter(qry,con);
        da.Fill(ds);
        //ds=cls.fill_dataset(qry);

        if (ds.Tables[0].Rows.Count > 0)
        {
            DataRow drr = ds.Tables[0].NewRow();
            drr[0] = "--Select--";
            ds.Tables[0].Rows.InsertAt(drr, 0);
            ddlloadaccession.DataSource = ds.Tables[0];
            ddlloadaccession.DataTextField = ds.Tables[0].Columns[0].ColumnName;
            ddlloadaccession.DataBind();
            ddlloadaccession.SelectedIndex = 0;
        }
        else
        {
            ddlloadaccession.DataSource = null;
            ddlloadaccession.DataBind();
        }


    }

    public void clear()
    {
        ddlloadaccession.SelectedIndex=0;
        ddlsearchtype.SelectedIndex = 0;
        gdvloaddata.DataSource = null;
        gdvloaddata.DataBind(); 
        numfrom.Value = "";
        numto.Value = "";
        Label1.Text = "Total:-0";
        Session["GridDataset"] = "";
        //gdvaccess.DataSource = null;
        //gdvaccess.DataBind(); 
        txtenteraccession.Text = "";
    }

    protected void btnclear_Click(object sender, EventArgs e)
    {
        clear();
        //BackColor="#DEBA84"
    }

    


    public void BindGrid()
    {
        if ((numfrom.Value != "" && numto.Value != "") || txtenteraccession.Text != "")
        {
            string constr = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            string ldlacc = ddlloadaccession.Text;
            int diff = 0;
            int diff1 = 0;
            if (txtenteraccession.Text == "")
            {
                diff = Convert.ToInt32(numfrom.Value);
                diff1 = Convert.ToInt32(numto.Value);
            }
            DataTable dt = new DataTable();
            dt.Columns.Add("Accession");
            if (gdvloaddata.Rows.Count > 0)
            {
                if (Session["GridDataset"] != "")
                {
                    dt = (DataTable)Session["GridDataset"];
                }
            }
            int count = 0;
            string ID = "";
            string err_lbl = "";
            string acc_val = "";
            if (txtenteraccession.Text == "")
            {
                for (int i = diff; i < diff1 + 1; i++)
                {
                    count++;
                    if (numfrom.Value.StartsWith("0") && Convert.ToString(i).Length != numto.Value.Length)
                    {
                       
                        acc_val = ldlacc.Trim() + "0" + Convert.ToString(i).Trim();
                    }
                    else{
                        acc_val = ldlacc.Trim().ToUpper() + Convert.ToString(i).Trim();
                    }
                    string str = "select * from lib_book_master where accession_no='" + acc_val + "' and del_flag='0'";
                    DataTable dt11 = new DataTable();
                    SqlConnection con = new SqlConnection();

                    con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
                    //if (ddl_connect.Text.StartsWith("Viva Engg"))
                    //{
                    //    con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect_engg"].ConnectionString);
                    //}
                    //else if (ddl_connect.Text.StartsWith("MCA")) { con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect_mca"].ConnectionString); }
                    //else if (ddl_connect.Text.StartsWith("pharmacy")) { con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect_pha"].ConnectionString); }
                    //else if (ddl_connect.Text.StartsWith("Viva IMR")) { con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString); }
                    //else if (ddl_connect.Text.StartsWith("Viva IMS")) { con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect_ims"].ConnectionString); }

                    SqlDataAdapter da = new SqlDataAdapter(str, con);
                    da.Fill(dt11);
                   
                    if (dt11.Rows.Count > 0)
                    {
                        if (ID == "")
                        {
                            ID = acc_val;
                        }
                        else { ID = ID + "," + acc_val; }

                        dt.Rows.Add(acc_val);
                    }
                    else
                    {
                        if (err_lbl == "")
                        {
                            err_lbl = acc_val;
                        }
                        else
                        {
                            err_lbl = err_lbl + acc_val;
                        }
                    }
                }
            }
            else
            {
                 val = txtenteraccession.Text;
                string str = "select * from lib_book_master where accession_no='" + val + "' and del_flag='0'";
                DataTable dt11 = new DataTable();
                SqlConnection con = new SqlConnection();

                con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
                //if (ddl_connect.Text.StartsWith("Viva Engg"))
                //{
                //    con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect_engg"].ConnectionString);
                //}
                //else if (ddl_connect.Text.StartsWith("MCA")) { con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect_mca"].ConnectionString); }
                //else if (ddl_connect.Text.StartsWith("pharmacy")) { con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect_pha"].ConnectionString); }
                //else if (ddl_connect.Text.StartsWith("Viva IMR")) { con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString); }
                //else if (ddl_connect.Text.StartsWith("Viva IMS")) { con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect_ims"].ConnectionString); }

                SqlDataAdapter da = new SqlDataAdapter(str, con);
                da.Fill(dt11);
                    if (dt11.Rows.Count > 0)
                    {
                        if (ID == "")
                        {
                            ID = val;
                        }
                        else { ID = ID + "," + val; }
   
                        dt.Rows.Add(val);
                    }
                    else
                    {
                        if (err_lbl == "")
                        {
                            err_lbl = val;
                        }
                        else
                        {
                            err_lbl = err_lbl + val;
                        }
                    }
            }
            txtenteraccession.Text = "";
            //Session["Accessprint"] = ID;
            gdvloaddata.DataSource = dt;
           Session["GridDataset"] = dt;
            gdvloaddata.DataBind();
            Label2.Text = "Book Not Exists:-"+err_lbl;
        }
    }


    protected void btnadd_Click(object sender, EventArgs e)
    {
        if ((numfrom.Value != "" && numto.Value != "") || txtenteraccession.Text!="")
        {

            int diff = 0;
            int diff1 = 0;
            if (txtenteraccession.Text == "")
            {
                 diff = Convert.ToInt32(numfrom.Value);
                 diff1 = Convert.ToInt32(numto.Value);
            }

            int val = diff1 - diff +1;
            int grid_diff = Convert.ToInt32(gdvloaddata.Rows.Count) + val;
            if (val <= 36 && grid_diff <= 36)
            {
                BindGrid();
                Label1.Text = "Total:-" + gdvloaddata.Rows.Count;
            }
            else
           {
            //    gdvloaddata.DataSource = null;
            //    gdvloaddata.DataBind(); 
                
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Range should be of 36 numbers only.')", true);
            }
        }
        else
        {
            if (val != "")
            {
                 
        
            }
            else
            {
                gdvloaddata.DataSource = null;
                gdvloaddata.DataBind();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Fill All Details.')", true);
            }
        }
        
     
    }
    protected void ddlsearchtype_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadPrefix(ddlsearchtype.Text);
    }
    protected void ddlsearchtype_TextChanged(object sender, EventArgs e)
    {
        LoadPrefix(ddlsearchtype.Text);
    }


    protected void btnprintallno_Click(object sender, EventArgs e)
    {
        txtenteraccession.Text = "";
        string id = "";
        for (int i = 0; i < gdvloaddata.Rows.Count; i++)
        {
            if (id == "")
            {
                id = gdvloaddata.Rows[i].Cells[0].Text;
            }
            else
            {
                id = id + "," + gdvloaddata.Rows[i].Cells[0].Text;
            }
        }

        Session["Accessprint"] = id;
        //Session["call_no"] = class_no;

        // Response.Write("<script>window.open('lib_barcode.aspx','_blank')</script>");
        // Response.Redirect("lib_barcode.aspx",true);
        ScriptManager.RegisterClientScriptBlock(this, GetType(), "none", "<script>ShowConfirm();</script>", false);
        //Response.Write("<script>window.open('lib_barcode.aspx','_blank');</script>");
        //Response.Redirect("lib_barcode.aspx");
        //ScriptManager.RegisterClientScriptBlock(this, GetType(), "none", "<script>ShowConfirm();</script>", false);

        // btnprintallno.Attributes.Add("OnClientClick", "window.open('lib_barcode.aspx', '_blank');return false;");
        //        Page.ClientScript.RegisterStartupScript(
        //this.GetType(), "OpenWindow", "window.open('lib_barcode.aspx','_newtab');", true);
        // Response.Redirect("lib_barcode.aspx");
    }
  //  protected void Button2_Click(object sender, EventArgs e)
  //  {
  //      DataTable dt = new DataTable(); ;
  //      dt.Columns.Add("Accession");
  //      string val = txtenteraccession.Text;
   
  //      string id = "";
  //      for (int i = 0; i < gdvaccess.Rows.Count; i++)
  //      {
  //          if (id == "")
  //          {
  //              id = gdvaccess.Rows[i].Cells[0].Text;
  //          }
  //          else
  //          {
  //              id = id + "," + gdvaccess.Rows[i].Cells[0].Text;
  //          }
  //      }

  //      Session["Accessprint"] = id;
  //      if (id != "")
  //      {
  //          Response.Write("<script>window.open('lib_barcode.aspx','_blank')</script>");

  ////          Page.ClientScript.RegisterStartupScript(
  ////this.GetType(), "OpenWindow", "window.open('lib_barcode.aspx','_newtab');", true);
  ////Response.Redirect("lib_barcode.aspx");
  //      }


  //      }
  //  protected void Button1_Click(object sender, EventArgs e)
  //  {
        
  //      DataTable dt = new DataTable(); ;
  //      dt.Columns.Add("Accession");
  //      if (gdvaccess.Rows.Count > 0)
  //      {
  //          if (Session["GridDataset"] != "")
  //          {
  //              dt = (DataTable)Session["GridDataset"];
  //          }
  //      }

  //      string val = txtenteraccession.Text;
  //          dt.Rows.Add(val);
  //      gdvaccess.DataSource = dt;
  //      Session["GridDataset"] =dt;
  //      gdvaccess.DataBind();
        
  //  }
    protected void txtenteraccession_TextChanged(object sender, EventArgs e)
    {
        if ((numfrom.Value != "" && numto.Value != "") || txtenteraccession.Text != "")
        {

            int diff = 0;
            int diff1 = 0;
            if (txtenteraccession.Text == "")
            {
                diff = Convert.ToInt32(numfrom.Value);
                diff1 = Convert.ToInt32(numto.Value);
            }

            int val = diff1 - diff + 1;
            int grid_diff = Convert.ToInt32(gdvloaddata.Rows.Count) + val;
            if (val <= 36 && grid_diff <= 36)
            {
                BindGrid();
                Label1.Text = "Total:-" + gdvloaddata.Rows.Count;
            }
            else
            {
                //    gdvloaddata.DataSource = null;
                //    gdvloaddata.DataBind(); 

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Range should be of 36 numbers only.')", true);
            }
        }
        else
        {
            if (txtenteraccession.Text != "")
            {


            }
            else
            {
                gdvloaddata.DataSource = null;
                gdvloaddata.DataBind();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Fill All Details.')", true);
            }
        }
            }
    protected void ddl_connect_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlsearchtype.SelectedIndex > 0)
        {
            LoadPrefix(ddlsearchtype.Text);
        }
    }
}

    


  
   