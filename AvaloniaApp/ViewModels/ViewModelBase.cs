using ReactiveUI;

namespace AvaloniaApp.ViewModels;

public class ViewModelBase : ReactiveObject
{
    private double _windowWidth;
    public double WindowWidth
    {
        get => _windowWidth;
        set => this.RaiseAndSetIfChanged(ref _windowWidth, value);
    }

    public ViewModelBase()
    {
    #if ANDROID
                    WindowWidth = 360; // Android значение
    #else
            WindowWidth = 800; // Windows значение
    #endif
    }
}
