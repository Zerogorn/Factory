using System;
using SystemUnits.Units.Base;
using UniRx;

namespace Models
{
    public sealed class DesignModel
    {
        private readonly ReactiveProperty<int> _coins;
        private readonly ReactiveDictionary<Type, ReactiveProperty<int>> _unitsLvl;

        public IReactiveProperty<int> Coins => _coins;
        public IReactiveDictionary<Type, ReactiveProperty<int>> UnitsLvl => _unitsLvl;

        public DesignModel()
        {
            _coins = new ReactiveProperty<int>(0);
            _unitsLvl = new ReactiveDictionary<Type, ReactiveProperty<int>>();
        }

        public int GetUnitLvl<TUnit>()
            where TUnit : BaseUnit
        {
            if (_unitsLvl.TryGetValue(typeof(TUnit), out ReactiveProperty<int> lvl))
            {
                return lvl.Value;
            }
            
            return int.MinValue;
        }

        public void SetUnitLvl<TUnit>(int newLvl)
            where TUnit : BaseUnit
        {
            if (_unitsLvl.TryGetValue(typeof(TUnit), out ReactiveProperty<int> lvl))
            {
                lvl.SetValueAndForceNotify(newLvl);
            }
        }

        public IDisposable OnlvlUpdate<TUnit>(Action<int> onLvlUpdate)
            where TUnit : BaseUnit
        {
            if (_unitsLvl.TryGetValue(typeof(TUnit), out ReactiveProperty<int> lvl))
            {
                return lvl.Subscribe(onLvlUpdate);
            }

            return null;
        }
    }
}