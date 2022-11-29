using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lift : MonoBehaviour
{
    private Camera camera;
    GameObject go;
    movement elevator;

    private void Start()
    {
        camera = Camera.main;
        go = GameObject.Find("elevator");
        elevator = (movement)go.GetComponent(typeof(movement));
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, 150))
            {
                if (hit.collider.tag == "btn")
                {
                    elevator.m=1;
                }
            }
        }
    }
}
