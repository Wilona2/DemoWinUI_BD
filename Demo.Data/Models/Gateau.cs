using Demo.Data.Models.Types;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Data.Models
{
    public class Gateau
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public DateOnly MeilleureAvant { get; set; }
        public TypeGateau Categorie { get; set; }

        public decimal Prix { get; set; }

        // Si on ne souhaite pas le stocker dans la BD mais qu'on en a besoin juste ici. 
        //    On ne l'initialise pas manuellement dans le seeding,
        [NotMapped]
        public decimal PrixAvecTaxes => Prix * 1.15m;

        // Relation : côté "N"
        // ? --> nullable : un gâteau peut exister sans client
        public int? ClientId { get; set; }
        public Client? Client { get; set; }


        public Gateau(string nom = "", DateOnly meilleureAvant = new DateOnly(), TypeGateau categorie = TypeGateau.Basique, decimal prix = 50)
        {
            Nom = nom;
            Categorie = categorie;
            MeilleureAvant = meilleureAvant;
            Prix = prix;
        }
    }
}
