using SystemUi.Hud.Bottom;
using SystemUi.Hud.Top;
using SystemUi.Popups.Info;
using Zenject;

namespace SystemUi
{
    public sealed class UiCreator : IInitializable
    {
        private readonly UiManger _uiManger;

        private readonly IFactory<BottomHudView> _bottomHud;
        private readonly IFactory<TopHudView> _topHud;
        private readonly IFactory<InfoPopupView> _infoPopupView;

        public UiCreator(UiManger uiManger,
                         IFactory<BottomHudView> bottomHud,
                         IFactory<TopHudView> topHud,
                         IFactory<InfoPopupView> infoPopupView)
        {
            _uiManger = uiManger;
            _bottomHud = bottomHud;
            _topHud = topHud;
            _infoPopupView = infoPopupView;
        }

        public void Initialize()
        {
            var bottomHud = _bottomHud.Create();
            bottomHud.Show();
            _uiManger.Add(bottomHud);

            var topHud = _topHud.Create();
            bottomHud.Show();
            _uiManger.Add(topHud);

            var infoPopup = _infoPopupView.Create();
            infoPopup.Hide();
            _uiManger.Add(infoPopup);
        }
    }
}