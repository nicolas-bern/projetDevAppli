using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDevAppli.Ctrl
{
    public class PlageViewModel
    {
        private int idPlage;
        private string Nom;
        private string Commune;
        private string Département;
        private int Superficie;

        public PlageViewModel() { }

        public PlageViewModel(int id, string nom, string commune, string département, int superficie)
        {
            this.idPlage = id;
            this.Nom = nom;
            this.Commune = commune;
            this.Département = département;
            this.Superficie = superficie;
        }

        public int idPlageProperty
        {
            get { return idPlage; }
        }

        public String nomPlageProperty
        {
            get { return Nom; }
            set
            {
                this.Nom = value;
            }
        }

        public String communeProperty
        {
            get { return Commune; }
            set
            {
                this.Commune = value;
            }
        }

        public String départementProperty
        {
            get { return Département; }
            set
            {
                this.Département = value;
            }
        }

        public int superficieProperty
        {
            get { return Superficie; }
            set
            {
                this.Superficie = value;
            }
        }
    }
}
