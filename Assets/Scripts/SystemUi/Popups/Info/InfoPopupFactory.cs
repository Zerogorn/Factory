using UnityEngine;
using Zenject;

namespace SystemUi.Popups.Info
{
    public sealed class InfoPopupFactory : IFactory<InfoPopupView>
    {
        private readonly UiObj.PopupsComponents _popupsComponents;
        private readonly UiCanvasController _uiCanvasController;
        private readonly UiManger _uiManger;

        public InfoPopupFactory(UiObj.PopupsComponents popupsComponents,
                                UiCanvasController uiCanvasController, 
                                UiManger uiManger)
        {
            _popupsComponents = popupsComponents;
            _uiCanvasController = uiCanvasController;
            _uiManger = uiManger;
        }

        public InfoPopupView Create()
        {
            var infoPopup = Object.Instantiate(_popupsComponents.InfoPopupView, _uiCanvasController.Windows);
            var infoPopupPresenter = new InfoPopupPresenter(_uiManger, infoPopup);
            infoPopupPresenter.Initialization();

            return infoPopup;
        }
    }
}