using ProjetDevAppli.DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDevAppli.DAO
{
    public class DAOEtude
    {
        public int idEtudeDAO { get; set; }
        public string nomEtudeDAO { get; set; }
        public DateTime dateDAO { get; set; }
        public int idPersonneDAO { get; set; }

        public DAOEtude(int idEtudeDAO, string nomEtudeDAO, DateTime dateDAO, int idPersonneDAO)
        {
            this.idEtudeDAO = idEtudeDAO;
            this.nomEtudeDAO = nomEtudeDAO;
            this.dateDAO = dateDAO;
            this.idPersonneDAO = idPersonneDAO;
        }

        public static ObservableCollection<DAOEtude> listeEtudes()
        {
            ObservableCollection<DAOEtude> listeEtudes = DALEtude.selectEtudes();
            return listeEtudes;
        }

        public static void addEtude(DAOEtude etude)
        {
            DALEtude.addEtude(etude);
        }

        public static DAOEtude getEtude(int id)
        {
            DAOEtude etude = DALEtude.getEtude(id);
            return etude;
        }
    }
}
