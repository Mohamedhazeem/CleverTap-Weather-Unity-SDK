using UnityEngine;

namespace CleverTap.WeatherSDK.ToastSystem
{
    public class AndroidToastService : IToastService
    {
        public void Show(string message)
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            ToastNativeBridge.ShowAndroidToast(message);
#else
            Debug.Log("[ToastSDK Android] " + message);
#endif
        }
    }
}
