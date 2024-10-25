using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ScoreBase : MonoBehaviour
{
    private string url = "http://localhost:3000/";
    private void Start()
    {
        StartCoroutine(GetInfoFromUrl());
    }

    private IEnumerator GetInfoFromUrl()
    {
        UnityWebRequest request = UnityWebRequest.Get(url);

        yield return request.SendWebRequest();

        if(request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.Log("Error");
        }
        else
        {
            string scoredata = request.downloadHandler.text;
            string[] highscores = scoredata.Split("; ");

            foreach(string highscore in highscores)
            {
                string[] fields = highscore.Split(", ");

                string name = fields[0];
                int score = int.Parse(fields[1]);

                Debug.Log(name + ": " + score);
            }
        }
    }
}
