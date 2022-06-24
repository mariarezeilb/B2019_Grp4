using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace BMS
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(@"Data Source=BALDIVICIO;Initial Catalog=login;Integrated Security=True;"))
            {
                sqlCon.Open();
                string query = "SELECT COUNT(1) FROM Users WHERE Username=@Username AND Password=@Password";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@Username", txtUsername.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Password", txtpassword.Text.Trim());
                int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                if (count == 1)
                {
                    Session["Username"] = txtUsername.Text.Trim();
                    Response.Redirect("dashboard.aspx");
                }
                else
                {
                    lblError.Text = "Invalid Username or Password";
                }
                if (txtUsername.Text.Trim() == "" || txtpassword.Text.Trim() == "")
                {
                    this.lblError.Text = "Please Enter Username and Password";
                }
                else
                {
                    this.lblError.Text = "Invalid Username or Password";

                    var username = txtUsername.Text.Trim();
                    var password = txtpassword.Text.Trim();


                }
            }
        }
    }
}