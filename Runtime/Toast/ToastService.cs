using UnityEngine;

namespace CleverTap.WeatherSDK.ToastSystem
{
    public static class ToastService
    {
        public static void Show(string message)
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            NativeBridge.ShowAndroidToast(message);
#elif UNITY_IOS && !UNITY_EDITOR
            NativeBridge.ShowIOSToast(message);
#else
            Debug.Log("[ToastSDK] " + message);
#endif
        }
    }
}
