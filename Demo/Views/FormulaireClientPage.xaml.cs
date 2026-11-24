using Demo.Data.Models;
using Demo.ViewModels;
using Demo.ViewModels.Pages;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Demo.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FormulaireClientPage : Page
    {
        public FormulaireClientViewModel ViewModel { get; private set; }

        public FormulaireClientPage()
        {
            ViewModel = new FormulaireClientViewModel();

            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (e.Parameter is ClientViewModel clientAModifier)
            {
                // On travaille sur une copie : si l'utilisateur annule,
                // le client affiché dans la liste n'est pas modifié.
                Client copie = new Client(clientAModifier.Id, clientAModifier.Prenom, clientAModifier.Nom,
                    clientAModifier.EstClientRegulier, clientAModifier.DateCreation, clientAModifier.GateauPreferee);

                ViewModel = new FormulaireClientViewModel(new ClientViewModel(copie));
            }
            else
            {
                ViewModel = new FormulaireClientViewModel();
            }
        }

        private void btn_EnregistrerClick(object sender, RoutedEventArgs e)
        {
            if (ViewModel.ClientEdit.EstValide)
            {
                Frame.Navigate(typeof(Clients), ViewModel.ClientEdit);
            }
        }

        private void btn_AnnulerClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Clients));
        }

    }
}
