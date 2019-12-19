using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDevAppli.Ctrl
{
    public class ZonePrelevementViewModel
    {
        private int idZonePrelevement;
        public EtudeViewModel idEtude;
        public PlageViewModel idPlage;
        private int Angle1;
        private int Angle2;
        private int Angle3;
        private int Angle4;
        public PersonneViewModel idPersonne;

        public ZonePrelevementViewModel() { }

        public ZonePrelevementViewModel(int id, EtudeViewModel idEtude, PlageViewModel idPlage, int Angle1, int Angle2, int Angle3, int Angle4, PersonneViewModel idPersonne)
        {
            this.idZonePrelevement = id;
            this.idEtude = idEtude;
            this.idPlage = idPlage;
            this.Angle1 = Angle1;
            this.Angle2 = Angle2;
            this.Angle3 = Angle3;
            this.Angle4 = Angle4;
            this.idPersonne = idPersonne;
        }

        public int idZonePrelevementProperty
        {
            get { return idZonePrelevement; }
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

        public int Angle1Property
        {
            get { return Angle1; }
            set
            {
                this.Angle1 = value;
            }
        }

        public int Angle2Property
        {
            get { return Angle2; }
            set
            {
                this.Angle2 = value;
            }
        }

        public int Angle3Property
        {
            get { return Angle3; }
            set
            {
                this.Angle3 = value;
            }
        }

        public int Angle4Property
        {
            get { return Angle4; }
            set
            {
                this.Angle4 = value;
            }
        }

        public PersonneViewModel idPersonneProperty
        {
            get { return idPersonne; }
            set
            {
                this.idPersonne = value;
            }
        }
    }
}
