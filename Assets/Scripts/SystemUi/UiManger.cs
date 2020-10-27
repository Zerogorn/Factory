using System;
using System.Collections.Generic;
using SystemUi.Base;

namespace SystemUi
{
    public sealed class UiManger
    {
        private readonly Dictionary<Type, BaseView> _views;
        private UiCanvasController _canvasController;

        public UiManger(UiCanvasController canvasController)
        {
            _views = new Dictionary<Type, BaseView>();
            _canvasController = canvasController;
        }

        public void Add<TView>(TView tView)
            where TView : BaseView
        {
            _views.Add(typeof(TView), tView);
        }

        public void Show<TView>()
            where TView : BaseView
        {
            if (_views.TryGetValue(typeof(TView), out BaseView component))
            {
                component.Show();
                _canvasController.Mask.transform.SetParent(component.transform.parent);
                _canvasController.Mask.transform.SetSiblingIndex(0);
                _canvasController.Mask.gameObject.SetActive(component.MaskOn);
            }
        }

        public void Hide<TView>()
            where TView : BaseView
        {
            if (_views.TryGetValue(typeof(TView), out BaseView component))
            {
                component.Hide();
                _canvasController.Mask.gameObject.SetActive(false);
            }
        }
    }
}