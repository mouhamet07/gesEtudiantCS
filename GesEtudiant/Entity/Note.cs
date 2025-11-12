namespace GesEtudiant.Entity
{
    public class Note
    {   
        public static int Compteur = 0;
        public int Id { get; set; }
        public string Matiere { get; set; }
        public decimal Valeur { get; set; }
        public string Appreciation { get; set; }
        public Note()
        {
            Id = ++Compteur;
        }

        public override string ToString()
        {
            return $"ID: {Id}, Matiere: {Matiere}, Valeur: {Valeur}, Appreciation: {Appreciation}";
        }
    }
}