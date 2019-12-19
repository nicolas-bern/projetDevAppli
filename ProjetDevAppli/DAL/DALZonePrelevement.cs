using MySql.Data.MySqlClient;
using ProjetDevAppli.DAO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProjetDevAppli.DAL
{
    public class DALZonePrelevement
    {
        private static MySqlConnection connection;

        public DALZonePrelevement()
        {
            DALConnection.Connection();
            connection = DALConnection.connection;
        }

        public static ObservableCollection<DAOZonePrelevement> selectZones()
        {
            ObservableCollection<DAOZonePrelevement> listeZones = new ObservableCollection<DAOZonePrelevement>();
            string query = "SELECT * FROM zoneprélèvement;";
            MySqlCommand command = new MySqlCommand(query, DALConnection.Connection());
            try
            {
                command.ExecuteNonQuery();
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    DAOZonePrelevement zone = new DAOZonePrelevement(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetInt32(5), reader.GetInt32(6), reader.GetInt32(7));
                    listeZones.Add(zone);
                }
                reader.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Une erreur est survenue impossible de continuer...");
            }
            return listeZones;
        }

        public static void addZone(DAOZonePrelevement zone)
        {
            string query = "INSERT INTO zoneprélèvement VALUES (\"" + zone.idZoneDAO + "\",\"" + zone.idEtudeDAO + "\",\"" + zone.idPlageDAO + "\",\"" + zone.Angle1DAO + "\",\"" + zone.Angle2DAO + "\",\"" + zone.Angle3DAO + "\",\"" + zone.Angle3DAO + "\",\"" + zone.idPersonneDAO + "\");";
            MySqlCommand command = new MySqlCommand(query, DALConnection.Connection());
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command);
            command.ExecuteNonQuery();
        }

        public static DAOZonePrelevement getZone(int id)
        {
            string query = "SELECT * FROM zoneprélèvement WHERE idZone = " + id + ";";
            MySqlCommand command = new MySqlCommand(query, DALConnection.Connection());
            command.ExecuteNonQuery();
            MySqlDataReader reader = command.ExecuteReader();
            reader.Read();
            DAOZonePrelevement zone = new DAOZonePrelevement(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetInt32(5), reader.GetInt32(6), reader.GetInt32(7));
            reader.Close();
            return zone;
        }

        public static int getMaxIdZone()
        {
            string query = "SELECT MAX(idZone) FROM zoneprélèvement;";
            MySqlCommand command = new MySqlCommand(query, DALConnection.Connection());
            command.ExecuteNonQuery();
            MySqlDataReader reader = command.ExecuteReader();
            reader.Read();
            int maxIdZone = reader.GetInt32(0);
            reader.Close();
            return maxIdZone + 1;
        }
    }
}
