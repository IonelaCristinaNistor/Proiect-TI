using MySql.Data.MySqlClient;
using System;
using System.IO;

namespace Proiect_TI_1
{
    public partial class Adaugare : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AdaugaAngajat(object sender, EventArgs e)
        {
            var nume = Request.Form["nume"];
            var prenume = Request.Form["prenume"];
            var functie = Request.Form["functie"];
            var salar = Request.Form["salar"];
            var spor = Request.Form["spor"];
            var premii = Request.Form["premii"];
            var retineri = Request.Form["retineri"];

            if (string.IsNullOrEmpty(nume) || string.IsNullOrEmpty(prenume) || string.IsNullOrEmpty(functie)
        || string.IsNullOrEmpty(salar) || string.IsNullOrEmpty(spor) || string.IsNullOrEmpty(premii)
        || string.IsNullOrEmpty(retineri))
            {
                string alertScript = "<script>alert('Nu ați completat toate câmpurile!');";
                alertScript += "window.location.href='Adaugare.aspx';</script>";
                Response.Write(alertScript);
                return;
            }
            else
            {
                if (imagine.PostedFile != null && imagine.PostedFile.ContentLength > 0)
                {
                    var fileExtension = Path.GetExtension(imagine.PostedFile.FileName);
                    if (fileExtension == ".jpg" || fileExtension == ".jpeg" || fileExtension == ".png" ||
                        fileExtension == ".JPG" || fileExtension == ".JPEG" || fileExtension == ".PNG")
                    {
                        byte[] bytes;
                        using (BinaryReader br = new BinaryReader(imagine.PostedFile.InputStream))
                        {
                            bytes = br.ReadBytes(imagine.PostedFile.ContentLength);
                        }

                        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;
                        string query = "INSERT INTO proiect_ti.gestiune (nume, prenume, functie, salar_baza, spor, premii_brute, procente_id, retineri, imagine) " +
                                       "VALUES (@Nume, @Prenume, @Functie, @Salar, @Spor, @Premii, 1, @Retineri, @Imagine)";

                        try
                        {
                            using (MySqlConnection connection = new MySqlConnection(connectionString))
                            {
                                MySqlCommand command = new MySqlCommand(query, connection);
                                command.Parameters.AddWithValue("@Nume", nume);
                                command.Parameters.AddWithValue("@Prenume", prenume);
                                command.Parameters.AddWithValue("@Functie", functie);
                                command.Parameters.AddWithValue("@Salar", salar);
                                command.Parameters.AddWithValue("@Spor", spor);
                                command.Parameters.AddWithValue("@Premii", premii);
                                command.Parameters.AddWithValue("@Retineri", retineri);
                                command.Parameters.AddWithValue("@Imagine", bytes);

                                connection.Open();
                                command.ExecuteNonQuery();
                                connection.Close();

                                string alertScript = "<script>alert('Angajatul a fost adăugat cu succes!');";
                                alertScript += "window.location.href='StatPlata.aspx';</script>";
                                Response.Write(alertScript);
                            }
                        }
                        catch (Exception ex)
                        {
                            string alertScript = "<script>alert('Eroare: " + ex.Message + "');</script>";
                            Response.Write(alertScript);
                        }
                    }
                }
            }

        }
    }
}