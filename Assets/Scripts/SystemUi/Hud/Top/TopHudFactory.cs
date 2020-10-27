using Models;
using UnityEngine;
using Zenject;

namespace SystemUi.Hud.Top
{
    public sealed class TopHudFactory : IFactory<TopHudView>
    {
        private readonly UiObj.HudComponents _hudComponents;
        private readonly DesignModel _designModel;
        private readonly UiCanvasController _uiCanvas;

        public TopHudFactory(DesignModel designModel,
                             UiCanvasController uiCanvas, 
                             UiObj.HudComponents hudComponents)
        {

            _designModel = designModel;
            _uiCanvas = uiCanvas;
            _hudComponents = hudComponents;
        }

        public TopHudView Create()
        {
            var topHudView = Object.Instantiate(_hudComponents.TopHudView, _uiCanvas.Hud);
            var topHudViewPresenter = new TopHudPresenter(topHudView, _designModel);
            topHudViewPresenter.Initialization();

            return topHudView;
        }
    }
}