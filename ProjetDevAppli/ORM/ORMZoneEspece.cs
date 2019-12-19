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
    public class ORMZoneEspece
    {
        public static ObservableCollection<ZoneEspeceViewModel> listeZones()
        {
            ObservableCollection<DAOZoneEspece> listeDAO = DAOZoneEspece.listeZones();
            ObservableCollection<ZoneEspeceViewModel> listeZones = new ObservableCollection<ZoneEspeceViewModel>();
            foreach (DAOZoneEspece item in listeDAO)
            {
                int idZone = item.IdZoneDAO;
                int idEspece = item.IdEspeceDAO;
                int idEtude = item.IdEtudeDAO;
                int idPlage = item.IdPlageDAO;

                ZonePrelevementViewModel zoneID = ORMZonePrelevement.getZone(idZone);
                EspèceViewModel especeID = ORMEspèce.getEspèce(idEspece);
                EtudeViewModel etudeID = ORMEtude.getEtude(idEtude);
                PlageViewModel plageID = ORMPlage.getPlage(idPlage);

                ZoneEspeceViewModel zone = new ZoneEspeceViewModel(item.idZoneEDAO, especeID, zoneID, etudeID, plageID, item.NombreDAO);
                listeZones.Add(zone);
            }
            return listeZones;
        }

        public static void addZone(ZoneEspeceViewModel zone)
        {
            DAOZoneEspece.addZone(new DAOZoneEspece(zone.idZoneEProperty, zone.idEspece.idEspèceProperty, zone.idZone.idZonePrelevementProperty, zone.idEtude.idEtudeProperty, zone.idPlage.idPlageProperty, zone.nombreProperty));
        }
    }
}