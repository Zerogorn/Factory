using System;
using System.Collections.Generic;
using SystemUnits.Units.Base;
using Models;
using UniRx;

namespace SystemUnits
{
    public sealed class UnitsManger
    {
        private readonly DesignModel _designModel;
        private readonly IDictionary<Type, IUnit> _units;

        public UnitsManger(DesignModel designModel)
        {
            _units = new Dictionary<Type, IUnit>();
            _designModel = designModel;
        }

        public void Add<TType>(TType unit)
            where TType : IUnit
        {
            var type = typeof(TType);

            _designModel.UnitsLvl.Add(type, new ReactiveProperty<int>(1));
            _units.Add(type, unit);
        }

        public TType Get<TType>()
            where TType : IUnit
        {
            var type = typeof(TType);
            
            return (TType) _units[type];
        }

        public void Remove<TType>()
            where TType : IUnit
        {
            var type = typeof(TType);

            _units.Remove(type);
        }
    }
}