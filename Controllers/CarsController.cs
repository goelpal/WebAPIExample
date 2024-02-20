using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;
using WebAPIExample.Models;

namespace WebAPIExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        /* Code Without Database connectivity
        private static List<Car> cars = new List<Car>
        {
            new Car { Id = 1,Brand = "BMW", CarModel="XL", Year=2010},
            new Car { Id = 2,Brand = "Volvo", CarModel="V90", Year=2011},
            new Car { Id = 3,Brand = "SAAB", CarModel="900", Year=2020}
        };

        [HttpGet("GetCars")]
        public IActionResult Get() //Get all the cars
        {
            return Ok(cars);
        }

        [HttpGet("GetCar/{id}")]
        public IActionResult Get(int id) //Get car by Id
        {
            Car car = cars.Find(x => x.Id == id);
            if(car == null)
            {
                return BadRequest("Car not found.");
            }
            else
            return Ok(car);
        }

        [HttpPost("CreateCar")]
        public IActionResult Post(Car request)
        {
            cars.Add(request);
            return Ok(cars);
        }

        [HttpPut("UpdateCar")]
        public IActionResult Put(Car request)
        {
            Car car = cars.Find(x => x.Id == request.Id);

            if (car == null)
                return BadRequest("Car Not Found");
            else
            {
                car.Id = request.Id;
                car.Brand = request.Brand;
                car.CarModel = request.CarModel;
                car.Year = request.Year;
                return Ok(car);
            }         
         }

        [HttpDelete("DeleteCars/{id}")]
        public IActionResult Delete(int id) 
        {
            Car car = cars.FirstOrDefault(x => x.Id == id);
            if (car == null)
                return BadRequest("Car Not Found");
            else
            {
                cars.Remove(car);
                return Ok(cars);
            }
        }
        */

        //Code with Database Connectivity

        private readonly DataContext _dataContext;

        //Constructor
        public CarsController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        //GET METHOD
        [HttpGet]
        public IActionResult Get()
        {
            if(_dataContext == null)
                return NotFound();
            return Ok(_dataContext.Cars.ToList());
        }

        //Get specific information
        [HttpGet("/{id}")]
        public IActionResult Get(int id)
        {
            if (_dataContext == null)
                return NotFound();
            else
            {
                return Ok(_dataContext.Cars.FirstOrDefault(x => x.Id == id));
            }

        }

        [HttpPost]
        public IActionResult Post(Car car)
        {
            _dataContext.Cars.Add(car);
            _dataContext.SaveChanges();
            return Ok(_dataContext.Cars.ToList());
        }

        [HttpPut]
        public IActionResult Put(Car request)
        {
            var car = _dataContext.Cars.FirstOrDefault(x => x.Id == request.Id);
            if (car == null)
                return NotFound();
            car.Id = request.Id;
            car.Brand = request.Brand;
            car.CarModel = request.CarModel;
            car.Year = request.Year;
            _dataContext.SaveChanges();
            return Ok(_dataContext.Cars.ToList());
        }

        [HttpDelete]
        public IActionResult Delete(int id) 
        {
            var car = _dataContext.Cars.Find(id);
            if(car == null)
                return NotFound();
            _dataContext.Cars.Remove(car);
            _dataContext.SaveChanges();
            return Ok(_dataContext.Cars.ToList());
        }

    }
}
