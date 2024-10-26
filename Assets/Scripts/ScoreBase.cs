using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;
using System.Text.RegularExpressions;

public class ScoreBase : MonoBehaviour
{
    private string url = "http://localhost:3000/";
    [SerializeField] private TextMeshProUGUI scoreboard;
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
}
