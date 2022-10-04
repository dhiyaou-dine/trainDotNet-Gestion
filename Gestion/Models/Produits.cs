using System.Reflection.Metadata.Ecma335;

namespace Gestion.Models
{
    public class Produits
    {
        public int id { get; set; }
        public String reference { get; set; }
        public String designation { get; set; }
        public String description { get; set; }
        public bool disponible { get; set; }
        public Famille famille { get; set; }
    }
}
