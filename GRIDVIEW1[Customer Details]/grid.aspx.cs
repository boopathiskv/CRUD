using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace GRIDVIEW1_Customer_Details_
{
    public partial class grid : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                txtid.Focus();
                Load();
            }
        }

       protected void Load()
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                string sql = "select * from Employ";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {
                    GridView1.DataSource = dr;
                    GridView1.DataBind();
                }
                con.Close();
            }

        }
        void Clear()
        {
            txtid.Text = "";
            txtna.Text = "";
            txtsal.Text = "";
        }

        protected void btnsav_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                string sql = "insert into Employ values('"+txtid.Text+ "','" + txtna.Text + "','" + txtsal.Text + "')";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                int t = cmd.ExecuteNonQuery();
                if(t>0)
                {
                    Response.Write("<script>alert('Inserted Successfull')</script>");
                }
                con.Close();
                Load();
                Clear();
            }
        }

        protected void btncan_Click(object sender, EventArgs e)
        {
            Clear();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            Load();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
            string name = ((TextBox)GridView1.Rows[e.RowIndex].Cells[1].Controls[0]).Text;
            string salary = ((TextBox)GridView1.Rows[e.RowIndex].Cells[2].Controls[0]).Text;

            using (SqlConnection con = new SqlConnection(cs))
            {
                string sql = "update Employ set ename='" + name + "',esalary='" + salary + "' where eid='" +id+"'  ";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                int t = cmd.ExecuteNonQuery();
                if(t>0)
                {
                    Response.Write("<script>alert('updated')</script>");
                    GridView1.EditIndex = -1;
                    Load();

                }
                con.Close();
            }
         }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            Load();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());


            using (SqlConnection con = new SqlConnection(cs))
            {
                string sql ="delete Employ where eid='"+id+"'";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                int res = cmd.ExecuteNonQuery();
                if(res==1)
                {
                    Response.Write("<script>alert('Deleted')</script>");

                    GridView1.EditIndex = -1;
                    Load();
                }
            }

        }
    }
}