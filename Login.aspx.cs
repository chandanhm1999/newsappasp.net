using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace chandIT
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUN.Text) || string.IsNullOrEmpty(txtPW.Text))
            {
                // Handle empty fields
                lblMessage.Text = "Please enter both username and password.";
                return;
            }

            string connectionString = ConfigurationManager.ConnectionStrings["NewsConnectionString"].ConnectionString;

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                try
                {
                    string query = "SELECT * FROM users WHERE username = @username AND password = @password";
                    SqlCommand cm = new SqlCommand(query, cn);

                    // Add parameters to prevent SQL injection
                    cm.Parameters.AddWithValue("@username", txtUN.Text);
                    cm.Parameters.AddWithValue("@password", txtPW.Text); // Ensure passwords are hashed in real applications

                    cn.Open();
                    SqlDataReader reader = cm.ExecuteReader();

                    if (reader.HasRows)
                    {
                        // User found, handle successful login
                        Session["username"] = txtUN.Text;
                        Response.Redirect("Settings.aspx");
                    }
                    else
                    {
                        // User not found, handle failed login
                        lblMessage.Text = "Invalid username or password.";
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    // Handle any errors that may have occurred
                    lblMessage.Text = "An error occurred: " + ex.Message;
                }
            }
        }
    }
}
