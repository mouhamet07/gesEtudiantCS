using GesEtudiant.Entity;
using GesEtudiant.Repository;

namespace GesEtudiant.Service.Impl
{
    public class ClasseService : IClasseService
    {
        private readonly IClasseRepository _classeRepository;
        public ClasseService(IClasseRepository classeRepository)
        {
            _classeRepository = classeRepository;
        }
        public List<Classe> GetAllClasses()=>_classeRepository.SelectAllClasses();
        public Classe? GetClasseById(int id)=>_classeRepository.SelectClasseById(id);
        public decimal GetMoyenneClasse(int id)=>_classeRepository.SelectMoyenneClasse(id);
    }
}