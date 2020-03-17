using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace population
{
    public partial class WebForm14 : System.Web.UI.Page
    {

        List<population> list = new List<population>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["P"] != null)
                list =(List<population>)Session["P"];

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DBClass D = new DBClass();
            int a=0;
            population P = new population();
            
                P.ApplicationID = D.getAppid();
             
            P.MemberID = list.Count + 1;
            P.FirstName = fname.Text;
            P.MiddleName = mi.Text;
            P.LastName = lname.Text;
            P.Dob = DateTime.Parse(dob.Text);
            P.Suffix = DropDownList1.Text;
            if (male.Checked)
                P.Gender = "Male";
            else
                P.Gender = "Female";
            list.Add(P);
            Session["P"] = list;
            GridView1.DataSource = list;
            GridView1.DataBind();
            fname.Text = "";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
          //  list = (List<Population>)Session["P"];

            DBClass D = new DBClass();
           string s= D.SaveMembers(list);
            Session.Remove("P");
            Response.Redirect("WebForm15.aspx?s=" + s);
            
        }
       

    }
}