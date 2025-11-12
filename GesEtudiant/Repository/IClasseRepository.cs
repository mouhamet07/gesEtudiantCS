using GesEtudiant.Entity;

namespace GesEtudiant.Repository
{
    public interface IClasseRepository
    {
        List<Classe> SelectAllClasses();
        Classe? SelectClasseById(int id);
        decimal SelectMoyenneClasse(int id);
    }
}