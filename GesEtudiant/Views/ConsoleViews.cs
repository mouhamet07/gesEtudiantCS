using GesEtudiant.Entity;
using GesEtudiant.Service;

namespace GesEtudiant.Views
{
    public class ConsoleViews
    {
        private readonly IClasseService classeService;
        private readonly IEtudiantService etudiantService;

        public ConsoleViews(IClasseService classeService, IEtudiantService etudiantService)
        {
            this.classeService = classeService;
            this.etudiantService = etudiantService;
        }
        private void SaisirEtudiant()
        {
            Console.WriteLine("\n=== AJOUT D’UN ÉTUDIANT ===");
            Console.Write("Nom complet : ");
            string nom = Console.ReadLine() ?? "";
            Console.Write("Sexe (M/F) : ");
            string s = Console.ReadLine()?.ToUpper() ?? "M";
            Sexe sexe = s == "F" ? Sexe.Feminin : Sexe.Masculin;
            Console.WriteLine("Choisir une classe : ");
            var classes = classeService.GetAllClasses();
            foreach (var c in classes)
            {
                Console.WriteLine($"{c.Id}. {c.Libelle}");
            }
            Console.Write("ID classe : ");
            if (!int.TryParse(Console.ReadLine(), out int idClasse))
            {
                Console.WriteLine("ID invalide !");
                return;
            }
            var classe = classeService.GetClasseById(idClasse);
            if (classe == null)
            {
                Console.WriteLine("Classe introuvable !");
                return;
            }
            var etu = new Etudiant
            {
                NomComplet = nom,
                Sexe = sexe
            };
            etudiantService.CreateEtudiant(etu);
            classe.Etudiants.Add(etu);
            Console.WriteLine("Etudiant ajoute avec succes !");
        }
        private void AfficherEtudiants()
        {
            Console.WriteLine("\n=== LISTE DES ÉTUDIANTS ===");
            var etudiants = etudiantService.GetAllEtudiants();
            if (!etudiants.Any())
            {
                Console.WriteLine("Aucun étudiant enregistré.");
                return;
            }
            foreach (var e in etudiants)
            {
                Console.WriteLine(e);
            }
        }
        private void AjouterNoteEtudiant()
        {
            Console.Write("\nID de l’étudiant : ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("ID invalide !");
                return;
            }
            var etudiant = etudiantService.GetEtudiantById(id);
            if (etudiant == null)
            {
                Console.WriteLine("Etudiant introuvable !");
                return;
            }
            Console.Write("Matière : ");
            string matiere = Console.ReadLine() ?? "";
            Console.Write("Valeur : ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal valeur))
            {
                Console.WriteLine("Valeur invalide !");
                return;
            }
            Console.Write("Appréciation : ");
            string appreciation = Console.ReadLine() ?? "";
            var note = new Note
            {
                Matiere = matiere,
                Valeur = valeur,
                Appreciation = appreciation
            };
            etudiantService.AddNoteToEtudiant(id, note);
            Console.WriteLine("Note ajoutée !");
        }
        private void AfficherNotesEtudiant()
        {
            Console.Write("\nID de l’étudiant : ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("ID invalide !");
                return;
            }
            var etudiant = etudiantService.GetEtudiantById(id);
            if (etudiant == null)
            {
                Console.WriteLine("Étudiant introuvable !");
                return;
            }
            Console.WriteLine($"\nNotes de {etudiant.NomComplet}:");
            if (!etudiant.Notes.Any())
            {
                Console.WriteLine("Aucune note enregistrée.");
                return;
            }
            foreach (var n in etudiant.Notes)
            {
                Console.WriteLine($"→ {n.Matiere} : {n.Valeur}/20 - {n.Appreciation}");
            }
        }
        private void SupprimerEtudiant()
        {
            Console.Write("\nID de l’étudiant à supprimer : ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("ID invalide !");
                return;
            }
            etudiantService.RemoveEtudiant(id);
            Console.WriteLine("Etudiant supprimé !");
        }
        private void AfficherMeilleurEtudiant()
        {
            var meilleur = etudiantService.GetMeilleurEtudiant();
            if (meilleur == null)
            {
                Console.WriteLine("Aucun étudiant avec des notes.");
                return;
            }
            decimal moyenne = meilleur.Notes.Any() ? meilleur.Notes.Average(n => n.Valeur) : 0;
            Console.WriteLine($"🏆 Meilleur étudiant : {meilleur.NomComplet} (moyenne : {moyenne:F2})");
        }
        private void AfficherMoyenneClasse()
        {
            Console.WriteLine("\n=== MOYENNE PAR CLASSE ===");
            var classes = classeService.GetAllClasses();
            foreach (var c in classes)
            {
                decimal moy = classeService.GetMoyenneClasse(c.Id);
                Console.WriteLine($"{c.Libelle} → Moyenne : {moy:F2}");
            }
        }
        public void Run()
        {
            while (true)
            {
                Console.WriteLine("\n=========== MENU PRINCIPAL ===========");
                Console.WriteLine("1. Ajouter un etudiant");
                Console.WriteLine("2. Afficher les etudiant");
                Console.WriteLine("3. Ajouter une note à un etudiant");
                Console.WriteLine("4. Afficher les notes un etudiant avec l’appreciation");
                Console.WriteLine("5. Supprimer un etudiant");
                Console.WriteLine("6. Afficher le Meilleur etudiant");
                Console.WriteLine("7. Afficher la moyenne de la classe");
                Console.WriteLine("8. Quitter");
                Console.Write("Faites votre choix: ");
                string? choix = Console.ReadLine();
                switch (choix)
                {
                    case "1":
                        SaisirEtudiant();
                        break;
                    case "2":
                        AfficherEtudiants();
                        break;
                    case "3":
                        AjouterNoteEtudiant();
                        break;
                    case "4":
                        AfficherNotesEtudiant();
                        break;
                    case "5":
                        SupprimerEtudiant();
                        break;
                    case "6":
                        AfficherMeilleurEtudiant();
                        break;
                    case "7":
                        AfficherMoyenneClasse();
                        break;
                    case "8":
                        Console.WriteLine("Au revoir !");
                        return;
                    default:
                        Console.WriteLine("Choix invalide !");
                        break;
                }
            }
        }
    }
}
