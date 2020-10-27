using Models;
using Zenject;
using UniRx;
using UnityEngine;

namespace SystemProgress
{
    public sealed class SaveToPlayerPrefs : IInitializable
    {
        private readonly DesignModel _model;

        public SaveToPlayerPrefs(DesignModel model)
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
            _model.Coins.Subscribe(conins => PlayerPrefs.SetInt(ProgressConst.COINS, conins));
        }

        private void Units()
        {
            foreach (var unit in _model.UnitsLvl)
            {
                unit.Value.Subscribe(lvl => PlayerPrefs.SetInt(unit.Key.ToString(), lvl));
            }
        }
    }
}