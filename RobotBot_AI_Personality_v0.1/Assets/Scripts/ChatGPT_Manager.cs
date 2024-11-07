using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OpenAI;


public class ChatGPT_Manager : MonoBehaviour
{
    private OpenAIApi openAI = new OpenAIApi();
    private List<ChatMessage> message = new List<ChatMessage>();



    public async void AskChatGPT(string newText)
    {

        ChatMessage newMessage = new ChatMessage();
        newMessage.Content = newText;
        newMessage.Role = "user";

        message.Add(newMessage);

        CreateChatCompletionRequest request = new CreateChatCompletionRequest();
        request.Messages = message;
        request.Model = "gpt-3.5-turbo";

        var response = await openAI.CreateChatCompletion(request);

        if(response.Choices != null && response.Choices.Count > 0)
        {
            var chatRespones = response.Choices[0].Message;
            message.Add(chatRespones);

            Debug.Log(chatRespones.Content);
        }
    }

}
