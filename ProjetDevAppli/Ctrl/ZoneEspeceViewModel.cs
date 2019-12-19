using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDevAppli.Ctrl
{
    public class ZoneEspeceViewModel
    {
        private int idZoneE;
        public EspèceViewModel idEspece;
        public ZonePrelevementViewModel idZone;
        public EtudeViewModel idEtude;
        public PlageViewModel idPlage;
        private int Nombre;

        public ZoneEspeceViewModel() { }

        public ZoneEspeceViewModel(int idZoneE, EspèceViewModel idEspece, ZonePrelevementViewModel idZone, EtudeViewModel idEtude, PlageViewModel idPlage, int nbr)
        {
            this.idZoneE = idZoneE;
            this.idEspece = idEspece;
            this.idZone = idZone;
            this.idEtude = idEtude;
            this.idPlage = idPlage;
            this.Nombre = nbr;
        }

        public int idZoneEProperty
        {
            get { return idZoneE; }
            set
            {
                this.idZoneE = value;
            }
        }

        public ZonePrelevementViewModel idZonePrelevementProperty
        {
            get { return idZone; }
            set
            {
                this.idZone = value;
            }
        }

        public EspèceViewModel idEspeceProperty
        {
            get { return idEspece; }
            set
            {
                this.idEspece = value;
            }
        }

        public EtudeViewModel idEtudeProperty
        {
            get { return idEtude; }
            set
            {
                this.idEtude = value;
            }
        }

        public PlageViewModel idPlageProperty
        {
            get { return idPlage; }
            set
            {
                this.idPlage = value;
            }
        }

        public int nombreProperty
        {
            get { return Nombre; }
            set
            {
                this.Nombre = value;
            }
        }
    }
}
