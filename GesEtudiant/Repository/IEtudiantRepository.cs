using GesEtudiant.Entity;

namespace GesEtudiant.Repository
{
    public interface IEtudiantRepository
    {
        void AddEtudiant(Etudiant etudiant);
        void AddNoteToEtudiant(int etudiantId, Note note);
        List<Etudiant> SelectAllEtudiants();
        Etudiant? SelectEtudiantById(int id);
        void DeleteEtudiant(int id);
        Etudiant? SelectMeilleurEtudiant();
    }
}