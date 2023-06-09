using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBehaviour : MonoBehaviour
{
    private int currentPosition = 0;
    private float currTime = 0f;
    public float tickTime = 1f;
    public bool isLeft = true;
    public int spawnPosition;
    private AudioSource audioSource;

    void Start()
    {
        currTime = Time.time;
        audioSource = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        if (Time.time - currTime > tickTime)
        {
            moveToNextPosition();
            currTime = Time.time;

        }
    }

    void moveToNextPosition()
    {
        if (currentPosition == 5)
        {
            GameObject.Find("GameController").GetComponent<GameController>().CheckBombIsCaught(spawnPosition);
            Destroy(gameObject);
        }

        if (currentPosition < 5)
        {
            float newX = 0f;
            if (isLeft)
            {
                newX = gameObject.transform.position.x + 0.5f;
            }
            else
            {
                newX = gameObject.transform.position.x - 0.5f;
            }
            Vector3 pos = new Vector3(newX, gameObject.transform.position.y - 0.25f, gameObject.transform.position.z);
            gameObject.transform.position = pos;
            gameObject.transform.eulerAngles = new Vector3(0, 0, gameObject.transform.eulerAngles.z + 50f);
            currentPosition++;
            audioSource.Play();
        }
    }
}
