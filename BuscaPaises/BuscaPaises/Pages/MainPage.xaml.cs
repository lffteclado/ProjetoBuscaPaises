using BuscaPaises.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace BuscaPaises
{
    public partial class MainPage
    {
        protected CountryService DataService { get; set; }

        public ObservableCollection<CountryViewModel> Countries { get; set; }
        public ICommand CallCommand { get; set; }
        public ICommand StatusCommand { get; set; }
        public ICommand SearchCommand { get; set; }
        public NavigationService NavigationService { get; set; }


        public MainPage()
        {
            Countries = new ObservableCollection<CountryViewModel>();
            DataService = new CountryService();
            CallCommand = new Command (obj => CallCountries());
            StatusCommand = new Command(obj => CallPlain());
            SearchCommand = new Command(obj=> CallSearch());
            NavigationService = new NavigationService(Navigation);

            InitializeComponent();

            List.ItemTapped += (sender, e) =>
            {
                var viewModel = ((ListView)sender).BindingContext as CountryViewModel;

                if (viewModel != null && viewModel.BrowseCommand != null)
                {
                    viewModel.BrowseCommand.Execute(((ListView)sender).BindingContext);
                }
            };
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (Countries.Any())
            {
                return;
            }

            CallCountries();
        }

        private async void CallPlain()
        {
            CallButton.Text = "Carregando...";
            IsBusy = true;
            List.IsVisible = true;

            try
            {
                Response.Text = await DataService.GetData();
                List.IsVisible = false;
                StatusPanel.IsVisible = true;
            }
            catch(Exception ex)
            {

            }
        }
    }

}
