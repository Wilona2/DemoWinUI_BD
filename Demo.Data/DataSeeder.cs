using Demo.Data.Models;
using Demo.Data.Models.Types;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Data
{
    public class DataSeeder
    {
        private readonly DemoDbContext _context;

        public DataSeeder(DemoDbContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            // Seulement si la table est vide
            if (!_context.Clients.Any())
            {
                // Créer les données initiales 
                List<Client> clients = new List<Client>
                {
                    new Client("Jean", "Dupont", true, gateauPreferee: TypeGateau.Tarte),
                    new Client("Marie", "Martin", false, gateauPreferee: TypeGateau.Entremet),
                    new Client("Pierre", "Bernard", true, gateauPreferee: TypeGateau.Etages),
                    new Client("Sophie", "Petit", false, gateauPreferee: TypeGateau.Tarte),
                    new Client("Luc", "Moreau", true, gateauPreferee: TypeGateau.Design)
                };

                // Ajouter les données initiales au contexte de base de données.
                _context.AddRange(clients);
                _context.SaveChanges();

            }

            // Gâteaux : seulement si la table est vide
            if (!_context.Gateaux.Any())
            {
                // Les clients existent maintenant dans la base, avec leur Id
                List<Client> clients = _context.Clients.OrderBy(c => c.Id).ToList();

                // On associe chaque gâteau au client qui l'a acheté (ClientId),
                // ou null si le gâteau n'est pas vendu.
                List<Gateau> gateaux = new List<Gateau>
                {
                    // Gâteaux vendus (avec clients)
                    new Gateau("Tarte aux fraises", DateOnly.FromDateTime(DateTime.Now.AddDays(3)), TypeGateau.Tarte, 45.99m)
                    {
                        ClientId = clients[0].Id
                    },
                    new Gateau("Entremet chocolaté", DateOnly.FromDateTime(DateTime.Now.AddDays(2)), TypeGateau.Entremet, 55.00m)
                    {
                        ClientId = clients[1].Id
                    },
                    new Gateau("Gâteau à étages vanille", DateOnly.FromDateTime(DateTime.Now.AddDays(4)), TypeGateau.Etages, 75.50m)
                    {
                        ClientId = clients[2].Id
                    },
                    new Gateau("Gâteau basique au citron", DateOnly.FromDateTime(DateTime.Now.AddMonths(-4)), TypeGateau.Basique, 35.00m)
                    {
                        ClientId = clients[3].Id
                    },

                    // Gâteaux disponibles (non vendus, ClientId = null)
                    new Gateau("Tarte au citron", DateOnly.FromDateTime(DateTime.Now.AddDays(2)), TypeGateau.Tarte, 29.99m),
                    new Gateau("Gâteau design vanille-amandes", DateOnly.FromDateTime(DateTime.Now.AddDays(3)), TypeGateau.Design, 65.00m),
                    new Gateau("Entremet aux amandes", DateOnly.FromDateTime(DateTime.Now.AddDays(5)), TypeGateau.Entremet, 48.75m)
                };

                _context.Gateaux.AddRange(gateaux);
                _context.SaveChanges();
            }

        }
    }
}
