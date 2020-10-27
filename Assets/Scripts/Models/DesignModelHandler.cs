using SystemUnits.Units.Base;

namespace Models
{
    public sealed class DesignModelHandler
    {
        public DesignModel DesignModel { get; }

        public DesignModelHandler(DesignModel designModel)
        {
            DesignModel = designModel;
        }

        public void UpdateUnitLvl<TUnit>()
            where TUnit : BaseUnit
        {
            DesignModel.SetUnitLvl<TUnit>(DesignModel.GetUnitLvl<TUnit>() + 1);
        }

        public bool IsMaxLvl<TUnit>(int maxLvl)
            where TUnit : BaseUnit
        {
            return DesignModel.GetUnitLvl<TUnit>() >= maxLvl;
        }

        public bool EnoughCoinsOnUpdate<TUnit>(int upgradePrice, int upgradeCoefficientForLvl)
            where TUnit : BaseUnit
        {
            return DesignModel.Coins.Value >= GetUnitUpdatePrice<TUnit>(upgradePrice, upgradeCoefficientForLvl);
        }

        public int GetUnitUpdatePrice<TUnit>(int upgradePrice, int upgradeCoefficientForLvl)
            where TUnit : BaseUnit
        {
            var unitLvl = DesignModel.GetUnitLvl<TUnit>();
            var price = upgradePrice;

            for (int i = 1; i < unitLvl; i++)
            {
                price *= upgradeCoefficientForLvl;
            }

            return price;
        }
    }
}