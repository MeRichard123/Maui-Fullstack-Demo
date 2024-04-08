using FullStackTest.Services;
using FullStackTest.ViewModels;
using Microcharts;
using SkiaSharp;

namespace FullStackTest
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        ChartEntry[] entries = new[]
{
            new ChartEntry(20)
            {
                Label = "Mon",
                ValueLabel = "112",
                Color = SKColor.Parse("#2c3e50")
            },
            new ChartEntry(100)
            {
                Label = "Tue",
                ValueLabel = "648",
                Color = SKColor.Parse("#77d065")
            },
            new ChartEntry(200)
            {
                Label = "Wed",
                ValueLabel = "428",
                Color = SKColor.Parse("#b455b6")
            },
            new ChartEntry(45)
            {
                Label = "Thu",
                ValueLabel = "214",
                Color = SKColor.Parse("#3498db")
            },
                        new ChartEntry(67)
            {
                Label = "Fri",
                ValueLabel = "214",
                Color = SKColor.Parse("#3498db")
            },
                                    new ChartEntry(89)
            {
                Label = "Sat",
                ValueLabel = "214",
                Color = SKColor.Parse("#3498db")
            },
                                                new ChartEntry(100)
            {
                Label = "Sun",
                ValueLabel = "214",
                Color = SKColor.Parse("#3498db")
            }
        };

        public MainPage(IHttpService httpService)
        {
            InitializeComponent();

            BindingContext = new ProductViewModel(httpService);

            chartView.Chart = new LineChart { 
                Entries = entries,
                LabelTextSize = 35,
                LabelOrientation = Orientation.Horizontal,
            };
          
        }
    }

}
