using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderQueen : MonoBehaviour
{
    public GameObject racer;
    public AudioSource attack;
    private float spiderSpeed = 0.6f;
    private float startTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        transform.LookAt(racer.transform);
        startTime = System.DateTime.Now.Second;
    }

    // Update is called once per frame
    void Update()
    {
        //if (System.DateTime.Now.Second - startTime > 3)
        //{
        transform.position = Vector3.Lerp(transform.position, racer.transform.position, spiderSpeed * Time.deltaTime);
        //}
        //Debug.Log(System.DateTime.Now.Second - startTime+"  "+Vector3.Distance(transform.position, racer.transform.position));

        if(Vector3.Distance(transform.position, racer.transform.position) < 20f && !attack.isPlaying)
        {
            attack.Play();
        }
    }
}
