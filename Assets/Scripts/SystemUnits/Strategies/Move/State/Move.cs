using SystemWaypoint;
using UnityEngine;

namespace SystemUnits.Strategies.Move.State
{
    public sealed class Move : IMoveState
    {
        private readonly Transform _transform;
        private readonly WaypointConrtoller _waypointConrtoller;
        private readonly float _speed;
        
        private int _currentPoint;

        public Move(Transform transform, WaypointConrtoller waypointConrtoller, float timeOnLoop)
        {
            _transform = transform;
            _waypointConrtoller = waypointConrtoller;
            _speed = waypointConrtoller.Distance / timeOnLoop;
        }

        public void Update()
        {
            var nextPoint = _currentPoint + 1;

            RotateTo(_waypointConrtoller.Waypoints[nextPoint].transform.position,
                     _transform.position);

            MoveTo(_transform.position,
                   _waypointConrtoller.Waypoints[nextPoint].transform.position, _speed);

            UpdatePoint(nextPoint);
            SetStartPosition();
        }

        private void SetStartPosition()
        {
            if (_currentPoint >= _waypointConrtoller.Waypoints.Length - 1)
            {
                _currentPoint = 0;
                var position = _waypointConrtoller.Waypoints[_currentPoint].transform.position;
                _transform.position = position;
            }
        }

        private void RotateTo(Vector3 target, Vector3 position)
        {
            var diff = target - position;
            diff.Normalize();

            var rotation = Mathf.Atan2(diff.x, diff.z) * Mathf.Rad2Deg;
            var newQuaternion = Quaternion.Euler(0f, rotation - 90, 0);
            _transform.rotation = Quaternion.Slerp(_transform.rotation, newQuaternion, Time.deltaTime * 15f);
        }

        private void MoveTo(Vector3 from, Vector3 to, float speed)
        {
            var step = speed * Time.deltaTime;
            _transform.position = Vector3.MoveTowards(from, to, step);
        }

        private void UpdatePoint(int nextPoint)
        {
            var magnitude = Vector3.SqrMagnitude(_transform.position - _waypointConrtoller.Waypoints[nextPoint].transform.position);
            if (magnitude <= Vector3.kEpsilon)
            {
                _currentPoint += 1;
            }
        }
    }
}