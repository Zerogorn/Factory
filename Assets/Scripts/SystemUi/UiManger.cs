using System;
using System.Collections.Generic;
using SystemUi.Base;

namespace SystemUi
{
    public sealed class UiManger
    {
        private readonly Dictionary<Type, BaseView> _views;

        public UiManger()
        {
            _views = new Dictionary<Type, BaseView>();
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
            }
        }

        public void Hide<TView>()
            where TView : BaseView
        {
            if (_views.TryGetValue(typeof(TView), out BaseView component))
            {
                component.Hide();
            }
        }
    }
}