namespace VasarMAUI;

public partial class MainPage : ContentPage
{
    private readonly MainPageViewModel _viewModel;

    public MainPage()
    {
        InitializeComponent();
        _viewModel = new MainPageViewModel();
        BindingContext = _viewModel;
    }

    private void ContentPage_Appearing(object sender, EventArgs e)
    {
        _viewModel.UpdateMessage();
    }
}

