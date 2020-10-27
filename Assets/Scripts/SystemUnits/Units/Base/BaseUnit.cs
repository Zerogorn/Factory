using System;
using System.Collections.Generic;
using SystemUnits.Strategies.Base;
using UnityEngine;

namespace SystemUnits.Units.Base
{
    public abstract class BaseUnit : MonoBehaviour , IUnit
    {
        private readonly IDictionary<Type, IStrategy> _strategies = new Dictionary<Type, IStrategy>();

        protected void AddStrategy<TStrategy>(TStrategy strategy)
            where TStrategy : IStrategy
        {
            _strategies.Add(typeof(TStrategy),  strategy);
        }

        protected TStrategy GetStrategy<TStrategy>()
            where TStrategy : IStrategy
        {
            return (TStrategy)_strategies[typeof(TStrategy)];
        }
    }
}