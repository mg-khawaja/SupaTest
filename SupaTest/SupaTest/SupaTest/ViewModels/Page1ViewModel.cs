using SupaTest.Helper;
using SupaTest.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SupaTest.ViewModels
{
    public class Page1ViewModel : BaseViewModel
    {
        public Page1ViewModel(INavigation navigation)
        {
            navigationService = navigation;
            InitCommand = new Command(Initialize);
            NextCommand = new Command(NextBtnClicked);
        }

        #region properties
        INavigation navigationService;
        bool _networkCodeCreated;
        string _code;
        public string code
        {
            get { return _code; }
            set { SetProperty(ref _code, value); }
        }
        string _network = "network";
        public string network
        {
            get { return _network; }
            set { SetProperty(ref _network, value); }
        }
        #endregion

        #region commands
        public Command InitCommand { get; }
        public Command NextCommand { get; }
        #endregion

        #region methods
        private async void Initialize()
        {
            IsBusy = true;
            try
            {
                if (Connectivity.NetworkAccess == NetworkAccess.Internet)
                {
                    //returns ssid if ssid is not hidden or not allowed to access. otherwise ip address will be returned
                    network = DependencyService.Get<INetWorkInfo>().getSSID();
                    
                    var guid = Guid.NewGuid().ToString();
                    code = guid.Substring(0, 4);

                    await SqlDbManager.Initialise();

                    _networkCodeCreated = await SqlDbManager.CreateNetworkCode(new Models.NetworkCode()
                    {
                        Code = code,
                        Network = network,
                    });
                }
                else
                {
                    await (Application.Current as App).MainPage.DisplayAlert("Connection Error", "There is no internet connection!", "OK");
                }
            }
            catch (SqlException ex)
            {
                await (Application.Current as App).MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
            catch (Exception ex)
            {
                await (Application.Current as App).MainPage.DisplayAlert("Error", "Something went wrong!", "OK");
            }
            IsBusy = false;
        }
        private async void NextBtnClicked()
        {
            if(_networkCodeCreated)
            await navigationService.PushAsync(new Page2(network));
        }
        #endregion

    }
}
