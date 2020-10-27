using System;
using SystemUi.Base;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace SystemUi.Popups.Info
{
    public sealed class InfoPopupView : BaseView
    {
        [SerializeField] 
        private Button _buttonOk = null;

        public event Action<Unit> ButtonOk;

        private void Awake()
        {
            ButtonOk = unit => { };
        }

        private void OnEnable()
        {
            _buttonOk.OnClickAsObservable()
                     .Subscribe(ButtonOk)
                     .AddTo(this);
        }
    }
}