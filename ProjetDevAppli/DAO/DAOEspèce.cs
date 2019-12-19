using ProjetDevAppli.DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDevAppli.DAO
{
    public class DAOEspèce
    {
        public int idEspèceDAO { get; set; }
        public string NomDAO { get; set; }


        public DAOEspèce(int idEspèceDAO, string NomDAO)
        {
            this.idEspèceDAO = idEspèceDAO;
            this.NomDAO = NomDAO;
        }

        public static ObservableCollection<DAOEspèce> listeEspèces()
        {
            ObservableCollection<DAOEspèce> ListeEspèces = DALEspèce.selectEspèces();
            return ListeEspèces;
        }

        public static void addEspèce(DAOEspèce espèce)
        {
            DALEspèce.addEspèce(espèce);
        }

        public static DAOEspèce getEspèce(int id)
        {
            DAOEspèce espèce = DALEspèce.getEspèce(id);
            return espèce;
        }
    }

    
}
