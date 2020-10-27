using System;
using SystemUi.Base;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace SystemUi.Hud.Bottom
{
    public sealed class BottomHudView : BaseView
    {
        [SerializeField]
        private TextMeshProUGUI _upgradePrice = null;
        [SerializeField]
        private TextMeshProUGUI _description = null;
        [SerializeField]
        private Button _upgradeButton = null;

        public event Action<Unit> UpgradeButton;

        private void Awake()
        {
            UpgradeButton += x => { };
        }

        private void OnEnable()
        {
            _upgradeButton.OnClickAsObservable()
                          .Subscribe(unit => UpgradeButton?.Invoke(unit))
                          .AddTo(this);
        }

        public void SetUpgradePrice(int upgradePrice)
        {
            _upgradePrice.text = upgradePrice.ToString();
        }

        public void SetDescription(string description)
        {
            _description.text = description;
        }
    }
}