using System;
using SystemUi.Hud.Bottom;
using SystemUi.Hud.Top;
using SystemUi.Popups.Info;
using UnityEngine;
using Zenject;

namespace SystemUi
{
    [CreateAssetMenu(fileName = nameof(UiObj), menuName = nameof(UiObj))]
    public sealed class UiObj : ScriptableObjectInstaller
    {
        [SerializeField]
        private HudComponents _hudComponents = null;
        [SerializeField] 
        private PopupsComponents _popupsComponents = null;

        public override void InstallBindings()
        {
            Container.BindInstance(_hudComponents);
            Container.BindInstance(_popupsComponents);
        }

        [Serializable]
        public class HudComponents
        {
            [SerializeField]
            private TopHudView _topHudView = null;
            [SerializeField]
            private BottomHudView _bottomHudView = null;

            public TopHudView TopHudView => _topHudView;
            public BottomHudView BottomHudView => _bottomHudView;
        }

        [Serializable]
        public class PopupsComponents
        {
            [SerializeField]
            private InfoPopupView _infoPopupView = null;
            
            public InfoPopupView InfoPopupView => _infoPopupView;
        }
    }
}