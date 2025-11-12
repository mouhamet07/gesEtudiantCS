namespace GesEtudiant.Views
{
    using GesEtudiant.Entity;
    using GesEtudiant.Service;

    public class ConsoleViews
    {
        private readonly IClasseService classeService;
        private readonly IEtudiantService etudiantService;
        public ConsoleViews(IClasseService classeService, IEtudiantService etudiantService)
        {
            this.classeService = classeService;
            this.etudiantService = etudiantService;
        }
        public void Run()
        {
            while (true)
            {
                Console.WriteLine("=========== MENU PRINCIPAL ===========");
                Console.WriteLine("1. Ajouter un etudiant");
                Console.WriteLine("2. Afficher les Etudiant");
                Console.WriteLine("3. Ajouter une note à un etudiant");
                Console.WriteLine("4. Afficher les notes un etudiant avec l’appreciation");
                Console.WriteLine("5. Supprimer un Etudiant");
                Console.WriteLine("6. Afficher le Meilleur etudiants ");
                Console.WriteLine("7. Afficher la moyenne de la classe");
                Console.WriteLine("8. Quitter");
                Console.Write("Faites votre choix: ");
                var choix = Console.ReadLine();

                switch (choix)
                {
                    case "1":
                        
                        break;

                    case "2":
                        
                        break;

                    case "3":
                        
                        break;

                    case "4":
                        
                        break;

                    case "5":
                        
                        break;

                    case "6":

                        break;
                        
                    case "7":

                        break;
                        
                    case "8":
                        Console.WriteLine("Au revoir !");
                        return;

                    default:
                        Console.WriteLine("Veuillez choisir une option valide.");
                        break;
                }
                Console.WriteLine();
            }
        }
    }
}
