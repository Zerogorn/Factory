using UnityEngine;

namespace SystemUi.Base
{
    public abstract class BaseView : MonoBehaviour
    {
        public bool MaskOn { get; protected set; } = false;

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}