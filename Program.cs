using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarnetAdresse
{
    class Program
    {
        static void Main(string[] args)
        {
            String choixUtilisateur;
            Boolean exit = false;
            String nom = null;
            String prenom = null;
            String numTel = null;
            String mailPro = null;
            String compteFacebook = null;
            Int16 i = 0; //compteur pour l'affichage du rang des contacts dans les listes

            // Titre de la console
            Console.Title = "Gestion d'un carnet d'adresses";

            // Création de la collection de contacts
            List<Contact> listeContacts = new List<Contact>();

            // Création de la collection de contacts pro
            List<ContactPro> listeContactsPro = new List<ContactPro>();

            // Création de la collection de contacts perso
            List<ContactPerso> listeContactsPerso = new List<ContactPerso>();

            // Ajout dans la liste des contacts par défaut
            listeContactsPro.Add(new ContactPro("SALLOT") { Prenom = "Nicolas", NumTel = "02.43.00.00.01", MailPro = "nico.sallot@gmail.com"});
            listeContacts.Add(new Contact("SALLOT") { Prenom = "Nicolas", NumTel = "02.43.00.00.01" });
            listeContactsPro.Add(new ContactPro("LEMAITRE") { Prenom = "Valentin", NumTel = "02.43.00.00.10", MailPro = "valentin.lm@laposte.net"});
            listeContacts.Add(new Contact("LEMAITRE") { Prenom = "Valentin", NumTel = "02.43.00.00.10" });
            listeContactsPerso.Add(new ContactPerso("OURY") { Prenom = "Louis", NumTel = "02.43.00.00.11", CompteFacebook = "louis.oury4"});
            listeContacts.Add(new Contact("OURY") { Prenom = "Louis", NumTel = "02.43.00.00.11" });
            listeContactsPerso.Add(new ContactPerso("GUESNE") { Prenom = "Maël", NumTel = "02.43.00.01.00", CompteFacebook = "mael.lepanda"});
            listeContacts.Add(new Contact("GUESNE") { Prenom = "Maël", NumTel = "02.43.00.01.00" });
            listeContacts.Add(new Contact("RENAULT") { Prenom = "Antoine", NumTel = "02.43.00.01.01" });
            listeContacts.Add(new Contact("ROUSSE") { Prenom = "Rémi", NumTel = "02.43.00.01.10" });
            listeContacts.Add(new Contact("COUILLEAULT") { Prenom = "Johan", NumTel = "02.43.00.01.11" });

            do
            {
                Menu.AfficherMenuPrincipal();
                choixUtilisateur = Console.ReadLine();

                Console.Clear();
                switch (choixUtilisateur)
                {
                    case "1": // Creer un nouveau contact

                        do // on reaffiche la meme chose en cas de mauvais saisie
                        {
                            Console.WriteLine("Voulez-vous créer un contact pro (1) ou perso (2) ? ");
                            choixUtilisateur = Console.ReadLine();
                            switch (choixUtilisateur)
                            {
                                // contact pro
                                case "1": ContactPro.CreationContact(nom, prenom, numTel, mailPro, listeContactsPro, listeContacts);
                                    break;

                                // contact perso
                                case "2": ContactPerso.CreationContact(nom, prenom, numTel, compteFacebook, listeContactsPerso, listeContacts);
                                    break;

                                default:
                                    break;
                            }
                        } while (choixUtilisateur != "1" && choixUtilisateur != "2");

                        break;
                    case "2": // Afficher la liste des contacts existants
                        Console.WriteLine("Voulez-vous afficher uniquement les contacts pro (1), perso (2) ou tous les contacts (autre touche) ?");
                        choixUtilisateur = Console.ReadLine();
                        Console.Clear();
                        switch (choixUtilisateur)
                        {
                            case "1": // contact pro : affichage du mail pro
                                Menu.AfficherListeContacts();
                        Console.WriteLine("   | Nom           | Prénom     | Num téléphone    | Adresse email");
                        Console.WriteLine("___|_______________|____________|__________________|____________________");
                        Console.WriteLine("   |               |            |                  |");
                        i = 1;
                        foreach (ContactPro uncontact in listeContactsPro)
                        {
                            // Ce "if" est juste là pour faire joli (aligner les lignes pour faire un tableau)
                            if (i < 10)
                            {
                                Console.WriteLine(i + "  | " + uncontact.InformationsFormateesPro());
                            }
                            else
                            {
                                Console.WriteLine(i + " | " + uncontact.InformationsFormateesPro());
                            }
                            i++;
                        }
                                break;

                            case "2": // contact perso : affichage du compte facebook
                                Menu.AfficherListeContacts();
                                Console.WriteLine("   | Nom           | Prénom     | Num téléphone    | Compte Facebook ");
                                Console.WriteLine("___|_______________|____________|__________________|____________________");
                                Console.WriteLine("   |               |            |                  |");
                                i = 1;
                                foreach (ContactPerso uncontact in listeContactsPerso)
                                {
                                    // Ce "if" est juste là pour faire joli (aligner les lignes pour faire un tableau)
                                    if (i < 10)
                                    {
                                        Console.WriteLine(i + "  | " + uncontact.InformationsFormateesPerso());
                                    }
                                    else
                                    {
                                        Console.WriteLine(i + " | " + uncontact.InformationsFormateesPerso());
                                    }
                                    i++;
                                }
                                break;

                            default:
                                Menu.AfficherListeContacts();
                        Console.WriteLine("   | Nom           | Prénom     | Num téléphone    ");
                        Console.WriteLine("___|_______________|____________|__________________");
                        Console.WriteLine("   |               |            |                  ");
                        i = 1;
                        foreach (Contact uncontact in listeContacts)
                        {
                            // Ce "if" est juste là pour faire joli (aligner les lignes pour faire un tableau)
                            if (i < 10)
                            {
                                Console.WriteLine(i + "  | " + uncontact.InformationsFormatees());
                            }
                            else
                            {
                                Console.WriteLine(i + " | " + uncontact.InformationsFormatees());
                            }
                            i++;
                        }
                                break;
                        }

                        

                        // la liste est affichée
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.Write("Saisir le numéro d'un contact pour le sélectionner\n(ou 0 pour retourner au menu) : ");

                        String selectContact = Console.ReadLine();
                        //Il faut convertir la chaine saisie en entier
                        Int32 entselectContact;
                        Boolean conversionReussie = Int32.TryParse(selectContact, out entselectContact);
                        if (conversionReussie)
                        {
                            if (entselectContact == 0)
                            {

                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine();
                                Console.WriteLine("Détails du contact sélectionné : ");
                                Console.WriteLine();
                                Console.WriteLine(listeContacts.ElementAt(entselectContact - 1).Informations());
                                Console.WriteLine();
                                Console.WriteLine();
                                Console.WriteLine("M pour modifier le contact,\nS pour le supprimer,\n0 pour revenir à la liste");
                                Console.Write("Votre choix : ");
                                String alterContact = Console.ReadLine();
                                Console.WriteLine();
                                switch (alterContact.ToUpper())
                                {
                                    case "M":
                                        Console.Clear();
                                        Console.WriteLine();
                                        Console.WriteLine("   MODIFICATION D'UN CONTACT");
                                        Console.WriteLine("____________________________________");
                                        Console.WriteLine();
                                        Console.WriteLine(listeContacts.ElementAt(entselectContact - 1).Informations());
                                        Console.WriteLine();
                                        listeContacts.ElementAt(entselectContact - 1).ModifierContact(listeContacts.ElementAt(entselectContact - 1));
                                        break;
                                    case "S":
                                        listeContacts.Remove(listeContacts.ElementAt(entselectContact - 1));
                                        Console.WriteLine("Suppression effectuée");
                                        break;
                                    case "O":
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }
                        break;
                    case "3":
                        Menu.AfficherRechercheContact();
                        break;
                    case "0":
                        Menu.AfficherAuRevoir();
                        exit = true;
                        break;
                    default:
                        // Retour au menu
                        break;
                }
            } while (!exit);

        }
    }
}
