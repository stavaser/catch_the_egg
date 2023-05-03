using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI score;

    private SpawnController spawnController;
    private int scoreCounter = 0;
    public bool isGameActive;

    // Start is called before the first frame update
    void Start()
    {
        spawnController = GameObject.Find("Spawner").GetComponent<SpawnController>();

        isGameActive = true;
        StartCoroutine(spawnController.SpawnRandom());
    }

    public void UpdateScore()
    {
        scoreCounter++;
        score.text = scoreCounter.ToString();
    }
}
