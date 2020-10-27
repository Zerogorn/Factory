using SystemUnits.Strategies.Base;
using Models;

namespace SystemUnits.Strategies
{
    public sealed class CoinsAdder : BaseStrategy
    {
        private readonly DesignModel _designModel;
        
        public CoinsAdder(DesignModel designModel)
        {
            _designModel = designModel;
        }

        public void AddCoins(int coins)
        {
            _designModel.Coins.Value += coins;
        }
    }
}