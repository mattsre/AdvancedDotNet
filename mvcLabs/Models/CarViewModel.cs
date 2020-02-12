using System.Collections.Generic;

namespace mvcLabs.Models
{
    public class CarViewModel
    {
        public List<Car> Cars = new List<Car>();
        public CarViewModel(List<Car> cars)
        {
            Cars = cars;
        }
    }
}