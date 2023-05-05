using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggController : MonoBehaviour
{

    public GameObject egg;
    public GameObject bomb;
    public Transform[] positions;
    public float tickTime = 3f;
    public PlayerController player;
    private float currTime = 0f;

    void Start()
    {
        currTime = Time.time;
        generateEgg();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Time.time - currTime > tickTime)
        {
            generateEgg();
            currTime = Time.time;
        }
    }

    public void generateEgg()
    {
        int rand = Random.Range(0, 4);
        // int randBomb = Random.Range(0, 10);
        // if (randBomb < 3)
        // {
        //     bomb = Instantiate(bomb, positions[rand].position, Quaternion.identity);
        //     BombBehaviour behaviour = bomb.GetComponent<BombBehaviour>();
        //     behaviour.spawnPosition = rand;
        //     if (rand == 2 || rand == 3)
        //     {
        //         behaviour.isLeft = false;
        //     }
        //     else
        //     {
        //         behaviour.isLeft = true;
        //     }
        // }
        // else
        // {
        GameObject newEgg = Instantiate(egg, positions[rand].position, Quaternion.identity);
        EggBehaviour behaviour = newEgg.GetComponent<EggBehaviour>();
        behaviour.spawnPosition = rand;
        if (rand == 2 || rand == 3)
        {
            behaviour.isLeft = false;
        }
        else
        {
            behaviour.isLeft = true;
        }
        //}
    }


}
