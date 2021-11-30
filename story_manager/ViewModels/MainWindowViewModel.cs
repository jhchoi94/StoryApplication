using System.Web.Hosting;
using Prism.Mvvm;
using RestSharp;

namespace story_manager.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private string restContent;
        public string RestContent
        {
            get { return restContent; }
            set { SetProperty(ref restContent, value); }
        }

        public MainWindowViewModel()
        {
            var client = new RestClient("https://api.bithumb.com");

            client.Timeout = -1;
            var request = new RestRequest("/public/ticker/BTC", Method.GET);
            var result = client.Execute(request);
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
                RestContent = result.Content;
            else
                RestContent = result.StatusCode.ToString();
        }
    }
}
