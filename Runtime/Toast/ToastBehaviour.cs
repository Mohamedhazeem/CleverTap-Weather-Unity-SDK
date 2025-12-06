using UnityEngine;

namespace CleverTap.WeatherSDK.ToastSystem
{
    public class ToastBehaviour : MonoBehaviour
    {
        [SerializeField] private string message = "Hello from SDK";

        private void OnMouseDown()
        {
            ToastService.Show(message);
        }

        public void SetMessage(string msg)
        {
            message = msg;
        }
    }
}
