namespace Gestion.Models.ViewModels
{
    public class ProduitFamille
    {
        public int ProduitId { get; set; }
        public string reference { get; set; }
        public String designation { get; set; }
        public  String description { get; set; }
        public bool disponible { get; set; }    
        public int FamilleId { get; set; }
        public IList<Famille> FamilleList { get; set; }
    }
}
