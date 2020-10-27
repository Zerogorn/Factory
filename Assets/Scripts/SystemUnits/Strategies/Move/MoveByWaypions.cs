using System;
using System.Collections.Generic;
using SystemUnits.Strategies.Base;
using SystemUnits.Strategies.Move.State;
using SystemWaypoint;
using UnityEngine;

namespace SystemUnits.Strategies.Move
{
    public sealed class MoveByWaypions : BaseStrategy
    {
        private readonly Transform _transform;
        private readonly WaypointConrtoller _waypointConrtoller;

        private IDictionary<Type, IMoveState> _moveState;
        private IMoveState _currentState;

        public MoveByWaypions(Transform transform, WaypointConrtoller waypointConrtoller, float timeOnLoop)
        {
            _transform = transform;
            _waypointConrtoller = waypointConrtoller;

            _moveState = new Dictionary<Type, IMoveState>
            {
                {typeof(Stop), new Stop()},
                {typeof(State.Move), new State.Move(transform,  waypointConrtoller, timeOnLoop)}
            };

            _currentState = _moveState[typeof(State.Move)];

            SetStartPosition();
        }

        public void SetState<TState>()
            where TState : IMoveState
        {
            _moveState.TryGetValue(typeof(TState), out _currentState);
        }

        public void Update()
        {
            _currentState.Update();
        }

        private void SetStartPosition()
        {
            _transform.position = _waypointConrtoller.Waypoints[0].transform.position;
        }
    }
}