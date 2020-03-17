using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace population
{
    public partial class search : System.Web.UI.Page
    {
        SqlConnection con = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SqlCon1"].ToString());
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlDataAdapter adp = new SqlDataAdapter("select * from population where Firstname=@fn or Lastname=@ln or Dob=@dob or ApplicationID=@appid", con);
            if (TextBox1.Text != null)
                adp.SelectCommand.Parameters.AddWithValue("@fn", TextBox1.Text);
            else
                adp.SelectCommand.Parameters.AddWithValue("@fn", string.Empty);
            if (TextBox2.Text != null)
                adp.SelectCommand.Parameters.AddWithValue("@ln", TextBox2.Text);
            else
                adp.SelectCommand.Parameters.AddWithValue("@ln", string.Empty);
            if (TextBox3.Text != null)
                adp.SelectCommand.Parameters.AddWithValue("@dob",TextBox3.Text);
            else
                adp.SelectCommand.Parameters.AddWithValue("@dob", string.Empty);
            if (TextBox4.Text != null)
                adp.SelectCommand.Parameters.AddWithValue("@appid", TextBox4.Text);
            else
                adp.SelectCommand.Parameters.AddWithValue("@appid", string.Empty);
            DataSet ds = new DataSet();
            adp.Fill(ds, "P");
            GridView1.DataSource = ds.Tables["P"];
            GridView1.DataBind();
        }
    }
}