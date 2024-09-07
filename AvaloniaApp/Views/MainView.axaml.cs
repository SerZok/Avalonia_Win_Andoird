using Avalonia.Controls;
using AvaloniaApp.ViewModels;

namespace AvaloniaApp.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
        DataContext = new MainViewModel();
    }
}
