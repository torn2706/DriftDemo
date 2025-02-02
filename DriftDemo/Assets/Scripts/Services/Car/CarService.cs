﻿using Data;
using System.Collections.Generic;

namespace Services
{
    public class CarService : ICarService
    {
        private Dictionary<CarName, PurchasedCar> _allCars;
        private const string _car1Path = "Cars/DefaultCar";
        private const string _car2Path = "Cars/Car2";
        private const int _car1Cost = 100;
        private const int _car2Cost = 500;

        public int AllCarsCount => _allCars.Count;

        public CarService()
        {
            _allCars = new Dictionary<CarName, PurchasedCar>()
            {
                [CarName.Car1] = new PurchasedCar(_car1Path, _car1Cost, name: CarName.Car1, withSpoiler: false),
                [CarName.Car2] = new PurchasedCar(_car2Path, _car2Cost, name: CarName.Car2, withSpoiler: false)
            };
        }

        public PurchasedCar GetPurchasedCar(CarName carName) => _allCars[carName];
    }
}