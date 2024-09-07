using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApp.Views
{
    public class MainWindowViewModel : ReactiveObject
    {
        private double _windowWidth;
        public double WindowWidth
        {
            get => _windowWidth;
            set => this.RaiseAndSetIfChanged(ref _windowWidth, value);
        }

        public MainWindowViewModel()
        {
        #if ANDROID
                WindowWidth = 360; // Android значение
        #else
                    WindowWidth = 800; // Windows значение
        #endif
                }
    }

}
