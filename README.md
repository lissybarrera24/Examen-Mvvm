# Examen-Mvvm
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:viewmodel="clr-namespace:Examen_Mvvm.ViewModels"
             x:Class="Examen_Mvvm.MainPage">

    <ContentPage.BindingContext>
        <viewmodel:MainViewModel />
    </ContentPage.BindingContext>

    <ScrollView>
        <VerticalStackLayout Padding="20" Spacing="15">

            <Label Text="Despensa - Cálculo de Descuento"
                   FontSize="20"
                   HorizontalOptions="Center" />

            <!-- Entradas de productos -->
            <Entry Placeholder="Producto 1"
                   Keyboard="Numeric"
                   Text="{Binding Producto1}" />

            <Entry Placeholder="Producto 2"
                   Keyboard="Numeric"
                   Text="{Binding Producto2}" />

            <Entry Placeholder="Producto 3"
                   Keyboard="Numeric"
                   Text="{Binding Producto3}" />

            <!-- Campos calculados -->
            <Entry Placeholder="Subtotal"
                   IsReadOnly="True"
                   Text="{Binding Subtotal}" />

            <Entry Placeholder="Descuento"
                   IsReadOnly="True"
                   Text="{Binding Descuento}" />

            <Entry Placeholder="Total a pagar"
                   IsReadOnly="True"
                   Text="{Binding Total}" />

            <!-- Botones -->
            <Button Text="Calcular"
                    Command="{Binding CalcularCommand}" />

            <Button Text="Limpiar"
                    Command="{Binding LimpiarCommand}" />

        </VerticalStackLayout>
    </ScrollView>
</ContentPage>

App.xaml
<?xml version="1.0" encoding="utf-8" ?>
<Application xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             x:Class="Examen_Mvvm.App">
    <Application.Resources>
        <!-- Recursos de la aplicación -->
    </Application.Resources>
</Application>

App.xaml.cs
using Microsoft.Maui.Controls;

namespace Examen_Mvvm
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }
    }
}


MainPage.xaml

<?xml version="1.0" encoding="utf-8" ?>
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:viewmodel="clr-namespace:Examen_Mvvm.ViewModels"
             x:Class="Examen_Mvvm.MainPage">

    <ContentPage.BindingContext>
        <viewmodel:MainViewModel />
    </ContentPage.BindingContext>

    <ScrollView>
        <VerticalStackLayout Padding="20" Spacing="15">

            <Label Text="Despensa - Cálculo de Descuento"
                   FontSize="20"
                   HorizontalOptions="Center" />

            <!-- Entradas de productos -->
            <Entry Placeholder="Producto 1"
                   Keyboard="Numeric"
                   Text="{Binding Producto1}" />

            <Entry Placeholder="Producto 2"
                   Keyboard="Numeric"
                   Text="{Binding Producto2}" />

            <Entry Placeholder="Producto 3"
                   Keyboard="Numeric"
                   Text="{Binding Producto3}" />

            <!-- Campos calculados -->
            <Entry Placeholder="Subtotal"
                   IsReadOnly="True"
                   Text="{Binding Subtotal}" />

            <Entry Placeholder="Descuento"
                   IsReadOnly="True"
                   Text="{Binding Descuento}" />

            <Entry Placeholder="Total a pagar"
                   IsReadOnly="True"
                   Text="{Binding Total}" />

            <!-- Botones -->
            <Button Text="Calcular"
                    Command="{Binding CalcularCommand}" />

            <Button Text="Limpiar"
                    Command="{Binding LimpiarCommand}" />

        </VerticalStackLayout>
    </ScrollView>
</ContentPage>


ViewModels.cs
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






