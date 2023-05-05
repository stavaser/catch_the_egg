using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject wolfTop;
    public GameObject wolfBottom;
    public GameObject player;

    public bool isUp = true;
    public bool isLeft = false;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (!isUp)
            {
                wolfBottom.SetActive(false);
                wolfTop.SetActive(true);
                isUp = true;
            }
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (isUp)
            {
                wolfBottom.SetActive(true);
                wolfTop.SetActive(false);
                isUp = false;
            }
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            Vector3 theScale = transform.localScale;
            theScale.x = -1;
            player.transform.localScale = theScale;
            isLeft = true;
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            Vector3 theScale = transform.localScale;
            theScale.x = 1;
            player.transform.localScale = theScale;
            isLeft = false;
        }
    }
}
