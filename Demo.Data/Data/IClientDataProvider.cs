using Demo.Data.Models;

namespace Demo.Data.Data
{
    public interface IClientDataProvider
    {
        // Dans une interface, les membres sont publics par défaut.
        //  La convention est de ne pas écrire de modificateur d'accès (public, private ou protected)
        List<Client> GetClients();

        void AjouterClient(Client client);
        void SupprimerClient(int clientId);
        void ModifierClient(Client client);

    }
}
