using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FullStackTest.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace FullStackTest.ViewModels
{
    public partial class ProductViewModel : ViewModelBase
    {

        private ObservableCollection<Product> products;
        private decimal totalPrice;

        public ObservableCollection<Product> Products
        {
            get => products;
            set => SetProperty(ref products, value);
        }

        public ProductViewModel(IHttpService httpService) : base(httpService)
        {
            // Initialize the collection with some sample data
            products = new ObservableCollection<Product>();
            AddProductData();
            CalculateTotalCommand = new Command(CalculateTotal);
            GetPizzasCommand = new Command(GetPizza);
        }

        public decimal TotalPrice
        {
            get => totalPrice;
            set => SetProperty(ref totalPrice, value);
        }

        // Command Pattern
        public ICommand CalculateTotalCommand { get; }
        public ICommand GetPizzasCommand { get; }

        private void AddProductData()
        {
            for (int i = 0; i < 10; i++)
            {
                products.Add(new Product { ID = i, Name = $"Product {i}", Price = 19.99m + i * 10 });

            }
        }
        private void CalculateTotal()
        {
            TotalPrice = Products.Sum(product => product.Price);
        }

        public async void GetPizza()
        {
            Console.WriteLine("Running command");
            
                List<Product> data = await HttpService.GetPizzas();
            
        }
    }
}
