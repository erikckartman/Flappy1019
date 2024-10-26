using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;
using System.Text.RegularExpressions;
using System;

public class ScoreBase : MonoBehaviour
{
    private string urlGet = "http://localhost:3000/getdata";
    private string urlSend = "http://localhost:3000/senddata";

    [SerializeField] private TextMeshProUGUI scoreboard;
    public string playername = "Semen";
    public int playerscore = 555;

    private void Start()
    {
        StartCoroutine(GetInfoFromUrl());
    }

    private IEnumerator GetInfoFromUrl()
    {
        UnityWebRequest request = UnityWebRequest.Get(urlGet);

        yield return request.SendWebRequest();

        if(request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.Log("Error");
        }
        else
        {
            string scoredata = request.downloadHandler.text;
            string[] highscores = scoredata.Split(new[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
            string finalDisplayText = "";

            foreach (string highscore in highscores)
            {

                string[] fields = Regex.Split(highscore, @"\s*,\s*");

                if (fields.Length == 2)
                {
                    string name = fields[0].Trim();
                    string score = fields[1].Trim();

                    finalDisplayText += $"{name} - {score}\n";
                }
                else
                {
                    Debug.LogWarning("Invalid data format for highscore entry: " + highscore);
                    Debug.LogWarning("Fields length: " + fields.Length + ", Content: " + string.Join(", ", fields));
                }
            }

            scoreboard.text = finalDisplayText;
        }
    }

    private IEnumerator SendInfoToUrl(string name, int score)
    {
        WWWForm form = new WWWForm();
        form.AddField("name", name);
        form.AddField("score", score);

        using (UnityWebRequest request = UnityWebRequest.Post(urlSend, form))
        {
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log("Error: " + request.error);
            }
            else
            {
                Debug.Log("Score sent successfully: " + request.downloadHandler.text);
                StartCoroutine(GetInfoFromUrl());
            }
        }
    }

    public void SendScoreToSQL()
    {
        Debug.Log($"Send {playername} and {playerscore}");
        if(GameOverScreen.highscore > 0)
        {
            StartCoroutine(SendInfoToUrl(playername, GameOverScreen.highscore));
        }
    }
}
