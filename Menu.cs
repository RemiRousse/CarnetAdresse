using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarnetAdresse
{
    static class Menu
    {
        #region Attributs

        #endregion

        #region Propriétés

        #endregion

        #region Constructeurs

        #endregion

        #region Méthodes
        public static void AfficherMenuPrincipal()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("   GESTION D'UN CARNET D'ADRESSES");
            Console.WriteLine("____________________________________");
            Console.WriteLine();
            Console.WriteLine("** 1. Créer un contact *************");
            Console.WriteLine("*** 2. Afficher les contacts *******");
            Console.WriteLine("**** 3. Rechercher un contact ******");
            Console.WriteLine("***** 0. Quitter *******************");
            Console.WriteLine("____________________________________");
            Console.WriteLine();
            Console.Write("                    Votre choix : ");
        }

        public static void AfficherListeContacts()
        {
            Console.WriteLine();
            Console.WriteLine("   LISTE DES CONTACTS");
            Console.WriteLine("____________________________________");
            Console.WriteLine();
        }

        public static void AfficherRechercheContact()
        {
            Console.WriteLine();
            Console.WriteLine("   RECHERCHE D'UN CONTACT");
            Console.WriteLine("____________________________________");
            Console.WriteLine();
            // Appel methodes pour recherche, puis modification / suppression
            Console.Read();
        }

        public static void AfficherAuRevoir()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("     A bientôt");
            Console.Read();
        }

        public void ModifierContact(Contact contact)
        {
            Console.Write("Saisir le nouveau nom : ");
            contact.Nom = Console.ReadLine();
            Console.Write("Saisir le nouveau prénom : ");
            contact.Prenom = Console.ReadLine();
            Console.Write("Saisir le nouveau numéro de téléphone : ");
            contact.NumTel = Console.ReadLine();
            if (contact is ContactPerso)
            {
                Console.Write("Saisir le nouveau compte Facebook : ");
                (contact as ContactPerso).CompteFacebook = Console.ReadLine();
            }
            else if (contact is ContactPro)
            {
                Console.Write("Saisir la nouvelle adresse email : ");
                (contact as ContactPro).MailPro = Console.ReadLine();
            }
        }

        public static String FormatageChaine(String str, Int16 longueurMax)
        {
            String strFormatee = str;

            while (strFormatee.Length < longueurMax)
            {
                strFormatee += " ";
            }
            return strFormatee;
        }

        public static String SaisirNom(String nom)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("   CREATION D'UN CONTACT");
            Console.WriteLine("____________________________________");
            Console.WriteLine();
            Console.Write("Saisir le nom : ");
            nom = Console.ReadLine();
            return nom;
        }

        public static String SaisirPrenom(String prenom)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("   CREATION D'UN CONTACT");
            Console.WriteLine("____________________________________");
            Console.WriteLine();
            Console.Write("Saisir le prénom : ");
            prenom = Console.ReadLine();
            return prenom;
        }

        public static String SaisirNumTel(String numTel)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("   CREATION D'UN CONTACT");
            Console.WriteLine("____________________________________");
            Console.WriteLine();
            Console.Write("Saisir le numéro de téléphone : ");
            numTel = Console.ReadLine();
            return numTel;
        }
        #endregion

    }
}
