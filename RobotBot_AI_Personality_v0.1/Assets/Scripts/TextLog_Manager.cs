using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Xml.Serialization;

public class TextLog_Manager : MonoBehaviour
{
    [SerializeField] 
    List<MessageNode> messageList = new List<MessageNode>();

    public TMP_InputField inputBox;

    public GameObject chatPanel, textObject;

    public int maxMessages = 25;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (inputBox.isFocused)
        {
            if (Input.GetKeyUp(KeyCode.Return)) 
            {
                SendMessageToChat(inputBox.text);
                inputBox.text = "";
            }
        }

    }

    public void SendMessageToChat(string text)
    {
        if (messageList.Count >= maxMessages)
        {
            Destroy(messageList[0].textObject.gameObject);
            messageList.Remove(messageList[0]);
        }


        MessageNode newMessage = new MessageNode();

        newMessage.text = text;
        GameObject newText = Instantiate(textObject, chatPanel.transform);

        newMessage.textObject = newText.GetComponent<TextMeshProUGUI>();
        newMessage.textObject.text = newMessage.text;

        messageList.Add(newMessage);
    }
}

[System.Serializable]
public class MessageNode
{
    public string text;
    public TextMeshProUGUI textObject;
}