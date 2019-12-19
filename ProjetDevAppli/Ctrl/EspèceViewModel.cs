using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDevAppli.Ctrl
{
    public class EspèceViewModel
    {
        private int idEspèce;
        private string Nom;

        public EspèceViewModel() { }

        public EspèceViewModel(int id, string nom)
        {
            this.idEspèce = id;
            this.Nom = nom;
        }

        public int idEspèceProperty
        {
            get { return idEspèce; }
        }

        public String nomEspèceProperty
        {
            get { return Nom; }
        }
    }
}
