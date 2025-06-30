using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class editDelete : System.Web.UI.Page
{

    dbmanager db = new dbmanager();
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
         gridBind();
        }
    }

    public void gridBind()
    {
        ds = db.getDataset("select * from State_category_details ");

        gridView1.DataSource = ds;
        gridView1.DataBind();
    }


    protected void dropDown_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (dropDown.SelectedValue == "State")
         {
            ds = db.getDataset("select * from State_category_details where Main='State'");
            gridView1.DataSource = ds;
            gridView1.DataBind();     

        }
         else if (dropDown.SelectedValue == "Reserved Category")
          {
            ds = db.getDataset("select * from State_category_details where Main='Reserved Category'");
            gridView1.DataSource = ds;
            gridView1.DataBind();
          }
     }




    protected void gridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
       // Label ID1 = (Label)gridView1.Rows[e.RowIndex].FindControl("id");
        Label myid = (Label)gridView1.Rows[e.RowIndex].FindControl("id");
        Label Parent = (Label)gridView1.Rows[e.RowIndex].FindControl("parentTxt");
        Label Child = (Label)gridView1.Rows[e.RowIndex].FindControl("childTxt");
        Label main = (Label)gridView1.Rows[e.RowIndex].FindControl("mainTxt");


        if (main.Text == "State")
        {
            dropDown.SelectedValue = "State";
        
        
        }
        else if (main.Text == "Reserved Category")
        {
            dropDown.SelectedValue = "Reserved Category";
        
        }


        //TextBox1.Text = ID1.Text;
        id.Text = myid.Text;
        parent.Text = Parent.Text;
        child.Text = Child.Text;

    }
    protected void clear_Click(object sender, EventArgs e)
    {
        //TextBox1.Text = string.Empty;
     
        parent.Text = string.Empty;
        child.Text = string.Empty;
    }

    private void inserting()
    {

        int result = db.getQuery("insert into State_category_details values('"+dropDown.SelectedValue+"','"+parent.Text+"','"+child.Text+"')");

        if (result > 0)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Inserted Successfully')", true);
            gridBind();

        }
    
    
    }


    protected void insert_Click(object sender, EventArgs e)
    {
        inserting();
    }

    protected void update_Click(object sender, EventArgs e)
    {

        int result = db.getQuery("update State_category_details set Main='"+dropDown.SelectedValue+"',Parent='"+parent.Text+"',Child='"+child.Text+"' where id='"+id.Text+"'");

        if (result > 0)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('data updated successfully')", true);
            gridBind();
        }

        
    }
    protected void deleteData_Click(object sender, EventArgs e)
    {
        //int result = db.getQuery();
    }
    protected void gridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //check if the row is the header row
        if (e.Row.RowType == DataControlRowType.Header)
        {
            //add the thead and tbody section programatically
            e.Row.TableSection = TableRowSection.TableHeader;
        }
    }
}