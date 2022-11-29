using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class movement : MonoBehaviour
{
    GameObject det;
    detector d;
    int floor;
    Vector3 nextFloor;
    public int m;
    float y;
    int w;
    public GameObject instr;
    int bla;

    private AudioSource aus;
    public AudioClip[] clips;

    void Start()
    {
        det = GameObject.Find("det");
        d = (detector)det.GetComponent(typeof(detector));
        floor = 1;
        nextFloor = transform.position;
        m = 0;
        y = transform.position.y;
        w = Random.Range(0, 2);
        aus = GetComponent<AudioSource>();
        instr.SetActive(false);
        bla = 0;
    }

    private void Update()
    {
        if (d.collides ==true && bla==0) { instr.SetActive(true); }
        if (d.collides == true && m==1)
        {
            instr.SetActive(false);
            bla = 1;
            if (floor == 0 ^ floor == 2)
            {
                y = 5;
                if(transform.position.y > 4.9 && transform.position.y < 5.1)
                {
                    floor = 1;
                    m = 0;
                    aus.clip = clips[1];
                    aus.Play();
                    w = Random.Range(0, 2);
                }
            }
            else if (floor == 1)
            {
                if (w == 1)
                {
                    y = 11;
                    if (transform.position.y > 10)
                    {
                        floor = 2;
                        m = 0;
                        aus.clip = clips[2];
                        aus.Play();
                    }
                }
                else if (w == 0)
                {
                    y = -1;
                    if (transform.position.y < 0)
                    {
                        floor = 0;
                        m = 0;
                        aus.clip = clips[0];
                        aus.Play();
                    }
                }
            }
            nextFloor = new Vector3(transform.position.x, y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, nextFloor, Time.deltaTime / 1);
        }
        /*if (transform.position.y == 5) 
        { floor = 1; }
        else if(transform.position.y == 0)
        { floor = 0; }
        else if (transform.position.y == 10)
        { floor = 2; }*/
    }

}
