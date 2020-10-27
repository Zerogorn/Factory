using System.Linq;
using UnityEngine;

namespace SystemWaypoint
{
    public sealed class WaypointConrtoller : MonoBehaviour
    {
        private Waypoint[] _waypoints = null;
        private float _distance = 0;

        public Waypoint[] Waypoints => _waypoints;
        public float Distance => _distance;

        private void Awake()
        {
            _waypoints = transform.GetComponentsInChildren<Waypoint>();

            for (int i = 0; i < _waypoints.Length -1; i++)
            {
                _distance += Vector3.Distance(_waypoints[i].transform.localPosition,
                                              _waypoints[i + 1].transform.localPosition);
            }

            _distance += Vector3.Distance(_waypoints.First().transform.localPosition,
                                          _waypoints.Last().transform.localPosition);
        }
    }
}