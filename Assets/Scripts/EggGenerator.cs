using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggGenerator : MonoBehaviour
{

    public Transform eggPosition1;
    public Transform eggPosition2;
    public Transform eggPosition3;
    public Transform eggPosition4;
    public GameObject eggPrefab;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CreateEgg", 2.0f, 1);
    }

    void CreateEgg()
    {
        GameObject eggClone = Instantiate(eggPrefab);
        EggController eggController = eggClone.AddComponent<EggController>();
        // eggController.spawn = Random.Range(0, 4);

        int rand = Random.Range(0, 4);

        switch (rand)
        {
            case 0:
                Instantiate(eggPrefab, eggPosition1);
                break;
            case 1:
                Instantiate(eggPrefab, eggPosition2);
                break;
            case 2:
                Instantiate(eggPrefab, eggPosition3);
                break;
            case 3:
                Instantiate(eggPrefab, eggPosition4);
                break;
        }
    }
}
