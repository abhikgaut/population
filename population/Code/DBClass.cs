using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace DemoWeb
{
    public class DBClass
    {
        SqlConnection Con = null;
         SqlCommand Cmd = null;
        public  int getAppid()
        {
            int C = 0;

            try
            {
                Con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SqlCon1"].ToString());
                Con.Open();
                Cmd = new SqlCommand("select max(Applicationid) from tblPopulation", Con);
                string S = Cmd.ExecuteScalar().ToString();
                if (S == "")
                    C++;
                else
                    C = int.Parse(S)+1;
            
            }
            catch (SqlException E)
            {

            }
            finally { Con.Close(); }
            return C;
        }

        public string SaveMembers(List<Population> L)
        {
            string str = null;
            try
            {
                Con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SqlCon1"].ToString());
                Con.Open();
                Cmd = new SqlCommand("sp_Populate", Con);
                Cmd.CommandType = CommandType.StoredProcedure;
                DataTable Db = new DataTable();
                Db.Columns.Add("ApplicationId",typeof(Int32));
                Db.Columns.Add("MemberId", typeof(Int32));
                Db.Columns.Add("FirstName", typeof(string));
                Db.Columns.Add("MiddleName", typeof(string));
                Db.Columns.Add("LastName", typeof(string));
                Db.Columns.Add("Suffix", typeof(string));
                Db.Columns.Add("Gender", typeof(string));
                Db.Columns.Add("DOB", typeof(DateTime));
                for (int i = 0; i < L.Count; i++)
                {
                    Db.Rows.Add(L[i].ApplicationId, L[i].MemberId, L[i].FirstName, L[i].Middlename, L[i].LastName, L[i].Suffix, L[i].Gender, L[i].Dob);
                }
                SqlParameter P = new SqlParameter("@Populate", Db);
                P.SqlDbType = SqlDbType.Structured;
                Cmd.Parameters.Add(P);
                Cmd.ExecuteNonQuery();
                str= "Application submitted with " + L.Count + " Members details.Your Application id " + L[0].ApplicationId;




            }
            catch (SqlException E)
            { }

               finally {
                Con.Close();
            }
            return str;
        }

    }
}