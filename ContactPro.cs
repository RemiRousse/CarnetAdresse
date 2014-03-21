using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarnetAdresse
{
    class ContactPro : Contact
    {
        #region Attributs
        private String _MailPro;
        #endregion

        #region Propriétés
        public String MailPro
        {
            get { return _MailPro; }
            set { _MailPro = value; }
        }
        #endregion

        #region Constructeurs
         public ContactPro(String nom) : base(nom)
        {

        }
        #endregion

        #region Méthodes
         public String InformationsFormateesPro()
         {
             String mailFormate = FormatageChaine(this.MailPro, 25);
             return base.InformationsFormatees() + " | " + mailFormate;
         }

         public override string Informations()
         {
             return base.Informations() + "   " + this.MailPro;
         }

         public static String SaisirMail(String mailPro)
         {
             Console.Clear();
             Console.WriteLine();
             Console.WriteLine("   CREATION D'UN CONTACT PRO");
             Console.WriteLine("____________________________________");
             Console.WriteLine();
             Console.Write("Saisir l'adresse email : ");
             mailPro = Console.ReadLine();
             return mailPro;
         }

         public static void CreationContact(String nom, String prenom, String numTel, String mailPro, List<ContactPro> listePro, List<Contact> liste)
         {
             String validSave = null;
             String autreContact = null;

             do
             {
                 nom = Contact.SaisirNom(nom);
                 prenom = Contact.SaisirPrenom(prenom);
                 numTel = Contact.SaisirNumTel(numTel);
                 mailPro = ContactPro.SaisirMail(mailPro);
                 AfficherUnContactPro(nom, prenom, numTel, mailPro);
                 Console.WriteLine();
                 Console.WriteLine();
                 Console.WriteLine("Voulez-vous enregistrer ce contact ? (1 pour valider, 0 pour annuler)");
                 Console.Write("Votre choix : ");
                 validSave = Console.ReadLine();
                 if (validSave == "1")
                 {
                     listePro.Add(new ContactPro(nom) { Prenom = prenom, NumTel = numTel, MailPro = mailPro });
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

         public static void AfficherUnContactPro(String nom, String prenom, String numTel, String MailPro)
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
             Console.WriteLine("Mail pro : " + MailPro);
         }
        #endregion
    }
}
