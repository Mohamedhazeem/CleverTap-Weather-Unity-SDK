using UnityEngine;

namespace CleverTap.WeatherSDK.ToastSystem
{
    public static class ToastNativeBridge
    {
#if UNITY_ANDROID
        public static void ShowAndroidToast(string message)
        {
           using (AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
    {
        AndroidJavaObject activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

        activity.Call("runOnUiThread", new AndroidJavaRunnable(() =>
        {
            using (AndroidJavaClass toastClass = new AndroidJavaClass("android.widget.Toast")){
             AndroidJavaObject toast = toastClass.CallStatic<AndroidJavaObject>(
                    "makeText", activity, message, 0
                );
                toast.Call("show");}           
        }));
    }
        }
#endif

#if UNITY_IOS
        [System.Runtime.InteropServices.DllImport("__Internal")]
        private static extern void _showToast(string message);

        public static void ShowIOSToast(string message)
        {
            _showToast(message);
        }
#endif
    }
}
