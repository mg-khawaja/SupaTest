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
    public class Page2ViewModel : BaseViewModel
    {
        public Page2ViewModel(INavigation navigation, string network)
        {
            _network = network;
            navigationService = navigation;
            SubmitCommand = new Command(SubmitBtnClicked);
        }

        #region properties
        INavigation navigationService;
        string _code;
        public string code
        {
            get { return _code; }
            set { SetProperty(ref _code, value); }
        }
        string _network = "network";
        #endregion

        #region commands
        public Command SubmitCommand { get; }
        #endregion

        #region methods
        private async void SubmitBtnClicked()
        {
            try
            {
                var exists = await SqlDbManager.VerifyNetworkCode(new Models.NetworkCode()
                {
                    Code = code,
                    Network = _network,
                });
                // go to page 3 if network code exists
                if (exists)
                {
                    await navigationService.PushAsync(new Page3());
                }
                else
                {
                    await (Application.Current as App).MainPage.DisplayAlert("Error", "Code mismatched!", "OK");
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
        }
        #endregion

    }
}
