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
            using (AndroidJavaClass toastClass = new AndroidJavaClass("android.widget.Toast"))
            using (AndroidJavaClass gravityClass = new AndroidJavaClass("android.view.Gravity"))
            {
                AndroidJavaObject toast = toastClass.CallStatic<AndroidJavaObject>(
                    "makeText", activity, message, 0
                );

                int gravity = gravityClass.GetStatic<int>("TOP") |
                              gravityClass.GetStatic<int>("CENTER_HORIZONTAL");

                toast.Call("setGravity", gravity, 0, 150);  
                // last param is Y offset (move slightly down from top)

                toast.Call("show");
            }
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
