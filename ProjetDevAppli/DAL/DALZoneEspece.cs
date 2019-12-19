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
    public class DALZoneEspece
    {
        private static MySqlConnection connection;

        public DALZoneEspece()
        {
            DALConnection.Connection();
            connection = DALConnection.connection;
        }

        public static ObservableCollection<DAOZoneEspece> selectZones()
        {
            ObservableCollection<DAOZoneEspece> listeZones = new ObservableCollection<DAOZoneEspece>();
            string query = "SELECT * FROM zoneespèce;";
            MySqlCommand command = new MySqlCommand(query, DALConnection.Connection());
            try
            {
                command.ExecuteNonQuery();
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    DAOZoneEspece zone = new DAOZoneEspece(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetInt32(5));
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

        public static void addZone(DAOZoneEspece zone)
        {
            string query = "INSERT INTO zoneespèce VALUES (\"" + zone.idZoneEDAO + "\",\"" + zone.IdEspeceDAO + "\",\"" + zone.IdZoneDAO + "\",\"" + zone.IdEtudeDAO + "\",\"" + zone.IdPlageDAO +"\",\"" + zone.NombreDAO + "\");";
            MySqlCommand command = new MySqlCommand(query, DALConnection.Connection());
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command);
            command.ExecuteNonQuery();
        }

        public static int getMaxIdZone()
        {
            string query = "SELECT MAX(idZoneEspece) FROM zoneespèce;";
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