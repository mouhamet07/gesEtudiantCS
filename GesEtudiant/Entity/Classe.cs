namespace GesEtudiant.Entity
{
    public class Classe
    {
        public static int Compteur = 0;
        public int Id { get; set; }
        public string Libelle { get; set; }
        public List<Etudiant> Etudiants { get; } = new List<Etudiant>();

        public Classe()
        {
            Id = ++Compteur;
        }

        public override string ToString()
        {
            return $"ID: {Id}, Libelle: {Libelle}, Nombre d'etudiants: {Etudiants.Count}";
        }
    }
}