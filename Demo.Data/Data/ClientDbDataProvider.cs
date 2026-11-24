using Demo.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Data.Data
{
    public class ClientDbDataProvider : IClientDataProvider
    {
        private readonly DemoDbContext _context;

        public ClientDbDataProvider(DemoDbContext demoDbContext)
        {
            _context = demoDbContext;
        }

        public void AjouterClient(Client client)
        {
            _context.Clients.Add(client);
            _context.SaveChanges();
        }

        public List<Client> GetClients()
        {
            return _context.Clients
                            .OrderBy(c => c.Prenom)
                            .ThenByDescending(c => c.Nom).ToList();
        }

        public void ModifierClient(Client client)
        {
            Client? clientExistant = _context.Clients.Find(client.Id);
            if (clientExistant != null)
            {
                clientExistant.Prenom = client.Prenom;
                clientExistant.Nom = client.Nom;
                clientExistant.EstClientRegulier = client.EstClientRegulier;
                clientExistant.GateauPreferee = client.GateauPreferee;

                _context.Clients.Update(clientExistant);
                _context.SaveChanges();
            }
        }

        public void SupprimerClient(int clientId)
        {
            Client? clientASupprimer = _context.Clients.FirstOrDefault(c => c.Id == clientId);
            if (clientASupprimer != null)
            {
                _context.Clients.Remove(clientASupprimer);
                _context.SaveChanges();
            }
        }
    }
}
