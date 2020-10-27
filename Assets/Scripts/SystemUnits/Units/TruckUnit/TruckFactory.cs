using UnityEngine;
using Zenject;

namespace SystemUnits.Units.TruckUnit
{
    public sealed class TruckFactory : IFactory<Truck>
    {
        private readonly TruckUnitConfiguration.Configuration _truckUnitConfiguration;
        private readonly UnitsManger _unitsManger;
        public TruckFactory(TruckUnitConfiguration.Configuration truckUnitConfiguration,
                            UnitsManger unitsManger)
        {
            _truckUnitConfiguration = truckUnitConfiguration;
            _unitsManger = unitsManger;
        }

        public Truck Create()
        {
            var manufactory = Object.Instantiate(_truckUnitConfiguration.Prefab);
            _unitsManger.Add(manufactory);

            manufactory.Initialize(_truckUnitConfiguration);
            manufactory.gameObject.SetActive(true);
            
            return manufactory;
        }
    }
}