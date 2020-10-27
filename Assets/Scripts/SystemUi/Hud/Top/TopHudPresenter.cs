using Models;
using UniRx;

namespace SystemUi.Hud.Top
{
    public sealed class TopHudPresenter
    {
        private readonly TopHudView _topHudView;
        private readonly DesignModel _designModel;

        private readonly CompositeDisposable _compositeDisposable;

        public TopHudPresenter(TopHudView topHudView, 
                               DesignModel designModel)
        {
            _compositeDisposable = new CompositeDisposable();

            _topHudView = topHudView;
            _designModel = designModel;
        }

        public void Initialization()
        {
            _designModel.Coins.Subscribe(_topHudView.SetCoins).AddTo(_compositeDisposable);
        }

        public void Dispose()
        {
            _compositeDisposable.Dispose();
        }
    }
}