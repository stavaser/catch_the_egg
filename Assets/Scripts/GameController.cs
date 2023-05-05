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
}
