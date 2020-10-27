using System;
using SystemUnits.Units.Base;
using UnityEngine;

namespace SystemUnits.Units.TruckUnit
{
    [CreateAssetMenu(fileName = nameof(TruckUnitConfiguration), menuName = nameof(BaseUnitConfiguration) + "/" + nameof(TruckUnitConfiguration))]
    public sealed class TruckUnitConfiguration : BaseUnitConfiguration
    {
        [SerializeField]
        private Configuration _truckUnitConfiguration = null;

        public override void InstallBindings()
        {
            Container.BindInstance(_truckUnitConfiguration);
        }

        [Serializable]
        public sealed class Configuration
        {
            [SerializeField]
            [Tooltip("In seconds")]
            private int _moveDuration;
            [SerializeField]
            private Truck _prefab = null;

            public int MoveDuration => _moveDuration;
            public Truck Prefab => _prefab;
        }
    }
}