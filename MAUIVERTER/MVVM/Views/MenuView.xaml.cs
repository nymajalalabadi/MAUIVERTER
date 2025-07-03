using MAUIVERTER.MVVM.ViewModels;

namespace MAUIVERTER.MVVM.Views;

public partial class MenuView : ContentPage
{
	public MenuView()
	{
		InitializeComponent();
		BindingContext = new MenuViewModel();
    }

    private void ContentPage_NavigatingFrom(object sender, NavigatingFromEventArgs e)
    {

    }
}