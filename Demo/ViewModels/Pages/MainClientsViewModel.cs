using Demo.Data.Data;
using Demo.Data.Models;
using Demo.Data.Models.Types;
using Demo.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Demo.ViewModels.Pages
{
    public class MainClientsViewModel : BaseViewModel
    {
        private IClientDataProvider _clientDataProvider;

        public ObservableCollection<ClientViewModel> Clients { get; }

        private ClientViewModel? _clientSelectionne;

        public ClientViewModel? ClientSelectionne
        {
            get { return _clientSelectionne; }
            set
            {
                if (_clientSelectionne != value)
                {
                    _clientSelectionne = value;
                    RaisePropertyChanged();
                }
            }
        }


        public MainClientsViewModel(IClientDataProvider clientDataProvider)
        {
            _clientDataProvider = clientDataProvider;
            Clients = new ObservableCollection<ClientViewModel>();
        }

        public void ChargerDonnees()
        {
            ChargerClients();
        }

        public void ChargerClients()
        {
            Clients.Clear();
            List<Client> clientsData = _clientDataProvider.GetClients();
            foreach (Client client in clientsData)
            {
                Clients.Add(new ClientViewModel(client));
            }
        }

        public void AjouterClient(ClientViewModel clientVM)
        {
            Client client = new Client(clientVM.Prenom, clientVM.Nom,
                clientVM.EstClientRegulier, clientVM.DateCreation, clientVM.GateauPreferee);

            _clientDataProvider.AjouterClient(client);
        }

        public void ModifierClient(ClientViewModel clientVM)
        {
            Client client = new Client(clientVM.Id, clientVM.Prenom, clientVM.Nom,
                clientVM.EstClientRegulier, clientVM.DateCreation, clientVM.GateauPreferee);

            _clientDataProvider.ModifierClient(client);
        }

        public void SupprimerClient()
        {
            if (ClientSelectionne == null)
            {
                return;
            }

            _clientDataProvider.SupprimerClient(ClientSelectionne.Id);
            Clients.Remove(ClientSelectionne);
            ClientSelectionne = null;
        }

    }
}
