using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    public GameObject wolfTop;
    public GameObject wolfBottom;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            wolfTop.SetActive(true);
            wolfBottom.SetActive(false);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            wolfTop.SetActive(false);
            wolfBottom.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            Vector3 theScale = transform.localScale;
            theScale.x = 1;
            wolfTop.transform.localScale = theScale;
            wolfBottom.transform.localScale = theScale;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            Vector3 theScale = transform.localScale;
            theScale.x = -1;
            wolfTop.transform.localScale = theScale;
            wolfBottom.transform.localScale = theScale;
        }


    }
}
