using GesEtudiant.Entity;

namespace GesEtudiant.Repository.Impl
{
    public class ClasseRepository : IClasseRepository
    {
        private readonly List<Classe> classes = new();
        public List<Classe> SelectAllClasses() => classes;
        public Classe? SelectClasseById(int id)=>
            classes.FirstOrDefault(c => c.Id == id);
        public decimal SelectMoyenneClasse(int id) =>
            classes.FirstOrDefault(c => c.Id == id)?
                .Etudiants.Average(e => e.Notes.Average(n => n.Valeur)) ?? 0;
    }
}