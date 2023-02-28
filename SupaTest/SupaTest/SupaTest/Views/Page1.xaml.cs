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
    public partial class Page1 : ContentPage
    {
        Page1ViewModel viewModel;
        public Page1()
        {
            viewModel = new Page1ViewModel(Navigation);
            BindingContext = viewModel;
            InitializeComponent();
            viewModel.InitCommand.Execute(null);
        }
    }
}