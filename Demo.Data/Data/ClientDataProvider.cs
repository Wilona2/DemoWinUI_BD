using Demo.Data.Models;
using Demo.Data.Models.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Data.Data
{
    public class ClientDataProvider : IClientDataProvider
    {
        private readonly List<Client> _clients;
        private int _prochainId = 1;

        public ClientDataProvider()
        {
            _clients = new List<Client>();

            AjouterClient(new Client("Jean", "Dupont", true, gateauPreferee: TypeGateau.Tarte));
            AjouterClient(new Client("Marie", "Martin", false, gateauPreferee: TypeGateau.Entremet));
            AjouterClient(new Client("Pierre", "Bernard", true, gateauPreferee: TypeGateau.Etages));
            AjouterClient(new Client("Sophie", "Petit", false, gateauPreferee: TypeGateau.Tarte));
            AjouterClient(new Client("Luc", "Moreau", true, gateauPreferee: TypeGateau.Design));

        }

        public void AjouterClient(Client client)
        {
            client.Id = _prochainId++;
            _clients.Add(client);
        }

        public List<Client> GetClients()
        {
            return _clients;
        }

        public void ModifierClient(Client client)
        {
            int index = _clients.FindIndex(c => c.Id == client.Id);
            if (index != -1)
            {
                _clients[index] = client;
            }
        }

        public void SupprimerClient(int clientId)
        {
            Client? client = _clients.FirstOrDefault(c => c.Id == clientId);
            if (client != null)
            {
                _clients.Remove(client);
            }

        }
    }
}
