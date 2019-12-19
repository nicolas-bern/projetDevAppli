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
    public class ORMEspèce
    {
        public static ObservableCollection<EspèceViewModel> listeEspèce()
        {
            ObservableCollection<DAOEspèce> listeDAO = DAOEspèce.listeEspèces();
            ObservableCollection<EspèceViewModel> listeEspèces = new ObservableCollection<EspèceViewModel>();
            foreach (DAOEspèce item in listeDAO)
            {
                EspèceViewModel espèce = new EspèceViewModel(item.idEspèceDAO, item.NomDAO);
                listeEspèces.Add(espèce);
            }
            return listeEspèces;
        }

        public static EspèceViewModel getEspèce(int id)
        {
            DAOEspèce daoespèce = DAOEspèce.getEspèce(id);
            EspèceViewModel espèce = new EspèceViewModel(daoespèce.idEspèceDAO, daoespèce.NomDAO);
            return espèce;
        }

        public static void addEspèce(EspèceViewModel espèce)
        {
            DAOEspèce.addEspèce(new DAOEspèce(espèce.idEspèceProperty, espèce.nomEspèceProperty));
        }
    }
}
