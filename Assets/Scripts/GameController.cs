using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI score;
    [SerializeField] TextMeshProUGUI lives;
    [SerializeField] TextMeshProUGUI highScore;
    [SerializeField] GameObject gameOver;

    public GameObject eggController;
    private int scoreCounter = 0;
    public int livesCount = 3;
    public bool isGameActive;
    public PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        isGameActive = true;
        HighscoreExists();
    }

    void FixedUpdate()
    {
        if (!isGameActive)
        {
            eggController.SetActive(isGameActive);
        }
    }

    public void UpdateScore()
    {
        if (isGameActive)
        {
            scoreCounter++;
            score.text = scoreCounter.ToString();

            if (scoreCounter > 10 && scoreCounter < 20)
            {
                eggController.GetComponent<EggController>().tickTime = 2;
            }

            if (scoreCounter > 20)
            {
                eggController.GetComponent<EggController>().tickTime = 1;
            }
        }
    }

    void DecreaseLives()
    {
        if (isGameActive)
        {
            livesCount--;
            lives.text = livesCount.ToString();

            if (livesCount == 0)
            {
                gameOver.SetActive(true);
                isGameActive = false;
                UpdateHighscore();
            }
        }
    }

    public void CheckEggIsCaught(int position)
    {
        switch (position)
        {
            case 0:
                if (playerController.isLeft && playerController.isUp) UpdateScore();
                else DecreaseLives();
                break;
            case 1:
                if (playerController.isLeft && !playerController.isUp) UpdateScore();
                else DecreaseLives();
                break;
            case 2:
                if (!playerController.isLeft && playerController.isUp) UpdateScore();
                else DecreaseLives();
                break;
            case 3:
                if (!playerController.isLeft && !playerController.isUp) UpdateScore();
                else DecreaseLives();
                break;
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene("CatchTheEgg");
    }

    private void UpdateHighscore()
    {
        if (PlayerPrefs.HasKey("highScore"))
        {
            int highScore = PlayerPrefs.GetInt("highScore");
            if (highScore < scoreCounter)
            {
                PlayerPrefs.SetInt("highScore", scoreCounter);
                PlayerPrefs.Save();
            }
        }
        else
        {
            PlayerPrefs.SetInt("highScore", scoreCounter);
            PlayerPrefs.Save();
        }
    }

    private void HighscoreExists()
    {
        if (PlayerPrefs.HasKey("highScore"))
        {
            int highScoreInt = PlayerPrefs.GetInt("highScore");
            highScore.text = highScoreInt.ToString();
        }
        else
        {
            highScore.text = 0.ToString();
        }
    }
}
