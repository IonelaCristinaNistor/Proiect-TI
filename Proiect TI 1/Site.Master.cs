using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proiect_TI_1
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                connectToDB();
            }
        }

        private void connectToDB()
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    Session["DatabaseConnection"] = connection;
                }
            }
            catch (Exception)
            {
                Response.Redirect("Error.html");
            }
        }
    }
}