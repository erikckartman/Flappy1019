using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameScore : MonoBehaviour
{
    public static int score = 0;
    public TextMeshProUGUI scoreUI;
    [SerializeField] private GameObject player;

    private void Start()
    {
        score = 0;
        InvokeRepeating("PlusToScore", 0f, 1f);
    }

    private void Update()
    {
        scoreUI.text = score.ToString();

        if(player == null)
        {
            StartCoroutine(GameOver());
        }
    }

    private void PlusToScore()
    {
        score++;
    }

    private IEnumerator GameOver()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("GameOver");
    }
}
