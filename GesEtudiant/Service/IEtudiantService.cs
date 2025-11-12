using GesEtudiant.Entity;

namespace GesEtudiant.Service
{
    public interface IEtudiantService
    {
        void CreateEtudiant(Etudiant etudiant);
        void AddNoteToEtudiant(int etudiantId, Note note);
        List<Etudiant> GetAllEtudiants();
        Etudiant? GetEtudiantById(int id);
        void RemoveEtudiant(int id);
        Etudiant? GetMeilleurEtudiant();
    }
}