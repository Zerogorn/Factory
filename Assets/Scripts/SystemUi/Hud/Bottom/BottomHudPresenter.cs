using SystemUi.Popups.Info;
using SystemUnits.Units.ManufactoryUnit;
using Models;
using UniRx;

namespace SystemUi.Hud.Bottom
{
    public sealed class BottomHudPresenter
    {
        private readonly BottomHudView _bottomHudView;
        private readonly DesignModelHandler _designModelHandler;
        private readonly ManufactoryUnitConfiguration.Configuration _configuration;
        private readonly UiManger _uiManger;

        private readonly CompositeDisposable _compositeDisposable;

        public BottomHudPresenter(BottomHudView bottomHudView,
                                  DesignModelHandler designModelHandler,
                                  ManufactoryUnitConfiguration.Configuration configuration,
                                  UiManger uiManger)
        {

            _compositeDisposable = new CompositeDisposable();

            _bottomHudView = bottomHudView;
            _designModelHandler = designModelHandler;
            _configuration = configuration;
            _uiManger = uiManger;
        }

        public void Initialization()
        {
            SetUpdatePrice();
            SetDescription(_configuration.CoinsByLvl * _designModelHandler.DesignModel.GetUnitLvl<Manufactory>());

            _designModelHandler.DesignModel.OnlvlUpdate<Manufactory>(lvl => SetUpdatePrice()).AddTo(_compositeDisposable);
            _designModelHandler.DesignModel.OnlvlUpdate<Manufactory>(lvl => SetDescription(_configuration.CoinsByLvl * lvl)).AddTo(_compositeDisposable);

            _bottomHudView.UpgradeButton += UpgradeButtonHandler;
        }

        public void Dispose()
        {
            _compositeDisposable.Dispose();
        }

        private void SetUpdatePrice()
        {
            var updatePrice = _designModelHandler.GetUnitUpdatePrice<Manufactory>(_configuration.UpgradePrice, _configuration.UpgradeCoefficientForLvl);
            _bottomHudView.SetUpgradePrice(updatePrice);
        }

        private void SetDescription(int coins)
        {
            var description = $"Gives {coins} coins per delivery";
            _bottomHudView.SetDescription(description);
        }

        private void UpgradeButtonHandler(Unit unit)
        {
            if (_designModelHandler.IsMaxLvl<Manufactory>(_configuration.Lvl))
            {
                return;
            }
            
            if (_designModelHandler.EnoughCoinsOnUpdate<Manufactory>(_configuration.UpgradePrice, _configuration.UpgradeCoefficientForLvl))
            {
                _designModelHandler.DesignModel.Coins.Value -= _designModelHandler.GetUnitUpdatePrice<Manufactory>(_configuration.UpgradePrice, _configuration.UpgradeCoefficientForLvl);
                _designModelHandler.UpdateUnitLvl<Manufactory>();
            }
            else
            {
                _uiManger.Show<InfoPopupView>();
            }
        }
    }
}