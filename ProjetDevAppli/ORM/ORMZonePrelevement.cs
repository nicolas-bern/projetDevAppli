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
    public class ORMZonePrelevement
    {
        public static ObservableCollection<ZonePrelevementViewModel> listeZones()
        {
            ObservableCollection<DAOZonePrelevement> listeDAO = DAOZonePrelevement.listeZones();
            ObservableCollection<ZonePrelevementViewModel> listeZones = new ObservableCollection<ZonePrelevementViewModel>();
            foreach (DAOZonePrelevement item in listeDAO)
            {
                int idEtude = item.idEtudeDAO;
                int idPlage = item.idPlageDAO;
                int idPersonne = item.idPersonneDAO;

                EtudeViewModel etudeID = ORMEtude.getEtude(idEtude);
                PlageViewModel plageID = ORMPlage.getPlage(idPlage);
                PersonneViewModel personneID = ORMPersonne.getPersonne(idPersonne);

                ZonePrelevementViewModel zone = new ZonePrelevementViewModel(item.idZoneDAO, etudeID, plageID, item.Angle1DAO, item.Angle2DAO, item.Angle3DAO, item.Angle4DAO, personneID);
                listeZones.Add(zone);
            }
            return listeZones;
        }

        public static void addZone(ZonePrelevementViewModel zone)
        {
            DAOZonePrelevement.addZone(new DAOZonePrelevement(zone.idZonePrelevementProperty, zone.idEtude.idEtudeProperty, zone.idPlage.idPlageProperty, zone.Angle1Property, zone.Angle2Property, zone.Angle3Property, zone.Angle4Property, zone.idPersonne.idPersonneProperty));
        }

        public static ZonePrelevementViewModel getZone(int id)
        {
            DAOZonePrelevement daozone = DAOZonePrelevement.getZone(id);
            int idEtude = daozone.idEtudeDAO;
            int idPlage = daozone.idPlageDAO;
            int idPersonne = daozone.idPersonneDAO;

            EtudeViewModel etude = ORMEtude.getEtude(idEtude);
            PlageViewModel plage = ORMPlage.getPlage(idPlage);
            PersonneViewModel personne = ORMPersonne.getPersonne(idPersonne);

            ZonePrelevementViewModel zone = new ZonePrelevementViewModel(daozone.idZoneDAO, etude, plage, daozone.Angle1DAO, daozone.Angle2DAO, daozone.Angle3DAO, daozone.Angle4DAO, personne);
            return zone;
        }
    }
}
