using UnityEngine;
using Zenject;

namespace SystemUnits.Units.BulldozerUnit
{
    public sealed class BulldozerFactory : IFactory<Bulldozer>
    {
        private readonly BulldozerUnitConfiguration.Configuration _bulldozerUnitConfiguration;
        private readonly UnitsManger _unitsManger;

        public BulldozerFactory(BulldozerUnitConfiguration.Configuration bulldozerUnitConfiguration,
                                UnitsManger unitsManger)
        {
            _bulldozerUnitConfiguration = bulldozerUnitConfiguration;
            _unitsManger = unitsManger;
        }

        public Bulldozer Create()
        {
            var bulldozer = Object.Instantiate(_bulldozerUnitConfiguration.Prefab);
            _unitsManger.Add(bulldozer);

            bulldozer.Initialization(_bulldozerUnitConfiguration);
            bulldozer.gameObject.SetActive(true);

            return bulldozer;
        }
    }
}