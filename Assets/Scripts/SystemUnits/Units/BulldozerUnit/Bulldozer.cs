using System;
using SystemUnits.Units.Base;
using SystemUnits.Units.TruckUnit;
using SystemUnits.Units.TruckUnit.State;
using UniRx;
using UnityEngine;

namespace SystemUnits.Units.BulldozerUnit
{
    public sealed class Bulldozer : BaseUnit
    {
        private const string LOAD = "Load";

        [SerializeField]
        private Animator _animator = null;

        private BulldozerUnitConfiguration.Configuration _configuration;

        private Truck _truck;

        public void Initialization(BulldozerUnitConfiguration.Configuration configuration)
        {
            _configuration = configuration;
        }

        private void OnTriggerEnter(Collider collider)
        {
            if (collider.gameObject.TryGetComponent(out _truck))
            {
                PlayLoad();
            }
        }

        private void PlayLoad()
        {
            _truck.CanMove(false);
            _animator.SetTrigger(LOAD);
            
            Observable.Timer(TimeSpan.FromSeconds(_configuration.LoadSpeed))
                      .Subscribe(_ =>
                                 {
                                     _animator.SetTrigger(LOAD);
                                     _truck.SetState<HasRock>();
                                     _truck.CanMove(true);
                                     
                                     _truck = null;
                                 })
                      .AddTo(this);
        }
    }
}