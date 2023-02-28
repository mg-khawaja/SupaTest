using SupaTest.Helper;
using SupaTest.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SupaTest.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page2 : ContentPage
    {
        Page2ViewModel viewModel;
        public Page2(string network)
        {
            viewModel = new Page2ViewModel(Navigation, network);
            BindingContext = viewModel;
            InitializeComponent();
        }
    }
}