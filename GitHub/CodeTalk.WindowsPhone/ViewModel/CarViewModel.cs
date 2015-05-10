using CodeTalk.WindowsPhone.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CodeTalk.WindowsPhone.ViewModel
{
    public class CarViewModel
    {

        private ObservableCollection<Car> cars;

        public ObservableCollection<Car> Cars
        {
            get { return cars; }
            set { cars = value; }
        }

        public CarViewModel()
        {
        }
        
        public async Task InitializeData()
        {
            var client = new HttpClient();
            string jsonData = await client.GetStringAsync("http://www.codetalk.de/cars.json");
            var result = JsonConvert.DeserializeObject<List<Car>>(jsonData);

            Cars = new ObservableCollection<Car>(result);
        }
    }
}
