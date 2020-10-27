using UnityEngine;

namespace SystemUi
{
    public sealed class UiCanvasController : MonoBehaviour
    {
        [SerializeField]
        private Transform _hud = null;
        [SerializeField]
        private Transform _windows = null;

        public Transform Hud => _hud;
        public Transform Windows => _windows;
    }
}