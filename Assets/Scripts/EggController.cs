using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggController : MonoBehaviour
{

    public GameObject egg;
    public GameObject bomb;

    // spawn positions
    public Transform[] positions;

    // egg spawn time 
    public float tickTime = 3f;
    // current time since the last tick
    private float currTime = 0f;

    void Start()
    {
        currTime = Time.time;
        generateEgg();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // check if enough time has passed since the last tick
        if (Time.time - currTime > tickTime)
        {
            // spawn new egg at random
            generateEgg();
            currTime = Time.time;
        }
    }

    public void generateEgg()
    {
        // get random position index
        int rand = Random.Range(0, 4);

        // TODO: code for generating bomb
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

        // create new egg
        GameObject newEgg = Instantiate(egg, positions[rand].position, Quaternion.identity);

        // set the egg's spawn position
        EggBehaviour behaviour = newEgg.GetComponent<EggBehaviour>();
        behaviour.spawnPosition = rand;

        // determine the egg's side (left or right)
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
