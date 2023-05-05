using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggBehaviour : MonoBehaviour
{
    // position of the egg
    private int currentPosition = 0;
    // time since last clock tick
    private float currTime = 0f;
    // tick frequency
    public float tickTime = 1f;
    // egg side
    public bool isLeft = true;
    // position of spawn: 0 - left up. 1 - left down, 2 - right up, 3 - right down
    public int spawnPosition;
    // tick sound
    private AudioSource audioSource;

    void Start()
    {
        currTime = Time.time;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // check if enough time has passed since the last tick
        if (Time.time - currTime > tickTime)
        {
            moveToNextPosition();
            currTime = Time.time;
        }
    }

    void moveToNextPosition()
    {
        // last valid position of the egg
        if (currentPosition == 5)
        {
            // egg falls down -> destroy object
            GameObject.Find("GameController").GetComponent<GameController>().CheckEggIsCaught(spawnPosition);
            Destroy(gameObject);
        }

        // if egg is still falling
        if (currentPosition < 5)
        {
            // new x coord of the falling egg
            float newX = 0f;

            // update the x coord according to the egg's side (left or right)
            if (isLeft)
            {
                newX = gameObject.transform.position.x + 0.5f;
            }
            else
            {
                newX = gameObject.transform.position.x - 0.5f;
            }

            // calculate the next position of the egg
            Vector3 pos = new Vector3(newX, gameObject.transform.position.y - 0.25f, gameObject.transform.position.z);

            // set the new position
            gameObject.transform.position = pos;

            // set egg's rotation
            gameObject.transform.eulerAngles = new Vector3(0, 0, gameObject.transform.eulerAngles.z + 50f);

            // update current position and play sound
            currentPosition++;
            audioSource.Play();
        }
    }
}
