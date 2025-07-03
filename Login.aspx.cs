using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IdentityModel.Tokens.Jwt;

namespace Bakery
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            error.Visible = false;
            
        }
        public void login_btn_Click(object sender, EventArgs e)
        {
            using(SqlConnection con = new SqlConnection(@"Data Source=SQL5063.site4now.net,1433;Initial Catalog=db_a7c364_db;User Id=db_a7c364_db_admin;Password=Abhinav123"))
            {
                con.Open();
                string query = "SELECT COUNT(1) FROM tbl_users WHERE username=@username AND password=@password";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@username",username_tb.Text.Trim());
                cmd.Parameters.AddWithValue("@password", pass_tb.Text.Trim());
                int c = Convert.ToInt32(cmd.ExecuteScalar());
                if(c==1)
                {
                    Session["username"] = username_tb.Text.Trim();
                    Response.Redirect("Home.aspx");
                }
                else
                {
                    Console.WriteLine(" Invalid credentials");
                    error.Visible = true;
                    username_tb.Text = "";
                    pass_tb.Text = "";
                }
                con.Close();
            }
        }
        protected void register_btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }
    }
}