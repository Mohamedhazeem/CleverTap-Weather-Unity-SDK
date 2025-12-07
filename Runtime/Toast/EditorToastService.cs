using UnityEngine;

namespace CleverTap.WeatherSDK.ToastSystem
{
    public class EditorToastService : IToastService
    {
        public void Show(string message)
        {
            Debug.Log("[ToastSDK Editor] " + message);
        }
    }
}
