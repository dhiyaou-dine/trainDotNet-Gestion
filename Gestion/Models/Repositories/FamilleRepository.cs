namespace Gestion.Models.Repositories
{
    public class FamilleRepository : IRepositorie<Famille>
    {
        public IList<Famille> familles { get; set; }
        public FamilleRepository()
        {
            familles = new List<Famille>()
            {
                new Famille
                {
                    id = 1, nom = "Imprimentes"
                },
                new Famille
                {
                    id = 2, nom = "PC"
                },
                new Famille
                {
                    id = 3, nom = "Camera"
                }

            };
        }
        public void ajouter(Famille element)
        {
            familles.Add(element);        
        }

        public IList<Famille> lister()
        {
            return familles;
        }

        public Famille listerSelonId(int id)
        {
            return familles.Single(x => x.id == id);
        }

        public void modifier(int id, Famille element)
        {
            var ancienneFamille = listerSelonId(id);
            ancienneFamille.nom = element.nom;
        }

        public void supprimer(int id)
        {
            var famille = listerSelonId(id);
            familles.Remove(famille);
        }
    }
}
