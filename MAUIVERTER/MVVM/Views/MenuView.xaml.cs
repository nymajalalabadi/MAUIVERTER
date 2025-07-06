using MAUIVERTER.MVVM.ViewModels;

namespace MAUIVERTER.MVVM.Views;

public partial class MenuView : ContentPage
{
	public MenuView()
	{
		InitializeComponent();
		BindingContext = new MenuViewModel();
    }


    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        var element = (Grid)sender;  

        var option = ((Label)element.Children.LastOrDefault()).Text; 

        var converterViewModel = new ConverterView()
        {
            BindingContext = new ConverterViewModel(option) // Pass the selected option to the ConverterViewModel
        };

        Navigation.PushAsync(converterViewModel); // Navigate to the ConverterView with the selected option
    }

}