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
    public class DALEspèce
    {
        private static MySqlConnection connection;

        public DALEspèce()
        {
            DALConnection.Connection();
            connection = DALConnection.connection;
        }

        public static ObservableCollection<DAOEspèce> selectEspèces()
        {
            ObservableCollection<DAOEspèce> ListeEspèce = new ObservableCollection<DAOEspèce>();
            string query = "SELECT * FROM espèce;";
            MySqlCommand command = new MySqlCommand(query, DALConnection.Connection());
            try
            {
                command.ExecuteNonQuery();
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    DAOEspèce espèce = new DAOEspèce(reader.GetInt32(0), reader.GetString(1));
                    ListeEspèce.Add(espèce);
                }
                reader.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Une erreur est survenue impossible de continuer...");
            }
            return ListeEspèce;
        }

        public static void addEspèce(DAOEspèce espèce)
        {
            string query = "INSERT INTO espèce VALUES (" + espèce.NomDAO + ");";
            MySqlCommand command = new MySqlCommand(query, DALConnection.Connection());
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command);
            command.ExecuteNonQuery();
        }

        public static DAOEspèce getEspèce(int id)
        {
            string query = "SELECT * FROM espèce WHERE idEspèce = " + id + ";";
            MySqlCommand command = new MySqlCommand(query, DALConnection.Connection());
            command.ExecuteNonQuery();
            MySqlDataReader reader = command.ExecuteReader();
            reader.Read();
            DAOEspèce espèce = new DAOEspèce(reader.GetInt32(0), reader.GetString(1));
            reader.Close();
            return espèce;
        }
    }
}
