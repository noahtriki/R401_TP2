using ClientConvertisseurV3.Models;
using ClientConvertisseurV3.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientConvertisseurV3.ViewModels
{
    public class ConvertisseurEuroViewModel : ObservableObject
    {
        public IRelayCommand BtnSetConversion { get; }
        public ConvertisseurEuroViewModel()
        {
            GetDataOnLoadAsync();
            //Boutons
            BtnSetConversion = new RelayCommand(ActionSetConversion);
        }

        public ConvertisseurEuroViewModel(ObservableCollection<Devise> lesDevises, double montant, double resultat, Devise selectedDevise)
        {
            this.lesDevises = lesDevises;
            this.montant = montant;
            this.resultat = resultat;
            this.selectedDevise = selectedDevise;
        }

        private ObservableCollection<Devise> lesDevises;
        private double montant;
        private double resultat;
        private Devise selectedDevise;

        public ObservableCollection<Devise> LesDevises
        {
            get
            {
                return lesDevises;
            }

            set
            {
                lesDevises = value;
                OnPropertyChanged();

            }
        }

        public double Montant
        {
            get
            {
                return montant;
            }

            set
            {
                montant = value;
                OnPropertyChanged();

            }
        }

        public double Resultat
        {
            get
            {
                return resultat;
            }

            set
            {
                resultat = value;
                OnPropertyChanged();

            }
        }

        public Devise SelectedDevise
        {
            get
            {
                return selectedDevise;
            }

            set
            {
                selectedDevise = value;
                OnPropertyChanged();

            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;



        public async void GetDataOnLoadAsync()
        {
            WSService service = new WSService("https://localhost:7155/api/");
            List<Devise> result = await service.GetDevisesAsync("devises");
            if (result == null)
            {
                ErrorMethod("Erreur", "Il n y a pas de liste");
            }
            else
                LesDevises = new ObservableCollection<Devise>(result);
        }
        protected void OnPropertyChanged(string name)
        {

            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        public void ActionSetConversion()
        {
            if (selectedDevise == null)
            {
                ErrorMethod("Erreur", "Vous n'avez pas selecctionée de Devise");
            }
            else
                Resultat = SelectedDevise.Taux * Montant;
        }
        private async void ErrorMethod(string title, string content)
        {
            ContentDialog maContentDialog = new ContentDialog
            {
                Title = title,
                Content = content,
                CloseButtonText = "Ok"
            };
            maContentDialog.XamlRoot = App.MainRoot.XamlRoot;
            ContentDialogResult result = await maContentDialog.ShowAsync();
        }

    }
}
