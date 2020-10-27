using System;
using System.Collections.Generic;
using SystemUnits.Units.Base;
using UnityEngine;

namespace SystemUnits.Units.ManufactoryUnit
{
    [CreateAssetMenu(fileName = nameof(ManufactoryUnitConfiguration), menuName = nameof(BaseUnitConfiguration) + "/" + nameof(ManufactoryUnitConfiguration))]
    public sealed class ManufactoryUnitConfiguration : BaseUnitConfiguration
    {
        [SerializeField]
        private Configuration _factoryUnitConfiguration = null;

        public override void InstallBindings()
        {
            Container.BindInstance(_factoryUnitConfiguration);
        }

        [Serializable]
        public sealed class Configuration
        {
            [SerializeField]
            private int _lvl = 0;
            [SerializeField]
            private int _coinsByLvl = 0;
            [SerializeField]
            private int _upgradePrice = 0;
            [SerializeField]
            private int _upgradeCoefficientForLvl = 0;
            [SerializeField]
            private Manufactory _prefabsContainer = null;
            [SerializeField]
            private int _prefabsUpdateLvl = 0;
            [SerializeField]
            private List<GameObject> _prefabs = new List<GameObject>();

            public int Lvl => _lvl;
            public int CoinsByLvl => _coinsByLvl;
            public int UpgradePrice => _upgradePrice;
            public int UpgradeCoefficientForLvl => _upgradeCoefficientForLvl;
            public Manufactory PrefabsContainer => _prefabsContainer;
            public int PrefabsUpdateLvl => _prefabsUpdateLvl;
            public List<GameObject> Prefabs => _prefabs;
        }
    }
}