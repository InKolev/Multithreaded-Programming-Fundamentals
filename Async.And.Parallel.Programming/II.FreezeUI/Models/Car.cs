using Async.Introduction.Infrastructure;

namespace Async.Introduction.Models
{
    public class Car
    {
        public string Name { get; set; }

        public string Origin { get; set; }

        public double MilesPerGalon { get; set; }

        public double Displacement { get; set; }

        public double Acceleration { get; set; }

        public double Horsepower { get; set; }

        public double Weight { get; set; }

        public int Cylinders { get; set; }

        public int Year { get; set; }

        public static Car Parse(string carData)
        {
            var carParams = carData.Split(';');

            return new Car
            {
                Name = carParams[0],
                MilesPerGalon = carParams[1].ToDouble(),
                Cylinders = carParams[2].ToInteger(),
                Displacement = carParams[3].ToDouble(),
                Horsepower = carParams[4].ToDouble(),
                Weight = carParams[5].ToDouble(),
                Acceleration = carParams[6].ToDouble(),
                Year = carParams[7].ToInteger(),
                Origin = carParams[8]
            };
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.Year} - {this.Horsepower} - {this.Weight}";
        }
    }
}
