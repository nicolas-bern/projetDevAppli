using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDevAppli.Ctrl
{
    public class EtudeViewModel
    {
        private int idEtude;
        private string nom;
        private DateTime date;
        public PersonneViewModel idPersonne;

        public EtudeViewModel() { }

        public EtudeViewModel(int id, string nom, DateTime date, PersonneViewModel idPersonne)
        {
            this.idEtude = id;
            this.nom = nom;
            this.date = date;
            this.idPersonne = idPersonne;
        }

        public int idEtudeProperty
        {
            get { return idEtude; }
        }

        public string nomEtudeProperty
        {
            get { return nom; }
            set
            {
                this.nom = value;
            }
        }

        public DateTime dateEtudeProperty
        {
            get { return date; }
            set
            {
                this.date = value;
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
