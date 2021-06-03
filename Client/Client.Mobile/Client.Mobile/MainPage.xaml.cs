using Client.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Client.Mobile
{
    public partial class MainPage : ContentPage
    {
        MainPageViewModel _viewModel;
        public MainPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new MainPageViewModel();
        }

    }
}
