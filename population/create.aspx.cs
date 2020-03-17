using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace population
{
   
    public partial class create : System.Web.UI.Page
    {

        List<population> list = new List<population>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["P"] != null)
                list = (List<population>)Session["P"];
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            DBClass D = new DBClass();
            string s = D.SaveMembers(list);
            Session.Remove("P");
            Response.Redirect("confirm.aspx?s=" + s);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DBClass D = new DBClass();
            int a = 0;
            population P = new population();

            P.ApplicationID = D.getAppid();

            P.MemberID = list.Count + 1;
            P.FirstName = TextBox1.Text;
            P.MiddleName = TextBox2.Text;
            P.LastName = TextBox3.Text;
            P.Dob = DateTime.Parse(TextBox4.Text);
            P.Suffix = DropDownList1.Text;
            if (Male.Checked)
                P.Gender = "Male";
            else
                P.Gender = "Female";
            list.Add(P);
            Session["P"] = list;
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            DropDownList1.SelectedIndex = -1;
            

        }
        public class DBClass
        {
            SqlConnection Con = null;
            SqlCommand Cmd = null;
            public int getAppid()
            {
                int C = 0;

                try
                {
                    Con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SqlCon1"].ToString());
                    Con.Open();
                    Cmd = new SqlCommand("select max(Applicationid) from Population", Con);
                    string S = Cmd.ExecuteScalar().ToString();
                    if (S == "")
                        C++;
                    else
                        C = int.Parse(S) + 1;

                }
                catch (SqlException E)
                {

                }
                finally { Con.Close(); }
                return C;
            }

            public string SaveMembers(List<population> L)
            {
                string str = null;
                try
                {
                    Con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SqlCon1"].ToString());
                    Con.Open();
                    Cmd = new SqlCommand("insertPop", Con);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    DataTable Db = new DataTable();
                    Db.Columns.Add("ApplicationId", typeof(Int32));
                    Db.Columns.Add("MemberId", typeof(Int32));
                    Db.Columns.Add("FirstName", typeof(string));
                    Db.Columns.Add("MiddleName", typeof(string));
                    Db.Columns.Add("LastName", typeof(string));
                    Db.Columns.Add("Suffix", typeof(string));
                    Db.Columns.Add("Gender", typeof(string));
                    Db.Columns.Add("DOB", typeof(DateTime));
                    for (int i = 0; i < L.Count; i++)
                    {
                        Db.Rows.Add(L[i].ApplicationID, L[i].MemberID, L[i].FirstName, L[i].MiddleName, L[i].LastName, L[i].Suffix, L[i].Gender, L[i].Dob);
                    }
                    SqlParameter P = new SqlParameter("@pop", Db);
                    P.SqlDbType = SqlDbType.Structured;
                    Cmd.Parameters.Add(P);
                    int j = Cmd.ExecuteNonQuery();
                    str = "Application submitted with " + L.Count + " Members details.Your Application id " + L[0].ApplicationID;
                }
                catch (SqlException E)
                { }

                finally
                {
                    Con.Close();
                }
                return str;
            }

        }
    }
}