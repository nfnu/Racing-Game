using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    private Vector3 startPos;
    private Vector3 endPos;
    private float monsterSpeed;
    public AudioSource batSound;
    public GameObject racer;
    public bool back;

    // Start is called before the first frame update
    void Start()
    {
        monsterSpeed = 0.85f;
        if (!back)
        {
            startPos = transform.position;
            endPos = new Vector3(startPos.x + 20, startPos.y, startPos.z);
        }
        else
        {
            endPos = transform.position;
            startPos = new Vector3(endPos.x - 20, endPos.y, endPos.z);
        }
        //Debug.Log("Start Pos " + startPos.x+" End Pos " + endPos.x);
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, racer.transform.position) < 80f && !batSound.isPlaying)
        {
            batSound.Play();
        }
        //Debug.Log("Start Pos " + transform.position.x + " Back " + back);
        if ((int)(transform.position.x) >= (int)(endPos.x))
        {
            back = true;
        }
        else if ((int)(transform.position.x) <= (int)(startPos.x))
        {
            back = false;
        }
        if (!back)
        {
            transform.position = Vector3.Lerp(transform.position, endPos, monsterSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, startPos, monsterSpeed * Time.deltaTime);
        }
    }
}
