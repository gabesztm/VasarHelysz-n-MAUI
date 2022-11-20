namespace VasarMAUI;

public partial class NextEvents : ContentPage
{
    private readonly NextEventsViewModel _viewModel;
    public NextEvents()
    {
        InitializeComponent();
        _viewModel = new NextEventsViewModel();
        BindingContext = _viewModel;
    }

    private void ContentPage_Appearing(object sender, EventArgs e)
    {
        _viewModel.UpdateDates();
    }
}