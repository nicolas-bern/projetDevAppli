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
    class DALPersonne
    {
        private static MySqlConnection connection;

        public DALPersonne()
        {
            DALConnection.Connection();
            connection = DALConnection.connection;
        }

        public static ObservableCollection<DAOPersonne> selectPersonnes()
        {
            ObservableCollection<DAOPersonne> ListePersonnes = new ObservableCollection<DAOPersonne>();
            string query = "SELECT * FROM personne;";
            MySqlCommand command = new MySqlCommand(query, DALConnection.Connection());
            try
            {
                command.ExecuteNonQuery();
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    DAOPersonne personne = new DAOPersonne(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3));
                    ListePersonnes.Add(personne);
                }
                reader.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Une erreur est survenue impossible de continuer...");
            }
            return ListePersonnes;
        }

        public static ObservableCollection<DAOPersonne> selectAdmins()
        {
            ObservableCollection<DAOPersonne> ListeAdmin = new ObservableCollection<DAOPersonne>();
            string query = "SELECT * FROM personne WHERE AdminBénévole = 0;";
            MySqlCommand command = new MySqlCommand(query, DALConnection.Connection());
            try
            {
                command.ExecuteNonQuery();
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    DAOPersonne admin = new DAOPersonne(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3));
                    ListeAdmin.Add(admin);
                }
                reader.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Une erreur est survenue impossible de continuer...");
            }
            return ListeAdmin;
        }

        public static ObservableCollection<DAOPersonne> selectBenevoles()
        {
            ObservableCollection<DAOPersonne> ListeBene = new ObservableCollection<DAOPersonne>();
            string query = "SELECT * FROM personne WHERE AdminBénévole = 1;";
            MySqlCommand command = new MySqlCommand(query, DALConnection.Connection());
            try
            {
                command.ExecuteNonQuery();
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    DAOPersonne bene = new DAOPersonne(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3));
                    ListeBene.Add(bene);
                }
                reader.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Une erreur est survenue impossible de continuer...");
            }
            return ListeBene;
        }

        public static void addPersonne(DAOPersonne personne)
        {
            string query = "INSERT INTO personne VALUES (\"" + personne.idPersonneDAO + "\",\"" + personne.NomDAO + "\",\"" + personne.PrénomDAO + "\",\"" + personne.AdminBénévoleDAO + "\");";
            MySqlCommand command = new MySqlCommand(query, DALConnection.Connection());
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command);
            command.ExecuteNonQuery();
        }

        public static void deletePersonne(int id)
        {
            string query = "DELETE FROM personne WHERE idPersonne = " + id + ";";
            MySqlCommand command = new MySqlCommand(query, DALConnection.Connection());
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command);
            command.ExecuteNonQuery();
        }

        public static void updatePersonne(DAOPersonne personne)
        {
            string query = "UPDATE personne SET Nom=" + personne.NomDAO + ", Prénom=" + personne.PrénomDAO + ", AdminBénévole=" + personne.AdminBénévoleDAO + ";";
            MySqlCommand command = new MySqlCommand(query, DALConnection.Connection());
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command);
            command.ExecuteNonQuery();
        }

        public static DAOPersonne getPersonne(int id)
        {
            string query = "SELECT * FROM personne WHERE idPersonne = " + id + ";";
            MySqlCommand command = new MySqlCommand(query, DALConnection.Connection());
            command.ExecuteNonQuery();
            MySqlDataReader reader = command.ExecuteReader();
            reader.Read();
            DAOPersonne personne = new DAOPersonne(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3));
            reader.Close();
            return personne;
        }

        public static int getMaxIdPersonne()
        {
            string query = "SELECT MAX(idPersonne) FROM personne;";
            MySqlCommand command = new MySqlCommand(query, DALConnection.Connection());
            command.ExecuteNonQuery();
            MySqlDataReader reader = command.ExecuteReader();
            reader.Read();
            int maxIdPersonne = reader.GetInt32(0);
            reader.Close();
            return maxIdPersonne + 1;
        }
    }
}
