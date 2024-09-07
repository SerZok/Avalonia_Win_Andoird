using ReactiveUI;
using System.Reactive;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

using AvaloniaApp.Models;
using System.Collections.Generic;

namespace AvaloniaApp.ViewModels;

public class MainViewModel : ViewModelBase
{

    private readonly WeatherService _weatherService;
    private WeatherResponse _weatherData;
    private string _location;

    public ObservableCollection<WeatherResponse> WDatas { get; }
    public MainViewModel()
    {
        _weatherService = new WeatherService();
        FetchWeatherCommand = ReactiveCommand.CreateFromTask(() => FetchWeatherAsync());
        WDatas = new ObservableCollection<WeatherResponse>();
        InitWeatherData();
    }

    private async void  InitWeatherData()
    {
        var locations = new List<string> { "New York", "Москва", "Kazan" };

        foreach (var loc in locations)
        {
            var weatherData = await _weatherService.GetCurrentWeatherAsync(loc);
            if (weatherData != null)
            {
                WDatas.Add(weatherData); // Добавление данных в коллекцию
            }
        }
    }
    public WeatherResponse WeatherData
    {
        get => _weatherData;
        set => this.RaiseAndSetIfChanged(ref _weatherData, value);
    }

    public string Location
    {
        get => _location;
        set => this.RaiseAndSetIfChanged(ref _location, value);
    }

    public ReactiveCommand<Unit, Unit> FetchWeatherCommand { get; }

    private async Task FetchWeatherAsync()
    {
        if (!string.IsNullOrEmpty(Location))
        {
            WeatherData = await _weatherService.GetCurrentWeatherAsync(Location);
        }
    }

}
