using UnityEngine;

namespace SystemUnits.Units.TruckUnit.State
{
    public sealed class HasRock : ITruckState
    {
        private GameObject _rock;

        public HasRock(GameObject rock)
        {
            _rock = rock;
        }

        public void Initialization()
        {
            _rock.gameObject.SetActive(true);
        }
    }
}