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
    public class DALEtude
    {
        private static MySqlConnection connection;

        public DALEtude()
        {
            DALConnection.Connection();
            connection = DALConnection.connection;
        }

        public static ObservableCollection<DAOEtude> selectEtudes()
        {
            ObservableCollection<DAOEtude> listeEtudes = new ObservableCollection<DAOEtude>();
            string query = "SELECT * FROM etude;";
            MySqlCommand command = new MySqlCommand(query, DALConnection.Connection());
            try
            {
                command.ExecuteNonQuery();
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    DAOEtude etude = new DAOEtude(reader.GetInt32(0), reader.GetString(1), reader.GetDateTime(2), reader.GetInt32(3));
                    listeEtudes.Add(etude);
                }
                reader.Close();
            }
                catch (Exception e)
            {
                MessageBox.Show("Une erreur est survenue impossible de continuer...");
            }
            return listeEtudes;
        }

        public static void addEtude(DAOEtude etude)
        {
            string query = "INSERT INTO etude VALUES (\"" + etude.idEtudeDAO + "\",\"" + etude.nomEtudeDAO + "\",\"" + etude.dateDAO + "\",\"" + etude.idPersonneDAO + "\");";
            MySqlCommand command = new MySqlCommand(query, DALConnection.Connection());
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command);
            command.ExecuteNonQuery();
        }

        public static DAOEtude getEtude(int id)
        {
            string query = "SELECT * FROM etude WHERE idEtude = " + id + ";";
            MySqlCommand command = new MySqlCommand(query, DALConnection.Connection());
            command.ExecuteNonQuery();
            MySqlDataReader reader = command.ExecuteReader();
            reader.Read();
            DAOEtude etude = new DAOEtude(reader.GetInt32(0), reader.GetString(1), reader.GetDateTime(2), reader.GetInt32(3));
            reader.Close();
            return etude;
        }

        public static int getMaxIdEtude()
        {
            string query = "SELECT MAX(idEtude) FROM etude;";
            MySqlCommand command = new MySqlCommand(query, DALConnection.Connection());
            command.ExecuteNonQuery();
            MySqlDataReader reader = command.ExecuteReader();
            reader.Read();
            int maxIdEtude = reader.GetInt32(0);
            reader.Close();
            return maxIdEtude + 1;
        }
    }
}
