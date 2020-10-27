using Models;
using UnityEngine;
using Zenject;

namespace SystemProgress
{
    public sealed class LoadPlayerPrefs : IInitializable
    {
        private readonly DesignModel _model;

        public LoadPlayerPrefs(DesignModel model)
        {
            _model = model;
        }

        public void Initialize()
        {
            Coins();
            Units();
        }

        private void Coins()
        {
            _model.Coins.Value = PlayerPrefs.GetInt(ProgressConst.COINS, 0);
        }

        private void Units()
        {
            foreach (var unit in _model.UnitsLvl)
            {
                var lvl = PlayerPrefs.GetInt(unit.Key.ToString(), 1);
                unit.Value.Value = lvl;
            }
        }
    }
}