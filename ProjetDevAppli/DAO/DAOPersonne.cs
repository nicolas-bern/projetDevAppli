using ProjetDevAppli.DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDevAppli.DAO
{
    public class DAOPersonne
    {
        public int idPersonneDAO { get; set; }
        public string NomDAO { get; set; }
        public string PrénomDAO { get; set; }
        public int AdminBénévoleDAO { get; set; }

        public DAOPersonne(int idPersonneDAO, string NomDAO, string PrénomDAO, int AdminBénévoleDAO)
        {
            this.idPersonneDAO = idPersonneDAO;
            this.NomDAO = NomDAO;
            this.PrénomDAO = PrénomDAO;
            this.AdminBénévoleDAO = AdminBénévoleDAO;
        }

        public static ObservableCollection<DAOPersonne> listePersonnes()
        {
            ObservableCollection<DAOPersonne> ListePersonnes = DALPersonne.selectPersonnes();
            return ListePersonnes;
        }

        public static ObservableCollection<DAOPersonne> listeAdmins()
        {
            ObservableCollection<DAOPersonne> ListeAdmins = DALPersonne.selectAdmins();
            return ListeAdmins;
        }

        public static ObservableCollection<DAOPersonne> listeBene()
        {
            ObservableCollection<DAOPersonne> ListeBene = DALPersonne.selectBenevoles();
            return ListeBene;
        }

        public static void addPersonne(DAOPersonne personne)
        {
            DALPersonne.addPersonne(personne);
        }

        public static void deletePersonne(int id)
        {
            DALPersonne.deletePersonne(id);
        }

        public static void updatePersonne(DAOPersonne personne)
        {
            DALPersonne.updatePersonne(personne);
        }

        public static DAOPersonne getPersonne(int id)
        {
            DAOPersonne personne = DALPersonne.getPersonne(id);
            return personne;
        }
    }
}
