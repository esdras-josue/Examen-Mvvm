using Examen_Mvvm.ViewModel;
using Microsoft.Maui.Controls;

namespace Examen_Mvvm
{
    public partial class MainPage : ContentPage
    {
        private MainPageViewModel viewModel;
        public MainPage()
        {
            InitializeComponent();
            viewModel = new MainPageViewModel();
            BindingContext = viewModel;
        }

        private void Calcular(object sender, EventArgs e)
        {
            viewModel.CalcularProducto();
        }

        private void Limpiar(object sender, EventArgs e)
        {
            viewModel.LimpiarProducto();
        }
    }

}
