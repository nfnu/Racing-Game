using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightAttack : MonoBehaviour
{
    private int startTime;

    // Start is called before the first frame update
    void Start()
    {
        startTime = 0;
        gameObject.SetActive(true);
        InvokeRepeating("ActiveSet", 1f, 2f);
    }

    void ActiveSet()
    {
        if (gameObject.activeSelf)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
