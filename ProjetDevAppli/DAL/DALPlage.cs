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
    class DALPlage
    {
        private static MySqlConnection connection;

        public DALPlage()
        {
            DALConnection.Connection();
            connection = DALConnection.connection;
        }

        public static ObservableCollection<DAOPlage> selectPlages()
        {
            ObservableCollection<DAOPlage> ListesPlages = new ObservableCollection<DAOPlage>();
            string query = "SELECT * FROM plage;";
            MySqlCommand command = new MySqlCommand(query, DALConnection.Connection());
            try
            {
                command.ExecuteNonQuery();
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    DAOPlage plage = new DAOPlage(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetInt32(4));
                    ListesPlages.Add(plage);
                }
                reader.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Une erreur est survenue impossible de continuer...");
            }
            return ListesPlages;
        }

        public static DAOPlage getPlage(int id)
        {
            string query = "SELECT * FROM plage WHERE idPlage = " + id + ";";
            MySqlCommand command = new MySqlCommand(query, DALConnection.Connection());
            command.ExecuteNonQuery();
            MySqlDataReader reader = command.ExecuteReader();
            reader.Read();
            DAOPlage plage = new DAOPlage(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetInt32(4));
            reader.Close();
            return plage;
        }

        public static void addPlage(DAOPlage plage)
        {
            string query = "INSERT INTO plage VALUES (\"" + plage.idPlageDAO + "\",\"" + plage.NomDAO + "\",\"" + plage.CommuneDAO + "\",\"" + plage.DépartementDAO + "\",\"" + plage.SuperficieDAO + "\");";
            MySqlCommand command = new MySqlCommand(query, DALConnection.Connection());
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command);
            command.ExecuteNonQuery();
        }

        public static void updatePlage(DAOPlage plage)
        {
            string query = "UPDATE personne SET Nom=" + plage.NomDAO + ", Commune=" + plage.CommuneDAO + ", Département=" + plage.DépartementDAO + ", Superficie=" + plage.SuperficieDAO + ";";
            MySqlCommand command = new MySqlCommand(query, DALConnection.Connection());
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command);
            command.ExecuteNonQuery();
        }

        public static int getMaxIdlage()
        {
            string query = "SELECT MAX(idPlage) FROM plage;";
            MySqlCommand command = new MySqlCommand(query, DALConnection.Connection());
            command.ExecuteNonQuery();
            MySqlDataReader reader = command.ExecuteReader();
            reader.Read();
            int maxIdPlage = reader.GetInt32(0);
            reader.Close();
            return maxIdPlage + 1;
        }
    }
}
