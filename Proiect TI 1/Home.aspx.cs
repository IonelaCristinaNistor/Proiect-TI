using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proiect_TI_1
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCreateTables_Click(object sender, EventArgs e)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                byte[] imagine1, imagine2, imagine3, imagine4, imagine5, imagine6, imagine7, imagine8, imagine9, imagine10;


                using (System.IO.FileStream fs1 = new System.IO.FileStream(Server.MapPath("/Angajati/Imagine1.png"), System.IO.FileMode.Open, System.IO.FileAccess.Read))
                {
                    using (System.IO.BinaryReader br1 = new System.IO.BinaryReader(fs1))
                    {
                        imagine1 = br1.ReadBytes((int)fs1.Length);
                    }
                }
                using (System.IO.FileStream fs2 = new System.IO.FileStream(Server.MapPath("/Angajati/Imagine2.png"), System.IO.FileMode.Open, System.IO.FileAccess.Read))
                {
                    using (System.IO.BinaryReader br2 = new System.IO.BinaryReader(fs2))
                    {
                        imagine2 = br2.ReadBytes((int)fs2.Length);
                    }
                }
                using (System.IO.FileStream fs3 = new System.IO.FileStream(Server.MapPath("/Angajati/Imagine3.png"), System.IO.FileMode.Open, System.IO.FileAccess.Read))
                {
                    using (System.IO.BinaryReader br3 = new System.IO.BinaryReader(fs3))
                    {
                        imagine3 = br3.ReadBytes((int)fs3.Length);
                    }
                }
                using (System.IO.FileStream fs4 = new System.IO.FileStream(Server.MapPath("/Angajati/Imagine4.png"), System.IO.FileMode.Open, System.IO.FileAccess.Read))
                {
                    using (System.IO.BinaryReader br4 = new System.IO.BinaryReader(fs4))
                    {
                        imagine4 = br4.ReadBytes((int)fs4.Length);
                    }
                }
                using (System.IO.FileStream fs5 = new System.IO.FileStream(Server.MapPath("/Angajati/Imagine5.png"), System.IO.FileMode.Open, System.IO.FileAccess.Read))
                {
                    using (System.IO.BinaryReader br5 = new System.IO.BinaryReader(fs5))
                    {
                        imagine5 = br5.ReadBytes((int)fs5.Length);
                    }
                }
                using (System.IO.FileStream fs6 = new System.IO.FileStream(Server.MapPath("/Angajati/Imagine6.png"), System.IO.FileMode.Open, System.IO.FileAccess.Read))
                {
                    using (System.IO.BinaryReader br6 = new System.IO.BinaryReader(fs6))
                    {
                        imagine6 = br6.ReadBytes((int)fs6.Length);
                    }
                }
                using (System.IO.FileStream fs7 = new System.IO.FileStream(Server.MapPath("/Angajati/Imagine7.png"), System.IO.FileMode.Open, System.IO.FileAccess.Read))
                {
                    using (System.IO.BinaryReader br7 = new System.IO.BinaryReader(fs7))
                    {
                        imagine7 = br7.ReadBytes((int)fs7.Length);
                    }
                }
                using (System.IO.FileStream fs8 = new System.IO.FileStream(Server.MapPath("/Angajati/Imagine8.png"), System.IO.FileMode.Open, System.IO.FileAccess.Read))
                {
                    using (System.IO.BinaryReader br8 = new System.IO.BinaryReader(fs8))
                    {
                        imagine8 = br8.ReadBytes((int)fs8.Length);
                    }
                }
                using (System.IO.FileStream fs9 = new System.IO.FileStream(Server.MapPath("/Angajati/Imagine9.png"), System.IO.FileMode.Open, System.IO.FileAccess.Read))
                {
                    using (System.IO.BinaryReader br9 = new System.IO.BinaryReader(fs9))
                    {
                        imagine9 = br9.ReadBytes((int)fs9.Length);
                    }
                }
                using (System.IO.FileStream fs10 = new System.IO.FileStream(Server.MapPath("~/Angajati/Imagine10.jpg"), System.IO.FileMode.Open, System.IO.FileAccess.Read))
                {
                    using (System.IO.BinaryReader br10 = new System.IO.BinaryReader(fs10))
                    {
                        imagine10 = br10.ReadBytes((int)fs10.Length);
                    }
                }

                string createTablesTriggers = @"-- SQL command to create 'gestiune' table if it doesn't exist
CREATE TABLE IF NOT EXISTS `proiect_ti`.`gestiune` (
    `nr_crt` INT NOT NULL AUTO_INCREMENT,
    `nume` VARCHAR(45) NOT NULL,
    `prenume` VARCHAR(45) NOT NULL,
    `functie` VARCHAR(45) NOT NULL,
    `salar_baza` INT NOT NULL,
    `spor` INT NULL DEFAULT 0,
    `premii_brute` INT NULL DEFAULT 0,
    `total_brut` INT GENERATED ALWAYS AS (salar_baza * (1 + (spor / 100)) + premii_brute),
    `procente_id` INT,
    `cas_procent_val` FLOAT,
    `cass_procent_val` FLOAT,
    `impozit_procent_val` FLOAT,
    `brut_impozitabil` INT GENERATED ALWAYS AS (total_brut - (total_brut * cas_procent_val) - (total_brut * cass_procent_val)) VIRTUAL,
    `cas` INT GENERATED ALWAYS AS (total_brut * cas_procent_val) VIRTUAL,
    `cass` INT GENERATED ALWAYS AS (total_brut * cass_procent_val) VIRTUAL,
    `impozit` INT GENERATED ALWAYS AS (brut_impozitabil * impozit_procent_val) VIRTUAL,
    `retineri` INT NULL DEFAULT 0,
    `virat_card` INT GENERATED ALWAYS AS (total_brut - impozit - (total_brut * cas_procent_val) - (total_brut * cass_procent_val) - retineri) VIRTUAL,
    `imagine` LONGBLOB NULL,
    PRIMARY KEY (`nr_crt`)
);

-- Delete existing data from 'gestiune' table
DELETE FROM `proiect_ti`.`gestiune`;

-- SQL command to create 'procente' table if it doesn't exist
CREATE TABLE IF NOT EXISTS `proiect_ti`.`procente` (
    `cas_procent` FLOAT NOT NULL DEFAULT '0.25',
    `cass_procent` FLOAT NOT NULL DEFAULT '0.1',
    `impozit_procent` FLOAT NOT NULL DEFAULT '0.1',
    `id` INT NOT NULL AUTO_INCREMENT,
    PRIMARY KEY (`id`)
);

-- SQL command to insert data into 'gestiune' table
INSERT INTO `proiect_ti`.`gestiune` (`nume`, `prenume`, `functie`, `salar_baza`, `spor`, `premii_brute`, `procente_id`, `retineri`, `imagine`)
VALUES
    ('Nistor', 'Cristina', 'Developer', 11000, 10, 750, 1, 0, @Imagine1),
    ('Ionescu', 'Ion', 'Software Architect', 22000, 15, 1200, 1, 0, @Imagine2),
    ('Popescu', 'Maria', 'HR Manager', 18000, 18, 1500, 1, 100, @Imagine3),
    ('Mihailovici', 'Diana', 'QA Lead', 13000, 10, 800, 1, 200, @Imagine4),
    ('Popovici', 'Victor', 'Database Administrator', 14500, 12, 700, 1, 0, @Imagine5),
    ('Stanciu', 'Alexandru', 'DevOps Engineer', 16000, 8, 900, 1, 0, @Imagine6),
    ('Iliescu', 'Marcelinis', 'HR Recruiter', 9000, 12, 300, 1, 0, @Imagine7),
    ('Nita', 'Otilia', 'Software Tester', 15000, 6, 200, 1, 100, @Imagine8),
    ('Nistor', 'Alexandra', 'Developer', 10000, 12, 250, 1, 0, @Imagine9),
    ('Constantinescu', 'Emanuel', 'Director', 20000, 20, 800, 1, 150, @Imagine10);

-- SQL command to create 'before_insert_gestiune' trigger if it doesn't exist
DROP TRIGGER IF EXISTS before_insert_gestiune;
CREATE TRIGGER before_insert_gestiune 
BEFORE INSERT ON `proiect_ti`.`gestiune` 
FOR EACH ROW 
BEGIN
    SET NEW.procente_id = 1;
    SET NEW.cas_procent_val = (SELECT cas_procent FROM `proiect_ti`.`procente` WHERE `id` = NEW.procente_id);
    SET NEW.cass_procent_val = (SELECT cass_procent FROM `proiect_ti`.`procente` WHERE `id` = NEW.procente_id);
    SET NEW.impozit_procent_val = (SELECT impozit_procent FROM `proiect_ti`.`procente` WHERE `id` = NEW.procente_id);
END";


                using (MySqlCommand cmd = new MySqlCommand(createTablesTriggers, conn))
                {
                    cmd.Parameters.AddWithValue("@Imagine1", imagine1);
                    cmd.Parameters.AddWithValue("@Imagine2", imagine2);
                    cmd.Parameters.AddWithValue("@Imagine3", imagine3);
                    cmd.Parameters.AddWithValue("@Imagine4", imagine4);
                    cmd.Parameters.AddWithValue("@Imagine5", imagine5);
                    cmd.Parameters.AddWithValue("@Imagine6", imagine6);
                    cmd.Parameters.AddWithValue("@Imagine7", imagine7);
                    cmd.Parameters.AddWithValue("@Imagine8", imagine8);
                    cmd.Parameters.AddWithValue("@Imagine9", imagine9);
                    cmd.Parameters.AddWithValue("@Imagine10", imagine10);
                    cmd.ExecuteNonQuery();
                }
            }
            string successMessage = "Datele au fost adaugate cu succes!";
            Session["SuccessMessage"] = successMessage;
            Response.Redirect("StatPlata.aspx?success=true");
        }
    }
}