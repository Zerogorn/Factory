namespace SystemUi.Popups.Info
{
    public sealed class InfoPopupPresenter
    {
        private readonly UiManger _uiManger;
        private readonly InfoPopupView _infoPopupView;

        public InfoPopupPresenter(UiManger uiManger, 
                                  InfoPopupView infoPopupView)
        {
            _uiManger = uiManger;
            _infoPopupView = infoPopupView;
        }

        public void Initialization()
        {
            _infoPopupView.ButtonOk += unit => { _uiManger.Hide<InfoPopupView>();};
        }
    }
}