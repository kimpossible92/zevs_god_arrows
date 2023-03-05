using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OneSignalSDK;
using System;
using UnityEngine.UI;

public class testOneBehavior : MonoBehaviour
{
    public Text console;
    // Start is called before the first frame update
    void Start()
    {
        OneSignal.Default.Initialize("f5065db6-fc23-470e-acf3-76b637f3a3bd");
        OneSignal.Default.SetExternalUserId("123123");
        SendPushToSelf();
    }
    public async void SendPushToSelf()
    {
        _log("Sending push notification to this device via PostNotification...");

        // Use the id of the push subscription in order to send a push without needing an API key
        var pushId = OneSignal.Default.PushSubscriptionState.userId;

        // Check out our API docs at https://documentation.onesignal.com/reference/create-notification
        // for a full list of possibilities for notification options.
        var pushOptions = new Dictionary<string, object>
        {
            ["contents"] = new Dictionary<string, string>
            {
                ["en"] = "Test Message"
            },

            // Send notification to this user
            ["include_player_ids"] = new List<string> { pushId },

            // Example of scheduling a notification in the future
            ["send_after"] = DateTime.Now.ToUniversalTime().AddSeconds(30).ToString("U")
        };

        var result = await OneSignal.Default.PostNotification(pushOptions);

        if (Json.Serialize(result) is string resultString) 
            _log($"Notification sent with result <b>{resultString}</b>");
        else 
            _error("Could not serialize result of PostNotification");
    }
    private void _log(object message)
    {
        Debug.Log(message);
        console.text += $"\n<color=green><b>I></b></color> {message}";
    }
    private void _warn(object message)
    {
        Debug.LogWarning(message);
        console.text += $"\n<color=orange><b>W></b></color> {message}";
    }

    private void _error(object message)
    {
        Debug.LogError(message);
        console.text += $"\n<color=red><b>E></b></color> {message}";
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
