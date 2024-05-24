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
    public partial class Contact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["NewsConnectionString"].ConnectionString;

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                try
                {
                    string query = "INSERT INTO contact (name, lastname, number, email, message) VALUES (@name, @lastname, @number, @Email, @message)";
                    SqlCommand cm = new SqlCommand(query, cn);

                    // Add parameters to prevent SQL injection
                    cm.Parameters.AddWithValue("@name", txtName.Text);
                    cm.Parameters.AddWithValue("@lastname", txtLastName.Text);
                    cm.Parameters.AddWithValue("@number", txtNumber.Text);
                    cm.Parameters.AddWithValue("@Email", txtEmail.Text);
                    cm.Parameters.AddWithValue("@message", txtMessage.Text);

                    cn.Open();
                    cm.ExecuteNonQuery();

                    // Clear the text fields after successful insertion
                    txtName.Text = "";
                    txtLastName.Text = "";
                    txtNumber.Text = "";
                    txtEmail.Text = "";
                    txtMessage.Text = "";

                    // Optionally display a success message
                    Response.Write("Contact information submitted successfully.");
                }
                catch (Exception ex)
                {
                    // Handle exceptions
                    Response.Write("An error occurred: " + ex.Message);
                }
            }
        }
    }
}