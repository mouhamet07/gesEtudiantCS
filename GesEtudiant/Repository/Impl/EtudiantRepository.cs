using GesEtudiant.Entity;

namespace GesEtudiant.Repository.Impl
{
    public class EtudiantRepository : IEtudiantRepository
    {
        private readonly List<Etudiant> etudiants = new();

        public void AddEtudiant(Etudiant etudiant)
        {
            etudiants.Add(etudiant);
        }

        public void AddNoteToEtudiant(int etudiantId, Note note)
        {
            var etudiant = etudiants.FirstOrDefault(e => e.Id == etudiantId);
            if (etudiant != null)
            {
                etudiant.Notes.Add(note);
            }
        }

        public List<Etudiant> SelectAllEtudiants() => etudiants;

        public Etudiant? SelectEtudiantById(int id) => etudiants.FirstOrDefault(e => e.Id == id);

        public void DeleteEtudiant(int id)
        {
            var etudiant = etudiants.FirstOrDefault(e => e.Id == id);
            if (etudiant != null)
            {
                etudiants.Remove(etudiant);
            }
        }

        public Etudiant? SelectMeilleurEtudiant() => etudiants
            .OrderByDescending(e => e.Notes != null && e.Notes.Any() ? e.Notes.Average(n => n.Valeur) : 0)
            .FirstOrDefault();
    }
}