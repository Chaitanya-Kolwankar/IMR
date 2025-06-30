using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Portals_Staff_Admission_Master_CategoryCast : System.Web.UI.Page
{
    Class1 db = new Class1();
    DataSet ds = new DataSet();
    //Class1 db  =new Class
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            gridBind();
            dropdownBInd();
            grid();
            categoryTxt.Text = string.Empty;
        }
     
  //     gridView1.HeaderRow.TableSection = TableRowSection.TableHeader;

    }

    public void gridBind()
    {
        ds = db.fillDataset("select * from State_category_details where del_flag=0 ");

        gridView1.DataSource = ds;
        gridView1.DataBind();
    }

    private void insertMain1()
    { 
    bool result=db.DMLqueries("insert into Main values('"+categoryTxt.Text+"',0)");
    if (result)
    {

        grid();
        dropdownBInd();
        categoryTxt.Text = string.Empty;
        gridView1.HeaderRow.TableSection = TableRowSection.TableHeader;

       
    }
    
    }

    private void updateMain1()
    {
        bool result = db.DMLqueries("update Main set main='" + categoryTxt.Text + "' where id='" + mainId.Text+ "'");
        if (result)
        {

            grid();
            insertMain.Text = "Insert";
            categoryTxt.Text = string.Empty;
            dropdownBInd();
           // dropDown.Items.Insert(0, new ListItem("--Select--", "0"));
            gridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

    }

    protected void dropDown_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(dropDown.SelectedValue=="0")
        {

            ds = db.fillDataset("select * from State_category_details where  del_flag=0");
            gridView1.DataSource = ds;
            gridView1.DataBind();
            parent.Text = string.Empty;
            child.Text = string.Empty;
        }

        else if (dropDown.SelectedValue == dropDown.SelectedItem.ToString())
        {

            ds = db.fillDataset("select * from State_category_details where Main='" + dropDown.SelectedItem.ToString() + "' and del_flag=0");
            gridView1.DataSource = ds;
            gridView1.DataBind();
            parent.Text = string.Empty;
            child.Text = string.Empty;
        }
        
         gridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
    }




    protected void gridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        // Label ID1 = (Label)gridView1.Rows[e.RowIndex].FindControl("id");
        Label myid = (Label)gridView1.Rows[e.RowIndex].FindControl("id");
        Label Parent = (Label)gridView1.Rows[e.RowIndex].FindControl("parentTxt");
        Label Child = (Label)gridView1.Rows[e.RowIndex].FindControl("childTxt");
        Label main = (Label)gridView1.Rows[e.RowIndex].FindControl("mainTxt");
        
        insert.Text = "Update";


        //ScriptManager.RegisterStartupScript(this, GetType(), "createDataTable ", "createDataTable();", true);
        //dropdownBInd();
        dropDown.SelectedValue = main.Text.ToString().Trim();
        //dropDown.Items.Insert(0, new ListItem("--Select--", "0"));
        id.Text = myid.Text;
        parent.Text = Parent.Text;
        child.Text = Child.Text;
        gridView1.HeaderRow.TableSection = TableRowSection.TableHeader;

    }
    protected void clear_Click(object sender, EventArgs e)
    {
        
        parent.Text = string.Empty;
        child.Text = string.Empty;
        dropDown.SelectedValue = "0";
        insert.Text = "Add";
        dropDown.Enabled = true;
     //   dropDown.SelectedValue = "";
        gridBind();
        //dropdownBInd();
      //  dropDown.Items.Insert(0, new ListItem("--Select--", "0"));
        gridView1.HeaderRow.TableSection = TableRowSection.TableHeader;

    }

    private void inserting()
    {

        if (dropDown.SelectedValue != "0")
        {

                 bool result = db.DMLqueries("insert into State_category_details values('" + dropDown.SelectedValue + "','" + parent.Text + "','" + child.Text + "',0)");

            if (result)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "func", "notify('Record Inserted Successfully','success')", true);
                gridBind();
                gridView1.HeaderRow.TableSection = TableRowSection.TableHeader;


            }
        }
        else 
        
        
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "func", "notify('please select category','danger')", true);
            gridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
 
        }


    }


    protected void insert_Click(object sender, EventArgs e)
    {

        if (insert.Text == "Add")
        {
            inserting();
        }
        else if (insert.Text == "Update")
        {
             updating();
        }
    }


    private void dropdownBInd()
    {
        ds = db.fillDataset("select * from Main where del_flag=0");
        dropDown.DataSource = ds;
        dropDown.DataValueField="main";
        dropDown.DataTextField = "main";

        dropDown.DataBind();
        dropDown.Items.Insert(0, new ListItem("--Select--", "0"));
        grid();
       
 
        //dropDown.DataBind();
    }


    public void updating()
    {
        bool result = db.DMLqueries("update State_category_details set Main='" + dropDown.SelectedValue + "',Parent='" + parent.Text + "',Child='" + child.Text + "' where id='" + id.Text + "'");

        if (result)
        {
            parent.Text = string.Empty;
            child.Text = string.Empty;

            insert.Text = "Add";
            dropDown.Enabled = true;
          //  dropDown.SelectedValue = "0";

            gridBind();
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "notify", "notify('Data updated successfully','success')", true);
        }

    }



    protected void deleteData_Click(object sender, EventArgs e)
    {
        LinkButton btn = sender as LinkButton;
        GridViewRow gvr = btn.NamingContainer as GridViewRow;

        int id = Convert.ToInt32(gridView1.DataKeys[gvr.RowIndex].Value.ToString());
        bool result = db.DMLqueries("update State_category_details set del_flag = 1 where id='" + id + "'");
        if (result)
        {

            gridBind();
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "notify", "notify('Data deleted successfully','success')", true);
            parent.Text = string.Empty;
            child.Text = string.Empty;

            insert.Text = "Add";
            dropDown.Enabled = true;
         
         //   dropDown.SelectedValue = "0";
            dropdownBInd();

        }
        gridBind();


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

    private void grid()
    {
       ds = db.fillDataset("select * from Main where del_flag=0");

       mainGrid1.DataSource = ds;
       mainGrid1.DataBind();
    }

    protected void selectData_Click(object sender, EventArgs e)
    {

    }

    protected void insertMain_Click(object sender, EventArgs e)
    {

        if (insertMain.Text == "Insert")
        {
            insertMain1();
        }
        else if (insertMain.Text == "Update")
        {
            updateMain1();
        }

        
    }


    protected void mainGrid_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        Label txt = (Label)mainGrid1.Rows[e.RowIndex].FindControl("txtmodal");
        Label id = (Label)mainGrid1.Rows[e.RowIndex].FindControl("idmodal");
        categoryTxt.Text = txt.Text;

        mainId.Text = id.Text;

        insertMain.Text = "Update";

        gridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
    }
    protected void modalDelete_Click(object sender, EventArgs e)
    {
        LinkButton btn = sender as LinkButton;
        GridViewRow gvr = btn.NamingContainer as GridViewRow;

        int id = Convert.ToInt32(mainGrid1.DataKeys[gvr.RowIndex].Value.ToString());

        bool result = db.DMLqueries("update Main set del_flag=1 where id='"+id+"'");

        if (result)
        {
            grid();
            categoryTxt.Text = string.Empty;
            insertMain.Text = "Insert";
            dropdownBInd();
            gridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }

    protected void clearTxt_Click(object sender, EventArgs e)
    {
        categoryTxt.Text = string.Empty;
        insertMain.Text = "Insert";
        gridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
    }
}