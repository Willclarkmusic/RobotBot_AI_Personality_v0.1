using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using Meta.WitAi.TTS.Utilities;
using TMPro;


public class Gemini_Manager : MonoBehaviour
{
    [SerializeField] private string gasURL;
    [SerializeField] private string prompt;
    [SerializeField] private TTSSpeaker ttsSpeaker;

    public TMPro.TMP_InputField inputField;
    

    private void Start()
    {

    }

    public void AskGemini(string finalPrompt)
    {
        prompt = finalPrompt;
        StartCoroutine(sendDataToGas());
    }

    private IEnumerator sendDataToGas()
    {

        WWWForm form = new WWWForm();
        form.AddField("parameter", prompt);
        UnityWebRequest www = UnityWebRequest.Post(gasURL, form);

        yield return www.SendWebRequest();
        string response = "";

        if (www.result == UnityWebRequest.Result.Success)
        {
            response = www.downloadHandler.text;
        }
        else
        {
            response = "There was an error!";
        }
        Debug.Log(response);
        RoboBotTTS(response);
    }

    private void RoboBotTTS(string inputText)
    {
        string characterPrompt = "You are a Robot named RoboBot and you were made to play video games with.  " +
            "You speak very simlpy and hardly ever use adjectives.  " +
            "Limit your response to one or two sentences.";

        ttsSpeaker.Speak(inputText);
    }

}
