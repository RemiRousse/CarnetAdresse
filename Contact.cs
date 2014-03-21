using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarnetAdresse
{
    class Contact
    {
        #region Attributs
        private String _Nom;
        private String _NumTel;
        private String _Prenom;
        private String _Type;
        #endregion
        
        #region Propriétés
        public String Nom
        {
            get { return _Nom; }
            set { _Nom = value; }
        }

        public String Prenom
        {
            get { return _Prenom; }
            set { _Prenom = value; }
        }

        public String NumTel
        {
            get { return _NumTel; }
            set { _NumTel = value; }
        }

        public String Type
        {
            get { return _Type; }
            set { _Type = value; }
        }
        #endregion

        #region Constructeurs
        public Contact(String nom)
        {
            this.Nom = nom;
        }
        #endregion

        #region Méthodes
        public String InformationsFormatees()
        {
            String nomFormate = Menu.FormatageChaine(this.Nom, 13);
            String prenomFormate = Menu.FormatageChaine(this.Prenom, 10);
            String numTelFormate = Menu.FormatageChaine(this.NumTel, 16);

            String infosFormatees = nomFormate + " | " + prenomFormate + " | " + numTelFormate;

            return infosFormatees;
        }

        public virtual String Informations()
        {
            return this.Nom + "   " + this.Prenom + "   " + this.NumTel;
        }
        #endregion
    }
}
