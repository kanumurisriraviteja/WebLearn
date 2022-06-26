using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
 
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        List<Car> car = new List<Car>();
       public CarController()
        {
            car.Add(new Car() { Model = 1, Type = "Tata", Color = "W" });
            car.Add(new Car() { Model = 2, Type = "Porsche", Color = "B" });
            car.Add(new Car() { Model = 3, Type = "VW", Color = "G" });
            car.Add(new Car() { Model = 4, Type = "GE", Color = "R" });
        }

        [HttpGet]
        public IEnumerable<Car> GetAllCar()
        {
            return car;
        }

        [HttpGet]
        public Car GetSpecificCar(int id)
        {
            return car.Find(x => x.Model == id);
        }

        [HttpPost]
        public IEnumerable<Car> PostCar(Car newCar)
        {
            car.Add(new Car() { Model = newCar.Model, Type = newCar.Type, Color = newCar.Color });
            return car;

        }

        [HttpPut]
        public IEnumerable<Car> PutCar(Car newCar)
        {
            DeleteCar(newCar.Model);
            PostCar(newCar);
            return car.OrderBy(x => x.Model);
        }

        [HttpDelete("{id}")]
        public IEnumerable<Car> DeleteCar(int id)
        {
            car.RemoveAll(x => x.Model == id);
            return car;
        }
    }
}
