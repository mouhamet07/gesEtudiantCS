using GesEtudiant.Entity;
using GesEtudiant.Repository;

namespace GesEtudiant.Service.Impl
{
    public class EtudiantService : IEtudiantService
    {
        private readonly IEtudiantRepository _etudiantRepository;
        public EtudiantService(IEtudiantRepository etudiantRepository)
        {
            _etudiantRepository = etudiantRepository;
        }
        public void CreateEtudiant(Etudiant etudiant)
        {
            _etudiantRepository.AddEtudiant(etudiant);
        }
        public void AddNoteToEtudiant(int etudiantId, Note note)
        {
            var etudiant = _etudiantRepository.SelectEtudiantById(etudiantId);
            if (etudiant != null)
            {
                _etudiantRepository.AddNoteToEtudiant(etudiantId, note);
            }
        }
        public List<Etudiant> GetAllEtudiants()=>_etudiantRepository.SelectAllEtudiants();
        public Etudiant? GetEtudiantById(int id)=>_etudiantRepository.SelectEtudiantById(id);
        public void RemoveEtudiant(int id)
        {
            _etudiantRepository.DeleteEtudiant(id);
        }
        public Etudiant? GetMeilleurEtudiant()=>_etudiantRepository.SelectMeilleurEtudiant();
    }
}