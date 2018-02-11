using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
public partial class index : System.Web.UI.Page
{
    SqlConnection con;
    protected void Page_Load(object sender, EventArgs e)
    {
        con = new SqlConnection("server=.;uid=sa;pwd=macfast@1;database=crime_db");
        con.Open();
    }
    protected void login_Click(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand("select * from login_tb where username='" + user.Text + "' and password='" + pass.Text + "'",con);
        SqlDataReader dr = cmd.ExecuteReader();
        if(!dr.Read())
        {
            logerr.InnerHtml = "Invalid credentials. Please try again with valid credentials.";
        }
        else
        {
            if (dr.GetString(2).ToString() == "admin")
            {
                Session["user"] = user.Text;
                Response.Redirect("admin/home.aspx"); 
                
            }
            else if (dr.GetString(2).ToString() == "ps")
            {
                Session["user"] = user.Text;
                Response.Redirect("Police_Station/home.aspx");
                
            }
        }
    }

}