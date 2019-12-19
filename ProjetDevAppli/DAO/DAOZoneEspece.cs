using ProjetDevAppli.DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDevAppli.DAO
{
    public class DAOZoneEspece
    {
        public int idZoneEDAO { get; set; }
        public int IdZoneDAO { get; set; }
        public int IdEspeceDAO { get; set; }
        public int IdEtudeDAO { get; set; }
        public int IdPlageDAO { get; set; }
        public int NombreDAO { get; set; }

        public DAOZoneEspece(int idZoneEDAO, int idZoneDAO, int idEspeceDAO, int idEtudeDAO, int idPlageDAO, int NombreDAO)
        {
            this.idZoneEDAO = idZoneEDAO;
            this.IdEspeceDAO = idEspeceDAO;
            this.IdZoneDAO = idZoneDAO;
            this.IdEtudeDAO = idEtudeDAO;
            this.IdPlageDAO = idPlageDAO;
            this.NombreDAO = NombreDAO;
        }

        public static ObservableCollection<DAOZoneEspece> listeZones()
        {
            ObservableCollection<DAOZoneEspece> listeZones = DALZoneEspece.selectZones();
            return listeZones;
        }

        public static void addZone(DAOZoneEspece zone)
        {
            DALZoneEspece.addZone(zone);
        }
    }
}
