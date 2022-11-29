using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detector : MonoBehaviour
{
    public GameObject light;
    public bool collides;
    GameObject instr;

    void Start()
    {
        light.SetActive(false);
        collides = false;
        instr = GameObject.Find("instrukcja");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            light.SetActive(true);
            collides = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            light.SetActive(false);
            collides=false;

            instr.SetActive(false);
        }
    }
}
