using ProjetDevAppli.DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDevAppli.DAO
{
    public class DAOPlage
    {
        public int idPlageDAO { get; set; }
        public string NomDAO { get; set; }
        public string CommuneDAO { get; set; }
        public string DépartementDAO { get; set; }
        public int SuperficieDAO { get; set; }

        public DAOPlage(int idPlageDAO, string NomDAO, string CommuneDAO, string DépartementDAO, int SuperficieDAO)
        {
            this.idPlageDAO = idPlageDAO;
            this.NomDAO = NomDAO;
            this.CommuneDAO = CommuneDAO;
            this.DépartementDAO = DépartementDAO;
            this.SuperficieDAO = SuperficieDAO;
        }

        public static DAOPlage getPlage(int id)
        {
            DAOPlage plage = DALPlage.getPlage(id);
            return plage;
        }

        public static ObservableCollection<DAOPlage> listePlages()
        {
            ObservableCollection<DAOPlage> ListePlages = DALPlage.selectPlages();
            return ListePlages;
        }

        public static void addPlage(DAOPlage plage)
        {
            DALPlage.addPlage(plage);
        }

        public static void updatePlage(DAOPlage plage)
        {
            DALPlage.updatePlage(plage);
        }
    }
}
