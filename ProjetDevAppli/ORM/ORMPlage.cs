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
    public class ORMPlage
    {
        public static PlageViewModel getPlage(int id)
        {
            DAOPlage daoplage = DAOPlage.getPlage(id);
            PlageViewModel plage = new PlageViewModel(daoplage.idPlageDAO, daoplage.NomDAO, daoplage.CommuneDAO, daoplage.DépartementDAO, daoplage.SuperficieDAO);
            return plage;
        }

        public static ObservableCollection<PlageViewModel> listePlages()
        {
            ObservableCollection<DAOPlage> listeDAO = DAOPlage.listePlages();
            ObservableCollection<PlageViewModel> listePlages = new ObservableCollection<PlageViewModel>();
            foreach (DAOPlage item in listeDAO)
            {
                PlageViewModel plage = new PlageViewModel(item.idPlageDAO, item.NomDAO, item.CommuneDAO, item.DépartementDAO, item.SuperficieDAO);
                listePlages.Add(plage);
            }
            return listePlages;
        }

        public static void addPlage(PlageViewModel plage)
        {
            DAOPlage.addPlage(new DAOPlage(plage.idPlageProperty, plage.nomPlageProperty, plage.communeProperty, plage.départementProperty, plage.superficieProperty));
        }
    }
}
