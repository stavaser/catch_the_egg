using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggController : MonoBehaviour
{
    public Transform[] positions;
    public GameObject egg;
    public float tickTime = 1f;
    private int currentPos = 0;
    private float currTime = 0f;

    void Start()
    {
        currTime = Time.time;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Time.time - currTime > tickTime)
        {
            egg.transform.position = positions[currentPos].position;
            currentPos++;
            currTime = Time.time;
        }
    }
}
