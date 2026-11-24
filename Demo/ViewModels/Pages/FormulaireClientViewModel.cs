using Demo.Data.Models;
using Demo.Data.Models.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo.ViewModels.Pages
{
    public class FormulaireClientViewModel : BaseViewModel
    {
        // Un Id à 0 signifie un nouveau client, sinon c'est une modification
        public string Titre
        {
            get
            {
                if (ClientEdit.Id == 0)
                {
                    return "Ajouter un client";
                }
                else
                {
                    return "Modifier un client";
                }
            }
        }

        // Valeurs de l'enum pour le ComboBox
        public List<TypeGateau> GateauOptions { get; } =
            Enum.GetValues(typeof(TypeGateau)).Cast<TypeGateau>().ToList();

        private ClientViewModel _clientEdit;

        public ClientViewModel ClientEdit
        {
            get { return _clientEdit; }
            set
            {
                if (_clientEdit != value)
                {
                    _clientEdit = value;
                    RaisePropertyChanged();
                }
            }
        }

        // Ajout : formulaire vide
        public FormulaireClientViewModel()
        {
            _clientEdit = new ClientViewModel(new Client());
        }

        // Modification : formulaire prérempli
        public FormulaireClientViewModel(ClientViewModel clientViewModel)
        {
            _clientEdit = clientViewModel;
        }
    }

}

