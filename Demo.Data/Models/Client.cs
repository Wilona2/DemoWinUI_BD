using Demo.Data.Models.Types;
using System;

namespace Demo.Data.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Prenom { get; set; }
        public string Nom { get; set; }
        public bool EstClientRegulier { get; set; }

        public DateOnly DateCreation { get; set; }

        public TypeGateau GateauPreferee { get; set; }

        // Propriété de navigation.
        // La liste des gâteaux associés à ce client : Peut-être vide (aucun gâteau) mais pas nulle.
        public List<Gateau> Gateaux { get; set; } = new List<Gateau>();


        public Client(int id, string prenom, string nom, bool estClientRegulier,
    DateOnly dateCreation, TypeGateau gateauPreferee) : this(prenom, nom, estClientRegulier, dateCreation, gateauPreferee)
        {

            Id = id;
        }

        public Client(string prenom = "", string nom = "", bool estClientRegulier = false,
            DateOnly dateCreation = new DateOnly(), TypeGateau gateauPreferee = TypeGateau.Tarte)
        {
            Prenom = prenom;
            Nom = nom;
            EstClientRegulier = estClientRegulier;

            if (dateCreation > DateOnly.MinValue)
            {
                DateCreation = dateCreation;
            }
            else
            {
                DateCreation = DateOnly.FromDateTime(DateTime.Now);
            }

            GateauPreferee = gateauPreferee;
        }

    }
}
