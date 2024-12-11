using CrystalDecisions.CrystalReports.Engine;
using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;

namespace Proiect_TI_1
{
    public partial class Fluturasi : System.Web.UI.Page
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();

                        string query = "SELECT nr_crt, nume, prenume, functie, salar_baza, spor, premii_brute, " +
                                       "total_brut, brut_impozitabil, impozit, cas, cass, retineri, virat_card " +
                                       "FROM gestiune";

                        DataSet ds = new DataSet();
                        MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                        adapter.Fill(ds, "GestiuneData");

                        ReportDocument crystalReport = new ReportDocument();

                        crystalReport.Load(Server.MapPath("~/CrystalReport2.rpt"));
                        crystalReport.SetDataSource(ds.Tables["GestiuneData"]);

                        Session["CrystalReport2"] = crystalReport;
                        CrystalReportViewer1.ReportSourceID = "CrystalReport2";
                        CrystalReportViewer1.ReportSource = crystalReport;
                        CrystalReportViewer1.RefreshReport();
                    }
                }
                catch (Exception)
                {
                    string alertScript = "<script>alert('A intervenit o eroare! Raportul nu a putut fi generat!');</script>";
                    Response.Write(alertScript);
                }
            }
        }
    }
}
