using System.Collections;
using System.Collections.Generic;
using Unity.AppUI.Core;
using UnityEngine;

public class TextLog_Manager : MonoBehaviour
{
    List<Message> messageList = new List<Message>();

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SendMessageToChat(string text)
    {
        Message newMessage = new Message();
        // newMessage.text = text;
        messageList.Add(newMessage);
    }

}
