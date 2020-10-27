using System;
using SystemUnits.Strategies;
using SystemUnits.Units.Base;
using SystemUnits.Units.TruckUnit;
using SystemUnits.Units.TruckUnit.State;
using Models;
using UnityEngine;

namespace SystemUnits.Units.ManufactoryUnit
{
    public sealed class Manufactory : BaseUnit
    {
        private ManufactoryUnitConfiguration.Configuration _configuration;
        private DesignModel _designModel;
        private GameObject _factoryPrefab;

        public void Initialize(GameObject factoryPrefab, ManufactoryUnitConfiguration.Configuration configuration, DesignModel designModel)
        {
            _factoryPrefab = factoryPrefab;
            _configuration = configuration;
            _designModel = designModel;

            AddStrategies();
        }

        private void Start()
        {
            UpdatePrefab(_designModel.GetUnitLvl<Manufactory>());
            _designModel.OnlvlUpdate<Manufactory>(UpdatePrefab);
        }

        private void UpdatePrefab(int lvl)
        {
            if (lvl % 5 == 0)
            {
                var prefabIndex = lvl / _configuration.PrefabsUpdateLvl;
                prefabIndex = Mathf.Min(_configuration.Prefabs.Count - 1, prefabIndex);

                Destroy(_factoryPrefab);
                SetPrefab(prefabIndex);
            }
        }

        private void SetPrefab(int prefabIndex)
        {
            _factoryPrefab = Instantiate(_configuration.Prefabs[prefabIndex], transform);
            _factoryPrefab.SetActive(true);
        }

        private void AddStrategies()
        {
            AddStrategy(new CoinsAdder(_designModel));
        }

        private void OnTriggerEnter(Collider collider)
        {
            if (collider.gameObject.TryGetComponent(out Truck truck)
                && truck.IsState<HasRock>())
            {
                var strategy = GetStrategy<CoinsAdder>();
                var coins = _configuration.CoinsByLvl * _designModel.GetUnitLvl<Manufactory>();
                strategy.AddCoins(coins);

                truck.SetState<Empty>();
            }
        }
    }
}