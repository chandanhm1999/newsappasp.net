using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace chandIT
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Ensure the page load logic only runs when the page is not being posted back
            if (!IsPostBack)
            {
                // Get the connection string from the configuration
                string connectionString = ConfigurationManager.ConnectionStrings["NewsConnectionString"].ConnectionString;

                // Create and open the SQL connection
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    try
                    {
                        cn.Open();

                        // Query to select titles
                        string selectQuery = "SELECT id, title FROM articles";
                        using (SqlCommand selectCmd = new SqlCommand(selectQuery, cn))
                        using (SqlDataReader dr = selectCmd.ExecuteReader())
                        {
                            string strTitle = string.Empty;

                            // Read the titles and append them to the string
                            while (dr.Read())
                            {
                                strTitle += "<a href='newsPa.aspx?x=" + dr["id"] + "'>" + HttpUtility.HtmlEncode(dr["title"].ToString()) + "</a> &nbsp;&nbsp;&nbsp;";
                            }

                            // Set the inner HTML of the marquee element
                            n.InnerHtml = "<marquee id='news' onmouseover='news.stop();' onmouseout='news.start();'>" + strTitle + "</marquee>";
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle exceptions
                        n.InnerHtml = "An error occurred: " + ex.Message;
                    }
                }
            }
        }
    }
}