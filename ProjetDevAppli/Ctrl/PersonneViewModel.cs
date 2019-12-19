using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDevAppli.Ctrl
{
    public class PersonneViewModel
    {
        private int idPersonne;
        private string Nom;
        private string Prénom;
        private int AdminBénévole;

        public PersonneViewModel() { }

        public PersonneViewModel(int id, string nom, string prénom, int adminBéné)
        {
            this.idPersonne = id;
            this.Nom = nom;
            this.Prénom = prénom;
            this.AdminBénévole = adminBéné;
        }

        public int idPersonneProperty
        {
            get { return idPersonne; }
            set
            {

            }
        }

        public string nomPersonneProperty
        {
            get { return Nom; }
            set
            {
                this.Nom = value;
            }
        }

        public string prénomPersonneProperty
        {
            get { return Prénom; }
            set
            {
                this.Prénom = value;
            }
        }

        public int adminbénéPersonneProperty
        {
            get { return AdminBénévole; }
            set
            {
                this.AdminBénévole = value;
            }
        }
    }
}
