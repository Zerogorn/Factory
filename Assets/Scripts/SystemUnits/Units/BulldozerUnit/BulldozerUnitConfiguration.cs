using System;
using SystemUnits.Units.Base;
using UnityEngine;

namespace SystemUnits.Units.BulldozerUnit
{
    [CreateAssetMenu(fileName = nameof(BulldozerUnitConfiguration), menuName = nameof(BaseUnitConfiguration) + "/" + nameof(BulldozerUnitConfiguration))]
    public sealed class BulldozerUnitConfiguration : BaseUnitConfiguration
    {
        [SerializeField] 
        private Configuration _bulldozerUnitConfiguration = null;

        public override void InstallBindings()
        {
            Container.BindInstance(_bulldozerUnitConfiguration);
        }

        [Serializable]
        public sealed class Configuration
        {
            [SerializeField]
            [Tooltip("In seconds")]
            private float _loadSpeed = 0;
            [SerializeField]
            private Bulldozer _prefab = null;

            public float LoadSpeed => _loadSpeed;
            public Bulldozer Prefab => _prefab;
        }
    }
}