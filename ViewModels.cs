using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;

namespace Examen_Mvvm.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private string producto1;

        [ObservableProperty]
        private string producto2;

        [ObservableProperty]
        private string producto3;

        [ObservableProperty]
        private decimal subtotal;

        [ObservableProperty]
        private decimal descuento;

        [ObservableProperty]
        private decimal total;

        [RelayCommand]
        private void Calcular()
        {
            try
            {
                decimal p1 = string.IsNullOrEmpty(Producto1) ? 0 : Convert.ToDecimal(Producto1);
                decimal p2 = string.IsNullOrEmpty(Producto2) ? 0 : Convert.ToDecimal(Producto2);
                decimal p3 = string.IsNullOrEmpty(Producto3) ? 0 : Convert.ToDecimal(Producto3);

                Subtotal = p1 + p2 + p3;

                if (Subtotal >= 1000 && Subtotal <= 4999.99m)
                    Descuento = Subtotal * 0.10m;
                else if (Subtotal >= 5000 && Subtotal <= 9999.99m)
                    Descuento = Subtotal * 0.20m;
                else if (Subtotal >= 10000 && Subtotal <= 19999.99m)
                    Descuento = Subtotal * 0.30m;
                else
                    Descuento = 0;

                Total = Subtotal - Descuento;
            }
            catch
            {
                Subtotal = 0;
                Descuento = 0;
                Total = 0;
            }
        }

        [RelayCommand]
        private void Limpiar()
        {
            Producto1 = string.Empty;
            Producto2 = string.Empty;
            Producto3 = string.Empty;
            Subtotal = 0;
            Descuento = 0;
            Total = 0;
        }
    }
}