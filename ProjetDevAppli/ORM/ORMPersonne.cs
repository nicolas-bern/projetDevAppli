using ProjetDevAppli.Ctrl;
using ProjetDevAppli.DAO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDevAppli.ORM
{
    public class ORMPersonne
    {

        public static PersonneViewModel getPersonne(int id)
        {
            DAOPersonne daopersonne = DAOPersonne.getPersonne(id);
            PersonneViewModel personne = new PersonneViewModel(daopersonne.idPersonneDAO, daopersonne.NomDAO, daopersonne.PrénomDAO, daopersonne.AdminBénévoleDAO);
            return personne;
        }

        public static ObservableCollection<PersonneViewModel> listePersonnes()
        {
            ObservableCollection<DAOPersonne> listeDAO = DAOPersonne.listePersonnes();
            ObservableCollection<PersonneViewModel> listePersonnes = new ObservableCollection<PersonneViewModel>();
            foreach (DAOPersonne item in listeDAO)
            {
                PersonneViewModel personne = new PersonneViewModel(item.idPersonneDAO, item.NomDAO, item.PrénomDAO, item.AdminBénévoleDAO);
                listePersonnes.Add(personne);
            }
            return listePersonnes;
        }

        public static ObservableCollection<PersonneViewModel> listeAdmins()
        {
            ObservableCollection<DAOPersonne> listeAdminsDAO = DAOPersonne.listeAdmins();
            ObservableCollection<PersonneViewModel> listeAdmins = new ObservableCollection<PersonneViewModel>();
            foreach (DAOPersonne item in listeAdminsDAO)
            {
                PersonneViewModel admin = new PersonneViewModel(item.idPersonneDAO, item.NomDAO, item.PrénomDAO, item.AdminBénévoleDAO);
                listeAdmins.Add(admin);
            }
            return listeAdmins;
        }

        public static ObservableCollection<PersonneViewModel> listeBenevoles()
        {
            ObservableCollection<DAOPersonne> listeBeneDAO = DAOPersonne.listeBene();
            ObservableCollection<PersonneViewModel> listeBenevoles = new ObservableCollection<PersonneViewModel>();
            foreach (DAOPersonne item in listeBeneDAO)
            {
                PersonneViewModel bene = new PersonneViewModel(item.idPersonneDAO, item.NomDAO, item.PrénomDAO, item.AdminBénévoleDAO);
                listeBenevoles.Add(bene);
            }
            return listeBenevoles;
        }

        public static void addPersonne(PersonneViewModel personne)
        {
            DAOPersonne.addPersonne(new DAOPersonne(personne.idPersonneProperty, personne.nomPersonneProperty, personne.prénomPersonneProperty, personne.adminbénéPersonneProperty));
        }

        public static void deletePersonne(int id)
        {
            DAOPersonne.deletePersonne(id);
        }

        public static void updatePersonne(PersonneViewModel personne)
        {
            DAOPersonne.updatePersonne(new DAOPersonne(personne.idPersonneProperty, personne.nomPersonneProperty, personne.prénomPersonneProperty, personne.adminbénéPersonneProperty));
        }
    }
}
