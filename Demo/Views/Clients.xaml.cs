using Demo.Data;
using Demo.Data.Data;
using Demo.ViewModels;
using Demo.ViewModels.Pages;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using System;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Demo.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Clients : Page
    {
        private readonly DemoDbContext _context;

        public MainClientsViewModel ViewModel { get; }

        public Clients()
        {
            _context = new DemoDbContext();
            IClientDataProvider clientDataProvider = new ClientDbDataProvider(_context);

            ViewModel = new MainClientsViewModel(clientDataProvider);
            InitializeComponent();
        }

        // Appelée à chaque arrivée sur la page, y compris au retour du formulaire
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (e.Parameter is ClientViewModel client)
            {
                if (client.Id == 0) // Nouveau client
                {
                    ViewModel.AjouterClient(client);
                }
                else // Client existant
                {
                    ViewModel.ModifierClient(client);
                }
            }

            ViewModel.ChargerDonnees();
        }

        private void btn_AjouterClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(FormulaireClientPage));
        }

        private void btn_ModifierClick(object sender, RoutedEventArgs e)
        {
            if (ViewModel.ClientSelectionne is null)
            {
                return;
            }

            Frame.Navigate(typeof(FormulaireClientPage), ViewModel.ClientSelectionne);
        }

        private async void btn_SupprimerClick(object sender, RoutedEventArgs e)
        {

            if (ViewModel.ClientSelectionne is null)
            {
                return;
            }

            ContentDialog dialogue = new ContentDialog
            {
                Title = "Supprimer le client",
                Content = $"Voulez-vous vraiment supprimer {ViewModel.ClientSelectionne.Prenom} {ViewModel.ClientSelectionne.Nom} ?",
                PrimaryButtonText = "Supprimer",
                CloseButtonText = "Annuler",
                DefaultButton = ContentDialogButton.Close,
                XamlRoot = this.XamlRoot
            };

            ContentDialogResult resultat = await dialogue.ShowAsync();

            if (resultat == ContentDialogResult.Primary)
            {
                ViewModel.SupprimerClient();
            }
        }

        // Fin de vie de l'écran : on libère le contexte
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            _context.Dispose();
        }
    }
}
