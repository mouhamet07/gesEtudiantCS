namespace GesEtudiant.Entity
{
    public enum Sexe
    {
        Masculin,
        Feminin
    }
    public class Etudiant
    {
        private static int Compteur = 0;
        public int Id { get; set; }
        public string NomComplet { get; set; }
        public Sexe Sexe { get; set; }
        public List<Note> Notes { get; } = new List<Note>();

        public Etudiant()
        {
            Id = ++Compteur;
        }

        public override string ToString()
        {
            return $"ID: {Id}, Nom Complet: {NomComplet}, Sexe: {Sexe}, Nombre de notes: {Notes.Count}";
        }
    }
}