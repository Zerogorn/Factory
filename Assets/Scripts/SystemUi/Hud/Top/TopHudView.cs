using SystemUi.Base;
using TMPro;
using UnityEngine;

namespace SystemUi.Hud.Top
{
    public sealed class TopHudView : BaseView
    {
        [SerializeField]
        private TextMeshProUGUI _coins = null;

        public void SetCoins(int coins)
        {
            _coins.text = $"x{coins}";
        }
    }
}