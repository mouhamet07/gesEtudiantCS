using GesEtudiant.Entity;

namespace GesEtudiant.Service
{
    public interface IClasseService
    {
        List<Classe> GetAllClasses();
        Classe? GetClasseById(int id);
        decimal GetMoyenneClasse(int id);
    }
}