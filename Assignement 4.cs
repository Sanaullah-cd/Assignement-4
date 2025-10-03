using System;

namespace FactoryMethodDemo
{
    // ===============================
    // 1. Common Vehicle Interface
    // ===============================
    public interface IVehicle
    {
        void Drive();
        void Refuel();
    }

    // ===============================
    // 2. Concrete Vehicles
    // ===============================
    public class Car : IVehicle
    {
        private string Brand;
        private string Model;
        private string FuelType;

        public Car(string brand, string model, string fuelType)
        {
            Brand = brand;
            Model = model;
            FuelType = fuelType;
        }

        public void Drive()
        {
            Console.WriteLine($"Driving car {Brand} {Model} with {FuelType}.");
        }

        public void Refuel()
        {
            Console.WriteLine($"Refueling {FuelType} for car {Brand} {Model}.");
        }
    }

    public class Motorcycle : IVehicle
    {
        private string Type;
        private int EngineCapacity;

        public Motorcycle(string type, int engineCapacity)
        {
            Type = type;
            EngineCapacity = engineCapacity;
        }

        public void Drive()
        {
            Console.WriteLine($"Riding {Type} motorcycle with {EngineCapacity}cc engine.");
        }

        public void Refuel()
        {
            Console.WriteLine($"Refueling motorcycle ({Type}, {EngineCapacity}cc).");
        }
    }

    public class Truck : IVehicle
    {
        private double Capacity;
        private int Axles;

        public Truck(double capacity, int axles)
        {
            Capacity = capacity;
            Axles = axles;
        }

        public void Drive()
        {
            Console.WriteLine($"Driving truck with capacity {Capacity} tons and {Axles} axles.");
        }

        public void Refuel()
        {
            Console.WriteLine($"Refueling diesel truck ({Capacity} tons, {Axles} axles).");
        }
    }

    // New vehicle type: Bus
    public class Bus : IVehicle
    {
        private int PassengerCapacity;
        private string Route;

        public Bus(int passengerCapacity, string route)
        {
            PassengerCapacity = passengerCapacity;
            Route = route;
        }

        public void Drive()
        {
            Console.WriteLine($"Bus with {PassengerCapacity} seats is driving on route {Route}.");
        }

        public void Refuel()
        {
            Console.WriteLine($"Refueling bus with {PassengerCapacity} seats on route {Route}.");
        }
    }

    // New vehicle type: Scooter
    public class Scooter : IVehicle
    {
        private string Type;
        private bool IsElectric;

        public Scooter(string type, bool isElectric)
        {
            Type = type;
            IsElectric = isElectric;
        }

        public void Drive()
        {
            string engine = IsElectric ? "electric motor" : "fuel engine";
            Console.WriteLine($"Scooter ({Type}) is moving with {engine}.");
        }

        public void Refuel()
        {
            if (IsElectric)
                Console.WriteLine($"Charging electric scooter ({Type}).");
            else
                Console.WriteLine($"Refueling fuel scooter ({Type}).");
        }
    }

    // ===============================
    // 3. Abstract Factory
    // ===============================
    public abstract class VehicleFactory
    {
        public abstract IVehicle CreateVehicle();
    }

    // ===============================
    // 4. Concrete Factories
    // ===============================
    public class CarFactory : VehicleFactory
    {
        private string Brand;
        private string Model;
        private string FuelType;

        public CarFactory(string brand, string model, string fuelType)
        {
            Brand = brand;
            Model = model;
            FuelType = fuelType;
        }

        public override IVehicle CreateVehicle() => new Car(Brand, Model, FuelType);
    }

    public class MotorcycleFactory : VehicleFactory
    {
        private string Type;
        private int EngineCapacity;

        public MotorcycleFactory(string type, int engineCapacity)
        {
            Type = type;
            EngineCapacity = engineCapacity;
        }

        public override IVehicle CreateVehicle() => new Motorcycle(Type, EngineCapacity);
    }

    public class TruckFactory : VehicleFactory
    {
        private double Capacity;
        private int Axles;

        public TruckFactory(double capacity, int axles)
        {
            Capacity = capacity;
            Axles = axles;
        }

        public override IVehicle CreateVehicle() => new Truck(Capacity, Axles);
    }

    public class BusFactory : VehicleFactory
    {
        private int PassengerCapacity;
        private string Route;

        public BusFactory(int passengerCapacity, string route)
        {
            PassengerCapacity = passengerCapacity;
            Route = route;
        }

        public override IVehicle CreateVehicle() => new Bus(PassengerCapacity, Route);
    }

    public class ScooterFactory : VehicleFactory
    {
        private string Type;
        private bool IsElectric;

        public ScooterFactory(string type, bool isElectric)
        {
            Type = type;
            IsElectric = isElectric;
        }

        public override IVehicle CreateVehicle() => new Scooter(Type, IsElectric);
    }

    // ===============================
    // 5. User Demo
    // ===============================
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Vehicle Factory Demo ===");

            // Example 1: Car
            VehicleFactory carFactory = new CarFactory("Toyota", "Camry", "Petrol");
            IVehicle car = carFactory.CreateVehicle();
            car.Drive();
            car.Refuel();

            Console.WriteLine();

            // Example 2: Motorcycle
            VehicleFactory motorcycleFactory = new MotorcycleFactory("Sport", 600);
            IVehicle motorcycle = motorcycleFactory.CreateVehicle();
            motorcycle.Drive();
            motorcycle.Refuel();

            Console.WriteLine();

            // Example 3: Truck
            VehicleFactory truckFactory = new TruckFactory(12, 4);
            IVehicle truck = truckFactory.CreateVehicle();
            truck.Drive();
            truck.Refuel();

            Console.WriteLine();

            // Example 4: Bus
            VehicleFactory busFactory = new BusFactory(50, "Route A1");
            IVehicle bus = busFactory.CreateVehicle();
            bus.Drive();
            bus.Refuel();

            Console.WriteLine();

            // Example 5: Scooter
            VehicleFactory scooterFactory = new ScooterFactory("City", true);
            IVehicle scooter = scooterFactory.CreateVehicle();
            scooter.Drive();
            scooter.Refuel();
        }
    }
}
