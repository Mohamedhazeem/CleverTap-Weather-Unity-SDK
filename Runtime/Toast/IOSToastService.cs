using UnityEngine;

namespace CleverTap.WeatherSDK.ToastSystem
{
    public class IOSToastService : IToastService
    {
        public void Show(string message)
        {
#if UNITY_IOS && !UNITY_EDITOR
            ToastNativeBridge.ShowIOSToast(message);
#else
            Debug.Log("[ToastSDK iOS] " + message);
#endif
        }
    }
}
