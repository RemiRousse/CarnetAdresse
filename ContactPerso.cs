using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarnetAdresse
{
    class ContactPerso : Contact
    {
        #region Attributs
        private String _CompteFacebook;
        #endregion

        #region Propriétés
        public String CompteFacebook
        {
            get { return _CompteFacebook; }
            set { _CompteFacebook = value; }
        }
        #endregion

        #region Constructeurs
        public ContactPerso(String nom)
            : base(nom)
        {

        }
        #endregion

        #region Méthodes
        public String InformationsFormateesPerso()
        {
            String compteFacebook = Menu.FormatageChaine(this.CompteFacebook, 25);
            return base.InformationsFormatees() + " | " + compteFacebook;
        }

        public override string Informations()
        {
            return base.Informations() + "   " + this.CompteFacebook;
        }

        public static String SaisirCompteFacebook(String compteFacbook)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("   CREATION D'UN CONTACT PERSO");
            Console.WriteLine("____________________________________");
            Console.WriteLine();
            Console.Write("Saisir le compte Facebook : ");
            compteFacbook = Console.ReadLine();
            return compteFacbook;
        }

        public static void CreationContact(String nom, String prenom, String numTel, String compteFacebook, List<ContactPerso> listePerso, List<Contact> liste)
        {
            String validSave = null;
            String autreContact = null;

            do
            {
                nom = Menu.SaisirNom(nom);
                prenom = Menu.SaisirPrenom(prenom);
                numTel = Menu.SaisirNumTel(numTel);
                compteFacebook = ContactPerso.SaisirCompteFacebook(compteFacebook);
                AfficherUnContact(nom, prenom, numTel, compteFacebook);
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Voulez-vous enregistrer ce contact ? (1 pour valider, 0 pour annuler)");
                Console.Write("Votre choix : ");
                validSave = Console.ReadLine();
                if (validSave == "1")
                {
                    listePerso.Add(new ContactPerso(nom) { Prenom = prenom, NumTel = numTel, CompteFacebook = compteFacebook });
                    liste.Add(new Contact(nom) { Prenom = prenom, NumTel = numTel });

                    Console.WriteLine();
                    Console.WriteLine("Contact enregistré avec succès");
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Enregistrement annulé");
                }

                Console.ReadLine();
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("   CREATION D'UN CONTACT");
                Console.WriteLine("____________________________________");
                Console.WriteLine();

                Console.WriteLine("Voulez-vous créer un autre contact ? (1 pour en recréer un, 0 pour revenir au menu principal)");
                Console.Write("Votre choix : ");
                autreContact = Console.ReadLine();
            } while (autreContact == "1");
        }

        public static void AfficherUnContact(String nom, String prenom, String numTel, String compteFacebook)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("   CREATION D'UN CONTACT");
            Console.WriteLine("____________________________________");
            Console.WriteLine();
            Console.WriteLine("Récapitulatif des informations du contact");
            Console.WriteLine();
            Console.WriteLine("Nom : " + nom);
            Console.WriteLine("Prenom : " + prenom);
            Console.WriteLine("Numero de téléphone : " + numTel);
            Console.WriteLine("Compte Facebook : " + compteFacebook);
        }
        #endregion
    }
}
