using UnityEngine;

namespace SystemUnits.Units.TruckUnit.State
{
    public sealed class Empty : ITruckState
    {
        private GameObject _rock;

        public Empty(GameObject rock)
        {
            _rock = rock;
        }

        public void Initialization()
        {
            _rock.SetActive(false);
        }
    }
}