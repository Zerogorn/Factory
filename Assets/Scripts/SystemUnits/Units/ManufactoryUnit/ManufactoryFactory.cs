using Models;
using UnityEngine;
using Zenject;

namespace SystemUnits.Units.ManufactoryUnit
{
    public sealed class ManufactoryFactory : IFactory<Manufactory>
    {
        private readonly ManufactoryUnitConfiguration.Configuration _manufactoryUnitConfiguration;
        private readonly DesignModel _designModel;
        private readonly UnitsManger _unitsManger;

        public ManufactoryFactory(ManufactoryUnitConfiguration.Configuration manufactoryUnitConfiguration,
                                  DesignModel designModel,
                                  UnitsManger unitsManger)
        {
            _manufactoryUnitConfiguration = manufactoryUnitConfiguration;
            _designModel = designModel;
            _unitsManger = unitsManger;
        }

        public Manufactory Create()
        {
            var manufactory = Object.Instantiate(_manufactoryUnitConfiguration.PrefabsContainer);

            _unitsManger.Add(manufactory);

            var manufactoryDefault = Object.Instantiate(_manufactoryUnitConfiguration.Prefabs[0], manufactory.transform);
            manufactoryDefault.gameObject.SetActive(true);

            manufactory.Initialize(manufactoryDefault, _manufactoryUnitConfiguration, _designModel);
            manufactory.gameObject.SetActive(true);

            return manufactory;
        }
    }
}