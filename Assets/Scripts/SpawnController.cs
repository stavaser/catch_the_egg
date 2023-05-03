using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField] GameObject EggPrefab;
    [SerializeField] GameObject player;

    public Transform[] startPositions;

    public GameController gameController;

    public int probabilityEgg = 100;

    void Start()
    {

    }

    public IEnumerator SpawnRandom()
    {
        while (gameController.isGameActive)
        {
            SpawnEgg();

            yield return new WaitForSeconds(1.0f);
        }
    }

    void SpawnEgg()
    {
        Vector3 spawnPosition = startPositions[Random.Range(0, startPositions.Length)].position;
        Instantiate(EggPrefab, spawnPosition, Quaternion.identity);
    }


}
