using Demo.Data.Models;
using Demo.Data.Models.Types;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Demo.ViewModels
{
    public class ClientViewModel : ValidableViewModel
    {
        private Client _client;

        public ClientViewModel(Client client)
        {
            _client = client;

            _errors.Add(nameof(Prenom), new ObservableCollection<ValidationResult>());
            _errors.Add(nameof(Nom), new ObservableCollection<ValidationResult>());

            Validate(Prenom, nameof(Prenom));
            Validate(Nom, nameof(Nom));

        }

        public int Id
        {
            get => _client.Id;
        }

        [Required(ErrorMessage = "Le prénom est requis")]
        [MinLength(2, ErrorMessage = "Le prénom doit comprendre au moins 2 caractères.")]
        [MaxLength(254, ErrorMessage = "Le prénom doit comprendre moins de 255 caractères.")]
        [DeniedValues(["Bob", "Ginette"],
                        ErrorMessage = "Soyez une personne plus créative svp.")]
        [RegularExpression(@"[A-Z].*",
                        ErrorMessage = "Le prénom doit commencer par une majuscule.")]
        public string Prenom
        {
            get => _client.Prenom;
            set
            {
                if (_client.Prenom != value && Validate(value))
                {
                    _client.Prenom = value;
                    RaisePropertyChanged();
                }
            }
        }

        [Required(ErrorMessage = "Le nom est requis")]
        [MinLength(2, ErrorMessage = "Le nom doit comprendre au moins 2 caractères.")]
        [MaxLength(254, ErrorMessage = "Le nom doit comprendre moins de 255 caractères.")]
        [DeniedValues(["Bob", "Ginette"],
                    ErrorMessage = "Soyez une personne plus créative svp.")]
        [RegularExpression(@"[A-Z].*",
                    ErrorMessage = "Le prénom doit commencer par une majuscule.")]
        public string Nom
        {
            get => _client.Nom;
            set
            {
                if (_client.Nom != value && Validate(value))
                {
                    _client.Nom = value;
                    RaisePropertyChanged();
                }
            }
        }

        public bool EstClientRegulier
        {
            get => _client.EstClientRegulier;
            set
            {
                if (_client.EstClientRegulier != value)
                {
                    _client.EstClientRegulier = value;
                    RaisePropertyChanged();
                }
            }
        }

        public DateOnly DateCreation
        {
            get => _client.DateCreation;
        }

        public TypeGateau GateauPreferee
        {
            get => _client.GateauPreferee;
            set
            {
                if (_client.GateauPreferee != value)
                {
                    _client.GateauPreferee = value;
                    RaisePropertyChanged();
                }
            }
        }

    }
}
