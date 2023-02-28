using SupaTest.Helper;
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
    public class Page3ViewModel : BaseViewModel
    {
        public Page3ViewModel(INavigation navigation)
        {
            navigationService = navigation;
            InitCommand = new Command(Initialize);
        }

        #region properties
        INavigation navigationService;
        string _username;
        public string username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }
        #endregion

        #region commands
        public Command InitCommand { get; }
        #endregion

        #region methods
        private async void Initialize()
        {
            IsBusy = true;
            try
            {
                if (Connectivity.NetworkAccess == NetworkAccess.Internet)
                {
                    var user = await SqlDbManager.GetRandomUser();
                    username = user?.Name.Trim();
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
        #endregion

    }
}
