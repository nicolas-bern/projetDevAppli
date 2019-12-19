using ProjetDevAppli.DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDevAppli.DAO
{
    public class DAOZonePrelevement
    {
        public int idZoneDAO { get; set; }
        public int idEtudeDAO { get; set; }
        public int idPlageDAO { get; set; }
        public int Angle1DAO { get; set; }
        public int Angle2DAO { get; set; }
        public int Angle3DAO { get; set; }
        public int Angle4DAO { get; set; }
        public int idPersonneDAO { get; set; }

        public DAOZonePrelevement(int idZoneDAO, int idEtudeDAO, int idPlageDAO, int Angle1DAO, int Angle2DAO, int Angle3DAO, int Angle4DAO, int idPersonneDAO)
        {
            this.idZoneDAO = idZoneDAO;
            this.idEtudeDAO = idEtudeDAO;
            this.idPlageDAO = idPlageDAO;
            this.Angle1DAO = Angle1DAO;
            this.Angle2DAO = Angle2DAO;
            this.Angle3DAO = Angle3DAO;
            this.Angle4DAO = Angle4DAO;
            this.idPersonneDAO = idPersonneDAO;
        }

        public static ObservableCollection<DAOZonePrelevement> listeZones()
        {
            ObservableCollection<DAOZonePrelevement> listeZones = DALZonePrelevement.selectZones();
            return listeZones;
        }

        public static void addZone(DAOZonePrelevement zone)
        {
            DALZonePrelevement.addZone(zone);
        }

        public static DAOZonePrelevement getZone(int id)
        {
            DAOZonePrelevement zone = DALZonePrelevement.getZone(id);
            return zone;
        }
    }
}
