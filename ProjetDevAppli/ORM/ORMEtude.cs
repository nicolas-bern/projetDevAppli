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
    public class ORMEtude
    {
        public static ObservableCollection<EtudeViewModel> listeEtudes()
        {
            ObservableCollection<DAOEtude> listeDAO = DAOEtude.listeEtudes();
            ObservableCollection<EtudeViewModel> listeEtudes = new ObservableCollection<EtudeViewModel>();
            foreach (DAOEtude item in listeDAO)
            {
                int idPersonne = item.idPersonneDAO;
                PersonneViewModel personneID = ORMPersonne.getPersonne(idPersonne);

                EtudeViewModel etude = new EtudeViewModel(item.idEtudeDAO, item.nomEtudeDAO, item.dateDAO, personneID);
                listeEtudes.Add(etude);
            }
            return listeEtudes;
        }

        public static void addEtude(EtudeViewModel etude)
        {
            DAOEtude.addEtude(new DAOEtude(etude.idEtudeProperty, etude.nomEtudeProperty, etude.dateEtudeProperty, etude.idPersonne.idPersonneProperty));
        }

        public static EtudeViewModel getEtude(int id)
        {
            DAOEtude daoetude = DAOEtude.getEtude(id);
            int idPersonne = daoetude.idPersonneDAO;

            PersonneViewModel personne = ORMPersonne.getPersonne(idPersonne);
            EtudeViewModel etude = new EtudeViewModel(daoetude.idEtudeDAO, daoetude.nomEtudeDAO, daoetude.dateDAO, personne);
            return etude;
        }
    }
}
