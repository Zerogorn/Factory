using SystemUnits.Units.ManufactoryUnit;
using Models;
using UnityEngine;
using Zenject;

namespace SystemUi.Hud.Bottom
{
    public sealed class BottomHudFactory : IFactory<BottomHudView>
    {
        private readonly UiObj.HudComponents _hudComponents;
        private readonly DesignModelHandler _designModelHandler;
        private readonly ManufactoryUnitConfiguration.Configuration _configuration;
        private readonly UiCanvasController _uiCanvas;
        private readonly UiManger _uiManger;

        public BottomHudFactory(DesignModelHandler designModelHandler,
                                ManufactoryUnitConfiguration.Configuration configuration,
                                UiCanvasController uiCanvas,
                                UiObj.HudComponents hudComponents,
                                UiManger uiManger)
        {
            _designModelHandler = designModelHandler;
            _configuration = configuration;
            _uiCanvas = uiCanvas;
            _hudComponents = hudComponents;
            _uiManger = uiManger;
        }

        public BottomHudView Create()
        {
            var bottomHudView = Object.Instantiate(_hudComponents.BottomHudView, _uiCanvas.Hud);
            var bottomHudPresenter = new BottomHudPresenter(bottomHudView, _designModelHandler, _configuration, _uiManger);
            bottomHudPresenter.Initialization();

            return bottomHudView;
        }
    }
}