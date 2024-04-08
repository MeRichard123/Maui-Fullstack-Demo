using CommunityToolkit.Mvvm.ComponentModel;
using FullStackTest.Services;

namespace FullStackTest.ViewModels
{
    public class ViewModelBase : ObservableObject
    {
        private readonly IHttpService _httpService;

        // Dependency Injection
        public ViewModelBase(IHttpService httpService)
        {
            _httpService = httpService;
        }

        protected IHttpService HttpService => _httpService;
    }
}
