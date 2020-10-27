using System;
using System.Collections.Generic;
using SystemUnits.Strategies.Move;
using SystemUnits.Strategies.Move.State;
using SystemUnits.Units.Base;
using SystemUnits.Units.TruckUnit.State;
using SystemWaypoint;
using UnityEngine;

namespace SystemUnits.Units.TruckUnit
{
    public sealed class Truck : BaseUnit
    {
        private const string MANUFACTURE_ROAD = "MnufactureRoad";

        [SerializeField] 
        private GameObject _rock = null;

        private TruckUnitConfiguration.Configuration _configuration;
        private WaypointConrtoller _waypointConrtoller;

        private IDictionary<Type, ITruckState> _truckStates = new Dictionary<Type, ITruckState>();
        private ITruckState _currentTruckStates;

        public void Initialize(TruckUnitConfiguration.Configuration configuration)
        {
            _configuration = configuration;

            _truckStates = new Dictionary<Type, ITruckState>
            {
                { typeof(Empty), new Empty(_rock)},
                { typeof(HasRock), new HasRock(_rock)},
            };
            _currentTruckStates = _truckStates[typeof(Empty)];
            _currentTruckStates.Initialization();

            _waypointConrtoller = GameObject.FindGameObjectWithTag(MANUFACTURE_ROAD)
                                            .transform
                                            .GetComponentInChildren<WaypointConrtoller>();
            
            AddStrategies();
        }

        public void SetState<TState>()
            where TState : ITruckState
        {
            _truckStates.TryGetValue(typeof(TState), out _currentTruckStates);
            _currentTruckStates?.Initialization();
        }

        public bool IsState<TState>()
            where TState : ITruckState
        {
            return _currentTruckStates.GetType() == typeof(TState);
        }

        public void CanMove(bool move)
        {
            if (move)
            {
                GetStrategy<MoveByWaypions>().SetState<Move>();
            }
            else
            {
                GetStrategy<MoveByWaypions>().SetState<Stop>();
            }
        }

        private void AddStrategies()
        {
            AddStrategy(new MoveByWaypions(transform, _waypointConrtoller, _configuration.MoveDuration));
        }

        private void Update()
        {
            GetStrategy<MoveByWaypions>().Update();
        }
    }
}