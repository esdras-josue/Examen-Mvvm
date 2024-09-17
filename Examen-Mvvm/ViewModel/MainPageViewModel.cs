using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;


namespace Examen_Mvvm.ViewModel
{
    public partial class MainPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private string productoUno;

        [ObservableProperty]
        private string productoDos;

        [ObservableProperty]
        private string productoTres;

        [ObservableProperty]
        private string subTotal;

        [ObservableProperty]
        private string descuento;

        [ObservableProperty]
        private string totalPagar;

        [ObservableProperty]
        private string mensajerror;

        [RelayCommand]
        public void CalcularProducto()
        {
            if(string.IsNullOrWhiteSpace(productoUno) || string.IsNullOrWhiteSpace(productoDos)
               || string.IsNullOrWhiteSpace(productoTres)) 
            {
                Mensajerror = "Todos los campos deben ser llenados.";
                return;
            }

            if (!double.TryParse(productoUno, out double producto1) || producto1 < 0 ||
                !double.TryParse(productoDos, out double producto2) || producto2 < 0 ||
                !double.TryParse(productoTres, out double producto3) || producto3 < 0)
            {
                Mensajerror = "Ingrese valores numericos validos o mayores o iguales a cero.";
                return;
            }

                Mensajerror = "";
            
                double suma = producto1 + producto2 + producto3;
                SubTotal = suma.ToString("F2") + " LPS";

                double aplicarDescuento = 0;

                if(suma >= 10000)
                {
                    aplicarDescuento = suma * 0.30;
                }
                else if(suma >= 5000)
                {
                    aplicarDescuento = suma * 0.20;
                }
                else if(suma >= 100)
                {
                    aplicarDescuento = suma * 0.10;
                }

                
                Descuento = aplicarDescuento.ToString("F2") + " LPS";
                TotalPagar = (suma - aplicarDescuento).ToString("F2") + " LPS";   
        }

        [RelayCommand]
        public void LimpiarProducto()
        {
            ProductoUno = ProductoDos = ProductoTres = "";
            SubTotal = Descuento = TotalPagar = "";
        }
    }
}
