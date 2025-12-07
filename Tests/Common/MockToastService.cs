using CleverTap.WeatherSDK.ToastSystem;
using System.Collections.Generic;

public class MockToastService : IToastService
{
    public List<string> MessagesShown = new List<string>();

    public void Show(string message)
    {
        MessagesShown.Add(message);
    }
    public string LastMessage
    {
        get
        {
            return MessagesShown.Count > 0
                ? MessagesShown[MessagesShown.Count - 1]
                : null;
        }
    }

}
