namespace Gestion.Models.Repositories
{
    public class ProduitsRepository : IRepositorie<Produits>
    {
        public IList<Produits> produits;
        public ProduitsRepository()
        {
            produits = new List<Produits>()
            {
                new Produits
                {
                    id = 1,
                    reference = "EL1110",
                    designation = "EPSON ECOTANK L1110",
                    description = "Impression Jet d'encre",
                    disponible = true,
                    famille = new Famille{id=1,nom="Imprimante"}
                },
                new Produits
                {
                    id = 2,
                    reference = "EL32110",
                    designation = "EPSON ECOTANK L3110",
                    description = "Impression Jet d'encre avec wifi",
                    disponible = true,
                    famille = new Famille{id=1,nom="Imprimante"}
                },
                new Produits
                {
                    id = 3,
                    reference = "CANON250D",
                    designation = "CANON 250D",
                    description = "Camera pour debutant...",
                    disponible = true,
                    famille = new Famille{id=3,nom="Camera"}
                }
            };
        }
        public void ajouter(Produits element)
        {
            element.id = produits.Max(x => x.id)+1;
            produits.Add(element);
        }

        public IList<Produits> lister()
        {
            return produits;
        }

        public Produits listerSelonId(int id)
        {
            return produits.Single(x => x.id == id);
        }

        public void modifier(int id, Produits element)
        {
            var ancienProduit = listerSelonId(id);
            ancienProduit.designation = element.designation;
            ancienProduit.description = element.description;
            ancienProduit.reference = element.reference;
            ancienProduit.disponible = element.disponible;
            ancienProduit.famille = element.famille;
        }

        public void supprimer(int id)
        {
            var produit = listerSelonId(id);
            produits.Remove(produit);
        }
    }
}
