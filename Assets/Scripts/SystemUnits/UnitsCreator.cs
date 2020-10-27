using SystemUnits.Units.Base;
using SystemUnits.Units.BulldozerUnit;
using SystemUnits.Units.ManufactoryUnit;
using SystemUnits.Units.TruckUnit;
using Zenject;

namespace SystemUnits
{
    public sealed class UnitsCreator : IInitializable
    {
        private readonly IFactory<Bulldozer> _factoryBulldozer;
        private readonly IFactory<Manufactory> _factoryManufactory;
        private readonly IFactory<Truck> _factoryTruck;

        public UnitsCreator(IFactory<Bulldozer> factoryBulldozer,
                            IFactory<Manufactory> factoryManufactory,
                            IFactory<Truck> factoryTruck)
        {
            _factoryBulldozer = factoryBulldozer;
            _factoryManufactory = factoryManufactory;
            _factoryTruck = factoryTruck;
        }

        public void Initialize()
        {
            CreateUnits();
        }

        private void CreateUnits()
        {
            CreateUnit(_factoryBulldozer);
            CreateUnit(_factoryManufactory);
            CreateUnit(_factoryTruck);
        }

        private void CreateUnit<TUnit>(IFactory<TUnit> unitFactory)
        where TUnit : IUnit
        {
            unitFactory.Create();
        }
    }
}